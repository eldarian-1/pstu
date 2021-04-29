package org.eldarian.polynomial;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import java.util.Objects;

public class CalculatedPolynomialDialog extends DialogFragment {
    private CalculatedPolynomial polynomial;

    private TextView polyTxt;
    private Button okBtn;

    public CalculatedPolynomialDialog(CalculatedPolynomial polynomial) {
        super();
        this.polynomial = polynomial;
    }

    @Nullable
    @Override
    public View onCreateView(@NonNull LayoutInflater inflater,
                             @Nullable ViewGroup container, @Nullable Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.polynomial_dialog, container, false);
        polyTxt = view.findViewById(R.id.polynomial);
        okBtn = view.findViewById(R.id.ok_button);
        polyTxt.setText(polynomial.toString());
        okBtn.setOnClickListener(this::onOkButtonClick);
        return view;
    }

    private void onOkButtonClick(View view) {
        Objects.requireNonNull(getDialog()).dismiss();
    }
}
