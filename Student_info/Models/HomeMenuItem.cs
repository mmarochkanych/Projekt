using System;
using System.Collections.Generic;
using System.Text;

namespace Student_info.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Sms
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
