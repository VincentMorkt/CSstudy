using Microsoft.EntityFrameworkCore.ChangeTracking;
using Packt.Shared;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindService.Repositories
{
  public class CustomerRepository : ICustomerRepository
  {
    // use a static thread-safe dictionary field to cache the customers
    private static ConcurrentDictionary
      <string, Customer> customersCache;

    // use an instance data context field because it should not be
    // cached due to their internal caching
    private Northwind db;

    public CustomerRepository(Northwind db)
    {
      this.db = db;

      // pre-load customers from database as a normal
      // Dictionary with CustomerID as the key,
      // then convert to a thread-safe ConcurrentDictionary
      if (customersCache == null)
      {
        customersCache = new ConcurrentDictionary<string, Customer>(
          db.Customers.ToDictionary(c => c.CustomerID));
      }
    }

    public async Task<Customer> CreateAsync(Customer c)
    {
      // normalize CustomerID into uppercase
      c.CustomerID = c.CustomerID.ToUpper();

      // add to database using EF Core
      EntityEntry<Customer> added = await db.Customers.AddAsync(c);
      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        // if the customer is new, add it to cache, else
        // call UpdateCache method
        return customersCache.AddOrUpdate(c.CustomerID, c, UpdateCache);
      }
      else
      {
        return null;
      }
    }

    public Task<IEnumerable<Customer>> RetrieveAllAsync()
    {
      // for performance, get from cache
      return Task.Run<IEnumerable<Customer>>(
        () => customersCache.Values);
    }

    public Task<Customer> RetrieveAsync(string id)
    {
      return Task.Run(() =>
      {
        // for performance, get from cache
        id = id.ToUpper();
        customersCache.TryGetValue(id, out Customer c);
        return c;
      });
    }

    private Customer UpdateCache(string id, Customer c)
    {
      Customer old;
      if (customersCache.TryGetValue(id, out old))
      {
        if (customersCache.TryUpdate(id, c, old))
        {
          return c;
        }
      }
      return null;
    }

    public async Task<Customer> UpdateAsync(string id, Customer c)
    {
      // normalize customer ID
      id = id.ToUpper();
      c.CustomerID = c.CustomerID.ToUpper();

      // update in database
      db.Customers.Update(c);
      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        // update in cache
        return UpdateCache(id, c);
      }
      return null;
    }

    public async Task<bool?> DeleteAsync(string id)
    {
      id = id.ToUpper();

      // remove from database
      Customer c = db.Customers.Find(id);
      db.Customers.Remove(c);
      int affected = await db.SaveChangesAsync();
      if (affected == 1)
      {
        // remove from cache
        return customersCache.TryRemove(id, out c);
      }
      else
      {
        return null;
      }
    }
  }
}