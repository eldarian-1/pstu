package org.eldarian.sirius13.task19;

import java.io.BufferedReader;
import java.io.InputStreamReader;

public class Solution {
    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        int[] array = new int[nums.length];
        for (int i = 0; i < array.length; i++) {
            array[i] = Integer.parseInt(nums[i]);
        }
        sort(array);
        for (int i = 0; i < 5; i++) {
            System.out.println(array[i]);
        }
    }
    public static void sort(int[] array) {
        for(int i = 0; i < array.length; i++) {
            for(int j = i + 1; j < array.length; j++) {
                if(array[i] < array[j]) {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
        }
    }
}
