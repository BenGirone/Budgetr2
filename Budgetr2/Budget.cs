using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    class Budget : IBudget, ITraversableBudget
    {
        //private fields
        private int pos;
        private DateTime dateAdded;
        private double amount;
        private string name;
        private double surplus;
        private List<IBudget> subBudgets;
        private List<Expense> expenses;
        private double transferedSurplus; 

        //the amount that can be spent on this budget on any day
        public double Amount { get => amount; set => amount = value; }

        //the cumulative amount of the budget left over after expenses
        public double Surplus { get => surplus; set => surplus = value; }

        //the budget elements that are considered a sub category of this budget
        public List<IBudget> SubBudgets { get => subBudgets; set => subBudgets = value; }

        //the name that will be visible to the user
        public string Name { get => name; set => name = value; }

        public DateTime DateAdded => dateAdded;

        int IBudget.PositionInParent { get => pos; set => pos = value; }

        public List<Expense> Expenses { get => expenses; set => Expenses = value; }

        public double TransferedSurplus { get => transferedSurplus; set => transferedSurplus = value; }

        public Budget()
        {
            dateAdded = DateTime.Now;
        }

        //
        public void addSub(IBudget b)
        {
            b.PositionInParent = subBudgets.Count;
            subBudgets.Add(b);
        }

        //
        public void CalculateBudget()
        {
            surplus = ((DateTime.Now - dateAdded).TotalDays) * amount;
            for (int i = 0; i < expenses.Count; i++)
            {
                surplus -= expenses[i].Amount;
            }
        }

        //
        public void removeSub(int index)
        {
            for (int i = (index + 1); i < subBudgets.Count; i++)
            {
                subBudgets[i].PositionInParent--;
            }

            subBudgets.RemoveAt(index);
        }

        //
        public void TransferSurplus(ref IBudget b, double transferAmount)
        {
            if (transferAmount <= surplus)
            {
                surplus -= transferAmount;
                transferedSurplus -= transferAmount;

                b.Surplus += transferAmount;
                b.TransferedSurplus += transferAmount;
            }
            else
            {
                b.Surplus += surplus;
                b.TransferedSurplus += surplus;

                transferedSurplus -= surplus;
                surplus = 0;
            }
        }

        //
        public void addExpense(Expense exp)
        {
            expenses.Add(exp);
            CalculateBudget();
        }
    }
}
