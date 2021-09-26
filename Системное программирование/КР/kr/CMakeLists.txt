cmake_minimum_required(VERSION 3.20)
project(server C)
project(client C)

set(CMAKE_C_STANDARD 11)

add_executable(server src/server/main.c src/common.h)
add_executable(client src/client/main.c src/common.h)
target_link_libraries(server m)