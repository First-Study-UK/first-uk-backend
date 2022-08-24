using FirstStudy.Data;
using FirstStudy.Interface;
using FirstStudy.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstStudy.Repository
{
    public class UserInfoRepository : IUserInfo
    {
        readonly DatabaseContext _dbContext = new();
        public UserInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddUser(UserInfo userInfo)
        {
            try
            {
                _dbContext.UserInfo.Add(userInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public UserInfo DeleteUser(int Id)
        {
            try
            {
                UserInfo userInfo = _dbContext.UserInfo.Find();
                if (userInfo != null)
                {
                    _dbContext.UserInfo.Remove(userInfo);
                    _dbContext.SaveChanges();
                    return userInfo;
                }
                else
                {
                    throw new ArgumentException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<UserInfo> GetAllUserInfos()
        {
            try
            {
                return _dbContext.UserInfo.ToList();
            }
            catch
            {
                throw;
            }
        }

        public void UpdateUser(UserInfo userInfo)
        {
            try
            {
                _dbContext.Entry(userInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
