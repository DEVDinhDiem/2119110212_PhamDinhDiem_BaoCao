using BaoCao.BAL;
using BaoCao.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaoCao
{
    public partial class Form1 : Form
    {
        EmployeeBAL empBAL = new EmployeeBAL();
        DepartmentBAL depBAL = new DepartmentBAL();
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            List<EmployeeBEL> lstemp = empBAL.ReadEmployee();
            foreach (EmployeeBEL emp in lstemp)
            {
                dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.NameDepartment);
            }
            List<DepartmentBEL> lstDepartment = depBAL.ReadDepartmentList();
            foreach (DepartmentBEL department in lstDepartment)
            {
                comboBoxDV.Items.Add(department);
            }
            comboBoxDV.DisplayMember = "Name";
        }
        private void dgvEmployee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                txtMa.Text = dgvEmployee.Rows[idx].Cells[0].Value.ToString();
                txtName.Text = dgvEmployee.Rows[idx].Cells[1].Value.ToString();
                datebỉth.Text = dgvEmployee.Rows[idx].Cells[2].Value.ToString();
                string cb = dgvEmployee.Rows[idx].Cells[3].Value.ToString();
                if (cb == "True")
                {
                    cbGioiTinh.Checked = true;
                }   
                {
                    cbGioiTinh.Checked = false;
                }
                txtNoiSinh.Text = dgvEmployee.Rows[idx].Cells[4].Value.ToString();
                comboBoxDV.Text = dgvEmployee.Rows[idx].Cells[5].Value.ToString();             
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            List<EmployeeBEL> lstemp = empBAL.ReadEmployee();
            if (lstemp.Any(item => item.IdEmployee.ToString() == txtMa.Text) == true)//kiểm tra trùng masv hay kh
            {
                MessageBox.Show("Trùng MSSV ", "Cảnh Báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (txtMa.Text == "" || txtName.Text == "")//masv va ten kh được để trống
                {
                    MessageBox.Show("Mã và Tên không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }                           
                    EmployeeBEL emp = new EmployeeBEL();
                    emp.IdEmployee = txtMa.Text;
                    emp.Name = txtName.Text;
                    emp.DateBirth = datebỉth.Value;
                    emp.Gender = cbGioiTinh.Checked;
                    emp.PlaceBirth = txtNoiSinh.Text;
                    emp.Department = (DepartmentBEL)comboBoxDV.SelectedItem;
                    empBAL.NewEmployee(emp);
                    dgvEmployee.Rows.Add(emp.IdEmployee, emp.Name, emp.DateBirth.ToShortDateString(), emp.Gender, emp.PlaceBirth, emp.Department.Name);
                    //clear data box
                    txtMa.Text = "";
                    txtName.Text = "";
                    datebỉth.Text = "";
                    cbGioiTinh.Checked = false;
                    txtNoiSinh.Text = "";
                    comboBoxDV.Text = "";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtMa.Text == "")//xem masv để trống không
            {
                MessageBox.Show("Vui lòng chọn Sinh Viên để xoá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
           if (MessageBox.Show("Bạn có muốn xóa hay không", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                EmployeeBEL emp = new EmployeeBEL();
                emp.IdEmployee = txtMa.Text.ToString();
                empBAL.DeleteEmployee(emp);
                int idx = dgvEmployee.CurrentCell.RowIndex;
                dgvEmployee.Rows.RemoveAt(idx);
                //clear data box
                txtMa.Text = "";
                txtName.Text = "";
                datebỉth.Text = "";
                cbGioiTinh.Checked = false;
                txtNoiSinh.Text = "";
                comboBoxDV.Text = "";
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DataGridViewRow row = dgvEmployee.CurrentRow;
            if (row != null)
            {
                if (txtName.Text == "")
                {
                    MessageBox.Show("Tên không được để trống", "Lưu Ý", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                if (txtName.Text != "" & txtNoiSinh.Text != "")
                {
                    EmployeeBEL emp = new EmployeeBEL();
                    emp.IdEmployee = txtMa.Text;
                    emp.Name = txtName.Text;
                    emp.DateBirth = datebỉth.Value;
                    emp.Gender = cbGioiTinh.Checked;
                    emp.PlaceBirth = txtNoiSinh.Text;
                    emp.Department = (DepartmentBEL)comboBoxDV.SelectedItem;
                    empBAL.EditEmployee(emp);
                    //sua data vao grid view
                    row.Cells[0].Value = emp.IdEmployee;
                    row.Cells[1].Value = emp.Name;
                    row.Cells[2].Value = emp.DateBirth.ToShortDateString();
                    row.Cells[3].Value = emp.Gender;
                    row.Cells[4].Value = emp.PlaceBirth;
                    row.Cells[5].Value = emp.Department.Name;
                    //clear data box
                    txtMa.Text = "";
                    txtName.Text = "";
                    datebỉth.Text = "";
                    cbGioiTinh.Checked = false;
                    txtNoiSinh.Text = "";
                    comboBoxDV.Text = "";
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn Có muốn Thoát", "Thoát Chương Trình", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            switch (result)
            {
                case DialogResult.No:
                    //khong thoat
                    break;
                case DialogResult.Yes:
                    this.Close();
                    break;
                default:
                    break;
            }
            //if (MessageBox.Show("Bạn có muốn thoát hay không", "Thoát Chương Trình", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            //    this.Close();
        }


    }
}
