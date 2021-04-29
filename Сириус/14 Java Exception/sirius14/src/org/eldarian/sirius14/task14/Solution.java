package org.eldarian.sirius14.task14;

public class Solution {
    public static void main(String[] args) throws Exception {
        try {
            method1();
        } catch (Exception1 | Exception2 | Exception3 e) {
            System.out.println(e.getClass().getName());
        }
    }
    public static void method1() throws Exception1, Exception2, Exception3 {
        int i = (int) (Math.random() * 3);
        if (i == 0) {
            throw new Exception1();
        } else if (i == 1) {
            throw new Exception2();
        } else if (i == 2) {
            throw new Exception3();
        }
    }
    public static class Exception1 extends Exception {}
    public static class Exception2 extends Exception {}
    public static class Exception3 extends Exception {}
}
