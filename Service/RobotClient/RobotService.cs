using TelebotStandBy.Models;

namespace TelebotStandBy.Service.RobotClient
{
    public class RobotService : TelebotCore
    {
        public override string Token => "";

        protected override TelebotReply _telebotReply => new RobotReply(this);


        //建構子
        public RobotService(TelegramMessage telegramMessage) : base(telegramMessage) { }


        /// <summary>
        /// 主要回應方式
        /// </summary>
        public override void RobotResponse()
        {
            //小於5G警示
            NotifyAvailableSpace("");

            //校驗id
            if (!VerifyUserId(0, ""))
            {

            }

            _telebotReply.ReplyToUser();
        }


    }
}