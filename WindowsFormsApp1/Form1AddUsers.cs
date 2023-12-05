﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.FolderName;

namespace WindowsFormsApp1
{
    public partial class Form1AddUsers : Form
    {
        public Form1AddUsers()
        {
            InitializeComponent();
        }

        private void Form1AddUsers_Load(object sender, EventArgs e)
        {
            StartLoad();
        }
        ModelEF model = new ModelEF();
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" ||
            textBox2.Text==""||
            textBox3.Text=="")
            {
                MessageBox.Show("Заполнить все поля");
                return;
            }
            UsersHash usersHash = new UsersHash();
            usersHash.Login = textBox1.Text;
            usersHash.Password = SHA256Builder.ConvertToHash(textBox2.Text);
            usersHash.FirstName = textBox3.Text;
            try
            {
                model.UsersHash.Add(usersHash);
                model.SaveChanges();
                model.SaveChanges();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }
            finally
            {
                StartLoad();

            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            MessageBox.Show("Данные добавлены");

            
        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            Form2Authorization form2 = new Form2Authorization();
            form2.ShowDialog();
        }

        void StartLoad()
        {
            dataGridView1.DataSource = model.UsersHash.ToList();
        }
       
    }
}
