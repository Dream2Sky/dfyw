using com.dfyw.entity;
using com.dfyw.Idal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.dfyw.dal
{
    public class MemberDAL : DataBaseDAL<Member>, IMemberDAL
    {
        public Member SelectByAccount(string account)
        {
            try
            {
                return db.Set<Member>().Where(n => n.Account == account).SingleOrDefault();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
