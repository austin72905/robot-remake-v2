using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelebotStandBy.Service.RobotClient;

namespace TelebotStandBy.Interface
{
    public interface IReplyStrategy
    {
        void ReplyContent(TelebotCore telebotCore);
    }
}
