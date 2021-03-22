package src;

public class Task45 {
    public static class Dog {
        String name;
        int height;
        int tail;
        public Dog(String name, int height, int tail) {
            this.name = name;
            this.height = height;
            this.tail = tail;
        }
        public String toString() {
            return String.format("%s (height: %d; tail: %d)",
                name, height, tail);
        }
    }
    public static class Cat {
        String name;
        int height;
        int tail;
        public Cat(String name, int height, int tail) {
            this.name = name;
            this.height = height;
            this.tail = tail;
        }
        public String toString() {
            return String.format("%s (height: %d; tail: %d)",
                name, height, tail);
        }
    }
    public static class Mouse {
        String name;
        int height;
        int tail;
        public Mouse(String name, int height, int tail) {
            this.name = name;
            this.height = height;
            this.tail = tail;
        }
        public String toString() {
            return String.format("%s (height: %d; tail: %d)",
                name, height, tail);
        }
    }

    public static void main(String[] args) {
        System.out.println(new Mouse("Jerry", 12, 5));
        System.out.println(new Mouse("Tuffy", 10, 4));
        System.out.println(new Cat("Tom", 120, 50));
        System.out.println(new Cat("Butch", 110, 40));
        System.out.println(new Cat("Pugovka", 105, 42));
        System.out.println(new Dog("Spike", 180, 30));
        System.out.println(new Dog("Tike", 80, 23));
    }
}