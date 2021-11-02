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
    public class OrdersRepository : IOrders
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Orders Add(Orders entity)
        {
            if(entity != null)
            {
                sanaSoftwareContext.Orders.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Orders Delete(int id)
        {
            if (id > 0)
            {
                Orders orders = sanaSoftwareContext.Orders.Find(id);
                sanaSoftwareContext.Orders.Remove(orders);
                sanaSoftwareContext.SaveChanges();
                return orders;
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

        public IEnumerable<Orders> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Orders.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Orders GetById(int id)
        {
            Orders orders = sanaSoftwareContext.Orders
               .Where(x => x.OrderId == id)
               .FirstOrDefault();
            return orders;
        }

        public Orders Modify(Orders entity)
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
