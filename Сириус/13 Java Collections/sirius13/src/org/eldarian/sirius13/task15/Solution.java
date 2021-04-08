package org.eldarian.sirius13.task15;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static Map<String, String> createMap() {
        Map<String, String> result = new HashMap<>();
        result.put("Попов", "Иван");
        result.put("Зайцев", "Павел");
        result.put("Антонов", "Иван");
        result.put("Платонов", "Марк");
        result.put("Аристархов", "Иван");
        result.put("Геродотов", "Всеволод");
        result.put("Котов", "Всеволод");
        result.put("Потов", "Дмитрий");
        result.put("Генов", "Артур");
        result.put("Панин", "Алексей");
        return result;
    }

    public static void removeTheFirstNameDuplicates(Map<String, String> map) {
        Map<String, String> copy1 = new HashMap<>(map);
        copy1.forEach((key1, value1) -> {
            Map<String, String> copy2 = new HashMap<>(copy1);
            copy2.remove(key1);
            copy2.forEach((key2, value2) -> {
                if(value2.equals(value1)) {
                    removeItemFromMapByValue(map, value2);
                }
            });
        });
    }

    public static void removeItemFromMapByValue(Map<String, String> map, String desiredValue) {
        Map<String, String> copy = new HashMap<>(map);
        copy.forEach((key, value) -> {
            if (value.equals(desiredValue)) {
                map.remove(value);
            }
        });
    }

    public static void main(String[] args) throws Exception {
        Map<String, String> persons = createMap();
        removeTheFirstNameDuplicates(persons);
        persons.forEach((ln, fn) -> System.out.println(ln + " " + fn));
    }
}
