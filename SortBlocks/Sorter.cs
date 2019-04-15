using System;
using System.Collections.Generic;
using System.Linq;

namespace SortBlocks
{
    public static class Sorter
    {
        public static List<Block> Sort(List<Block> blocks)
        {
            if(blocks == null)
            {
                throw new NullReferenceException("collection is null");
            }

            if(blocks.Count == 0)
            {
                return blocks;
            }

            var unsortBlocks = blocks.ToList();
            var sortBlocks = new List<Block>();

            var block = unsortBlocks.First();

            bool reverse = false;

            while(block != null)
            {
                if (string.IsNullOrWhiteSpace(block.From) || string.IsNullOrWhiteSpace(block.To))
                {
                    throw new ArgumentException();
                }

                unsortBlocks.Remove(block);

                try
                {
                    if (reverse)
                    {
                        sortBlocks.Insert(0, block);
                        block = unsortBlocks.SingleOrDefault(b => b.To == sortBlocks.First().From);
                    }
                    else
                    {
                        sortBlocks.Add(block);
                        block = unsortBlocks.SingleOrDefault(b => b.From == sortBlocks.Last().To);
                    }

                    if (!reverse && (block == null))
                    {
                        reverse = true;
                        block = unsortBlocks.SingleOrDefault(b => b.To == sortBlocks.First().From);
                    }
                }
                catch (InvalidOperationException ex)
                {
                    throw new InvalidOperationException($"some blocks has the same members as {sortBlocks.First().From}", ex);
                }
            }

            if(sortBlocks.Count != blocks.Count)
            {
                throw new Exception("can't sort this blocks collection");
            }

            return sortBlocks;
        }
    }
}
