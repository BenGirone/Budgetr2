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

        //the amount that can be spent on this budget on any day
        public double Amount { get => amount; set => amount = value; }

        //the cumulative amount of the budget left over after expenses
        public double Surplus { get => surplus; set => surplus = value; }

        //the budget elements that are considered a sub category of this budget
        public List<IBudget> SubBudgets { get => subBudgets; set => subBudgets = value; }

        //the name that will be visible to the user
        public string Name { get => name; set => name = value; }

        public int PositionInParent => pos;

        public DateTime DateAdded => dateAdded;

        public Budget(int p = 0)
        {
            pos = p;
            dateAdded = DateTime.Now;
        }

        //
        public void addSub(IBudget b)
        {
            subBudgets.Add(b);
            CalculateBudget();
        }

        //
        public void CalculateBudget()
        {
            
        }

        //
        public void removeSub(int index)
        {
            throw new NotImplementedException();
        }

        //
        public void TransferSurplus(ref IBudget b, double transferAmount)
        {
            if (transferAmount <= surplus)
            {
                surplus -= transferAmount;

                b.Surplus += transferAmount;
            }
            else
            {
                b.Surplus += surplus;

                surplus = 0;
            }
        }
    }
}
