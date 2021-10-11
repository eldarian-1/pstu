#include <iostream>
#include <vector>

#include "BigInt.h"

std::vector<int> BigInt::_string_convert_to_vector(const std::string& string) {
    std::vector<int> result;
    if (string.size() % _base_length == 0) {
        result.resize(string.size() / _base_length);
    }
    else {
        result.resize(string.size() / _base_length + 1);
    }
    for (long long string_position = string.size() - 1, result_position = result.size() - 1; string_position >= 0; string_position = string_position - _base_length, result_position = result_position - 1) {
        if ((string_position + 1) - _base_length <= 0) {
            result[result_position] = std::stoi(string.substr(0, (string_position + 1)));
        }
        else {
            result[result_position] = std::stoi(string.substr((string_position + 1) - _base_length, _base_length));
        }
    }
    return result;
}
BigInt::BigInt() {
    _digits.resize(1);
    _digits[0] = 0;
    _natural = true;
}
BigInt::BigInt(std::string string) {
    if (string.empty() or (string.size() == 1 and string[0] == '-')) {
        throw "Fatal error. Type creation is impossible. String does not contain number.";
    }
    if (string[0] == '-') {
        string.erase(string.begin() + 0);
        _natural = false;
    }
    else {
        _natural = true;
    }
    for (long long i = 0; i < string.size(); i = i + 1) {
        if (string[i] < 48 or string[i] > 57) {
            throw "Fatal error. Type creation is impossible. String contain unknown characters.";
        }
    }
    while (string.size() != 1 and string[0] == '0') {
        string.erase(string.begin() + 0);
    }
    _digits = BigInt::_string_convert_to_vector(string);
}
BigInt::BigInt(signed int number) {
    std::string string = std::to_string(number);
    if (string[0] == '-') {
        string.erase(string.begin() + 0);
        _natural = false;
    }
    else {
        _natural = true;
    }
    _digits = BigInt::_string_convert_to_vector(string);
}
BigInt::BigInt(unsigned int number) {
    _natural = true;
    _digits = BigInt::_string_convert_to_vector(std::to_string(number));
}
BigInt::BigInt(signed long number) {
    std::string string = std::to_string(number);
    if (string[0] == '-') {
        string.erase(string.begin() + 0);
        _natural = false;
    }
    else {
        _natural = true;
    }
    _digits = BigInt::_string_convert_to_vector(string);
}
BigInt::BigInt(unsigned long number) {
    _natural = true;
    _digits = BigInt::_string_convert_to_vector(std::to_string(number));
}
BigInt::BigInt(signed long long number) {
    std::string string = std::to_string(number);
    if (string[0] == '-') {
        string.erase(string.begin() + 0);
        _natural = false;
    }
    else {
        _natural = true;
    }
    _digits = BigInt::_string_convert_to_vector(string);
}
BigInt::BigInt(unsigned long long number) {
    _natural = true;
    _digits = BigInt::_string_convert_to_vector(std::to_string(number));
}
std::string BigInt::to_string(BigInt number) {
    if (number._digits.size() == 1 and number._digits[0] == 0) {
        return "0";
    }
    std::string result;
    if (number._natural == false) {
        result.append("-");
    }
    result.reserve(number._digits.size() * (_base_length - 1));
    std::string tmp;
    result.append(std::to_string(number._digits[0]));
    for (long long i = 1; i < number._digits.size(); i = i + 1) {
        tmp = std::to_string(number._digits[i]);
        tmp.reserve(_base_length - tmp.size());
        while (tmp.size() < _base_length) {
            tmp.insert(tmp.begin() + 0, '0');
        }
        result.append(tmp);
    }
    return result;
}
std::ostream& operator <<(std::ostream& ostream, const BigInt& number) {
    std::string string = BigInt::to_string(number);
    for (long long i = 0; i < string.size(); i = i + 1) {
        ostream.put(string[i]);
    }
    return ostream;
}
BigInt BigInt::_zeroes_leading_remove(BigInt number) {
    long long zeroes_leading_border = number._digits.size() - 1;
    for (long long i = 0; i < number._digits.size() - 1; i = i + 1) {
        if (number._digits[i] != 0) {
            zeroes_leading_border = i;
            break;
        }
    }
    number._digits.erase(number._digits.begin() + 0, number._digits.begin() + zeroes_leading_border);
    return number;
}
BigInt BigInt::_shift_right(BigInt number, long long shift_power) {
    number._digits.reserve(shift_power);
    for (long long i = 0; i < shift_power; i = i + 1) {
        number._digits.insert(number._digits.begin() + 0, 0);
    }
    return number;
}
BigInt BigInt::_shift_left(BigInt number, long long shift_power) {
    if (number == 0) {
        return number;
    }
    number._digits.reserve(shift_power);
    for (long long i = 0; i < shift_power; i = i + 1) {
        number._digits.push_back(0);
    }
    return number;
}
BigInt BigInt::abs(BigInt number_first) {
    number_first._natural = true;
    return number_first;
}
bool BigInt::even(BigInt number) {
    if (number._digits[number._digits.size() - 1] % 2 == 0) {
        return true;
    }
    return false;
}
bool BigInt::odd(BigInt number) {
    return (BigInt::even(number) == false);
}
char BigInt::sign(const BigInt& number) {
    if (number._natural == true) {
        return '+';
    }
    return '-';
}
BigInt BigInt::max(BigInt number_first, BigInt number_second) {
    if (number_first > number_second) {
        return number_first;
    }
    return number_second;
}
BigInt BigInt::min(BigInt number_first, BigInt number_second) {
    if (number_first < number_second) {
        return number_first;
    }
    return number_second;
}
int BigInt::log2(BigInt number) {
    int k = 0;
    BigInt nul(0);
    BigInt two(2);
    while (number != nul) {
        number /= two;
        ++k;
    }
    return k;
}
bool operator ==(BigInt number_first, BigInt number_second) {
    if (number_first._natural != number_second._natural) {
        return false;
    }
    if (number_first._digits.size() != number_second._digits.size()) {
        return false;
    }
    for (long long numbers_position = 0; numbers_position < number_first._digits.size(); numbers_position = numbers_position + 1) {
        if (number_first._digits[numbers_position] != number_second._digits[numbers_position]) {
            return false;
        }
    }
    return true;
}
bool operator !=(BigInt number_first, BigInt number_second) {
    return (number_first == number_second == false);
}
bool operator >(BigInt number_first, BigInt number_second) {
    if (number_first == number_second) {
        return false;
    }
    if (number_first._natural == true and number_second._natural == false) {
        return true;
    }
    if (number_first._natural == false and number_second._natural == true) {
        return false;
    }
    if (number_first._natural == false and number_second._natural == false) {
        number_first._natural = true;
        number_second._natural = true;
        return (number_first > number_second == false);
    }
    if (number_first._digits.size() > number_second._digits.size()) {
        return true;
    }
    if (number_first._digits.size() < number_second._digits.size()) {
        return false;
    }
    for (long long numbers_position = 0; numbers_position < number_first._digits.size(); numbers_position = numbers_position + 1) {
        if (number_first._digits[numbers_position] > number_second._digits[numbers_position]) {
            return true;
        }
        if (number_first._digits[numbers_position] < number_second._digits[numbers_position]) {
            return false;
        }
    }
    return false;
}
bool operator <(const BigInt& number_first, const BigInt& number_second) {
    if (number_first != number_second and (number_first > number_second == false)) {
        return true;
    }
    return false;
}
bool operator >=(const BigInt& number_first, const BigInt& number_second) {
    if (number_first > number_second or number_first == number_second) {
        return true;
    }
    return false;
}
bool operator <=(const BigInt& number_first, const BigInt& number_second) {
    if (number_first < number_second or number_first == number_second) {
        return true;
    }
    return false;
}
BigInt operator +(BigInt number_first, BigInt number_second) {
    if (number_first._natural == true and number_second._natural == false) {
        number_second._natural = true;
        return number_first - number_second;
    }
    if (number_first._natural == false and number_second._natural == true) {
        number_first._natural = true;
        return number_second - number_first;
    }
    if (number_first._natural == false and number_second._natural == false) {
        number_second._natural = true;
    }
    if (number_first._digits.size() > number_second._digits.size()) {
        number_second = BigInt::_shift_right(number_second, number_first._digits.size() - number_second._digits.size());
    }
    else {
        number_first = BigInt::_shift_right(number_first, number_second._digits.size() - number_first._digits.size());
    }
    int sum;
    int in_mind = 0;
    for (long long numbers_position = number_first._digits.size() - 1; numbers_position >= 0; numbers_position = numbers_position - 1) {
        sum = number_first._digits[numbers_position] + number_second._digits[numbers_position] + in_mind;
        in_mind = sum / BigInt::_base;
        number_first._digits[numbers_position] = sum % BigInt::_base;
    }
    if (in_mind != 0) {
        number_first._digits.insert(number_first._digits.begin() + 0, in_mind);
    }
    return number_first;
}
BigInt BigInt::operator +=(BigInt number) {
    return *this = *this + std::move(number);
}
BigInt BigInt::operator ++() {
    return *this = *this + 1;
}
BigInt BigInt::operator ++(int) {
    *this = *this + 1;
    return *this = *this - 1;
}
BigInt operator -(BigInt number_first, BigInt number_second) {
    if (number_first._natural == true and number_second._natural == false) {
        number_second._natural = true;
        return number_first + number_second;
    }
    if (number_first._natural == false and number_second._natural == true) {
        number_first._natural = true;
        BigInt tmp = number_first + number_second;
        tmp._natural = false;
        return tmp;
    }
    if (number_first._natural == false and number_second._natural == false) {
        number_first._natural = true;
        number_second._natural = true;
        BigInt tmp;
        tmp = number_first;
        number_first = number_second;
        number_second = tmp;
    }
    if (number_first < number_second) {
        BigInt tmp = number_first;
        number_first = number_second;
        number_second = tmp;
        number_first._natural = false;
    }
    number_second = BigInt::_shift_right(number_second, number_first._digits.size() - number_second._digits.size());
    int different;
    for (long long numbers_position1 = number_first._digits.size() - 1; numbers_position1 >= 0; numbers_position1 = numbers_position1 - 1) {
        different = number_first._digits[numbers_position1] - number_second._digits[numbers_position1];
        if (different >= 0) {
            number_first._digits[numbers_position1] = different;
        }
        else {
            number_first._digits[numbers_position1] = different + BigInt::_base;
            for (long long numbers_position2 = numbers_position1 - 1; true; numbers_position2 = numbers_position2 - 1) {
                if (number_first._digits[numbers_position2] == 0) {
                    number_first._digits[numbers_position2] = BigInt::_base - 1;
                }
                else {
                    number_first._digits[numbers_position2] = number_first._digits[numbers_position2] - 1;
                    break;
                }
            }
        }
    }
    return BigInt::_zeroes_leading_remove(number_first);
}
BigInt BigInt::operator -=(BigInt number) {
    return *this = *this - std::move(number);
}
BigInt BigInt::operator --() {
    return *this = *this - 1;
}
BigInt BigInt::operator --(int) {
    *this = *this - 1;
    return *this = *this + 1;
}
BigInt BigInt::_multiply_karatsuba(BigInt number_first, BigInt number_second) {
    if (std::min(number_first._digits.size(), number_second._digits.size()) <= _length_maximum_for_default_multiply) {
        number_first = BigInt::_zeroes_leading_remove(number_first);
        number_second = BigInt::_zeroes_leading_remove(number_second);
        BigInt result;
        result._digits.resize(number_first._digits.size() + number_second._digits.size());
        long long composition;
        for (long long number_first_position = number_first._digits.size() - 1; number_first_position >= 0; number_first_position = number_first_position - 1) {
            for (long long number_second_position = number_second._digits.size() - 1; number_second_position >= 0; number_second_position = number_second_position - 1) {
                composition = (long long)number_first._digits[number_first_position] * (long long)number_second._digits[number_second_position] + result._digits[number_first_position + number_second_position + 1];
                result._digits[number_first_position + number_second_position + 1] = composition % BigInt::_base;
                result._digits[number_first_position + number_second_position + 1 - 1] = result._digits[number_first_position + number_second_position + 1 - 1] + (composition / BigInt::_base);
            }
        }
        return BigInt::_zeroes_leading_remove(result);
    }
    if (number_first._digits.size() % 2 != 0) {
        number_first._digits.insert(number_first._digits.begin() + 0, 0);
    }
    if (number_second._digits.size() % 2 != 0) {
        number_second._digits.insert(number_second._digits.begin() + 0, 0);
    }
    if (number_first._digits.size() > number_second._digits.size()) {
        number_second = BigInt::_shift_right(number_second, number_first._digits.size() - number_second._digits.size());
    }
    else {
        number_first = BigInt::_shift_right(number_first, number_second._digits.size() - number_first._digits.size());
    }
    long long numbers_size = number_first._digits.size();
    long long numbers_part_size = numbers_size / 2;
    BigInt number_first_part_left;
    BigInt number_first_part_right;
    BigInt number_second_part_left;
    BigInt number_second_part_right;
    number_first_part_left._digits.resize(0);
    number_first_part_right._digits.resize(0);
    number_second_part_left._digits.resize(0);
    number_second_part_right._digits.resize(0);
    number_first_part_left._digits.reserve(numbers_part_size);
    number_first_part_right._digits.reserve(numbers_part_size);
    number_second_part_left._digits.reserve(numbers_part_size);
    number_second_part_right._digits.reserve(numbers_part_size);
    for (long long i = 0; i < numbers_part_size; i = i + 1) {
        number_first_part_left._digits.push_back(number_first._digits[i]);
        number_second_part_left._digits.push_back(number_second._digits[i]);
    }
    for (long long i = numbers_part_size; i < numbers_size; i = i + 1) {
        number_first_part_right._digits.push_back(number_first._digits[i]);
        number_second_part_right._digits.push_back(number_second._digits[i]);
    }
    BigInt product_first = BigInt::_multiply_karatsuba(number_first_part_left, number_second_part_left);
    BigInt product_second = BigInt::_multiply_karatsuba(number_first_part_right, number_second_part_right);
    BigInt product_third = BigInt::_multiply_karatsuba(BigInt::_zeroes_leading_remove(number_first_part_left) + BigInt::_zeroes_leading_remove(number_first_part_right), BigInt::_zeroes_leading_remove(number_second_part_left) + BigInt::_zeroes_leading_remove(number_second_part_right));
    return BigInt::_shift_left(product_first, numbers_size) + BigInt::_shift_left(product_third - product_first - product_second, numbers_part_size) + product_second;
}
BigInt operator *(const BigInt& number_first, const BigInt& number_second) {
    BigInt result = BigInt::_multiply_karatsuba(number_first, number_second);
    result._natural = (number_first._natural == number_second._natural);
    return result;
}
BigInt BigInt::operator *=(const BigInt& number) {
    return *this = *this * number;
}
BigInt operator /(BigInt number_first, BigInt number_second) {
    BigInt result;
    result._natural = (number_first._natural == number_second._natural);
    BigInt number_first_part;
    number_first_part._natural = true;
    number_first._natural = true;
    number_second._natural = true;
    if (number_second == 0) {
        throw "Fatal error. Division whole is impossible. Attempt to divide by zero.";
    }
    if (number_first < number_second) {
        return 0;
    }
    result._digits.resize(0);
    number_first_part._digits.resize(0);
    int quotient;
    int left;
    int middle;
    int right;
    BigInt tmp;
    for (long long number_first_position = 0; number_first_position < number_first._digits.size(); number_first_position = number_first_position + 1) {
        number_first_part._digits.push_back(number_first._digits[number_first_position]);
        quotient = 0;
        left = 0;
        right = BigInt::_base;
        while (left <= right) {
            middle = (left + right) / 2;
            tmp = number_second * middle;
            if (tmp <= number_first_part) {
                quotient = middle;
                left = middle + 1;
            }
            else {
                right = middle - 1;
            }
        }
        number_first_part = number_first_part - (number_second * quotient);
        if (!result._digits.empty() or quotient != 0) {
            result._digits.push_back(quotient);
        }
        if (number_first_part == 0) {
            number_first_part._digits.resize(0);
        }
    }
    return result;
}
BigInt BigInt::operator /=(BigInt number) {
    return *this = *this / std::move(number);
}
BigInt operator %(BigInt number_first, BigInt number_second) {
    BigInt number_first_part;
    number_first_part._natural = true;
    number_first._natural = true;
    number_second._natural = true;
    if (number_second == 0) {
        throw "Fatal error. Division remainder calculation is impossible. Attempt to divide by zero.";
    }
    if (number_first < number_second) {
        return number_first;
    }
    number_first_part._digits.resize(0);
    int quotient;
    int left;
    int middle;
    int right;
    BigInt tmp;
    for (long long number_first_position = 0; number_first_position < number_first._digits.size(); number_first_position = number_first_position + 1) {
        number_first_part._digits.push_back(number_first._digits[number_first_position]);
        quotient = 0;
        left = 0;
        right = BigInt::_base;
        while (left <= right) {
            middle = (left + right) / 2;
            tmp = number_second * middle;
            if (tmp <= number_first_part) {
                quotient = middle;
                left = middle + 1;
            }
            else {
                right = middle - 1;
            }
        }
        number_first_part = number_first_part - (number_second * quotient);
        if (number_first_part == 0) {
            number_first_part._digits.resize(0);
        }
    }
    if (number_first_part._digits.empty()) {
        return 0;
    }
    return number_first_part;
}
BigInt BigInt::operator %=(BigInt number) {
    return *this = *this % std::move(number);
}
BigInt BigInt::pow(BigInt number_first, BigInt number_second) {
    if (number_first == 0 and number_second == 0) {
        throw "Fatal error. Pow calculation is impossible. It is impossible to raise zero to zero degree.";
    }
    if (number_second < 0) {
        throw "Fatal error. Pow calculation is impossible. This class only support whole numbers, so erection to negative degree is impossible.";
    }
    BigInt result = 1;
    while (number_second != 0) {
        if (even(number_second)) {
            number_second = number_second / 2;
            number_first = number_first * number_first;
        }
        else {
            number_second = number_second - 1;
            result = result * number_first;
        }
    }
    return result;
}
BigInt BigInt::modPow(BigInt base, BigInt exp, BigInt modulus) {
    base %= modulus;
    BigInt result = 1;
    while (exp > 0) {
        if (!even(exp)) result = (result * base) % modulus;
        base = (base * base) % modulus;
        exp /= 2;
    }
    return result;
}
BigInt BigInt::mod2Pow(BigInt num1, BigInt exp1, BigInt num2, BigInt exp2, BigInt mod) {
    return (modPow(num1, exp1, mod) * modPow(num2, exp2, mod)) % mod;
}
BigInt BigInt::_factorial_tree(BigInt number_first, const BigInt& number_second) {
    if (number_first > number_second) {
        return 1;
    }
    if (number_first == number_second) {
        return number_first;
    }
    if (number_second - number_first == 1) {
        return number_first * number_second;
    }
    BigInt tmp = (number_first + number_second) / 2;
    return BigInt::_factorial_tree(number_first, tmp) * BigInt::_factorial_tree(tmp + 1, number_second);
}
BigInt BigInt::factorial(BigInt number) {
    if (number < 1) {
        throw "Fatal error. Factorial calculation is impossible. Factorial is defined only for _natural numbers.";
    }
    if (number == 1 or number == 2) {
        return number;
    }
    return _factorial_tree(2, number);
}
BigInt BigInt::gcd(BigInt number_first, BigInt number_second) {
    if (number_first == 0 and number_second == 0) {
        throw "Fatal error. Gcd calculation is impossible. Both numbers are zeros.";
    }
    number_first._natural = true;
    number_second._natural = true;
    if (number_first == 0) {
        return number_second;
    }
    if (number_second == 0) {
        return number_first;
    }
    while (number_first != 0 and number_second != 0) {
        if (number_first > number_second) {
            number_first = number_first % number_second;
        }
        else {
            number_second = number_second % number_first;
        }
    }
    return number_first + number_second;
}
BigInt BigInt::lcm(BigInt number_first, BigInt number_second) {
    if (number_first == 0 or number_second == 0) {
        throw "Fatal error. Lcm calculation is impossible. One of the numbers is zero.";
    }
    number_first._natural = true;
    number_second._natural = true;
    return number_first * number_second / BigInt::gcd(number_first, number_second);
}
BigInt BigInt::sqrt(const BigInt& number) {
    if (number._natural == false) {
        throw "Fatal error. Sqrt calculation is impossible. Sqrt operation over negative numbers has no result.";
    }
    if (number == 0) {
        return number;
    }
    BigInt left = 1;
    BigInt right = number / 2 + 1;
    BigInt middle;
    BigInt result;
    while (left <= right) {
        middle = left + (right - left) / 2;
        if (middle <= number / middle) {
            left = middle + 1;
            result = middle;
        }
        else {
            right = middle - 1;
        }
    }
    return result;
}
BigInt BigInt::cbrt(BigInt number) {
    if (number == 0) {
        return number;
    }
    bool result_natural = number._natural;
    number._natural = true;
    BigInt left = 1;
    BigInt right = number / 2 + 1;
    BigInt middle;
    BigInt result;
    while (left <= right) {
        middle = left + (right - left) / 2;
        if (middle <= number / (middle * middle)) {
            left = middle + 1;
            result = middle;
        }
        else {
            right = middle - 1;
        }
    }
    result._natural = result_natural;
    return result;
}