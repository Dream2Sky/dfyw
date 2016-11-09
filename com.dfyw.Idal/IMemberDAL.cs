using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dfyw.entity;

namespace com.dfyw.Idal
{
    public interface IMemberDAL:IDataBaseDAL<Member>
    {
        Member SelectByAccount(string account);
        IEnumerable<Member> SelectByRoles(int role);
    }
}
