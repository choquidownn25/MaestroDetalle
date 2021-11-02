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
    public class CategoriesRepository : ICategories
    {
        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        /// <summary>
        /// Motodo agregar
        /// </summary>
        /// <param name="entity"></param>
        public Categories Add(Categories entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Categories.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }
        /// <summary>
        /// Eliminar dato de la tabla Alumno
        /// </summary>
        /// <param name="id"></param>
        public Categories Delete(int id)
        {
            if (id > 0)
            {
                Categories categories = sanaSoftwareContext.Categories.Find(id);
                sanaSoftwareContext.Categories.Remove(categories);
                sanaSoftwareContext.SaveChanges();
                return categories;
            }
            else
                throw new ArgumentException("Debe ingresar un numero valido");
        }
        /// <summary>
        /// Metedo liberacion Memoria
        /// </summary>
        public void Dispose()
        {
            // Elimine los recursos no administrados.
            Dispose(true);
            // Suppress finalization.
            GC.SuppressFinalize(this);
        }
        /// <summary>
        /// finalizacion del evento
        /// </summary>
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
        /// <summary>
        /// Muestra todos los datos de la tabla
        /// </summary>
        /// <returns>Valores a mostrar</returns>
        public IEnumerable<Categories> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Categories.ToList(); // Return the list of data from the database
                return data;
            }
        }
        /// <summary>
        /// Metodo buscar por Brands
        /// </summary>
        /// <param name="id">Parametro para buscar</param>
        /// <returns></returns>
        public Categories GetById(int id)
        {
            Categories alumno = sanaSoftwareContext.Categories
                .Where(x => x.CategoryId == id)
                .FirstOrDefault();
            return alumno;
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entity">Parametro</param>
        public Categories Modify(Categories entity)
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
