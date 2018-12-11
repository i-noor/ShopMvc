using System.Linq;
using Shop.Domain.Entities;
using Shop.Models;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}