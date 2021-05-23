using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MealCreatorPlanner
{
    /// <summary>
    /// Interaction logic for NeueZutat.xaml
    /// </summary>
    public partial class IngredientAdd : Window
    {
        ObservableCollection<PackagingSize> packagings;

        public Ingredient NewIngredient { get; private set; }

        public IngredientAdd()
        {
            packagings = new ObservableCollection<PackagingSize>();            
            InitializeComponent();
            PackagingSizes.ItemsSource = packagings;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            double doubleValue;

            NewIngredient = new Ingredient();
            NewIngredient.Name = Name.Text;
            NewIngredient.Barcode = Barcode.Text;

            if (double.TryParse(Calories.Text, out doubleValue))
                NewIngredient.CaloriesPer100g = doubleValue;

            if (double.TryParse(Carbohydrates.Text, out doubleValue))
                NewIngredient.CarbsPer100g = doubleValue;

            if (double.TryParse(Fat.Text, out doubleValue))
                NewIngredient.FatPer100g = doubleValue;

            if (double.TryParse(Protein.Text, out doubleValue))
                NewIngredient.ProteinPer100g = doubleValue;

            NewIngredient.AmountVariable = Convert.ToBoolean(AmountVariable.IsChecked);
            NewIngredient.PackagingSizes = this.packagings.ToList<PackagingSize>();

            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PackagingSizeAdd_Click(object sender, RoutedEventArgs e)
        {
            packagings.Add(new PackagingSize());
        }

        private void PackagingSizeDelete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
