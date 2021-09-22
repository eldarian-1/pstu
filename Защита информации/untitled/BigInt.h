#include <iostream>
#include <vector>

class BigInt {
public:
    BigInt();
    BigInt(std::string string);
    BigInt(signed int number);
    BigInt(unsigned int number);
    BigInt(signed long number);
    BigInt(unsigned long number);
    BigInt(signed long long number);
    BigInt(unsigned long long number);
    static std::string to_string(BigInt number);
    friend std::ostream& operator <<(std::ostream& ostream, const BigInt& number);
    static BigInt abs(BigInt number_first);
    static bool even(BigInt number);
    static bool odd(BigInt number);
    static char sign(const BigInt& number);
    static BigInt max(BigInt number_first, BigInt number_second);
    static BigInt min(BigInt number_first, BigInt number_second);
    friend bool operator ==(BigInt number_first, BigInt number_second);
    friend bool operator !=(BigInt number_first, BigInt number_second);
    friend bool operator >(BigInt number_first, BigInt number_second);
    friend bool operator <(const BigInt& number_first, const BigInt& number_second);
    friend bool operator >=(const BigInt& number_first, const BigInt& number_second);
    friend bool operator <=(const BigInt& number_first, const BigInt& number_second);
    friend BigInt operator +(BigInt number_first, BigInt number_second);
    BigInt operator +=(BigInt number);
    BigInt operator ++();
    BigInt operator ++(int);
    friend BigInt operator -(BigInt number_first, BigInt number_second);
    BigInt operator -=(BigInt number);
    BigInt operator --();
    BigInt operator --(int);
    friend BigInt operator *(const BigInt& number_first, const BigInt& number_second);
    BigInt operator *=(const BigInt& number);
    friend BigInt operator /(BigInt number_first, BigInt number_second);
    BigInt operator /=(BigInt number);
    friend BigInt operator %(BigInt number_first, BigInt number_second);
    BigInt operator %=(BigInt number);
    static BigInt pow(BigInt number_first, BigInt number_second);
    static BigInt factorial(BigInt number);
    static BigInt gcd(BigInt number_first, BigInt number_second);
    static BigInt lcm(BigInt number_first, BigInt number_second);
    static BigInt sqrt(const BigInt& number);
    static BigInt cbrt(BigInt number);
private:
    std::vector<int> _digits;
    bool _natural;
    static const int _base = 1000000000;
    static const int _base_length = 9;
    static const int _length_maximum_for_default_multiply = 256;
    static std::vector<int> _string_convert_to_vector(const std::string& string);
    static BigInt _zeroes_leading_remove(BigInt number);
    static BigInt _shift_right(BigInt number, long long shift_power);
    static BigInt _shift_left(BigInt number, long long shift_power);
    static BigInt _multiply_karatsuba(BigInt number_first, BigInt number_second);
    static BigInt _factorial_tree(BigInt number_first, const BigInt& number_second);
};