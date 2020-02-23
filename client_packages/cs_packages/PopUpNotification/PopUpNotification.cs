using System;
using RAGE;
using RAGE.Ui;

namespace ClientLogin
{
    class PopUpNotification : Events.Script
    {
        private HtmlWindow Notification;

        PopUpNotification()
        {
            Events.Add("Notification_PopUpNotification", Notification_PopUpNotification);
            Events.Add("Notification_NotificationOff", Notification_NotificationOff);
            Notification = new HtmlWindow("package://TopNotification.html");
        }

        private void Notification_PopUpNotification(object [] args)
        {
            Notification.Active = true;
            Notification.ExecuteJs($"ExecuteNotification('{args[0].ToString()}', '{Convert.ToInt32(args[1])}', '{args[2].ToString()}', '{Convert.ToBoolean(args[3])}')");
        }
        private void Notification_NotificationOff(object [] args)
        {
            Notification.Active = false;
        }
    }
}
