using Example.DAL;
using Example.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Example.BLL
{
    public class SysUserBLL
    {
        private SysUserDAL _dal = null;
        public SysUserDAL dal
        {
            get
            {
                if (_dal == null) _dal = new SysUserDAL();
                return _dal;
            }
        }
        public SysUser GetUserById(int id)
        {
            return dal.GetUserById(id);
        }
    }
}