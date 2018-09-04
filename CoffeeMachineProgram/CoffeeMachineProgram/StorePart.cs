using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
namespace CoffeeMachineProgram
{
    public class StorePart
    {
        private decimal water;
        private decimal sugar;
        private decimal coffee;

        public StorePart()
        {
            DataEntities db; db = new DataEntities();
            Ingredient ingredient = db.Ingredients.First();
            water = ingredient.Water;
            sugar = ingredient.Sugar;
            coffee = ingredient.Coffee;

            db.SaveChanges();
        }
        public bool ResourceTrack(CoffeeType coffeeType, bool b = true)
        {
            if (this.water >= coffeeType.Water && this.sugar >= coffeeType.Sugar && this.coffee >= coffeeType.Coffee)
            {
                if (b)
                {
                    DataEntities db = new DataEntities();
                    Ingredient ingredients= db.Ingredients.First(); 
                    ingredients.Water -= coffeeType.Water;
                    ingredients.Sugar -= coffeeType.Sugar;
                    ingredients.Coffee -= coffeeType.Coffee;
                    db.SaveChanges();
                    this.water -= coffeeType.Water;
                    this.sugar -= coffeeType.Sugar;
                    this.coffee -= coffeeType.Coffee;
                }
                return true;
            }
            return false;
        }
        public void AddResource(decimal w,decimal s,decimal c)  
        {
            DataEntities db = new DataEntities();
            Ingredient ingredients = db.Ingredients.First();
            ingredients.Water -= w; 
            ingredients.Sugar -= s;
            ingredients.Coffee -= c;
            db.SaveChanges();
            this.water -= w;
            this.sugar -= s;
            this.coffee -= c;
        }
    }
}
