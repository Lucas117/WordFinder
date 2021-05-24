using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Strategy
{
    public class LeftToRightLookUp : ILookUp
    {
        public bool MatchNextChar(char[,] matrixResult, int indexX, int indexY, string target)
        {
             return MatchNext(matrixResult, indexX+1, indexY, target, 1);
        }

        private bool MatchNext(char[,] matrixResult, int indexX, int indexY, string target, int targetIndex)
        {
            if (indexX < matrixResult.GetLength(1) && matrixResult[indexY, indexX].Equals(target[targetIndex]))
            {
                if (target.Length == targetIndex + 1)
                    return true;
                return MatchNext(matrixResult, indexX+1, indexY, target, targetIndex+1);
            }

            return false;
        }
    }
}
