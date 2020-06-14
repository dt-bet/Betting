using Betting.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Betting.DAL
{
    public class PredictionRepository : ISaveLoad<Prediction>
    {
        public ICollection<Prediction> Load()
        {
            return new ObservableCollection<Prediction>();
        }

        public void Save(ICollection<Prediction> t)
        {

        }
    }
}
