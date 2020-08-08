using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        public  async Task<List<Krapfen>> GetAllKrapfen()
        {
            return await _krapfenDao.GetAllKrapfen();
        }

        public async Task<Krapfen> GetKrapfenById(Guid? id)
        {
            return await _krapfenDao.GetKrapfenById(id);
        }

        public async Task<Krapfen> GetKrapfenByName(string name)
        {
            return await _krapfenDao.GetKrapfenByName(name);
        }

        public async Task<Krapfen> AddKrapfen(Krapfen krapfen)
        {
            return await _krapfenDao.AddKrapfen(krapfen);
        }

        public  async Task<Krapfen> UpdateKrapfen(Krapfen krapfen)
        {
            return await _krapfenDao.UpdateKrapfen(krapfen);
        }

        public void DeleteKrapfen(Krapfen krapfen)
        {
            _krapfenDao.DeleteKrapfen(krapfen);
        }
        #endregion

        #region Order

        public async Task<List<Order>> GetAllOrder()
        {
            return await _orderDao.GetAllOrders();
        }

        public async Task<Order> GetOrderById(Guid? id)
        {
            return await _orderDao.GetOrderById(id);
        }

        public async Task<Order> AddOrder(Order order)
        {
            return await _orderDao.AddOrder(order);
        }
        

        public async Task<Order> UpdateOrder(Order order)
        {
           return await _orderDao.UpdateOrder(order);
        }

        public  void DeleteOrder(Order order)
        {
            _orderDao.DeleteOrder(order);
        }

        #endregion

        #region Event
        
        public async Task<Event> GetEventById(Guid? id)
        {
            return await _eventDao.GetEventById(id);
        }

        public async Task<Event> AddEvent(Event @event)
        {
            return await _eventDao.AddEvent(@event);
        }

        public async Task<List<Event>> GetAllEvent()
        {
            return await _eventDao.GetAllEvent();
        }

        public async Task<Event> UpdateEvent(Event @event)
        {
            return await _eventDao.UpdateEvent(@event);
        }

        public void DeleteEvent(Event @event)
        {
            _eventDao.DeleteEvent(@event);
        }

        #endregion

        #region Selling
        
        public async Task<Selling> GetSellingById(Guid? id)
        {
            return await _sellingDao.GetSellingById(id);
        }
        
        public  async Task<List<Selling>> GetAllSelling()
        {
            return await _sellingDao.GetAllSelling();
        }

        public async Task<Selling> AddSelling(Selling selling)
        {
            return await _sellingDao.AddSelling(selling);
        }
        
        public async Task<Selling> UpdateSelling(Selling selling)
        {
            return await _sellingDao.UpdateSelling(selling);
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