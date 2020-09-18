using Admin.XXCommon;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using XXBLL;
using XXCommon;
using XXModels;

namespace Admin.Controllers
{
    
    [ApiBase]
    public class UserController : ApiController
    {
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/user/userreg")]
        public IHttpActionResult UserReg(string userName,string passWord,string passWordAgain)
        {
            //验证不能为空
            int code = 100;
            string msg = "";
            if (string.IsNullOrWhiteSpace(userName))
            {
                msg = "账号不能为空";
            }else if (string.IsNullOrWhiteSpace(passWord)&& string.IsNullOrWhiteSpace(passWordAgain))
            {
                msg = "密码不能为空";
            }
            else if (!passWord.Equals(passWordAgain))
            {
                msg = "输入的密码不一致";
            }
            //验证是否通过规则
            //用户名规范
            else if (XXHelper.UserName(userName) != "")
            {
                msg = XXHelper.UserName(userName);
            }
            //用户名是否存在
            else if (!BLL_User.Instance.UserNameExist(userName))
            {
                msg = "该账号已存在";
            }
            //密码规范
            else if (XXHelper.PassWord(passWord) != "")
            {
                msg = XXHelper.PassWord(passWord);
            }
            //全部通过以后
            else
            {
                User user = new User();
                user.userName = userName;                
                user.randCode = RandomHelper.CreateRandomStr(18);                
                user.guid = Guid.NewGuid().ToString("N").ToUpper();
                user.passWord = RsaHelper.MD5(passWord + user.randCode + user.guid).ToUpper();
                user.userRole = 1;//普通用户
                user.avatarPath = XXHelper.CreateUserAvatarSrc();
                user.name = XXHelper.CreateName();
                //user.email = "";//邮箱
                //user.phone = "";//手机号码
                user.isVip = 0;
                user.vipGrade = 1;
                user.intergral = 0;
                //user.lastLoginTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss:fff");
                user.isFreeze = 0;
                user.isActivation = 0;
                int res = BLL_User.Instance.UserReg(user);
                if (res > 0)
                {
                    msg = "注册成功";
                    code = 200;
                }
            }           
            return Json(new {  code = code, msg = msg});
        }
        
        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="passWord">密码</param>       
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [Route("/api/user/userlogin")]
        public IHttpActionResult UserLogin(string userName,string passWord)
        {
            int code = 100;
            string msg = "登录失败";
            object data=null;
            if (string.IsNullOrWhiteSpace(userName))
            {
                code = 101;
                msg = "账号不能为空";
            }else if (string.IsNullOrWhiteSpace(passWord))
            {
                code = 102;
                msg = "密码不能为空";
            }else
            {
                User user = BLL_User.Instance.GetUser(userName);
                string createPassWord = RsaHelper.MD5(passWord + user.randCode + user.guid).ToUpper();
                if (user.id ==0)
                {
                    code = 102;
                    msg = "用户不存在";
                }
                else if (!user.passWord.Equals(createPassWord))
                {
                    code = 103;
                    msg = "密码错误";
                }
                else
                {
                    //生成token
                    string token = CreateToken(user.id, user.randCode, user.guid);                   
                    if (token == "")
                    {
                        msg = "生成token失败";
                    }
                    else
                    {
                        msg = "登录成功";
                        data = new { id = user.id, token = token };
                    }
                }
            }
            //查询用户是否存在

            return Json(new { code = code, msg = msg,data=data });
        }
        /// <summary>
        /// 生成token 保存token
        /// </summary>
        /// <param name="id">用户id</param>
        /// <param name="randCode">随机码</param>
        /// <param name="guid">guid</param>
        /// <returns></returns>
        public string CreateToken(int id, string randCode,string guid)
        {
            //最新的token是否有效
            Token tokenInfo = BLL_Token.Instance.GetTokenByUid(id);
            string nowTime = DateTime.Now.ToString("yyyyMMddHHmmssffff");            
            if (tokenInfo.expiredTime != null&&long.Parse(tokenInfo.expiredTime) > long.Parse(nowTime))
            {
                return tokenInfo.token;
            }else
            {
                string token = RsaHelper.MD5(randCode + guid).ToUpper();
                string expiredTime = DateTime.Now.AddDays(1).ToString("yyyyMMddHHmmssffff");
                int res = BLL_Token.Instance.CreateToken(id, token, expiredTime);
                return res == 0 ? "" : token;
            }            
        }
        /// <summary>
        /// 查询用户列表
        /// </summary>
        /// <param name="userName">用户名</param>
        /// <param name="name">昵称</param>
        /// <param name="userRole">角色</param>
        /// <param name="isVip">是否vip</param>
        /// <param name="isFreeze">是否冻结</param>
        /// <param name="isActivation">是否激活</param>
        /// <param name="pageSize">分页显示数量</param>
        /// <param name="pageIndex">当前分页</param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/user/UserList")]
        public IHttpActionResult UserList(string userName="",string name="",string userRole="",string isVip="",string isFreeze="",string isActivation="",int pageSize=30,int pageIndex=1)
        {
            int code = 100;
            string msg = "获取用户数据失败";
            StringBuilder sb = new StringBuilder();

            //处理查询条件
            int userRoleInt = userRole == null ? -1 : Convert.ToInt32(userRole);
            int isVipInt = isVip== null ? -1: Convert.ToInt32(isVip);
            int isFreezeInt = isFreeze == null ? -1 : Convert.ToInt32(isFreeze);
            int isActivationInt = isActivation == null ? -1 : Convert.ToInt32(isActivation);


            //构造查询语句
            if (userName != null&& userName!="")
            {
                sb.Append($"and userName='{userName}'");
            }
            if (name != null&& name!="")
            {
                sb.Append($"and name like '%{name}%'");
            }
            if (userRoleInt > -1)
            {
                sb.Append($"and userRole ={userRoleInt}");
            }
            if (isVipInt > -1)
            {
                sb.Append($"and isVip ={isVipInt}");
            }
            if (isFreezeInt > -1)
            {
                sb.Append($"and isFreeze ={isFreeze}");
            }
            if (isActivationInt > -1)
            {
                sb.Append($"and isActivation ={isActivationInt}");
            }

            DataTable dt = BLL_User.Instance.GetUsers(sb.ToString(), pageSize, pageIndex);
            List<User> userList = ModelConvertHelper<User>.ConverModel(dt);
            if (userList.Count > 0 || userList != null)
            {
                 code = 200;
                 msg = "获取用户数据成功";
            }
            return Json(new { code = code, msg = msg, data = new { total = dt.Rows.Count > 0 ? dt.Rows[0]["total"] : 0, userName= userName, pageIndex = pageIndex, pageSize = pageSize, userList = userList } });
        }
        /// <summary>
        /// 编辑用户信息
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("/api/user/UserEdit")]
        public IHttpActionResult UserEdit( EditUser model)
        {
            int code = 100;
            string msg = "编辑失败";
            if (model.id > 0)
            {
                int res = BLL_User.Instance.EditUser(model);
                if (res > 0)
                {
                     code = 200;
                     msg = "编辑成功";
                }
            }
            return Json(new { code = code, msg=msg });
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/api/user/GetUser")]
        public IHttpActionResult GetUser(int id=-1)
        {
            int code = 100;
            string msg = "获取失败";
            EditUser user = new EditUser();
            if (id > -1)
            {
                 user = BLL_User.Instance.UserById(id);
                if (user.id > 0)
                {
                     code = 200;
                     msg = "获取成功";
                }
            }

            return Json(new { code=code,msg=msg,data= new { user=user} });
        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>  
        [HttpPost]
        [Route("/api/user/DeleteUser")]
        public IHttpActionResult DeleteUser(int id=-1)
        {
            int code = 100;
            string msg = "删除失败";
            if (id > -1)
            {
                int res = BLL_User.Instance.DeleteUser(id);
                if (res > 0)
                {
                     code = 200;
                     msg = "删除成功";
                }
            }
            return Json(new { code = code, msg = msg });
        }
    }
}
