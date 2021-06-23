package org.eldarian.sirius12.task28;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[20];
        int[] array1 = new int[10];
        int[] array2 = new int[10];
        for(int i = 0; i < 20; i++) {
            array[i] = Integer.parseInt(nums[i]);
        }
        for(int i = 0; i < 10; i++) {
            array1[i] = array[i];
            array2[i] = array[i + 10];
            System.out.println(array[i]);
        }
    }
}
