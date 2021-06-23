package org.eldarian.sirius13.task13;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static BufferedReader reader = new BufferedReader(
            new InputStreamReader(System.in));

    public static Map<String, String> createMap() throws Exception {
        Map<String, String> result = new HashMap<>();
        for(int i = 0; i < 10; i++) {
            String[] person = reader.readLine().split(" ");
            result.put(person[0], person[1]);
        }
        return result;
    }
    public static int getCountTheSameFirstName(Map<String, String> map, String name) {
        int result = 0;
        for(String item : map.values()) {
            if(item.equals(name))
                result++;
        }
        return result;
    }
    public static int getCountTheSameLastName(Map<String, String> map, String lastName) {
        int result = 0;
        for(String item : map.keySet()) {
            if(item.equals(lastName))
                result++;
        }
        return result;
    }
    public static void main(String[] args) throws Exception {
        Map<String, String> persons = createMap();
        String[] person = reader.readLine().split(" ");
        System.out.println("Совпадающих имен: "
                + getCountTheSameFirstName(persons, person[1])
                + "\nСовпадающих фамилий: "
                + getCountTheSameLastName(persons, person[0]));
    }
}
