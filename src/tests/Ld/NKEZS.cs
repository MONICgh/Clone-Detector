namespace LinkedListTask
{
    public class TaskSolver {
        public TaskSolver()
        {
            
        }

        public static Node Solve(MyLinkedList list1, MyLinkedList list2)
        {
            var ptr1 = list1.Begin();
            var ptr2 = list2.Begin();
            var jump1 = false;
            var jump2 = false;
            while (true)
            {
                if (ptr1 == ptr2)
                {
                    return ptr1;
                }

                if (ptr1.next == null)
                {
                    if (jump1)
                    {
                        return null;
                    }
                    jump1 = true;
                    ptr1 = list2.Begin();
                }
                else
                {
                    ptr1 = ptr1.next;
                }
                
                if (ptr2.next == null)
                {
                    if (jump2)
                    {
                        return null;
                    }
                    jump2 = true;
                    ptr2 = list1.Begin();
                }
                else
                {
                    ptr2 = ptr2.next;
                }
            }
        }
    }
}