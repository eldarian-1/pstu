package org.eldarian.task19;

public class Solution {
    public static void main(String[] args) {
        System.out.println(HenFactory.getHen(Country.RUSSIA).getDescription());
        System.out.println(HenFactory.getHen(Country.UKRAINE).getDescription());
        System.out.println(HenFactory.getHen(Country.BELARUS).getDescription());
        System.out.println(HenFactory.getHen(Country.MOLDOVA).getDescription());
    }
    public interface Country {
        String RUSSIA = "Россия";
        String UKRAINE = "Украина";
        String BELARUS = "Беларусь";
        String MOLDOVA = "Молдова";
    }
    static class HenFactory {
        static Hen getHen(String country) {
            if(country.equals(Country.RUSSIA)) {
                return new RussianHen();
            } else if(country.equals(Country.UKRAINE)) {
                return new UkrainianHen();
            } else if(country.equals(Country.BELARUS)) {
                return new BelarusianHen();
            } else if(country.equals(Country.MOLDOVA)) {
                return new MoldovanHen();
            } else {
                return null;
            }
        }
    }
    static abstract class Hen {
        public abstract int getCountOfEggsPerMonth();
        public abstract String getCountryName();
        public final String getDescription() {
            return "Я - курица. Моя страна - " + getCountryName()
                    + ". Я несу " + getCountOfEggsPerMonth() + " яиц в месяц.";
        }
    }
    static class RussianHen extends Hen {
        @Override
        public int getCountOfEggsPerMonth() {
            return 29;
        }
        @Override
        public String getCountryName() {
            return Country.RUSSIA;
        }
    }
    static class UkrainianHen extends Hen {
        @Override
        public int getCountOfEggsPerMonth() {
            return 31;
        }
        @Override
        public String getCountryName() {
            return Country.UKRAINE;
        }
    }
    static class BelarusianHen extends Hen {
        @Override
        public int getCountOfEggsPerMonth() {
            return 27;
        }
        @Override
        public String getCountryName() {
            return Country.BELARUS;
        }
    }
    static class MoldovanHen extends Hen {
        @Override
        public int getCountOfEggsPerMonth() {
            return 25;
        }
        @Override
        public String getCountryName() {
            return Country.MOLDOVA;
        }
    }
}
