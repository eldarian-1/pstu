package org.eldarian.sirius14.task7;

public class Solution {
    public static void main(String[] args) {
        int deep = getStackTraceDepth();
        System.out.println(deep);
    }
    public static int getStackTraceDepth() {
        return Thread.currentThread().getStackTrace().length;
    }
}
