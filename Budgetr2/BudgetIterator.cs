using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budgetr2
{
    class BudgetIterator
    {
        //private fields
        private Stack<ITraversableBudget> parents;
        private ITraversableBudget headBudget;

        private ITraversableBudget currentBudget;
        private List<IBudget> children;
        private int childCount = 0;

        public ITraversableBudget CurrentBudget { get => currentBudget; }
        
        public int ChildCount { get => childCount; set => childCount = value; }

        //constructor
        public BudgetIterator(ref ITraversableBudget head)
        {
            headBudget = head;

            parents.Push(head);

            currentBudget = head;

            children = currentBudget.SubBudgets;

            childCount = children.Count;
        }
        
        //moves the iterator up
        public bool goToParent()
        {
            if (parents.Count != 1)
            {
                currentBudget = parents.Pop();

                children = currentBudget.SubBudgets;

                childCount = children.Count;

                return true;
            }
            else
            {
                currentBudget = headBudget;

                return false;
            }
        }

        //moves the iterator down
        public void goToChild(int index)
        {
            if (childCount > index)
            {
                if (children[index] is ITraversableBudget)
                {
                    parents.Push(currentBudget);

                    currentBudget = (ITraversableBudget)children[index];

                    children = currentBudget.SubBudgets;

                    childCount = children.Count;
                }
                else
                {
                    throw new InvalidCastException();
                }
            }
        }
    }
}
