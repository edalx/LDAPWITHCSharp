using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Security.Permissions;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.DirectoryServices.Protocols;

namespace LPADWithCSharp
{
         [DirectoryServicesPermission(SecurityAction.Demand, Unrestricted = true)]

    public partial class LoginForm : MetroForm
    {
             private static String userPs;
        
             
             public LoginForm()
        {
            InitializeComponent();
            this.passw.PasswordChar = '*';
        }

            
        private void metroTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            string path = @"LDAP://UIOSVR2K8:389/DC=INFORMATICA,DC=COM";       //CAMBIAR POR VUESTRO PATH (URL DEL SERVICIO DE DIRECTORIO LDAP)
            //Por ejemplo: 'LDAP://ejemplo.lan.es'
            string dominio = @"informatica";             //CAMBIAR POR VUESTRO DOMINIO
            string usu = user.Text.Trim();                   //USUARIO DEL DOMINIO
            string pass = passw.Text.Trim();                    //PASSWORD DEL USUARIO
            string domUsu = dominio + @"\" + usu;               //CADENA DE DOMINIO + USUARIO A COMPROBAR
            
            bool permiso = AutenticaUsuario(path, domUsu, pass);
        if(permiso){
            ControlerForm op=new ControlerForm(usu);
            this.Hide();
            op.ShowDialog();
            this.Close();
        }
        else
        {
            MessageBox.Show("Usuario no encontrado", "Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
        }
            
        }
       
        private bool AutenticaUsuario(String path, String user, String pass)
        {
            //Los datos que hemos pasado los 'convertimos' en una entrada de Active Directory para hacer la consulta
            DirectoryEntry de = new DirectoryEntry(path, user, pass, AuthenticationTypes.Secure);
            try
            {
                //Inicia el chequeo con las credenciales que le hemos pasado
                //Si devuelve algo significa que ha autenticado las credenciales
                DirectorySearcher ds = new DirectorySearcher(de);
                
                ds.FindOne();
                return true;
            }
            catch
            {
                //Si no devuelve nada es que no ha podido autenticar las credenciales
                //ya sea porque no existe el usuario o por que no son correctas
                return false;
            }
        }
    }
}
