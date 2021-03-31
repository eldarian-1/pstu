package org.eldarian.sirius12.task29;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[15];
        int odd = 0, even = 0;
        for(int i = 0; i < 15; i++) {
            array[i] = Integer.parseInt(nums[i]);
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
