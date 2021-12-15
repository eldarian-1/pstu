#include "Multy.h"

#include <QPainter>
#include <QPaintEvent>

Multy::Multy() : QWidget() {
    resize(900, 900);
    int n = moon.size();
    for(int i = 0; i < n; ++i) {
        vaza[i].rx() *= 100;
        vaza[i].ry() = 900 - vaza[i].ry() * 100;
        moon[i].rx() *= 100;
        moon[i].ry() = 900 - moon[i].ry() * 100;
        banan[i].rx() *= 100;
        banan[i].ry() = 900 - banan[i].ry() * 100;
    }
}

void Multy::paintEvent(QPaintEvent *event) {
    int n = moon.size();
    std::vector<QPointF> r(n);
    for(int i = 0; i < n; ++i) {
        r[i].rx() = 1/4. * vaza[i].rx() + 1/4. * moon[i].rx() + 1/2. * banan[i].rx();
        r[i].ry() = 1/4. * vaza[i].ry() + 1/4. * moon[i].ry() + 1/2. * banan[i].ry();
    }

    QPainter p;
    p.begin(this);
    //p.drawPolygon(vaza.data(), r.size());
    //p.drawPolygon(moon.data(), r.size());
    //p.drawPolygon(banan.data(), r.size());
    p.drawPolygon(r.data(), r.size());
    p.end();
}
