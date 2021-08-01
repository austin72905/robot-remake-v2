using System;
using TelebotStandBy.Interface;
using TelebotStandBy.Service.RobotClient;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service
{
    public class RobotReply : TelebotReply
    {
        public RobotReply(TelebotCore telebotCore) : base(telebotCore) { }

        protected override IReplyToUser _robotFuncCore => new RobotFunc(this);
    }
}