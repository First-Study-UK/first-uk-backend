using FirstStudy.Models;

namespace FirstStudy.Interface
{
    public interface IUserInfo
    {
        public List<UserInfo> GetAllUserInfos();
        public void AddUser(UserInfo userInfo);
        public void UpdateUser(UserInfo userInfo);
        public UserInfo DeleteUser(int Id);
    }
}
