using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication35
{
    public partial class Form1 : Form
    {
        private readonly Random _random = new Random();
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }  

        

        public Form1()
        {
            InitializeComponent();
            textBox4.Text = "0";
            tabControl1.SelectedTab = tabPage1;
        }

        int iclient = -1;

        int gen = 0;
        Produs[] cos=new Produs[100];
        int nrcos = 0;

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            // TODO: This line of code loads data into the 'atestatfinal1.produse' table. You can move, or remove it, as needed.
            this.produseTableAdapter.Fill(this.atestatfinal1.produse);
            // TODO: This line of code loads data into the 'atestatfinal1.facturi' table. You can move, or remove it, as needed.
            this.facturiTableAdapter.Fill(this.atestatfinal1.facturi);
            // TODO: This line of code loads data into the 'atestatfinal1.detalii' table. You can move, or remove it, as needed.
            this.detaliiTableAdapter.Fill(this.atestatfinal1.detalii);
            // TODO: This line of code loads data into the 'atestatfinal1.curieri' table. You can move, or remove it, as needed.
            this.curieriTableAdapter.Fill(this.atestatfinal1.curieri);
            // TODO: This line of code loads data into the 'atestatfinal1.clienti' table. You can move, or remove it, as needed.
            this.clientiTableAdapter.Fill(this.atestatfinal1.clienti);

            this.atestatfinal1.EnforceConstraints = false;
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox8.Focus();
            tabControl1.SelectedTab = tabPage2;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataTable d=atestatfinal1.clienti;
            int k=1;
            if (textBox8.Text != "" && textBox7.Text != "" && textBox6.Text != "")
            {
                for (int i = 0; i < d.Rows.Count; i++)
                {


                    if (string.Compare(textBox8.Text, Convert.ToString(d.Rows[i]["username"])) == 0)
                    {
                        MessageBox.Show("folositi alt username");
                        k = 0;
                    }
                }
                if (k == 1)
                {
                    clientiTableAdapter.Insert(textBox8.Text, textBox7.Text, textBox6.Text);
                    clientiTableAdapter.Update(atestatfinal1);
                    MessageBox.Show("Inregistrat cu succes");
                    tabControl1.SelectedTab = tabPage4;
                    clientiTableAdapter.username(atestatfinal1.clienti, textBox8.Text);
                    DataTable dt = atestatfinal1.clienti;
                    iclient = Convert.ToInt32(dt.Rows[0]["idcl"]);
                }
                produseTableAdapter.informatii(atestatfinal1.produse);
                DataTable cdt = atestatfinal1.produse;
                for (int i = 0; i < cdt.Rows.Count; i++)
                {
                    richTextBox2.Text += cdt.Rows[i]["denumire"].ToString() + " " + cdt.Rows[i]["gramaj"].ToString() + " grame " + cdt.Rows[i]["pret"].ToString() + " lei" + "\n";

                }
            }
            else MessageBox.Show("Introduceti toate datele !");
        }

        private void bindingNavigator1_RefreshItems(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox2.Focus();
            tabControl1.SelectedTab = tabPage3;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            int k = 1;
            DataTable d = atestatfinal1.clienti;
            if (textBox2.Text != "" && textBox1.Text != "")
            {
                for (int i = 0; i < d.Rows.Count && k == 1; i++)
                {

                    if (string.Compare(textBox2.Text, Convert.ToString(d.Rows[i]["username"])) == 0 && string.Compare(textBox1.Text, Convert.ToString(d.Rows[i]["parola"])) == 0)
                    {
                        MessageBox.Show("Conectat cu succes");
                        tabControl1.SelectedTab = tabPage4;
                        clientiTableAdapter.username(atestatfinal1.clienti, textBox2.Text);
                        DataTable dt = atestatfinal1.clienti;
                        iclient = Convert.ToInt32(dt.Rows[0]["idcl"]);
                        k = 0;
                    }

                }
                if (k == 1)
                    MessageBox.Show("Parola sau username gresit");

                produseTableAdapter.informatii(atestatfinal1.produse);
                DataTable cdt = atestatfinal1.produse;
                for (int i = 0; i < cdt.Rows.Count; i++)
                {
                    richTextBox2.Text += cdt.Rows[i]["denumire"].ToString() + " " + cdt.Rows[i]["gramaj"].ToString() + " grame " + cdt.Rows[i]["pret"].ToString() + " lei" + "\n";

                }
            }
            else MessageBox.Show("Introduceti toate datele !");

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage10;
            
        }

        private void numericUpDown13_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void button16_Click(object sender, EventArgs e)
        {
            
        }

        private void button21_Click(object sender, EventArgs e)
        {
            gen = RandomNumber(1, 8);
            facturiTableAdapter.Insert(DateTime.Now, gen, Convert.ToString(comboBox1), textBox3.Text);
            facturiTableAdapter.Update(atestatfinal1);
            facturiTableAdapter.ultima_factura(atestatfinal1.facturi);
            
            DataTable dt=atestatfinal1.facturi;
            int idf=Convert.ToInt32(dt.Rows[0]["idf"]);
            for (int i = 0; i < nrcos; i++)
            {
                produseTableAdapter.idprod(atestatfinal1.produse,cos[i].denumire);
                DataTable dt1=atestatfinal1.produse;
                int idp=Convert.ToInt32(dt1.Rows[0]["idp"]);
                detaliiTableAdapter.Insert(idf, idp, cos[i].cantitate, iclient);
                detaliiTableAdapter.Update(atestatfinal1);
            }
            int t=0;
         
                if (comboBox1.Text == "Zorilor")
                    t = 20;else 
                if (comboBox1.Text == "Manastur")
                    t = 20;else 
                if (comboBox1.Text == "Grigorescu")
                    t = 25;else 
                if (comboBox1.Text == "Andrei Muresanu")
                    t = 15;else 
                if (comboBox1.Text == "Marasti")
                    t = 25;else 
                if (comboBox1.Text == "Ghiorgheni")
                    t = 22;else 
                if (comboBox1.Text == "Europa")
                    t = 23;else 
                if (comboBox1.Text == "Iris")
                    t = 40;else 
                if (comboBox1.Text == "Bulgaria")
                    t = 30;else 
                if (comboBox1.Text == "Someseni")
                    t = 40;else
                if (comboBox1.Text == "Baci")
                    t = 45;
            
            MessageBox.Show("Comanda plasata");
            tabControl1.SelectedTab = tabPage5;
            timer1.Start();
            timer1.Interval = 300;
            
        }

        private void label24_Click(object sender, EventArgs e)
        {
        
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            if (comboBox2.Text != "Preparate" && comboBox2.Text != "Bauturi")
            {
                string x = "%" + comboBox2.Text + "%";
                this.produseTableAdapter.mancaruri(atestatfinal1.produse, x);
                DataTable edt = atestatfinal1.produse;
                for (int i = 0; i < edt.Rows.Count; i++)
                    comboBox3.Items.Add(Convert.ToString(edt.Rows[i]["denumire"]));
            }
            else {
                if (comboBox2.Text == "Preparate")
                {
                    comboBox3.Items.Add("Cas Pane");
                    comboBox3.Items.Add("Costite BBQ");
                }
                else {
                    comboBox3.Items.Add("Apa Plata");
                    comboBox3.Items.Add("Coca-Cola");
                    comboBox3.Items.Add("Fanta");
                }
            }
        }

        

        private void button4_Click(object sender, EventArgs e)
        {
            int sum=Convert.ToInt32(textBox4.Text);
            this.produseTableAdapter.pret(atestatfinal1.produse,comboBox3.Text);
            DataTable edt = atestatfinal1.produse;
            int pret=Convert.ToInt32(edt.Rows[0]["Pret"]);
            Produs a = new Produs(comboBox3.Text,Convert.ToInt32(numericUpDown1.Value),pret);
            cos[nrcos] = a;
            nrcos++;
            richTextBox1.Text += a.af();
            richTextBox3.Text += a.af();
            
            textBox4.Text = Convert.ToString(sum + a.pret * a.cantitate);
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage4;
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
                textBox1.PasswordChar = '\0';
            else textBox1.PasswordChar = '*';
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked == true)
                textBox7.PasswordChar = '\0';
            else textBox7.PasswordChar = '*';
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        int ok = 1;
        
        private void timer1_Tick(object sender, EventArgs e)
        {
            facturiTableAdapter.infoc(atestatfinal1.facturi);
            DataTable edt = atestatfinal1.curieri;
            progressBar1.Minimum = 0;
            progressBar1.Maximum = 100;
            if (progressBar1.Value < progressBar1.Maximum)
            {
                progressBar1.Value = progressBar1.Value + 1;
 
            }
            if (progressBar1.Value == 10)
            { 
                richTextBox4.Text += "Comanda a fost receptata" + "\n";
                richTextBox4.Text += "\n";
            }
            if (progressBar1.Value == 40)
            {
                richTextBox4.Text += "Preparat finalizat" + "\n";
                richTextBox4.Text += "\n";
            }
            if (progressBar1.Value == 60)
                richTextBox4.Text += "Comanda preluata de:" + edt.Rows[gen]["nume"] + " " + edt.Rows[gen]["prenume"] + "\n" + "Puteti contacta curierul la numarul:" +"\n"+"0"+ edt.Rows[gen]["telefon"] + "\n";
            if (progressBar1.Value > 60 && ok==1)
            {
                ok = 0;
                richTextBox4.Text += "\n";
                richTextBox4.Text += "Comanda in curs de livrare...";
            }

            if (progressBar1.Value == 99)
            { 
                MessageBox.Show("Curierul este la usa !");
                tabControl1.SelectedTab = tabPage2;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            clientiTableAdapter.inregistrare(atestatfinal1.clienti);
            DataTable edc = atestatfinal1.curieri;
            if (comboBox1.Text != "" && textBox3.Text != "")
            {
                tabControl1.SelectedTab = tabPage5;
                richTextBox3.Text += "\n";
                richTextBox3.Text += "Pretul total este de: " + textBox4.Text + " lei" + "\n";
                richTextBox3.Text += "\n";
                richTextBox3.Text += "Detalii de livrare:" + "\n";
                richTextBox3.Text += "Strada " + textBox3.Text + " " + "Cartier " + comboBox1.Text + "\n";
                richTextBox3.Text += "Numar de telefon: 0";
                richTextBox3.Text += edc.Rows[iclient]["telefon"];
            }
            else MessageBox.Show("Intoduceti adresa !");

            
            
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button21_Click_1(object sender, EventArgs e)
        {
            gen = RandomNumber(1, 8);
            facturiTableAdapter.Insert(DateTime.Now, gen, Convert.ToString(comboBox1), textBox3.Text);
            facturiTableAdapter.Update(atestatfinal1);
            facturiTableAdapter.ultima_factura(atestatfinal1.facturi);

            DataTable dt = atestatfinal1.facturi;
            int idf = Convert.ToInt32(dt.Rows[0]["idf"]);
            for (int i = 0; i < nrcos; i++)
            {
                produseTableAdapter.idprod(atestatfinal1.produse, cos[i].denumire);
                DataTable dt1 = atestatfinal1.produse;
                int idp = Convert.ToInt32(dt1.Rows[0]["idp"]);
                detaliiTableAdapter.Insert(idf, idp, cos[i].cantitate, iclient);
                detaliiTableAdapter.Update(atestatfinal1);
            }
            int t = 0;

            if (comboBox1.Text == "Zorilor")
                t = 20;
            else
                if (comboBox1.Text == "Manastur")
                    t = 20;
                else
                    if (comboBox1.Text == "Grigorescu")
                        t = 25;
                    else
                        if (comboBox1.Text == "Andrei Muresanu")
                            t = 15;
                        else
                            if (comboBox1.Text == "Marasti")
                                t = 25;
                            else
                                if (comboBox1.Text == "Ghiorgheni")
                                    t = 22;
                                else
                                    if (comboBox1.Text == "Europa")
                                        t = 23;
                                    else
                                        if (comboBox1.Text == "Iris")
                                            t = 40;
                                        else
                                            if (comboBox1.Text == "Bulgaria")
                                                t = 30;
                                            else
                                                if (comboBox1.Text == "Someseni")
                                                    t = 40;
                                                else
                                                    if (comboBox1.Text == "Baci")
                                                        t = 45;

            MessageBox.Show("Comanda plasata");
            tabControl1.SelectedTab = tabPage5;
            timer1.Start();
            timer1.Interval =t*60;
        }
    }
}
