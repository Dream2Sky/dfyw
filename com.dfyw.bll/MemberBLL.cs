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

        public OperatorState AddMember(string name, int role, string parent, ref Member member)
        {
            var m = _memberDAL.SelectByAccount(name);
            if (m != null)
            {
                return OperatorState.repeat;
            }

            Member me = new Member();
            me.Account = name;
            me.IsDeleted = false;
            me.Password = EncryptManager.SHA1("123456");

            me.Role = role;
            try
            {
                me.ParentId = role == 2 ? _memberDAL.SelectByAccount(parent).Id : Guid.Empty;
            }
            catch (Exception ex)
            {
                LogHelper.writeLog_error(ex.Message);
                LogHelper.writeLog_error(ex.StackTrace);

                return OperatorState.error;
            }

            if (_memberDAL.Insert(me))
            {
                member = me;
                return OperatorState.success;
            }
            else
            {
                return OperatorState.error;
            }
        }

        public IEnumerable<Member> GetUsersByRole(int role)
        {
            return _memberDAL.SelectByRoles(role);
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
