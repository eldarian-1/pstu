package org.eldarian.polynomial;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.Button;
import android.widget.ListView;
import android.widget.Toast;

public class MainActivity extends AppCompatActivity {
    private Polynomial polynomial;

    private Button polynomialBtn;
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
        termLst = findViewById(R.id.term_list);
        addTermBtn = findViewById(R.id.add_term);
        polynomialBtn.setOnClickListener(this::solvePolynomialBtnOnClick);
        termLst.setOnItemClickListener(this::editTermListItemClick);
        addTermBtn.setOnClickListener(this::addTermBtnOnClick);
        TermAdapter termAdapter = new TermAdapter(this,
                R.layout.term_list_item, polynomial.getTerms());
        termLst.setAdapter(termAdapter);
        updatePolynomialBtn();
    }

    private void updatePolynomialBtn() {
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

    private void solvePolynomialBtnOnClick(View view) {
        Toast.makeText(this, polynomial.toString(), Toast.LENGTH_SHORT).show();
    }
}