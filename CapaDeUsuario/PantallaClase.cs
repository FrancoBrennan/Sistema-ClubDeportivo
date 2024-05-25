using CapaDeNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaDeUsuario
{
    public partial class PantallaClase : Form
    {
        private Clase clase;
        private List<Actividad> actividades;
        private List<Profesor> profesores;

        //Este contructor se usa para modificar
        public PantallaClase(Clase clase, List<Actividad> actividades, List<Profesor> profesores)
        {
            InitializeComponent();
            this.clase = clase;
            this.actividades = actividades;
            this.profesores = profesores;

            this.textBox1.Text = clase.Id.ToString();
            this.textBox2.Text = clase.CupoMax.ToString();
            this.textBox4.Text = clase.Hora.ToString();

            llenarProfesores();
            llenarActividades();
            llenarDias();

            this.comboBox1.Text = clase.Act.ToString();
            this.comboBox2.Text = clase.Prof.ToString();
            this.comboBox3.Text = clase.Dia.ToString();

            this.listBox1.DataSource = clase.Socios;

            this.textBox1.ReadOnly = true;
        }

        //Este para crear
        public PantallaClase(List<Actividad> actividades, List<Profesor> profesores)
        {
            InitializeComponent();
            this.actividades = actividades;
            this.profesores = profesores;

            llenarProfesores();
            llenarActividades();
            llenarDias();

            this.label7.Visible = false;
            this.listBox1.Visible = false;
        }

        public Clase Clase
        {
            get { return this.clase; }
            set { this.clase = value; }
        }

        private void llenarProfesores()
        {
            foreach (Profesor profesor in profesores)
            {
                this.comboBox2.Items.Add(profesor);
            }
        }

        private void llenarActividades()
        {
            foreach (Actividad actividad in actividades)
            {
                this.comboBox1.Items.Add(actividad);
            }
        }

        private void llenarDias()
        {
            foreach (string dia in obtenerDiasDeSemana())
            {
                this.comboBox3.Items.Add(dia);
            }
        }

        private void Aceptar_Click(object sender, EventArgs e)
        {

            try
            {
                if (textBox1.Text.Length == 0 || textBox2.Text.Length == 0 || comboBox3.Text.Length == 0 || textBox4.Text.Length == 0 || comboBox1.Text.Length == 0 || comboBox2.Text.Length == 0)
                {
                    throw new Exception("Hay campos vacíos !");
                }


                if (!verificarDia(comboBox3.Text))
                {
                    throw new Exception("Formato incorrecto !");
                }

                int id = int.Parse(this.textBox1.Text);
                int cupo = int.Parse(this.textBox2.Text);
                string dia = this.comboBox3.Text;
                int hora = int.Parse(this.textBox4.Text);

                Actividad actividad = (Actividad)this.comboBox1.SelectedItem;
                Profesor profesor = (Profesor)this.comboBox2.SelectedItem;

                if (clase == null)
                {
                    this.clase = new Clase(id, actividad, dia, hora, new List<Socio>(), profesor, cupo);
                }
                else
                {
                    this.clase.CupoMax = cupo;
                    this.clase.Dia = dia;
                    this.clase.Hora = hora;

                    //BD: Eliminar relacion con actividad vieja
                    this.clase.Act.quitarClaseBD(clase);

                    this.clase.Act = actividad;

                    //BD: Crear relacion con actividad nueva

                    this.clase.Act.agregarClaseBD(clase);

                    //BD: Eliminar relacion con profesor viejo

                    this.clase.Prof.quitarClaseBD(clase);

                    this.clase.Prof = profesor;

                    //BD: Crear relacion con profesor nuevo

                    this.clase.Prof.agregarClaseBD(clase);
                }



                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Cancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool verificarDia(string dia)
        {
            return obtenerDiasDeSemana().Any(d => d.Equals(dia.ToLower()));
        }

        private List<string> obtenerDiasDeSemana()
        {
            return new List<string> { "lunes", "martes", "miércoles", "jueves", "viernes", "sábado", "domingo" };
        }
    }

    }
