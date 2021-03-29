package org.eldarian.sirius12.task32;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) throws Exception {
        Scanner reader = new Scanner(System.in);
        int[] array = new int[20];
        for (int i = 0; i < 20; i++) {
            array[i] = reader.nextInt();
        }
        sort(array);
        for (int x : array) {
            System.out.print(x + " ");
        }
    }
    public static void sort(int[] array) {
        for(int i = 0, n = array.length; i < n; i++) {
            for(int j = i + 1; j < n; j++) {
                if(array[i] < array[j]) {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
