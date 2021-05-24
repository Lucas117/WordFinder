using System;
using System.Collections.Generic;
using System.Linq;

namespace WordFinder.Validation
{
    public class WordFinderValidations : IWordFinderValidations
    {
        public void ValidateMatrix(IEnumerable<string> matrix)
        {
            List<string> errors = new List<string>();
            errors.Add(IsMatrixGreaterThan(matrix));
            errors.Add(AnyMatrixStringHaveDifferentNumberOfCharacters(matrix));
            errors.Add(MatrixIsNotEmpty(matrix));

            if (errors.Any(error => !String.IsNullOrEmpty(error)))
            {
                String errorMsg = "|";
                errors.Where(error => !String.IsNullOrEmpty(error)).ToList().ForEach(error => errorMsg += error + "|");
                throw new Exception(errorMsg);
            }
                
        }

        private string IsMatrixGreaterThan(IEnumerable<string> matrix)
        {
            if (matrix.Count() > 64 || matrix.Any(row => row.Count() > 64))
                return "Matrix size must be less than 64";
            return "";
        }

        private string AnyMatrixStringHaveDifferentNumberOfCharacters(IEnumerable<string> matrix)
        {
            if (matrix.Any(row => matrix.Count() != row.Count()))
                return "All matrix strings must contain the same number of characters";
            return "";            
        }

        private string MatrixIsNotEmpty(IEnumerable<string> matrix)
        {
            if (matrix.Count() == 0)
                return "Matrix should not be empty";
            return "";
        }
    }
}
