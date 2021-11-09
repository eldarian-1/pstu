#include "server.h"

#include <math.h>
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <pthread.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>

char *toString(int number);

void server_run(int logged) {
    int sock, listener;
    struct sockaddr_in addr;
    char buf[1024];
    int bytes_read;

    listener = socket(AF_INET, SOCK_STREAM, 0);
    if (listener < 0) {
        perror("socket");
        exit(1);
    }

    addr.sin_family = AF_INET;
    addr.sin_port = htons(3456);
    addr.sin_addr.s_addr = htonl(INADDR_ANY);
    if (bind(listener, (struct sockaddr *)&addr, sizeof(addr)) < 0) {
        perror("bind");
        exit(2);
    }

    listen(listener, 1);

    int i = 0;
    int sum = 0;
    while (1) {
        sock = accept(listener, 0, 0);
        if (sock < 0) {
            perror("accept");
            exit(3);
        }

        while (1) {
            memset(buf, '\0', 1024);
            bytes_read = recv(sock, buf, 1024, 0);
            if(bytes_read <= 0) break;
            else {
                char *number = toString(sum += atoi(buf));
                ++i;
                if(logged) {
                    printf("Клиент %d: %s\nТекущая сумма: %d\n", i, buf, sum);
                }
                send(sock, number, strlen(number), 0);
                free(number);
            }
        }

        close(sock);
    }
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
