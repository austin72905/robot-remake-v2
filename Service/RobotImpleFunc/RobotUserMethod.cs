using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotUserMethod : ApiMethod, IUser
    {
        public RobotUserMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void AddUser(string who, int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "新增用戶 ~ 是在 RobotUserMethod 實作細節");
        }

        public void DeleteUser(string who, int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "刪除用戶 ~ 是在 RobotUserMethod 實作細節");
        }

        public void QueryUserID(string who, int userid)
        {
            _robotFuncCore.RobotApi(userid, "查詢用戶 ~ 是在 RobotUserMethod 實作細節");
        }

    }
}