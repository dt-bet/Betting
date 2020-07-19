using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UtilityEnum;
using Betting.Enum;

namespace Betting
{


    public static class MiscellaneousExtension
    {

        public static Resolution GetSuccess(int contract, int outcome)
        {
            return (contract == outcome) ? Resolution.For : Resolution.Against;
        }

        public static int ToInt(this Resolution resolution)
        {
            switch (resolution)
            {
                case Resolution.For:
                    return 1;
                case Resolution.Against:
                    return -1;
                default: return 0;
            }
        }



        public static int ToInferInt(this string result) => result switch
        {
            "H" => 2,
            "D" => 0,
            "A" => 1,
            _ => throw new System.ComponentModel.InvalidEnumArgumentException("not h/a/d")
        };
    }
}
