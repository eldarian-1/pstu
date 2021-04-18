package org.eldarian.polynomial;

public class Term {
    private static char nextName = 'A';

    private Double coefficient;
    private Integer degree;
    private final Character name;

    private Term(Double coefficient, Integer degree, Character name) {
        this.coefficient = coefficient;
        this.degree = degree;
        this.name = name;
    }

    public Term(Term from) {
        this(from.coefficient, from.degree, from.name);
    }

    public Term(Double coefficient, Integer degree) {
        this(coefficient, degree, nextName++);
    }

    public boolean isNull() {
        return coefficient == 0d;
    }

    public boolean isPositive() {
        return coefficient > 0d;
    }

    public Double getCoefficient() {
        return coefficient;
    }

    public void setCoefficient(Double coefficient) {
        this.coefficient = coefficient;
    }

    public Integer getDegree() {
        return degree;
    }

    public void setDegree(Integer degree) {
        this.degree = degree;
    }

    public Character getName() {
        return name;
    }

    @Override
    public String toString() {
        Double c = Math.abs(coefficient);
        return (c == 1d ? "" : c) + name.toString() + (degree == 1d ? "" : ("^" + degree));
    }
}
