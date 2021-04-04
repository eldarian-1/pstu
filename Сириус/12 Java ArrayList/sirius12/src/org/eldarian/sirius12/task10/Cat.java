package org.eldarian.sirius12.task10;

public class Cat {
    private static int catCount = 0;

    public Cat() {
        catCount++;
    }

    @Override
    protected void finalize() throws Throwable {
        super.finalize();
        catCount--;
    }

    public static int getCatCount() {
        return catCount;
    }

    public static void setCatCount(int catCount) {
        Cat.catCount = catCount;
    }

    public static void main(String[] args) {
        System.out.println(getCatCount());
        Cat cat = new Cat();
        System.out.println(getCatCount());
        cat = null;
        System.out.println(getCatCount());
    }
}
