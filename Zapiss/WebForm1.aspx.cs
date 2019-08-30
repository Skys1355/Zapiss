using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Zapiss
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        string connect = @"Data Source=ФУРИН-ПК\SQLEXPRESS;Initial Catalog=zapis;Integrated Security=True";
        string query;
        DataSet ds;
        DataTable dt;
        SqlDataAdapter adapterSql;
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
                return;
            }
            else
            {
                dt = new DataTable();
                ds = new DataSet();
                query = "select [DateDay],[DateMonth],[DateTime] from Zapis_na_osmotr";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt = ds.Tables[0];
                int i = 0;
                string st1,st2,st3;
                while (i < dt.Rows.Count)
                {
                    st1 = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[0]).Replace(" ", "");
                    st2 = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[1]).Replace(" ", "");
                    st3 = Convert.ToString(ds.Tables[0].Rows[i].ItemArray[2]).Replace(" ", "");
                    if (DropDownList1.Text == st1 && DropDownList2.Text==st2 && DropDownList3.Text==st3)
                    {
                        Label12.Text = "Данное время занято";
                        Label12.Visible = true;
                        return;
                    }
                    i++;
                }
                dt = new DataTable();
                ds = new DataSet();
                query = "insert into Zapis_na_osmotr values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "','" + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "','" + DropDownList1.Text + "','" + DropDownList2.Text + "','" + DropDownList3.Text + "');";
                adapterSql = new SqlDataAdapter(query, connect);
                adapterSql.Fill(ds);
                dt.Dispose();
                ds.Dispose();
                Label11.Visible = false;
                Label12.Visible = true;
                Label12.Text = "Вы записаны";
                Label12.ForeColor = System.Drawing.Color.Green;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            ds = new DataSet();
            query = "SELECT * from [Zapis_na_osmotr] WHERE [DateDay]= "+DropDownList4.Text+" AND [DateMonth]= "+ DropDownList5.Text;
            adapterSql = new SqlDataAdapter(query, connect);
            ds = new DataSet();
            adapterSql.Fill(ds);            
            GridView1.DataSource = ds.Tables[0];
            GridView1.DataBind();
            dt.Dispose();
            ds.Dispose();
        }
    }
}