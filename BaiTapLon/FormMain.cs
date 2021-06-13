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
using System.Diagnostics;
namespace BaiTapLon
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            

        }
        string str = @"Data Source=DESKTOP-201IC1A\SQLEXPRESS;Initial Catalog=QLyDiemSV;Integrated Security=True";
        void LoadData2()
        {
            ConnectionDB conn = new ConnectionDB();
            string sql = "select * from SINHVIEN";
            DataTable dt = new DataTable();
            dt = conn.getTable(sql);
            dataGridView2.DataSource = dt;
        }
        void LoadData3()
        {
            ConnectionDB conn = new ConnectionDB();
            string sql = "select SINHVIEN.MãSV,SINHVIEN.HọTên,SINHVIEN.Lớp,Diem.MãMH,Diem.TênMH,Diem.ĐiểmQT,Diem.ĐiểmThi" +
                " from SINHVIEN, Diem" +
                " where SINHVIEN.MãSV = Diem.MãSV ";
            DataTable dt = new DataTable();
            dt = conn.getTable(sql);
            dataGridView3.DataSource = dt;
            
        }
        void LoadData1()
        {
            ConnectionDB conn = new ConnectionDB();
            string sql = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,Diem.TênMH,Diem.SốTín,Diem.LầnThi,Diem.ĐiểmQT, Diem.ĐiểmThi ,Tổng = (Diem.ĐiểmQT*0.5 + Diem.ĐiểmThi*0.5)  From Diem, SINHVIEN Where(Diem.MãSV = SINHVIEN.MãSV)  ";
            DataTable dt = new DataTable();
            dt = conn.getTable(sql);
            dataGridView1.DataSource = dt; 
        }
        void TimKiem2()
        {
            ConnectionDB conn = new ConnectionDB();
            string query = "SELECT* FROM SINHVIEN  WHERE HọTên like N'%" + txtTimKiem.Text + "%' and Lớp = '"+cbTraCuuLop2.Text+"'";
            DataTable dt = new DataTable();
            dt = conn.getTable(query);
            dataGridView2.DataSource = dt;  
        }
        void TimKiem3()
        {
            ConnectionDB conn = new ConnectionDB();
            string query = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,SINHVIEN.Lớp,Diem.MãMH,Diem.TênMH, Diem.ĐiểmQT,Diem.ĐiểmThi From Diem, SINHVIEN Where(Diem.MãSV = SINHVIEN.MãSV) and (SINHVIEN.HọTên like N'%"+txtTimKiem3.Text+ "%'  and SINHVIEN.Lớp = '"+cbTraCuuLop.Text+"')";
            DataTable dt = new DataTable();
            dt = conn.getTable(query);
            dataGridView3.DataSource = dt;
        }
        void TimKiem1()
        {
            try
            {
                ConnectionDB conn = new ConnectionDB();
                string query = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,Diem.TênMH,Diem.SốTín,Diem.LầnThi,Diem.ĐiểmQT, Diem.ĐiểmThi,Tổng = (Diem.ĐiểmQT*0.5 + Diem.ĐiểmThi*0.5) From Diem, SINHVIEN Where (Diem.MãSV = SINHVIEN.MãSV)  and ( Diem.MãMH like '" + cbMaMH4.Text + "' and SINHVIEN.Lớp = '" + cbLop4.Text + "')";
                DataTable dt = new DataTable();
                dt = conn.getTable(query);
                dataGridView1.DataSource = dt;
            }
            catch(Exception)
            {
                MessageBox.Show("Tra cứu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
            
        }
        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            TimKiem2();
            
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            LoadData2();         
            LoadData3();
            LoadData1();
        }

        private void dataGridView2_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
           // txtMaSV2.Text = txtHoTen2.Text = cbQueQuan2.Text = cbLop2.Text = cbKhoa2.Text="";
            txtMaSV2.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtMaSV3.Text = dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen2.Text = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            dtpNgaySinh.Text = dataGridView2.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbQueQuan2.Text = dataGridView2.Rows[e.RowIndex].Cells[3].Value.ToString();
            if (dataGridView2.Rows[e.RowIndex].Cells[4].Value.ToString().Trim() == "Nam")
            {
                rdNam.Checked = true;
            }
            else
                rdNu.Checked = true;
            cbLop2.Text = dataGridView2.Rows[e.RowIndex].Cells[5].Value.ToString();
            cbKhoa2.Text = dataGridView2.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //txtMaSV3.Text = txtHoTen3.Text = cbLop3.Text = cbMaMH3.Text = cbTenMH3.Text = txtDiemThi3.Text = "";
            txtMaSV3.Text = dataGridView3.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtHoTen3.Text = dataGridView3.Rows[e.RowIndex].Cells[1].Value.ToString();
            cbLop3.Text = dataGridView3.Rows[e.RowIndex].Cells[2].Value.ToString();
            cbMaMH3.Text = dataGridView3.Rows[e.RowIndex].Cells[3].Value.ToString();
            cbTenMH3.Text = dataGridView3.Rows[e.RowIndex].Cells[4].Value.ToString();
            txtDiemQT3.Text = dataGridView3.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtDiemThi3.Text = dataGridView3.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            cbLop4.Text = cbMaMH4.Text = "";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TimKiem3();
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            string ten = txtHoTen2.Text;
            string ngaysinh = dtpNgaySinh.Value.ToString();
            string quequan = cbQueQuan2.Text;
            string lop = cbLop2.Text;
            string khoa = cbKhoa2.Text;
            string gioitinh = "";
            if (rdNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else if(rdNu.Checked == true)
                gioitinh = "Nữ";
            try
            {
                SqlConnection conn = new SqlConnection(str);

                string query = "update SINHVIEN set HọTên = N'" + ten + "',NgàySinh = '" + ngaysinh + "',QuêQuán = N'" + quequan + "',Lớp = '" + lop + "',Khoa = N'" + khoa + "',GiớiTính = N'" + gioitinh + "' where MãSV = '" + txtMaSV2.Text.Trim() + "' ";
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();

                cmd.ExecuteNonQuery();
                LoadData2();
                MessageBox.Show("Sửa đổi thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);

                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Sửa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TimKiem1();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://www.tlu.edu.vn/");
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            string masv = txtMaSV2.Text;
            string ten = txtHoTen2.Text;
            string quequan = cbQueQuan2.Text;
            string lop = cbLop2.Text;
            string khoa = cbKhoa2.Text;
            string gioitinh = "";
            if (rdNam.Checked == true)
            {
                gioitinh = "Nam";
            }
            else if (rdNu.Checked == true)
                gioitinh = "Nữ";
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string sql_insert = "INSERT INTO SINHVIEN VALUES ('" + masv + "',N'" + ten + "','" + dtpNgaySinh.Value.Date + "',N'" + quequan + "',N'" + gioitinh + "','" + lop + "',N'" + khoa + "')" +
                    "insert into Diem Values('" + masv + "','','','','','','')";
                SqlCommand cmd = new SqlCommand(sql_insert, conn);
                SqlDataAdapter daSV = new SqlDataAdapter(cmd);

                cmd.ExecuteNonQuery();
                LoadData2();

                MessageBox.Show("Thêm thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có muốn xóa dữ liệu?", "Cảnh báo!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    SqlConnection conn = new SqlConnection(str);
                    conn.Open();
                    string query = " DELETE FROM Diem WHERE MãSV = '" + txtMaSV2.Text + "'" + "delete from SINHVIEN where MãSV = '" + txtMaSV2.Text + "'";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.ExecuteNonQuery();
                    LoadData2();
                    conn.Close();
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Xóa dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string masv = txtMaSV3.Text;
            string ten = txtHoTen3.Text;
            string lop = cbLop3.Text;
            string MaMH = cbMaMH3.Text;
            string tenMH = cbTenMH3.Text;
            string diemQT = txtDiemQT3.Text;
            string diemthi = txtDiemThi3.Text;
            string sotin = txtSoTin3.Text;
            string lanthi = txtLanthi3.Text;
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string update = "Update Diem Set MãMH = '" + MaMH + "',TênMH = N'" + tenMH + "',SốTín = '" + sotin + "',LầnThi = '" + lanthi + "',ĐiểmQT = '" + diemQT + "',ĐiểmThi = '" + diemthi + "' Where MãSV = '" + masv + "'";
                SqlCommand cmd = new SqlCommand(update, conn);
                cmd.ExecuteNonQuery();

                LoadData3();
                MessageBox.Show("Cập nhập thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                conn.Close();
            }
            catch(Exception)
            {
                MessageBox.Show("Cập nhập dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbMaMH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMaMH3.SelectedIndex == 0)
               cbTenMH3.SelectedIndex = 0;
            else if (cbMaMH3.SelectedIndex == 1)
                cbTenMH3.SelectedIndex = 1;
            if(cbMaMH3.SelectedIndex == 2)
                cbTenMH3.SelectedIndex = 2;
        }

        private void cbTenMH3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTenMH3.Text == "Cơ sở dữ liệu")
                cbMaMH3.Text = "CSE484";
            else if (cbTenMH3.Text == "Lập trình nâng cao")
                cbMaMH3.Text = "CSE381";
            else  
                cbMaMH3.Text = "CSE281";
        }

        private void cbTraCuuLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTraCuuLop.SelectedIndex !=0)
            {
                ConnectionDB conn = new ConnectionDB();
                string query = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,SINHVIEN.Lớp,Diem.MãMH,Diem.TênMH, Diem.ĐiểmThi From Diem, SINHVIEN Where(Diem.MãSV = SINHVIEN.MãSV) and SINHVIEN.Lớp = '" + cbTraCuuLop.Text + "'";
                DataTable dt = new DataTable();
                dt = conn.getTable(query);
                dataGridView3.DataSource = dt;

            }
            else
                LoadData3();
        }
        DangNhap form1 = new DangNhap();
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();

            DangNhap f= new DangNhap();
            f.Show();

        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DoiMK f = new DoiMK();
            f.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(str);
                conn.Open();
                string query = "insert into Diem  values ('" + txtMaSV3.Text + "','" + cbMaMH3.Text + "',N'" + cbTenMH3.Text + "','" + txtSoTin3.Text + "','" + txtLanthi3.Text + "','" + txtDiemQT3.Text + "','" + txtDiemThi3.Text + "') ";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();
                LoadData3();
                conn.Close();
                MessageBox.Show("Thêm thông tin thành công ", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Thêm dữ liệu thất bại!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string masv = txtMaSV3.Text;
            string ten = txtHoTen3.Text;
            string lop = cbLop3.Text;
            string MaMH = cbMaMH3.Text;
            string tenMH = cbTenMH3.Text;
            string diemthi = txtDiemThi3.Text;
            string diemQT = txtDiemQT3.Text;
            string sotin = txtSoTin3.Text;
            string lanthi = txtLanthi3.Text;
            SqlConnection conn = new SqlConnection(str);
            conn.Open();
            string update = "Update Diem Set TênMH = N'" + tenMH + "',SốTín = '" + sotin + "',LầnThi = '" + lanthi + "',ĐiểmQT = '"+diemQT+"',ĐiểmThi = '" + diemthi + "' Where MãSV = '" + masv + "'";
            SqlCommand cmd = new SqlCommand(update, conn);
            cmd.ExecuteNonQuery();
            LoadData3();
            MessageBox.Show("Thêm thông tin thành công!", "Thông báo!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            conn.Close();
        }

        

        private void cbSapXep_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbSapXep.SelectedIndex == 1)
            {
                ConnectionDB conn = new ConnectionDB();
                string query = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,Diem.TênMH,Diem.SốTín,Diem.LầnThi,Diem.ĐiểmQT, Diem.ĐiểmThi,Tổng = (Diem.ĐiểmQT*0.5 + Diem.ĐiểmThi*0.5)" +
                    " From Diem, SINHVIEN " +
                    "Where (Diem.MãSV = SINHVIEN.MãSV)  and ( Diem.MãMH like '" + cbMaMH4.Text + "' and SINHVIEN.Lớp = '" + cbLop4.Text + "')" +
                    "Order by  Diem.ĐiểmThi ASC";
                DataTable dt = new DataTable();
                dt = conn.getTable(query);
                dataGridView1.DataSource = dt;
            }
            else if (cbSapXep.SelectedIndex == 2)
            {
                ConnectionDB conn = new ConnectionDB();
                string query = "SELECT SINHVIEN.MãSV,SINHVIEN.HọTên,Diem.TênMH,Diem.SốTín,Diem.LầnThi, Diem.ĐiểmQT,Diem.ĐiểmThi,Tổng = (Diem.ĐiểmQT*0.5 + Diem.ĐiểmThi*0.5)" +
                    " From Diem, SINHVIEN " +
                    "Where (Diem.MãSV = SINHVIEN.MãSV)  and ( Diem.MãMH like '" + cbMaMH4.Text + "' and SINHVIEN.Lớp = '" + cbLop4.Text + "')" +
                    "Order by Diem.ĐiểmThi DESC";
                DataTable dt = new DataTable();
                dt = conn.getTable(query);
                dataGridView1.DataSource = dt; 
            }
            else
                TimKiem1();
        }

        private void cbTraCuuLop2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTraCuuLop2.SelectedIndex != 0)
            {
                ConnectionDB conn = new ConnectionDB();
                string sql = "select * from SINHVIEN where SINHVIEN.Lớp = '" + cbTraCuuLop2.Text + "'";
                DataTable dt = new DataTable();
                dt = conn.getTable(sql);
                dataGridView2.DataSource = dt;
            }
            else
                LoadData2();
        }

        private void cbLop4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLop4.SelectedIndex == 0)
            {
                LoadData1();
                cbMaMH4.SelectedIndex = 0; 
            }    
        }
    }
}
