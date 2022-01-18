using DEINT_16_Ejercios_API_Entidades;
using DEINT_16_Ejercicios_API_BL;
using System;
using System.Collections.Generic;
using System.Text;
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using System.ComponentModel;

namespace DEINT_16_Ejercicos_API_UI.ViewModels
{
    public class ViewModelList : clsVMBase
    {
        #region propiedades privadas
        DelegateCommand cargarLista;
        List<clsPersona> listadoPersonas;
        GestoraPersonasApiBL gestora ;
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); } }

        public DelegateCommand CargarLista { get { return cargarLista = new DelegateCommand(CargarLista_Execute, CargarLista_CanExecute); } }
        #endregion
        #region constructor
        public ViewModelList() 
        {
            listadoPersonas = new List<clsPersona>();
            gestora = new GestoraPersonasApiBL();
        }
        #endregion
        #region CargarLista
        private bool CargarLista_CanExecute()
        {
            return true;
        }

        private void CargarLista_Execute()
        {
            ListadoPersonas = gestora.ListadoCompletoBL().Result;
        }
        #endregion
    }
}
