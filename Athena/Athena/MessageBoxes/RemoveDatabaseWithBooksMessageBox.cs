using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdonisUI.Controls;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace Athena.MessageBoxes
{
    public class RemoveDatabaseWithBooksMessageBox
    {
        public bool Show() {
            var messageBox = new MessageBoxModel {
                Text = "Baza danych zawiera już książki. Czy jesteś absosmerfnie pewien, że chcesz ją usunąć?",
                Caption = "Info",
                Icon = MessageBoxImage.Warning,
                Buttons = new [] {
                    MessageBoxButtons.Yes("Tak"),
                    MessageBoxButtons.No("Nie")
                },
                IsSoundEnabled = false
            };

            var buttons = messageBox.Buttons.ToArray();
            buttons[0].IsDefault = false;
            buttons[1].IsDefault = true;
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
