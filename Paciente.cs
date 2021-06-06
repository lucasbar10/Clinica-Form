using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica
{
    class Paciente : Persona
    {
        private string obraSocial;
        private string historiaClinica;

        public Paciente(int dni, string nombre, bool sexo, string telefono, string os, string hc) : base(dni, nombre,sexo, telefono) 
        {
            obraSocial = os;
            historiaClinica = hc;
        }

        public string pObraSocial
        {
            get { return obraSocial; }
            set { obraSocial = value; }
        }
        public string pHistoriaClinica
        {
            get { return historiaClinica; }
            set { historiaClinica = value; }
        }

        public override int CalcularRiesgo()
        {
            if (historiaClinica != null && historiaClinica.ToLower().Contains("febril"))
                return 5;
            return 1;
        }

        public override string ToString()
        {
            //especializando el comportamiento de la clase base:
            return base.ToString() + "|OS: " + obraSocial + " |Historia Clínica: " + historiaClinica ;
        }
    }
}
