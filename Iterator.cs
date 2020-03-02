using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    interface Iterator
    {
        bool HasNext();
        string MoveNext();
    }
}
