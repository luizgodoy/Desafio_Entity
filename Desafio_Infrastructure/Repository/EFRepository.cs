﻿using Desafio_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Infrastructure.Repository
{
    public class EFRepository<T> : IRepository<T> where T : EntityBase
    {
        protected PostgreContext _context;
        protected DbSet<T> _dbSet;

        public EFRepository(PostgreContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }        

        public void Create(T entidade)
        {
            entidade.DataAtualizacao = DateTime.Now;

            _context.Set<T>().Add(entidade);
            _context.SaveChanges();
        
        }
        public void Update(T entidade)
        {
            _context.Set<T>().Update(entidade);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Set<T>().Remove(GetById(id));
            _context.SaveChanges();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().FirstOrDefault(x => x.Id == id);
        }

        public IList<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
    }
}