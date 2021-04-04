package org.eldarian.sirius12.task16;

public class Calculator {
    public static int plus(int a, int b) {
        return a + b;
    }
    public static int minus(int a, int b) {
        return a - b;
    }
    public static int multiply(int a, int b) {
        return a * b;
    }
    public static double division(int a, int b) {
        return (double)a / b;
    }
    public static double percent(int a, int b) {
        return a * b / 100.0;
    }
    public static void main(String[] args) {
        int a  = 13;
        int b = 6;
        System.out.println("13 + 6 = " + plus(a, b));
        System.out.println("13 - 6 = " + minus(a, b));
        System.out.println("13 * 6 = " + multiply(a, b));
        System.out.println("13 / 6 = " + division(a, b));
        System.out.println("13 * 6% = " + percent(a, b));
    }
}
