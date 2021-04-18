package org.eldarian.polynomial;

import java.util.LinkedList;
import java.util.List;

public class CalculatedPolynomial {
    private List<TermMultiplication> terms;

    public CalculatedPolynomial(Polynomial polynomial) {
        terms = new LinkedList<>();
    }
}
