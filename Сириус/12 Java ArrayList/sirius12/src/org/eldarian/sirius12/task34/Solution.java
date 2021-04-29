package org.eldarian.sirius12.task34;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 10; i++) {
            list.add(0, reader.readLine());
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
