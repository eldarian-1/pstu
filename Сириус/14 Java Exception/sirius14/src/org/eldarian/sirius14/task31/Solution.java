package org.eldarian.sirius14.task31;

import static java.lang.Math.min;

public class Solution {
    public static void main(String[] args) {
        if(args.length == 0)
            return;
        int min = Integer.parseInt(args[0]);
        for(String arg : args) {
            min = min(min, Integer.parseInt(arg));
        }
        System.out.println(min);
    }
}
