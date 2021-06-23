package org.eldarian.polynomial;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class Transposition {
    private Double coefficient;
    private Map<Character, Double> terms;

    private Transposition(Transposition multiply) {
        this.coefficient = multiply.coefficient;
        this.terms = new HashMap<>(multiply.terms);
    }

    public Transposition(List<Term> terms) {
        coefficient = 1d;
        this.terms = new HashMap<>();
        for(Term term : terms) {
            coefficient *= term.getCoefficient();
            for(Map.Entry<Character, Double> arg : term.getArgs().entrySet()) {
                Character name = arg.getKey();
                Double degree = arg.getValue();
                if(this.terms.get(name) == null) {
                    this.terms.put(name, degree);
                } else {
                    this.terms.put(name, this.terms.get(name) + degree);
                }
            }
        }
    }

    public Transposition add(Transposition term) {
        Transposition result = new Transposition(this);
        result.coefficient += term.coefficient;
        return result;
    }

    public boolean isPositive() {
        return coefficient > 0d;
    }

    public boolean likes(Transposition multiply) {
        for(Map.Entry<Character, Double> term : terms.entrySet()) {
            if((multiply.terms.get(term.getKey()) == null && term.getValue() != 0) ||
                    (multiply.terms.get(term.getKey()) != null &&
                            !multiply.terms.get(term.getKey()).equals(term.getValue()))) {
                return false;
            }
        }
        return true;
    }

    public String absString() {
        double c = Math.abs(coefficient);
        String result = c == 1d ? "" :
                (c % 1d == 0d ? Integer.valueOf((int) c).toString() : Double.valueOf(c).toString());
        for(Map.Entry<Character, Double> term : terms.entrySet()) {
            double d = term.getValue();
            d = d % 1 == 0d ? (int)d : d;
            result += (c == 0d || d == 0d ? "" : term.getKey() + (d == 1d ? "" : "^" +
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
