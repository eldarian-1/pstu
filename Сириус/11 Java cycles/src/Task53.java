package src;

public class Task53 {
    public static class Man {
        private String name;
        private int age;
        private String address;

        public Man(String name, int age, String address) {
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public String toString() {
            return name + " " + age + " " + address;
        }
    }
    public static class Woman {
        private String name;
        private int age;
        private String address;

        public Woman(String name, int age, String address) {
            this.name = name;
            this.age = age;
            this.address = address;
        }

        public String toString() {
            return name + " " + age + " " + address;
        }
    }

    public static void main(String[] args) {
        Man man = new Man("Gerald", 84, "Riviah");
        Woman woman = new Woman("Cirilla", 17, "Nilfgaard");
        System.out.println(man);
        System.out.println(woman);
    }
}