using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XREChall
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal [] price = { 2.90m, 5.40m, 8.90m };
            int[] noOfItemsInPacks = { 2, 5, 8 };     // Pack size A, B, C
            int[] noOfPacksOrdered = { 0, 0, 0 };   // initiate only
            int[] maxNoOfPacksEach = { 0, 0, 0 };  // initiate only

            Console.WriteLine(" Enter total number required ");
            int totalRequiredNumber =int.Parse( Console.ReadLine());

            // Calc Max number of packs of each pack by dividing total number by No in each pack
            for (int i = 0; i < noOfPacksOrdered.Length; i++)
            {
                maxNoOfPacksEach[i] = totalRequiredNumber / noOfItemsInPacks[i];
                Console.Write(" pack {0}, Needs {1} packs ", i, maxNoOfPacksEach[i]);                
            }
            Console.WriteLine();

            // Calculate for each combination of noOfPacksOrdered

            for (int i=0; i<= maxNoOfPacksEach[0]; i++)  // pack size A
            {
                int totalQtyInApacks = noOfItemsInPacks[0] * i;

                for (int j=0; j <= maxNoOfPacksEach[1]; j++) // pack size B
                {
                    int totalQtyInBpacks = noOfItemsInPacks[1] * j;

                    for (int k=0; k<= maxNoOfPacksEach[2]; k++) // pack size C
                    {
                        int totalQtyInCpacks = noOfItemsInPacks[2] * k;
                        int grandTotal = totalQtyInApacks + totalQtyInBpacks + totalQtyInCpacks;
                        if (grandTotal == totalRequiredNumber)
                        {
                            Console.Write(" pack-A {0} x pack-B {1} pack-C {2} ", i, j, k);

                            Console.WriteLine("  A {0} + B {1}+ C {2},  Total {3}", totalQtyInApacks, totalQtyInBpacks, totalQtyInCpacks, grandTotal);
                        }
                    }
                }
            }          

            Console.Read();
        }
    }
}
