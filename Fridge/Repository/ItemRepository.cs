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


        //-----------------------------compare Now and Date of Item to determine expiration
        public Color CalculateExpiration(Item item)
        {
            DateTime now = DateTime.Now;

            if (item.ExpirationDate.Date == now.Date)
            {
                System.Diagnostics.Debug.Print("equal");
                return Color.Orange;
            }
            else if (item.ExpirationDate.Date < now.Date)
            {
                System.Diagnostics.Debug.Print("smaller");
                return Color.Tomato;
            }
            System.Diagnostics.Debug.Print("greater");
            return Color.MediumSeaGreen;
        }
    }

}
