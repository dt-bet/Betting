using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Model
{
    public class Position
    {
        public string Key { get; set; }
        public decimal Total { get; }
        public decimal Bought { get; }
        public decimal Sold { get; }

    }
}
