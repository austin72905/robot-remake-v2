using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelebotStandBy.Interface
{
    public interface IWhite
    {
        void QueryWhite(int userid, string text);

        void AddWhite(int userid, string text);

        void DeleteWhite(int userid, string text);
    }
}
