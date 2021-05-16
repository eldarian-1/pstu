package org.eldarian.task1;

public class Solution {
    public static void main(String[] args) throws Exception {
        print(new Fanta());
        print(new Cola());
    }

    private static void print(Drink drink) {
        System.out.println(drink.getClass().getSimpleName());
    }

    public interface Drink {
        boolean isOrange();
    }

    public static class Fanta implements Drink {
        @Override
        public boolean isOrange() {
            return true;
        }
    }

    public static class Cola implements Drink {
        @Override
        public boolean isOrange() {
            return false;
        }
    }
}
