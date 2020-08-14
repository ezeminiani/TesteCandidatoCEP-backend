using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TesteCandidatoCEP.Domain.Base;

namespace TesteCandidatoCEP.Repository.Generic
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly TesteCandidatoCEPContext ctx;
        private DbSet<T> dataset;

        /// <summary>
        /// Construtor.
        /// </summary>
        /// <param name="ctx"></param>
        public GenericRepository(TesteCandidatoCEPContext ctx)
        {
            this.ctx = ctx;
            dataset = this.ctx.Set<T>();
        }


        /// <summary>
        /// Grava a entidade.
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<T> Create(T item)
        {
            try
            {
                dataset.Add(item);
                await this.ctx.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }


        /// <summary>
        /// Remove a entidade.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> Delete(int id)
        {
            var result = dataset.FirstOrDefaultAsync(i => i.Id.Equals(id)).Result;

            try
            {
                if (result != null) dataset.Remove(result);
                return (await this.ctx.SaveChangesAsync()) > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// Verifica se a entidade existe.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public virtual async Task<bool> Exists(int? id)
        {
            return await dataset.AnyAsync(a => a.Id.Equals(id));
        }


        /// <summary>
        /// Retorna todas as entidades.
        /// </summary>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        public virtual async Task<List<T>> FindAllAsync(bool asNoTracking = false)
        {
            if (asNoTracking)
                return await dataset.AsNoTracking().ToListAsync();
            else
                return await dataset.ToListAsync();
        }


        /// <summary>
        /// Retorna a entidade pelo seu ID.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="asNoTracking"></param>
        /// <returns></returns>
        public virtual async Task<T> FindByIdAsync(int id, bool asNoTracking = false)
        {
            if (asNoTracking)
                return await dataset.AsNoTracking().FirstOrDefaultAsync(p => p.Id.Equals(id));
            else
                return await dataset.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public virtual async Task<T> Update(T item)
        {
            if (!Exists(item.Id).Result) return null;

            var result = dataset.FirstOrDefaultAsync(i => i.Id.Equals(item.Id)).Result;

            if (result != null)
            {
                try
                {
                    this.ctx.Entry(result).CurrentValues.SetValues(item);
                    await this.ctx.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            return result;
        }
    }
}
