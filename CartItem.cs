using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XREChall
{
    class CartItem
    {
        public int[] NoOfItemsInPacks { get; set; }
        public decimal[] Price { get; set; }
        public string ProductCode { get; set; }
        int[] noOfPacksToOrder = { 100, 100, 100 };   // initiate with a large number 


        // Constructor 1
        public CartItem()
        {
        }
        // Constructor 2
        public CartItem(int[] noOfItemsInPacks, decimal[] price, string productCode)
        {
            NoOfItemsInPacks = noOfItemsInPacks;
            Price = price;
            ProductCode = productCode;
            Console.WriteLine("product Code" + ProductCode);
        }   

        
       public override string  ToString()
        {
            string returnString = null;
            for (int i=0; i< NoOfItemsInPacks.Length; i++)
            {
                returnString += (NoOfItemsInPacks[i] + " @ $" + Price[i] +", ");
            }

            return returnString;
        }


       public int[] GetOptiumNoOfPacksSingleItem( int totalRequiredNumber1)
        {
            int[] maxNoOfPacksEach = { 0, 0, 0 };  // initiate only

            // Calc Max number of packs of each pack by dividing total number by No in each pack
            for (int i = 0; i < noOfPacksToOrder.Length; i++)
            {
                maxNoOfPacksEach[i] = NoOfItemsInPacks[i] > 0 ? totalRequiredNumber1 / NoOfItemsInPacks[i] : 0;
                Console.Write(" pack {0}, Max {1} packs ", i, maxNoOfPacksEach[i]);
            }
            Console.WriteLine();

            // Calculate for each combination of noOfPacksOrdered

            for (int i = 0; i <= maxNoOfPacksEach[0]; i++)  // pack size A
            {
                int totalQtyInApacks = NoOfItemsInPacks[0] * i;

                for (int j = 0; j <= maxNoOfPacksEach[1]; j++) // pack size B
                {
                    int totalQtyInBpacks = NoOfItemsInPacks[1] * j;

                    for (int k = 0; k <= maxNoOfPacksEach[2]; k++) // pack size C
                    {
                        int totalQtyInCpacks = NoOfItemsInPacks[2] * k;
                        int grandTotal = totalQtyInApacks + totalQtyInBpacks + totalQtyInCpacks;
                        if (grandTotal == totalRequiredNumber1)
                        {
                            int totalNumberOfPacks = i + j + k;
                            // if it is less than the already selected option, select this as the new pack option
                            if (totalNumberOfPacks < (noOfPacksToOrder[0] + noOfPacksToOrder[1] + noOfPacksToOrder[2]))
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



        public void PrintPackDetails() // int[] noOfItemsInPacks, decimal[] price, int[] noOfPacksToShip, string productCode)
        {
            Console.WriteLine(" Product " + ProductCode);
            decimal totalPrice = 0m;
            for (int i = 0; i < NoOfItemsInPacks.Length; i++)
            {
                if (noOfPacksToOrder[i] > 0)
                {             // Print if no of packs is > 0
                    Console.WriteLine(" {0}x{1} packs. @ Price ${2} ", noOfPacksToOrder[i], NoOfItemsInPacks[i], Price[i]);
                    totalPrice += noOfPacksToOrder[i] * Price[i];
                }
            }
            Console.WriteLine(" Total price =" + totalPrice + "\n");
        }

    }
}
