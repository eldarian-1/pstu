cmake_minimum_required(VERSION 3.20)
project(sysprog C)

set(CMAKE_C_STANDARD 11)
set(THREADS_PREFER_PTHREAD_FLAG ON)
find_package(Threads REQUIRED)

include_directories(.)

add_library(common server.h server.c client.h client.c consts.h)

add_executable(server main_server.c)
add_executable(client main_client.c)
add_executable(work main_work.c)

target_link_libraries(common PRIVATE m)
target_link_libraries(server PRIVATE Threads::Threads common)
target_link_libraries(client PRIVATE common)
target_link_libraries(work PRIVATE Threads::Threads common)
