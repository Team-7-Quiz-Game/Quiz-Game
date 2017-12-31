using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trivia.Common.Utils
{
    public static class IdGenerator
    {
        private static int id;

        public static int GetId => ++id;
    }
}
