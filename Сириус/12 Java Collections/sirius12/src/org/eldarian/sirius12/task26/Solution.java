package org.eldarian.sirius12.task26;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        String[] stringArray = new String[10];
        int[] intArray = new int[10];
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 10; i++) {
            stringArray[i] = scanner.nextLine();
            intArray[i] = stringArray[i].length();
        }
        for(int i = 0; i < 10; i++) {
            System.out.println(intArray[i]);
        }
    }
}
