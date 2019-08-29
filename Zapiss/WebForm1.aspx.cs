using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Zapiss
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox7.Text == "1111")
            {
                Label10.Text = "Пароль принят";
                Label10.Visible = true;
                Label9.Visible = true;
                DropDownList4.Visible = true;
                DropDownList5.Visible = true;
                Button3.Visible = true;
            }
            else
            {
                Label10.Text = "Неверный пароль";
                Label10.Visible = true;
            }
            if (TextBox7.Text=="")
            {
                Label10.Text = "Введите пароль администратора";
                Label10.Visible = true;
            }            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text=="" | TextBox2.Text=="" | TextBox3.Text=="" | TextBox4.Text=="" | TextBox5.Text=="" | TextBox6.Text== "" )
            {
                Label11.Text = "Заполните все поля";
                Label11.Visible = true;
            }
            else
            {

            }
        }
    }
}