package org.eldarian.sirius12.task44;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        int[] array = new int[20];
        Scanner scanner = new Scanner(System.in);
        int min = 2000000000, max = -2000000000;
        for(int i = 0; i < 20; i++) {
            array[i] = scanner.nextInt();
            min = Math.min(min, array[i]);
            max = Math.max(max, array[i]);
        }
        System.out.println("Min: " + min + "; Max: " + max);
    }
}
