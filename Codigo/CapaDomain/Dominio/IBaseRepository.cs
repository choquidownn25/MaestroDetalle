using System;
using System.Collections.Generic;
using System.Text;

namespace CapaDomain.Dominio
{
    /**
    * <typeparam name="TEntity">Corresponde a la entidad con la cual van a trabajar los métodos de esta interfaz, por ejemplo: entidad de tipo “Permiso”/”Persona”/”Usuario”.</typeparam>
    * <summary>Interfaz genérica que puede ser utilizado por cualquier entidad.</summary>
    */
    public interface IBaseRepository<TEntity> where TEntity : class
    {
        //Cualquier clase que implemente esta interfaz por debajo también implementa estos métodos
        /**
         * <summary>Método que permite ingresar una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea agregar</param>
         */
        TEntity Add(TEntity entity);

        /**
         * <summary>Método que permite eliminar una entidad</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea eliminar</param>
         */
        TEntity Delete(int id);

        /**
         * <summary>Método que permite actualizar la información una entidad</summary>
         * <param name="entity">Corresponde a la entidad que se desea modificar</param>
         */
        TEntity Modify(TEntity entity);

        /**
         * <summary>Método que permite obtener todos los registros pertenecientes a esa entidad</summary>
         * <returns>Todos los objetos de ese tipo de entidad</returns>
         */
        IEnumerable<TEntity> GetAll();

        /**
         * <summary>Método que permite obtener la información correspondiente a la entidad solicitada</summary>
         * <param name="id">Corresponde al identificador de la entidad que se desea obtener</param>
         * <returns>La información de la correspondiente entidad</returns>
         */
        TEntity GetById(int id);
        /// finalizacion del evento
        void Dispose();
        /// finalizacion del evento
        void Dispose(bool disposing);
    }//Fin de la Interface IBaseRepository

}
