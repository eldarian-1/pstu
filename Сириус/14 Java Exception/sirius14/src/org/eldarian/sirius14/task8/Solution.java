package org.eldarian.sirius14.task8;

public class Solution {
    public static void main(String[] args) {
        log("In main method");
    }
    public static void log(String s) {
        StackTraceElement item = Thread.currentThread().getStackTrace()[2];
        System.out.println(item.getClassName() + ": " + item.getMethodName() + ": " + s);
    }
}
