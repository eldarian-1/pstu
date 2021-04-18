package org.eldarian.polynomial;

import androidx.appcompat.app.AppCompatActivity;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ListView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity implements TermDialog.OnInputListener {
    private Polynomial polynomial;

    private Button polynomialBtn;
    private EditText degreeTxt;
    private Button changeDegreeBtn;
    private ListView termLst;
    private Button addTermBtn;

    public MainActivity() {
        super();
        polynomial = new Polynomial();
    }

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);

        polynomialBtn = findViewById(R.id.polynomial);
        degreeTxt = findViewById(R.id.degree);
        changeDegreeBtn = findViewById(R.id.change_degree_btn);
        termLst = findViewById(R.id.term_list);
        addTermBtn = findViewById(R.id.add_term);

        polynomialBtn.setOnClickListener(this::solvePolynomialBtnOnClick);
        changeDegreeBtn.setOnClickListener(this::changeDegreeBtnOnClick);
        termLst.setOnItemClickListener(this::editTermListItemClick);
        addTermBtn.setOnClickListener(this::addTermBtnOnClick);

        TermAdapter termAdapter = new TermAdapter(this,
                R.layout.term_list_item, polynomial.getTerms());
        termLst.setAdapter(termAdapter);
        updatePolynomial();
    }

    private void solvePolynomialBtnOnClick(View view) {
        CalculatedPolynomialDialog dialog = new CalculatedPolynomialDialog(
                new CalculatedPolynomial(polynomial));
        dialog.show(getSupportFragmentManager(), "custom");
    }

    @SuppressLint("ShowToast")
    private void changeDegreeBtnOnClick(View view) {
        try {
            polynomial.setDegree(Integer.parseInt(degreeTxt.getText().toString()));
            updatePolynomial();
        } catch (Throwable t) {
            Toast.makeText(this, t.getMessage(), Toast.LENGTH_LONG);
        }
    }

    private void updatePolynomial() {
        polynomialBtn.setText(polynomial.toString());
    }

    private void addTermBtnOnClick(View view) {
        TermDialog dialog = new TermDialog(polynomial, null);
        dialog.show(getSupportFragmentManager(), "custom");
    }

    private void editTermListItemClick(AdapterView<?> parent, View view, int position, long id) {
        TermDialog dialog = new TermDialog(polynomial, polynomial.getTerms().get(position));
        dialog.show(getSupportFragmentManager(), "custom");
    }

    @Override
    public void insert(Term term) {
        polynomial.insert(term);
        updatePolynomial();
    }

    @Override
    public void update(Term from, Term to) {
        polynomial.update(from, to);
        updatePolynomial();
    }

    @Override
    public void delete(Term term) {
        polynomial.delete(term);
        updatePolynomial();
    }
}