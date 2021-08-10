using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotClient;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service
{
    public class RobotReplyOld : TelebotReply
    {
        protected override IReplyToUser _robotFuncCore => new RobotFuncCoreOld(this);

        public RobotReplyOld(TelebotCore telebotCore):base(telebotCore)
        {
            //新增到狀態dic裡
            base.Add(replyHi, replyHiMethod);
        }

        // 舊機器人想拔掉cmder功能
        //這樣改即可
        //protected override bool replyCmder()
        //{
        //    return false;
        //}

        

        //想要新增一個情境 sayHi 情境
        public bool replyHi()
        {
            return _telebotCore.Text.Contains("dick");
        }

        public void replyHiMethod()
        {
            _telebotCore.RobotApi(_telebotCore.UserId,"dick your ass");
        }
        
    }
}