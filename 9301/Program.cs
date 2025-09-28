using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9301_questions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> q = Arr2Q(new int[] { 2, 3, 5 });
            Console.WriteLine(CountQueueModify(q));
            Console.WriteLine(q); //q=[]

            q = Arr2Q(new int[] { 2, 3, 5 });
            Console.WriteLine(CountQueue(q));
            Console.WriteLine(q);

            Console.WriteLine(RemoveAndReturnLast(q));
            Console.WriteLine(q);

            q = Arr2Q(new int[] { 3,5,8 });
            Console.WriteLine(RemoveAndReturnLast(q));
            Console.WriteLine(q);

            q = Arr2Q(new int[] { 3, 5, 8 });
            Console.WriteLine(RemoveAndReturnLast2(q));
            Console.WriteLine(q);
        }
        //1
        // Array to Queue
        // param : int[] arr
        // return : Queue<int>
        // example: param: {1,2,3} , return: [1,2,3]
        static Queue<int> Arr2Q(int[] arr)
        {
            Queue<int> q = new Queue<int>();
            foreach (int value in arr)
                q.Insert(value);
            return q;
        }

        //בכל התרגילים - מיחקו את שורת ההחזרה וממשו את הקוד כנדרש

        // 2
        // number of elements in Q
        // param : Queue<int>
        // return : int
        // example: param: [1,2,3], return: 3
        // note - no need to preserve Q. print Q in main to check it's []
        static int CountQueueModify(Queue<int> q)
        {
            int len = 0;

            while (!q.IsEmpty())
            {
                q.Remove();
                len++;
            }
            return len;

        }

        //בכל השאלות מעכשיו והלאה יש צורך לשמר את התור
        //לא רק בקובץ הזה

        // 3
        // number of elements in Q
        // param : Queue<int>
        // return : int
        // example: param: [1,2,3], return: 3
        // note - print Q in main to check it's not modified
        static int CountQueue(Queue<int> q)
        {
            int len = 0;
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
                len++;
            }

            //restore q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());


            return len;

        }

        // 4
        // Clone Q
        // param : Queue<int>
        // return : Queue<int>
        // example: param: [1,2,3], return new Q: [1,2,3]

        static Queue<int> Clone(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();
            Queue<int> ret = new Queue<int>();

            while (!q.IsEmpty())
            {
                temp.Insert(q.Remove());
            }

            while (!temp.IsEmpty())
            {
                ret.Insert(temp.Head());
                q.Insert(temp.Remove());
            }
            return ret;

        }

        // 5
        // IsValueInQ
        // param : Queue<int>, int
        // return : bool
        // example: param: [1,2,3], 2, return: true
        // note: שימו לב שלא ניתן להחזיר אמת באמצע הפעולה

        // מה הסיבוכיות

        static bool IsValueInQ(Queue<int> q, int val)
        {
            Queue<int> temp = new Queue<int>();
            bool found = false;

            while (!q.IsEmpty())
            {
                if (q.Head() == val) found = true;
                temp.Insert(q.Remove());
            }

            //restore q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return found;

        }

        // 5
        // RemoveFromIndex
        // param : Queue<int>, int
        // return : int
        // example: param: q=[3,5,8], 1; return: 5, after: q=[3,8]
        // note: assume queue is not empty and index>=0 
        static int RemoveFromIndex(Queue<int> q, int index)
        {
            int count = 0, num = 0;
            Queue<int> temp = new Queue<int>();


            while (!q.IsEmpty())
            {
                if (count == index)
                    num = q.Remove();
                else
                    temp.Insert(q.Remove());
                count++;
            }

            //restore q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return num;


        }

        // 6
        // number of elements in Q, *all elements positive*
        // param : Queue<int>
        // return : int
        // example: param: [1,2,3], return: 3
        // note - CANNOT use another queue

        static int CountQueueNoTemp(Queue<int> q)
        {
            q.Insert(-1);
            int len = 0;

            while (q.Head()!=-1)
            {
                len++;
                q.Insert(q.Remove());
            }

            q.Remove(); //remove -1

            return len;


        }

        // 7
        // RemoveAndReturnLast
        // param : Queue<int>
        // return : int
        // example: param: q=[3,5,8], return: 8, after: q=[3,5]
        // note: assume queue is not empty
        // tip: tricky...



        static int RemoveAndReturnLast(Queue<int> q)
        {

            Queue<int> temp = new Queue<int>();
            int len = 0, last=0;
            while (!q.IsEmpty())
            {
                last = q.Remove();
                len++;
                temp.Insert(last);
            }

            // restore q, except last
            for (int i = 0; i < len - 1; i++)
                q.Insert(temp.Remove());

            return last;
        }

        static int RemoveAndReturnLast2(Queue<int> q)
        {
            Queue<int> temp = new Queue<int>();

            int last = q.Remove(); 
            while (!q.IsEmpty())
            {
                temp.Insert(last);
                last = q.Remove();
            }

            //restore q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());

            return last;
        }

        // 8
        // InsertToSortedQ
        // param : Queue<int> sorted ascending, int
        // return : void
        // example: param: q=[3,5,8], 4, after: q=[3,4,5,8]
        // example2: param: q=[3,4,5,8], 9, after: q=[3,4,5,8,9]

        static void InsertToSortedQ(Queue<int> q, int num)
        {
            bool inserted = false;
            Queue<int> temp = new Queue<int>();

            while (!q.IsEmpty())
            {
                if (num < q.Head() && !inserted)
                {
                    inserted = true;
                    temp.Insert(num);
                }
                else
                    temp.Insert(q.Remove());
            }

            if (!inserted)
                temp.Insert(num);

            //restore q
            while (!temp.IsEmpty())
                q.Insert(temp.Remove());
        }

        // 9
        // Merge2Queues
        // param : Queue<int>, Queue<int>
        // return : Queue<int>
        // example: param: q1=[1,3,5,7], q2=[0,2], return: [1,0,3,2,5,7]
        // אין צורך לשמר את 2 הרשימות המתקבלות
        static Queue<int> Merge2Queues(Queue<int> q1, Queue<int> q2)
        {
            return null;

        }

    }
}