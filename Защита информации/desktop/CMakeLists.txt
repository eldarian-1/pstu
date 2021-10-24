cmake_minimum_required(VERSION 3.16.0)

project(desktop VERSION 1.0.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_PREFIX_PATH "/home/eldarian/Qt/5.15.2/gcc_64")
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5 COMPONENTS Core Gui Widgets Network REQUIRED)

add_executable(desktop main.cpp Window.h TaskManager.h Task.h RsaTask.h GronsfeldTask.h GronsfeldTask.cpp ElgamalTask.h DesTask.h CicleTask.h HuffmanTask.h HashTask.h GammaTask.h BigInt.cpp BigInt.h RsaTask.cpp Loader.cpp Loader.h ElgamalTask.cpp DesTask.cpp Des.h HuffmanTask.cpp GammaTask.cpp HashTask.cpp)

target_link_libraries(desktop PRIVATE Qt5::Core Qt5::Gui Qt5::Widgets Qt5::Network)
