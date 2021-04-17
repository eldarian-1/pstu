package org.eldarian.polynomial;

public class Term {
    private static char nextName = 'A';

    private Double coefficient;
    private Integer degree;
    private final Character name;

    public Term(Double coefficient, Integer degree) {
        this.coefficient = coefficient;
        this.degree = degree;
        this.name = nextName++;
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
}
