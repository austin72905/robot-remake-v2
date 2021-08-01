using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotUrlMethod : ApiMethod, IPayUrl
    {
        public RobotUrlMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void QueryPayUrl(int userid, string payUrl)
        {
            _robotFuncCore.RobotApi(userid, "查網關~ 我是在RobotUrlMethod 實作細節的");
        }

    }
}