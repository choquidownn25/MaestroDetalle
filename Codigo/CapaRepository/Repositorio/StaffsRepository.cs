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
    public class StaffsRepository : IStaffs
    {

        #region Atributos
        productionContext sanaSoftwareContext = new productionContext();
        private TextReader reader;
        private bool disposed = false; //Para detectar llamadas redundantes
        #endregion

        public Staffs Add(Staffs entity)
        {
            if (entity != null)
            {
                sanaSoftwareContext.Staffs.Add(entity);
                sanaSoftwareContext.SaveChanges();
                return entity;
            }
            else
                throw new ArgumentNullException(paramName: nameof(entity), message: "Entidad no pueden ser null algunos de los campos");

        }

        public Staffs Delete(int id)
        {
            if (id > 0)
            {
                Staffs staffs = sanaSoftwareContext.Staffs.Find(id);
                sanaSoftwareContext.Staffs.Remove(staffs);
                sanaSoftwareContext.SaveChanges();
                return staffs;
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

        public IEnumerable<Staffs> GetAll()
        {
            using (var context = new productionContext())
            {
                var data = context.Staffs.ToList(); // Return the list of data from the database
                return data;
            }
        }

        public Staffs GetById(int id)
        {
            Staffs staffs = sanaSoftwareContext.Staffs
               .Where(x => x.StaffId == id)
               .FirstOrDefault();
            return staffs;
        }

        public Staffs Modify(Staffs entity)
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
