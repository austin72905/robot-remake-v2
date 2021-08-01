using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotWhiteMethod : ApiMethod, IWhite
    {
        public RobotWhiteMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void AddWhite(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "新增白名單~ 是在 RobotWhiteMethod 實作細節");
        }

        public void DeleteWhite(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "刪除白名單~ 是在 RobotWhiteMethod 實作細節");
        }

        public void QueryWhite(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "查詢白名單~ 是在 RobotWhiteMethod 實作細節");
        }

    }
}