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
    public class OrderItemsRepository : IOrderItems
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public OrderItems Add(OrderItems entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.OrderItems.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public OrderItems Delete(int id)
        {
            if (id > 0)
            {
                OrderItems orderItems = sanaSoftwareContext.OrderItems.Find(id);
                sanaSoftwareContext.OrderItems.Remove(orderItems);
                sanaSoftwareContext.SaveChanges();
                return orderItems;
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

        public IEnumerable<OrderItems> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.OrderItems.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public OrderItems GetById(int id)
        {
            OrderItems orderItems = sanaSoftwareContext.OrderItems
               .Where(x => x.ItemId== id)
               .FirstOrDefault();
            return orderItems;
        }

        public OrderItems Modify(OrderItems entity)
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
