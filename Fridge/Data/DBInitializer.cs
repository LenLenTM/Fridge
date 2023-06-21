using Fridge.Models;

namespace Fridge.Data
{
    public class DbInitializer
    {
        public static void Initializer(FridgeContext context)
        {
            //check if database is not empty. If empty initialize
            if (context.Item.Any())
            {
                return;
            }

            var items = new Item[]
            {
                new Item{Name="Banana", ExpirationDate=DateTime.Parse("1991-04-13")},
                new Item{Name="Butter", ExpirationDate=DateTime.Parse("2023-08-07")},
                new Item{Name="Lettuce", ExpirationDate=DateTime.Parse("2023-06-27")},
                new Item{Name="Gochujang", ExpirationDate=DateTime.Parse("2025-02-12")},
                new Item{Name="Lasagne", ExpirationDate=DateTime.Parse("2023-06-22")},
                new Item{Name="Pickles", ExpirationDate=DateTime.Parse("2023-06-23")},
                new Item{Name="Milk", ExpirationDate=DateTime.Parse("2023-06-26")},
                new Item{Name="Eggs", ExpirationDate=DateTime.Parse("2023-06-24")},
                new Item{Name="Tomatos", ExpirationDate=DateTime.Parse("2023-01-27")},
                new Item{Name="Cheese", ExpirationDate=DateTime.Parse("2023-06-25")},
                new Item{Name="Garlic Dip", ExpirationDate=DateTime.Parse("2023-07-01")},
                new Item{Name="Insulin", ExpirationDate=DateTime.Parse("2023-06-21")}
            };

            context.Item.AddRange(items);
            context.SaveChanges();

        }
    }
}
