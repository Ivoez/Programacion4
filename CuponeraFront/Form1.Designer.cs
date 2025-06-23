namespace CuponeraFront
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabCupones = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblDescrip = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtDescrip = new System.Windows.Forms.TextBox();
            this.lblTipoCupon = new System.Windows.Forms.Label();
            this.cmbTipoCupon = new System.Windows.Forms.ComboBox();
            this.DtpInicio = new System.Windows.Forms.DateTimePicker();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.DtpFin = new System.Windows.Forms.DateTimePicker();
            this.lblFechaFin = new System.Windows.Forms.Label();
            this.CbActivo = new System.Windows.Forms.CheckBox();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.NudPorcentaje = new System.Windows.Forms.NumericUpDown();
            this.lblImporte = new System.Windows.Forms.Label();
            this.NudImporte = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblArticulo = new System.Windows.Forms.Label();
            this.cmbArticulo = new System.Windows.Forms.ComboBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.NudCantidad = new System.Windows.Forms.NumericUpDown();
            this.BtmAgregarProducto = new System.Windows.Forms.Button();
            this.dgvArticuloAgregar = new System.Windows.Forms.DataGridView();
            this.btmGuardarArticulo = new System.Windows.Forms.Button();
            this.btmCancelarArticulo = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.dgvCuponesCargados = new System.Windows.Forms.DataGridView();
            this.btmDetalleCupon = new System.Windows.Forms.Button();
            this.tabUsuarios = new System.Windows.Forms.TabPage();
            this.dgvUsuarios = new System.Windows.Forms.DataGridView();
            this.btnMostrarGrid = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lblReUsuario = new System.Windows.Forms.Label();
            this.lblRePassword = new System.Windows.Forms.Label();
            this.lblReNombre = new System.Windows.Forms.Label();
            this.lblReApellido = new System.Windows.Forms.Label();
            this.lblReDni = new System.Windows.Forms.Label();
            this.lblReEmail = new System.Windows.Forms.Label();
            this.txtReUsuario = new System.Windows.Forms.TextBox();
            this.txtRePassword = new System.Windows.Forms.TextBox();
            this.txtReNombre = new System.Windows.Forms.TextBox();
            this.txtReApellido = new System.Windows.Forms.TextBox();
            this.txtReDni = new System.Windows.Forms.TextBox();
            this.txtReEmail = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.btmLogin = new System.Windows.Forms.Button();
            this.tabControlMain = new System.Windows.Forms.TabControl();
            this.tabCupones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPorcentaje)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudImporte)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloAgregar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuponesCargados)).BeginInit();
            this.tabUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabControlMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabCupones
            // 
            this.tabCupones.Controls.Add(this.btmDetalleCupon);
            this.tabCupones.Controls.Add(this.dgvCuponesCargados);
            this.tabCupones.Controls.Add(this.label7);
            this.tabCupones.Controls.Add(this.groupBox1);
            this.tabCupones.Controls.Add(this.NudImporte);
            this.tabCupones.Controls.Add(this.lblImporte);
            this.tabCupones.Controls.Add(this.NudPorcentaje);
            this.tabCupones.Controls.Add(this.lblPorcentaje);
            this.tabCupones.Controls.Add(this.CbActivo);
            this.tabCupones.Controls.Add(this.lblFechaFin);
            this.tabCupones.Controls.Add(this.DtpFin);
            this.tabCupones.Controls.Add(this.lblFechaInicio);
            this.tabCupones.Controls.Add(this.DtpInicio);
            this.tabCupones.Controls.Add(this.cmbTipoCupon);
            this.tabCupones.Controls.Add(this.lblTipoCupon);
            this.tabCupones.Controls.Add(this.txtDescrip);
            this.tabCupones.Controls.Add(this.txtNombre);
            this.tabCupones.Controls.Add(this.lblDescrip);
            this.tabCupones.Controls.Add(this.lblNombre);
            this.tabCupones.Controls.Add(this.label1);
            this.tabCupones.Location = new System.Drawing.Point(4, 25);
            this.tabCupones.Name = "tabCupones";
            this.tabCupones.Padding = new System.Windows.Forms.Padding(3);
            this.tabCupones.Size = new System.Drawing.Size(1522, 605);
            this.tabCupones.TabIndex = 3;
            this.tabCupones.Text = "Cupones";
            this.tabCupones.UseVisualStyleBackColor = true;
            this.tabCupones.Click += new System.EventHandler(this.tabCupones_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Cargar cupon";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(28, 51);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(56, 16);
            this.lblNombre.TabIndex = 1;
            this.lblNombre.Text = "Nombre";
            // 
            // lblDescrip
            // 
            this.lblDescrip.AutoSize = true;
            this.lblDescrip.Location = new System.Drawing.Point(27, 84);
            this.lblDescrip.Name = "lblDescrip";
            this.lblDescrip.Size = new System.Drawing.Size(79, 16);
            this.lblDescrip.TabIndex = 3;
            this.lblDescrip.Text = "Descripcion";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(113, 45);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(119, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // txtDescrip
            // 
            this.txtDescrip.Location = new System.Drawing.Point(113, 81);
            this.txtDescrip.Name = "txtDescrip";
            this.txtDescrip.Size = new System.Drawing.Size(334, 22);
            this.txtDescrip.TabIndex = 4;
            // 
            // lblTipoCupon
            // 
            this.lblTipoCupon.AutoSize = true;
            this.lblTipoCupon.Location = new System.Drawing.Point(27, 123);
            this.lblTipoCupon.Name = "lblTipoCupon";
            this.lblTipoCupon.Size = new System.Drawing.Size(75, 16);
            this.lblTipoCupon.TabIndex = 5;
            this.lblTipoCupon.Text = "Tipo cupon";
            // 
            // cmbTipoCupon
            // 
            this.cmbTipoCupon.FormattingEnabled = true;
            this.cmbTipoCupon.Location = new System.Drawing.Point(112, 115);
            this.cmbTipoCupon.Name = "cmbTipoCupon";
            this.cmbTipoCupon.Size = new System.Drawing.Size(121, 24);
            this.cmbTipoCupon.TabIndex = 6;
            this.cmbTipoCupon.SelectedIndexChanged += new System.EventHandler(this.cmbTipoCupon_SelectedIndexChanged);
            // 
            // DtpInicio
            // 
            this.DtpInicio.Location = new System.Drawing.Point(112, 190);
            this.DtpInicio.Name = "DtpInicio";
            this.DtpInicio.Size = new System.Drawing.Size(181, 22);
            this.DtpInicio.TabIndex = 7;
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(27, 196);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(79, 16);
            this.lblFechaInicio.TabIndex = 8;
            this.lblFechaInicio.Text = "Fecha Inicio";
            // 
            // DtpFin
            // 
            this.DtpFin.Location = new System.Drawing.Point(422, 190);
            this.DtpFin.Name = "DtpFin";
            this.DtpFin.Size = new System.Drawing.Size(183, 22);
            this.DtpFin.TabIndex = 9;
            // 
            // lblFechaFin
            // 
            this.lblFechaFin.AutoSize = true;
            this.lblFechaFin.Location = new System.Drawing.Point(341, 195);
            this.lblFechaFin.Name = "lblFechaFin";
            this.lblFechaFin.Size = new System.Drawing.Size(66, 16);
            this.lblFechaFin.TabIndex = 10;
            this.lblFechaFin.Text = "Fecha Fin";
            // 
            // CbActivo
            // 
            this.CbActivo.AutoSize = true;
            this.CbActivo.Location = new System.Drawing.Point(30, 235);
            this.CbActivo.Name = "CbActivo";
            this.CbActivo.Size = new System.Drawing.Size(66, 20);
            this.CbActivo.TabIndex = 12;
            this.CbActivo.Text = "Activo";
            this.CbActivo.UseVisualStyleBackColor = true;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.AutoSize = true;
            this.lblPorcentaje.Location = new System.Drawing.Point(28, 158);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(72, 16);
            this.lblPorcentaje.TabIndex = 16;
            this.lblPorcentaje.Text = "Porcentaje";
            // 
            // NudPorcentaje
            // 
            this.NudPorcentaje.Location = new System.Drawing.Point(112, 152);
            this.NudPorcentaje.Name = "NudPorcentaje";
            this.NudPorcentaje.Size = new System.Drawing.Size(120, 22);
            this.NudPorcentaje.TabIndex = 17;
            // 
            // lblImporte
            // 
            this.lblImporte.AutoSize = true;
            this.lblImporte.Location = new System.Drawing.Point(275, 158);
            this.lblImporte.Name = "lblImporte";
            this.lblImporte.Size = new System.Drawing.Size(52, 16);
            this.lblImporte.TabIndex = 18;
            this.lblImporte.Text = "Importe";
            // 
            // NudImporte
            // 
            this.NudImporte.Location = new System.Drawing.Point(344, 150);
            this.NudImporte.Name = "NudImporte";
            this.NudImporte.Size = new System.Drawing.Size(120, 22);
            this.NudImporte.TabIndex = 19;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btmCancelarArticulo);
            this.groupBox1.Controls.Add(this.btmGuardarArticulo);
            this.groupBox1.Controls.Add(this.dgvArticuloAgregar);
            this.groupBox1.Controls.Add(this.BtmAgregarProducto);
            this.groupBox1.Controls.Add(this.NudCantidad);
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Controls.Add(this.cmbArticulo);
            this.groupBox1.Controls.Add(this.lblArticulo);
            this.groupBox1.Location = new System.Drawing.Point(22, 290);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(828, 292);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar articulo al cupon";
            // 
            // lblArticulo
            // 
            this.lblArticulo.AutoSize = true;
            this.lblArticulo.Location = new System.Drawing.Point(6, 39);
            this.lblArticulo.Name = "lblArticulo";
            this.lblArticulo.Size = new System.Drawing.Size(51, 16);
            this.lblArticulo.TabIndex = 9;
            this.lblArticulo.Text = "Articulo";
            // 
            // cmbArticulo
            // 
            this.cmbArticulo.FormattingEnabled = true;
            this.cmbArticulo.Location = new System.Drawing.Point(63, 31);
            this.cmbArticulo.Name = "cmbArticulo";
            this.cmbArticulo.Size = new System.Drawing.Size(121, 24);
            this.cmbArticulo.TabIndex = 10;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(212, 39);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(61, 16);
            this.lblCantidad.TabIndex = 11;
            this.lblCantidad.Text = "Cantidad";
            // 
            // NudCantidad
            // 
            this.NudCantidad.Location = new System.Drawing.Point(279, 33);
            this.NudCantidad.Name = "NudCantidad";
            this.NudCantidad.Size = new System.Drawing.Size(120, 22);
            this.NudCantidad.TabIndex = 18;
            // 
            // BtmAgregarProducto
            // 
            this.BtmAgregarProducto.Location = new System.Drawing.Point(433, 33);
            this.BtmAgregarProducto.Name = "BtmAgregarProducto";
            this.BtmAgregarProducto.Size = new System.Drawing.Size(75, 23);
            this.BtmAgregarProducto.TabIndex = 19;
            this.BtmAgregarProducto.Text = "Agregar";
            this.BtmAgregarProducto.UseVisualStyleBackColor = true;
            // 
            // dgvArticuloAgregar
            // 
            this.dgvArticuloAgregar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticuloAgregar.Location = new System.Drawing.Point(6, 65);
            this.dgvArticuloAgregar.Name = "dgvArticuloAgregar";
            this.dgvArticuloAgregar.RowHeadersWidth = 51;
            this.dgvArticuloAgregar.RowTemplate.Height = 24;
            this.dgvArticuloAgregar.Size = new System.Drawing.Size(789, 192);
            this.dgvArticuloAgregar.TabIndex = 20;
            this.dgvArticuloAgregar.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // btmGuardarArticulo
            // 
            this.btmGuardarArticulo.Location = new System.Drawing.Point(24, 263);
            this.btmGuardarArticulo.Name = "btmGuardarArticulo";
            this.btmGuardarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btmGuardarArticulo.TabIndex = 21;
            this.btmGuardarArticulo.Text = "Guardar";
            this.btmGuardarArticulo.UseVisualStyleBackColor = true;
            // 
            // btmCancelarArticulo
            // 
            this.btmCancelarArticulo.Location = new System.Drawing.Point(134, 263);
            this.btmCancelarArticulo.Name = "btmCancelarArticulo";
            this.btmCancelarArticulo.Size = new System.Drawing.Size(75, 23);
            this.btmCancelarArticulo.TabIndex = 22;
            this.btmCancelarArticulo.Text = "Cancelar";
            this.btmCancelarArticulo.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(664, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 16);
            this.label7.TabIndex = 22;
            this.label7.Text = "Cupones cargados";
            // 
            // dgvCuponesCargados
            // 
            this.dgvCuponesCargados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCuponesCargados.Location = new System.Drawing.Point(649, 35);
            this.dgvCuponesCargados.Name = "dgvCuponesCargados";
            this.dgvCuponesCargados.RowHeadersWidth = 51;
            this.dgvCuponesCargados.RowTemplate.Height = 24;
            this.dgvCuponesCargados.Size = new System.Drawing.Size(741, 150);
            this.dgvCuponesCargados.TabIndex = 14;
            this.dgvCuponesCargados.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // btmDetalleCupon
            // 
            this.btmDetalleCupon.Location = new System.Drawing.Point(667, 215);
            this.btmDetalleCupon.Name = "btmDetalleCupon";
            this.btmDetalleCupon.Size = new System.Drawing.Size(125, 23);
            this.btmDetalleCupon.TabIndex = 15;
            this.btmDetalleCupon.Text = "Ver detalle";
            this.btmDetalleCupon.UseVisualStyleBackColor = true;
            this.btmDetalleCupon.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabUsuarios
            // 
            this.tabUsuarios.Controls.Add(this.btnMostrarGrid);
            this.tabUsuarios.Controls.Add(this.dgvUsuarios);
            this.tabUsuarios.Location = new System.Drawing.Point(4, 25);
            this.tabUsuarios.Name = "tabUsuarios";
            this.tabUsuarios.Padding = new System.Windows.Forms.Padding(3);
            this.tabUsuarios.Size = new System.Drawing.Size(1522, 605);
            this.tabUsuarios.TabIndex = 2;
            this.tabUsuarios.Text = "Usuarios";
            this.tabUsuarios.UseVisualStyleBackColor = true;
            // 
            // dgvUsuarios
            // 
            this.dgvUsuarios.AllowUserToAddRows = false;
            this.dgvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsuarios.Location = new System.Drawing.Point(6, 38);
            this.dgvUsuarios.Name = "dgvUsuarios";
            this.dgvUsuarios.RowHeadersWidth = 51;
            this.dgvUsuarios.RowTemplate.Height = 24;
            this.dgvUsuarios.Size = new System.Drawing.Size(749, 242);
            this.dgvUsuarios.TabIndex = 0;
            this.dgvUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUsuarios_CellContentClick);
            // 
            // btnMostrarGrid
            // 
            this.btnMostrarGrid.Location = new System.Drawing.Point(11, 9);
            this.btnMostrarGrid.Name = "btnMostrarGrid";
            this.btnMostrarGrid.Size = new System.Drawing.Size(101, 23);
            this.btnMostrarGrid.TabIndex = 1;
            this.btnMostrarGrid.Text = "Mostrar";
            this.btnMostrarGrid.UseVisualStyleBackColor = true;
            this.btnMostrarGrid.Click += new System.EventHandler(this.btnMostrarGrid_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txtReEmail);
            this.tabPage2.Controls.Add(this.txtReDni);
            this.tabPage2.Controls.Add(this.txtReApellido);
            this.tabPage2.Controls.Add(this.txtReNombre);
            this.tabPage2.Controls.Add(this.txtRePassword);
            this.tabPage2.Controls.Add(this.txtReUsuario);
            this.tabPage2.Controls.Add(this.lblReEmail);
            this.tabPage2.Controls.Add(this.lblReDni);
            this.tabPage2.Controls.Add(this.lblReApellido);
            this.tabPage2.Controls.Add(this.lblReNombre);
            this.tabPage2.Controls.Add(this.lblRePassword);
            this.tabPage2.Controls.Add(this.lblReUsuario);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1522, 605);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Registro";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lblReUsuario
            // 
            this.lblReUsuario.AutoSize = true;
            this.lblReUsuario.Location = new System.Drawing.Point(19, 15);
            this.lblReUsuario.Name = "lblReUsuario";
            this.lblReUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblReUsuario.TabIndex = 0;
            this.lblReUsuario.Text = "Usuario";
            // 
            // lblRePassword
            // 
            this.lblRePassword.AutoSize = true;
            this.lblRePassword.Location = new System.Drawing.Point(19, 68);
            this.lblRePassword.Name = "lblRePassword";
            this.lblRePassword.Size = new System.Drawing.Size(67, 16);
            this.lblRePassword.TabIndex = 1;
            this.lblRePassword.Text = "Password";
            // 
            // lblReNombre
            // 
            this.lblReNombre.AutoSize = true;
            this.lblReNombre.Location = new System.Drawing.Point(19, 129);
            this.lblReNombre.Name = "lblReNombre";
            this.lblReNombre.Size = new System.Drawing.Size(56, 16);
            this.lblReNombre.TabIndex = 2;
            this.lblReNombre.Text = "Nombre";
            // 
            // lblReApellido
            // 
            this.lblReApellido.AutoSize = true;
            this.lblReApellido.Location = new System.Drawing.Point(301, 15);
            this.lblReApellido.Name = "lblReApellido";
            this.lblReApellido.Size = new System.Drawing.Size(57, 16);
            this.lblReApellido.TabIndex = 3;
            this.lblReApellido.Text = "Apellido";
            // 
            // lblReDni
            // 
            this.lblReDni.AutoSize = true;
            this.lblReDni.Location = new System.Drawing.Point(301, 68);
            this.lblReDni.Name = "lblReDni";
            this.lblReDni.Size = new System.Drawing.Size(27, 16);
            this.lblReDni.TabIndex = 4;
            this.lblReDni.Text = "Dni";
            // 
            // lblReEmail
            // 
            this.lblReEmail.AutoSize = true;
            this.lblReEmail.Location = new System.Drawing.Point(301, 129);
            this.lblReEmail.Name = "lblReEmail";
            this.lblReEmail.Size = new System.Drawing.Size(41, 16);
            this.lblReEmail.TabIndex = 5;
            this.lblReEmail.Text = "Email";
            // 
            // txtReUsuario
            // 
            this.txtReUsuario.Location = new System.Drawing.Point(92, 15);
            this.txtReUsuario.Name = "txtReUsuario";
            this.txtReUsuario.Size = new System.Drawing.Size(169, 22);
            this.txtReUsuario.TabIndex = 6;
            // 
            // txtRePassword
            // 
            this.txtRePassword.Location = new System.Drawing.Point(92, 68);
            this.txtRePassword.Name = "txtRePassword";
            this.txtRePassword.Size = new System.Drawing.Size(169, 22);
            this.txtRePassword.TabIndex = 7;
            // 
            // txtReNombre
            // 
            this.txtReNombre.Location = new System.Drawing.Point(92, 123);
            this.txtReNombre.Name = "txtReNombre";
            this.txtReNombre.Size = new System.Drawing.Size(169, 22);
            this.txtReNombre.TabIndex = 8;
            // 
            // txtReApellido
            // 
            this.txtReApellido.Location = new System.Drawing.Point(372, 15);
            this.txtReApellido.Name = "txtReApellido";
            this.txtReApellido.Size = new System.Drawing.Size(169, 22);
            this.txtReApellido.TabIndex = 9;
            // 
            // txtReDni
            // 
            this.txtReDni.Location = new System.Drawing.Point(372, 65);
            this.txtReDni.Name = "txtReDni";
            this.txtReDni.Size = new System.Drawing.Size(169, 22);
            this.txtReDni.TabIndex = 10;
            // 
            // txtReEmail
            // 
            this.txtReEmail.Location = new System.Drawing.Point(372, 123);
            this.txtReEmail.Name = "txtReEmail";
            this.txtReEmail.Size = new System.Drawing.Size(169, 22);
            this.txtReEmail.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Registrarse";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btmLogin);
            this.tabPage1.Controls.Add(this.txtPassword);
            this.tabPage1.Controls.Add(this.txtUsuario);
            this.tabPage1.Controls.Add(this.lblPassword);
            this.tabPage1.Controls.Add(this.lblUsuario);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1522, 605);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Login";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Location = new System.Drawing.Point(9, 54);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(54, 16);
            this.lblUsuario.TabIndex = 5;
            this.lblUsuario.Text = "Usuario";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(9, 108);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(66, 16);
            this.lblPassword.TabIndex = 6;
            this.lblPassword.Text = "password";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(105, 54);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(167, 22);
            this.txtUsuario.TabIndex = 7;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(105, 108);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(167, 22);
            this.txtPassword.TabIndex = 8;
            this.txtPassword.UseSystemPasswordChar = true;
            // 
            // btmLogin
            // 
            this.btmLogin.Location = new System.Drawing.Point(12, 178);
            this.btmLogin.Name = "btmLogin";
            this.btmLogin.Size = new System.Drawing.Size(79, 27);
            this.btmLogin.TabIndex = 9;
            this.btmLogin.Text = "Login";
            this.btmLogin.UseVisualStyleBackColor = true;
            this.btmLogin.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tabControlMain
            // 
            this.tabControlMain.AccessibleName = "";
            this.tabControlMain.Controls.Add(this.tabPage1);
            this.tabControlMain.Controls.Add(this.tabPage2);
            this.tabControlMain.Controls.Add(this.tabUsuarios);
            this.tabControlMain.Controls.Add(this.tabCupones);
            this.tabControlMain.Location = new System.Drawing.Point(-2, -2);
            this.tabControlMain.Name = "tabControlMain";
            this.tabControlMain.SelectedIndex = 0;
            this.tabControlMain.Size = new System.Drawing.Size(1530, 634);
            this.tabControlMain.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1513, 701);
            this.Controls.Add(this.tabControlMain);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabCupones.ResumeLayout(false);
            this.tabCupones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPorcentaje)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudImporte)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticuloAgregar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCuponesCargados)).EndInit();
            this.tabUsuarios.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsuarios)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabControlMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabCupones;
        private System.Windows.Forms.Button btmDetalleCupon;
        private System.Windows.Forms.DataGridView dgvCuponesCargados;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btmCancelarArticulo;
        private System.Windows.Forms.Button btmGuardarArticulo;
        private System.Windows.Forms.DataGridView dgvArticuloAgregar;
        private System.Windows.Forms.Button BtmAgregarProducto;
        private System.Windows.Forms.NumericUpDown NudCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.ComboBox cmbArticulo;
        private System.Windows.Forms.Label lblArticulo;
        private System.Windows.Forms.NumericUpDown NudImporte;
        private System.Windows.Forms.Label lblImporte;
        private System.Windows.Forms.NumericUpDown NudPorcentaje;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.CheckBox CbActivo;
        private System.Windows.Forms.Label lblFechaFin;
        private System.Windows.Forms.DateTimePicker DtpFin;
        private System.Windows.Forms.Label lblFechaInicio;
        private System.Windows.Forms.DateTimePicker DtpInicio;
        private System.Windows.Forms.ComboBox cmbTipoCupon;
        private System.Windows.Forms.Label lblTipoCupon;
        private System.Windows.Forms.TextBox txtDescrip;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblDescrip;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabUsuarios;
        private System.Windows.Forms.Button btnMostrarGrid;
        private System.Windows.Forms.DataGridView dgvUsuarios;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtReEmail;
        private System.Windows.Forms.TextBox txtReDni;
        private System.Windows.Forms.TextBox txtReApellido;
        private System.Windows.Forms.TextBox txtReNombre;
        private System.Windows.Forms.TextBox txtRePassword;
        private System.Windows.Forms.TextBox txtReUsuario;
        private System.Windows.Forms.Label lblReEmail;
        private System.Windows.Forms.Label lblReDni;
        private System.Windows.Forms.Label lblReApellido;
        private System.Windows.Forms.Label lblReNombre;
        private System.Windows.Forms.Label lblRePassword;
        private System.Windows.Forms.Label lblReUsuario;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btmLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TabControl tabControlMain;
    }
}

