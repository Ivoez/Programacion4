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
using System.Text.Json.Serialization;
using TrabajoPracticoCuponera.Dtos;

namespace CuponeraFront
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

            tabControlMain.TabPages.Remove(btmAgregarCupon);
            tabControlMain.TabPages.Remove(tabUsuarios);
            tabControlMain.TabPages.Remove(tabCuponesCliente);
            CbRegistroAdmin.Visible = false;

            this.Load += Form1_Load;




            dgvUsuarios.RowValidated += dgvUsuarios_RowValidated; // nos permite que al editar una columna y salir de esta valida los datos ingresados
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //deshabilitado xd
        }

        private void btnLogin_Click(object sender, EventArgs e)
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
                            if (!tabControlMain.TabPages.Contains(tabUsuarios))
                                tabControlMain.TabPages.Add(tabUsuarios);

                            if (!tabControlMain.TabPages.Contains(btmAgregarCupon))
                                tabControlMain.TabPages.Add(btmAgregarCupon);

                            tabControlMain.SelectedTab = btmAgregarCupon;

                            CbRegistroAdmin.Visible = true;
                            tabControlMain.SelectedTab = tabRegistro;


                        }
                        else if (Sesion.Rol == "Cliente")
                        {
                            if (!tabControlMain.TabPages.Contains(tabCuponesCliente))
                                tabControlMain.TabPages.Add(tabCuponesCliente);
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
                Id_Rol = CbRegistroAdmin.Checked ? 1 : 2
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





        ///DATAGRID INFO Usuarios 

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

        private async void btnMostrarGrid_Click(object sender, EventArgs e) //mostrar usuarios 
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





        //DATAGRID Cupones cargados
        private async void button2_Click(object sender, EventArgs e) //ver cupones cargados
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.GetAsync("https://localhost:44329/api/Cupon");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var cupones = JsonSerializer.Deserialize<List<CuponDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dgvCuponesCargados.AutoGenerateColumns = true;
                    dgvCuponesCargados.DataSource = new BindingList<CuponDTO>(cupones);
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los cupones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }


        /////// carga del combox del tipo de cupon 
        private async void Form1_Load(object sender, EventArgs e)
        {
            await CargarTiposCuponAsync();
        }

        private async Task CargarTiposCuponAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.GetAsync("https://localhost:44329/api/Cupon/tipos");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var tipos = JsonSerializer.Deserialize<List<TipoCuponDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    cmbTipoCupon.DataSource = tipos;
                    cmbTipoCupon.DisplayMember = "Nombre";
                    cmbTipoCupon.ValueMember = "Id_Tipo_Cupon";
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los tipos de cupón.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar tipos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        //boton agregar cupon
        private async void button2_Click_1(object sender, EventArgs e)
        {
            {
                if (string.IsNullOrWhiteSpace(txtNombreCupon.Text))
                {
                    MessageBox.Show("Ingrese un nombre para el cupón.");
                    return;
                }

                var dto = new CuponDTO
                {
                    Nombre = txtNombreCupon.Text,
                    Descripcion = txtDescrip.Text,
                    FechaInicio = DtpInicio.Value,
                    FechaFin = DtpFin.Value,
                    Id_Tipo_Cupon = (int)cmbTipoCupon.SelectedValue,
                    Activo = CbActivo.Checked,
                    PorcentajeDto = null,
                    ImportePromo = null,
                    Detalles = new List<CuponDetalleDTO>()
                };


                if (dto.Id_Tipo_Cupon == 1 && decimal.TryParse(NudPorcentaje.Text, out decimal porc))
                    dto.PorcentajeDto = porc;
                else if (dto.Id_Tipo_Cupon == 2 && decimal.TryParse(NudImporte.Text, out decimal imp))
                    dto.ImportePromo = imp;



                // Llamada a la API
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var json = JsonSerializer.Serialize(dto);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await httpClient.PostAsync("https://localhost:44329/api/Cupon", content);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Cupón creado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);


                    txtNombreCupon.Text = "";
                    txtDescrip.Text = "";
                    NudPorcentaje.Text = "";
                    NudImporte.Text = "";
                    DtpInicio.Value = DateTime.Today;
                    DtpFin.Value = DateTime.Today;
                    cmbTipoCupon.SelectedIndex = -1;
                    CbActivo.Checked = false;



                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("Error al crear cupón: " + error);
                }
            }
        }



        ///carga grid articulos 
        private async Task CargarArticulosAsync()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.GetAsync("https://localhost:44329/api/Articulo");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var articulos = JsonSerializer.Deserialize<List<ArticuloDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dgvArticuloAgregar.DataSource = new BindingList<ArticuloDTO>(articulos);
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los artículos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private async void btnVerArticulos_Click(object sender, EventArgs e)
        {
            await CargarArticulosAsync();
        }

        private async void BtmAgregarProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtArticulo.Text) || string.IsNullOrWhiteSpace(txtPrecio.Text))
            {
                MessageBox.Show("El nombre y el precio son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                MessageBox.Show("Precio inválido. Ingrese un valor numérico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var nuevoArticulo = new ArticuloDTO
            {
                Nombre_Articulo = txtArticulo.Text,
                Descripcion_Articulo = txtDescripcionArticulo.Text,
                Precio = precio,
                Activo = CbActivo.Checked
            };

            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

            var json = JsonSerializer.Serialize(nuevoArticulo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("https://localhost:44329/api/Articulo", content);

            if (response.IsSuccessStatusCode)
            {
                MessageBox.Show("Artículo agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarArticulosAsync();
                txtArticulo.Clear();
                txtDescripcionArticulo.Clear();
                txtPrecio.Clear();
                CbActivoArticulo.Checked = false;

            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                MessageBox.Show("Error al agregar artículo: " + error, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }






        private async void btmCuponesCliente_Click(object sender, EventArgs e)
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.GetAsync("https://localhost:44329/api/Cupon");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var cupones = JsonSerializer.Deserialize<List<CuponDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dgvCuponesCliente.AutoGenerateColumns = true;
                    dgvCuponesCliente.DataSource = new BindingList<CuponDTO>(cupones);
                }
                else
                {
                    MessageBox.Show("No se pudieron cargar los cupones.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }


        ///GRID CUPONES CLIENTE

        private async void CargarCuponesReclamados()
        {
            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.GetAsync("https://localhost:44329/api/CuponHistorial/mio");

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var historial = JsonSerializer.Deserialize<List<CuponHistorialDTO>>(json, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    dtgCuponesReclamados.AutoGenerateColumns = true;
                    dtgCuponesReclamados.DataSource = new BindingList<CuponHistorialDTO>(historial);
                }
                else
                {
                    MessageBox.Show("No se pudo obtener el historial.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener historial: " + ex.Message);
            }
        }


        private async void btmReclamarCupon_Click(object sender, EventArgs e)
        {
            if (dgvCuponesCliente.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un cupón.");
                return;
            }

            var cupon = dgvCuponesCliente.CurrentRow.DataBoundItem as CuponDTO;

            if (cupon == null)
            {
                MessageBox.Show("Error al obtener el cupón.");
                return;
            }

            try
            {
                var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Authorization =
                    new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", Sesion.Token);

                var response = await httpClient.PostAsync($"https://localhost:44329/api/CuponHistorial/reclamar/{cupon.NroCupon}", null);

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("¡Cupón reclamado!");
                    CargarCuponesReclamados();
                }
                else
                {
                    var error = await response.Content.ReadAsStringAsync();
                    MessageBox.Show($"No se pudo reclamar el cupón.\n{error}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reclamar: {ex.Message}");
            }
        }



















        //botones que agregue sin querer al apretar en el form y no los puedo borrar sin romper la vista 

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //deshabilitado xd
        } //deshabilitado

        private void dgvUsuarios_CellContentClick(object sender, EventArgs eventArgs)
        {
            //deshabilitado xd
        } //deshabilitado

        private void tabCupones_Click(object sender, EventArgs e)
        {
            //deshabilitado xd
        } //deshabilitado

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            //deshabilitado xd
        } //deshabilitado

        private void label1_Click_1(object sender, EventArgs e)
        {
            //deshabilitado xd
        } //deshabilitado

        private void dgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //deshabilitado
        } //deshabilitado

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //deshabilitado
        } //deshabilitado

        private void btnAgregarArticulo_Click(object sender, EventArgs e)
        {
            //deshabilitado
        }

        private void CbActivoArticulo_CheckedChanged(object sender, EventArgs e) //deshabilitado
        {

        }



        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
    


