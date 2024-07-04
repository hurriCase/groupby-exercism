using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence) =>
        new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        }.Concat(sequence.GroupBy(c => c)
                .ToDictionary(
                    group => group.Key,
                    group => group.Count()))
            .GroupBy(kvp => kvp.Key)
            .ToDictionary(
                g => g.ElementAt(0).Value == 0 ? g.Key : throw new ArgumentException("error"),
                g => g.Sum(g => g.Value));

    // var expected = new Dictionary<char, int>
    // {
    //     ['A'] = 0,
    //     ['C'] = 0,
    //     ['G'] = 1,
    //     ['T'] = 0
    // };
    // Assert.Equal(expected, NucleotideCount.Count("G"));




    // {
    //     IDictionary<char, int> DNACount = new Dictionary<char, int>()
    //     {
    //         ['A'] = 0,
    //         ['C'] = 0,
    //         ['G'] = 0,
    //         ['T'] = 0,
    //     };
    //     var query = sequence.GroupBy(m => m)
    //         .Select(group => new
    //         {
    //             Character = group.Key,
    //             Count = group.Count()
    //         });
    //     foreach (var group in query)
    //     {
    //         if (group.Character is ('A' or 'C' or 'G' or 'T'))
    //         {
    //             DNACount[group.Character] = group.Count; 
    //         }
    //         else throw new ArgumentException();
    //     }
    //     
    //     return DNACount;
    // }
    // {
    //     IDictionary<char, int> DNACount = new Dictionary<char, int>()
    //     {
    //         ['A'] = 0,
    //         ['C'] = 0,
    //         ['G'] = 0,
    //         ['T'] = 0,
    //     };
    //     var query = sequence.GroupBy(m => m)
    //         .Select(group => new
    //         {
    //             Character = group.Key,
    //             Count = group.Count()
    //         });
    //     
    //     foreach (var group in query)
    //     {
    //         if (!DNACount.ContainsKey(group.Character))
    //         {
    //             throw new ArgumentException();
    //         }
    //         DNACount[group.Character] = group.Count;
    //     }
    //
    //     return DNACount;
    // }






    // sequence.Count(s => s != 'A' && s != 'C' && s != 'G' && s != 'T') == 0 ? 
    //     new Dictionary<char, int>()
    //     {
    //         ['A'] = sequence.Count(s => s == 'A'),
    //         ['C'] = sequence.Count(s => s == 'C'),
    //         ['G'] = sequence.Count(s => s == 'G'),
    //         ['T'] = sequence.Count(s => s == 'T'),
    //     } 
    //     : throw new ArgumentException("error");
}