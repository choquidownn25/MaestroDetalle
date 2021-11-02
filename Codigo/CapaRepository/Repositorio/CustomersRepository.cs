using CapaConexion.Models;
using CapaService.Servicio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace CapaRepository.Repositorio
{
    public class CustomersRepository : ICustomers
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Customers Add(Customers entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Customers.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");
        }

        public Customers Delete(int id)
        {
            if (id > 0)
            {
                Customers brands = sanaSoftwareContext.Customers.Find(id);
                sanaSoftwareContext.Customers.Remove(brands);
                sanaSoftwareContext.SaveChanges();
                return brands;
            }
            else
                throw new ArgumentException("Debe ingresar un numero valido");
        }

        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }

        public void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    if (reader != null)
                    {
                        reader.Dispose();
                    }
                }

                disposed = true;
            }
        }

        public IEnumerable<Customers> GetAll()
        {

            using (var context = new productionContext())
            {
                var data = context.Customers.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Customers GetById(int id)
        {
            Customers brands = sanaSoftwareContext.Customers
                .Where(x => x.CustomerId == id)
                .FirstOrDefault();
            return brands;
        }

        public Customers Modify(Customers entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Entry(entity).State = EntityState.Modified;
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }
    }
}
