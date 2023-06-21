using Fridge.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Fridge.Repository;
using Fridge.Data;
using System.Drawing;

namespace Fridge.Repository
{
    public class ItemRepository : IItem
    {
        private readonly FridgeContext _context;

        public ItemRepository(FridgeContext context)
        {
            this._context = context;
        }

        //-------------------------------------------------------------DB Access Methodes
        public async Task<List<Item>> GetItems()
        {
            return await _context.Item.ToListAsync();
        }

        public async Task<String> DeleteItem(Item item)
        { 
            try
            {
                _context.Item.Remove(item);
                await _context.SaveChangesAsync();
                return "Deleted";
            }
            catch (Exception ex)
            {
                return "Could not delete. " + ex;
            }
        }


        //-----------------------------compare Now and Date of Item to determine expiration
        public List<String> CalculateExpiration(Item item)
        {
            DateTime now = DateTime.Now;

            if (item.ExpirationDate.Date == now.Date)
            {
                System.Diagnostics.Debug.Print("equal");
                return new List<String> { Color.Moccasin.Name, "Just good" };
            }
            else if (item.ExpirationDate.Date < now.Date)
            {
                System.Diagnostics.Debug.Print("smaller");
                return new List<String> { Color.LightSalmon.Name, "Yuck" };
            }
            System.Diagnostics.Debug.Print("greater");
            return new List<String> { Color.LightGreen.Name, "Yummy" };
        }
    }

}
