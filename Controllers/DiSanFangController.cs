using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelebotStandBy.Models;
using TelebotStandBy.Service.RobotClient;

namespace TelebotStandBy.Controllers
{
    public class DiSanFangController : Controller
    {
        private TelebotCore telebotCore;

        private string _telegramRequest;
        private string TelegramRequest
        {
            get
            {
                if (_telegramRequest == null)
                {
                    _telegramRequest = Request["Serch"].ToString();
                }
                return _telegramRequest;
            }

        }
        public ActionResult Index()
        {
            return Content("");
        }

        //舊機器人街口
        public ActionResult Index2()
        {
            TelegramMessage telegramMessage = JsonConvert.DeserializeObject<TelegramMessage>(TelegramRequest);
            telebotCore = new RobotServiceOld(telegramMessage);
            telebotCore.RobotResponse();
            return Content("OK");
        }

        //新機器人街口
        public ActionResult Index3()
        {

            TelegramMessage telegramMessage = JsonConvert.DeserializeObject<TelegramMessage>(TelegramRequest);
            telebotCore = new RobotService(telegramMessage);
            telebotCore.RobotResponse();
            return Content("OK");
        }
    }
}