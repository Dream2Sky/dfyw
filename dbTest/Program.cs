using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.dfyw.entity;
using com.dfyw.common;
using System.Data.Entity;

namespace dbTest
{
    class Program
    {
        static void Main(string[] args)
        {
            DFYW_DbContext db = new DFYW_DbContext();
            Member member = new Member();
            member.Account = "admin";
            member.Password = EncryptManager.SHA1("admin");
            member.Role = 0;

            db.Members.Add(member);
            db.SaveChanges();

        }
    }
}
