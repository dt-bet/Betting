using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Betting.DAL
{

    public class ProfitRepository : ISaveLoad<Profit>
    {

        public ICollection<Profit> Load()
        {
            return new ObservableCollection<Profit>();
        }


        public void Save(ICollection<Profit> t)
        {
        }
    }

}
