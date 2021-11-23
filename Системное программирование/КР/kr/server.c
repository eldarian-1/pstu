#include "server.h"
#include "consts.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>
#include <sys/ipc.h>
#include <sys/sem.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

void server_run(int logged) {
    int listener;
    struct sockaddr_in addr;
    resources_t resources = {{}, logged, 0, 0};
    sem_init(&resources.semaphore, 0, 1);

    listener = socket(AF_INET, SOCK_STREAM, 0);
    if (listener < 0) {
        perror("socket");
        exit(1);
    }

    addr.sin_family = AF_INET;
    addr.sin_port = htons(PORT);
    addr.sin_addr.s_addr = htonl(INADDR_ANY);
    if (bind(listener, (struct sockaddr *)&addr, sizeof(addr)) < 0) {
        perror("bind");
        exit(2);
    }

    listen(listener, 1);

    while (1) {
        thread_data_t *data = malloc(sizeof(thread_data_t));
        data->socket = accept(listener, 0, 0);
        data->resources = &resources;
        pthread_t thread;
        if(pthread_create(&thread, NULL, &socket_thread, data)) {
            exit(-1);
        }
    }
}

void *socket_thread(void *arg) {
    char buf[1024];
    int bytes_read;
    thread_data_t *data = (thread_data_t*)arg;

    if (data->socket < 0) {
        perror("accept");
        exit(3);
    }

    while (1) {
        memset(buf, '\0', 1024);
        bytes_read = recv(data->socket, buf, 1024, 0);
        if(bytes_read <= 0) break;
        else {
            sem_wait(&data->resources->semaphore);
            int client_number;
            if (isNumber(buf, &client_number)) {
                char *number = numberToString(data->resources->sum += client_number);
                ++data->resources->i;
                if (data->resources->logged) {
                    printf("Клиент %d: %s\nТекущая сумма: %d\n",
                           data->resources->i, buf, data->resources->sum);
                }
                send(data->socket, number, strlen(number), 0);
                free(number);
            } else {
                ++data->resources->i;
                const char *warn = "Некорректный ввод!";
                printf("Клиент %d ввёл строку: %s\n", data->resources->i, buf);
                send(data->socket, warn, strlen(warn), 0);
            }
            sem_post(&data->resources->semaphore);
        }
    }

    close(data->socket);
    free(arg);
    return 0;
}

int isNumber(const char *input, int *output) {
    *output = 0;
    int n = strlen(input), first = 0;
    if(n && input[0] == '-') {
        first = 1;
    }
    if (n == first + 1 && input[first] == '0') {
        return 1;
    } else if (n <= first || input[first] < '1' || input[first] > '9') {
        return 0;
    } else {
        *output = input[first] - '0';
    }
    for (int i = first + 1; i < n; ++i) {
        if (input[i] < '0' || input[i] > '9') {
            return 0;
        } else {
            *output *= 10;
            *output += input[i] - '0';
        }
    }
    if (first) {
        *output = -*output;
    }
    return 1;
}

char *numberToString(int number) {
    char *numberArray;
    if (number == 0) {
        numberArray = malloc(2 * sizeof(char));
        numberArray[0] = '0';
        numberArray[1] = '\0';
        return numberArray;
    }
    int i, first;
    if (number < 0) {
        first = 1;
        number = -number;
    } else {
        first = 0;
    }
    int n = (int)log10((double)number) + first + 1;
    numberArray = calloc(n + first + 1, sizeof(char));
    for (i = n - 1; i >= first; --i, number /= 10) {
        numberArray[i] = (char)((number % 10) + '0');
    }
    if (first) {
        numberArray[0] = '-';
    }
    numberArray[n] = '\0';
    return numberArray;
}
