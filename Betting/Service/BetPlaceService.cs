using Betting.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Betting
{
    public class BetPlaceService
    {



        public void Execute(Bet bets, NodaMoney.Money pot, ref NodaMoney.Money amountSpent)
        {
            Helper.ExecuteBet(bets, pot, ref amountSpent);
        }


        private class Helper
        {
            //public static void ExecuteBets(Bet[] bets, NodaMoney.Money[] pot, ref NodaMoney.Money[] amountSpent)
            //{
            //    for (int i = 0; i < bets.Length; i++)
            //        ExecuteBet(bets[i], pot[i], ref amountSpent[i]);
            //}


            public static void ExecuteBet(Bet bet, NodaMoney.Money pot, ref NodaMoney.Money amountSpent)
            {
                //decimal amt = 0;


                if (bet != null)
                {
                    if (amountSpent + bet.Amount > pot * 100)
                    {
                        bet.Execution = UtilityEnum.Execution.Failure;
                        bet.Amount = 0;
                    }
                    else if (bet.Amount > 000)
                    {
                        bet.Execution = UtilityEnum.Execution.Success;
                    }

                    amountSpent = +bet.Amount;
                }

            }
        }
    }
}
