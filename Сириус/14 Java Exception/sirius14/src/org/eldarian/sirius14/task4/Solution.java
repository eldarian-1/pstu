package org.eldarian.sirius14.task4;

public class Solution {
    public static void main(String[] args) {
        try {
            int a = 42 / 0;
        } catch(ArithmeticException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
