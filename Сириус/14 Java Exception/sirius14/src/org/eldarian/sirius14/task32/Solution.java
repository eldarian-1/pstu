package org.eldarian.sirius14.task32;

public class Solution {
    public static void main(String[] args) {
        if(args.length < 2)
            return;
        int sum = Integer.parseInt(args[0]);
        int dif = Integer.parseInt(args[1]);
        for(int i = 2, n = args.length; i < n; i++) {
            if(i % 2 == 0) {
                sum += Integer.parseInt(args[i]);
            }
            else {
                dif -= Integer.parseInt(args[i]);
            }
        }
        System.out.println(sum);
        System.out.println(dif);
    }
}
