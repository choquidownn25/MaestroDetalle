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
    public class ProductsRepository : IProducts
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Products Add(Products entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Products.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Products Delete(int id)
        {
            if (id > 0)
            {
                Products products = sanaSoftwareContext.Products.Find(id);
                sanaSoftwareContext.Products.Remove(products);
                sanaSoftwareContext.SaveChanges();
                return products;
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

        public IEnumerable<Products> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Products.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Products GetById(int id)
        {
            Products brands = sanaSoftwareContext.Products
               .Where(x => x.ProductId == id)
               .FirstOrDefault();
            return brands;
        }

        public Products Modify(Products entity)
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
