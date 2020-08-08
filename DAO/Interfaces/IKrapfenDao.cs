using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities;

namespace DAO.Interfaces
{
    public interface IKrapfenDao
    {
        Task<List<Krapfen>> GetAllKrapfen();
        Task<Krapfen> GetKrapfenById(Guid? id);
        Task<Krapfen> GetKrapfenByName(string name);
        Task<Krapfen> AddKrapfen(Krapfen krapfen);
        Task<Krapfen> UpdateKrapfen(Krapfen krapfen);
        void DeleteKrapfen(Krapfen krapfen);
        
    }
}