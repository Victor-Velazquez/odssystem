using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ODS.DataLayer
{
    public class UsersRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetRolesForUser(string username)
        {
            //ODS.DataLayer.Modelo db = new Modelo();
            IQueryable<ods_interesado> ods_Interesado_encontrado = null;
            List<string> roles = new List<string>();
            ods_interesado ods_interesado = null;

            using (Modelo db = new ODS.DataLayer.Modelo())
            {
                ods_Interesado_encontrado = from p in db.ods_interesado where (username == p.Usuario) select p;
                ods_interesado = ods_Interesado_encontrado.First();

                if (ods_interesado.SuperUsuario && !ods_interesado.Administrador)
                    roles.Add("SuperUsuario");

                if (ods_interesado.Administrador && !ods_interesado.SuperUsuario)
                    roles.Add("Administrador");

                if (!ods_interesado.SuperUsuario && !ods_interesado.Administrador)
                    roles.Add("Usuario");

                //var userRoles = (from user in context.Users
                //                 join roleMapping in context.UserRolesMappings
                //                 on user.ID equals roleMapping.UserID
                //                 join role in context.RoleMasters
                //                 on roleMapping.RoleID equals role.ID
                //                 where user.UserName == username
                //                 select role.RollName).ToArray();
                
                return roles.ToArray();
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
