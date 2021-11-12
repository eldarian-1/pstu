#include <stdio.h>
#include <unistd.h>
#include <pthread.h>

#include "server.h"
#include "client.h"

void *server_thread(void *arg);
void *client_thread(void *arg);

int main() {
    int connections = 0;
    pthread_t server, client;
    if(pthread_create(&server, NULL, &server_thread, NULL)) {
        return -1;
    }
    if(pthread_create(&client, NULL, &client_thread, &connections)) {
        return -1;
    }
    do {
        if(!connections) {
            printf("Введите число подключений (отрицательное число - выход): ");
            scanf("%d", &connections);
            getchar();
        } else {
            usleep(100);
        }
    } while (connections >= 0);
    pthread_join(client, NULL);
    return 0;
}

int predicate(void *arg) {
    return *((int*)arg) >= 0;
}

void *server_thread(void *arg) {
    server_run(0);
    pthread_exit(NULL);
}

void *client_thread(void *arg) {
    int *connections = (int*)arg;
    while(*connections >= 0) {
        if (*connections > 0) {
            client_run();
            --*connections;
        } else {
            usleep(100);
        }
    }
    pthread_exit(NULL);
}
