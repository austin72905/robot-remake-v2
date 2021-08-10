using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using TelebotStandBy.Models;

namespace TelebotStandBy.Service.RobotClient
{
    public abstract class TelebotCore
    {
        //每個機器人獨一無二的token
        public abstract string Token { get; }
        //自訂要判斷的情境
        protected abstract TelebotReply _telebotReply { get; }

        //三方名稱
        private List<string> _payName;
        public virtual List<string> PayName
        {
            get
            {
                if (_payName == null)
                {
                    _payName = new List<string>() { "支付1", "支付2", "支付3" };
                }
                return _payName;
            }
            set
            {

            }
        }


        public TelebotCore(TelegramMessage telegramMessage)
        {
            UserId = telegramMessage.message.from.id;
            Text = telegramMessage.message.text;
            FirstName = telegramMessage.message.from.first_name;
            Sticker = telegramMessage.message.sticker;
            Reply_To_Message = telegramMessage.message.reply_to_message;
            Forward_From = telegramMessage.message.forward_from;

            UserLevel = CheckLvl(UserId);
        }

        //以下為核心方法

        public abstract void RobotResponse();

        /// <summary>
        /// 校驗用戶ID
        /// </summary>
        /// <param name="Userid"></param>
        /// <param name="text"></param>
        /// <returns></returns>
        public virtual bool VerifyUserId(int Userid, string text)
        {
            return true;
        }

        /// <summary>
        /// 確認用戶等級
        /// </summary>
        /// <param name="Userid"></param>
        /// <returns></returns>
        public virtual string CheckLvl(int Userid)
        {
            return "2";
        }

        public virtual void NotifyAvailableSpace(string freesapce)
        {

        }

        public void RobotApi(int chat_id, string text)
        {
            Task.Run(async () =>
            {
                var httpclient = new HttpClient();
                string baseUrl = "https://api.telegram.org/bot";
                var postdata = new Dictionary<string, string>()
                {
                    { "chat_id",chat_id.ToString()},
                    { "text",text},
                    { "parsr_mode","HTML"}
                };
                string url = $"{baseUrl}{Token}/sendMessage";

                var content = new FormUrlEncodedContent(postdata);
                var response = await httpclient.PostAsync(url, content);
            });
        }


        
        public int UserId { get; }
        public string Text { get; }
        public string FirstName { get; }
        public Sticker Sticker { get; }
        public Reply_To_Message Reply_To_Message { get; }
        public Forward_From Forward_From { get; }
        public string UserLevel { get; }
        public int RespContent { get; }
    }
}