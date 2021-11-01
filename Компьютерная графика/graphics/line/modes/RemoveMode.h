#include "../Mode.h"

class LineCleaner;

class RemoveMode : public QObject, public ModeImpl {
Q_OBJECT

private:
    Line* focusedLine = nullptr;
    LineCleaner* cleaner = nullptr;

protected:
    bool isFocused(Line *line) override { return line == focusedLine; }

public:
    void start();

    void mousePressEvent(QMouseEvent *event) override {}
    void mouseReleaseEvent(QMouseEvent *event) override {}
    void mouseMoveEvent(QMouseEvent *event) override;
    void contextMenuEvent(QContextMenuEvent *event) override {}

private slots:
    void slotClosed();

};
