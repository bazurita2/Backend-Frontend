using Cliente.DAL;
using Cliente.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cliente.BLL
{
    public class UsuarioBLL
    {
        private readonly UsuarioDAL DAL = new UsuarioDAL();
        public IEnumerable<UsuarioModel> listarUsuarios()
        {
            return DAL.listarUsuarios();
        }
    }
}