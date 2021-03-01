using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebListaGenerica.Models.Business.Entitys
{
    public class EntMascota
    {
        public int Id_Persona { get; set; }

        public string Nombre { get; set; }

        public string Raza { get; set; }

        public int Edad { get; set; }

        public string Especie { get; set; }

        public string Sexo { get; set; }

        public DateTime FechaAlta { get; set; }

        private string nombreRazaEspecie;

        public string NombreRazaEspecie
        {
            get {
                nombreRazaEspecie = $"{Nombre}{Raza}{Especie}";
                return nombreRazaEspecie;
            }
            set { nombreRazaEspecie = value; }
        }

    }
}