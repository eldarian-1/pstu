#pragma once

#include <semaphore.h>

typedef struct {
    sem_t semaphore;
    int logged, i, sum;
} resources_t;

typedef struct {
    int socket;
    resources_t *resources;
} thread_data_t;

void *socket_thread(void *arg);
char *toString(int number);

void server_run(int logged);
