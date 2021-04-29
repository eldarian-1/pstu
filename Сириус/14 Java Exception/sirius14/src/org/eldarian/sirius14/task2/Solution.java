package org.eldarian.sirius14.task2;

public class Solution {
    public static void main(String[] args) {
        System.out.println(method1());
        System.out.println(method2());
        System.out.println(method3());
        System.out.println(method4());
        System.out.println(method5());
    }
    public static String method1() {
        method2();
        return Thread.currentThread().getStackTrace()[2].getMethodName();
    }
    public static String method2() {
        method3();
        return Thread.currentThread().getStackTrace()[2].getMethodName();
    }
    public static String method3() {
        method4();
        return Thread.currentThread().getStackTrace()[2].getMethodName();
    }
    public static String method4() {
        method5();
        return Thread.currentThread().getStackTrace()[2].getMethodName();
    }
    public static String method5() {
        return Thread.currentThread().getStackTrace()[2].getMethodName();
    }
}
