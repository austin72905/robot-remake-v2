using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotRecordMethod : ApiMethod, IRecord
    {
        public RobotRecordMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }
        public void QueryRecord(int userid, string record)
        {
            _robotFuncCore.RobotApi(userid, "查詢訂單號~ 我是在 RobotRecordMethod 實作細節的");
        }

    }
}