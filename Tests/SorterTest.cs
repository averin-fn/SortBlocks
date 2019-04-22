using SortBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Tests
{
    public class SorterTest
    {
        [Fact]
        public void Normal_Correct_Blocks_Collection()
        {
            var unsortBlocks = new List<Block>
            {
                new Block("Южнопортовый", "Печатники"),
                new Block("Текстильщики", "Нижегородский"),
                new Block("Печатники", "Текстильщики")
            };

            var sortBlocks = Sorter.Sort(unsortBlocks).ToList();

            for (int i = 0; i < sortBlocks.Count; i++)
            {
                if (i != sortBlocks.Count - 1)
                {
                    Assert.True(sortBlocks[i].To == sortBlocks[i + 1].From,
                        $"{sortBlocks[i].To} != {sortBlocks[i + 1].From}");
                }
            }
        }

        [Fact]
        public void Reverse_Correct_Blocks_Collection()
        {
            var unsortBlocks = new List<Block>
            {
                new Block("Южнопортовый", "Печатники"),
                new Block("Текстильщики", "Нижегородский"),
                new Block("Печатники", "Текстильщики"),
                new Block("Нижегородский", "Южнопортовый"),
            };

            var sortBlocks = Sorter.Sort(unsortBlocks).ToList();

            for (int i = 0; i < sortBlocks.Count; i++)
            {
                if (i != sortBlocks.Count - 1)
                {
                    Assert.True(sortBlocks[i].To == sortBlocks[i + 1].From,
                        $"{sortBlocks[i].To} != {sortBlocks[i + 1].From}");
                }
            }
        }

        [Fact]
        public void Blocks_Collection_With_Duplicate()
        {
            var unsortBlocks = new List<Block>
            {
                new Block("Южнопортовый", "Печатники"),
                new Block("Текстильщики", "Нижегородский"),
                new Block("Печатники", "Текстильщики"),
                new Block("Печатники", "Текстильщики"),
                new Block("Нижегородский", "Южнопортовый"),
            };

            var exType = typeof(InvalidOperationException);

            Assert.Throws(exType, () => Sorter.Sort(unsortBlocks));            
        }

        [Fact]
        public void Incorrect_Blocks_Collection()
        {
            var unsortBlocks = new List<Block>
            {
                new Block("Южнопортовый", "Печатники"),
                new Block("Текстильщики", "Нижегородский"),
                new Block("Печатники", ""),
                new Block(),
            };

            var exType = typeof(ArgumentException);

            Assert.Throws(exType, () => Sorter.Sort(unsortBlocks));
        }

        [Fact]
        public void Incoherent_Blocks_Collection()
        {
            var unsortBlocks = new List<Block>
            {
                new Block("Южнопортовый", "Печатники"),
                new Block("Нижегородский", "Текстильщики"),
                new Block("Печатники", "Текстильщики"),
            };

            var exType = typeof(Exception);

            Assert.Throws(exType, () => Sorter.Sort(unsortBlocks));
        }

        [Fact]
        public void Null_Blocks_Collection()
        {
            List<Block> unsortBlocks = null;
            var exType = typeof(ArgumentNullException);

            Assert.Throws(exType, () => Sorter.Sort(unsortBlocks));
        }

        [Fact]
        public void Empty_Blocks_Collection()
        {
            List<Block> unsortBlocks = new List<Block>();

            var sortBlocks = Sorter.Sort(unsortBlocks);

            Assert.Equal(unsortBlocks, sortBlocks);
        }
    }
}
