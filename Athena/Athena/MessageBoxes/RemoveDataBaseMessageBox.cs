using System;
using System.Linq;
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
