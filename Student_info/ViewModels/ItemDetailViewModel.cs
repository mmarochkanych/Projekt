using System;

using Student_info.Models;

namespace Student_info.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Item Item { get; set; }
        public ItemDetailViewModel(Item item = null)
        {
            Title = item?.Index;
            Item = item;
        }
    }
}
