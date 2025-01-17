﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;

namespace PersonalTracking
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = General.isNumber(e);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (txtUserNo.Text.Trim() == "" || txtPassword.Text.Trim() == "")
            {
                MessageBox.Show("Please fill the userno and password");
            }
            else
            {
                List<EMPOLYEE> employeelist = EmployeeBLL.GetEmployees(Convert.ToInt32(txtUserNo.Text), txtPassword.Text);
                if (employeelist.Count == 0)
                {
                    MessageBox.Show("Please control your information");
                }
                else
                {
                    EMPOLYEE employee = new EMPOLYEE();
                    employee = employeelist.First();
                    UserStat.EmployeeID = employee.ID;
                    UserStat.UserID = employee.UserNumber;
                    UserStat.isAdmin = Convert.ToBoolean(employee.isAdmin);
                    FrmMain frm = new FrmMain();
                    this.Hide();
                    frm.ShowDialog();
                }
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
        }
    }
}
