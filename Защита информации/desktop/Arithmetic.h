#pragma once

#include <QString>
#include <QTextStream>

class ArithmeticEncoder {
private:
    QString text;

public:
    friend QTextStream& operator >> (QTextStream &in, ArithmeticEncoder& encoder);
    friend QTextStream& operator << (QTextStream &out, const ArithmeticEncoder& encoder);

};

class ArithmeticDecoder {
private:
    QString text;

public:
    friend QTextStream& operator >> (QTextStream &in, ArithmeticDecoder& decoder);
    friend QTextStream& operator << (QTextStream &out, const ArithmeticDecoder& decoder);

};
