using System;
using System.Collections.Generic;
using DAO.Implementations;
using DAO.Interfaces;
using Entities;
using Microsoft.Extensions.Configuration;

namespace BL
{
    public class BL
    {
        private static BL _instance = null;
        private static IKrapfenDao _krapfenDao;
        private static IOrderDao _orderDao;

        public void SetUpBl(string db)
        {
            _krapfenDao = new KrapfenDao(db);
            _orderDao = new OrderDao(db);
        }

        private BL()
        {
        }

        public static BL Instance => _instance ??= new BL();

        #region Krapfen
        public  List<Krapfen> GetAllKrapfen()
        {
            return _krapfenDao.GetAllKrapfen();
        }

        public Krapfen GetKrapfenById(Guid? id)
        {
            return _krapfenDao.GetKrapfenById(id);
        }

        public  Krapfen AddKrapfen(Krapfen krapfen)
        {
            return _krapfenDao.AddKrapfen(krapfen);
        }

        public  List<Krapfen> AddKrapfenRange(List<Krapfen> krapfen)
        {
            return _krapfenDao.AddKrapfenRange(krapfen);
        }

        public  Krapfen UpdateKrapfen(Krapfen krapfen)
        {
            return _krapfenDao.UpdateKrapfen(krapfen);
        }

        public  void DeleteKrapfen(Krapfen krapfen)
        {
            _krapfenDao.DeleteKrapfen(krapfen);
        }
        #endregion

        #region Order

        public  List<Order> GetAllOrder()
        {
            return _orderDao.GetAllOrders();
        }

        public Order GetOrderById(Guid id)
        {
            return _orderDao.GetOrderById(id);
        }

        public Order AddOrder(Order order)
        {
            order.Krapfens.ForEach(k =>
            
                k = GetKrapfenById(k.Id)
            );
            
            return _orderDao.AddOrder(order);
        }

        public  List<Order> AddOrderRange(List<Order> order)
        {
            order.ForEach(o => 
                o.Krapfens.ForEach(k => 
                    k = GetKrapfenById(k.Id)
                ));
            
            return _orderDao.AddOrderRange(order);
        }

        public  Order UpdateOrder(Order order)
        {
            order.Krapfens.ForEach(
                k => 
                    k = GetKrapfenById(k.Id)
                    );
            return _orderDao.UpdateOrder(order);
        }

        public  void DeleteOrder(Order order)
        {
            _orderDao.DeleteOrder(order);
        }

        #endregion
        
    }
}