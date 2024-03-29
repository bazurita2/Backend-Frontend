using ApiPrueba.Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiPrueba
{
    public class EmpleadoService
    {
        private IMongoCollection<Empleado> empleados;

        public EmpleadoService(IBarSettings settings)
        {
            var client = new MongoClient(settings.Server);
            var database = client.GetDatabase(settings.Database);

            empleados = database.GetCollection<Empleado>("Empleado");
        }

        public List<Empleado> Get()
        {
            return empleados.Find(d => true).ToList();
        }

        public List<Empleado> FindById(string _id)
        {
            return empleados.Find(d => d.id == _id).ToList();
        }
        public List<Empleado> FindByNombreApellido(string n)
        {
            return empleados.Find(d => d.nombre.ToLower().Contains(n.ToLower()) || d.apellido.ToLower().Contains(n.ToLower())).ToList();
        }


        public List<Empleado> Autentication(string _user, string _passw)
        {
            return empleados.Find(d => d.usuario == _user && d.contrasena == _passw).ToList();
        }

        public Empleado Create(Empleado empleado)
        {
            empleado.usuario = empleado.nombre[0] + empleado.apellido;
            empleado.contrasena = "123";
            empleados.InsertOne(empleado);
            return empleado;
        }

        public void Update(String id, Empleado empleado)
        {
            empleados.ReplaceOne(empleado => empleado.id == id, empleado);
            
        }

        public void Delete(String id)
        {
            empleados.DeleteOne(d => d.id == id);
        }
    }
}
