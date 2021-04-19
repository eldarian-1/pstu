package org.eldarian.polynomial;

import android.content.Context;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.TextView;

import java.util.List;
import java.util.Map;

public class ArgAdapter extends ArrayAdapter<Map.Entry<Character, Double>> {
    private LayoutInflater inflater;
    private int layout;
    private List<Map.Entry<Character, Double>> args;

    public ArgAdapter(Context context, int resource, List<Map.Entry<Character, Double>> args) {
        super(context, resource, args);
        this.layout = resource;
        this.inflater = LayoutInflater.from(context);
        this.args = args;
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
        Map.Entry<Character, Double> temp = args.get(position);
        viewHolder.nameTxt.setText(temp.getKey().toString());
        viewHolder.degreeTxt.setText(temp.getValue().toString());
        return convertView;
    }

    public List<Map.Entry<Character, Double>> getArgs() {
        return args;
    }

    private static class ViewHolder {
        final TextView nameTxt;
        final TextView degreeTxt;
        ViewHolder(View view){
            nameTxt = view.findViewById(R.id.name_text);
            degreeTxt = view.findViewById(R.id.degree_text);
        }
    }
}

