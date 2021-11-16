#pragma once

#include <QWidget>
#include <QPointF>
#include <vector>

class Multy : public QWidget {
private:
    std::vector<QPointF> vaza = {
            {1, 8},
            {4, 8},
            {3, 7},
            {3, 6},
            {4, 5},
            {5, 4},
            {5, 2},
            {4.5, 1},
            {4, 0},
            {1, 0},
            {0, 2},
            {0, 4},
            {2, 6},
            {2, 7},
    };

    std::vector<QPointF> moon = {
            {0, 5},
            {1, 7},
            {3, 8},
            {5, 7},
            {6, 5},
            {6, 3},
            {5, 1},
            {3, 0},
            {1, 1},
            {0, 3},
            {2, 2},
            {4, 3},
            {4, 5},
            {2, 6},
    };

    std::vector<QPointF> banan = {
            {0, 9},
            {1, 9},
            {1, 8},
            {3, 7},
            {3.5, 6},
            {4, 5},
            {4, 3},
            {3.5, 2},
            {3, 1},
            {1, 0},
            {2, 2},
            {3, 4},
            {2, 6},
            {1, 8},
    };

public:
    Multy();

protected:
    void paintEvent(QPaintEvent *event) override;

};
