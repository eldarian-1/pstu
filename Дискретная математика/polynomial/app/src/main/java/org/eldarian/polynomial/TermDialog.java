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
import android.widget.ListView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import java.util.AbstractMap;
import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;
import java.util.Objects;

public class TermDialog extends DialogFragment {
    private static final String TAG = "TermDialog";

    private Term from;
    private List<Map.Entry<Character, Double>> args;

    private EditText coefficient;
    private ListView argLst;
    private Button addArgBtn;
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
        this.from = term;
        if(term == null) {
            args = new LinkedList<>();
        } else {
            args = new LinkedList<>(term.getArgs().entrySet());
        }
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.term_dialog, container, false);
        coefficient = view.findViewById(R.id.coefficient);
        argLst = view.findViewById(R.id.arg_list);
        addArgBtn = view.findViewById(R.id.add_arg);
        updateBtn = view.findViewById(R.id.update_btn);
        cancelBtn = view.findViewById(R.id.cancel_btn);
        deleteBtn = view.findViewById(R.id.remove_btn);
        addArgBtn.setOnClickListener(this::onAddArgButtonClick);
        if(from == null) {
            from = new Term();
            deleteBtn.setVisibility(View.INVISIBLE);
            updateBtn.setText("Добавить");
            updateBtn.setOnClickListener(this::onInsertButtonClick);
        } else {
            coefficient.setText(from.getCoefficient().toString());
            updateBtn.setOnClickListener(this::onUpdateButtonClick);
            deleteBtn.setOnClickListener(this::onDeleteButtonClick);
        }
        ArgAdapter argAdapter = new ArgAdapter(this.getContext(),
                R.layout.arg_list_item, args);
        argLst.setAdapter(argAdapter);
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

    private void onAddArgButtonClick(View view) {
        args.add(new AbstractMap.SimpleEntry<>('A', 1d));
    }

    private Map<Character, Double> getArgs() {
        ArgAdapter adapter = (ArgAdapter)argLst.getAdapter();
        Map<Character, Double> result = new HashMap<>();
        adapter.
        for(Map.Entry<Character, Double> arg : adapter.getArgs()) {
            if(result.get(arg.getKey()) == null) {
                result.put(arg.getKey(), arg.getValue());
            } else {
                result.put(arg.getKey(), result.get(arg.getKey()) + arg.getValue());
            }
        }
        return result;
    }

    @SuppressLint("ShowToast")
    private void onInsertButtonClick(View view) {
        try {
            Double c = Double.parseDouble(coefficient.getText().toString());
            Map<Character, Double> newArgs = getArgs();
            onInputListener.insert(new Term(c, newArgs));
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
            to.setArgs(getArgs());
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
