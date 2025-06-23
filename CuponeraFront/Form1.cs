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
using TrabajoPracticoCuponera.DTOs;

namespace CuponeraFront
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tabUsuarios.Parent = null;
            dgvUsuarios.RowValidated += dgvUsuarios_RowValidated; // nos permite que al editar una columna y salir de esta valida los datos ingresados
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
                        if (Sesion.Rol == "Admin")
                        {
                            tabUsuarios.Parent = tabControlMain; 
                        }
                        else
                        {
                            tabUsuarios.Parent = null; 
                        }

                        if (Sesion.Rol == "Admin")
                        {
                            tabUsuarios.Parent = tabControlMain; 
                            
                        }
                        else
                        {
                            tabUsuarios.Parent = null; 
                        }



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





        ///DATAGRID INFO

        private async Task CargarUsuariosAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

            var response = await httpClient.GetAsync("https://localhost:44329/api/Usuario");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioDTO>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dgvUsuarios.DataSource = new BindingList<UsuarioDTO>(usuarios);
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void dgvUsuarios_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; 

            var row = dgvUsuarios.Rows[e.RowIndex];
            if (row.DataBoundItem is UsuarioDTO usuarioModificado)
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                string url = $"https://localhost:44329/api/Usuario/{usuarioModificado.Id_Usuario}";

                string json = JsonSerializer.Serialize(usuarioModificado);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                try
                {
                    var response = await httpClient.PutAsync(url, content);

                    if (!response.IsSuccessStatusCode)
                    {
                        string error = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Error al actualizar usuario:\n{error}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        
                        await CargarUsuariosAsync();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error de conexión al actualizar usuario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnMostrarGrid_Click(object sender, EventArgs e)
        {

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

            var response = await httpClient.GetAsync("https://localhost:44329/api/Usuario");

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var usuarios = JsonSerializer.Deserialize<List<UsuarioDTO>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                dgvUsuarios.DataSource = new BindingList<UsuarioDTO>(usuarios); 
            }
            else
            {
                MessageBox.Show("No se pudieron cargar los usuarios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        } //mostrar usuarios 


      private void dgvUsuarios_CellContentClick(object sender, EventArgs eventArgs)
        {
            //deshabilitado xd
        }







    }

}
