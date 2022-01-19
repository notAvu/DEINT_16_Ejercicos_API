using DEINT_16_Ejercios_API_Entidades;
using DEINT_16_Ejercicios_API_BL;
using System;
using System.Collections.Generic;
using System.Text;
using _18_CRUD_Personas_UWP_UI.ViewModels.Utilidades;
using System.ComponentModel;
using Xamarin.Forms;
using System.Net;
using System.Threading.Tasks;

namespace DEINT_16_Ejercicos_API_UI.ViewModels
{
    public class ViewModelList : clsVMBase
    {
        #region propiedades privadas
        bool indicatorState;
        DelegateCommand cargarLista;
        DelegateCommand borrarPersona;
        List<clsPersona> listadoPersonas;
        clsPersona personaSeleccionada;
        GestoraPersonasApiBL gestora ;
        #endregion
        #region propiedades publicas
        public List<clsPersona> ListadoPersonas { get => listadoPersonas; set { listadoPersonas = value; NotifyPropertyChanged("ListadoPersonas"); } }
        public clsPersona PersonaSeleccionada { get => personaSeleccionada; set { personaSeleccionada = value; NotifyPropertyChanged("PersonaSeleccionada"); } }

        public DelegateCommand CargarLista { get { return cargarLista = new DelegateCommand(CargarLista_Execute, CargarLista_CanExecute); } }
        public DelegateCommand BorrarPersona { get { return borrarPersona = new DelegateCommand(BorrarPersona_Execute, BorrarPersona_CanExecute); } }

        public bool IndicatorState { get => indicatorState; set { indicatorState = value; NotifyPropertyChanged("Indicator"); } }

        #region constructor
        public ViewModelList() 
        {
            listadoPersonas = new List<clsPersona>();
            gestora = new GestoraPersonasApiBL();
            indicatorState = false;
        }
        #endregion
        #region
        private bool BorrarPersona_CanExecute()
        {
            return /*personaSeleccionada != null*/ true;
        }

        private async void BorrarPersona_Execute()
        {
            HttpStatusCode httpStatus= new HttpStatusCode();
            bool response = await Application.Current.MainPage.DisplayAlert("Borrar", "Seguro?", "yes","no");
            //TODO preguntar antes de borrar y notificar borrado correcto
            if (response) 
            {
                IndicatorState = true;
                httpStatus = await gestora.BorrarPersonaBL(personaSeleccionada.Id);
                CargarListaPersonas();
                IndicatorState = false;
                if (httpStatus == HttpStatusCode.OK)
                {
                    await Application.Current.MainPage.DisplayAlert("Joya", "Ta Joya", "Perfe");
                }
                else 
                {
                    await Application.Current.MainPage.DisplayAlert("Cagaste", $"Codigo de error{httpStatus}", "Catxis");
                }
            }
        }
        #endregion
        #endregion
        #region CargarLista
        private bool CargarLista_CanExecute()
        {
            return true;
        }

        private void CargarLista_Execute()
        {
            IndicatorState = true;
            CargarListaPersonas();
            IndicatorState = false;
        }

        private async void CargarListaPersonas()
        {
            ListadoPersonas = await gestora.ListadoCompletoBL();
        }
        #endregion
    }
}
