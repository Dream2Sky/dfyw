using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dfyw.Ibll;
using com.dfyw.Idal;
using com.dfyw.common;
using com.dfyw.entity;

namespace com.dfyw.bll
{
    public class MemberBLL : IMemberBLL
    {
        private IMemberDAL _memberDAL;
        public MemberBLL(IMemberDAL memberDAL)
        {
            _memberDAL = memberDAL;
        }

        public LoginState Login(string account, string password, ref Member member)
        {
            if (string.IsNullOrEmpty(account))
            {
                return LoginState.empty;
            }

            try
            {
                var m = _memberDAL.SelectByAccount(account);

                if (m == null)
                {
                    return LoginState.account_error;
                }

                if (m.Password != EncryptManager.SHA1(password))
                {
                    return LoginState.password_error;
                }

                member = m;
                return LoginState.success;
            }
            catch (Exception ex)
            {
                LogHelper.writeLog_error(ex.Message);
                LogHelper.writeLog_error(ex.StackTrace);

                member = null;
                return LoginState.failed;
            }
        }
    }
}
