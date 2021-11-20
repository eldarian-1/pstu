cmake_minimum_required(VERSION 3.16.0)

project(graphics VERSION 1.0.0 LANGUAGES CXX)

set(CMAKE_CXX_STANDARD 20)
set(CMAKE_PREFIX_PATH "/home/eldarian/Qt/5.15.2/gcc_64")
set(CMAKE_CXX_STANDARD_REQUIRED ON)

set(CMAKE_AUTOMOC ON)
set(CMAKE_AUTORCC ON)
set(CMAKE_AUTOUIC ON)

find_package(Qt5 COMPONENTS Core Gui Widgets REQUIRED)

include_directories(common)

add_library(common common/Splines.h common/Splines.cpp
        common/Matrix.h common/Matrix.cpp
        common/Const.cpp common/Const.h
        common/Graphic.cpp common/Graphic.h
        common/Func.cpp common/Func.h
        common/widgets/Slider.cpp common/widgets/Slider.h)

add_executable(home home/main.cpp home/Home.h)

add_executable(point point/main.cpp point/Point.h)

add_executable(human human/main.cpp human/Human.h)

add_executable(spline spline/main.cpp spline/Splines.h spline/Splines.cpp)

add_executable(multy multy/main.cpp multy/Multy.h multy/Multy.cpp)

add_executable(fractal fractal/main.cpp
        fractal/Canvas.cpp fractal/Canvas.h
        fractal/FractalEditor.cpp fractal/FractalEditor.h)

add_executable(line line/main.cpp
        line/Canvas.h line/Canvas.cpp
        line/figures/Line.h line/figures/Line.cpp
        line/Mode.cpp line/Mode.h
        line/modes/CreateMode.cpp line/modes/CreateMode.h
        line/widgets/LineEditor.cpp line/widgets/LineEditor.h
        line/modes/EditMode.cpp line/modes/EditMode.h
        line/figures/Point.cpp line/figures/Point.h
        line/modes/RemoveMode.cpp line/modes/RemoveMode.h
        line/widgets/LineCleaner.cpp line/widgets/LineCleaner.h)

target_link_libraries(common PRIVATE Qt5::Core Qt5::Gui Qt5::Widgets)

target_link_libraries(home PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(point PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(human PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(spline PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(multy PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(fractal PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
target_link_libraries(line PRIVATE common Qt5::Core Qt5::Gui Qt5::Widgets)
