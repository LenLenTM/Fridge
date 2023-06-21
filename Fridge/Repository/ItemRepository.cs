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

        public async Task<String> AddItem(Item item)
        {
            try
            {
                _context.Item.Add(item);
                await _context.SaveChangesAsync();
                return "Item added";

            }
            catch (Exception ex)
            {
                return "Could not add item. " + ex.Message;
            }
            
        }

        public async Task<String> UpdateItem(int id, String name, DateTime date)
        {
            var entity = _context.Item.Find(id);
            _context.Item.Entry(entity).CurrentValues.SetValues(new Item(id, name, date));

            try
            {
                await _context.SaveChangesAsync();
                return "Item updated";
            }
            catch (Exception ex)
            {
                return "Could not update. " + ex.Message;
            }
            
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
                return "Could not delete. " + ex.Message;
            }
        }


        //-----------------------------compare Now and Date of Item to determine expiration
        public List<String> CalculateExpiration(Item item)
        {
            DateTime now = DateTime.Now;

            if (item.ExpirationDate.Date == now.Date)
            {
                return new List<String> { Color.Moccasin.Name, "Just good" };
            }
            else if (item.ExpirationDate.Date < now.Date)
            {
                return new List<String> { Color.LightSalmon.Name, "Yuck" };
            }
            return new List<String> { Color.LightGreen.Name, "Yummy" };
        }
    }

}
