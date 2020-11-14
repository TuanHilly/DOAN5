using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public interface IUserDAL
    {
        User GetUser(string username, string password);
        User GetDatabyID(string id);
        bool Create(User model);
        bool Update(User model);
        bool Delete(string id);
        List<User> Search(int pageIndex, int pageSize, out long total, string hoten, string taikhoan);
    }
}