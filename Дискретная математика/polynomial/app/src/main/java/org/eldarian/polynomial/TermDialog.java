package org.eldarian.polynomial;

import android.annotation.SuppressLint;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import java.util.Objects;

public class TermDialog extends DialogFragment {
    private static final String TAG = "TermDialog";

    private Polynomial polynomial;
    private Term from;

    private EditText coefficient;
    private EditText degree;
    private Button updateBtn;
    private Button cancelBtn;
    private Button deleteBtn;

    public interface OnInputListener {
        void insert(Term term);
        void update(Term from, Term to);
        void delete(Term term);
    }

    private OnInputListener onInputListener;

    public TermDialog(Polynomial polynomial, Term term) {
        super();
        this.polynomial = polynomial;
        this.from = term;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.term_dialog, container, false);
        coefficient = view.findViewById(R.id.coefficient);
        degree = view.findViewById(R.id.degree);
        updateBtn = view.findViewById(R.id.update_btn);
        cancelBtn = view.findViewById(R.id.cancel_btn);
        deleteBtn = view.findViewById(R.id.remove_btn);
        if(from == null) {
            deleteBtn.setVisibility(View.INVISIBLE);
            updateBtn.setText("Добавить");
            updateBtn.setOnClickListener(this::onInsertButtonClick);
        } else {
            coefficient.setText(from.getCoefficient().toString());
            degree.setText(from.getDegree().toString());
            updateBtn.setOnClickListener(this::onUpdateButtonClick);
            deleteBtn.setOnClickListener(this::onDeleteButtonClick);
        }
        cancelBtn.setOnClickListener(this::onCancelButtonClick);
        return view;
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        try {
            onInputListener = (OnInputListener) getActivity();
        } catch (ClassCastException e) {
            Log.e(TAG, "onAttach: " + e.getMessage());
        }
    }

    @SuppressLint("ShowToast")
    private void onInsertButtonClick(View view) {
        try {
            onInputListener.insert(new Term(Double.parseDouble(coefficient.getText().toString()),
                    Integer.parseInt(degree.getText().toString())));
        } catch (Throwable t) {
            Toast.makeText(getActivity(), t.getMessage(), Toast.LENGTH_LONG);
        } finally {
            onCancelButtonClick(view);
        }
    }

    @SuppressLint("ShowToast")
    private void onUpdateButtonClick(View view) {
        try {
            Term to = new Term(from);
            to.setCoefficient(Double.parseDouble(coefficient.getText().toString()));
            to.setDegree(Integer.parseInt(degree.getText().toString()));
            onInputListener.update(from, to);
        } catch (Throwable t) {
            Toast.makeText(getActivity(), t.getMessage(), Toast.LENGTH_LONG);
        } finally {
            onCancelButtonClick(view);
        }
    }

    private void onDeleteButtonClick(View view) {
        onInputListener.delete(from);
        onCancelButtonClick(view);
    }

    private void onCancelButtonClick(View view) {
        Objects.requireNonNull(getDialog()).dismiss();
    }
}
