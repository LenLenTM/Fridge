using Fridge.Models;
using System.Drawing;

namespace Fridge.Repository
{
    public interface IItem
    {
        Task<List<Item>> GetItems();

        Task<String> DeleteItem(Item item);

        Task<String> AddItem(Item item);

        Task<String> UpdateItem(int id, String name, DateTime date);

        List<String> CalculateExpiration(Item item);
    }
}
