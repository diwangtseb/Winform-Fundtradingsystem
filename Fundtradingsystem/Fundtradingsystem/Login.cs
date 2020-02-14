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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text)&&!string.IsNullOrWhiteSpace(textBox2.Text))
            {
                var sqlConction=SqlSugarDbFirst.GetSqlConction();
                var sUserses = sqlConction.Queryable<Users>()
                    .Where(a => a.Phonenum == textBox1.Text && a.Password == textBox2.Text).ToList();
                if (sUserses.Count>0)
                {
                    //构造函数
                    //var transaction = new Transaction(sUserses[0].Nicky); 
                    //委托
                    var transaction=new Transaction();
                    Action<string,Users> action = transaction.setvalue;//签名
                    action.Invoke(string.Format("尊敬的{0}您好", sUserses[0].Nicky),sUserses[0]);
                    this.Hide();
                    transaction.ShowDialog();
                }
                else
                {
                    Lrest();
                    MessageBox.Show("您的账号未注册");
                }
            }
            else
            {
                Lrest();
                MessageBox.Show("请全部填写");
            }
        }

        public void Lrest()
        {
            Controls.Clear();
            InitializeComponent();
        }
    }
}
