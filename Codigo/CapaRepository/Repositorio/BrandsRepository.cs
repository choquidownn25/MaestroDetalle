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
    public class BrandsRepository : IBrands
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
        public Brands Add(Brands entity)
        {
            if(entity !=null)
            {
                sanaSoftwareContext.Brands.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");
        }
        /// <summary>
        /// Eliminar dato de la tabla Alumno
        /// </summary>
        /// <param name="id"></param>
        public Brands Delete(int id)
        {
            if (id > 0)
            {
                Brands brands = sanaSoftwareContext.Brands.Find(id);
                sanaSoftwareContext.Brands.Remove(brands);
                sanaSoftwareContext.SaveChanges();
                return brands;
            }else
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
        public IEnumerable<Brands> GetAll()
        {
            var dato = sanaSoftwareContext.Brands.ToList();
            return  sanaSoftwareContext.Brands.ToList();
        }
        /// <summary>
        /// Metodo buscar por Brands
        /// </summary>
        /// <param name="id">Parametro para buscar</param>
        /// <returns></returns>
        public Brands GetById(int id)
        {
            Brands brands = sanaSoftwareContext.Brands
                .Where(x => x.BrandId == id)
                .FirstOrDefault();
            return brands;
        }
        /// <summary>
        /// Modificar
        /// </summary>
        /// <param name="entity">Parametro</param>
        public Brands Modify(Brands entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Entry(entity).State = EntityState.Modified;
                sanaSoftwareContext.SaveChanges();
                return entity;
            }else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }
    }
}
