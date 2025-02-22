using System.Collections.Generic;

namespace GestionEntrenamientos
{
    public class GestorUsuario
    {
        private List<Usuario> usuarios = new List<Usuario>();
        public Usuario? UsuarioActual { get; private set; }

        public bool RegistrarUsuario(string correo, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Correo == correo)
                    return false;
            }

            usuarios.Add(new Usuario(correo, contraseña));
            return true;
        }

        public bool IniciarSesion(string correo, string contraseña)
        {
            foreach (var usuario in usuarios)
            {
                if (usuario.Correo == correo && usuario.ValidarContraseña(contraseña))
                {
                    UsuarioActual = usuario;
                    return true;
                }
            }
            return false;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }
    }
}