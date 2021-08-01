using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelebotStandBy.Interface
{
    public interface IUser
    {
        void QueryUserID(string who, int userid);

        void AddUser(string who, int userid, string text);

        void DeleteUser(string who, int userid, string text);
    }
}
