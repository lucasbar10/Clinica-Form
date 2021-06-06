using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica
{
    class Medico : Persona
    {
        private string especialidad;
        private double costoConsulta;

        public Medico(int dni, string nombre, bool sexo, string telefono, string esp, double costo) :base(dni, nombre, sexo, telefono)
        {
            this.especialidad = esp;
            this.costoConsulta = costo;
        }

        public string pEspecialidad
        {
            get { return especialidad; }
            set { especialidad = value; }
        }

        public double pCostoConsulta
        {
            get { return costoConsulta; }
            set { costoConsulta = value; }
        }

        public override int CalcularRiesgo()
        {
            if (especialidad != null && especialidad.ToLower().Equals("cardiología"))
                return 3;
            return 1;
        }

        public override string ToString() {
            return "Medico| Especialidad: " + especialidad;
        }



    }
}
