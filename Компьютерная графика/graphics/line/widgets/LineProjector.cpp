#include "LineProjector.h"

#include "../figures/Line.h"
#include <QLabel>
#include <QLineEdit>
#include <QPushButton>
#include <QVBoxLayout>
#include <QHBoxLayout>

LineProjector::LineProjector(Line *line) : current(line), original(new Line(*line)) {
    lytMain = new QVBoxLayout;
    lytP = new QHBoxLayout;
    lytQ = new QHBoxLayout;
    lblP = new QLabel("p");
    lblQ = new QLabel("p");
    leP = new QLineEdit("0");
    leQ = new QLineEdit("0");
    btnApply = new QPushButton("Принять");

    setLayout(lytMain);
    lytMain->addLayout(lytP);
    lytMain->addLayout(lytQ);
    lytP->addWidget(lblP);
    lytP->addWidget(leP);
    lytQ->addWidget(lblQ);
    lytQ->addWidget(leQ);
    lytMain->addWidget(btnApply);

    connect(btnApply, SIGNAL(released()), SLOT(apply()));
    setWindowTitle("Проекция прямой");
    show();
}

void LineProjector::closeEvent(QCloseEvent *event) {
    emit closed();
}

void LineProjector::apply() {
    QPoint m = original->middle();
    int x1 = original->top().x() - m.x();
    int y1 = original->top().y() - m.y();
    int x2 = original->bottom().x() - m.x();
    int y2 = original->bottom().y() - m.y();
    double p = leP->text().toDouble();
    double q = leQ->text().toDouble();
    auto f = [&](int x, int y) -> QPoint {
        double t = p * x + q * y + 1;
        return {int(x / t), int(y / t)};
    };
    QPoint p1 = f(x1, y1);
    QPoint p2 = f(x2, y2);
    p1.rx() += m.x();
    p1.ry() += m.y();
    p2.rx() += m.x();
    p2.ry() += m.y();
    current->rebuild(p1, p2);
}
