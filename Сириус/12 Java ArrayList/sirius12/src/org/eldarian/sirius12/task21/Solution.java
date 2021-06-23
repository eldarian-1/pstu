package org.eldarian.sirius12.task21;

public class Solution {
    private static String name;

    public static class Cat {
        private static String name;
    }

    public static class Dog {
        private static String name;
    }

    public static void main(String[] args) {
        name = "4 практика - 13 задание";
        Cat.name = "Васька";
        Dog.name = "Пират";
        System.out.println(name);
        System.out.println(Cat.name);
        System.out.println(Dog.name);
    }
}
