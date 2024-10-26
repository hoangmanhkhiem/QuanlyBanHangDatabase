using QuanLyBanHang.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyBanHang
{
    public partial class frmMatHang : Form
    {
        DataBaseProcess dtbase = new DataBaseProcess();

        public frmMatHang()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void pnlChucNang_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTieuDe_Paint(object sender, PaintEventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
            bool hien = true;
            HienChiTiet(hien);

        }
        private void HienChiTiet(bool hien)
        {
            txtMaSP.Enabled = hien;
            txtTenSP.Enabled = hien;
            dtpNgayHH.Enabled = hien;
            dtpNgaySX.Enabled = hien;
            txtDonVi.Enabled = hien;
            txtDonGia.Enabled = hien;
            txtGhiChu.Enabled = hien;
            btnLuu.Enabled = hien;
            btnHuy.Enabled = hien;
        }

        private void frmMatHang_Load(object sender, EventArgs e)
        {

            dgvMatHang.DataSource = dtbase.DataReader("Select * from tblMatHang");
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(false);

        }

        private void dgvMatHang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            btnThem.Enabled = false;
            try
            {
                txtMaSP.Text = dgvMatHang.CurrentRow.Cells[0].Value.ToString();
                txtTenSP.Text = dgvMatHang.CurrentRow.Cells[1].Value.ToString();
                dtpNgaySX.Value = (DateTime)dgvMatHang.CurrentRow.Cells[2].Value;
                dtpNgayHH.Value = (DateTime)dgvMatHang.CurrentRow.Cells[3].Value;
                txtDonVi.Text = dgvMatHang.CurrentRow.Cells[4].Value.ToString();
                txtDonGia.Text = dgvMatHang.CurrentRow.Cells[5].Value.ToString();
                txtGhiChu.Text = dgvMatHang.CurrentRow.Cells[6].Value.ToString();
            }
            catch (Exception)
            {
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "TÌM KIẾM MẶT HÀNG";
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            string sql = "SELECT * FROM tblMatHang where MaSP is not null ";
            if (txtTKMaSP.Text.Trim() != "")
            {
                sql += " and MaSP like '%" + txtTKMaSP.Text + "%'";
            }
            if (txtTKTenSP.Text.Trim() != "")
            {
                sql += " AND TenSP like N'%" + txtTKTenSP.Text + "%'";
            }
            dgvMatHang.DataSource = dtbase.DataReader(sql);

        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
  
            if (MessageBox.Show("Bạn  có  chắc  chắn  xóa  mã  mặt  hàng  " + txtMaSP.Text + " không ? Nếu  có  ấn  nút  Lưu, không  thì  ấn  nút  Hủy", "Xóa  sản  phẩm", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                lblTieuDe.Text = "XÓA MẶT HÀNG";
                btnThem.Enabled = false;
                btnSua.Enabled = false;
                HienChiTiet(true);
            }

        }

        private void XoaTrangChiTiet()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            dtpNgaySX.Value = DateTime.Today;
            dtpNgayHH.Value = DateTime.Today;
            txtDonVi.Text = "";
            txtDonGia.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "THÊM MẶT HÀNG";
            XoaTrangChiTiet();
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            lblTieuDe.Text = "CẬP NHẬT MẶ HÀNG";
            btnThem.Enabled = false;
            btnXoa.Enabled = false;
            HienChiTiet(true);

        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            string sql = "";
            if (txtTenSP.Text.Trim() == "")
            {
                errChiTiet.SetError(txtTenSP, "Bạn không để trống tên sản phẩm!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            if (dtpNgaySX.Value > DateTime.Now)
            {
                errChiTiet.SetError(dtpNgaySX, "Ngày sản xuất không hợp lệ!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            if (dtpNgayHH.Value < dtpNgaySX.Value)
            {
                errChiTiet.SetError(dtpNgayHH, "Ngay  hết  hạn  nhỏ  hơn  ngày  sản  xuất!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            if (txtDonVi.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDonVi, "Bạn  không  để  trống  đơn  vi!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            if (txtDonGia.Text.Trim() == "")
            {
                errChiTiet.SetError(txtDonGia, "Bạn  không  để  trống  đơn  giá!");
                return;
            }
            else
            {
                errChiTiet.Clear();
            }
            if (btnThem.Enabled == true)
            { 
                if (txtMaSP.Text.Trim() == "")
                {
                    errChiTiet.SetError(txtMaSP, "Bạn  không  để  trống  mã  sản phẩm  trường  này!");
                    return;
                }
                else
                {  
                    sql = "Select  *  From  tblMatHang  Where  MaSP  ='" + txtMaSP.Text + "'";
                    DataTable dtSP = dtbase.DataReader(sql);
                    if (dtSP.Rows.Count > 0)
                    {
                        errChiTiet.SetError(txtMaSP, "Mã sản phẩm trùng trong cơ sở dữ liệu");
                        return;
                    }
                    errChiTiet.Clear();
                }
                sql = "INSERT  INTO  tblMatHang(MaSP, TenSP, NgaySX, NgayHH, DonVi, DonGia, GhiChu) VALUES(";
                sql += "N'" + txtMaSP.Text + "',N'" + txtTenSP.Text + "','" + dtpNgaySX.Value.Date + "','" +
                    dtpNgayHH.Value.Date + "',N'" + txtDonVi.Text + "',N'" + txtDonGia.Text + "',N'" + txtGhiChu.Text + "')";
            }
            if (btnSua.Enabled == true)
            {
                sql = "Update tblMatHang SET ";
                sql += "TenSP = N'" + txtTenSP.Text + "',";
                sql += "NgaySX = '" + dtpNgaySX.Value.Date + "',";
                sql += "NgayHH = '" + dtpNgayHH.Value.Date + "',";
                sql += "DonVi = N'" + txtDonVi.Text + "',";
                sql += "DonGia = '" + txtDonGia.Text + "',";
                sql += "GhiChu = N'" + txtGhiChu.Text + "' ";
                sql += "Where MaSP = N'" + txtMaSP.Text + "'";
            }
            if (btnXoa.Enabled == true)
            {
                sql = "Delete From tblMatHang Where MaSP =N'" + txtMaSP.Text + "'";
            }
            dtbase.DataChange(sql);
            sql = "Select * from tblMatHang";
            dgvMatHang.DataSource = dtbase.DataReader(sql);
            HienChiTiet(false);
            btnSua.Enabled = false;
            btnXoa.Enabled = false;

        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            btnXoa.Enabled = false;
            btnSua.Enabled = false;
            btnThem.Enabled = true;
            XoaTrangChiTiet();
            HienChiTiet(false);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn thoát không?", "TB", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter_1(object sender, EventArgs e)
        {

        }
    }
}

