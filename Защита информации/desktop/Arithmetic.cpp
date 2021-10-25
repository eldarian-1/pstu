#include "Arithmetic.h"

QTextStream& operator >> (QTextStream &in, ArithmeticEncoder& encoder) {
    encoder.text = in.readAll();
    return in;
}

QTextStream& operator << (QTextStream &out, const ArithmeticEncoder& encoder) {
    out << encoder.text;
    return out;
}

QTextStream& operator >> (QTextStream &in, ArithmeticDecoder& decoder) {
    decoder.text = in.readAll();
    return in;
}

QTextStream& operator << (QTextStream &out, const ArithmeticDecoder& decoder) {
    out << decoder.text;
    return out;
}
