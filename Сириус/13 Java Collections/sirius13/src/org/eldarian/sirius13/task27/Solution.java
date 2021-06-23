package org.eldarian.sirius13.task27;

import java.util.HashSet;
import java.util.Set;

public class Solution {
    public static void main(String[] args) {
        Set<Cat> cats = createCats();
        cats.remove(cats.toArray()[0]);
        printCats(cats);
    }

    public static Set<Cat> createCats() {
        Set<Cat> cats = new HashSet<>();
        cats.add(new Cat("Vasya"));
        cats.add(new Cat("Seriy"));
        cats.add(new Cat("Boris"));
        return cats;
    }

    public static void printCats(Set<Cat> cats) {
        for(Cat cat : cats) {
            System.out.println(cat);
        }
    }

    public static class Cat {
        private String name;
        public Cat(String name) {
            this.name = name;
        }
        public String toString() {
            return name;
        }
    }
}
