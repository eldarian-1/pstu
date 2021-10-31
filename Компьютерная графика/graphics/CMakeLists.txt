cmake_minimum_required(VERSION 3.16.0)

project(common VERSION 1.0.0 LANGUAGES CXX)
project(dz4 VERSION 1.0.0 LANGUAGES CXX)
project(dz6 VERSION 1.0.0 LANGUAGES CXX)
project(line VERSION 1.0.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_PREFIX_PATH "/home/eldarian/Qt/5.15.2/gcc_64")
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5 COMPONENTS Core Gui Widgets REQUIRED)

include_directories(common)

add_library(common common/Splines.h common/Splines.cpp common/Matrix.h common/Matrix.cpp common/Const.cpp common/Const.h common/Graphic.cpp common/Graphic.h)
add_executable(dz4 dz4/main.cpp dz4/Dz4.h)
add_executable(dz5 dz5/main.cpp dz5/Dz5.h)
add_executable(dz6 dz6/main.cpp dz6/Dz6.h dz6/Dz6.cpp)
add_executable(line line/main.cpp line/Canvas.h line/Canvas.cpp line/Line.h line/Line.cpp line/dialogs/WeightDialog.h line/dialogs/WeightDialog.cpp line/Mode.cpp line/Mode.h line/modes/CreateMode.cpp line/modes/CreateMode.h line/modes/MoveMode.cpp line/modes/MoveMode.h line/widgets/LineEditor.cpp line/widgets/LineEditor.h line/widgets/Slider.cpp line/widgets/Slider.h)

target_link_libraries(common PRIVATE Qt5::Core Qt5::Gui Qt5::Widgets)

target_link_libraries(dz4 PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(dz5 PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(dz6 PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(line PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
