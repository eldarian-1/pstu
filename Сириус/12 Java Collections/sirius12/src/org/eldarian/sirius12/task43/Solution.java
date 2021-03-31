package org.eldarian.sirius12.task43;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<Integer> list = new ArrayList<>();
        String[] nums = reader.readLine().split(" ");
        int n = Integer.parseInt(nums[0]);
        int m = Integer.parseInt(nums[1]);
        nums = reader.readLine().split(" ");
        for(int i = 0; i < n; i++) {
            list.add(Integer.parseInt(nums[i]));
        }
        for(int i = 0; i < m; i++) {
            list.add(list.remove(0));
        }
        for(int i = 0; i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
