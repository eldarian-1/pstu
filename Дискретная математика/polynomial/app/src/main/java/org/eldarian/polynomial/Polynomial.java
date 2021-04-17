package org.eldarian.polynomial;

import java.util.LinkedList;
import java.util.List;

public class Polynomial {
    private List<Term> terms;
    private Integer degree;

    public Polynomial() {
        terms = new LinkedList<>();
        degree = 0;
    }

    public void add(Term term) {
        terms.add(term);
    }

    public void remove(Term term) {
        terms.remove(term);
    }

    public List<Term> getTerms() {
        return terms;
    }

    public void setTerms(List<Term> terms) {
        this.terms = terms;
    }

    public Integer getDegree() {
        return degree;
    }

    public void setDegree(Integer degree) {
        this.degree = degree;
    }
}
