using System;
using System.Threading.Tasks;
using System.Timers;
using GTANetworkAPI;

namespace Furious_V
{
    public class Main : Script
    {
        /// <summary>
        /// Contains the current version of the gamemode saved inside the database.
        /// </summary>
        public static String ServerVersion { get; set; } = "0.0.1a";
        private static Timer SaveDataTimer { get; set; } = null;
        /// <summary>
        /// This initiates the call of a endless timer which saves datas every minute //
        /// </summary>
        private static void RepeatSaveData()
        {
            SaveDataTimer = new Timer(60 * 1000);
            SaveDataTimer.Elapsed += OnAllDataSave;
            SaveDataTimer.Enabled = true;
        }
        /// <summary>
        /// The callback for the timer in <see cref="RepeatSaveData"/> which loops through datas and saves it in the database.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static async void OnAllDataSave(object source, ElapsedEventArgs e)
        {
            foreach (Client item in NAPI.Pools.GetAllPlayers())
            {
                if (Player.Data.GetPlayerData(item).LoggedIn)
                {
                    await Player.Data.GetPlayerData(item).SavePlayerData(item);
                }
            }
        }
        /// <summary>
        /// This callback simply passes the credentials for the database for connection.
        /// </summary>
        /// <returns>Void</returns>
        [ServerEvent(Event.ResourceStart)]
        public static async Task OnResourceStart()
        {
            NAPI.Server.SetAutoSpawnOnConnect(false);
            NAPI.Server.SetAutoRespawnAfterDeath(false);

            RepeatSaveData();

            #region DebugCase
            await MySQL.Database.InitConnection("localhost", "root", "", "furious_v");
            #endregion
            return;
        }
    }
}
