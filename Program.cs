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

            CartItem[] cartItems = new CartItem[3];   // Initiate array of cart items
            for (int i = 0; i < cartItems.Length; i++)
            {
                cartItems[i] = new CartItem();
            }

            #region SH3 

            int[] noOfItemsInPacksSH3 = { 3, 5, 0 };     // Pack size A, B, C    
            decimal[] priceSH3 = { 2.99m, 4.49m, 0.0m };
            string productCodeSH3 = "SH3";


            cartItems[0].NoOfItemsInPacks = noOfItemsInPacksSH3;
            cartItems[0].Price = priceSH3;
            cartItems[0].ProductCode = productCodeSH3;

            //  Console.WriteLine(" to String " + SH3.ToString());

            //Console.WriteLine("\n No of SH3 Items in each pack1-{0}, pack2-{1}, pack3-{2}",
            //       noOfItemsInPacksSH3[0], noOfItemsInPacksSH3[1], noOfItemsInPacksSH3[2]);


            //  int[] noOfSH3PacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksSH3, totalRequiredNumberSH3);
            //  Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfSH3PacksToShip[0], noOfSH3PacksToShip[1], noOfSH3PacksToShip[2]);

            //  PrintPackDetails(noOfItemsInPacksSH3, priceSH3, noOfSH3PacksToShip, productCodeSH3);

            #endregion
          
            // YT2
            #region: YT2
            int[] noOfItemsInPacksYT2 = { 4, 10, 15 };     // Pack size A, B, C  
            decimal[] priceYT2 = { 4.95m, 9.95m, 13.95m };
            string productCodeYT2 = "YT2";

            cartItems[1].NoOfItemsInPacks = noOfItemsInPacksYT2;
            cartItems[1].Price = priceYT2;
            cartItems[1].ProductCode = productCodeYT2;


            //Console.WriteLine("\n No of YT2 Items in each pack1-{0}, pack2-{1}, pack3-{2}",
            //  noOfItemsInPacksYT2[0], noOfItemsInPacksYT2[1], noOfItemsInPacksYT2[2]);
            //Console.Write(" Enter total number required YT2   ");
            // int totalRequiredNumberYT2 = int.Parse(Console.ReadLine());

            // int[] noOfYT2PacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksYT2, totalRequiredNumberYT2);
            // Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfYT2PacksToShip[0], noOfYT2PacksToShip[1], noOfYT2PacksToShip[2]);

            //PrintPackDetails(noOfItemsInPacksYT2, priceYT2, noOfYT2PacksToShip, productCodeYT2);

            #endregion

            #region TR
            
           int[] noOfItemsInPacksTR = { 3, 5, 9 };     // Pack size A, B, C   
           decimal[] priceTR = { 2.95m, 4.45m, 7.99m };
           string productCodeTR = "TR";

            cartItems[2].NoOfItemsInPacks = noOfItemsInPacksTR;
            cartItems[2].Price = priceTR;
            cartItems[2].ProductCode = productCodeTR;

            // Console.WriteLine("\n No of TR Items in each pack1-{0}, pack2-{1}, pack3-{2}",
            //    noOfItemsInPacksTR[0], noOfItemsInPacksTR[1], noOfItemsInPacksTR[2]);
            //Console.Write(" Enter total number required TR   ");
            //int totalRequiredNumberTR = int.Parse(Console.ReadLine());

            //int[] noOfTRPacksToShip = GetOptiumNoOfPacksSingleItem(noOfItemsInPacksTR, totalRequiredNumberTR);
            //Console.WriteLine("Selected pack combination {0}, {1}, {2}", noOfTRPacksToShip[0], noOfTRPacksToShip[1], noOfTRPacksToShip[2]);

            // PrintPackDetails(noOfItemsInPacksTR, priceTR, noOfTRPacksToShip, productCodeTR);

            #endregion

            // Yoghurt YT2 4 @ $4.95, 10 @ $9.95, 15 @ $13.95


            int[] noOfItemsRequired = { 0, 0, 0 }; // initiate array of required no of items
            string[] codeOfItemsRequired = { "", "", "" };  // ProductCode

            string inputS;  // Read quantiy and code from keyboard
            int cartItemSequenNumberMatch = -1;  // Matching sequence number from Product Array 

            for (int i = 0; i < noOfItemsRequired.Length; i++)
            {
                Console.Write(" Enter number of items followed by code   ");
                inputS = Console.ReadLine();
                string[] inputDetail = inputS.Split(' ');
                try
                {
                    noOfItemsRequired[i] = int.Parse(inputDetail[0]);
                    codeOfItemsRequired[i] = inputDetail[1];
                }
                catch // if input is not in proper format set them to 0 and ""
                {
                    noOfItemsRequired[i] = 0; ;
                    codeOfItemsRequired[i] = "";
                }
                Console.WriteLine(" no required " + noOfItemsRequired[i] + " Code =" + codeOfItemsRequired[i]);

                // Find the matching item by searching product code
               
                if (noOfItemsRequired[i] > 0 )
                {
                    for (int j =0; j< cartItems.Length; j++)
                    {
                        if (cartItems[j].ProductCode.Equals(codeOfItemsRequired[i]))
                        {
                            cartItemSequenNumberMatch = j; // matching item found from product codes
                            break;
                        }
                    }
                }
                Console.WriteLine(" CartItem " + cartItemSequenNumberMatch + " matches code " + codeOfItemsRequired[i]);

                int[] noOfPacksToShip =
               cartItems[cartItemSequenNumberMatch].GetOptiumNoOfPacksSingleItem(noOfItemsRequired[i]);

                cartItems[cartItemSequenNumberMatch].PrintPackDetails();

            } // end of for i



           


            Console.Read();
        }




    }
}
