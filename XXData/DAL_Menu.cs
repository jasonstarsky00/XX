using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XXCommon;
using XXModels;

namespace XXData
{
    public class DAL_Menu
    {
        /// <summary>
        /// 获取所有的菜单信息
        /// </summary>
        /// <param name="id">角色id</param>
        /// <returns></returns>
        public List<Menu> GetMenusByRoleId(int id)
        {
            string sql = $"   select p.*from XX_Permission p left join XX_RolePermission rp on p.permissId = rp.permissionId where rp.roleId = {id} and (type = 1 or type = 3)";
            DataTable dt = DBhelper.ExecuteDataTable(sql);
            return ModelConvertHelper<Menu>.ConverModel(dt);
        }
    }
}
