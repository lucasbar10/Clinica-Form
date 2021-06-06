using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica
{
    class Clinica
    {
        private string razonSocial;
        private Persona[] personas;

        public Clinica(string razonSocial, int cant)
        {
            this.razonSocial = razonSocial;
            this.personas = new Persona[cant];
        }
        public string pRazonSocial
        {
            get { return razonSocial; }
            set { razonSocial = value; }
        }

        public void registrarPersona(Persona oPersona)
        {
            for (int i = 0; i < personas.Length; i++)//desde 0 a 49 inclusive
            {
                if (personas[i] == null)
                {
                    personas[i] = oPersona;
                    break; //corta el ciclo 
                }
            }
        }

        public string CalcularNivelRiesgo() {
            string nivelRiesgo = "BAJO";
            int riesgo = 0;

            foreach (Persona oPersona in personas) {
                if(oPersona != null)    
                    riesgo += oPersona.CalcularRiesgo();
            }

            if (riesgo >= 10)
                nivelRiesgo = "ALTO";
            else if (riesgo > 3)
                nivelRiesgo = "MEDIO";

            return nivelRiesgo;
        }
    }
}
