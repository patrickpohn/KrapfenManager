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
        private static IEventDao _eventDao;
        private static ISellingDao _sellingDao;
        private static IUserDao _userDao;

        public void SetUpBl(string db)
        {
            _krapfenDao = new KrapfenDao(db);
            _orderDao = new OrderDao(db);
            _eventDao = new EventDao(db);
            _sellingDao = new SellingDao(db);
            _userDao = new UserDao(db);
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

        public Krapfen GetKrapfenByName(string name)
        {
            return _krapfenDao.GetKrapfenByName(name);
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
            return _orderDao.AddOrder(order);
        }
        

        public  Order UpdateOrder(Order order)
        {
           return _orderDao.UpdateOrder(order);
        }

        public  void DeleteOrder(Order order)
        {
            _orderDao.DeleteOrder(order);
        }

        #endregion

        #region Event
        
        public Event GetEventById(Guid id)
        {
            return _eventDao.GetEventById(id);
        }

        public Event AddEvent(Event @event)
        {
            return _eventDao.AddEvent(@event);
        }

        public  List<Event> GetAllEvent()
        {
            return _eventDao.GetAllEvent();
        }

        public Event UpdateEvent(Event @event)
        {
            return _eventDao.UpdateEvent(@event);
        }

        public void DeleteEvent(Event @event)
        {
            _eventDao.DeleteEvent(@event);
        }

        #endregion

        #region Selling
        
        public Selling GetSellingById(Guid id)
        {
            return _sellingDao.GetSellingById(id);
        }
        
        public  List<Selling> GetAllSelling()
        {
            return _sellingDao.GetAllSelling();
        }

        public Selling AddSelling(Selling selling)
        {
            return _sellingDao.AddSelling(selling);
        }
        
        public Selling UpdateSelling(Selling selling)
        {
            return _sellingDao.UpdateSelling(selling);
        }

        public void DeleteSelling(Selling selling)
        {
            _sellingDao.DeleteSelling(selling);
        }

        #endregion
        
        #region User
        
        public User GetUserById(Guid? id)
        {
            return _userDao.GetUserById(id);
        }
        
        public  List<User> GetAllUser()
        {
            return _userDao.GetAllUser();
        }

        public User GetUserByName(string name)
        {
            return _userDao.GetUserByName(name);
        }

        public User AddUser(User user)
        {
            return _userDao.AddUser(user);
        }
        
        public User UpdateUser(User user)
        {
            return _userDao.UpdateUser(user);
        }

        public void DeleteUser(User user)
        {
            _userDao.DeleteUser(user);
        }

        #endregion

    }
}