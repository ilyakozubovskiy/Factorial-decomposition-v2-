using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Numerics;

class FactDecomp
{
    private static Dictionary<int, int> ValueDegreeCollection = new Dictionary<int, int>();
    private static List<int> primeFactors = new List<int>();

    public static string Decomp(int n)
    {
        primeFactors = GetPrimeFactors(Fact(n));
        primeFactors = DistinctPrimeFactors();

        return DecompositePrimeFactorsToString();
    }
    private static List<int> GetPrimeFactors(BigInteger n)
    {
        List<int> primeFactors = new List<int>();
        int count = 2;

        while (n > 1)
        {
            if (n % count == 0)
            {
                primeFactors.Add(count);
                n /= count;
            }
            else
                count++;
        }
        return primeFactors;
    }
    private static BigInteger Fact(BigInteger n)
    {
        BigInteger fact = BigInteger.One;
        for (int i = 2; i <= n; i++)
            fact *= i;
        return fact;
    }

    private static string DecompositePrimeFactorsToString()
    {
        StringBuilder decompositionResult = new StringBuilder();

        for (int i = 0; i < primeFactors.Count; i++)
        {
            if (i != 0)
                decompositionResult.Append(" * ");

            if (ValueDegreeCollection[primeFactors[i]] > 1)
                decompositionResult.Append(primeFactors[i] + "^" + ValueDegreeCollection[primeFactors[i]]);
            else
                decompositionResult.Append(primeFactors[i]);
        }
        ValueDegreeCollection.Clear();

        return decompositionResult.ToString();
    }

    private static void AddItemsInValueDegreeCollection()
    {
        foreach (var item in primeFactors)
            if (!ValueDegreeCollection.ContainsKey(item))
                ValueDegreeCollection.Add(item, primeFactors.Count(x => x == item));
    }

    private static List<int> DistinctPrimeFactors() => primeFactors.Select(i => i).Distinct().ToList();

}