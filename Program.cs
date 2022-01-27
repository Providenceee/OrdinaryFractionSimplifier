using System;
using System.Linq;

namespace Project
{
    public class OrdinaryFractionSimplifier
    {
        public OrdinaryFractionSimplifier()
        {
            Loop();
        }
        private void Loop()
        {
            string input;
            while (true)
            {
                Console.WriteLine("Type the ordinary fraction to simplify, or nothing to exit:");
                input = Console.ReadLine();
                if (input == "")
                {
                    break;
                }
                Console.WriteLine("Simplified fraction:");
                Console.WriteLine(Simplify(input));
            }
        }
        public static string Simplify(string ordFraction)
        {
            int[] nums = ordFraction.Split("/").Select(c => int.Parse(c)).ToArray();
            if (nums.Length != 2)
            {
                throw new ArgumentException("Invalid ordinary fraction, use a/b template.");
            }
            if (nums[0] % nums[1] == 0)
            {
                return $"{nums[0] / nums[1]}";
            }
            for (int i = nums[0]; i > 1; i--)
            {
                if (nums[0] % i == 0 && nums[1] % i == 0)
                {
                    ordFraction = Simplify($"{nums[0] / i}/{nums[1] / i}");
                }
            }
            return ordFraction;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            OrdinaryFractionSimplifier OFS = new OrdinaryFractionSimplifier();
        }
    }
}
