package org.eldarian.sirius14.task29;

import java.util.HashMap;
import java.util.HashSet;
import java.util.Map;
import java.util.Set;

public class Solution {
    public static void main(String[] args) {
        Map<String, Cat> map = createMap();
        Set<Cat> set = convertMapToSet(map);
        printCatSet(set);
    }
    public static Map<String, Cat> createMap() {
        Map<String, Cat> map = new HashMap<>();
        fillMap(map, "Tom", "Vasya", "Boris", "Murka", "Chicha",
                "Maya", "Sima", "Richi", "Lola", "Seriy");
        return map;
    }
    public static void fillMap(Map<String, Cat> map, String... names) {
        for(String name : names) {
            map.put(name, new Cat(name));
        }
    }
    public static Set<Cat> convertMapToSet(Map<String, Cat> map) {
        Set<Cat> set = new HashSet<>();
        for(String key : map.keySet()) {
            set.add(map.get(key));
        }
        return set;
    }
    public static void printCatSet(Set<Cat> set) {
        for (Cat cat : set) {
            System.out.println(cat);
        }
    }
    public static class Cat {
        private String name;

        public Cat(String name) {
            this.name = name;
        }
        public String toString() {
            return "Cat " + this.name;
        }
    }
}
