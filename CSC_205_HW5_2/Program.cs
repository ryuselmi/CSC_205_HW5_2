using System;
using System.IO;
using System.Diagnostics;

namespace CSC_205_HW5_2
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileName = "numbers.txt";
            Stopwatch stopwatch = new Stopwatch();
            Method01(fileName, 1000, 1, 1001);
            string[] lines = File.ReadAllLines(fileName);
            int[] values = new int[lines.Length];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = Convert.ToInt32(lines[i]);
            }
            stopwatch.Start();
            Console.WriteLine("starting ... ");
            Method02(values);
            Console.WriteLine("done! ... ");
            stopwatch.Stop();
            Console.WriteLine("time measured: {0} ms", stopwatch.ElapsedMilliseconds);
            foreach (int value in values)
                Console.Write(value + " ");
            Console.WriteLine();
        }

        static void Method01(string fileName, int total, int lowerRange, int upperRange)
        {
            // Create a StreamWriter to write to the specified file
            using (var writer = new StreamWriter(fileName))
            {
                Random r = new Random(); // Initialize a random number generator
                int number = 0;
                {
                    // Loop to generate 'total - 1' random numbers
                    for (int i = 1; i < total; i++)
                    {
                        // Generate a random number between lowerRange (inclusive) and upperRange (exclusive)
                        number = r.Next(lowerRange, upperRange);
                        // Write the generated number to the file
                        writer.WriteLine(number);
                    }
                }
            }
        }


        static void Method02(int[] arr)
        {
            // Loop through each element in the array except the last one
            for (int start = 0; start < arr.Length - 1; start++)
            {
                int posMin = start; // Assume the current element is the minimum

                // Loop through the remaining elements to find the actual minimum
                for (int i = start + 1; i < arr.Length; i++)
                {
                    // Update posMin if a smaller element is found
                    if (arr[i] < arr[posMin])
                    {
                        posMin = i;
                    }
                }

                // Swap the minimum element with the current element
                int tmp = arr[start];
                arr[start] = arr[posMin];
                arr[posMin] = tmp;
            }
        }
    }
}


//1. Method01 is responsible for generating a file called numbers.txt filled with random integers

// 2. Method02 implements a selection sort algorithm to sort an array of integers in ascending order.
// It repeatedly finds the minimum element from the unsorted part of the array and swaps it with
// the first unsorted element, thus growing the sorted portion of the array one element at a time.

//3. This code reads all the lines from the numbers.txt file into a string array
//(lines). It then creates an integer array (values) of the same length as the
//lines array. The for loop iterates through each line in the lines array,
//converts the string representation of the number to an integer, and stores
//it in the corresponding position in the values array. Essentially, this code
//reads the random numbers from the file and converts them from strings to integers
//for further processing.

// C:\Users\Yuselmi\source\repos\CSC_205_HW5_2\CSC_205_HW5_2\bin\Debug\net8.0\CSC_205_HW5_2.exe