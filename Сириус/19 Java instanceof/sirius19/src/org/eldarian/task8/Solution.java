package org.eldarian.task8;

public class Solution {
    public static void main(String[] args) {
        getDeliciousDrink().taste();
        System.out.println(getWine().getHolidayName());
        System.out.println(getSparklingWine().getHolidayName());
        System.out.println(getWine().getHolidayName());
    }
    public static Drink getDeliciousDrink() {
        return getWine();
    }
    public static Wine getWine() {
        return new Wine();
    }
    public static Wine getSparklingWine() {
        return new SparklingWine();
    }
    public static abstract class Drink {
        public void taste() {
            System.out.println("Вкусно");
        }
    }
    public static class Wine extends Drink {
        public String getHolidayName() {
            return "День Рождения";
        }
    }
    public static class SparklingWine extends Wine {
        @Override
        public String getHolidayName() {
            return "Новый Год";
        }
    }
}
