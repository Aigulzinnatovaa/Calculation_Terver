using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate_Terver
{
    class Program
    {
        // перестановки с повторениями- Permutations with repetitions 
        //Для сочетаний с повторениями - Combination with repetitions 
        //Для размещений с повторениямий -Placements with repetitions: 

        static public int CalcFactorial(int number)
        {
            if (number == 1) return 1;
            return number * CalcFactorial(number - 1);
        }

        public static void Main(string[] args)
        {
            Console.WriteLine("you want to calculate a calculation that repeats or not? (enter 'yes' or 'no')");

            string input = Console.ReadLine();

            if (input == "no")
            {
                Console.Write("enter n: ");
                int n = Convert.ToInt32(Console.ReadLine());

                Console.Write("enter m: ");
                int m = Convert.ToInt32(Console.ReadLine());
                if (n >= m)
                {
                    //Перестановкиe 
                    Console.WriteLine("permutation Pn = n! = " + Permutation(n));
                    Console.WriteLine();

                    //Сочетаниe 
                    Console.WriteLine("Combination nCm = " + binomialCoeff(n, m));
                    Console.WriteLine();

                    //размещений 
                    Console.WriteLine("Placement nAm = " + nAm(n, m));
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine(" enter n >= m ");
                }
            }

            if (input == "yes")
            {
                //Перестановки с повторениями 

                Console.WriteLine(" перестановки с повторениями- Permutations with repetitions P(n1, n2,..., nk)  ");

                Console.Write("enter the number of elements (k): ");

                int k = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("enter array with elements are n1, n2,..., nk:  ");

                int[] n = new int[k];

                for (int i = 0; i < k; i++)
                {
                    n[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine("=> Permutations with repetitions P(n1, n2,..., nk) = " + PermutationWithRe(n));

                Console.WriteLine();

                // Сочетаниe с повторениями 
                Console.WriteLine(" Для сочетаний с повторениями - Combination with repetitions: ");

                Console.Write("enter n: ");
                int n1 = Convert.ToInt32(Console.ReadLine());
                Console.Write("enter k: ");

                int k1 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine(CalcFactorial(n1 + (k1 - 1)) / (CalcFactorial(k1) * CalcFactorial(n1 - 1)));

                Console.WriteLine();


                //Размещения с повторениями 

                Console.WriteLine("Для размещений с повторениямий -Placements with repetitions: ");
                Console.Write("enter n: ");

                int n2 = Convert.ToInt32(Console.ReadLine());
                Console.Write("enter k: ");

                int k2 = Convert.ToInt32(Console.ReadLine());

                if (n2 > k2)
                {
                    Console.WriteLine(Math.Pow(n2, k2));
                }
                else { Console.WriteLine(" enter n > k"); }
            }
            Console.ReadLine();

        }

        // p không lặp lại 
        public static int Permutation(int n)
        {
            return (n == 1 || n == 0) ? 1 : n * Permutation(n - 1);
        }

        public static int Fact(int n)
        {
            if (n <= 1)
                return 1;
            return n * Fact(n - 1);
        }

        public static int nAm(int n, int m)
        {
            return Fact(n) / Fact(n - m);
        }

        // Coefficient C(n,m) 
        public static int binomialCoeff(int n, int m)
        {

            // Base Cases 
            if (m > n)
                return 0;
            if (m == 0 || m == n)
                return 1;

            // Recur 
            return binomialCoeff(n - 1, m - 1)
                + binomialCoeff(n - 1, m);
        }


        public static int PermutationWithRe(int[] n)
        {
            int temp = 1;
            int sum = 0;

            for (int i = 0; i < n.Length; i++)
            {
                temp *= Permutation(n[i]);
                sum += n[i];
            }

            return Permutation(sum) / temp;

            //Permutation(n.Length)/temp; 

        }

        public static int CombinationWithRep(int n, int k)
        {
            int a = n + k - 1;
            return binomialCoeff(a, k);
        }

        /* 
        public static int CombinationWithRep(int n, int k) 
        { 
             
        }*/
        //Размещения с повторениями 

        public static int ARep(int n, int k)
        {
            int re = 1;
            for (int i = 1; i <= k; i++)
            {
                re *= n;
            }

            return re;
        }
       
    }
    
}
