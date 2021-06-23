package org.eldarian.sirius12.task31;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> list = new ArrayList<>();
        ArrayList<String> maxList = new ArrayList<>();
        int max = 0;
        for(int i = 0; i < 5; i++) {
            list.add(reader.readLine());
            max = Math.max(max, list.get(i).length());
        }
        for(int i = 0; i < 5; i++) {
            if(list.get(i).length() == max) {
                maxList.add(list.get(i));
            }
        }
        for(int i = 0, n = maxList.size(); i < n; i++) {
                System.out.println(maxList.get(i));
        }
    }
}
