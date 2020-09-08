

using System.ComponentModel;

using UtilityEnum;


namespace Betting.Enum
{
    public enum PriceSource : short
    {
        None,
        [Names("10Bet")]
        TenBet = 1,
        [Names("1xBet")]
        OnexBet,
        [Names("888sport")]
        EightEightEightsport,
        [Names("bet365", "B365")]
        Bet365,
        [Names("Betting")]
        Betting,
        [Names("Betway")]
        Betway,
        //formally "Bet & Win"
        [Names("bwin", "BW")]
        Bwin,
        [Names("ComeOn")]
        ComeOn,
        [Names("Paddy Power")]
        PaddyPower,
        [Names("Sportingbet", "SB")]
        Sportingbet,
        [Names("Unibet")]
        Unibet,
        [Names("youwin")]
        Youwin,
        [Names("William Hill", "WH")]
        WilliamHill,
        [Names("188BET")]
        OneEightEightBet,
        [Names("bet-at-home")]
        betathome,
        [Names("12BET")]
        TwelveBET,
        [Names("Betclic")]
        Betclic,
        [Names("Betsafe")]
        Betsafe,
        [Names("Betsson")]
        Betsson,
        [Names("BetVictor", "VC")]
        BetVictor,
        [Names("Interwetten", "IW")]
        Interwetten,
        [Names("SBOBET")]
        SBOBET,
        [Names("Betting Exchange")]
        BettingExchange,
        [Names("5Dimes")]
        FiveDimes,
        [Names("AsianOdds")]
        AsianOdds,
        [Names("Bethard")]
        Bethard,
        [Names("BetOlimp")]
        BetOlimp,
        [Names("Pinnacle", "P", "PS")]
        Pinnacle,
        [Names("1xStavka")]
        OnexStavka,
        [Names("22Bet")]
        TwentyTwoBet,
        [Names("Babibet")]
        Babibet,
        [Names("Betcruise")]
        Betcruise,
        [Names("BoyleSports")]
        BoyleSports,
        [Names("Coolbet")]
        Coolbet,
        [Names("Dafabet")]
        Dafabet,
        [Names("eFortuna.pl")]
        eFortunapl,
        [Names("Expekt")]
        Expekt,
        [Names("France Pari")]
        FrancePari,
        [Names("iFortuna.cz")]
        iFortunacz,
        [Names("iFortuna.sk")]
        iFortunask,
        [Names("Intertops")]
        Intertops,
        [Names("Interwetten.es")]
        Interwettenes,
        [Names("Island Casino")]
        IslandCasino,
        [Names("Ladbrokes", "LB")]
        Ladbrokes,
        [Names("Leon.ru")]
        Leonru,
        [Names("Marsbet")]
        Marsbet,
        [Names("MAXITIP.cz")]
        MAXITIPcz,
        [Names("NightRush")]
        NightRush,
        [Names("NordicBet")]
        NordicBet,
        [Names("Oddsring")]
        Oddsring,
        [Names("SAZKAbet.cz")]
        SAZKAbetcz,
        [Names("ScandiBet")]
        ScandiBet,
        [Names("TitanBet")]
        TitanBet,
        [Names("Totolotek.pl")]
        Totolotekpl,
        [Names("Unibet.fr")]
        Unibetfr,
        [Names("Unibet.it")]
        Unibetit,
        [Names("WilliamHill.it")]
        WilliamHillit,
        [Names("Winline")]
        Winline,
        [Names("youwin")]
        youwin,
        [Names("GB")]
        Gamebookers,
        [Names("SO")]
        SportingOdds,
        [Names("SJ")]
        StanJames,
        [Names("SY")]
        Stanleybet,
        [Names("BS")]
        BlueSquare,

        BetExplorerAverage,

        [Names("BbAv")]
        BetBrainsAverage,
        [Names("BbMx")]
        BetBrainsMaximum,
                    [Names("PSC")]
        PinnacleClosing,
                    Smarkets

    }
}
