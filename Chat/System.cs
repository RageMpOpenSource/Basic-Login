using System;
using System.Collections.Generic;
using System.Text;
using GTANetworkAPI;

namespace Furious_V.Chat
{
    public class System : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            NAPI.Server.SetGlobalServerChat(false);
        }

        public static void ProximityRPChat(Client player, string message, float radius, Colors veryNear, Colors near, Colors nearMid, Colors mid, Colors midFar, Colors far)
        {
            player.SendChatMessage($"{Colors.COLOR_GRAD1}{player.Name} says: {message}");

            foreach (Client target in NAPI.Pools.GetAllPlayers())
            {
                if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 64)
                    target.SendChatMessage($"{Colors.COLOR_GRAD1}{player.Name} says: {message}");
                else if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 32)
                    target.SendChatMessage($"{Colors.COLOR_GRAD2}{player.Name} says: {message}");
                else if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 16)
                    target.SendChatMessage($"{Colors.COLOR_GRAD3}{player.Name} says: {message}");
                else if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 8)
                    target.SendChatMessage($"{Colors.COLOR_GRAD4}{player.Name} says: {message}");
                else if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 4)
                    target.SendChatMessage($"{Colors.COLOR_GRAD5}{player.Name} says: {message}");
                else if (Utils.DistanceFromPlayerToPlayer(player, target) <= radius / 2)
                    target.SendChatMessage($"{Colors.COLOR_GRAD6}{player.Name} says: {message}");
            }
        }
        public static void SendOOCChatToAll(string message)
        {
            foreach (Client target in NAPI.Pools.GetAllPlayers())
            {
                SendOOCChatToPlayer(target, message);
            }
        }
        public static void SendOOCChatToPlayer(Client player, string message)
        {
            player.SendChatMessage($"(({Colors.COLOR_OOC}))");
        }
        public static void SendErrorMessageToPlayer(Client player, string message)
        {
            player.SendChatMessage($"{Colors.Color_White}[{Colors.Color_Error}Error{Colors.Color_White}] {message}");
        }
    }
}