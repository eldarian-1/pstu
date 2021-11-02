cmake_minimum_required(VERSION 3.20)
project(associative C)

set(CMAKE_C_STANDARD 11)

add_executable(associative main.c assoc.c assoc.h)
