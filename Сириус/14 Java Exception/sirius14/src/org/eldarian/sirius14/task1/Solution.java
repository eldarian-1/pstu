package org.eldarian.sirius14.task1;

public class Solution {
    public static void main(String[] args) {
        System.out.println("Для method1():");
        for(StackTraceElement item : method1()) {
            System.out.println(item.getMethodName());
        }
        System.out.println("\nДля method2():");
        for(StackTraceElement item : method2()) {
            System.out.println(item.getMethodName());
        }
        System.out.println("\nДля method3():");
        for(StackTraceElement item : method3()) {
            System.out.println(item.getMethodName());
        }
        System.out.println("\nДля method4():");
        for(StackTraceElement item : method4()) {
            System.out.println(item.getMethodName());
        }
        System.out.println("\nДля method5():");
        for(StackTraceElement item : method5()) {
            System.out.println(item.getMethodName());
        }
    }
    public static StackTraceElement[] method1() {
        method2();
        return Thread.currentThread().getStackTrace();
    }
    public static StackTraceElement[] method2() {
        method3();
        return Thread.currentThread().getStackTrace();
    }
    public static StackTraceElement[] method3() {
        method4();
        return Thread.currentThread().getStackTrace();
    }
    public static StackTraceElement[] method4() {
        method5();
        return Thread.currentThread().getStackTrace();
    }
    public static StackTraceElement[] method5() {
        return Thread.currentThread().getStackTrace();
    }
}
