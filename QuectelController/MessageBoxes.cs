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
        public static async Task<MessageBox.Avalonia.Enums.ButtonResult> ShowWarning(Window window, string title, string message)
        {
            var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
            new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = message,
                Icon = MessageBox.Avalonia.Enums.Icon.Warning,
            });
            return await mb.Show(window);
        }

        public static async Task<MessageBox.Avalonia.Enums.ButtonResult> ShowError(Window window, string title, string message)
        {
            var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
            new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = message,
                Icon = MessageBox.Avalonia.Enums.Icon.Error,
            });
            return await mb.Show(window);
        }

        public static async Task<MessageBox.Avalonia.Enums.ButtonResult> ShowQuestion(Window window, string title, string message)
        {
            var mb = MessageBox.Avalonia.MessageBoxManager.GetMessageBoxStandardWindow(
            new MessageBoxStandardParams
            {
                ContentTitle = title,
                ContentMessage = message,
                Icon = MessageBox.Avalonia.Enums.Icon.Question,
                ButtonDefinitions = MessageBox.Avalonia.Enums.ButtonEnum.YesNo,
            });
            return await mb.ShowDialog(window);
        }
    }
}
