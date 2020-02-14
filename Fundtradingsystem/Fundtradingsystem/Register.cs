using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fundtradingsystem
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public void Reset()
        {
            Controls.Clear();
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)&& !string.IsNullOrWhiteSpace(textBox2.Text)&&
                !string.IsNullOrWhiteSpace(textBox3.Text)&& !string.IsNullOrWhiteSpace(textBox4.Text))
            {
                if (textBox2.Text.Equals(textBox3.Text))
                {
                    var dbConction=SqlSugarDbFirst.GetSqlConction();
                    var users=new Users() { Id = Guid.NewGuid(),Phonenum = textBox1.Text, Password = textBox2.Text, Nicky = textBox4.Text};
                    //判断数据库中是否存在当前对象
                    var dList=dbConction.Queryable<Users>().Where(s => s.Phonenum == users.Phonenum).ToList();
                    if (dList.Count==0)
                    {
                        var dCommand = dbConction.Insertable<Users>(users).ExecuteCommand();
                        if (dCommand==1)
                        {
                            MessageBox.Show("恭喜您注册成功");
                            this.Hide();
                            var login=new Login();
                            login.ShowDialog();
                        }
                    }
                    else
                    {
                        Reset();
                        MessageBox.Show("你的手机已注册");
                    }
                }
                else
                {
                    Reset();
                    MessageBox.Show("二次密码输入的不对");
                }
            }
            else
            {
                Reset();
                MessageBox.Show("全部必须填写");
            }
        }
        
    }
}
