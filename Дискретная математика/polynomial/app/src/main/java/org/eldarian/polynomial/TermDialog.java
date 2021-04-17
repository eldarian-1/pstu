package org.eldarian.polynomial;

import android.app.AlertDialog;
import android.app.Dialog;
import android.os.Bundle;
import android.content.DialogInterface;

import androidx.annotation.NonNull;
import androidx.fragment.app.DialogFragment;

public class TermDialog extends DialogFragment {
    private String positiveString;
    private String negativeString;
    private DialogInterface.OnClickListener positiveAction;
    private DialogInterface.OnClickListener negativeAction;
    private Term term;

    public TermDialog(String positiveString, String negativeString,
                      DialogInterface.OnClickListener positiveAction,
                      DialogInterface.OnClickListener negativeAction,
                      Term term) {
        super();
        this.positiveString = positiveString;
        this.negativeString = negativeString;
        this.positiveAction = positiveAction;
        this.negativeAction = negativeAction;
        this.term = term;
    }

    @NonNull
    public Dialog onCreateDialog(Bundle savedInstanceState) {
        return new AlertDialog.Builder(getActivity())
                .setTitle("Диалоговое окно")
                .setIcon(android.R.drawable.ic_dialog_alert)
                .setView(R.layout.term_dialog)
                .setPositiveButton(positiveString, positiveAction)
                .setNegativeButton(negativeString, negativeAction)
                .create();
    }
}
