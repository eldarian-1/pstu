package org.eldarian.task12;

public class Solution {
    public static void main(String[] args) {
        Animal cow = new Cow();
        System.out.println(cow.getName());
    }
    public static abstract class Animal {
        public abstract String getName();
    }
    public static class Cow extends Animal {
        @Override
        public String getName() {
            return "Корова";
        }
    }
}
