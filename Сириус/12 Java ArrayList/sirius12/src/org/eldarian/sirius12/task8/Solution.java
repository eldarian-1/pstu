package org.eldarian.sirius12.task8;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        ArrayList<Integer> list = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            list.add(Integer.parseInt(nums[i]));
        }
        list.sort((a, b)-> (a > b ? 1 : a < b ? -1 : 0));
        for(int i = 0; i < 5; i++) {
            System.out.print(list.get(i) + " ");
        }
    }
}
