using System;
using System.Collections.Generic;
using System.Text;

namespace DEINT_16_Ejercios_API_Entidades
{
    public class clsDepartamento
    {
        string nombre;
        int id;
        public string Nombre { get => nombre; set => nombre = value; }
        public int Id { get => id; set => id = value; }

        public clsDepartamento(int id, string nombre)
        {
            this.Id = id;
            this.Nombre = nombre;
        }
        public clsDepartamento() 
        {
            Nombre = "";
            Id = 0;
        }
    }
}
