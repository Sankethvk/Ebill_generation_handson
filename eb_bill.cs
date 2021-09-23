using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace BILL_GENERATION
{
    class eb_bill
    {
        public static void customer_details()
        {
            List<string> lst = new List<string>();
            Console.WriteLine("enter number of consumers");
            int n = Convert.ToInt32(Console.ReadLine());
            for(int i=0;i<n;i++)
            {
                Console.WriteLine("enter consumer number");
                var consumer_no = Console.ReadLine();
                lst.Add(consumer_no);
                Console.WriteLine("enter consumer name");
                var name = Console.ReadLine();
                lst.Add(name);
                Console.WriteLine("total units");
                var units = Console.ReadLine();
                lst.Add(units);
                FileStream fs = new FileStream(@"C:\Training\EuroTraining\Files\CustomerData.txt", FileMode.Append, FileAccess.Write);
                //System.IO.File.WriteAllLines(@"C:\Training\EuroTraining\Files\CustomerData.txt", lst);
                StreamWriter sr = new StreamWriter(fs);
                sr.WriteLine("Customer data : consumer no , name , units consumed");
                foreach (String s in lst)
                    sr.WriteLine(s);
                sr.WriteLine("**********");
                sr.Close();
                fs.Close();
                billGeneration(lst);
                lst.Clear();

            }


        }
        public static void billGeneration(List<string> lst)
        {
            int units = Convert.ToInt32(lst[2]);
            int total_amount = 5 * units;
            Console.WriteLine("Consumer Bill");
            Console.WriteLine("**************");
            Console.WriteLine("Consumer no : {0}", lst[0]);
            Console.WriteLine("Consumer name : {0}", lst[1]);
            Console.WriteLine("Consumer units consumed : {0}", lst[2]);
            Console.WriteLine("total amount to be paid : Rs.{0}", total_amount);
            Console.WriteLine("**************");
            FileStream FS = new FileStream(@"C:\Training\EuroTraining\Files\BillGeneration.txt", FileMode.Append, FileAccess.Write);
            StreamWriter SR = new StreamWriter(FS);
            SR.WriteLine("consumer number" + " " + lst[0]);
            SR.WriteLine("consumer name" + " " + lst[1]);
            SR.WriteLine("consumed units" + " " + lst[2]);
            SR.WriteLine("total amount" + " " + total_amount);
            SR.WriteLine("**************************");
            SR.Close();
            FS.Close();



        }
    }
}
