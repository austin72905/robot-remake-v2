using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TelebotStandBy.Common;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotRecordMethod : ApiMethod, IRecord
    {
        public RobotRecordMethod(IRobotApi robotApi) : base(robotApi) { }
        public void QueryRecord(int userid, string record)
        {
            DataTable dt = Verify.GetPayRecord(record, userid).Tables[0];
            if (dt == null || dt.Rows.Count < 1)
            {
                _robotApi.RobotApi(userid, $"訂單號 {record} 未收到地方通知");
            }
            else
            {
                string thirdName = dt.Rows[0]["PayName"].ToString();
                DateTime dateTime= DateTime.Parse(dt.Rows[0]["Time"].ToString());
                string msg= dt.Rows[0]["Msg"].ToString();
                _robotApi.RobotApi(userid, $"{thirdName} 第三方訂單，已於{dateTime}收到通知。 {msg}");
            }
            
        }

    }
}