package org.eldarian.sirius13.task5;

import java.util.HashSet;
import java.util.Set;

public class Solution {
    public static void main(String[] args) {
        Set<String> set = new HashSet<>();
        String[] array = new String[] {"арбуз", "банан", "вишня", "груша",
            "дыня", "ежевика", "женьшень", "земляника", "ирис", "картофель"};
        for (String item : array) {
            set.add(item);
        }
        set.forEach(System.out::println);
    }
}
