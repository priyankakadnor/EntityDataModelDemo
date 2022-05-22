using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityDataModelDemo
{
    public partial class Form1 : Form
    {
        ApplicationEntities dbcontext = new ApplicationEntities();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                //create object form
                EmployeInfo emp = new EmployeInfo();
                emp.ename = txtname.Text;
                emp.edesignation = txtdesig.Text;
                emp.esalary = Convert.ToInt32(txtsalary.Text);
                //add data dbcontext
                dbcontext.EmployeInfoes.Add(emp);
                //update chnage to the db
                dbcontext.SaveChanges();
                MessageBox.Show("Done....");

            }
            catch (Exception ep)
            {

            }
        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeInfo emp = dbcontext.EmployeInfoes.Find(Convert.ToInt32(txtid.Text));
                if (emp != null)
                {
                    txtname.Text = emp.ename;
                    txtsalary.Text = emp.esalary.ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeInfo emp = dbcontext.EmployeInfoes.Find(Convert.ToInt32(txtid.Text));
                if (emp != null)
                {
                    emp.ename = txtname.Text;
                    emp.esalary = Convert.ToInt32(txtsalary.Text);
                    dbcontext.SaveChanges();
                    MessageBox.Show("updated");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                EmployeInfo emp = dbcontext.EmployeInfoes.Find(Convert.ToInt32(txtid.Text));
                if (emp != null)
                {
                    dbcontext.EmployeInfoes.Remove(emp);
                    dbcontext.SaveChanges();
                    MessageBox.Show("deleted");
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnshowall_Click(object sender, EventArgs e)
        {

            dataGridView1.DataSource = dbcontext.EmployeInfoes.ToList();
        }
    }
    }



        

