package org.eldarian.task13;

public class Solution {
    public static void main(String[] args) {
        Pet pet1 = new Cat();
        Pet cat = pet1.getChild();
        Pet pet2 = new Dog();
        System.out.println(pet1.getName());
        System.out.println(cat.getName());
        System.out.println(pet2.getName());
    }
    public static abstract class Pet {
        public abstract String getName();
        public abstract Pet getChild();
    }
    public static class Cat extends Pet {
        @Override
        public String getName() {
            return "Кошка";
        }
        @Override
        public Pet getChild() {
            return new Cat();
        }
    }
    public static class Dog extends Pet {
        @Override
        public String getName() {
            return "Собака";
        }
        @Override
        public Pet getChild() {
            return new Dog();
        }
    }
}
