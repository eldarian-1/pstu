package org.eldarian.task1;

public class Solution {
    public static void main(String[] args) {
        int a = 0;
        int b = (byte) a + 46;
        byte c = (byte) (a * b);
        double f = (short) 1234.15;
        long d = (char) (a + f / c + b);
        System.out.println(d);
    }
}
