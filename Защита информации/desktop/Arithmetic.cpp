#include "Arithmetic.h"

int& Arithmetic::count(QList<Freq>& list, const QChar& symbol) {
    for(auto& item : list) {
        if(item.symbol == symbol) {
            return item.count;
        }
    }
    list.append({symbol, 0});
    return list.back().count;
}

Arithmetic::Range Arithmetic::findRange(QList<Symbol>& list, const QChar& symbol) {
    for(auto& item : list) {
        if(item.symbol == symbol) {
            return item.range;
        }
    }
    return {0, 1};
}

Arithmetic::Range Arithmetic::calculate(const Range& last, const Range& next) {
    auto calc = [&last](double d) -> double {
        return last.lower + (last.upper - last.lower) * d;
    };
    return {calc(next.lower), calc(next.upper)};
}

QList<Arithmetic::Symbol> Arithmetic::symbols(QString text) {
    int n = text.size();
    QList<Freq> freq;
    QList<Symbol> result;
    for(auto ch : text) {
        ++count(freq, ch);
    }
    double lastLower = 0.;
    for(auto& item : freq) {
        double fc = (double)item.count / n;
        result.append({item.symbol, {lastLower, lastLower + fc}});
        lastLower += fc;
    }
    return result;
}

Arithmetic::Encoded Arithmetic::encode(QString text) {
    Encoded result;
    result.list = symbols(text);
    result.count = text.count();
    auto &list = result.list;
    Range range = {0, 1};
    for(auto ch : text) {
        range = calculate(range, findRange(list, ch));
    }
    result.code = (range.lower + range.upper) / 2;
    return result;
}

Arithmetic::Symbol Arithmetic::findBetween(const QList<Symbol>& list, const double& code) {
    for(auto& item : list) {
        if(item.range.lower <= code && code < item.range.upper) {
            return item;
        }
    }
    return {'a', {0, 1}};
}

QString Arithmetic::decode(Arithmetic::Encoded encoded) {
    QString result;
    double code = encoded.code;
    for(int i = 0; i < encoded.count; ++i) {
        auto symbol = findBetween(encoded.list, code);
        result += symbol.symbol;
        code = (code - symbol.range.lower) / (symbol.range.upper - symbol.range.lower);
    }
    return result;
}

QTextStream& Arithmetic::operator >> (QTextStream &in, Arithmetic::Encoder& encoder) {
    encoder.text = in.readAll();
    return in;
}

QTextStream& Arithmetic::operator << (QTextStream &out, const Arithmetic::Encoder& encoder) {
    auto ec = Arithmetic::encode(encoder.text);
    out << ec.list.size();
    for(auto item : ec.list) {
        out << item.symbol << " " << item.range.lower << " " << item.range.upper << "\n";
    }
    out << ec.count << " " << ec.code;
    return out;
}

QTextStream& Arithmetic::operator >> (QTextStream &in, Arithmetic::Decoder& decoder) {
    Arithmetic::Encoded ec;
    int n;
    in >> n;
    for(int i = 0; i < n; ++i) {
        QChar symbol, space, nl;
        double lower, upper;
        in >> symbol >> space >> lower >> space >> upper >> nl;
        ec.list.append({symbol, {lower, upper}});
    }
    in >> ec.count;
    in >> ec.code;
    decoder.text = Arithmetic::decode(ec);
    return in;
}

QTextStream& Arithmetic::operator << (QTextStream &out, const Arithmetic::Decoder& decoder) {
    out << decoder.text;
    return out;
}
