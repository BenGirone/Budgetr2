using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    class Expense
    {
        private string purpose;
        private double amount;
        private DateTime date;

        public Expense(double a, DateTime d, string p = "")
        {
            Amount = a;
            Purpose = p;
            Date = d;
        }

        public string Purpose { get => purpose; set => purpose = value; }

        public double Amount { get => amount; set => amount = value; }

        public DateTime Date { get => date; set => date = value; }
    }
}
