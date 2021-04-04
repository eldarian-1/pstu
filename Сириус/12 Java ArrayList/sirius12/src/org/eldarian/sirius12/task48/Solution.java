package org.eldarian.sirius12.task48;

import java.io.BufferedReader;
import java.io.InputStreamReader;
import java.util.ArrayList;

public class Solution {
    public final static ArrayList<Cat> CATS = new ArrayList<>();
    public static void main(String[] args) throws Throwable {
        BufferedReader reader = new BufferedReader(
                new InputStreamReader(System.in));
        while (true) {
            String name = reader.readLine();
            String[] nums = reader.readLine().split(" ");
            if (name == null || name.isEmpty()) {
                break;
            }
            int age = Integer.parseInt(nums[0]);
            int weight = Integer.parseInt(nums[1]);
            int tailLength = Integer.parseInt(nums[2]);
            Cat cat = new Cat(name, age, weight, tailLength);
            CATS.add(cat);
        }
        printList();
    }
    public static void printList() {
        for (int i = 0; i < CATS.size(); i++) {
            System.out.println(CATS.get(i));
        }
    }
    public static class Cat {
        private String name;
        private int age;
        private int weight;
        private int tailLength;
        Cat(String name, int age, int weight, int tailLength) {
            this.name = name;
            this.age = age;
            this.weight = weight;
            this.tailLength = tailLength;
        }
        @Override
        public String toString() {
            return "Cat's name: " + name + ", age: " + age
                    + ", weight: " + weight + ", tail: " + tailLength;
        }
    }
}
