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
            int[] Array1 = {1, 3, 5, 7};
            int[] Array2 = {2, 4, 6, 8};
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

            while (IndexArray2< Array2.Length) // when length of Array1 is smaller than Array2 and Array2 still has elements in it
            {
                SortedMergedArray[IndexNewArray] = Array2[IndexArray2];
                IndexNewArray++;
                IndexArray2++;
            }
            Console.WriteLine("Merged Array: " + string.Join(", ", SortedMergedArray));
        }






    }
}