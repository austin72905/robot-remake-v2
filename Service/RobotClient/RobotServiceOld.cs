using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TelebotStandBy.Models;

namespace TelebotStandBy.Service.RobotClient
{
    public class RobotServiceOld : TelebotCore
    {
        public override string Token => "1071865921:AAF-yxkGqL3ICDkUsXGhrMXA3r9KjW8be28";

        protected override TelebotReply _telebotReply => new RobotReplyOld(this);

        public RobotServiceOld(TelegramMessage telegramMessage):base(telegramMessage)
        {

        }

        public override void RobotResponse()
        {

            _telebotReply.ReplyToUser();
        }
    }
}