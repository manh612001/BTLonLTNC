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

namespace BaiTapLon
{
    public partial class DangNhap : Form
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        string str = @"Data Source=DESKTOP-201IC1A\SQLEXPRESS;Initial Catalog=QLyDiemSV;Integrated Security=True";
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "SELECT * FROM DangNhap where UserName = '" + txtTaiKhoan.Text + "' and  PassWord = '" + txtMatKhau.Text + "'";
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlDataReader dta = cmd.ExecuteReader();
                if (dta.Read() == true)

                {
                    this.Hide();
                    FormMain f = new FormMain();
                    f.ShowDialog();

                    conn.Close();
                }
                else
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi không kết nối được!");
            }

        }
          
        private void CkBMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (CkBMatKhau.Checked)
                txtMatKhau.UseSystemPasswordChar = true;
            else
                txtMatKhau.UseSystemPasswordChar = false;
        }
    }
}
