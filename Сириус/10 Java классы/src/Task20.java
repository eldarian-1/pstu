package src;

public class Task20 {

    public static void main(String[] args) {
        System.out.println(Cat.count());
        Cat.addNewCat();
        Cat.addNewCat();
        Cat.addNewCat();
        System.out.println(Cat.count());
    }

    public static class Cat {

        private static int catsCount = 0;

        public static int count() {
            return catsCount;
        }
        
        public static void addNewCat() {
            ++catsCount;
        }
    }
}