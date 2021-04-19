package org.eldarian.polynomial;

import android.annotation.SuppressLint;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
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
    private Map.Entry<Character, Double> currentArg;

    private EditText coefficient;
    private EditText argName;
    private EditText argDegree;
    private ListView argLst;
    private Button addArgBtn;
    private Button remArgBtn;
    private Button updateBtn;
    private Button cancelBtn;
    private Button deleteBtn;

    public interface OnInputListener {
        void insert(Term term);
        void update(Term from, Term to);
        void delete(Term term);
    }

    private OnInputListener onInputListener;

    public TermDialog(Term term) {
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
        argName = view.findViewById(R.id.name_arg);
        argDegree = view.findViewById(R.id.degree_arg);
        argLst = view.findViewById(R.id.arg_list);
        addArgBtn = view.findViewById(R.id.add_arg);
        remArgBtn = view.findViewById(R.id.remove_arg);
        updateBtn = view.findViewById(R.id.update_btn);
        cancelBtn = view.findViewById(R.id.cancel_btn);
        deleteBtn = view.findViewById(R.id.remove_btn);

        updateCurrentArg(null);
        remArgBtn.setOnClickListener(this::onRemoveArgButtonClick);
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
        argLst.setOnItemClickListener(this::editArgListItemClick);
        cancelBtn.setOnClickListener(this::onCancelButtonClick);
        return view;
    }

    private void updateCurrentArg(Map.Entry<Character, Double> arg) {
        currentArg = arg;
        if(arg == null) {
            argName.setText("");
            argDegree.setText("");
            addArgBtn.setText("+");
            addArgBtn.setOnClickListener(this::onAddArgButtonClick);
            remArgBtn.setVisibility(View.INVISIBLE);
        } else {
            argName.setText(arg.getKey().toString());
            argDegree.setText(arg.getValue().toString());
            addArgBtn.setText("*");
            addArgBtn.setOnClickListener(this::onEditArgButtonClick);
            remArgBtn.setVisibility(View.VISIBLE);
        }
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
        args.add(new AbstractMap.SimpleEntry<>(
                argName.getText().charAt(0),
                Double.parseDouble(argDegree.getText().toString())
        ));
        updateCurrentArg(null);
    }

    private void onEditArgButtonClick(View view) {
        args.set(args.indexOf(currentArg), new AbstractMap.SimpleEntry<>(
                argName.getText().charAt(0),
                Double.parseDouble(argDegree.getText().toString())));
        updateCurrentArg(null);
    }

    private void onRemoveArgButtonClick(View view) {
        args.add(new AbstractMap.SimpleEntry<>('A', 1d));
    }

    private Map<Character, Double> getArgs() {
        ArgAdapter adapter = (ArgAdapter)argLst.getAdapter();
        Map<Character, Double> result = new HashMap<>();
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
            onInputListener.insert(new Term(c, getArgs()));
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

    private void editArgListItemClick(AdapterView<?> parent, View view, int position, long id) {
        updateCurrentArg((Map.Entry<Character, Double>)argLst.getAdapter().getItem(position));
    }

    private void onCancelButtonClick(View view) {
        Objects.requireNonNull(getDialog()).dismiss();
    }
}
