#include "server.h"
#include "consts.h"

#include <math.h>
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
            char *number = toString(data->resources->sum += atoi(buf));
            ++data->resources->i;
            if(data->resources->logged) {
                printf("Клиент %d: %s\nТекущая сумма: %d\n",
                       data->resources->i, buf, data->resources->sum);
            }
            sem_post(&data->resources->semaphore);
            send(data->socket, number, strlen(number), 0);
            free(number);
        }
    }

    close(data->socket);
    free(arg);
    return 0;
}

char *toString(int number) {
    int n = (int)log10((double)number) + 1;
    int i;
    char *numberArray = calloc(n + 1, sizeof(char));
    for (i = n-1; i >= 0; --i, number /= 10) {
        numberArray[i] = (char)((number % 10) + '0');
    }
    numberArray[n] = '\0';
    return numberArray;
}
