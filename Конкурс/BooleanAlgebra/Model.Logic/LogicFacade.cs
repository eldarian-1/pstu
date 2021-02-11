using System.Linq;
using Model.Entities;
using System.Collections.Generic;

namespace Model.Logic
{
    public class LogicFacade<TVariable, TFunction, TVariableList, TFunctionList>
        where TVariable : Variable, ISymbol, new()
        where TFunction : Function, ISymbol, new()
        where TVariableList : ICollection<TVariable>, new()
        where TFunctionList : ICollection<TFunction>, new()
    {
        public TVariableList Variables { get; protected set; }

        public TFunctionList Functions { get; protected set; }

        public TFunction ActiveFunction { get; protected set; }

        public LogicFacade()
        {
            Initialize();
        }

        protected virtual void Initialize()
        {
            Variables = new TVariableList();
            Functions = new TFunctionList();
            TVariable A = new TVariable();
            TVariable B = new TVariable();
            Variables.Add(A);
            Variables.Add(B);
            NewFunction(A, B);
        }

        public void AddVariable() => Variables.Add(new TVariable());

        public void InvertVariable(string name)
        {
            foreach(var item in Variables)
                if(item.Name == name)
                {
                    item.Invert();
                    break;
                }
        }

        public void InvertSymbol(bool isLeft) => ActiveFunction.Invert(isLeft);

        public void ChangeSymbol(string name, bool isLeft)
            => new SymbolChanger<TVariable, TFunction, TVariableList, TFunctionList>(this, isLeft, name)
            .Execute();

        public void SetActiveFunction(string name)
        {
            foreach (var item in Functions)
                if (item.Name == name)
                {
                    ActiveFunction = item;
                    break;
                }
        }

        protected void NewFunction(TVariable A, TVariable B)
        {
            TFunction F = new TFunction();
            F.Left = A;
            F.Right = B;
            Functions.Add(F);
            ActiveFunction = F;
        }

        public void AddFunction()
        {
            var list = Variables.ToList();
            NewFunction(list[0], list[1]);
        }

        public void ChangeOperator() => ActiveFunction.Change();

        protected string RunFunction<TResultFormater>()
            where TResultFormater : ResultFormater<TVariable, TFunction, TVariableList, TFunctionList>, new()
            => new TResultFormater().SetFacade(this).Execute();
    }
}
