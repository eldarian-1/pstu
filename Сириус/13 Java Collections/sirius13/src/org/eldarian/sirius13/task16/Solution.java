package org.eldarian.sirius13.task16;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static Map<String, Integer> createMap() {
        Map<String, Integer> result = new HashMap<>();
        result.put("Попов", 500);
        result.put("Зайцев", 400);
        result.put("Антонов", 3000);
        result.put("Платонов", 300);
        result.put("Аристархов", 550);
        result.put("Геродотов", 900);
        result.put("Котов", 200);
        result.put("Потов", 15000);
        result.put("Генов", 215);
        result.put("Панин", 215000);
        return result;
    }

    public static void removeItemFromMap(Map<String, Integer> map) {
        Map<String, Integer> copy = new HashMap<>(map);
        copy.forEach((name, num) -> {
            if(num < 500) {
                map.remove(name);
            }
        });
    }

    public static void main(String[] args) {
        Map<String, Integer> persons = createMap();
        removeItemFromMap(persons);
        persons.forEach((ln, num) -> System.out.println(ln + " " + num));
    }
}
