package org.eldarian.sirius13.task23;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static void main(String[] args) throws IOException {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        Map<String, String> map = new HashMap<>();
        while (true) {
            String about = reader.readLine();
            if (about.isEmpty()) {
                break;
            }
            String[] abouts = about.split(" ");
            map.put(abouts[0], abouts[1]);
        }
        String city = reader.readLine();
        System.out.println(map.containsKey(city) ? map.get(city) : "Никто");
    }
}
