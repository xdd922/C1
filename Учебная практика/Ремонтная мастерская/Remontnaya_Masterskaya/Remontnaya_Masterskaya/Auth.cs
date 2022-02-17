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

namespace Remontnaya_Masterskaya
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        private void Avtorizatsiya_Vhod_Click(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(@"Data Source=DESKTOP-4QTHHHR\SQLEXPRESS;Initial Catalog=Мебельная_фабрика;Integrated Security=True");
            SqlCommand sqlcom = new SqlCommand("Select * from Пользователи where Логин = '" + tbLogin.Text.Trim() + "' and Пароль = '" + tbParol.Text.Trim() + "' ", sqlcon);
            SqlDataAdapter sda = new SqlDataAdapter(sqlcom);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            string cmbItemValue = cbRol.SelectedItem.ToString();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i]["Роль"].ToString() == cmbItemValue)
                    {
                        MessageBox.Show("Здравствуйте, " + dt.Rows[i][1]);
                        if (cbRol.SelectedIndex == 0)
                        {
                            Polzovatel pl = new Polzovatel();
                            pl.Show();
                            this.Hide();
                        }
                        else
                        {
                            Polzovatel pl = new Polzovatel();
                            pl.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        MessageBox.Show("Неправильно введены данные");
                        tbLogin.Clear();
                        tbParol.Clear();
                    }
                }
            }
            if (cbRol.Text == "Менеджер")
            {
                Tip_Polzovatelya.Rol = "Менеджер";
            }
            if (cbRol.Text == "Заместитель директора")
            {
                Tip_Polzovatelya.Rol = "Заместитель директора";
            }
            if (cbRol.Text == "Заказчик")
            {
                Tip_Polzovatelya.Rol = "Заказчик";
            }
            if (cbRol.Text == "Директор")
            {
                Tip_Polzovatelya.Rol = "Директор";
            }
            if (cbRol.Text == "Мастер")
            {
                Tip_Polzovatelya.Rol = "Мастер";
            }
        }
    }
}
