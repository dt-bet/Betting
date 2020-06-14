using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.Model
{
    public class Profit
    {
        public DateTime Date { get; set; }

        public NodaMoney.Money Amount { get; set; }
    }
}
