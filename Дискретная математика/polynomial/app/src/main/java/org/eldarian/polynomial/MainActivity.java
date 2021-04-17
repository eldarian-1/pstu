package org.eldarian.polynomial;

import androidx.appcompat.app.AppCompatActivity;

import android.content.DialogInterface;
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
        polynomialBtn.setOnClickListener(this::editTermBtnOnClick);
        termLst.setOnItemClickListener(this::selectTermClick);
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
        TermDialog dialog = new TermDialog("Ок", "Отмена",
                this::addTerm, null, null);
        dialog.show(getSupportFragmentManager(), "custom");
    }

    private void editTermBtnOnClick(View view) {
        TermDialog dialog = new TermDialog("Обновить", "Удалить",
                this::editTerm, this::removeTerm, null);
        dialog.show(getSupportFragmentManager(), "custom");
    }

    private void addTerm(DialogInterface dialog, int which) {
        Toast.makeText(this, "Добавление", Toast.LENGTH_SHORT).show();
    }

    private void editTerm(DialogInterface dialog, int which) {
        Toast.makeText(this, "Обновление", Toast.LENGTH_SHORT).show();
    }

    private void removeTerm(DialogInterface dialog, int which) {
        Toast.makeText(this, "Удаление", Toast.LENGTH_SHORT).show();
    }

    private void selectTermClick(AdapterView<?> parent, View view, int position, long id) {
        Toast.makeText(this, "Выбран " + position, Toast.LENGTH_SHORT).show();
    }
}