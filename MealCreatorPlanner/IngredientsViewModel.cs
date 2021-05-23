using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Media;

namespace MealCreatorPlanner
{
    public class IngredientsViewModel
    {
        public IngredientsViewModel()
        {
            Ingredients = new ObservableCollection<Ingredient>();
        }

        public ObservableCollection<Ingredient> Ingredients { get; set; }
    }

    public class Ingredient
    {
        public string Barcode { get; set; }
        public string Name { get; set; }        
        public bool AmountVariable { get; set; }
        public double ProteinPer100g { get; set; }
        public double FatPer100g { get; set; }
        public double CarbsPer100g { get; set; }
        public double CaloriesPer100g { get; set; }
    }

    public class PackagingSize
    {
        [Description("Contents of the Packing in gramm")]
        public double Content { get; set; }
        public decimal Price { get; set; }
    }
}
