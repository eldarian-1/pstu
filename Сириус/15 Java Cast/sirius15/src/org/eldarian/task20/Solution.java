package org.eldarian.task20;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        Map<Integer, String> map = new HashMap<>();
        while(true) {
            String num = reader.readLine();
            if(num.equals(""))
                break;
            int id = Integer.parseInt(num);
            String name = reader.readLine();
            map.put(id, name);
        }
        map.forEach((id, name) -> {
            System.out.println("Id=" + id + " Name=" + name);
        });
    }
}
