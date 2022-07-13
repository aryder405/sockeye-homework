using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChallengeService
{
    public interface IProcessStrings
    {
        IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input);
    }
}
