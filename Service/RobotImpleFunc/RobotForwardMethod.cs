using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotForwardMethod : ApiMethod, IForward
    {
        public RobotForwardMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void RobotAddWhite(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, text);
        }

    }
}