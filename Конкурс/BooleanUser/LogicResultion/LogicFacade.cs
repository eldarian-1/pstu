﻿using Entity;
using Resultion;
using Resolution.Lists;
using Resolution.Visuals;
using Resolution.Commands;

namespace Resolution
{
    public class LogicFacade : Logic.LogicFacade
    {
        public FunctionVisual ResultFunction { get; protected set; }

        public string Expressions
        {
            get
            {
                string variables = Variables.ToString();
                string functions = Functions.ToString();
                string middle = (variables != "" && functions != "" ? ", " : "");
                return variables + middle + functions;
            }
        }

        protected override void Initialize()
        {
            Variables = new VariableList();
            Functions = new FunctionList();
            VariableVisual A = new VariableVisual(true);
            VariableVisual B = new VariableVisual();
            ResultFunction = new FunctionVisual() { Left = B, Right = B, Name = "G" };
            Variables.Add(A);
            Variables.Add(B);
            NewFunction(A, B);
            ActiveFunction.Change();
            ActiveFunction.Change();
        }

        public override void AddVariable() => Variables.Add(new VariableVisual());

        public void ChangeVisibleVariable(string name)
        {
            foreach (VariableVisual item in Variables)
                if (item.Name == name)
                {
                    item.ChangeVisible();
                    break;
                }
        }

        public void ChangeVisibleFunction(string name)
        {
            foreach (FunctionVisual item in Functions)
                if (item.Name == name)
                {
                    item.ChangeVisible();
                    break;
                }
        }

        protected override void NewFunction(Variable A, Variable B)
        {
            FunctionVisual F = new FunctionVisual();
            F.Left = A;
            F.Right = B;
            Functions.Add(F);
            ActiveFunction = F;
        }

        public override void SetActiveFunction(string name)
        {
            if(name == ResultFunction.Name)
            {
                ActiveFunction = ResultFunction;
                return;
            }
            base.SetActiveFunction(name);
        }

        public string RunResulution()
        {
            ResolventList list = new ResolventList();
            list.Add(Variables.Get());
            list.Add(Functions.Get());
            list.Set(ResultFunction);
            list.Fill();
            return list.Solve();
        }

        public override string RunFunction() => new ResultFormater(this).Execute();
    }
}
