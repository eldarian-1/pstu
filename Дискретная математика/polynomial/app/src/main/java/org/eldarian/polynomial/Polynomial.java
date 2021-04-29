package org.eldarian.polynomial;

import java.util.List;
import java.util.LinkedList;

public class Polynomial {
    private List<Term> terms;
    private Integer degree;

    public Polynomial() {
        terms = new LinkedList<>();
        degree = 1;
    }

    public void insert(Term term) {
        terms.add(term);
    }

    public void update(Term from, Term to) {
        terms.set(terms.indexOf(from), to);
    }

    public void delete(Term term) {
        terms.remove(term);
    }

    public List<Term> getTerms() {
        return terms;
    }

    public Integer getDegree() {
        return degree;
    }

    public void setDegree(Integer degree) throws Throwable {
        if(degree < 1)
            throw new TermException(TermException.Type.POLYNOMIAL_DEGREE);
        this.degree = degree;
    }

    @Override
    public String toString() {
        String result;
        int index = 0;
        int size = terms.size();
        boolean isFirst = degree == 1;
        if(size == 0) {
            result = "Пусто";
        } else {
            result = isFirst ? "" : "(";
            for (Term item : terms) {
                if(index == 0) {
                    if(item.isPositive()) {
                        result += item.absString();
                    } else {
                        result += "-" + item.absString();
                    }
                } else {
                    if(item.isPositive()) {
                        result += " + " + item.absString();
                    } else {
                        result += " - " + item.absString();
                    }
                }
                ++index;
            }
            result += isFirst ? "" : (")^" + degree);
        }
        if(size == 0) {
            result = "Пусто";
        }
        return result;
    }
}
