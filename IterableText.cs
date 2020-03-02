using System;
using System.Collections.Generic;
using System.Text;

namespace TextAnalyser
{
    interface IterableText
    {
        Iterator CharIterator();
        Iterator WordIterator();
    }
}
