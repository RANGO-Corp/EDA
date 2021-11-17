using System.Collections.Generic;
using Alere.Models;


namespace Alere.ViewModels
{
    public class FoodViewModel
    {
        public IList<Food> Foods { get; set; }

        #nullable enable
        public Requisition? Requisition { get; set; }
        #nullable restore
    }
}