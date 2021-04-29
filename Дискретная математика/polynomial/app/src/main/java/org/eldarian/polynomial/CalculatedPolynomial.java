package org.eldarian.polynomial;

import java.util.LinkedList;
import java.util.List;

public class CalculatedPolynomial {
    private List<Transposition> multiplies;

    public CalculatedPolynomial(Polynomial polynomial) {
        multiplies = new LinkedList<>();
        fill(polynomial.getTerms(), new LinkedList<>(), polynomial.getDegree(), 0);
        minimize();
    }

    private void fill(List<Term> from, List<Term> to, int degree, int current) {
        if(current == degree) {
            multiplies.add(new Transposition(to));
            return;
        }
        for(Term term : from) {
            List<Term> temp = new LinkedList<>(to);
            temp.add(term);
            fill(from, temp, degree, current + 1);
        }
    }

    private void minimize() {
        for(int i = 0, n = multiplies.size(); i < n; i++) {
            for(int j = i + 1; j < n && j != i; j++) {
                if(multiplies.get(i).likes(multiplies.get(j))) {
                    multiplies.set(i, multiplies.get(i).add(multiplies.get(j)));
                    multiplies.remove(j--);
                    n--;
                }
            }
        }
    }

    @Override
    public String toString() {
        String result;
        int index = 0;
        int size = multiplies.size();
        if(size == 0) {
            result = "Пусто";
        } else {
            result = "";
            for (Transposition multiply : multiplies) {
                if(index == 0) {
                    if(multiply.isPositive()) {
                        result += multiply.absString();
                    } else {
                        result += "-" + multiply.absString();
                    }
                } else {
                    if(multiply.isPositive()) {
                        result += " + " + multiply.absString();
                    } else {
                        result += " - " + multiply.absString();
                    }
                }
                ++index;
            }
        }
        if(size == 0) {
            result = "Пусто";
        }
        return result;
    }
}
