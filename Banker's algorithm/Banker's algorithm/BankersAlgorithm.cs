//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Banker_s_algorithm
//{
//    internal class BankersAlgorithm
//    {
//        static void Main(string[] args)
//        {
//            int n, m;
//            Console.Write("Number of Processes: ");
//            n = Convert.ToInt32(Console.ReadLine());
//            Console.Write("Number of Resources: ");
//            m = Convert.ToInt32(Console.ReadLine());
//            List<List<int>> alloc = new List<List<int>>(n);
//            List<List<int>> max = new List<List<int>>(n);
//            List<List<int>> need = new List<List<int>>(n);
//            for (int i = 0; i < n; i++)
//            {
//                alloc.Add(new List<int>(m));
//                max.Add(new List<int>(m));
//                need.Add(new List<int>(m));
//                for (int j = 0; j < m; j++)
//                {
//                    alloc[i].Add(0);
//                    max[i].Add(0);
//                    need[i].Add(0);
//                }
//            }
//            Console.Write("Enter Allocation Matrix: ");
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < m; j++)
//                {
//                    alloc[i][j] = Convert.ToInt32(Console.ReadLine());
//                }
//            }
//            Console.Write("Enter Maximum Matrix: ");
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < m; j++)
//                {
//                    max[i][j] = Convert.ToInt32(Console.ReadLine());
//                }
//            }
//            List<int> avail = new List<int>(m);
//            Console.Write("Enter Available Resources: ");
//            for (int i = 0; i < m; i++)
//            {
//                avail.Add(Convert.ToInt32(Console.ReadLine()));
//            }
//            Console.WriteLine("Calculating Need of Each Process....");
//            for (int i = 0; i < n; i++)
//            {
//                for (int j = 0; j < m; j++)
//                {
//                    need[i][j] = max[i][j] - alloc[i][j];
//                }
//            }
//            Console.WriteLine("Need matrix is calculated.");
//            List<int> f = new List<int>(n);
//            for (int i = 0; i < n; i++)
//            {
//                f.Add(0);
//            }
//            List<int> ans = new List<int>();
//            int idx = 0;
//            for (int i = 0; i < 5; i++)
//            {
//                for (int j = 0; j < n; j++)
//                {
//                    if (f[j] == 0)
//                    {
//                        int flag = 0;
//                        for (int k = 0; k < m; k++)
//                        {
//                            if (need[j][k] > avail[k])
//                            {
//                                flag = 1;
//                                break;
//                            }
//                        }
//                        if (flag == 0)
//                        {
//                            ans.Add(j);
//                            for (int h = 0; h < m; h++)
//                            {
//                                avail[h] += alloc[j][h];
//                            }
//                            f[j] = 1;
//                        }
//                    }
//                }
//            }
//            Console.Write("SAFE Seq\n");
//            foreach (var i in ans)
//            {
//                Console.Write("P" + i + " -> ");
//            }
//            Console.WriteLine();
//        }
//    }
//}
