using System;
using System.Threading.Tasks;
using System.Collections.Generic;

using GTANetworkAPI;

namespace Furious_V.Admin
{
    /// <summary>
    /// Contains all relevant attributes and methods for admins.
    /// </summary>
    public class Data : Script
    {
        /// <summary>
        /// The different types of admin.
        /// </summary>
        public enum E_ADMIN_LEVEL
        {
            ADMIN_NONE,
            ADMIN_PROBIE,
            ADMIN_GENERAL,
            ADMIN_HEAD,
            ADMIN_EXECUTIVE,
            ADMIN_OWNER
        }
        [Command("savechars", Alias = "saveall")]
        public static async Task CMD_SaveChars(Client player)
        {
            if (Player.Data.GetPlayerData(player).Admin < E_ADMIN_LEVEL.ADMIN_HEAD)
            {
                return;
            }
            int count = 0;

            foreach (Client item in NAPI.Pools.GetAllPlayers())
            {
                if (Player.Data.GetPlayerData(item).LoggedIn)
                {
                    await Player.Data.GetPlayerData(item).SavePlayerData(item);
                    count++;
                }
            }
            Utils.Log($"{count} player data were saved.", Utils.Log_Status.Log_Debug);
            Utils.PopUpNotification(player, $"{count} player data were saved.", 3000, "lightgreen", true);
        }
    }
}
