using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ODS.DataLayer
{
    public enum RolesPermisos
    {
        #region Alumnos
        Alumno_Puede_Crear_Nuevo_Registro = 2,
        Alumno_Puede_Eliminar_Registro = 3,
        Alumno_Puede_Visualizar_Un_Alumno = 4,
        #endregion
    }

    public class FrontUser
    {

        //public static bool ValidarAcceso(string usuario, string password)
        //{
        //    string hash_password = Cifrar(password);
        //}


        public static bool TienePermiso(RolesPermisos valor)
        {
            //var usuario = FrontUser.Get();
            //return !usuario.Rol.Permiso.Where(x => x.PermisoID == valor)
            //                   .Any();
            return true;
        }

        //public static Usuario Get()
        //{
        //    return new Usuario().Obtener(SessionHelper.GetUser());
        //}

        private string Cifrar(string valor)
        {
            SHA256 sha256 = new SHA256CryptoServiceProvider();

            byte[] inputBytes = (new UnicodeEncoding()).GetBytes(valor);
            byte[] hash = sha256.ComputeHash(inputBytes);

            return Convert.ToBase64String(hash);
        }

    }
}
