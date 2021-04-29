package src;

public class Task18 {
    public static void main(String[] args) {
        Man man = new Man();
        Woman woman = new Woman();
        man.age = 25;
        man.height = 80;
        man.wife = woman;
        woman.age = 22;
        woman.height = 60;
        woman.husband = man;
    }

    public static class Man {
        public int age;
        public int height;
        public Woman wife;
    }

    public static class Woman {
        public int age;
        public int height;
        public Man husband;
    }
}
