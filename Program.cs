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
            int[] noOfItemsInPacks = { 2, 5, 0 };     // Pack size A, B, C
            int[] noOfPacksOrdered = { 100, 100, 100 };   // initiate with a large number 
            int[] maxNoOfPacksEach = { 0, 0, 0 };  // initiate only

            Console.WriteLine(" No of Items in each pack1-{0}, pack2-{1}, pack3-{2}", noOfItemsInPacks[0], noOfItemsInPacks[1], noOfItemsInPacks[2]);
            Console.WriteLine(" Enter total number required ");
            int totalRequiredNumber =int.Parse( Console.ReadLine());

            // Calc Max number of packs of each pack by dividing total number by No in each pack
            for (int i = 0; i < noOfPacksOrdered.Length; i++)
            {
                maxNoOfPacksEach[i] = noOfItemsInPacks[i]>0 ? totalRequiredNumber / noOfItemsInPacks[i]:0 ;
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
                            int totalNumberOfPacks = i + j + k;
                            // if it is less than the already selected option, select this as the new pack option
                            if (totalNumberOfPacks < noOfPacksOrdered[0]+ noOfPacksOrdered[1]+noOfPacksOrdered[2] )
                            {
                                noOfPacksOrdered[0] = i;
                                noOfPacksOrdered[1] = j;
                                noOfPacksOrdered[2] = k;
                            }
                            Console.Write(" pack-A {0} x pack-B {1} pack-C {2} ", i, j, k);

                            Console.WriteLine("  A {0} + B {1}+ C {2},  Total {3}", totalQtyInApacks, totalQtyInBpacks, totalQtyInCpacks, grandTotal);
                        }
                    }
                }
            }

            Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfPacksOrdered[0], noOfPacksOrdered[1], noOfPacksOrdered[2]);

            Console.Read();
        }
    }
}
