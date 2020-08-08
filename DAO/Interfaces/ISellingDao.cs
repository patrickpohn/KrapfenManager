using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DAO.Interfaces
{
    public interface ISellingDao
    {
        Task<List<Selling>> GetAllSelling();
        Task<Selling> GetSellingById(Guid? id);
        Task<Selling> AddSelling(Selling selling);
        Task<Selling> UpdateSelling(Selling selling);
        void DeleteSelling(Selling selling);
    }
}