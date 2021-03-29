package org.eldarian.sirius12.task28;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        int[] array = new int[20];
        int[] array1 = new int[10];
        int[] array2 = new int[10];
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 20; i++) {
            array[i] = scanner.nextInt();
        }
        for(int i = 0; i < 10; i++) {
            array1[i] = array[i];
            array2[i] = array[i + 10];
            System.out.println(array[i]);
        }
    }
}
