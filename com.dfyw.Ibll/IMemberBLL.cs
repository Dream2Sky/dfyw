﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dfyw.common;
using com.dfyw.entity;

namespace com.dfyw.Ibll
{
    public interface IMemberBLL
    {
        LoginState Login(string account, string password, ref Member member);
        IEnumerable<Member> GetUsersByRole(int role);
        OperatorState AddMember(string name, int role, string parent, ref Member member);
    }
}
