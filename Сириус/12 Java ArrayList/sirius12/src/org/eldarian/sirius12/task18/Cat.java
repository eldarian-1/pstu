package org.eldarian.sirius12.task18;

import java.util.ArrayList;

public class Cat {
    private static int catCount;
    private static ArrayList<Cat> cats = new ArrayList<>();

    private int catIndex;

    public Cat() {
        catIndex = ++catCount;
        cats.add(this);
    }

    @Override
    public String toString() {
        return "Cat[" + catIndex + "]";
    }

    public static void printCats() {
        for(int i = 0, n = cats.size(); i < n; i++) {
            System.out.println(cats.get(i));
        }
    }

    public static void main(String[] args) {
        for(int i = 0; i < 10; i++) {
            new Cat();
        }
        printCats();
    }
}
