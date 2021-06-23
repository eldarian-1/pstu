package src;

public class Task1 {


    public static void main(String[] args) {
        Cat boris = new Cat("Boris");
        Cat vasya = new Cat("Vasya");
        boris.meow();
        vasya.meow();
    }

    public static class Cat {
        private String _name;

        public Cat(String name) {
            name = _name;
        }

        public void meow() {
            System.out.println(String.format("%s: meow", _name));
        }
    }
}