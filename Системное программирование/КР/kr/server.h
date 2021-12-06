#pragma once

#include <semaphore.h>

typedef struct {
    sem_t semaphore;
    int current_index, sum_of_numbers;
} resources_t;

typedef struct {
    int socket;
    resources_t *resources;
} thread_data_t;

void server_run(int logged);
void *socket_thread(void *arg);

int isNumber(const char *input, int *output);
char *numberToString(int number);
