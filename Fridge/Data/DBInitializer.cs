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
                new Item{Name="Lettuce", ExpirationDate=DateTime.Parse("2023-06-27")}
            };

            context.Item.AddRange(items);
            context.SaveChanges();

        }
    }
}
