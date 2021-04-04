package org.eldarian.sirius13.task5;

import java.util.Arrays;
import java.util.HashSet;
import java.util.Set;

public class Solution {
    public static Set<String> createSet(String... array) {
        return new HashSet<>(Arrays.asList(array));
    }

    public static void main(String[] args) {
        Set<String> set = createSet("арбуз", "банан", "вишня",
                "груша", "дыня", "ежевика", "женьшень", "земляника",
                "ирис", "картофель");
        set.forEach(System.out::println);
    }
}
