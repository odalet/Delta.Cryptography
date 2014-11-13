﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ISO7816.FileSystem;

namespace ISO7816.Handler.Commands
{
    class AppendRecord : ICardCommand
    {
        IISO7816Card card;
        public IISO7816Card Card { set { card = value; } }
        CardHandler handler;
        public CardHandler Handler { set { handler = value; } }

        public void getSMKeys(Apdu apdu, out BSO sigIn, out BSO encIn, out BSO sigOut, out BSO encOut)
        {
            CardContext context = handler.Context;

            sigIn = null;
            encIn = null;
            sigOut = null;
            encOut = null;

            var efBin = context.CurEF as EFRecord;
            if (efBin == null)
                return;

            encIn = handler.getSMKey(efBin, EF_SM.SM_ENC_APPEND);
            sigIn = handler.getSMKey(efBin, EF_SM.SM_SIG_APPEND);
        }

        public virtual byte[] processCommand(Apdu apdu)
        {
            CardContext context = handler.Context;

            if (apdu.P1 != 0 || apdu.P2 != 0)
                return Error.P1OrP2NotValid;

            if (apdu.Data == null || apdu.Data.Length == 0)
                return Error.DataFieldNotValid;

            if (context.CurEF == null)
                return Error.NoCurrentEFSelected;

            if (!(context.CurEF is EFRecord))
                return Error.CommandIncompatibleWithFileStructure;

            var efRec = context.CurEF as EFRecord;

            if (!handler.IsVerifiedAC(efRec,EF_AC.AC_APPEND))
                return Error.SecurityStatusNotSatisfied;

            int recNum=efRec.Append(apdu.Data);
            context.CurRecord = recNum;

            return Error.Ok;
        }
    }
}
