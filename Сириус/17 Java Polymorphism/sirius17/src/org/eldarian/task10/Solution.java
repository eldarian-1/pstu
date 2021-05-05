package org.eldarian.task10;

import static org.eldarian.task1.Solution.Cow;
import static org.eldarian.task1.Solution.Whale;

public class Solution {
    public static void main(String[] args) {
        print(13);
        print(0.6);
        print("Sirius");
        print(new Cow());
        print(new Whale());
    }
    public static void print(int num) {
        System.out.println(num);
    }
    public static void print(double num) {
        System.out.println(num);
    }
    public static void print(String text) {
        System.out.println(text);
    }
    public static void print(Cow cow) {
        System.out.println(cow.getName());
    }
    public static void print(Whale whale) {
        System.out.println(whale.getName());
    }
}
