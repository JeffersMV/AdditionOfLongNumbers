using System;
using System.Collections;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            const int cellLength = 18;
            string result;
            ArrayList listNum = new ArrayList();
            ArrayList listNum1 = new ArrayList();
            ArrayList listNum2 = new ArrayList();

            Console.WriteLine("Введите первое число: ");
            listNum1 = stringToArray(Console.ReadLine(), cellLength);

            Console.WriteLine("Введите второе число: ");
            listNum2 = stringToArray(Console.ReadLine(), cellLength);

            listNum = addition(listNum1, listNum2, cellLength);

            result = arrayToString(listNum);
            try {
                while (result.ToCharArray()[0] == '0')
                {
                    result = result.Remove(0, 1);
                }
                Console.WriteLine("Результат: " + result);
            } catch {
                Console.WriteLine("Результат: 0");
            }
            Console.ReadKey();
        }
        public static ArrayList stringToArray(string num, int l)
        {
            ArrayList listNum = new ArrayList();
            double longArraylist = Convert.ToInt32(Math.Ceiling(num.Length / Convert.ToDouble(l)));

            for (long i = 0; i < longArraylist; i++)
            {
                string lastNum;
                int lo;
                if (num.Length < l) {lo = num.Length;} else {lo = l;}

                lastNum = num.Substring(num.Length - lo);
                string uio = lastNum;
                listNum.Add(uio);
                num = num.Remove(num.Length - lo);
            }
            return listNum;
        }
        public static ArrayList addition(ArrayList arrayList1, ArrayList arrayList2, int l) {
            ArrayList list1 = new ArrayList();
            ArrayList list2 = new ArrayList();
            ArrayList list = new ArrayList();

            if(arrayList1.Count > arrayList2.Count)
            {
                list1 = arrayList1;
                list2 = arrayList2;
            } else
            {
                list1 = arrayList2;
                list2 = arrayList1;
            }

            string numString2 = null;
            for (int i = 0; i < list1.Count; i++)
            {
                string lo = "0";
                var lo1 = list1[i];
                try
                {
                    var lo2 = list2[i];
                    lo = Convert.ToString(Convert.ToInt64(lo1) + Convert.ToInt64(lo2) + Convert.ToInt64(numString2));
                    numString2 = null;
                }
                catch
                {

                    lo = Convert.ToString(Convert.ToInt64(lo1) + Convert.ToInt64(numString2));
                    numString2 = null; ;
                }
                finally
                {
                    string numString = lo;
                    if (numString.Length > l && i != list1.Count - 1)
                    {
                        string numString1 = numString.Substring(numString.Length - l);
                        numString2 = numString.Remove(numString.Length - l);
                        lo = numString1;
                    }
                    if (numString.Length < l)
                    {
                        int k = l - numString.Length;
                        for (int t = 0; t < k; t++)
                        {
                            numString = numString.Insert(0, "0");
                        }
                        lo = numString;
                    }
                }
                list.Add(lo);
            }
            return list;
        }
        public static String arrayToString (ArrayList arrayList)
        {
            string s = "";
            for (int i = arrayList.Count; i > 0; i--)
            {
                s += Convert.ToString(arrayList[(i-1)]);
            }
            return s;
        }
    }
}
