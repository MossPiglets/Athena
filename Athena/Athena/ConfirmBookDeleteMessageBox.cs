using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdonisUI.Controls;
using Athena.Data.Books;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxButton = AdonisUI.Controls.MessageBoxButton;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace Athena
{
    public class ConfirmBookDeleteMessageBox
    {
        public bool CreateMessageBox() {
            var messageBox = new MessageBoxModel {
                Text = "Czy na pewno chcesz usunąć książkę?",
                Caption = "Info",
                Icon = MessageBoxImage.Warning,
                Buttons = new [] {
                    MessageBoxButtons.Yes("Tak"),
                    MessageBoxButtons.No("Nie")
                },
                IsSoundEnabled = false
            };
            MessageBox.Show(messageBox);

            switch (messageBox.Result) {
                case MessageBoxResult.No:
                    return false;
                case MessageBoxResult.Yes:
                    return true;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
