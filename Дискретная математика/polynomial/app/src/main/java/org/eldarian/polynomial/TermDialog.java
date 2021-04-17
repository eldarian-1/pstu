package org.eldarian.polynomial;

import android.app.AlertDialog;
import android.app.Dialog;
import android.os.Bundle;
import android.content.DialogInterface;
import android.view.View;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.DialogFragment;

public class TermDialog extends DialogFragment {
    private Polynomial polynomial;
    private Term term;

    public TermDialog(Polynomial polynomial, Term term) {
        super();
        this.polynomial = polynomial;
        this.term = term;
    }

    @NonNull
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity())
                .setTitle("Диалоговое окно")
                .setIcon(android.R.drawable.ic_dialog_alert)
                .setView(R.layout.term_dialog);
        if(term == null) {
            builder.setPositiveButton("Добавить", this::addTerm)
                    .setNegativeButton("Отмена", null);
        } else {
            builder.setPositiveButton("Обновить", this::editTerm)
                    .setNeutralButton("Отмена", null)
                    .setNegativeButton("Удалить", this::removeTerm);
        }
        return builder.create();
    }

    private void addTerm(DialogInterface dialog, int which) {
        View v = getActivity().getLayoutInflater().inflate(R.layout.term_dialog, null);
        TextView c = v.findViewById(R.id.coefficient);
        TextView d = v.findViewById(R.id.degree);
        polynomial.add(new Term(Double.parseDouble(c.getText().toString()),
                Integer.parseInt(d.getText().toString())));
    }

    private void editTerm(DialogInterface dialog, int which) {
        View v = getActivity().getLayoutInflater().inflate(R.layout.term_dialog, null);
        TextView c = v.findViewById(R.id.coefficient);
        TextView d = v.findViewById(R.id.degree);
        term.setCoefficient(Double.parseDouble(c.getText().toString()));
        term.setDegree(Integer.parseInt(d.getText().toString()));
    }

    private void removeTerm(DialogInterface dialog, int which) {
        polynomial.remove(term);
    }

}
