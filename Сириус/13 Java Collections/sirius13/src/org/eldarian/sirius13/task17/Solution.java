package org.eldarian.sirius13.task17;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static Map<String, String> createPeopleMap() {
        Map<String, String> result = new HashMap<>();
        result.put("Попов", "Иван");
        result.put("Зайцев", "Павел");
        result.put("Антонов", "Иван");
        result.put("Платонов", "Марк");
        result.put("Аристархов", "Иван");
        result.put("Попов", "Всеволод");
        result.put("Котов", "Всеволод");
        result.put("Попов", "Дмитрий");
        result.put("Генов", "Артур");
        result.put("Панин", "Алексей");
        return result;
    }

    public static void printPeopleMap(Map<String, String> map) {
        map.forEach((ln, fn) -> System.out.println(ln + " " + fn));
    }

    public static void main(String[] args) {
        Map<String, String> map = createPeopleMap();
        printPeopleMap(map);
    }
}
