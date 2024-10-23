using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCC_HomeWork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int[] array = { 25, 30, 45, 25, 75, 50, 45, 30, 70, 75, 25, 50 };
                Dictionary<int, int> frequency = CalculateFrequencyRecursive(array, 25, 75);
                foreach (var item in frequency)
                {
                    Console.WriteLine($"Value: {item.Key}, Frequency: {item.Value}");
                }

                Dictionary<int, int> numberCount = new Dictionary<int, int>();
                foreach (int number in array)
                {
                    if (numberCount.ContainsKey(number))
                    {
                        numberCount[number]++;
                    }
                    else
                    {
                        numberCount[number] = 1;
                    }
                }

                foreach (KeyValuePair<int, int> entry in numberCount)
                {
                    Console.WriteLine($"Number {entry.Key} occurred {entry.Value} times.");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        static Dictionary<int, int> CalculateFrequencyRecursive(int[] array, int start, int end, int index = 0, Dictionary<int, int> frequency = null)
        {
            if (frequency == null)
            {
                frequency = new Dictionary<int, int>();
            }
            if (index >= array.Length)
            {
                return frequency;
            }

            int value = array[index];

            if (value < start || value > end)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"The value {value} is out of the specified range {start} to {end}.");
            }

            if (frequency.ContainsKey(value))
            {
                frequency[value]++;
            }
            else
            {
                frequency[value] = 1;
            }

            return CalculateFrequencyRecursive(array, start, end, index + 1, frequency);
        }
    }

}
