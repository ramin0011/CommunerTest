using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Communer.Models;
using Communer.Models.Enums;

namespace Communer
{
    class Database
    {
        public static List<Models.Recipe> GetAllRecipes()
        {
            return new List<Recipe>()
            {
                new Recipe()
                {
                    Name = "Hot  Chocolate",
                    Steps = new List<RecipeActions>()
                    {
                        new RecipeActions("Water",VedingMachineActions.Boil),
                        new RecipeActions("Drinking Choclate",VedingMachineActions.AddToCup),
                        new RecipeActions("Water",VedingMachineActions.Add),
                    }
                },
                new Recipe()
                {
                    Name = "White  Coffee  with  1  sugar",
                    Steps = new List<RecipeActions>()
                    {
                        new RecipeActions("Water",VedingMachineActions.Boil),
                        new RecipeActions("Sugar",VedingMachineActions.Add),
                        new RecipeActions("coffee  granules ",VedingMachineActions.AddToCup),
                        new RecipeActions("Water ",VedingMachineActions.Add),
                        new RecipeActions("Milk",VedingMachineActions.Add),
                    }
                },
                new Recipe()
                {
                    Name = "Lemon  Tea  ",
                    Steps = new List<RecipeActions>()
                    {
                        new RecipeActions("water",VedingMachineActions.Boil),
                        new RecipeActions("water",VedingMachineActions.Add),
                        new RecipeActions("tea bag ",VedingMachineActions.Add),
                        new RecipeActions("lemon ",VedingMachineActions.Add),
                    }
                },
                new Recipe()
                {
                    Name = "Iced  Coffee",
                    Steps = new List<RecipeActions>()
                    {
                        new RecipeActions("Ice",VedingMachineActions.Crush),
                        new RecipeActions("Ice",VedingMachineActions.AddToBlender),
                        new RecipeActions("coffee  syrup ",VedingMachineActions.AddToBlender),
                        new RecipeActions("ingredients ",VedingMachineActions.Add),
                    }
                }
            };
        }
    }
}
