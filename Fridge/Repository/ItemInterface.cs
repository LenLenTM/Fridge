using Fridge.Models;
using System.Drawing;

namespace Fridge.Repository
{
    public interface IItem
    {
        Task<List<Item>> GetItems();
        Color CalculateExpiration(Item item);
    }
}
