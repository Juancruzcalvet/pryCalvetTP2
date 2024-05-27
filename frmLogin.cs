using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pryCalvetTP2
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        DateTime Fecha;
        int contadorInicio = 0;
        String Usuario;
        String Contraseña;
        String Perfil;

        clsUsuario objUsuario = new clsUsuario();
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario = txtUsuario.Text;
            Contraseña = txtContraseña.Text;
            objUsuario.ValidarUsuario(Usuario, Contraseña);
            if(objUsuario.Logged == true)
            {
                objUsuario.RegistroLogInicioSesion();
                MessageBox.Show("Conectado");
                label3.Visible = true;
                comboBox1.Visible = true;       //solo se podra registrar nuevos usuarios tras inciar sesion con cualquier ususario
                btnRegistrar.Visible = true;
            }
            else
            {
                MessageBox.Show("Error al inciar");
                contadorInicio++;
                if(contadorInicio > 3)  //Sacamos a los 3 errores de inicio
                {
                    btnLogin.Enabled = false;
                }
            }

        }

        private void btnRegistrar_Click(object sender, EventArgs e)
        {
            Usuario = txtUsuario.Text;
            Contraseña = txtContraseña.Text;
            Perfil = comboBox1.Text;
            objUsuario.CrearCuenta(Usuario, Contraseña, Perfil);
            objUsuario.RegistroLogCrearCuenta();
            MessageBox.Show("Usuario registrado exitosamente");
        }
    }
}
