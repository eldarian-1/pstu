#pragma once

#include <vector>
#include <QWidget>

struct Level {
    double weight;
    double multiplier;
    QColor color;
};

struct FractalSettings {
    QPoint first;
    QPoint second;
    std::vector<double> angles;
    std::vector<Level> levels;

    static FractalSettings *instance();

private:
    static FractalSettings *_instance;

};

class FractalEditor : public QWidget {
Q_OBJECT

private:

public:
    FractalEditor();

protected:
    void closeEvent(QCloseEvent *event) override;

};
