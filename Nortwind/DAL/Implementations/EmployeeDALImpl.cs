﻿using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class EmployeeDALImpl : IEmployeeDAL
    {
        private NorthWindContext _northWindContext;
        private UnidadDeTrabajo<Employee> unidad;

        public bool Add(Employee entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new NorthWindContext()))
                {
                    unidad.genericDAL.Add(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void AddRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> Find(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<Employee> Get(int id)
        {
            Employee employee = null;
            using (unidad = new UnidadDeTrabajo<Employee>(new NorthWindContext()))
            {
                employee = await unidad.genericDAL.Get(id);
            }
            return employee;
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            IEnumerable<Employee> employees = null;
            using (unidad = new UnidadDeTrabajo<Employee>(new NorthWindContext()))
            {
                employees = await unidad.genericDAL.GetAll();
            }
            return employees;
        }

        public bool Remove(Employee entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new NorthWindContext()))
                {
                    unidad.genericDAL.Remove(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public void RemoveRange(IEnumerable<Employee> entities)
        {
            throw new NotImplementedException();
        }

        public Employee SingleOrDefault(Expression<Func<Employee, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public bool Update(Employee entity)
        {
            try
            {
                using (unidad = new UnidadDeTrabajo<Employee>(new NorthWindContext()))
                {
                    unidad.genericDAL.Update(entity);
                    unidad.Complete();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}