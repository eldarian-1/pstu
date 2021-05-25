package org.eldarian.task15;

public class Hryvnia extends Money {
    public Hryvnia(double amount) {
        super(amount);
    }

    @Override
    public String getCurrencyName() {
        return "UAH";
    }
}
