using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    interface ITraversableBudget : IBudget
    {
        List<IBudget> SubBudgets { set; get; }

        void addSub(IBudget b);

        void removeSub(int index);
    }
}
