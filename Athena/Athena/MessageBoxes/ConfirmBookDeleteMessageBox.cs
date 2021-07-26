using System;
using AdonisUI.Controls;
using MessageBox = AdonisUI.Controls.MessageBox;
using MessageBoxImage = AdonisUI.Controls.MessageBoxImage;
using MessageBoxResult = AdonisUI.Controls.MessageBoxResult;

namespace Athena.MessageBoxes {
    public class ConfirmBookDeleteMessageBox {
        public bool Show() {
            var messageBox = new MessageBoxModel {
                Text = "Czy na pewno chcesz usunąć książkę?",
                Caption = "Info",
                Icon = MessageBoxImage.Warning,
                Buttons = new[] {
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