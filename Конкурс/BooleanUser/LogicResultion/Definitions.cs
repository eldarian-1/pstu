using Resolution.Lists;
using Resolution.Visuals;
using System.Collections.Generic;

namespace Resultion
{
    public static class Definitions
    {
        public static VariableVisual Index(this VariableList list, int index)
        {
            return list[index] as VariableVisual;
        }

        public static FunctionVisual Index(this FunctionList list, int index)
        {
            return list[index] as FunctionVisual;
        }

        public static IEnumerable<VariableVisual> Get(this Logic.Lists.VariableList list)
        {
            foreach (var item in list)
                yield return item as VariableVisual;
        }

        public static VariableList ToList(this Logic.Lists.VariableList list)
        {
            VariableList result = new VariableList();
            foreach (var item in list)
                result.Add(item);
            return result;
        }

        public static FunctionList ToList(this Logic.Lists.FunctionList list)
        {
            FunctionList result = new FunctionList();
            foreach (var item in list)
                result.Add(item);
            return result;
        }

        public static IEnumerable<FunctionVisual> Get(this Logic.Lists.FunctionList list)
        {
            foreach (var item in list)
                yield return item as FunctionVisual;
        }

        public static VariableVisual Get(this Logic.Visuals.VariableVisual variable)
        {
            return variable as VariableVisual;
        }

        public static FunctionVisual Get(this Logic.Visuals.FunctionVisual function)
        {
            return function as FunctionVisual;
        }
    }
}
