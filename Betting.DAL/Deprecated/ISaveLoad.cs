using System;
using System.Collections.Generic;
using System.Text;

namespace Betting.DAL
{
    public interface ISaveLoad<T>
    {
        void Save(ICollection<T> t);

        ICollection<T> Load();
    }
}
