using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TelebotStandBy.Models
{
    public class ThirdInfoModel

    {

        //三方名稱

        public string payName { get; set; }

        //支付url

        public string RedirectURL { get; set; }

        //代付url

        public string WithdrawURL { get; set; }

        //查詢url

        public string WithdrawQueryUrl { get; set; }



        //支付種類

        public string PayChannel { get; set; }

        //支付方式

        public string PayWay { get; set; }

        //備註

        public string remark { get; set; }

        //代付備註

        public string WithdrawRemark { get; set; }

        //支付是否啟用

        public string isEnabled { get; set; }

        //代付是否啟用

        public string WithdrawIsEnabled { get; set; }

    }
}