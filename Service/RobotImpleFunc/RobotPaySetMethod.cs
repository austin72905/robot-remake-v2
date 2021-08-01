using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotPaySetMethod : ApiMethod, IPaySet
    {
        public RobotPaySetMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void QueryPaySet(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, "查詢三方支付方式~ 我是在 RobotPaySetMethod 實作細節的");
        }

    }
}