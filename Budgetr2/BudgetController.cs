using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    class BudgetController
    {
        private BudgetIterator iterator;
        private ITraversableBudget head;

        public BudgetController(ITraversableBudget h)
        {
            head = h;
            iterator = new BudgetIterator(ref head);
        }

        public void addToCurrent(IBudget b)
        {
            iterator.CurrentBudget.addSub(b);
            iterator.ChildCount++;
            iterator.CurrentBudget.Amount += b.Amount;

            Stack<int> sequence = new Stack<int> {};
            sequence.Push(iterator.ChildCount - 1);

            while (iterator.goToParent())
            {
                sequence.Push(iterator.CurrentBudget.PositionInParent);
                iterator.CurrentBudget.Amount += b.Amount;
            }

            for (int i = 0; i < sequence.Count; i++)
            {
                iterator.goToChild(sequence.Pop());
            }
        }

        public void removeFromCurrent(int index)
        {
            iterator.CurrentBudget.removeSub(index);
        }
        
        public bool hasChildren()
        {
            if (iterator.ChildCount == 0)
                return false;
            else
                return true;
        }

        public void goToHead()
        {
            while (iterator.goToParent())
            {
                continue;
            }
        }
    }
}
