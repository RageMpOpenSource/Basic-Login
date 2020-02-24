using System;
using GTANetworkAPI;

namespace Furious_V
{
    /// <summary>
    /// Contains most of the static utilities functions.
    /// </summary>
    public class Utils : Script
    {
        /// <summary>
        /// The different levels of Log for the function Log()
        /// </summary>
        public enum Log_Status
        {
            Log_Success,
            Log_Error,
            Log_Warning,
            Log_Debug
        }
        /// <summary>
        /// Prints in the console with colors depending on the log level.
        /// </summary>
        /// <param name="message">The text that needs to be printed.</param>
        /// <param name="log_status">The enum which defines the log level which determines the prefix and color of the text.</param>
        public static void Log(String message, Log_Status log_status)
        {
            String status = "";
            ConsoleColor color = ConsoleColor.Gray;

            switch (log_status)
            {
                case Log_Status.Log_Success:
                    {
                        status = "[Success]";
                        color = ConsoleColor.Green;
                        break;
                    }
                case Log_Status.Log_Error:
                    {
                        status = "[Error]";
                        color = ConsoleColor.Red;
                        break;
                    }
                case Log_Status.Log_Warning:
                    {
                        status = "[Warning]";
                        color = ConsoleColor.Yellow;
                        break;
                    }
                case Log_Status.Log_Debug:
                    {
                        status = "[Debug]";
                        color = ConsoleColor.Blue;
                        break;
                    }
            }
            if (status.Equals(""))
                NAPI.Util.ConsoleOutput($"{message}");
            else
            {
                Console.ForegroundColor = color;
                NAPI.Util.ConsoleOutput($"{status} {message}");
                Console.ForegroundColor = ConsoleColor.Gray;
            }                

            return;
        }
        /// <summary>
        /// Calculates the distance between two players in an absolute form.
        /// </summary>
        /// <param name="player">The player</param>
        /// <param name="target">The target</param>
        /// <returns>The distance between the two players.</returns>
        public static float DistanceFromPlayerToPlayer(Client player, Client target)
        {
            return Math.Abs( player.Position.DistanceTo(target.Position) );
        }
        /// <summary>
        /// Displays a pop up notification from up top.
        /// </summary>
        /// <param name="player">The player who will see the notification.</param>
        /// <param name="text">The message that will be displayed to the player.</param>
        /// <param name="delay">The time in ms the pop up will be shown for.</param>
        /// <param name="color">Color name in string.</param>
        /// <param name="italics">Whether the text should be in italics or not.</param>
        public static void PopUpNotification(Client player, string text, int delay, string color, bool italics = false)
        {
            NAPI.ClientEvent.TriggerClientEvent(player, "Notification_PopUpNotification", text, delay, color, italics);
            return;
        }
    }
}
