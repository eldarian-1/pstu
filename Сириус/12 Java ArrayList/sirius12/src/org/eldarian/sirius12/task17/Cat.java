package org.eldarian.sirius12.task17;

public class Cat {
    private static int catCount = 0;

    public Cat() {
        catCount++;
    }

    public static void main(String[] args) {
        for(int i = 0; i < 10; i++) {
            new Cat();
        }
        System.out.println(catCount);
    }
}
