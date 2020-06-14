using System.Collections.Generic;
using Betting;
using Betting.Model;
using UtilityReactive;

namespace BettingSystem.DemoApp
{
    class Class1
    {

        public void sdf()
        {
            ICollection<Profit> profits = new List<Profit>();
            ICollection<Prediction> predictions = new List<Prediction>();
            ICollection<Price> prices = new List<Price>();
            ICollection<Recommendation> recommendations = new List<Recommendation>();
            ICollection<Balance> balances = new List<Balance>();
            CollectionObserver<Profit> profitObserver = new CollectionObserver<Profit>(profits);
            CollectionObserver<Prediction> predictionsObserver = new CollectionObserver<Prediction>(predictions);
            CollectionObserver<Price> priceObserver = new CollectionObserver<Price>(prices);
            CollectionObserver<Recommendation> recommendationObserver = new CollectionObserver<Recommendation>(recommendations);
            CollectionObserver<Balance> balanceObserver = new CollectionObserver<Balance>(balances);


            var ps = new ProfitService();

            

            var rs = new RecommendationService(predictions, prices);

            var betService = new BetService();

            rs.Subscribe(betService);
            rs.Subscribe(recommendationObserver);
            ps.Subscribe(profitObserver);



        }



    }



}
