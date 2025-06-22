using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using CuponeraFront.Utils;

namespace CuponeraFront
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //deshabilitado xd
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        { 
        //desabilitado xd
        }

        private async void button1_Click_1(object sender, EventArgs e) //boton login
        {

            {
                var cliente = new HttpClient();

                var login = new
                {
                    User_Name = txtUsuario.Text,
                    Password = txtPassword.Text
                };

                string json = JsonSerializer.Serialize(login);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await cliente.PostAsync("https://localhost:44329/api/Auth/login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseBody = await response.Content.ReadAsStringAsync();

                        using (var doc = JsonDocument.Parse(responseBody))
                        {
                            var root = doc.RootElement;

                            Sesion.Token = root.GetProperty("token").GetString();
                            Sesion.UserName = root.GetProperty("user").GetString();
                            Sesion.Rol = root.GetProperty("rol").GetString();
                        }


                        MessageBox.Show($"Login exitoso como {Sesion.Rol}", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    }
                    else
                    {
                        MessageBox.Show("Credenciales incorrectas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error de conexión:\n" + ex.Message);
                }

            }

        }

        private async void button1_Click_2(object sender, EventArgs e) //boton registro 
        {
            var cliente = new HttpClient();

            var usuario = new
            {
                User_Name = txtReUsuario.Text,
                Password = txtRePassword.Text,
                Nombre = txtReNombre.Text,
                Apellido = txtReApellido.Text,
                Dni = txtReDni.Text,
                Email = txtReEmail.Text,
                Estado = true,
                Id_Rol = 2 // Cliente por defecto
            };

            string json = JsonSerializer.Serialize(usuario);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await cliente.PostAsync("https://localhost:44329/api/Auth/register", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario registrado correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    string respuesta = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al registrar usuario:\n" + respuesta, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de conexión:\n" + ex.Message);
            }
        }

    }

}
