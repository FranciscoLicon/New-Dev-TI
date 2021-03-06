﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebListaGenerica.Models.Business.Entitys;
using WebListaGenerica.Models.Data;

namespace WebListaGenerica.Models.Business
{
    public class BusMascota
    {
        DataMascotas datos = new DataMascotas();
        public List<EntMascota> Obtener()
        {
            DataTable dt = datos.Obtener();
            List<EntMascota> ls = new List<EntMascota>();
            foreach(DataRow dr in dt.Rows)
            {
                EntMascota m = new EntMascota();
                m.Nombre = dr["nombre"].ToString();
                m.Raza = dr["raza"].ToString();
                m.Edad = Convert.ToInt32(dr["edad"]);
                m.Especie = dr["especie"].ToString();
                m.Sexo = dr["sexo"].ToString();
                m.FechaAlta = Convert.ToDateTime(dr["fechaAlta"]);
                m.Id_Mascota = Convert.ToInt32(dr["id_mascota"]);

                ls.Add(m);
            }
            return ls;
        }

        public EntMascota Obtener(int id)
        {
            DataRow dr = datos.Obtener(id);
            EntMascota m = new EntMascota();
            m.Nombre = dr["nombre"].ToString();
            m.Raza = dr["raza"].ToString();
            m.Edad = Convert.ToInt32(dr["edad"]);
            m.Especie = dr["especie"].ToString();
            m.Sexo = dr["sexo"].ToString();
            m.FechaAlta = Convert.ToDateTime(dr["fechaAlta"]);
            m.Id_Mascota = Convert.ToInt32(dr["id_mascota"]);
    
            return m;
        }

        public List<EntMascota> Obtener(string nombreMascota)
        {
            DataTable dt = datos.Obtener(nombreMascota);
            List<EntMascota> ls = new List<EntMascota>();
            foreach (DataRow dr in dt.Rows)
            {
                EntMascota m = new EntMascota();
                m.Nombre = dr["nombre"].ToString();
                m.Raza = dr["raza"].ToString();
                m.Edad = Convert.ToInt32(dr["edad"]);
                m.Especie = dr["especie"].ToString();
                m.Sexo = dr["sexo"].ToString();
                m.FechaAlta = Convert.ToDateTime(dr["fechaAlta"]);
                m.Id_Mascota = Convert.ToInt32(dr["id_mascota"]);

                ls.Add(m);
            }
            return ls;
        }

        public void Agregar(EntMascota m)
        {
            m.FechaAlta = DateTime.Now;
            int filas = datos.Agregar(m.Nombre, m.Raza, m.Edad, m.Especie, m.Sexo, m.FechaAlta.ToString("yyyy/MM/dd"), m.NombreRazaEspecie);
            if(filas != 1)
            {
                throw new ApplicationException("Hay error al Agregar " + m.NombreRazaEspecie);
            }
        }

        public void Editar(EntMascota m)
        {
            int filas = datos.Editar(m.Nombre, m.Raza, m.Edad, m.Especie, m.Sexo, m.NombreRazaEspecie, m.Id_Mascota);
            if (filas != 1)
            {
                throw new ApplicationException("Hay error al Editar " + m.NombreRazaEspecie);
            }
        }

        public void Borrar(EntMascota m)
        {
            int filas = datos.Borrar(m.Id_Mascota);
            if (filas != 1)
            {
                throw new ApplicationException("Hay error al Borrar " + m.NombreRazaEspecie);
            }
        }

        public void ValidarNombreRepetidoAgregar(EntMascota m)
        {
            bool existe = datos.ValidarNombreRepetidoAgregar(m.Nombre, m.Raza);
            if (existe)
            {
                throw new ApplicationException("Ya existe una mascota con el mismo nombre y raza" );
            }
        }

        public void ValidarNombreRepetidoEditar(EntMascota m)
        {
            bool existe = datos.ValidarNombreRepetidoEditar(m.Nombre, m.Raza, m.Id_Mascota);
            if (existe)
            {
                throw new ApplicationException("Ya existe una mascota con el mismo nombre y raza");
            }
        }
    }
}