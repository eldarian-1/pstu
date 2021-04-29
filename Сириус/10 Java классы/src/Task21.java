package src;

public class Task21 {

    public static void main(String[] args) {
        System.out.println(Cat.getCatsCount());
        Cat.setCatsCount(5);
        System.out.println(Cat.getCatsCount());
    }

    public static class Cat {
        private static int catsCount = 0;

        public static int getCatsCount() {
            return catsCount;
        }

        public static void setCatsCount(int catsCount) {
            Cat.catsCount = catsCount;
        }
    }
}