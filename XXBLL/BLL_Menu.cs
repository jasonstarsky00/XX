using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXModels;

namespace XXBLL
{
    public class BLL_Menu
    {
        //创建锁
        private static object _lock = new object();
        //创建类静态调用字符
        public static BLL_Menu Instance { get; private set; }
        //私有构造函数
        private BLL_Menu()
        {

        }
        //静态构造函数
        static BLL_Menu()
        {
            if (Instance == null)
            {
                lock (_lock)
                {
                    if (Instance == null) Instance = new BLL_Menu();
                }
            }
        }
        private XXData.DAL_Menu bll = new XXData.DAL_Menu();
        /// <summary>
        /// 获取所有的菜单信息
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        public List<Menu> GetMenusByRoleId(int id)
        {
            return bll.GetMenusByRoleId(id);
        }
    }
}
