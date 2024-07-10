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
            LargestAndSecondLargest();
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
            int[] A = { 2, 3, 4, 5, 6, 9 ,0};
            Console.Write("The array is: ");
            foreach (int element in A)
            {
                Console.Write(element);
                Console.Write(" ");              
            }
            Console.WriteLine();

            int Largest = 0;

            for (int i = 1; i < A.Length; i++) 
            {
                if (A[i] > Largest) 
                {
                    Largest = A[i];
                }
            }
            Console.WriteLine($"The Largest Number in Array is: {Largest}");
            int[] newArray = new int[A.Length-1];
            foreach (int element in A)
            {
                if (element != Largest)
                {
                    newArray[] = element;
                }
            }
            foreach (int element in newArray)
            {
                Console.Write(element);
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        

        static void ZerosAtEnd()
        {
            int[] ZerosArray = { 2, 0, 5, 0, 0, 0, 3 };        
            List<int> NoZerosList = new List<int>(); 
            int CountZero = 0;

            
            foreach(int element in ZerosArray) //loop to count zeros in array
            {
                if (element == 0) 
                {
                    CountZero++;                   
                }                               
            }          

            foreach(int element in ZerosArray) //loop to add all non-zero elements first
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
    }
}
