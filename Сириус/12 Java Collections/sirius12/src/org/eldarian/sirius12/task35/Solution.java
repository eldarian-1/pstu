package org.eldarian.sirius12.task35;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> list = new ArrayList<>();
        for(int i = 0; i < 5; i++) {
            list.add(0, reader.readLine());
        }
        for(int i = 0; i < 13; i++) {
            list.add(list.remove(0));
        }
        for(int i = 0, n = list.size(); i < n; i++) {
            System.out.println(list.get(i));
        }
    }
}
