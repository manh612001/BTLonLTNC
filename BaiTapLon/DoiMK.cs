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
    public partial class DoiMK : Form
    {
        public DoiMK()
        {
            InitializeComponent();
        }
        string str = @"Data Source=DESKTOP-201IC1A\SQLEXPRESS;Initial Catalog=QLyDiemSV;Integrated Security=True";
        private void btdoimk_Click(object sender, EventArgs e)
        {
            if (txtmkmoi.Text == txtxnmk.Text)
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string sql = "Update DangNhap set PassWord ='" + txtmkmoi.Text + "'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
                
                conn.Close();
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmkcu.Text = txtmkmoi.Text = txtxnmk.Text = "";
            }
            else if(txtmkcu.Text=="" || txtmkmoi.Text=="" || txtxnmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!","Thông báo!",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Mật khẩu không trùng khớp vui lòng nhập lại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btcancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có muốn hủy bỏ!", "Thông báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Question)==DialogResult.OK)
            {
                this.Close();
            }    
        }

     
    }
}
