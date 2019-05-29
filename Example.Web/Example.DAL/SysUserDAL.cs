using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Example.Model;

namespace Example.DAL
{
    public class SysUserDAL : BaseDAL<SysUser>
    {
        public SysUser GetUserById(int id)
        {
            return Entities.Where(o => o.ID == id).FirstOrDefault();
        }
    }
}