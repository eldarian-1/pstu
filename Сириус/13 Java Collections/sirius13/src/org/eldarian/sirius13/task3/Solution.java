package org.eldarian.sirius13.task3;

import java.util.HashMap;
import java.util.Map;

public class Solution {
    public static void main(String[] args) throws Exception {
        String[] cats = new String[]{"васька", "мурка", "дымка",
                "рыжик", "серый", "снежок", "босс", "борис",
                "визя", "гарфи"};
        Map<String, Cat> map = addCatsToMap(cats);
        for (Map.Entry<String, Cat> pair : map.entrySet()) {
            System.out.println(pair.getKey() + " - "
                    + pair.getValue());
        }
    }
    public static Map<String, Cat> addCatsToMap(String[] cats) {
        Map<String, Cat> result = new HashMap<>();
        for(String item : cats) {
            result.put(item, new Cat(item));
        }
        return result;
    }
    public static class Cat {
        String name;
        public Cat(String name) {
            this.name = name;
        }
        @Override
        public String toString() {
            return name != null ? name.toUpperCase() : null;
        }
    }
}
