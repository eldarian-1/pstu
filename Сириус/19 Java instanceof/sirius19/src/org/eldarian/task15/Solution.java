package org.eldarian.task15;

import java.util.ArrayList;
import java.util.List;

public class Solution {
    public static void main(String[] args) {
        Person ivan = new Person("Иван");
        for (Money money : ivan.getAllMoney()) {
            System.out.println(ivan.name + " имеет заначку в размере "
                    + money.getAmount() + " " + money.getCurrencyName());
        }
    }
    static class Person {
        public String name;
        Person(String name) {
            this.name = name;
            this.allMoney = new ArrayList<>();
            this.allMoney.add(new Hryvnia(13));
            this.allMoney.add(new Ruble(97));
            this.allMoney.add(new USD(6));
        }
        private List<Money> allMoney;
        public List<Money> getAllMoney() {
            return allMoney;
        }
    }
}
