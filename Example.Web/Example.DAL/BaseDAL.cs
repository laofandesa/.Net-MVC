using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityFramework.Extensions;
using Example.Model;

namespace Example.DAL
{
    public class BaseDAL<T> where T : class
    {
        private ExampleEntities _db = null;
        public ExampleEntities db
        {
            get
            {
                if (_db == null) _db = new ExampleEntities();
                return _db;
            }
        }

        public virtual IQueryable<T> Entities
        {
            get { return db.Set<T>().AsNoTracking(); }
        }

        public virtual IQueryable<T> Table
        {
            get { return db.Set<T>(); }
        }
        public IList<T> GetAll(Expression<Func<T, bool>> exp)
        {
            var query = db.Set<T>().Where(exp).AsNoTracking();
            IList<T> data = query.ToList();
            return data;
        }

        public int Add(T model)
        {
            try
            {
                EntityState state = db.Entry(model).State;
                if (state == EntityState.Detached)
                {
                    db.Entry(model).State = EntityState.Added;
                }
                //db.Set<T>().Add(model);
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 批量添加
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int AddCollect(List<T> models)
        {
            try
            {
                foreach (T model in models)
                {
                    EntityState state = db.Entry(model).State;
                    if (state == EntityState.Detached)
                    {
                        db.Entry(model).State = EntityState.Added;
                    }
                }
                //db.Set<T>().Add(model);
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
        public int Edit(T model)
        {
            try
            {
                try
                {
                    db.Set<T>().Attach(model);
                }
                catch { }
                db.Entry(model).State = EntityState.Modified;
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 批量修改
        /// </summary>
        /// <param name="models"></param>
        /// <returns></returns>
        public int EditCollect(List<T> models)
        {
            try
            {
                foreach (T model in models)
                {
                    try
                    {
                        EntityState state = db.Entry(model).State;
                        db.Set<T>().Attach(model);
                    }
                    catch { }
                    db.Entry(model).State = EntityState.Modified;
                }
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 修改操作,可以只更新部分列，效率高
        /// </summary>
        /// <param name="funWhere">查询条件-谓语表达式</param>
        /// <param name="funUpdate">实体-谓语表达式</param>
        /// <returns>操作影响的行数</returns>
        public virtual int Edit(Expression<Func<T, bool>> funWhere, Expression<Func<T, T>> funUpdate)
        {
            return Entities.Where(funWhere).Update(funUpdate);
        }
        public int Delete(T model)
        {
            try
            {
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Entry(model).State = EntityState.Deleted;
                db.Configuration.AutoDetectChangesEnabled = true;
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
        public int DeleteExp(Expression<Func<T, bool>> exp)
        {
            try
            {
                var q = db.Set<T>().Where(exp);
                db.Configuration.AutoDetectChangesEnabled = false;
                db.Set<T>().RemoveRange(q);
                db.Configuration.AutoDetectChangesEnabled = true;
                return db.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                string errmsg = "";
                foreach (var item in ex.EntityValidationErrors.First().ValidationErrors)
                {
                    errmsg += item.ErrorMessage + " ; ";
                }
                throw new Exception(errmsg);
            }
            finally
            {

            }
        }
    }
}