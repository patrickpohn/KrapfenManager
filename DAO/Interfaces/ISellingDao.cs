using System;
using System.Collections.Generic;
using Entities;

namespace DAO.Interfaces
{
    public interface ISellingDao
    {
        List<Selling> GetAllSelling();
        Selling GetSellingById(Guid? id);
        Selling AddSelling(Selling selling);
        Selling UpdateSelling(Selling selling);
        void DeleteSelling(Selling selling);
    }
}