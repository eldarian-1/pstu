cmake_minimum_required(VERSION 3.20)
project(sysprog C)

set(CMAKE_C_STANDARD 11)
set(THREADS_PREFER_PTHREAD_FLAG ON)
find_package(Threads REQUIRED)

include_directories(.)

add_executable(server main_server.c server.h server.c consts.h)
add_executable(client main_client.c client.h client.c consts.h)

target_link_libraries(server PRIVATE Threads::Threads m)
target_link_libraries(client)
