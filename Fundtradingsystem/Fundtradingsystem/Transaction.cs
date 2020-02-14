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
    public partial class Transaction : Form
    {
        public Transaction()
        {
            InitializeComponent();
        }

        public Users user { get; set; }
        //构造函数传值
        public Transaction(string Name)
        {
            InitializeComponent();
            this.label1.Text = Name;
            
        }

        

        //利用委托
        public void setvalue(string Name, Users users)
        {
            label1.Text= Name;
            this.user = users;
        }
        

        private void Transaction_Load(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public enum num
        {
            Afactory, Bfactory, Cfactory, Dfactory
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            var sqlConction = SqlSugarDbFirst.GetSqlConction();
            //找到这个用户
            var sHandles = sqlConction.Queryable<Handle>().Where(i => i.Id == user.Id).ToList();

            #region 买入
            if (comboBox1.Text.Equals("买入"))
            {
                if (sHandles.Count == 0)
                {
                    //首次买入,创建用户
                    var handle = new Handle()
                    {
                        Id = user.Id,
                        Afactory = comboBox2.Text.Equals(num.Afactory.ToString()) ? textBox2.Text : "",
                        Bfactory = comboBox2.Text.Equals(num.Bfactory.ToString()) ? textBox2.Text : "",
                        Cfactory = comboBox2.Text.Equals(num.Cfactory.ToString()) ? textBox2.Text : "",
                        Dfactory = comboBox2.Text.Equals(num.Dfactory.ToString()) ? textBox2.Text : "",
                    };
                    var sCommand = sqlConction.Insertable(handle).ExecuteCommand();
                }
                else
                {
                    var handle = new Handle()
                    {
                        Id = user.Id,
                        Afactory = comboBox2.Text.Equals(num.Afactory.ToString()) ? (Convert.ToInt32(sHandles[0].Afactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                        Bfactory = comboBox2.Text.Equals(num.Bfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Bfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                        Cfactory = comboBox2.Text.Equals(num.Cfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Cfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                        Dfactory = comboBox2.Text.Equals(num.Dfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Dfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                    };
                    sqlConction.Updateable(handle).ExecuteCommand();
                }
                this.textBox1.Text = "你真好";

            }


            #endregion
            #region 卖出
            if (comboBox1.Text.Equals("卖出"))
            {
                var handle = new Handle()
                {
                    Id = user.Id,
                    Afactory = comboBox2.Text.Equals(num.Afactory.ToString()) ? (Convert.ToInt32(sHandles[0].Afactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                    Bfactory = comboBox2.Text.Equals(num.Bfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Bfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                    Cfactory = comboBox2.Text.Equals(num.Cfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Cfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                    Dfactory = comboBox2.Text.Equals(num.Dfactory.ToString()) ? (Convert.ToInt32(sHandles[0].Dfactory) + Convert.ToInt32(textBox2.Text)).ToString() : "",
                };
                sqlConction.Updateable(handle).ExecuteCommand();
                this.textBox1.Text = "卖出成功";
            }

            #endregion

            #region 持仓数量

            if (comboBox1.Text.Equals("持仓数量"))
            {
                textBox1.Text = comboBox2.Text.Equals(num.Afactory.ToString()) ? sHandles[0].Afactory : "";
                textBox1.Text = comboBox2.Text.Equals(num.Bfactory.ToString()) ? sHandles[0].Bfactory : "";
                textBox1.Text = comboBox2.Text.Equals(num.Cfactory.ToString()) ? sHandles[0].Cfactory : "";
                textBox1.Text = comboBox2.Text.Equals(num.Dfactory.ToString()) ? sHandles[0].Dfactory : "";
            }

            #endregion

            #region 清仓

            if (comboBox1.Text.Equals("清仓"))
            {
                var handle = new Handle()
                {
                    Id = user.Id,
                    Afactory = comboBox2.Text.Equals(num.Afactory.ToString()) ?  "":sHandles[0].Afactory,
                    Bfactory = comboBox2.Text.Equals(num.Bfactory.ToString()) ?  "": sHandles[0].Bfactory,
                    Cfactory = comboBox2.Text.Equals(num.Cfactory.ToString()) ?  "": sHandles[0].Cfactory,
                    Dfactory = comboBox2.Text.Equals(num.Dfactory.ToString()) ?  "": sHandles[0].Dfactory
            };                                                                 
                sqlConction.Updateable(handle).ExecuteCommand();
                this.textBox1.Text = "清仓成功";
            }
            #endregion
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
