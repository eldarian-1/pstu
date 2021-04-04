package org.eldarian.sirius12.task9;

public class Solution {
    public static class Cat {
        @Override
        protected void finalize() throws Throwable {
            super.finalize();
            System.out.println("Кот уничтожен");
        }
    }
    public static class Dog {
        @Override
        protected void finalize() throws Throwable {
            super.finalize();
            System.out.println("Пёс уничтожен");
        }
    }
    public static void main(String[] args) {
        Cat cat = new Cat();
        Dog dog = new Dog();
        cat = null;
        dog = null;
    }
}
