using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Level_Access_Data
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

       private SqlConnection Connet = new SqlConnection("server = DESKTOP-0O21MS4; database = Registro_Agenda; integrated security = true ");


        private void Form1_Load(object sender, EventArgs e)
        {

            Connet.Open();

            String Query = "Select * from Contactos";

            SqlCommand GetQuery = new SqlCommand(Query, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            Connet.Close();

            comboBox1.Items.Add("Masculino");
            comboBox1.Items.Add("Femenino");
            comboBox1.Items.Add("Otros");

            comboBox2.Items.Add("Soltero/a");
            comboBox2.Items.Add("Casado/a");
            comboBox2.Items.Add("Divorciado/a");
            comboBox2.Items.Add("Viudo/a");

            comboBox3.Items.Add("Masculino");
            comboBox3.Items.Add("Femenino");
            comboBox3.Items.Add("Otros");


            comboBox4.Items.Add("Soltero/a");
            comboBox4.Items.Add("Casado/a");
            comboBox4.Items.Add("Divorciado/a");
            comboBox4.Items.Add("Viudo/a");

            comboBox5.Items.Add("ID");
            comboBox5.Items.Add("Nombre");
            comboBox5.Items.Add("Apellido");

            comboBox5.SelectedIndex = 0;


        }

       

        private void button5_Click(object sender, EventArgs e)
        {
            String Nombre = textBox2.Text;
            String Apellido = textBox3.Text;
            String Nacimiento = monthCalendar1.SelectionRange.Start.ToShortDateString();
            String Direccion = textBox5.Text;
            String Genero = comboBox1.Text;
            String EstadoCivil = comboBox2.Text;
            String Movil = textBox8.Text;
            String Telefono = textBox9.Text;
            String Email = textBox4.Text;

            if (Nombre == "" ||
                Apellido == "" ||
                Direccion == "" ||
                Genero == "" ||
                EstadoCivil == "" ||
                Movil == "" ||
                Telefono == "" ||
                Email == "") {

                MessageBox.Show("Complete Todos Los Campos", "Alerta: Campos Requeridos");
            }
            else
            {
                

                Connet.Open();

                String Query = "Insert into Contactos (Nombre,Apellido,Nacimiento,Direccion,Genero,Estado_Civil,Movil,Telefono,Email) values('" + Nombre + "', '" + Apellido + "', '" + Nacimiento + "','" + Direccion + "','" + Genero + "','" + EstadoCivil + "','" + Movil + "','" + Telefono + "','" + Email + "')";

                SqlCommand InsertQuery = new SqlCommand(Query, Connet);

                InsertQuery.ExecuteNonQuery();


                Connet.Close();


                MessageBox.Show("El Contacto Fue Agregado Correctamente", "Contacto Creado");

                 textBox2.Text = "";
                 textBox3.Text = "";
                 textBox5.Text = "";
                 comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                textBox8.Text = "";
                 textBox9.Text = "";
                 textBox4.Text = "";

                panel2.Visible = false;

                textBox1.Text = "";

                Connet.Open();

                String QueryView = "Select * from Contactos";

                SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

                SqlDataReader Registros = GetQuery.ExecuteReader();

                while (Registros.Read())
                {
                    textBox1.AppendText(" ID: ");

                    textBox1.AppendText(Registros["ID"].ToString());

                    textBox1.AppendText("; Nombre: ");

                    textBox1.AppendText(Registros["Nombre"].ToString());

                    textBox1.AppendText("; Apellido: ");

                    textBox1.AppendText(Registros["Apellido"].ToString());

                    textBox1.AppendText("; Nacimiento: ");

                    textBox1.AppendText(Registros["Nacimiento"].ToString());

                    textBox1.AppendText("; Dirección: ");

                    textBox1.AppendText(Registros["Direccion"].ToString());

                    textBox1.AppendText("; Genero: ");

                    textBox1.AppendText(Registros["Genero"].ToString());

                    textBox1.AppendText("; Estado_Civil: ");

                    textBox1.AppendText(Registros["Estado_Civil"].ToString());

                    textBox1.AppendText("; Movil: ");

                    textBox1.AppendText(Registros["Movil"].ToString());

                    textBox1.AppendText("; Telefono: ");

                    textBox1.AppendText(Registros["Telefono"].ToString());

                    textBox1.AppendText("; Email ");

                    textBox1.AppendText(Registros["Email"].ToString());

                    textBox1.AppendText(Environment.NewLine);

                    textBox1.AppendText(Environment.NewLine);

                }

                textBox19.Visible = true;

                button4.Visible = true;

                button11.Visible = true;

                comboBox5.Visible = true;

                label33.Visible = true;

                Connet.Close();

            }

            
        }

        private void button7_Click(object sender, EventArgs e)
        {
  

            Connet.Open();

            String Code = textBox17.Text;

            int valide = 0;

            if (int.TryParse(Code, out valide))
            { }

            else
            {

                MessageBox.Show("El ID Debe de Ser Un Valor Númerico", "Error: No se Campo Númerico");

                Connet.Close();

                return;
            }

            String QueryView = "Select * from Contactos where ID = " + Code;

            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            if (Registros.Read()) {

                textBox13.Text = Registros["Nombre"].ToString();
                textBox12.Text = Registros["Apellido"].ToString();
                textBox14.Text = Registros["Nacimiento"].ToString();
                textBox11.Text = Registros["Direccion"].ToString();
                textBox15.Text = Registros["Genero"].ToString();
                textBox16.Text = Registros["Estado_Civil"].ToString();
                textBox10.Text = Registros["Movil"].ToString();
                textBox7.Text = Registros["Telefono"].ToString();
                textBox6.Text = Registros["Email"].ToString();

                button6.Enabled = true;

            }
            else
            {

                MessageBox.Show("El Contacto Especificado No Existe","Alerta: Contacto No Existente");
            }


            Connet.Close();



        }

        private void textBox17_TextChanged(object sender, EventArgs e)
        {
            if (textBox17.Text == "") {
                
                button7.Enabled = false;
            
            }

            else
            {
                button7.Enabled = true;

            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Connet.Open();

            String Code = textBox17.Text;

            String DeleteView = "Delete from Contactos where ID = " + Code;

            SqlCommand DeleteQuery = new SqlCommand(DeleteView, Connet);

            DeleteQuery.ExecuteNonQuery();

            MessageBox.Show("El Contacto Fue Eliminado Correctamente", "Contacto Eliminado");

            Connet.Close();

            textBox1.Text = "";

            Connet.Open();

            String QueryView = "Select * from Contactos";

            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            Connet.Close();

            textBox19.Visible = true;

            button4.Visible = true;

            button11.Visible = true;

            comboBox5.Visible = true;

            label33.Visible = true;

            textBox13.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            textBox11.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox17.Text = "";

            button6.Enabled = false;

            button7.Enabled = false;

            panel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;

            textBox19.Visible = false;

            button4.Visible = false;

            button11.Visible = false;

            comboBox5.Visible = false;

            label33.Visible = false;


            Connet.Open();

            String QueryView = "Select * from Contactos";


            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            textBox1.Text = "";

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            button11.Enabled = false;

            button4.Enabled = false;

            textBox19.Text = "";

            comboBox5.SelectedIndex = 0;

            Connet.Close();

           



        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;

            textBox19.Visible = false;

            button4.Visible = false;

            button11.Visible = false;

            comboBox5.Visible = false;

            label33.Visible = false;

            Connet.Open();

            String QueryView = "Select * from Contactos";


            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            textBox1.Text = "";

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            button11.Enabled = false;

            button4.Enabled = false;

            textBox19.Text = "";

            comboBox5.SelectedIndex = 0;

            Connet.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Connet.Open();

            String Code = textBox18.Text;

              int valide = 0;

                if (int.TryParse(Code, out valide))
                { }

                else
                {

                    MessageBox.Show("El ID Debe de Ser Un Valor Númerico", "Error: No se Campo Númerico");

                    Connet.Close();

                    return;
                }

            String QueryView = "Select * from Contactos where ID = " + Code;

            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            if (Registros.Read())
            {

                textBox27.Text = Registros["Nombre"].ToString();
                textBox26.Text = Registros["Apellido"].ToString();
                textBox21.Text = Registros["Nacimiento"].ToString();
                textBox25.Text = Registros["Direccion"].ToString();
                comboBox3.Text = Registros["Genero"].ToString();
                comboBox4.Text = Registros["Estado_Civil"].ToString();
                textBox24.Text = Registros["Movil"].ToString();
                textBox23.Text = Registros["Telefono"].ToString();
                textBox22.Text = Registros["Email"].ToString();

                button9.Enabled = true;

                textBox27.ReadOnly = false;
                textBox26.ReadOnly = false;
                textBox21.ReadOnly = false;
                textBox25.ReadOnly = false;
                comboBox3.Enabled = true;
                comboBox4.Enabled = true;
                textBox24.ReadOnly = false;
                textBox23.ReadOnly = false;
                textBox22.ReadOnly = false; 

            }
            else
            {

                MessageBox.Show("El Contacto Especificado No Existe", "Alerta: Contacto No Existente");
            }


            Connet.Close();
        }

        private void textBox18_TextChanged(object sender, EventArgs e)
        {
            if (textBox18.Text == "")
            {

                button8.Enabled = false;

            }

            else
            {
                button8.Enabled = true;

            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            panel4.Visible = false;

            textBox19.Visible = true;

            button4.Visible = true;

            button11.Visible = true;

            comboBox5.Visible = true;

            label33.Visible = true;

            textBox18.Text = "";

            textBox27.Text = "";
            textBox26.Text = "";
            textBox21.Text = "";
            textBox25.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox24.Text = "";
            textBox23.Text = "";
            textBox22.Text = "";

            textBox27.ReadOnly = true;
            textBox26.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox25.ReadOnly = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox24.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox22.ReadOnly = true;

            button8.Enabled = false;

            button9.Enabled = false;

            panel4.Visible = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {

            String Code = textBox18.Text;

            String Nombre = textBox27.Text;
            String Apellido = textBox26.Text;
            String Nacimiento = textBox21.Text;
            String Direccion = textBox25.Text;
            String Genero = comboBox3.Text;
            String EstadoCivil = comboBox4.Text;
            String Movil = textBox24.Text;
            String Telefono = textBox23.Text;
            String Email = textBox22.Text;

            if (Nombre == "" ||
                Apellido == "" ||
                Direccion == "" ||
                Genero == "" ||
                EstadoCivil == "" ||
                Movil == "" ||
                Telefono == "" ||
                Email == "")
            {

                MessageBox.Show("No Deje Ningun Campo Vacio", "Alerta: Campos Requeridos");

                return;
            }

            Connet.Open();

            String UpdateView = "update Contactos set Nombre = '"+ Nombre + "', Apellido = '" + Apellido + "', Nacimiento = '" + Nacimiento + "', Direccion = '" + Direccion + "', Genero = '" + Genero + "', Estado_Civil = '" + EstadoCivil + "', Movil = '" + Movil + "', Telefono = '" + Telefono + "', Email = '" + Email + "' where ID = " + Code;

            SqlCommand UpdateQuery = new SqlCommand(UpdateView, Connet);

            UpdateQuery.ExecuteNonQuery();

            MessageBox.Show("El Contacto Fue Actualizado Correctamente", "Contacto Actualizado");

            Connet.Close();

            textBox1.Text = "";


            Connet.Open();

            String QueryView = "Select * from Contactos";

            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            Connet.Close();

            textBox19.Visible = true;

            button4.Visible = true;

            button11.Visible = true;

            comboBox5.Visible = true;

            label33.Visible = true;

            textBox27.Text = "";
            textBox26.Text = "";
            textBox21.Text = "";
            textBox25.Text = "";
            comboBox3.SelectedIndex = -1;
            comboBox4.SelectedIndex = -1;
            textBox24.Text = "";
            textBox23.Text = "";
            textBox22.Text = "";

            textBox18.Text = "";

            textBox27.ReadOnly = true;
            textBox26.ReadOnly = true;
            textBox21.ReadOnly = true;
            textBox25.ReadOnly = true;
            comboBox3.Enabled = false;
            comboBox4.Enabled = false;
            textBox24.ReadOnly = true;
            textBox23.ReadOnly = true;
            textBox22.ReadOnly = true; 

            button8.Enabled = false;

            button9.Enabled = false;

            panel4.Visible = false;
        }

        private void textBox19_TextChanged(object sender, EventArgs e)
        {
            if (textBox19.Text == "") {

                button4.Enabled = false;
            }
            else
            {
                button4.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
           

            Connet.Open();

            String Filter = comboBox5.Text;

            String Value = textBox19.Text;

            String QueryView = "";

            if (Filter == "ID") {

                QueryView = "Select * from Contactos where ID = " + Value;

                int valide = 0;

                if (int.TryParse(Value, out valide))
                { }

                else
                {

                    MessageBox.Show("El ID Debe de Ser Un Valor Númerico", "Error: No se Campo Númerico");

                    Connet.Close();

                    return;
                }
            } 
            
            else if(Filter == "Nombre")
            {
                QueryView = "Select * from Contactos where Nombre = '"+ Value + "'";
            }

            else if (Filter == "Apellido")
            {
                QueryView = "Select * from Contactos where Apellido = '" + Value + "'";
            }
            else { }


            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            int count = 0;
                
                textBox1.Text = "";

                while (Registros.Read())
                {
                count += 1;

                    textBox1.AppendText(" ID: ");

                    textBox1.AppendText(Registros["ID"].ToString());

                    textBox1.AppendText("; Nombre: ");

                    textBox1.AppendText(Registros["Nombre"].ToString());

                    textBox1.AppendText("; Apellido: ");

                    textBox1.AppendText(Registros["Apellido"].ToString());

                    textBox1.AppendText("; Nacimiento: ");

                    textBox1.AppendText(Registros["Nacimiento"].ToString());

                    textBox1.AppendText("; Dirección: ");

                    textBox1.AppendText(Registros["Direccion"].ToString());

                    textBox1.AppendText("; Genero: ");

                    textBox1.AppendText(Registros["Genero"].ToString());

                    textBox1.AppendText("; Estado_Civil: ");

                    textBox1.AppendText(Registros["Estado_Civil"].ToString());

                    textBox1.AppendText("; Movil: ");

                    textBox1.AppendText(Registros["Movil"].ToString());

                    textBox1.AppendText("; Telefono: ");

                    textBox1.AppendText(Registros["Telefono"].ToString());

                    textBox1.AppendText("; Email ");

                    textBox1.AppendText(Registros["Email"].ToString());

                    textBox1.AppendText(Environment.NewLine);

                    textBox1.AppendText(Environment.NewLine);



            }

            if (count == 0) {

                textBox1.Text = "No Se Encontro Ningún Contacto Con Esa Descripción";
            }
            else { }
          

            button11.Enabled = true;

            Connet.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;

            textBox19.Visible = false;

            button4.Visible = false;

            button11.Visible = false;

            comboBox5.Visible = false;

            label33.Visible = false;

            Connet.Open();

            String QueryView = "Select * from Contactos";


            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            textBox1.Text = "";

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            button11.Enabled = false;

            button4.Enabled = false;

            textBox19.Text = "";

            comboBox5.SelectedIndex = 0;

            Connet.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Connet.Open();

            String QueryView = "Select * from Contactos";


            SqlCommand GetQuery = new SqlCommand(QueryView, Connet);

            SqlDataReader Registros = GetQuery.ExecuteReader();

            textBox1.Text = "";

            while (Registros.Read())
            {
                textBox1.AppendText(" ID: ");

                textBox1.AppendText(Registros["ID"].ToString());

                textBox1.AppendText("; Nombre: ");

                textBox1.AppendText(Registros["Nombre"].ToString());

                textBox1.AppendText("; Apellido: ");

                textBox1.AppendText(Registros["Apellido"].ToString());

                textBox1.AppendText("; Nacimiento: ");

                textBox1.AppendText(Registros["Nacimiento"].ToString());

                textBox1.AppendText("; Dirección: ");

                textBox1.AppendText(Registros["Direccion"].ToString());

                textBox1.AppendText("; Genero: ");

                textBox1.AppendText(Registros["Genero"].ToString());

                textBox1.AppendText("; Estado_Civil: ");

                textBox1.AppendText(Registros["Estado_Civil"].ToString());

                textBox1.AppendText("; Movil: ");

                textBox1.AppendText(Registros["Movil"].ToString());

                textBox1.AppendText("; Telefono: ");

                textBox1.AppendText(Registros["Telefono"].ToString());

                textBox1.AppendText("; Email ");

                textBox1.AppendText(Registros["Email"].ToString());

                textBox1.AppendText(Environment.NewLine);

                textBox1.AppendText(Environment.NewLine);

            }

            button11.Enabled = false;

            button4.Enabled = false;

            textBox19.Text = "";

            Connet.Close();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;

            textBox19.Visible = true;

            button4.Visible = true;

            button11.Visible = true;

            comboBox5.Visible = true;

            label33.Visible = true;

            textBox2.Text = "";
            textBox3.Text = "";
            textBox5.Text = "";
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            textBox8.Text = "";
            textBox9.Text = "";
            textBox4.Text = "";


        }

        private void button13_Click(object sender, EventArgs e)
        {

            panel3.Visible = false;

            textBox19.Visible = true;

            button4.Visible = true;

            button11.Visible = true;

            comboBox5.Visible = true;

            label33.Visible = true;

            textBox13.Text = "";
            textBox12.Text = "";
            textBox14.Text = "";
            textBox11.Text = "";
            textBox15.Text = "";
            textBox16.Text = "";
            textBox10.Text = "";
            textBox7.Text = "";
            textBox6.Text = "";
            textBox17.Text = "";

            button6.Enabled = false;
        }
    }
}
