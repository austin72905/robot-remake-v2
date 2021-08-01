using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service
{
    public abstract class ApiMethod
    {
        protected RobotFuncCore _robotFuncCore;
        public ApiMethod(RobotFuncCore robotFuncCore)
        {
            _robotFuncCore = robotFuncCore;
        }


        /// <summary>
        /// 為了能夠在不耦合telebotCore 類 的情況下使用 robotapi
        /// </summary>
        protected void RobotApi(int userid, string text)
        {
            _robotFuncCore.RobotApi(userid, text);
        }
    }
}