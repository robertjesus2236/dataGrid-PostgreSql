using Npgsql;
using System.Windows.Forms;

namespace dgv_base_de_datos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string email = txtEmail.Text;
            string descripcion = txtDescripcion.Text;

            dataGridView1.Rows.Add(usuario, email, descripcion);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var connectionString = "Server=localhost;Database=factura;User Id=postgres;Password=1234;";
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    var columna1 = row.Cells[0].Value.ToString();
                    var columna2 = row.Cells[1].Value.ToString();
                    var columna3 = row.Cells[2].Value.ToString();
                 
                    // Obtener los demás valores de las celdas

                    var insertQuery = "INSERT INTO usuarios1 (usuario, email, descripcion) VALUES (@usuario, @email, @descripcion);";
                    using (var cmd = new NpgsqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("usuario", columna1);
                        cmd.Parameters.AddWithValue("email", columna2);
                        cmd.Parameters.AddWithValue("descripcion", columna3);
                        // Agregar los demás parámetros según las columnas de la tabla

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Se ha registrado con existo");
                    }
                }
            }
        }
    }
}