using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    interface IBudget
    {
        DateTime DateAdded { get; }

        List<Expense> Expenses { set; get; }

        int PositionInParent { get; set; }

        double Amount { set; get; }

        string Name { set; get; }

        double Surplus { set; get; }

        double TransferedSurplus { get; set; }

        void CalculateBudget();

        void addExpense(Expense exp); 

        void TransferSurplus(ref IBudget b, double transferAmount);
    }
}
