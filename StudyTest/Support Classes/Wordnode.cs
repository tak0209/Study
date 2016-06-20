using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyTest
{
    public class WordNode
    {
        public String word;
        public int numSteps;

        public WordNode(String word, int numSteps)
        {
            this.word = word;
            this.numSteps = numSteps;
        }
    }
}
