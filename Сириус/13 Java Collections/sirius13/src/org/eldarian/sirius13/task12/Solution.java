package org.eldarian.sirius13.task12;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.LinkedList;
import java.util.List;

public class Solution {
    public static int maxNumberOfRepetitive(List<Integer> list) {
        int temp = 0, number = 0, max = 0;
        for(int item : list) {
            if(temp == item) {
                number++;
                max = Math.max(max, number);
            }
            else {
                temp = item;
                number = 1;
            }
        }
        return max;
    }

    public static void main(String[] args) throws Exception {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        List<Integer> list = new LinkedList<>();
        String[] nums = reader.readLine().split(" ");
        for(String item : nums) {
            list.add(Integer.parseInt(item));
        }
        System.out.println(maxNumberOfRepetitive(list));
    }
}
