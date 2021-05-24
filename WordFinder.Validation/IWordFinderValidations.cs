using System;
using System.Collections.Generic;
using System.Text;

namespace WordFinder.Validation
{
    public interface IWordFinderValidations
    {
        void ValidateMatrix(IEnumerable<string> matrix);
    }
}
