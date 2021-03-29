package org.eldarian.sirius12.task29;

import java.util.Scanner;

public class Solution {
    public static void main(String[] args) {
        int[] array = new int[15];
        int odd = 0, even = 0;
        Scanner scanner = new Scanner(System.in);
        for(int i = 0; i < 15; i++) {
            array[i] = scanner.nextInt();
            if(array[i] % 2 == 0) {
                even += array[i];
            }
            else {
                odd += array[i];
            }
        }
        System.out.println(odd < even ?
                "В домах с четными номерами проживает больше жителей." :
                odd > even ?
                        "В домах с нечетными номерами проживает больше жителей." :
                        "В домах с четными номерами и с нечетными номерами" +
                                "проживает равное количество жителей.");
    }
}
