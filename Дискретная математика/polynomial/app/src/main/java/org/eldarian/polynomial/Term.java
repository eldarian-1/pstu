package org.eldarian.polynomial;

public class Term {
    private static char nextName = 'A';

    private Double coefficient;
    private Integer degree;
    private final Character name;

    private Term(Double coefficient, Integer degree, Character name) throws Throwable {
        if(coefficient == 0d)
            throw new Exception("Коэффициент не может быть равен нулю");
        this.coefficient = coefficient;
        this.degree = degree;
        this.name = name;
    }

    public Term(Term from) throws Throwable {
        this(from.coefficient, from.degree, from.name);
    }

    public Term(Double coefficient, Integer degree) throws Throwable {
        this(coefficient, degree, nextName++);
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

    public Integer getDegree() {
        return degree;
    }

    public void setDegree(Integer degree) {
        this.degree = degree;
    }

    public Character getName() {
        return name;
    }

    public String absString() {
        double c = Math.abs(coefficient);
        return (c == 1d ? "" : c) + name.toString() + (degree == 1d ? "" : ("^" + degree));
    }

    @Override
    public String toString() {
        return (isPositive() ? "" : "-") + absString();
    }
}
