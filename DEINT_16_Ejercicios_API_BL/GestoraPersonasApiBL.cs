using DEINT_16_Ejercicios_API_DAL;
using DEINT_16_Ejercios_API_Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DEINT_16_Ejercicios_API_BL
{
    public class GestoraPersonasApiBL
    {
        GestoraPersonasApi gestoraDal; 
        public GestoraPersonasApiBL() 
        {
            gestoraDal = new GestoraPersonasApi();
        }
        public async Task<List<clsPersona>> ListadoCompletoBL() 
        {
           return await gestoraDal.getListadoPersonasDAL();
        }
        public async Task<System.Net.HttpStatusCode> BorrarPersonaBL(int idTarget) 
        {
           return await gestoraDal.BorrarPersonaDAL(idTarget);
        }
    }
}
