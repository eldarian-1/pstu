package org.eldarian.task11;

public class Solution {
    public static void main(String[] args) {
        System.out.println(min(13, 19));
        System.out.println(min(13l, 19l));
        System.out.println(min(13d, 19d));
    }
    public static int min(int a, int b) {
        return a < b ? a : b;
    }
    public static long min(long a, long b) {
        return a < b ? a : b;
    }
    public static double min(double a, double b) {
        return a < b ? a : b;
    }
}
