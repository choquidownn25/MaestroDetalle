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
    public class StoresRepository : IStores
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Stores Add(Stores entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Stores.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Stores Delete(int id)
        {
            if (id > 0)
            {
                Stores stores = sanaSoftwareContext.Stores.Find(id);
                sanaSoftwareContext.Stores.Remove(stores);
                sanaSoftwareContext.SaveChanges();
                return stores;
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

        public IEnumerable<Stores> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Stores.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Stores GetById(int id)
        {
            Stores brands = sanaSoftwareContext.Stores
                .Where(x => x.StoreId == id)
                .FirstOrDefault();
            return brands;
        }

        public Stores Modify(Stores entity)
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
