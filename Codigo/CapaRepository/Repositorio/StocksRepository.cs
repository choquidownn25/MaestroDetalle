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
    public class StocksRepository : IStocks
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Stocks Add(Stocks entity)
        {
            if(entity != null)
            {
                sanaSoftwareContext.Stocks.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Stocks Delete(int id)
        {
            if (id > 0)
            {
                Stocks stocks = sanaSoftwareContext.Stocks.Find(id);
                sanaSoftwareContext.Stocks.Remove(stocks);
                sanaSoftwareContext.SaveChanges();
                return stocks;
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

        public IEnumerable<Stocks> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Stocks.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Stocks GetById(int id)
        {
            Stocks stocks = sanaSoftwareContext.Stocks
               .Where(x => x.StoreId == id)
               .FirstOrDefault();
            return stocks;
        }

        public Stocks Modify(Stocks entity)
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
