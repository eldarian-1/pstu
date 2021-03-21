package src;

public class Task6 {
    private static class Friend {
        private String about = null;

        public void initialize(String name) {
            about = name;
        }

        public void initialize(String name, int age) {
            about = String.format("%s (age: %d)", name, age);
        }

        public void initialize(String name, int age, char sex) {
            about = String.format("%s (%c, age: %d)", name, sex, age);
        }

        public String about() {
            return about;
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