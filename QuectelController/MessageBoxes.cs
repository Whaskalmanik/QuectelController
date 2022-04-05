using Avalonia.Controls;
using MessageBox.Avalonia.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController
{
    public static class MessageBoxes
    {
        public static async void ShowWarning(Window window, string title, string message)
        {
            var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
            new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = message,
                Icon = MessageBox.Avalonia.Enums.Icon.Warning,
            });
            await mb.Show(window);
        }
        public static async void ShowError(Window window, string title, string message)
        {
            var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
            new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = message,
                Icon = MessageBox.Avalonia.Enums.Icon.Error,
            });
            await mb.Show(window);
        }

    }
}
