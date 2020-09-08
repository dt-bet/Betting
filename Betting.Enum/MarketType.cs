

using System.ComponentModel;
using UtilityEnum;

namespace Betting.Enum
{
    //Order affects databases
    public enum MarketType : byte
    {
        None,
        [Names("1", "HalfTimeResult", "half-time-result")]
        HalfTimeResult = 1,

        [Names("ou")]
        //[Names("Over Under")]
        OverUnder,
        //[Names("Asian Handicap")]
        [Names("ah")]
        AsianHandicap,

        [Names("dc", "DoubleChance")]
        DoubleChance,


        [Names("dnb", "DrawNoBet", "draw-no-bet")]
        DrawNoBet,

        //[Names("Both Teams To Score")]
        [Names("bts", "BTTS", "BothTeamsToScore", "both-teams-score")]
        BTTS,

        [Names("HalfTimeFullTime")]
        HTFT,

        [Names("correct-score")]
        CorrectScore,
        [Names("half-time-score")]
        HalfTimeScore,
        [Names("over-under-12.5")]
        OU125,
        [Names("over-under-11.5")]
        OU115,
        [Names("over-under-10.5")]
        OU105,
        [Names("over-under-9.5")]
        OU95,
        [Names("over-under-8.5")]
        OU85,
        [Names("over-under-7.5")]
        OU75,
        [Names("over-under-6.5")]
        OU65,
        [Names("over-under-5.5")]
        OU55,
        [Names("over-under-3.5")]
        OU35,

        [Names("over-under-2.5")]
        OU25,

        [Names("over-under-4.5")]
        OU45,

        [Names("over-under-1.5")]
        OU15,

        [Names("over-under-0.5")]
        OU05,

        [Names("half-full")]
        HalfFull,

        //[Description("1X2 Odds")]
        [Names("1x2", "FullTimeResult", "winner")]
        FullTimeResult,
    }
}
