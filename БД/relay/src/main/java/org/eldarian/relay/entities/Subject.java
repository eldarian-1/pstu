package org.eldarian.relay.entities;

public class Subject {
    private int _subjectId;
    private String _subjectName;
    private String _subjectUnit;
    private double _subjectMultiplier;

    public int getSubjectId() {
        return _subjectId;
    }

    public void setSubjectId(int subjectId) {
        _subjectId = subjectId;
    }

    public String getSubjectName() {
        return _subjectName;
    }

    public void setSubjectName(String subjectName) {
        _subjectName = subjectName;
    }

    public String getSubjectUnit() {
        return _subjectUnit;
    }

    public void setSubjectUnit(String subjectUnit) {
        _subjectUnit = subjectUnit;
    }

    public double getSubjectMultiplier() {
        return _subjectMultiplier;
    }

    public void setSubjectMultiplier(double subjectMultiplier) {
        _subjectMultiplier = subjectMultiplier;
    }
}
