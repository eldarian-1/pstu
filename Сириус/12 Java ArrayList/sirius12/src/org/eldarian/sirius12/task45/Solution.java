package org.eldarian.sirius12.task45;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        ArrayList<String> list = new ArrayList<>();
        while(true) {
            String temp = reader.readLine();
            if(temp.equals("end")) {
                break;
            }
            list.add(temp);
        }
        for(String item : list) {
            System.out.println(item);
        }
    }
}
