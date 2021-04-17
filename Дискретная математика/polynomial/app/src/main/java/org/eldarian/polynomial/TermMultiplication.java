package org.eldarian.polynomial;

import java.util.HashSet;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Set;

import static java.lang.Math.pow;

public class TermMultiplication {
    private Double coefficient;
    private final Set<Character> names;
    private final List<Integer> degree;

    public TermMultiplication(Map<Term, Integer> terms) {
        coefficient = 1d;
        names = new HashSet<>();
        degree = new LinkedList<>();
        for(Map.Entry<Term, Integer> term : terms.entrySet()) {
            Term key = term.getKey();
            Integer value = term.getValue();
            if(value != 0) {
                coefficient *= pow(key.getCoefficient(), value);
                names.add(key.getName());
                degree.add(value);
            } else {
                coefficient = 0d;
                names.clear();
                degree.clear();
                break;
            }
        }
    }

    public Double getCoefficient() {
        return coefficient;
    }

    public Set<Character> getNames() {
        return names;
    }

    public List<Integer> getDegree() {
        return degree;
    }
}
