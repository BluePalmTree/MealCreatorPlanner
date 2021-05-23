using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MealCreatorPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IngredientsViewModel IngredientsVM;

        public MainWindow()
        {
            IngredientsVM = new IngredientsViewModel();
            SeedIngredientsVM();            
            InitializeComponent();
            tiIngredients.DataContext = IngredientsVM;
        }

        private void SeedIngredientsVM()
        {
            var jsonString = File.ReadAllText(@"F:\Projekte\MealCreatorPlanner\Data\Ingredients.json");
            IngredientsVM.Ingredients = JsonSerializer.Deserialize<ObservableCollection<Ingredient>>(jsonString);
        }

        private void IngredientsSave_Click(object sender, RoutedEventArgs e)
        {
            var jsonstrig = JsonSerializer.Serialize(IngredientsVM.Ingredients);
            File.WriteAllText(@"F:\Projekte\MealCreatorPlanner\Data\Ingredients.json", jsonstrig);
        }

        private void IngredientsAdd_Click(object sender, RoutedEventArgs e)
        {
            IngredientAdd ingredientAdd = new IngredientAdd();
            ingredientAdd.ShowDialog();

            if (ingredientAdd.NewIngredient != null)            
                IngredientsVM.Ingredients.Add(ingredientAdd.NewIngredient);            
        }
    }
}
