package org.eldarian.sirius12.task46;

public class Solution {
    public static void main(String[] args) throws Throwable {
        for(int i = 30; i >= 0; i--) {
            Thread.sleep(100);
            System.out.println(i);
        }
        System.out.println("Бум!");
    }
}
