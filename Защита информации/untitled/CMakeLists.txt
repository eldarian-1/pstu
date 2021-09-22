cmake_minimum_required(VERSION 3.16.0)

project(untitled VERSION 1.0.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_PREFIX_PATH "/home/eldarian/Qt/5.15.2/gcc_64")
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5 COMPONENTS Core Gui Widgets REQUIRED)

add_executable(untitled main.cpp Window.h TaskManager.h Task.h RSATask.h GronsfeldTask.h GronsfeldTask.cpp ElgamalTask.h DESTask.h CicleTask.h HuffmanTask.h HashTask.h GammaTask.h BigInt.cpp BigInt.h)

target_link_libraries(untitled PRIVATE Qt5::Core Qt5::Gui Qt5::Widgets)