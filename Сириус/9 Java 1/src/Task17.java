package src;

public class Task17 {
    public static void main(String[] args) {
        Person john = new Person("John", 19, 65, 3000);
        System.out.println(john);
    }

    public static class Person {
        private String _name;
        private int _age;
        private int _weight;
        private int _money;

        public Person(String name, int age, int weight, int money){
            _name = name;
            _age = age;
            _weight = weight;
            _money = money;
        }

        @Override
        public String toString() {
            return String.format("%s:\n\tAge: %d\n\tWeight: %d\n\tMoney: %d", _name, _age, _weight, _money);
        }
    }
}
