using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client1.Command
{
    class CompanyCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            /*if (parameter == null ||
                !(parameter is Object[]))
                return;

            Object[] parameters = parameter as Object[];
            if (parameters == null || parameters.Length != 3)
                return;

            foreach (var v in parameters)
            {
                if (v == null || v.ToString().Length == 0)
                    return;
            }

            float n1 = float.Parse(parameters[0].ToString());
            float n2 = float.Parse(parameters[1].ToString());
            String op = parameters[2].ToString();

            switch (op)
            {
                case "+":
                    AddOperation(n1, n2);
                    break;
                case "-":
                    SubOperation(n1, n2);
                    break;
                case "EUR":
                    ConvertRSD2EUR(n1, n2);
                    break;
                default:
                    break;
            }*/
        }
    }
}
