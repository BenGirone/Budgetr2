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

        int PositionInParent { get; }

        double Amount { set; get; }

        string Name { set; get; }

        double Surplus { set; get; }

        void CalculateBudget();

        void TransferSurplus(ref IBudget b, double transferAmount);
    }
}
