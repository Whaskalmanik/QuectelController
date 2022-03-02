using QuectelController.Communication;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuectelController
{
    public class TreeViewCategory
    {
        public ObservableCollection<TreeViewItem> Items { get; set; }

        public CommandCategory CommandCategory { get; set; }

        public string Name => GetEnumValueAttribute<DescriptionAttribute>(CommandCategory)?.Description;

        public static T GetEnumValueAttribute<T>(Enum value)
             where T : Attribute
        {
            return value
                .GetType()
                .GetMember(value.ToString())
                ?.FirstOrDefault()
                ?.GetCustomAttributes(typeof(T), false)
                ?.FirstOrDefault() as T;
        }

        public TreeViewCategory()
        {

        }
    }
}
