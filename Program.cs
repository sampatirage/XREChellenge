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

           // decimal[] price = { 2.90m, 5.40m, 8.90m };

            #region SH3 
            int[] noOfItemsInPacksSH3 = { 3, 5, 0 };     // Pack size A, B, C            
            Console.WriteLine("\n No of SH3 Items in each pack1-{0}, pack2-{1}, pack3-{2}", 
                     noOfItemsInPacksSH3[0], noOfItemsInPacksSH3[1], noOfItemsInPacksSH3[2]);
            
            Console.Write(" Enter total number required SH3   ");
            int totalRequiredNumberSH3 = int.Parse(Console.ReadLine());

            int[] noOfSH3PacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksSH3, totalRequiredNumberSH3);
            Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfSH3PacksToShip[0], noOfSH3PacksToShip[1], noOfSH3PacksToShip[2]);
            #endregion
            // YT2
            #region: YT2
            int[] noOfItemsInPacksYT2 = { 4, 10, 15 };     // Pack size A, B, C   
            Console.WriteLine("\n No of YT2 Items in each pack1-{0}, pack2-{1}, pack3-{2}", 
                noOfItemsInPacksYT2[0], noOfItemsInPacksYT2[1], noOfItemsInPacksYT2[2]);
            Console.Write(" Enter total number required YT2   ");
            int totalRequiredNumberYT2 = int.Parse(Console.ReadLine());

            int[] noOfYT2PacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksYT2,  totalRequiredNumberYT2);
            Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfYT2PacksToShip[0], noOfYT2PacksToShip[1], noOfYT2PacksToShip[2]);
            #endregion

            #region TR

            int[] noOfItemsInPacksTR = { 3, 5, 9 };     // Pack size A, B, C   
            Console.WriteLine("\n No of TR Items in each pack1-{0}, pack2-{1}, pack3-{2}",
                noOfItemsInPacksTR[0], noOfItemsInPacksTR[1], noOfItemsInPacksTR[2]);
            Console.Write(" Enter total number required TR   ");
            int totalRequiredNumberTR  = int.Parse(Console.ReadLine());

            int[] noOfTRPacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksTR, totalRequiredNumberTR);
            Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfTRPacksToShip[0], noOfTRPacksToShip[1], noOfTRPacksToShip[2]);

            #endregion





            // Yoghurt YT2 4 @ $4.95, 10 @ $9.95, 15 @ $13.95

            Console.Read();
        }

        private static int[]  GetOptiumNoOfPacksSingleItem(int[] noOfItemsInPacks,   int totalRequiredNumber)
        {
            int[] noOfPacksToOrder = { 100, 100, 100 };   // initiate with a large number 
            int[] maxNoOfPacksEach = { 0, 0, 0 };  // initiate only

            // Calc Max number of packs of each pack by dividing total number by No in each pack
            for (int i = 0; i < noOfPacksToOrder.Length; i++)
            {
                maxNoOfPacksEach[i] = noOfItemsInPacks[i] > 0 ? totalRequiredNumber / noOfItemsInPacks[i] : 0;
                Console.Write(" pack {0}, Needs {1} packs ", i, maxNoOfPacksEach[i]);
            }
            Console.WriteLine();

            // Calculate for each combination of noOfPacksOrdered

            for (int i = 0; i <= maxNoOfPacksEach[0]; i++)  // pack size A
            {
                int totalQtyInApacks = noOfItemsInPacks[0] * i;

                for (int j = 0; j <= maxNoOfPacksEach[1]; j++) // pack size B
                {
                    int totalQtyInBpacks = noOfItemsInPacks[1] * j;

                    for (int k = 0; k <= maxNoOfPacksEach[2]; k++) // pack size C
                    {
                        int totalQtyInCpacks = noOfItemsInPacks[2] * k;
                        int grandTotal = totalQtyInApacks + totalQtyInBpacks + totalQtyInCpacks;
                        if (grandTotal == totalRequiredNumber)
                        {
                            int totalNumberOfPacks = i + j + k;
                            // if it is less than the already selected option, select this as the new pack option
                            if (totalNumberOfPacks < noOfPacksToOrder[0] + noOfPacksToOrder[1] + noOfPacksToOrder[2])
                            {
                                noOfPacksToOrder[0] = i;
                                noOfPacksToOrder[1] = j;
                                noOfPacksToOrder[2] = k;
                            }
                            Console.Write(" pack-A {0} x pack-B {1} pack-C {2} ", i, j, k);

                            Console.WriteLine("  A {0} + B {1}+ C {2},  Total {3}", totalQtyInApacks, totalQtyInBpacks, totalQtyInCpacks, grandTotal);
                        }
                    }
                }
            }
            return noOfPacksToOrder;
        }
        // End GetOptiumNoOfPacksSingleItem

    }
}
