package org.eldarian.sirius14.task18;

import java.io.IOException;

public class Solution {
    public static void main(String[] args) {
        try {
            throw new MyException1();
        } catch (MyException1 e) {
            System.out.println(e.getClass().getName());
        }
        throw new MyException3();
    }
    static class MyException1 extends IOException {}
    static class MyException2 extends IOException {}
    static class MyException3 extends RuntimeException {}
    static class MyException4 extends RuntimeException {}
}
