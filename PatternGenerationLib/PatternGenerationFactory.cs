using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternGenerationLib
{
    public static class PatternGenerationFactory
    {
        public static IPatternGenerator CreatePhyllotaxis()
        {
            return new Phyllotaxis();
        }
        public static IPatternGenerator CreateSpirograph()
        {
            return new Spirograph();
        }
    }
}
