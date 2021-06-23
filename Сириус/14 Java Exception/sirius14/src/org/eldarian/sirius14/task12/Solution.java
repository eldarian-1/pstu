package org.eldarian.sirius14.task12;

public class Solution {
    public static void main(String[] args) {
        try {
            int num=Integer.parseInt("XYZ");
            System.out.println(num);
        } catch(NumberFormatException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
