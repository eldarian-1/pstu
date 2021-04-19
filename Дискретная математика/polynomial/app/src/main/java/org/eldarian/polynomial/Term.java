package org.eldarian.polynomial;

import java.util.HashMap;
import java.util.Map;

public class Term {
    private Double coefficient;
    private Map<Character, Double> args;

    public Term() {
        coefficient = 1d;
        args = new HashMap<>();
    }

    public Term(Double coefficient, Map<Character, Double> args) throws Throwable {
        if(coefficient == 0d)
            throw new Exception("Коэффициент не может быть равен нулю");
        this.coefficient = coefficient;
        this.args = args;
    }

    public Term(Term from) throws Throwable {
        this(from.coefficient, from.args);
    }

    public boolean isPositive() {
        return coefficient > 0d;
    }

    public Double getCoefficient() {
        return coefficient;
    }

    public void setCoefficient(Double coefficient) throws Throwable {
        if(coefficient == 0d)
            throw new Exception("Коэффициент не может быть равен нулю");
        this.coefficient = coefficient;
    }

    public Map<Character, Double> getArgs() {
        return args;
    }

    public void setArgs(Map<Character, Double> args) {
        this.args = args;
    }

    public String absString() {
        double c = Math.abs(coefficient);
        String result = c == 1d ? "" :
                (c % 1d == 0d ? Integer.valueOf((int) c).toString() : Double.valueOf(c).toString());
        for(Map.Entry<Character, Double> item : args.entrySet()) {
            double d = item.getValue();
            result += (c == 0d || d == 0d ? "" : item.getKey() + (d == 1d ? "" : "^" +
                    (d % 1d == 0d ? Integer.valueOf((int) d).toString() : Double.valueOf(d)
                            .toString())));
        }
        return result;
    }

    @Override
    public String toString() {
        return (isPositive() ? "" : "-") + absString();
    }
}
