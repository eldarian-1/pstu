package org.eldarian.task7;

public class Solution {
    public static void main(String[] args) {
        float f = (float) 128.50;
        int i = (int) f;
        int b = (byte)(int) (i + f);
        System.out.println(b);
    }
}
