package org.eldarian.sirius14.task17;

public class Solution {
    public interface Func {
        void run() throws Throwable;
    }
    public static void main(String[] args) {
        handleExceptions(new Solution());
    }
    public static void handleExceptions(Solution obj) {
        obj.helpMethod(obj::method1, obj::method2, obj::method3);
    }
    public void helpMethod(Func... methods) {
        for(Func method : methods) {
            try {
                method.run();
            } catch (Throwable e) {
                printStack(e);
            }
        }
    }
    public static void printStack(Throwable throwable) {
        System.out.println(throwable);
        for (StackTraceElement element : throwable.getStackTrace()) {
            System.out.println(element);
        }
    }
    public void method1() {
        throw new NullPointerException();
    }
    public void method2() {
        throw new IndexOutOfBoundsException();
    }
    public void method3() {
        throw new NumberFormatException();
    }
}
