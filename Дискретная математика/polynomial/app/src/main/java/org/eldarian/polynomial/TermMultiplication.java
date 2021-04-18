package org.eldarian.polynomial;

import java.util.HashMap;
import java.util.List;
import java.util.Map;

public class TermMultiplication {
    private Double coefficient;
    private Map<Character, Integer> terms;

    private TermMultiplication(TermMultiplication multiply) {
        this.coefficient = multiply.coefficient;
        this.terms = new HashMap<>(multiply.terms);
    }

    public TermMultiplication(List<Term> terms) {
        coefficient = 1d;
        this.terms = new HashMap<>();
        for(Term term : terms) {
            Character name = term.getName();
            coefficient *= term.getCoefficient();
            if(this.terms.get(name) == null) {
                this.terms.put(name, term.getDegree());
            } else {
                this.terms.put(name, this.terms.get(name) + term.getDegree());
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
        for(Map.Entry<Character, Integer> term : terms.entrySet()) {
            if(multiply.terms.get(term.getKey()) != term.getValue()) {
                return false;
            }
        }
        return true;
    }

    public String absString() {
        double c = Math.abs(coefficient);
        String result = (c == 1d ? "" : String.valueOf(c));
        for(Map.Entry<Character, Integer> term : terms.entrySet()) {
            Integer d = term.getValue();
            result += term.getKey() + (d == 1d ? "" : ("^" + d));
        }
        return result;
    }

    @Override
    public String toString() {
        return (isPositive() ? "" : "-") + absString();
    }
}
