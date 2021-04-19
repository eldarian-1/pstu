package org.eldarian.polynomial;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class TermMultiplication {
    private Double coefficient;
    private Map<Character, Double> terms;

    private TermMultiplication(TermMultiplication multiply) {
        this.coefficient = multiply.coefficient;
        this.terms = new HashMap<>(multiply.terms);
    }

    public TermMultiplication(List<Term> terms) {
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

    public TermMultiplication add(TermMultiplication term) {
        TermMultiplication result = new TermMultiplication(this);
        result.coefficient += term.coefficient;
        return result;
    }

    public boolean isPositive() {
        return coefficient > 0d;
    }

    public boolean likes(TermMultiplication multiply) {
        for(Map.Entry<Character, Double> term : terms.entrySet()) {
            if(multiply.terms.get(term.getKey()) != term.getValue()) {
                return false;
            }
        }
        return true;
    }

    public String absString() {
        double c = Math.abs(coefficient);
        String result = (c == 1d ? "" : String.valueOf(c));
        for(Map.Entry<Character, Double> term : terms.entrySet()) {
            Double d = term.getValue();
            result += term.getKey() + (d == 1d ? "" : ("^" + d));
        }
        return result;
    }

    @Override
    public String toString() {
        return (isPositive() ? "" : "-") + absString();
    }
}
