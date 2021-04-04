package org.eldarian.sirius12.task1;

public class Cat {

    public Cat() {
        System.out.println("Объект создан");
    }

    protected void finalize() throws Throwable {
        System.out.println("Объект удален");
    }

    public static void main(String[] args) {
	    Cat cat;
        System.out.println("Ссылка создана");
	    cat = new Cat();
	    cat = null;
    }
}
