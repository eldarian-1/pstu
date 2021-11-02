#include "assoc.h"

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

typedef unsigned char byte;
typedef void (*task)(void**);

const byte BYTE_COUNT = 64;

const char *DIALOG =
        "Меню:\n"
        "\t1. Создать устройство ассоциативной памяти.\n"
        "\t2. Вывести все записи.\n"
        "\t3. Прочитать из памяти.\n"
        "\t4. Записать в память.\n"
        "\t5. Удалить из памяти.\n"
        "\t6. Удалить устройство ассоциативной памяти.\n"
        "\t(*). Выход.\n"
        "Введите номер действия: ";

const task TASKS[] = {
        &create,
        &out,
        &read,
        &write,
        &rem,
        &drop
};

byte read_index();
byte read_value();

void run() {
    int number;
    void *mem = NULL;
    while(1) {
        printf("%s", DIALOG);
        scanf("%d", &number);
        if(1 <= number && number <= 6) {
            if(number > 1 && mem == NULL) {
                printf("Устройство ассоциативной памяти не было создано!\n\n");
                continue;
            } else {
                TASKS[number - 1](&mem);
                printf("\n");
            }
        } else {
            break;
        }
    }
}

void create(void **mem) {
    if(*mem) {
        free(*mem);
    }
    *mem = malloc(BYTE_COUNT);
    for(byte i = 0; i < BYTE_COUNT; ++i) {
        ((byte*)*mem)[i] = 0;
    }
    printf("Устройство ассоциативной памяти создано.\n");
}

void out(void **mem) {
    byte count = 0;
    printf("Содержимое памяти:\n");
    for(byte i = 0; i < BYTE_COUNT; ++i) {
        byte value = ((byte*)*mem)[i];
        if(value) {
            printf("\t%d -> %c\n", i, value);
            ++count;
        }
    }
    if(count == 0) {
        printf("\t<пусто>\n");
    }
    printf("Всего записей: %d\n", count);
}

void read(void **mem) {
    byte index = read_index();
    byte value = ((byte*)*mem)[index];
    printf("%d -> %c\n", index, value);
}

void write(void **mem) {
    byte index = read_index();
    byte value = read_value();
    ((byte*)*mem)[index] = value;
    printf("%d -> %c\n", index, value);
}

void rem(void **mem) {
    byte index = read_index();
    if(((byte*)*mem)[index]) {
        ((byte*)*mem)[index] = 0;
        printf("Байт по индексу %d обнулён.\n", index);
    } else {
        printf("Байт по индексу %d уже был обнулён.\n", index);
    }
}

void drop(void **mem) {
    free(*mem);
    *mem = NULL;
    printf("Устройство ассоциативной памяти удалено.\n");
}

byte read_index() {
    const byte buffer_size = 10;
    char buffer[buffer_size];
    printf("Введите индекс: ");
    scanf("%s", buffer);
    int index = 0;
    for(byte i = 0, n = strlen(buffer); i < n; ++i) {
        index *= 2;
        index += (buffer[i] != '0' ? 1 : 0);
    }
    return index;
}

byte read_value() {
    byte value;
    printf("Введите значение: ");
    scanf("\n%c", &value);
    return value;
}
