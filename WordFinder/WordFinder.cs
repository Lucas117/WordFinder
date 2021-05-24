using System;
using System.Collections.Generic;
using System.Linq;
using WordFinder.Strategy;
using WordFinder.Utils;

namespace WordFinder
{
    public class WordFinder
    {

        private IList<ILookUp> LookUpStrategies { get; set; } = new List<ILookUp>();
        private char[,] Matrix2D { get; set; }

        public WordFinder(IEnumerable<string> matrix)
        {           
            this.Matrix2D = EnumerableExtensions.To2DArray(matrix);
            
            this.LookUpStrategies.Add(new TopToBottomLookUp());
            this.LookUpStrategies.Add(new LeftToRightLookUp());
        }

        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {   
            return wordstream
               .GroupBy(word => word, (key, result) => new{
                   Word = key,
                   Count = result.Count()
               })
               .AsParallel()
               .Select(group =>  new {
                       group.Word,
                       group.Count,
                       Found = FindByWord(group.Word)
               })
               .Where(x => x.Found).OrderByDescending(x => x.Count)
               .Select(x => x.Word)
               .Take(10);
        }

        private bool FindByWord(string word)
        {            
            for (int indexY = 0; indexY < this.Matrix2D.GetLength(0); indexY++)
            {
                for (int indexX = 0; indexX < this.Matrix2D.GetLength(1); indexX++)
                {
                    if ( String.Equals(this.Matrix2D[indexY, indexX], word[0])
                        && this.LookUpStrategies
                            .AsParallel()
                            .Any(strategy => strategy.MatchNextChar(this.Matrix2D, indexX, indexY, word)))
                        return true;
                    
                }
            }
            
            return false;
        }        
    }
}
