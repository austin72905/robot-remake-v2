using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotStandBy.Service.RobotFuncManagement
{
    public class RobotFuncCoreOld: RobotFuncCore
    {
        public RobotFuncCoreOld(TelebotReply telebotReply) : base(telebotReply) 
        { 
            
        }

        
        public override void Cmder(int userid)
        {
            _telebotReply.RobotApi(userid,"舊版無此功能");
        }
    }
}