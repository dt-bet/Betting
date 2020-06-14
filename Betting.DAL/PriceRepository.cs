using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Betting.DAL
{
    public class PriceRepository : ISaveLoad<Price>
    {
        public ICollection<Price> Load()
        {
            return new ObservableCollection<Price>();
        }

        public void Save(ICollection<Price> t)
        {

        }
    }

}
