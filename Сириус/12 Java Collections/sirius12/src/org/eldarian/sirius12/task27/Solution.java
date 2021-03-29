package org.eldarian.sirius12.task27;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        int[] array = new int[10];
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 10; i++) {
            array[i] = scanner.nextInt();
        }
        for(int i = 9; i >= 0; i--) {
            System.out.println(array[i]);
        }
    }
}
