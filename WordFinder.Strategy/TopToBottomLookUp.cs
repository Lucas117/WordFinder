using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Strategy
{
    public class TopToBottomLookUp : ILookUp
    {
        public bool MatchNextChar(char[,] matrixResult, int indexX, int indexY, string target)
        {           
            return MatchNext(matrixResult, indexX, indexY+1, target, 1);                
        }

        private bool MatchNext(char[,] matrixResult, int indexX, int indexY, string target, int targetIndex)
        {
            if (indexY < matrixResult.GetLength(0) && Char.Equals(matrixResult[indexY, indexX], target[targetIndex]))
            {
                if (target.Length == targetIndex + 1)
                    return true;
                return MatchNext(matrixResult, indexX, indexY+1, target, targetIndex+1);
            }

            return false;               
        }
    }
}
