package org.eldarian.task16;

import java.util.LinkedList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        List<Number> list = new LinkedList<>();
        initList(list);
        printListValues(list);
        processCastedObjects(list);
    }
    public static void initList(List<Number> list) {
        list.add(Double.valueOf(1000f));
        list.add(Double.valueOf("123e-445632"));
        list.add(Float.valueOf(-90 / -3));
        list.remove(Double.valueOf("123e-445632"));
    }
    public static void printListValues(List<Number> list) {
        list.forEach(System.out::println);
    }
    public static void processCastedObjects(List<Number> list) {
        for (Number object : list) {
            if (object instanceof Float a) {
                System.out.println("Is float value defined? " + !(a.isNaN()));
            } else if (object instanceof Double a) {
                System.out.println("Is double value infinite? " + a.isInfinite());
            }
        }
    }
}
