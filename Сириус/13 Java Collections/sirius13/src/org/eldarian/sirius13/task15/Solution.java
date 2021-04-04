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
        for (Map.Entry<String, String> pair1 : copy1.entrySet()) {
            Map<String, String> copy2 = new HashMap<>(copy1);
            copy2.remove(pair1.getKey());
            for (Map.Entry<String, String> pair2 : copy2.entrySet()) {
                if(pair2.getValue().equals(pair1.getValue())) {
                    removeItemFromMapByValue(map, pair2.getValue());
                }
            }
        }
    }

    public static void removeItemFromMapByValue(Map<String, String> map, String value) {
        Map<String, String> copy = new HashMap<>(map);
        for (Map.Entry<String, String> pair : copy.entrySet()) {
            if (pair.getValue().equals(value)) {
                map.remove(pair.getKey());
            }
        }
    }

    public static void main(String[] args) throws Exception {
        Map<String, String> persons = createMap();
        removeTheFirstNameDuplicates(persons);
        persons.forEach((ln, fn) -> System.out.println(ln + " " + fn));
    }
}
