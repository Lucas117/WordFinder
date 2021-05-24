using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WordFinder.Models
{
    public class WordFinderModel
    {
        public IEnumerable<string> Matrix { get; set; }
        public IEnumerable<string> Wordstream { get; set; }
    }
}
