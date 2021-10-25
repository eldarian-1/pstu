#pragma once

#include <QString>
#include <QTextStream>

namespace Arithmetic {
    struct Freq {
        QChar symbol;
        int count;
    };

    struct Range {
        double lower, upper;
    };

    struct Symbol {
        QChar symbol;
        Range range;
    };

    struct Encoded {
        QList<Symbol> list;
        int count;
        double code;
    };

    Encoded encode(QString text);
    QString decode(Encoded encoded);

    int &count(QList<Freq> &list, const QChar &symbol);
    Range findRange(QList<Symbol> &list, const QChar &symbol);
    Range calculate(const Range &last, const Range &next);
    QList<Symbol> symbols(QString text);
    Symbol findBetween(const QList<Symbol> &list, const double &code);

    class Encoder {
    private:
        QString text;
    public:
        friend QTextStream &operator>>(QTextStream &in, Encoder &encoder);
        friend QTextStream &operator<<(QTextStream &out, const Encoder &encoder);

    };

    class Decoder {
    private:
        QString text;
    public:
        friend QTextStream &operator>>(QTextStream &in, Decoder &decoder);
        friend QTextStream &operator<<(QTextStream &out, const Decoder &decoder);

    };

}
