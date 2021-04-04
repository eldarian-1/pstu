package org.eldarian.sirius12.task24;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        int[] array = initializeArray();
        int max = max(array);
        System.out.println(max);
    }

    public static int[] initializeArray() {
        int[] array = new int[20];
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 20; i++) {
            array[i] = scanner.nextInt();
        }
        return array;
    }

    public static int max(int[] array) {
        int max = array[0];
        for(int i = 1, n = array.length; i < n; i++) {
            max = max < array[i] ? array[i] : max;
        }
        return max;
    }
}
