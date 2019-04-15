using System;
using System.Collections.Generic;
using System.Text;

namespace SortBlocks
{
    public class Block
    {
        public string From { get; set; }
        public string To { get; set; }

        public Block() { }

        public Block(string from, string to)
        {
            this.From = from;
            this.To = to;
        }

        public override string ToString()
        {
            return $"{From} -> {To}";
        }
    }
}
