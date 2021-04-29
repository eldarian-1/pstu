package src;

public class Task4 {


    public static void main(String[] args) {
        Cat boris = new Cat();
        boris.meow();
        boris.setName("Boris");
        boris.meow();
    }

    public static class Cat {

        private String _name = "без имени";

        public void setName(String name) {
            _name = name;
        }

        public void meow() {
            System.out.println(String.format("%s: meow", _name));
        }
    }
}