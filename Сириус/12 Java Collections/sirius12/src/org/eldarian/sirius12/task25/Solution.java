package org.eldarian.sirius12.task25;

import java.util.Scanner;

public class Solution {

    public static void main(String[] args) {
        String[] array = new String[10];
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 8; i++) {
            array[i] = scanner.nextLine();
        }
        for(int i = 9; i >= 0; i--) {
            System.out.println(array[i] == null ? "" : array[i]);
        }
    }
}
