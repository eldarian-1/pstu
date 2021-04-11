package org.eldarian.sirius14.task5;

public class Solution {
    public static void main(String[] args) {
        try {
            String s = null;
            String m = s.toLowerCase();
        } catch(NullPointerException e) {
            System.out.println(e.getClass().getName());
        }
    }
}
