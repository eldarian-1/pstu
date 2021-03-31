package org.eldarian.sirius12.task42;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        String[] nums = reader.readLine().split(" ");
        ArrayList<Integer> list = new ArrayList<>();
        for(int i = 0; i < 10; i++) {
            list.add(Integer.parseInt(nums[i]));
        }
        for(int i = list.size() - 1; i >= 0; i--) {
            System.out.println(list.get(i));
        }
    }
}
