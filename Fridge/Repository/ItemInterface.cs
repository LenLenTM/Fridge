using Fridge.Models;
using System.Drawing;

namespace Fridge.Repository
{
    public interface IItem
    {
        Task<List<Item>> GetItems();

        Task<String> DeleteItem(Item item);

        List<String> CalculateExpiration(Item item);
    }
}
