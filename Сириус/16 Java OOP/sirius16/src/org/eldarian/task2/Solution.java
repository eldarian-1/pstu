package org.eldarian.task2;

public class Solution {
    public static void main(String[] args) {
        System.out.println(new Cat());
        System.out.println(new Dog());
    }
    public static class Pet {
        @Override
        public String toString() {
            return "Pet";
        }
    }
    public static class Cat extends Pet {
        @Override
        public String toString() {
            return "Cat is " + super.toString();
        }
    }
    public static class Dog extends Pet {
        @Override
        public String toString() {
            return "Dog is " + super.toString();
        }
    }
}
