using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelebotStandBy.Interface
{
    public interface ICmder : IUser, IWhite
    {
        void Cmder(int userid);

        void CheckCmder(string cmder, int userid, string text, string who, string freespace = "");
    }
}
