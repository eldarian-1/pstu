package org.eldarian.sirius12.task11;

import java.util.ArrayList;

public class Solution {
    public static class Cat {
        private static int catCount = 0;
        public Cat() {catCount++;}
        @Override
        protected void finalize() throws Throwable {
            super.finalize();
            System.out.println("Кот[" + catCount + "] уничтожен");
        }
    }
    public static class Dog {
        private static int dogCount = 0;
        public Dog() {dogCount++;}
        @Override
        protected void finalize() throws Throwable {
            super.finalize();
            System.out.println("Пёс[" + dogCount + "] уничтожен");
        }
    }
    public static void main(String[] args) {
        for(int i = 0; i < 5000000; i++) {
            new Cat();
            new Dog();
        }
    }
}
