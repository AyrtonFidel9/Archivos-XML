using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace WpfAppDataSet.Clases
{
    class Validaciones: IDataErrorInfo
    {
        private string _nombre;
        private string apellido;
        private string _cedula;
        private string telefono;
        private string direccion;
        private string email;
        private string numero;
        private string caracteres;
        private string otros;
        private string id;



        string IDataErrorInfo.Error
        {
            get
            {
                return null;
            }
        }

        public string Nombre { get => this._nombre; set => this._nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Cedula { get => this._cedula; set => this._cedula = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Email { get => email; set => email = value; }
        public string Numero { get => numero; set => numero = value; }
        public string Caracteres { get => caracteres; set => caracteres = value; }
        public string Otros { get => otros; set => otros = value; }
        public string Id { get => id; set => id = value; }

        string IDataErrorInfo.this[string columnName]
        {
            get
            {
                string result = null;
                if (columnName == "Nombre")
                {
                    if (!cadenas(_nombre))
                    {
                        result = "No se admiten valores numéricos o campos vacíos.";
                    }
                }
                if (columnName == "Caracteres")
                {
                    if (!cadenas(caracteres))
                    {
                        result = "No se admiten valores numéricos o campos vacíos.";
                    }
                }
                
                
                if (columnName == "Numero")
                {
                    if (!numeros(numero))
                    {
                        result = "No se admiten caracteres o campos vacíos.";
                    }

                }

                if(columnName == "Id")
                {
                    if(!idValidacion(id))
                    {
                        result = "El ID debe contener 4 dígitos y no se admiten campos vacíos.";
                    }
                }


                if (columnName == "Apellido")
                {
                    if (!cadenas(apellido))
                    {
                        result = "No se admiten valores numéricos o campos vacíos.";
                    }
                }

                if (columnName == "Cedula")
                {
                    if (!cedula(_cedula))
                    {
                        result = "No se admiten caracteres o campos vacíos.";

                    }
                    if (!tamanio(_cedula))
                    {
                        result = "La cédula debe contener 10 dígitos.";
                    }
                }
                if (columnName == "Otros" || columnName == "RchOtros")
                {
                    if (!camposVacios(otros))
                    {
                        result = "No se admiten campos vacíos.";
                    }
                }

                if (columnName == "Telefono")
                {
                    if (!cedula(telefono))
                    {
                        result = "No se admiten caracteres o campos vacíos.";

                    }
                    if (!tamanio(telefono))
                    {
                        result = "El teléfono debe contener 10 dígitos.";
                    }
                }
                /*
                if (columnName == "Direccion")
                {
                    if (string.IsNullOrEmpty(direccion))
                    {
                        result = "No se admiten campos vacíos.";
                    }
                }
                if (columnName == "Email")
                {
                    if (!camposVacios(email))
                    {
                        result = "No se admiten campos vacíos.";
                    }
                    if (!email_bien_escrito(email))
                    {
                        result = "E-mail no válido.";
                    }
                }*/

                return result;
            }
        }

        public bool cadenas(string nom)
        {
            if (string.IsNullOrEmpty(nom))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < nom.Length; i++)
                {
                    if ((int)nom[i] >= 48 && (int)nom[i] <= 57)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public bool idValidacion (string ids)
        {
            if (string.IsNullOrEmpty(ids))
            {
                return false;
            }
            else
            {
                if(ids.Length != 4)
                {
                    return false;
                }
            }
            return true;
        }
        public bool cedula(string ced)
        {
            if (string.IsNullOrEmpty(ced))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < ced.Length; i++)
                {
                    if (!((int)ced[i] >= 48 && (int)ced[i] <= 57))
                    {
                        return false;

                    }
                }
            }
            return true;
        }

        public bool tamanio(string valor)
        {
            if (!string.IsNullOrEmpty(valor))
            {
                if (valor.Length > 10)
                {
                    return false;
                }
                if (valor.Length < 10)
                {
                    return false;
                }
                return true;
            }
            return true;
        }

        public bool numeros(string valor)
        {
            if (!camposVacios(valor))
            {
                return false;
            }
            else
            {
                for (int i = 0; i < valor.Length; i++)
                {
                    if (!((int)valor[i] >= 48 && (int)valor[i] <= 57))
                    {
                        return false;

                    }
                }
            }


            return true;
        }
        /*
        public bool email_bien_escrito(String email)
        {
            if (!string.IsNullOrEmpty(email))
            {
                String expresion;
                expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
                if (Regex.IsMatch(email, expresion))
                {
                    if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        

        }*/
        public bool camposVacios(string valor)
        {
            if (string.IsNullOrEmpty(valor))
            {
                return false;
            }
            return true;
        }
    }
}
