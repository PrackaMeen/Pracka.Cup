namespace Pracka.Cup.Database.Enums
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public enum TeamResultEnum
    {
        Victory = 1,
        OvertimeVictory = 3,
        ShootoutVictory = 4,
        Lost = 7,
        OvertimeLost = 21,
        ShootoutLost = 28
    }
}
