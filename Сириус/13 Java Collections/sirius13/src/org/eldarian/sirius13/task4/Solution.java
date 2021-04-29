package org.eldarian.sirius13.task4;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static void main(String[] args) {
        Map<String, Object> map = new HashMap<>();
        map.put("Sim", 5);
        map.put("Tom", 5.5);
        map.put("Arbus", false);
        map.put("Baby", null);
        map.put("Cat", "Cat");
        map.put("Eat", Long.valueOf(56));
        map.put("Food", '3');
        map.put("Gevey", '6');
        map.put("Hugs", 111111111111L);
        map.put("Comp", (double) 123);
        map.forEach((key, value) ->
                System.out.println("map[" + key + "] == " + value));
    }
}
