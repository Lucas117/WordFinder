using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WordFinder.Strategy
{
    public interface ILookUp
    {
        bool MatchNextChar(char[,] matrixResult, int indexX, int indexY, string target);
    }
}
