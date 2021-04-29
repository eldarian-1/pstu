package org.eldarian.sirius14.task19;

public class Solution {
    public static void main(String[] args) {
        try {
            divideByZero();
        } catch (ArithmeticException e) {
            e.printStackTrace();
        }
    }

    private static void divideByZero() {
        System.out.println(13 / 0);
    }
}
