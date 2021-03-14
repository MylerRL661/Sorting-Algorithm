using System;
using System.IO;
using System.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//15614035 - Myles Leslie
//Algorithms and Complexity Assessment 2 Code

namespace CMP1124M_Assessment2
{
    class Program
    {
        static void Main(string[] args)
        {//main method asking which files to search and sort
            Console.WriteLine("Which file would you like to search and sort?");
            //options
            Console.WriteLine("Press 1 for Close\nPress 2 for Change\nPress 3 for Open\nPress 4 for High\nPress 5 for Low");
            string choice = Console.ReadLine();
            string filename;

            //switch statement for choosing the type of file
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Close file selected");
                    filename = "Close";
                    FileSize(filename);
                    break;
                case "2":
                    Console.WriteLine("Change file selected");
                    filename = "Change";
                    FileSize(filename);
                    break;
                case "3":
                    Console.WriteLine("Open file selected");
                    filename = "Open";
                    FileSize(filename);
                    break;
                case "4":
                    Console.WriteLine("High file selected");
                    filename = "High";
                    FileSize(filename);
                    break;
                case "5":
                    Console.WriteLine("Low file selected");
                    filename = "Low";
                    FileSize(filename);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }

        public static void FileSize(string filename)
        {//allows the file size to be chosen
            //asks the user which file size they wold like to search and sort
            Console.WriteLine("Which file size would you like to search and sort?");
            //options
            Console.WriteLine("Press 1 for 128\nPress 2 for 256\nPress 3 for 1024");
            string choice = Console.ReadLine();

            //switch statement for which file size selected
            switch (choice)
            {
                case "1":
                    Console.WriteLine("128 selected");
                    filename = filename + "_128";
                    ReadFile(filename);
                    break;
                case "2":
                    Console.WriteLine("256 selected");
                    filename = filename + "_256";
                    ReadFile(filename);
                    break;
                case "3":
                    Console.WriteLine("1024 selected");
                    filename = filename + "_1024";
                    ReadFile(filename);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }

        public static void ReadFile(string filename)
        {//allows the files to be read into the program and arrays
            //converts the string array into a float array
            string[] bankstring = File.ReadAllLines(filename + ".txt");
            float[] bankarray = new float[bankstring.Length];
            int i = 0;

            foreach (var line in bankstring)
            {
                bankarray[i] = float.Parse(line);
                i++;
            }

            //asks for ascending or descending oder of the data
            Console.WriteLine("Would you like to sort in either (1)ascending or (2)descending?");
            int answer = int.Parse(Console.ReadLine());

            //passes through to be sorted
            bankarray = SortFiles(bankarray, answer);

            Console.WriteLine("Contents of " + filename + " = ");
            foreach (var item in bankarray)
            {
                Console.WriteLine("\t" + item);
            }

            //passes through to search for the number
            SearchFiles(bankarray, answer);

            Console.ReadLine();
        }

        public static float[] SortFiles(float[] bankarray, int answer)
        {//allows the user to sort the files chosen
            //asks the user which sorting alorithm they would like to use
            Console.WriteLine("Which sort would you like to use?");
            //options
            Console.WriteLine("Press 1 for BubbleSort\nPress 2 for QuickSort\nPress 3 for InsertionSort");
            string choice = Console.ReadLine();

            //switch statement allowing the user to select a sorting algorithm
            switch (choice)
            {
                case "1":
                    Console.WriteLine("Bubblesort selected");
                    bankarray = BubbleSort(bankarray, bankarray.Length, answer);
                    break;
                case "2":
                    Console.WriteLine("QuickSort selected");
                    bankarray = QuickSort(bankarray, 0, bankarray.Length - 1, answer);
                    break;
                case "3":
                    Console.WriteLine("InsertionSort selected");
                    bankarray = InsertionSort(bankarray, bankarray.Length - 1, answer); 
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
            return bankarray;
        }

        public static void SearchFiles(float[] bankarray, int answer)
        { //allows the files to be searched
            //user enters their desired number
            Console.WriteLine("What number are you searching for?");
            float number = float.Parse(Console.ReadLine());
            //clears previous menu options
            Console.Clear();
            //asks which searching algorithm the user would like to use
            Console.WriteLine("How would you like to search the files?");
            //options
            Console.WriteLine("Press 1 for BinarySearch\nPress 2 for LinearSearch");
            string choice = Console.ReadLine();

            //switch statement for choosing which searching method to use
            switch (choice)
            {
                case "1":
                    Console.WriteLine("BinarySearch selected");
                    BinarySearch(bankarray, number, answer);
                    break;
                case "2":
                    Console.WriteLine("LinearSearch selected");
                    LinearSearch(bankarray, number, answer);
                    break;
                default:
                    Console.WriteLine("Please enter a valid input");
                    break;
            }
        }

        public static float[] BubbleSort(float[] bankarray, int n, int answer)
        {//bubble sort for the program
            //int counter = 0;

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 1 - i; j++)
                {
                    //if the user wants the numbers ascended
                    if (answer == 1)
                    {
                        if (bankarray[j + 1] < bankarray[j])
                        {
                            float temp = bankarray[j];
                            bankarray[j] = bankarray[j + 1];
                            bankarray[j + 1] = temp;
                        }
                        //counter to find how many steps the algorithm goes through
                        //counter++;
                        //Console.WriteLine("Count is " + counter);
                    }
                    //if the user wants the numbers descended
                    else
                    {
                        if (bankarray[j + 1] > bankarray[j])
                        {
                            float temp = bankarray[j];
                            bankarray[j] = bankarray[j + 1];
                            bankarray[j + 1] = temp;
                        }
                        //counter to find how many steps the algorithm goes through
                        //counter++;
                        //Console.WriteLine("Count is " + counter);
                    }
                }
            }
            return bankarray;
        }

