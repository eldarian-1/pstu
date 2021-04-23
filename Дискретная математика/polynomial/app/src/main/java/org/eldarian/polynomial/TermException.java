package org.eldarian.polynomial;

public class TermException extends Exception {
    public enum Type {
        POLYNOMIAL_DEGREE,
        VARIABLE_COEFFICIENT,
        VARIABLE_DEGREE,
        FORMAT_COEFFICIENT,
        FORMAT_NAME,
        FORMAT_DEGREE
    }

    public TermException(Type type) {
        super(type == Type.POLYNOMIAL_DEGREE ? "Степень полинома должна быть натуральным числом" :
                type == Type.VARIABLE_COEFFICIENT ? "Коэффициент не может быть равен нулю" :
                type == Type.VARIABLE_DEGREE ? "Степень переменной не может быть равна нулю" :
                type == Type.FORMAT_COEFFICIENT ? "Некорректное значение коэффициента" :
                type == Type.FORMAT_NAME ? "Некорректное значение имени" :
                type == Type.FORMAT_DEGREE ? "Некорректное значение степени" :
                        "Неизвестная ошибка");
    }

}
