package org.eldarian.sirius14.task9;

public class Solution {
    public static void main(String[] args) {
        try {
            int[] m = new int[2];
            m[8] = 5;
        } catch(ArrayIndexOutOfBoundsException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