        public static float[] QuickSort(float[] bankarray, int L, int R, int answer)
        {//quick sort sorting method for the program
            //declaration of variables
            int i, j, pivot;
            float temp;
            //int counter = 0;

            //finds very most left and right values and each pivot
            if (L < R)
            {
                pivot = L;
                i = L;
                j = R;

                while (i < j)
                {
                    //if the user wants the numbers ascended
                    if (answer == 1)
                    {
                        while (bankarray[i] <= bankarray[pivot] && i < R)
                            i++;
                        while (bankarray[j] > bankarray[pivot])
                            j--;
                    }
                    
                    //if the user wants the numbers descended
                    else
                    {
                        while (bankarray[i] >= bankarray[pivot] && i < R)
                            i++;
                        while (bankarray[j] < bankarray[pivot])
                            j--;
                    }
                    if (i < j)
                    {
                        temp = bankarray[i];
                        bankarray[i] = bankarray[j];
                        bankarray[j] = temp;
                    }
                }
                

                temp = bankarray[pivot];
                bankarray[pivot] = bankarray[j];
                bankarray[j] = temp;
                QuickSort(bankarray, L, j - 1, answer);
                QuickSort(bankarray, j + 1, R, answer);

                
            }
            // used to check the count of steps for the report
            //counter++;
            //Console.WriteLine("Count is " + counter);
            return bankarray;
        }

        public static float[] InsertionSort(float[] bankarray, int n, int answer)
        {//insertion sort array
            //declaration of variables
            int numsorted = 0;
            int i;
            //int counter = 0;

            while (numsorted < n)
            {
                float temp = bankarray[numsorted];
                for (i = numsorted; i > 0; i--)
                {
                    if (answer == 1)
                    {//if the user chose ascending order
                        if (temp < bankarray[i - 1])
                        {
                            bankarray[i] = bankarray[i - 1];
                        }
                        else
                        {
                            break;
                        }
                        //counter to find how many steps the algorithm goes through
                        //counter++;
                        //Console.WriteLine("Count is " + counter);
                    }
                    else
                    {
                        if (temp > bankarray[i - 1])
                        {
                            bankarray[i] = bankarray[i - 1];
                        }
                        else
                        {
                            break;
                        }
                    }   
                }
                bankarray[i] = temp;
                numsorted++;
            }
            return bankarray;
        }

        public static void BinarySearch(float[]bankarray, float number, int answer)
        {//binary search for the program
            //declaration of variables
            int L;
            int midpoint = 0;
            int R;
            L = 0;
            R = bankarray.Length - 1;

            //int counter = 0;

            if (answer == 1)
            { //if sorted in ascending order
                while (L <= R)
                {
                    midpoint = (L + R) / 2;
                    if (number == bankarray[midpoint])
                    {
                        //search for the location of the users dsired number in the array
                        for (; L <= R; L++)
                        {
                            if (bankarray[L] == number)
                            {
                                Console.WriteLine(L);
                            }
                        }
                        Console.WriteLine("These are the location(s) of your number");
                        return;   
                    }
                    else if (number > bankarray[midpoint])
                    {
                        L = midpoint + 1;
                    }
                    else
                    {
                        R = midpoint - 1;
                    }
                    //counter to find how many steps the algorithm goes through
                    //counter++;
                    //Console.WriteLine("Count is " + counter);
                }
            }
            else //if sorted in descending order 
            {
                while (L <= R)
                {
                    midpoint = (L + R) / 2;
                    if (number == bankarray[midpoint])
                    {
                        //searches for the location of the users desired number
                        for (; L <= R; L++)
                        {
                            if (bankarray[L] == number)
                            {
                                Console.WriteLine(L);
                            }
                        }
                        Console.WriteLine("These are the location(s) of your number");
                        return;
                    }
                    else if (number < bankarray[midpoint])
                    {
                        L = midpoint + 1;
                    }
                    else
                    {
                        R = midpoint - 1;
                    }
                }
            }
            //if the number can't be found this searches for the locations of the number closest to it
            if (number != bankarray[midpoint]) 
            {
                Console.WriteLine(bankarray[midpoint] + " is the closest value to your number");
                BinarySearch(bankarray, bankarray[midpoint], answer);
            }
        }

        public static void LinearSearch(float[] bankarray, float number, int answer)
        { //linear search function for the program
            //declaration of variables
            int L;
            int R;
            L = 0;
            R = bankarray.Length - 1;
            //int counter = 0;

            //if sorted in ascending order
            if(answer == 1)
            {
                for (; L <= R; L++)
                {
                    if (bankarray[L] == number)
                    {
                        Console.WriteLine(L);
                    }
                    //counter to find how many steps the algorithm goes through
                    //counter++;
                    //Console.WriteLine("Count is " + counter);
                }
                Console.WriteLine("These are the location(s) of your number");
                return;
            }
            else //if sorted in descending order
            {
                for (; R >= L; L++)
                {
                    if (bankarray[L] == number)
                    {
                        Console.WriteLine(L);
                    }
                }
                Console.WriteLine("These are the location(s) of your number");
                return;
            }
            //if the number can't be found in the array/ unreachable code
            //if (number != bankarray[L])
            //{
            //    Console.WriteLine("Number not found");
            //    return;
            //}
        }
    }
}

    

