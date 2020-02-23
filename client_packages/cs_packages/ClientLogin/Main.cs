using System;
using System.Collections.Generic;
using RAGE;
using RAGE.Ui;

namespace ClientLogin
{
    public class Main : Events.Script
    {
        private HtmlWindow LoginPage = null;

        public Main()
        {
            Events.Add("Login_PlayerLogin", PlayerLogin);
            Events.Add("Login_LoginInfoToClient", LoginInfoToServer);
            Events.Add("Login_EditWelcomeText", EditWelcomeText);
            Events.Add("Login_EditButtonText", EditButtonText);
            Events.Add("Login_EditInformationText", EditInformationText);
        }

        public void PlayerLogin(object [] args)
        {
            if ((bool)args[0])
            {
                if (LoginPage == null)
                {
                    LoginPage = new HtmlWindow("package://LoginPage.html");
                    ShowLoginPage(true);
                }
            }
            else
            {
                if (LoginPage != null)
                {
                    ShowLoginPage(false);
                    LoginPage.Destroy();
                    LoginPage = null;
                }                
            }
        }

        public void LoginInfoToServer(object [] args)
        {
            Events.CallRemote("Login_LoginInfoToServer", (string)args[0]);
        }

        public void EditWelcomeText(object [] args)
        {
            if(LoginPage != null)
            {
                LoginPage.ExecuteJs($"EditWelcomeText('{args[0].ToString()}')");
            }
        }

        public void EditButtonText(object[] args)
        {
            if (LoginPage != null)
            {
                LoginPage.ExecuteJs($"EditButtonText('{args[0].ToString()}')");
            }
        }

        public void EditInformationText(object [] args)
        {
            if (LoginPage != null)
            {
                LoginPage.ExecuteJs($"EditInformationText('{args[0].ToString()}')");
            }
        }

        public void ShowLoginPage(bool show)
        {
            LoginPage.Active = show;
            Cursor.Visible = show;
            RAGE.Elements.Player.LocalPlayer.FreezePosition(show);
        }
    }
}
