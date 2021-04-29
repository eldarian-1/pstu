package src;

public class Task10 {

    public static void main(String[] args) {
        Cat cat1 = new Cat();
        Cat cat2 = new Cat();
        Cat cat3 = new Cat();
        Cat cat4 = new Cat();
        Cat cat5 = new Cat();
        Cat cat6 = new Cat();
        Cat cat7 = new Cat();
        Cat cat8 = new Cat();
        Cat cat9 = cat8;
        Cat cat10 = null;
        
        System.out.println(cat1.name());
        System.out.println(cat2.name());
        System.out.println(cat3.name());
        System.out.println(cat4.name());
        System.out.println(cat5.name());
        System.out.println(cat6.name());
        System.out.println(cat7.name());
        System.out.println(cat8.name());
        System.out.println(cat9.name());
        //System.out.println(cat10.name());
        //переменная не хранит ссылку на объет => ошибка
    }

    public static class Cat {
        private static int _i = 1;

        private String _name;

        public Cat() {
            _name = "cat" + _i++;
        }

        public String name() {
            return _name;
        }
    }
}