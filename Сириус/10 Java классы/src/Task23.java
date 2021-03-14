package src;

public class Task23 {

    public static void main(String[] args) {
        System.out.println(Cat.getCount());
        Cat cat1 = new Cat();
        Cat cat2 = new Cat();
        Cat cat3 = new Cat();
        System.out.println(Cat.getCount());
    }

    public static class Cat {
        private static int count = 0;

        public Cat() {
            ++count;
        }

        public static int getCount() {
            return count;
        }
    }
}