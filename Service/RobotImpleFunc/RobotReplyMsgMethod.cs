using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Interface;
using TelebotStandBy.Models;
using TelebotStandBy.Service.RobotFuncManagement;

namespace TelebotStandBy.Service.RobotImpleFunc
{
    public class RobotReplyMsgMethod : ApiMethod, IReply_To_Message
    {
        public RobotReplyMsgMethod(RobotFuncCore robotFuncCore) : base(robotFuncCore) { }


        public void ReplyMessage(Reply_To_Message reply, string text, Sticker sticker)
        {
            _robotFuncCore.RobotApi(int.Parse(text), text);
        }

    }
}