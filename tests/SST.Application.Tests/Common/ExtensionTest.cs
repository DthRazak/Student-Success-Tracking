using System;
using System.Collections.Generic;
using Shouldly;
using SST.Application.Common.Extensions;
using Xunit;

namespace SST.Application.Tests.Common
{
    public class ExtensionTest
    {
        [Fact]
        public void ShouldCreateSortedList()
        {
            var list = new List<Tuple<string, string>>
            {
                new Tuple<string, string>("Third", "!"),
                new Tuple<string, string>("Second", "World"),
                new Tuple<string, string>("First", "Hello")
            };

            var sortedList = list.ToSortedList(x => x.Item1, x => x.Item2);

            sortedList.ShouldBeOfType<SortedList<string, string>>();
        }
    }
}
