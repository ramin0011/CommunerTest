using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Communer.Models
{
    public class RecipeActions
    {
        public RecipeActions(string item, Enums.VedingMachineActions action)
        {
            this.Item = item;
            this.Action = action;
        }
        public string Item { get; set; }
        public Enums.VedingMachineActions Action { get; set; }
    }
    public class Recipe
    {
        public Guid Id { get; set; }
        public Recipe()
        {
            Id=Guid.NewGuid();
            Steps = new List<RecipeActions>();
        }
        public List<RecipeActions> Steps { get; set; }
        public string Name { get; set; }
    }
}
