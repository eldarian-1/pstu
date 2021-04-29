package src;

public class Task6 {
    private static class Friend {
        private String name;
        private int age;
        private char sex;

        public void initialize(String name) {
            this.name = name;
            this.age = 0;
            this.sex = 0;
        }

        public void initialize(String name, int age) {
            this.name = name;
            this.age = age;
            this.sex = 0;
        }

        public void initialize(String name, int age, char sex) {
            this.name = name;
            this.age = age;
            this.sex = sex;
        }

        public String about() {
            return (age == 0 ? name : sex == 0
                ? String.format("%s (age: %d)", name, age)
                : String.format("%s (%c, age: %d)", name, sex, age));
        }
    }

    public static void main(String[] args) {
        Friend friend = new Friend();
        friend.initialize("Jack");
        System.out.println(friend.about());
        friend.initialize("Maria", 20);
        System.out.println(friend.about());
        friend.initialize("Helga", 21, 'f');
        System.out.println(friend.about());
    }
}