using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureProjectJamesStuart
{
    public interface IFlashcard
    {
        string Prompt { get; }
        string Answer { get; }
        Difficulty Difficulty { get;}
    }
}
