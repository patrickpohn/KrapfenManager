using System;
using System.Collections.Generic;
using Entities;

namespace DAO.Interfaces
{
    public interface IKrapfenDao
    {
        List<Krapfen> GetAllKrapfen();
        Krapfen GetKrapfenById(Guid? id);
        Krapfen GetKrapfenByName(string name);
        Krapfen AddKrapfen(Krapfen krapfen);
        List<Krapfen> AddKrapfenRange(List<Krapfen> krapfen);
        Krapfen UpdateKrapfen(Krapfen krapfen);
        void DeleteKrapfen(Krapfen krapfen);
        
    }
}