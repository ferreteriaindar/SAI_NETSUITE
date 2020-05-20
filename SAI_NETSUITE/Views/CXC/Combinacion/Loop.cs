using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAI_NETSUITE.Views.CXC.Combinacion
{
    class Loop
    {


        public List<decimal> FindCombination(List<decimal> lista, decimal objetivo)
        { // Get input
            decimal target_sum = objetivo;


            // Create lists
            List<decimal> numbers = lista;//new List<decimal>();
            List<decimal[]> output_indexes = new List<decimal[]>();
            List<decimal[]> output_numbers = new List<decimal[]>();

            Int32 combinations = (Int32)(Math.Pow(2, numbers.Count) - 1);

            for (int i = 0; i < combinations; i++)
            {
                // Create subset lists
                List<decimal> subset = new List<decimal>();
                List<decimal> subindexes = new List<decimal>();

                // Loop all numbers
                for (int j = 0; j < numbers.Count; j++)
                {
                    if (((i & (1 << j)) >> j) == 1)
                    {
                        // Add the number and the index
                        subset.Add(numbers[j]);
                        subindexes.Add(j);
                    }
                }

                // Check if the target sum has been reached
                if (subset.Sum() >= target_sum-3 && subset.Sum()<=target_sum+3)
                {
                    // Add a combination
                    output_indexes.Add(subindexes.ToArray());
                    output_numbers.Add(subset.ToArray());
                    //break;
                }
            }
            //return output_numbers.First().ToList();
            for (int i = 0; i < output_indexes.Count; i++)
            {
                Console.WriteLine(string.Join(" ", output_indexes[i]) + " (" + string.Join(" + ", output_numbers[i]) + " = " + target_sum.ToString() + ")");
            }
            if (output_numbers.Count ==1)
                Console.WriteLine("UNA COMBINACION 11111111111111111111111");
            if (output_numbers.Count > 0)
                return output_numbers[0].ToList();
            else return new List<decimal>();
        }


    }
}
