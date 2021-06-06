using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clinica
{
    abstract class Persona 
    {
        private int dni;
        private string nombre;
        private bool sexo;      //false->Femenino  - true->Masculino
        private string telefono;

       /*public Persona()
        {
        }*/

        public Persona(int dni, string nombre, bool sexo, string telefono)
        {
            this.dni = dni;
            this.nombre = nombre;
            this.sexo = sexo;
            this.telefono = telefono;
        }

        public int pDni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string pTelefono
        {
            get { return telefono; }
            set { telefono = value; }
        }

        public bool pSexo
        {
            get { return sexo; }
            set { sexo = value; }
        }


        public override string ToString() {
            return "Nombre: " + nombre + "|Sexo: " + mostrarSexo() + " |Dni: " + dni.ToString() + " |Contacto: " + telefono;
        }

        private String mostrarSexo()
        {
            String aux = "";
            if (sexo)// if(sexo == true) son equivalentes!
                aux += "| Sexo: M";
            else
                aux += "| Sexo: F";

            return aux;
        }

        public abstract int CalcularRiesgo();

    }
}