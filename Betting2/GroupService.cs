using Betting.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using UtilityInterface.NonGeneric;

namespace Betting.A
{
   public abstract class  GroupService:IGroupService, IName
    {
        private readonly IModel model;

        public GroupService(IModel model)
        {
            this.model = model;
        }

        public string Name => model.Name;

        public abstract IAsyncEnumerable<(string key, IProfit[] profits, IOdd[] odds)> Group();

    }
}
