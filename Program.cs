using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //RemoveDuplicates();
            //ZerosAtEnd();
            //LargestAndSecondLargest();
            //FirstNonRepeating();
            //MergeTwoSortedArrays();
            //MissingNumberInarray();
            //ArmstrongNumber();
            //LongestCommonPrefix();
            //FibonacciSeries();
            PositiveAndNegativeCount();


            Console.WriteLine("Press Enter to exit.");
            Console.ReadLine();


        }
        static void RemoveDuplicates()
        {
            int[] A = { 2, 2, 5, 8, 5, 9, 3 };
            HashSet<int> ANew = new HashSet<int>(); //using hashset because it always adds up/ contains unique elements.

            foreach (int element in A) //iterating on arrayA to add all its elements in Anew hashset with no duplicate
            {
                ANew.Add(element);
            }

            foreach (int element in ANew)
            {
                Console.Write(element); //printing all the hashset elements
                Console.Write(" ");
            }
        }

        static void LargestAndSecondLargest()
        {
            int[] A = { 20, 10, 5, 4 };
            Console.Write("The array is: ");
            foreach (int element in A)
            {
                Console.Write(element);
                Console.Write(" ");
            }
            Console.WriteLine();

            int Largest = 0, SecondLargest = 0;
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > Largest)
                {
                    SecondLargest = Largest; //updating 2nd largest before largest as greater than largest is found and its no longer largest
                    Largest = A[i];           // recent found largest is assigned to largest        
                }
                else if (A[i] > SecondLargest && A[i] != Largest) // runs when 10 comes after 20 for ex. it is less than largest but greater than 2nd largest.
                {
                    SecondLargest = A[i];
                }
            }
            Console.WriteLine($"The Largest Number in Array is: {Largest}");
            Console.WriteLine($"The Second Largest Number in Array is: {SecondLargest}");

        }

        static void ZerosAtEnd()
        {
            int[] ZerosArray = { 2, 0, 5, 0, 0, 0, 3 };
            List<int> NoZerosList = new List<int>();
            int CountZero = 0;


            foreach (int element in ZerosArray) //loop to count zeros in array
            {
                if (element == 0)
                {
                    CountZero++;
                }
            }

            foreach (int element in ZerosArray) //loop to add all non-zero elements first
            {
                if (element != 0)
                {
                    NoZerosList.Add(element);
                }
            }

            while (CountZero != 0) //loop to add zeros at the end in the list
            {
                NoZerosList.Add(0);
                CountZero--;
            }

            foreach (int element in NoZerosList) //loop to print list after adding zeros
            {
                Console.Write(element);
                Console.Write(" ");
            }
        }

        static void FirstNonRepeating()
        {
            String CheckString = "Swiss";
            CheckString = CheckString.ToLower(); // to make S and s as same as we are using ASCII 
            int[] CountOfEachChar = new int[256]; // as 256 can be the max number of characters including cap, small, numbers, special chars, etc
            int[] IndexOfChar = new int[256]; // the index of first occurrence of each char to check later the order in which characters appeared and return the first
            char FirstLowestCountChar = '\0';
            // Initialize FirstIndex with -1 (indicating character has not appeared yet)
            for (int i = 0; i < 256; i++)
            {
                IndexOfChar[i] = -1; //to initialize all the indexes with -1 
            }
            int index = 0;
            foreach (char ch in CheckString)
            {
                CountOfEachChar[ch]++; // stores count of each character in CheckString
                if (IndexOfChar[ch] == -1)
                {
                    IndexOfChar[ch] = index; // stores the first occurrence index of char
                }
                index++;
            }

            int MinIndexFirstly = 1000;
            foreach (char ch in CheckString)
            {
                if (CountOfEachChar[ch] == 1 && IndexOfChar[ch] < MinIndexFirstly)
                {
                    MinIndexFirstly = IndexOfChar[ch];
                    FirstLowestCountChar = ch; // Stores the character with lowest index where count is 1
                }
            }
            Console.WriteLine($"First Non-Repeating character in {CheckString} is {FirstLowestCountChar}");
        }

        static void MergeTwoSortedArrays()
        {
            int[] Array1 = { 1, 3, 5, 7 };
            int[] Array2 = { 2, 4, 6, 8 };
            int[] SortedMergedArray = new int[Array1.Length + Array2.Length];
            int IndexArray1 = 0, IndexArray2 = 0, IndexNewArray = 0; //iterators for each array initialized with zero to start with first index

            while (IndexArray1 < Array1.Length && IndexArray2 < Array2.Length)
            {
                if (Array1[IndexArray1] < Array2[IndexArray2])
                {
                    SortedMergedArray[IndexNewArray] = Array1[IndexArray1];
                    IndexArray1++;
                    IndexNewArray++;
                }
                else
                {
                    SortedMergedArray[IndexNewArray] = Array2[IndexArray2];
                    IndexArray2++;
                    IndexNewArray++;
                }
            }

            while (IndexArray1 < Array1.Length) // when length of Array2 is smaller than Array1 and Array1 still has elements in it
            {
                SortedMergedArray[IndexNewArray] = Array1[IndexArray1];
                IndexNewArray++;
                IndexArray1++;
            }

            while (IndexArray2 < Array2.Length) // when length of Array1 is smaller than Array2 and Array2 still has elements in it
            {
                SortedMergedArray[IndexNewArray] = Array2[IndexArray2];
                IndexNewArray++;
                IndexArray2++;
            }
            Console.WriteLine("Merged Array: " + string.Join(", ", SortedMergedArray));
        }

        static void LongestCommonPrefix()
        {
            string[] ArrayToCheck = {"internet", "intermediate", "interstellar" };

            if (ArrayToCheck == null || ArrayToCheck.Length == 0) //for edge cases
                Console.WriteLine("");

            string prefix = ArrayToCheck[0]; //we are storing the first string to check it with other strings

            for (int i = 1; i < ArrayToCheck.Length; i++)
            {              
                //indexof returns the startind index 0 if both starts with same prefix otherwise -1, as here its internet, intermediate does not starts with internet so its -1
                while (ArrayToCheck[i].IndexOf(prefix) != 0) // While the current string does not start with the current prefix, trim the prefix from end
                {
                    prefix = prefix.Substring(0, prefix.Length - 1);
                    if (prefix.Length == 0)
                        Console.WriteLine("");
                }
            }
            Console.Write("The Longest Common Prefix in array [{0}]", string.Join(", ", ArrayToCheck));
            Console.WriteLine($" is: {prefix}");
        }

        static void MissingNumberInarray()
        {
            //we will use sum technique here, as we have formula for calculating the sum of numbers from 0.
            int[] ArrayToCheck = { 0, 2, 4, 7, 6, 1, 3 }; // 5 is missing
            int MissingNumber;
            int n = ArrayToCheck.Length; // to calculate the sum of all the numbers in the array including missing no. as 0 is counted as 1
            int SumOfArrayIncludingMissing = n * (n + 1) / 2; // Sum of first all numbers

            int SumOfArray = 0;
            foreach (int number in ArrayToCheck)
            {
                SumOfArray = SumOfArray + number;
            }

            MissingNumber = SumOfArrayIncludingMissing - SumOfArray;
            Console.Write("Missing Number in [{0}]", string.Join(", ", ArrayToCheck));
            Console.WriteLine($" is: {MissingNumber}");

        }

        static void ArmstrongNumber()
        {
            int number = 153, LastDigit, SumToCheck = 0;
            int OriginalNumber = number;
            while (number != 0)
            {
                LastDigit = number % 10;
                int LengthOfNumber = OriginalNumber.ToString().Length;
                SumToCheck = SumToCheck + (int)Math.Pow(LastDigit, LengthOfNumber);
                number = number / 10;
            }
            if (SumToCheck == OriginalNumber)
            {
                Console.WriteLine($"{OriginalNumber} is an Armstrong number!");
            }
            else
            {
                Console.WriteLine($"{OriginalNumber} is not an Armstrong number!");
            }

        }
        
        static void FibonacciSeries()
        {
            Console.Write("Enter the n for Fibonacci sequence: ");
            int NumOfTerms = int.Parse(Console.ReadLine());
            int FirstNumber = 0, SecondNumber = 1, NextNumber;

            Console.WriteLine($"Fibonacci sequence up to {NumOfTerms} terms:");

            for (int i = 0; i < NumOfTerms; i++)
            {
                if (i <= 1)
                {
                    NextNumber = i;
                }
                else
                {
                    NextNumber = FirstNumber + SecondNumber;
                    FirstNumber = SecondNumber;
                    SecondNumber = NextNumber;
                }
                Console.Write(NextNumber + " ");
            }

            Console.WriteLine();
        }

        static void PositiveAndNegativeCount()
        {
            Console.Write("Enter no of integers you wanna check: ");
            int TotalCount = int.Parse(Console.ReadLine());

            int[] numbers = new int[TotalCount];
            int PosNumberCount = 0, NegNumberCount = 0, Sum = 0;

            Console.Write($"Enter {TotalCount} values: ");
            string[] inputValues = Console.ReadLine().Split(' ');

            for (int i = 0; i < TotalCount; i++)
            {
                numbers[i] = int.Parse(inputValues[i]);
                if (numbers[i] > 0)
                {
                    PosNumberCount++;
                }
                else if (numbers[i] < 0)
                {
                    NegNumberCount++;
                }
                Sum += numbers[i];
            }

            double average = (double)Sum / TotalCount;

            Console.WriteLine($"The no. of positive numbers: {PosNumberCount}");
            Console.WriteLine($"The no. of negative numbers: {NegNumberCount}");
            Console.WriteLine($"Sum: {Sum}");
            Console.WriteLine($"Avg of all numbers: {average}");
        }

    }
}