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
        final int[] result = {0};
        map.forEach((ln, fn) -> {
            if(fn.equals(name))
                result[0]++;
        });
        return result[0];
    }
    public static int getCountTheSameLastName(Map<String, String> map, String lastName) {
        final int[] result = {0};
        map.forEach((ln, fn) -> {
            if(ln.equals(lastName))
                result[0]++;
        });
        return result[0];
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
