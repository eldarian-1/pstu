package org.eldarian.polynomial;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.TextView;

import java.util.List;

public class TermAdapter extends ArrayAdapter<Term> {
    private LayoutInflater inflater;
    private int layout;
    private List<Term> terms;

    public TermAdapter(Context context, int resource, List<Term> terms) {
        super(context, resource, terms);
        this.terms = terms;
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
    }

    public View getView(int position, View convertView, ViewGroup parent) {
        ViewHolder viewHolder;
        if(convertView == null) {
            convertView = inflater.inflate(this.layout, parent, false);
            viewHolder = new ViewHolder(convertView);
            convertView.setTag(viewHolder);
        }
        else {
            viewHolder = (ViewHolder) convertView.getTag();
        }
        viewHolder.termText.setText(terms.get(position).toString());
        return convertView;
    }

    private static class ViewHolder {
        final TextView termText;
        ViewHolder(View view){
            termText = view.findViewById(R.id.term_text);
        }
    }
}
