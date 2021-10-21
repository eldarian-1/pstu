#pragma once

#include <QTimer>
#include <QColor>
#include <QLabel>
#include <QWidget>
#include <QSlider>
#include <QPainter>
#include <QVBoxLayout>

#include <Matrix.h>

class Dz5 : public QWidget {
private:
    Matrix left {
            {30, 100, 1},
            {35, 120, 1},
            {10, 110, 1},
            {10, 120, 1},
            {10, 110, 1},
            {35, 120, 1},
            {30, 100, 1},
            {44, 120, 1},
            {20, 110, 1},
            {20, 120, 1},
            {20, 110, 1},
            {44, 120, 1},
            {30, 100, 1},
            {60, 80, 1},
            {50, 102, 1},
            {60, 120, 1},
            {50, 102, 1},
            {60, 80, 1},
            {60, 100, 1},
            {70, 120, 1},
            {60, 100, 1},
            {60, 80, 1},
            {68, 77, 1},
            {70, 70, 1},
            {82, 70, 1},
            {80, 85, 1},
            {70, 82, 1},
            {68, 77, 1},
            {60, 80, 1},
    }, right {
            {350, 90, 1},
            {338, 113, 1},
            {320, 100, 1},
            {312, 107, 1},
            {320, 100, 1},
            {338, 113, 1},
            {350, 90, 1},
            {373, 90, 1},
            {362, 114, 1},
            {371, 120, 1},
            {362, 114, 1},
            {373, 90, 1},
            {350, 90, 1},
            {360, 60, 1},
            {365, 78, 1},
            {387, 62, 1},
            {365, 78, 1},
            {360, 60, 1},
            {337, 65, 1},
            {338, 85, 1},
            {337, 65, 1},
            {360, 60, 1},
            {362, 50, 1},
            {356, 46, 1},
            {361, 35, 1},
            {372, 40, 1},
            {370, 50, 1},
            {362, 50, 1},
            {360, 60, 1},
    };
    QHBoxLayout *lyt;
    QLabel *lblFrom, *lblTo;
    QSlider *sld;

public:
    Dz5() : QWidget() {
        setWindowTitle("Д/З №5");
        setFixedSize(400, 140);

        lyt = new QHBoxLayout;
        lblFrom = new QLabel("t: 0.0");
        lblTo = new QLabel(" 1.0");
        sld = new QSlider(Qt::Horizontal);

        lyt->setAlignment(Qt::AlignTop);
        sld->setRange(0, 1000);
        setLayout(lyt);
        lyt->addWidget(lblFrom);
        lyt->addWidget(sld);
        lyt->addWidget(lblTo);

        QTimer *timer = new QTimer(this);
        connect(timer, SIGNAL(timeout()), SLOT(repaint()));
        timer->start(20);
    }

private:
    QPoint* getPoints(Matrix m) {
        int n = m.n();
        QPoint *result = new QPoint[n];
        for(int i = 0; i < n; ++i) {
            result[i] = QPoint(m[i][0], m[i][1]);
        }
        return result;
    }

    Matrix morfing(double t) {
        int n = left.n(), m = left.m();
        Matrix result(n, m);
        for(int i = 0; i < n; ++i) {
            for(int j = 0; j < m; ++j) {
                result[i][j] = (1 - t) * left[i][j] + t * right[i][j];
            }
        }
        return result;
    }

protected:
    void paintEvent(QPaintEvent *event) override {
        int n = left.n();
        double t = sld->value() / 1000.0;
        QPoint* l = getPoints(left);
        QPoint* r = getPoints(right);
        QPoint* m = getPoints(morfing(t));

        QPainter painter;
        painter.begin(this);
        painter.drawText(180, 13, QString::asprintf("%.3f", t));
        painter.setPen(Qt::green);
        painter.drawPolygon(l, n);
        painter.setPen(Qt::blue);
        painter.drawPolygon(r, n);
        painter.setPen(Qt::red);
        painter.drawPolygon(m, n);
        painter.end();

        delete[] l;
        delete[] r;
        delete[] m;
    }

};
