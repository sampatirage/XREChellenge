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

            #endregion

            // YT2
            #region: YT2

            int[] noOfItemsInPacksYT2 = { 4, 10, 15 };     // Pack size A, B, C  
            decimal[] priceYT2 = { 4.95m, 9.95m, 13.95m };
            string productCodeYT2 = "YT2";
            cartItems[1].NoOfItemsInPacks = noOfItemsInPacksYT2;
            cartItems[1].Price = priceYT2;
            cartItems[1].ProductCode = productCodeYT2;
            
            #endregion

            #region TR

            int[] noOfItemsInPacksTR = { 3, 5, 9 };     // Pack size A, B, C   
            decimal[] priceTR = { 2.95m, 4.45m, 7.99m };
            string productCodeTR = "TR";

            cartItems[2].NoOfItemsInPacks = noOfItemsInPacksTR;
            cartItems[2].Price = priceTR;
            cartItems[2].ProductCode = productCodeTR;

            #endregion

            int[] noOfItemsRequired = { 0, 0, 0 }; // initiate array of required no of items
            string[] codeOfItemsRequired = { "", "", "" };  // ProductCode

            string inputS;  // To read quantiy and code from keyboard
            int cartItemSequenNumberMatch = -1;  // Initialise as negative, Matching sequence number from Product Array 

            for (int i = 0; i < noOfItemsRequired.Length; i++)
            {
                Console.Write(" Enter number of items followed by space then code (Ex : 12 SH3)   ");
                inputS = Console.ReadLine().Trim();  // Get input from screen

                if (inputS.Length < 3)  // Length has to be at least 3 
                {
                    break;
                }
                string[] inputDetail = inputS.Split(' ');
                try
                {
                    noOfItemsRequired[i] = int.Parse(inputDetail[0]); 
                    codeOfItemsRequired[i] = inputDetail[1].ToUpper();
                }
                catch // if input is not in proper format set them to 0 and ""
                {
                    noOfItemsRequired[i] = 0; ;
                    codeOfItemsRequired[i] = "";
                }
               // Console.WriteLine(" no required " + noOfItemsRequired[i] + " Code =" + codeOfItemsRequired[i]);

                // Find the matching item by searching product code
                bool matchFound = false;
                if (noOfItemsRequired[i] > 0)
                {
                    for (int j = 0; j < cartItems.Length; j++)
                    {
                        if (cartItems[j].ProductCode.Equals(codeOfItemsRequired[i]))
                        {
                            matchFound = true;
                            cartItemSequenNumberMatch = j; // matching item found from product codes
                            break;
                        }
                    }
                }
                if (matchFound)
                {
                   // Console.WriteLine(" CartItem " + cartItemSequenNumberMatch + " matches code " + codeOfItemsRequired[i]);
                    int[] noOfPacksToShip =
                    cartItems[cartItemSequenNumberMatch].GetOptiumNoOfPacksSingleItem(noOfItemsRequired[i]);
                    cartItems[cartItemSequenNumberMatch].PrintPackDetails();
                }
                else
                {
                    Console.WriteLine(" Error, no matching item found for the given code or other error ");
                }

            } // end of for i






            Console.Read();
        }




    }
}
