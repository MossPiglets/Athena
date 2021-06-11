using System;
using System.Collections.Generic;
using System.Text;
using AdonisUI.Controls;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace Athena.MessageBoxes
{
    public class RemoveDataBaseMessageBox
    {
        public bool Show() {
            var messageBox = new MessageBoxModel {
                Text = "Baza danych już istnieje. Czy chcesz ją usunąć?",
                Caption = "Info",
                Icon = MessageBoxImage.Question,
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
