using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PseudoToCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string option = "";
            while (option != "0") // as first time option is NULL not 0 it will execute once and go inside while to take input
            {               
                Console.WriteLine("\n\nPress 1 to execute Sum program. \nPress 2 to execute EvenNumbers program. \n" +
               "Press 3 to execute CheckForLeapYear program. \nPress 4 to execute KphToMph program.\n" +
               "Press 5 to execute BuzzNumber program. \nPress 6 to execute PrintTABLE program. \n" +
               "Press 7 to execute factorial program. \nPress 8 to execute CheckifPrime program. \n" +
               "Press 9 to execute CheckTriangle program. \nPress 10 to execute PrintHalfTriangle program. \n" +
               "Press 11 to execute CheckForPalindrome program. \nPress 0 to exit! \n");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        Sum();
                        break;
                    case "2":
                        EvenNumbers();
                        break;
                    case "3":
                        CheckForLeapYear(1900);
                        break;
                    case "4":
                        KphToMph();
                        break;
                    case "5":
                        BuzzNumber();
                        break;
                    case "6":
                        PrintTABLE();
                        break;
                    case "7":
                        int factorialofnum = factorial();
                        Console.WriteLine($"The Factorial is: {factorialofnum}");
                        break;
                    case "8":
                        CheckifPrime();
                        break;
                    case "9":
                        CheckTriangle();
                        break;
                    case "10":
                        PrintHalfTriangle();
                        break;
                    case "11":
                        CheckForPalindrome(12321);
                        break;
                    case "0":                                              
                        break;
                    default:
                        Console.WriteLine("Enter a any given option please!");
                        break;
                }
            }

            //Sum();
            //EvenNumbers();
            //CheckForLeapYear(1900);
            //KphToMph();
            //BuzzNumber();
            //PrintTABLE();
            //factorial();
            //CheckifPrime();
            //CheckTriangle();
            //PrintHalfTriangle();
            //CheckForPalindrome(12321);

            //Console.WriteLine("Press Enter to exit.");
            //Console.ReadLine();
        }
        static void Sum()
        {
            string number1, number2;
            int num1, num2, Sum = 0;
            Console.WriteLine("Please enter two numbers: ");
            number1 = Console.ReadLine();
            number2 = Console.ReadLine();
            num1 = Convert.ToInt32(number1); // converting num1 to integer
            num2 = Convert.ToInt32(number2); // converting num2 to integer
            Sum = num1 + num2;
            Console.WriteLine($"The Sum of Numbers is : {Sum}");
        }

        static void EvenNumbers()
        {
            int EvenNo = 1;
            while(EvenNo <= 100)
            {
                if (EvenNo % 2 == 0)
                {
                    Console.WriteLine($"{EvenNo} is an Even Number.");
                }
                EvenNo++;
            }
        }

        static void CheckForLeapYear(int year)
        {
            //int year = 2024; // it is divisible by 4 but not 100 so its leap year.
            //int year = 200; // it is divisible by 4 and 100 too so its not a leap year.
            //int year = 6000; // it is divisible by all 4,100,400 then its leap year.
            if (year % 4 == 0 && year % 100 != 0) // if year is divisible by 4 then it has to not be divisible by 100 to be a leap year.
            {
                Console.WriteLine($"{year} is a leap year!");
            }
            else if (year % 100 == 0 && year % 400 == 0) // if it is divisible by 100 too then it must be divisible by 400 as well to be leap year.
            {
                Console.WriteLine($"{year} is a leap year!");
            }
            else
            {
                Console.WriteLine($"{year} is not a leap year!");
            }          
        }

        static void KphToMph()
        {
            double kphvalue = 120, mphValue;
            mphValue = kphvalue * 0.621371;
            Console.WriteLine($"{mphValue} is mph value for: {kphvalue} kph!");
        }

        static void BuzzNumber()
        {
            string number;
            int num;
            Console.WriteLine("Please enter a number to check if its buzz: ");
            number = Console.ReadLine();
            num = Convert.ToInt32(number); // converting string to integer num.
            if (num < 10 && num == 7) // if number is exact 7
            {
                Console.WriteLine($"{num} is a Buzz Number!");
            }
             else if (num % 7 == 0 || num % 10 == 7) // check if it divisible by 7 or it is ending with 7
            {
                Console.WriteLine($"{num} is a Buzz Number!");
            }
            else
                Console.WriteLine($"{num} is not a Buzz Number!");
        }
        static void PrintTABLE()
        {
            string number;
            int num, counter = 1, tableNo;
            Console.WriteLine("Please enter a number to print its table: ");
            number = Console.ReadLine();
            num = Convert.ToInt32(number); // converting string to integer num.
            while (counter <= 10)
            {
                tableNo = num * counter;
                Console.WriteLine($"{num} x by {counter} is {tableNo}!");
                counter++;
            }
        }

        static int factorial()
        {
            string number;
            int num, counter = 1, factorialOfNum = 1;
            Console.WriteLine("Please enter a number to print its factorial: ");
            number = Console.ReadLine();
            num = Convert.ToInt32(number); // converting string to integer num.
            if (num == 1 || num == 0) // as both 0 and 1 are having 1 as factorial
            {
                Console.WriteLine($"Factorial of {num} is 1");
            }
            else
                for (counter = 1; counter <= num;) // loop terminates after we multiply factorial with all the numbers including the Number itself
                {
                    factorialOfNum = factorialOfNum * counter;
                    counter++;                  
                }
            return factorialOfNum;
            //Console.WriteLine($"Factorial of {num} is {factorialOfNum}");
        }

        static void CheckifPrime()
        {
            string number;
            int num, counter = 2, temp; // counter iterate till half and temp to store half of the original number to make it efficient.
            Console.WriteLine("Please enter a number to check if its prime: ");
            number = Console.ReadLine();
            num = Convert.ToInt32(number); // converting string to integer num.
            temp = num / 2;
            while (counter <= temp) // means counter starts with 2 and goes to check the number TILL its half which is temp
            {
                if (num % counter == 0)
                {
                    Console.WriteLine($"{num} is not a Prime Number!");
                    return; // as soon as number is divisible by any number till its half it prints its not prime and return to come OUT of while's scope
                }
                counter++;             
            }
            Console.WriteLine($"{num} is a Prime Number!");
        }

        static void CheckTriangle()
        {
            string side1, side2, side3;
            int sideint1, sideint2, sideint3;
            Console.WriteLine("Please enter a three sides of a triangle: ");
            side1 = Console.ReadLine();
            side2 = Console.ReadLine();
            side3 = Console.ReadLine();
            sideint1 = Convert.ToInt32(side1); // converting string to integer num.
            sideint2 = Convert.ToInt32(side2); // converting string to integer num.
            sideint3 = Convert.ToInt32(side3); // converting string to integer num.

            if (sideint1 == sideint2 && sideint1 == sideint3)
                Console.WriteLine("Triangle is Equilateral! ");
            else if (sideint1 == sideint2 || sideint1 == sideint3 || sideint2 == sideint3)
                Console.WriteLine("Triangle is Isosceles! ");
            else
                Console.WriteLine("Triangle is Scalene! ");                  
        }

        static void PrintHalfTriangle()
        {
            for (int i = 1; i <= 5; i++) //for printing 5 rows here
            {
                for (int j = 1; j <= i; j++) //for printing a single row 1* then 2* then 3* and so on
                {
                    Console.Write("*"); //if we use writeline here it will not print at the same line
                }
             Console.WriteLine(); // to move to next line/row
            }
        }

        static void CheckForPalindrome(int number)
        {
            //string number;
            int num, reverse = 0, temp, lastDigit; 
            //Console.WriteLine("Please enter a number to check if its palindrome: ");
            //number = Console.ReadLine();
            num = Convert.ToInt32(number); // converting string to integer num.
            temp = num; //to have record of original number so we can compare if it is equal to its reverse
            while (num > 0) // loop iterates till number becomes zero and comes out of the loop.
            {
                lastDigit = num % 10;
                reverse = reverse * 10 + lastDigit;
                num = num / 10; // to decrease the digits from the last everytime to make it 0.
            }
            if (reverse == temp)
            {
                Console.WriteLine($"The Number {temp} is a Palindrome Number!");
            }
            else
                Console.WriteLine($"The Number {temp} is not a Palindrome Number!");
        }
    }
}
