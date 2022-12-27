using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OrderManagement
{
    public partial class Form1 : Form
    {
        public SqlConnection sqlConnection = null;
        public int id;
        public Form1()
        {
            InitializeComponent();
        }


        private async void Form1_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Ponomarev_VT_31DataSet1.Products". При необходимости она может быть перемещена или удалена.

            // TODO: данная строка кода позволяет загрузить данные в таблицу "_Ponomarev_VT_31DataSet1.Customers". При необходимости она может быть перемещена или удалена.




            string connectionString = @"Data source = (LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\Data\OrderManagement.mdf; Integrated Security = True"; /*User ID = stud; Password = stud;*/
            sqlConnection = new SqlConnection(connectionString);

            await sqlConnection.OpenAsync();

            listView1.GridLines = true;
            listView1.FullRowSelect = true;
            listView1.View = View.Details;


            listView1.Columns.Add("Id");
            listView1.Columns.Add("Наименование");
            listView1.Columns.Add("Адрес");
            listView1.Columns.Add("Телефон");
            listView1.Columns.Add("Контактное лицо");

            listView1.Columns[listView1.Columns.Count - 1].Width = 170;
            listView1.Columns[listView1.Columns.Count - 2].Width = 150;
            listView1.Columns[listView1.Columns.Count - 3].Width = 390;
            listView1.Columns[listView1.Columns.Count - 4].Width = 150;
            listView1.Columns[listView1.Columns.Count - 5].Width = 0;

            listView2.GridLines = true;
            listView2.FullRowSelect = true;
            listView2.View = View.Details;

            listView2.Columns.Add("Id");
            listView2.Columns.Add("Наименование");
            listView2.Columns.Add("Цена");
            listView2.Columns.Add("Продолжительность");


            listView2.Columns[listView2.Columns.Count - 1].Width = 190;
            listView2.Columns[listView2.Columns.Count - 2].Width = 120;
            listView2.Columns[listView2.Columns.Count - 3].Width = 170;
            listView2.Columns[listView2.Columns.Count - 4].Width = 0;


            listView3.GridLines = true;
            listView3.FullRowSelect = true;
            listView3.View = View.Details;

            listView3.Columns.Add("Id");
            listView3.Columns.Add("Наименование");
            listView3.Columns.Add("Адрес");
            listView3.Columns.Add("Телефон");
            listView3.Columns.Add("Контактное лицо");
            listView3.Columns.Add("Цена");
            listView3.Columns.Add("Описание");
            listView3.Columns.Add("Количество");
            listView3.Columns.Add("Дата");
            listView3.Columns.Add("Доставка");


            listView3.Columns[listView3.Columns.Count - 1].Width = 170;
            listView3.Columns[listView3.Columns.Count - 2].Width = 120;
            listView3.Columns[listView3.Columns.Count - 3].Width = 120;
            listView3.Columns[listView3.Columns.Count - 4].Width = 250;
            listView3.Columns[listView3.Columns.Count - 5].Width = 100;
            listView3.Columns[listView3.Columns.Count - 6].Width = 250;
            listView3.Columns[listView3.Columns.Count - 7].Width = 150;
            listView3.Columns[listView3.Columns.Count - 8].Width = 390;
            listView3.Columns[listView3.Columns.Count - 9].Width = 170;
            listView3.Columns[listView3.Columns.Count - 10].Width = 0;



            listView4.GridLines = true;
            listView4.FullRowSelect = true;
            listView4.View = View.Details;


            listView4.Columns.Add("Id");
            listView4.Columns.Add("Наименование");
            listView4.Columns.Add("Цена доставки");
            listView4.Columns.Add("Скорость доставки");
            listView4.Columns.Add("Описание");

            listView4.Columns[listView4.Columns.Count - 1].Width = 170;
            listView4.Columns[listView4.Columns.Count - 2].Width = 190;
            listView4.Columns[listView4.Columns.Count - 3].Width = 170;
            listView4.Columns[listView4.Columns.Count - 4].Width = 170;
            listView4.Columns[listView4.Columns.Count - 5].Width = 0;

            listView5.GridLines = true;
            listView5.FullRowSelect = true;
            listView5.View = View.Details;

            listView5.Columns.Add("Id");
            listView5.Columns.Add("Цена");
            listView5.Columns.Add("Описание");


            listView5.Columns[listView5.Columns.Count - 1].Width = 190;
            listView5.Columns[listView5.Columns.Count - 2].Width = 120;
            listView5.Columns[listView5.Columns.Count - 3].Width = 0;

            await LoadTableAsync();
        }


        public async Task LoadTableAsync()
        {
            SqlDataReader sqlReader = null;
            SqlCommand command = new SqlCommand("SELECT * FROM [Customers]", sqlConnection);

            try
            {
                sqlReader = await command.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["id"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Addres"]),
                        Convert.ToString(sqlReader["Phone"]),
                         Convert.ToString(sqlReader["Contact"])
                        });

                    listView1.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }

            SqlCommand command1 = new SqlCommand("SELECT * FROM [Deliveries]", sqlConnection);

            try
            {
                sqlReader = await command1.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["id"]),
                        Convert.ToString(sqlReader["Name"]),
                        Convert.ToString(sqlReader["Price"]),
                        Convert.ToString(sqlReader["Duration"]),

                        });

                    listView2.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }

            SqlCommand command2 = new SqlCommand("SELECT * FROM [OrdersView]", sqlConnection);

            try
            {
                sqlReader = await command2.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["ID"]),
                        Convert.ToString(sqlReader["CustomerName"]),
                        Convert.ToString(sqlReader["CustomerAddres"]),
                        Convert.ToString(sqlReader["CustomerPhone"]),
                        Convert.ToString(sqlReader["CustomerContact"]),
                        Convert.ToString(sqlReader["ProductPrice"]),
                        Convert.ToString(sqlReader["ProductDescription"]),
                        Convert.ToString(sqlReader["Count"]),
                        Convert.ToString(String.Format("{0:dd/MM/yyyy}",sqlReader["Date"])),
                        Convert.ToString(sqlReader["DeliveryId"]),

                        });

                    listView3.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }

            SqlCommand command3 = new SqlCommand("SELECT * FROM [ProductDeliveriesView]", sqlConnection);

            try
            {
                sqlReader = await command3.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["id"]),
                        Convert.ToString(sqlReader["DeliveryName"]),
                        Convert.ToString(sqlReader["DeliveryPrice"]),
                        Convert.ToString(sqlReader["DeliveryDuration"]),
                        Convert.ToString(sqlReader["ProductDescription"]),
                        Convert.ToString(sqlReader["ProdPrice"]),

                        });

                    listView4.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }


            SqlCommand command4 = new SqlCommand("SELECT * FROM [Products]", sqlConnection);

            try
            {
                sqlReader = await command4.ExecuteReaderAsync();
                while (await sqlReader.ReadAsync())
                {
                    ListViewItem item = new ListViewItem(new string[] {

                        Convert.ToString(sqlReader["id"]),
                        Convert.ToString(sqlReader["Price"]),
                        Convert.ToString(sqlReader["Description"]),

                        });

                    listView5.Items.Add(item);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString(), ex.Source.ToString(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (sqlReader != null && !sqlReader.IsClosed)
                {
                    sqlReader.Close();
                }
            }


        }

        private async void button1_Click(object sender, EventArgs e)
        {

            if (label8.Visible)
            {
                label8.Visible = false;
            }
            if (listView1.SelectedItems.Count == 0)
            {
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                & !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Customers] (Name,Addres, Phone,Contact) VALUES (@Name,@Addres, @Phone,@Contact)", sqlConnection);
                    command.Parameters.AddWithValue("Name", textBox1.Text);
                    command.Parameters.AddWithValue("Addres", textBox2.Text);
                    command.Parameters.AddWithValue("Phone", textBox3.Text);
                    command.Parameters.AddWithValue("Contact", textBox4.Text);
                    await command.ExecuteNonQueryAsync();


                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    await LoadTableAsync();

                }
                else
                {
                    label8.Visible = true;
                    label8.Text = "Поля не заполнены!";
                }
            }
            if (listView1.SelectedItems.Count > 0)
            {

                MessageBox.Show("Вы выделили строку, поэтому новую запись добавить невозможно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button3_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteCustomersCommand = new SqlCommand("DELETE FROM [Customers] WHERE [Id] =@id", sqlConnection);
                        deleteCustomersCommand.Parameters.AddWithValue("id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                        try
                        {

                            await deleteCustomersCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Для начала необходимо удалить все зависимые записи в других таблицах!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        listView5.Items.Clear();
                        await LoadTableAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button4_Click(object sender, EventArgs e)
        {

            if (label10.Visible)
            {
                label10.Visible = false;
            }

            if (listView2.SelectedItems.Count == 0)
            {
                if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text)
                )
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Deliveries] (Name,Price, Duration) VALUES (@Name,@Price, @Duration)", sqlConnection);
                    command.Parameters.AddWithValue("Name", textBox5.Text);
                    command.Parameters.AddWithValue("Price", textBox8.Text);
                    command.Parameters.AddWithValue("Duration", textBox7.Text);

                    await command.ExecuteNonQueryAsync();

                    textBox5.Clear();
                    textBox8.Clear();
                    textBox7.Clear();

                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    await LoadTableAsync();

                }
                else
                {
                    label10.Visible = true;
                    label10.Text = "Поля не заполнены!";
                }
            }
            if (listView2.SelectedItems.Count > 0)
            {

                MessageBox.Show("Вы выделили строку, поэтому новую запись добавить невозможно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteDeliveriesCommand = new SqlCommand("DELETE FROM [Deliveries] WHERE [Id] =@id", sqlConnection);
                        deleteDeliveriesCommand.Parameters.AddWithValue("id", Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text));
                        try
                        {

                            await deleteDeliveriesCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Для начала необходимо удалить все зависимые записи в других таблицах!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        listView5.Items.Clear();
                        await LoadTableAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button7_Click(object sender, EventArgs e)
        {
            if (label17.Visible)
            {
                label17.Visible = false;
            }
            if (listView3.SelectedItems.Count == 0)
            {
                if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text)
                && !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text)
                && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                && !string.IsNullOrEmpty(comboBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.Text)
                )
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Orders] (CustomerID,ProductID, Count,Date,DeliveryId) VALUES (@CustomerID,@ProductID, @Count,@Date,@DeliveryId)", sqlConnection);
                    command.Parameters.AddWithValue("CustomerID", (int)comboBox1.SelectedValue);
                    command.Parameters.AddWithValue("ProductID", (int)comboBox2.SelectedValue);
                    command.Parameters.AddWithValue("Count", textBox9.Text);
                    command.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("DeliveryId", (int)comboBox3.SelectedValue);


                    await command.ExecuteNonQueryAsync();

                    textBox9.Clear();


                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    await LoadTableAsync();

                }
                else
                {
                    label17.Visible = true;
                    label17.Text = "Поля не заполнены!";
                }
            }

            if (listView3.SelectedItems.Count > 0)
            {

                MessageBox.Show("Вы выделили строку, поэтому новую запись добавить невозможно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button9_Click(object sender, EventArgs e)
        {
            if (listView3.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteOrdersCommand = new SqlCommand("DELETE FROM [Orders] WHERE [Id] =@id", sqlConnection);
                        deleteOrdersCommand.Parameters.AddWithValue("id", Convert.ToInt32(listView3.SelectedItems[0].SubItems[0].Text));
                        try
                        {

                            await deleteOrdersCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        listView5.Items.Clear();
                        await LoadTableAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            if (label19.Visible)
            {
                label19.Visible = false;
            }
            if (listView4.SelectedItems.Count == 0)
            {
                if (!string.IsNullOrEmpty(comboBox4.Text) && !string.IsNullOrWhiteSpace(comboBox4.Text)
                && !string.IsNullOrEmpty(comboBox5.Text) && !string.IsNullOrWhiteSpace(comboBox5.Text)

                )
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [ProductDeliveries] (ProductID,DeliveryID) VALUES (@ProductID,@DeliveryID)", sqlConnection);
                    command.Parameters.AddWithValue("ProductID", (int)comboBox4.SelectedValue);
                    command.Parameters.AddWithValue("DeliveryID", (int)comboBox5.SelectedValue);



                    await command.ExecuteNonQueryAsync();


                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    await LoadTableAsync();

                }
                else
                {
                    label19.Visible = true;
                    label19.Text = "Поля не заполнены!";
                }
            }
            if (listView4.SelectedItems.Count > 0)
            {

                MessageBox.Show("Вы выделили строку, поэтому новую запись добавить невозможно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private async void button12_Click(object sender, EventArgs e)
        {
            if (listView4.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteProductDeliveriesCommand = new SqlCommand("DELETE FROM [ProductDeliveries] WHERE [Id] =@id", sqlConnection);
                        deleteProductDeliveriesCommand.Parameters.AddWithValue("id", Convert.ToInt32(listView4.SelectedItems[0].SubItems[0].Text));
                        try
                        {

                            await deleteProductDeliveriesCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }



                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        listView5.Items.Clear();
                        await LoadTableAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button13_Click(object sender, EventArgs e)
        {
            if (label24.Visible)
            {
                label24.Visible = false;
            }
            if (listView5.SelectedItems.Count == 0)
            {
                if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text)
                && !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text)

                )
                {
                    SqlCommand command = new SqlCommand("INSERT INTO [Products] (Price,Description) VALUES (@Price,@Description)", sqlConnection);
                    command.Parameters.AddWithValue("Price", textBox16.Text);
                    command.Parameters.AddWithValue("Description", textBox14.Text);



                    await command.ExecuteNonQueryAsync();

                    textBox16.Clear();
                    textBox14.Clear();

                    listView1.Items.Clear();
                    listView2.Items.Clear();
                    listView3.Items.Clear();
                    listView4.Items.Clear();
                    listView5.Items.Clear();
                    await LoadTableAsync();

                }
                else
                {
                    label24.Visible = true;
                    label24.Text = "Поля не заполнены!";
                }
            }
            if (listView5.SelectedItems.Count > 0)
            {

                MessageBox.Show("Вы выделили строку, поэтому новую запись добавить невозможно!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void button15_Click(object sender, EventArgs e)
        {
            if (listView5.SelectedItems.Count > 0)
            {
                DialogResult res = MessageBox.Show("Вы действительно хотите удалить эту строку?", "Удаление строки", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);
                switch (res)
                {
                    case DialogResult.OK:
                        SqlCommand deleteProductsCommand = new SqlCommand("DELETE FROM [Products] WHERE [Id] =@id", sqlConnection);
                        deleteProductsCommand.Parameters.AddWithValue("id", Convert.ToInt32(listView5.SelectedItems[0].SubItems[0].Text));
                        try
                        {

                            await deleteProductsCommand.ExecuteNonQueryAsync();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Для начала необходимо удалить все зависимые записи в других таблицах!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        listView1.Items.Clear();
                        listView2.Items.Clear();
                        listView3.Items.Clear();
                        listView4.Items.Clear();
                        listView5.Items.Clear();

                        await LoadTableAsync();

                        break;
                }
            }
            else
            {
                MessageBox.Show("Для начала необходимо удалить все зависимые записи в других таблицах!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 43 && number != 45 && number != 41 && number != 40 && number != 32)
            {
                e.Handled = true;

            }
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;

            }
        }

        private void textBox16_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;

            }
        }

        byte IsFirstClick1 = 0;

        private async void button2_Click(object sender, EventArgs e)
        {






            switch (IsFirstClick1)
            {


                case 0:
                    /* if (listView1.SelectedItems.Count > 0)
                     {
                         SqlCommand getCustomersInfoCommand = new SqlCommand("SELECT [Name], [Addres], [Phone],[Contact] FROM [Customers] WHERE [Id]=@id", sqlConnection);
                         getCustomersInfoCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[id].SubItems[id].Text));
                         SqlDataReader sqlReader = null;

                         try
                         {
                             sqlReader = await getCustomersInfoCommand.ExecuteReaderAsync();
                             while (await sqlReader.ReadAsync())
                             {
                                 textBox1.Text = Convert.ToString(sqlReader["Name"]);
                                 textBox2.Text = Convert.ToString(sqlReader["Addres"]);
                                 textBox3.Text = Convert.ToString(sqlReader["Phone"]);
                                 textBox4.Text = Convert.ToString(sqlReader["Contact"]);

                             }
                         }
                         catch (Exception ex)
                         {
                             MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                         }
                         finally
                         {
                             if (sqlReader != null && !sqlReader.IsClosed)
                             {
                                 sqlReader.Close();
                             }
                         }
                     }
                     else
                     {
                         textBox1.Clear();
                         textBox2.Clear();
                         textBox3.Clear();
                         textBox4.Clear();
                         MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                     }*/


                    if (listView1.SelectedItems.Count > 0)
                    {
                        textBox1.Text = listView1.FocusedItem.SubItems[1].Text;
                        textBox2.Text = listView1.FocusedItem.SubItems[2].Text;
                        textBox3.Text = listView1.FocusedItem.SubItems[3].Text;
                        textBox4.Text = listView1.FocusedItem.SubItems[4].Text;
                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }




                    IsFirstClick1 = 1;

                    break;
                case 1:

                    if (listView1.SelectedItems.Count > 0)
                    {
                        if (label5.Visible)
                        {
                            label5.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrWhiteSpace(textBox1.Text)
                            && !string.IsNullOrEmpty(textBox2.Text) && !string.IsNullOrWhiteSpace(textBox2.Text)
                            && !string.IsNullOrEmpty(textBox3.Text) && !string.IsNullOrWhiteSpace(textBox3.Text)
                             && !string.IsNullOrEmpty(textBox4.Text) && !string.IsNullOrWhiteSpace(textBox4.Text))
                        {
                            SqlCommand updateCustomerscommand = new SqlCommand("UPDATE [Customers] SET [Name] = @Name, [Addres] = @Addres, [Phone] = @Phone,[Contact] = @Contact WHERE [Id] = @id", sqlConnection);
                            updateCustomerscommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView1.SelectedItems[0].SubItems[0].Text));
                            updateCustomerscommand.Parameters.AddWithValue("Name", textBox1.Text);
                            updateCustomerscommand.Parameters.AddWithValue("Addres", textBox2.Text);
                            updateCustomerscommand.Parameters.AddWithValue("Phone", textBox3.Text);
                            updateCustomerscommand.Parameters.AddWithValue("Contact", textBox4.Text);
                            try
                            {
                                await updateCustomerscommand.ExecuteNonQueryAsync();
                                listView1.Items.Clear();
                                listView2.Items.Clear();
                                listView3.Items.Clear();
                                listView4.Items.Clear();
                                listView5.Items.Clear();

                                await LoadTableAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            label10.Visible = true;
                            label10.Text = "";

                        }

                    }
                    else
                    {
                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    textBox4.Clear();
                    IsFirstClick1 = 0;
                    break;
                default:
                    break;
            }


        }

        byte IsFirstClick2 = 0;
        private async void button5_Click(object sender, EventArgs e)
        {

            textBox1.Text = listView1.FocusedItem.SubItems[0].Text;

            switch (IsFirstClick2)
            {


                case 0:
                    if (listView2.SelectedItems.Count > 0)
                    {
                        SqlCommand getDeliveriesInfoCommand = new SqlCommand("SELECT [Name], [Price], [Duration] FROM [Deliveries] WHERE [Id]=@id", sqlConnection);
                        getDeliveriesInfoCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text));
                        SqlDataReader sqlReader = null;

                        try
                        {
                            sqlReader = await getDeliveriesInfoCommand.ExecuteReaderAsync();
                            while (await sqlReader.ReadAsync())
                            {
                                textBox5.Text = Convert.ToString(sqlReader["Name"]);
                                textBox8.Text = Convert.ToString(sqlReader["Price"]);
                                textBox7.Text = Convert.ToString(sqlReader["Duration"]);


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                    }
                    else
                    {
                        textBox5.Clear();
                        textBox8.Clear();
                        textBox7.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                    IsFirstClick2 = 1;
                    break;
                case 1:

                    if (listView2.SelectedItems.Count > 0)
                    {
                        if (label10.Visible)
                        {
                            label10.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(textBox5.Text) && !string.IsNullOrWhiteSpace(textBox5.Text)
                            && !string.IsNullOrEmpty(textBox8.Text) && !string.IsNullOrWhiteSpace(textBox8.Text)
                            && !string.IsNullOrEmpty(textBox7.Text) && !string.IsNullOrWhiteSpace(textBox7.Text)
                    )
                        {
                            SqlCommand updateDeliveriescommand = new SqlCommand("UPDATE [Deliveries] SET [Name] = @Name, [Price] = @Price, [Duration] = @Duration WHERE [Id] = @id", sqlConnection);
                            updateDeliveriescommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView2.SelectedItems[0].SubItems[0].Text));
                            updateDeliveriescommand.Parameters.AddWithValue("Name", textBox5.Text);
                            updateDeliveriescommand.Parameters.AddWithValue("Price", textBox8.Text);
                            updateDeliveriescommand.Parameters.AddWithValue("Duration", textBox7.Text);

                            try
                            {
                                await updateDeliveriescommand.ExecuteNonQueryAsync();
                                listView1.Items.Clear();
                                listView2.Items.Clear();
                                listView3.Items.Clear();
                                listView4.Items.Clear();
                                listView5.Items.Clear();

                                await LoadTableAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            label10.Visible = true;
                            label10.Text = "";

                        }
                        textBox5.Clear();
                        textBox8.Clear();
                        textBox7.Clear();

                    }
                    else
                    {
                        textBox5.Clear();
                        textBox8.Clear();
                        textBox7.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick2 = 0;
                    break;
                default:
                    break;

            }
        }

        byte IsFirstClick3 = 0;
        private async void button8_Click(object sender, EventArgs e)
        {




            switch (IsFirstClick3)
            {


                case 0:
                    if (listView3.SelectedItems.Count > 0)
                    {
                        SqlCommand getOrdersViewInfoCommand = new SqlCommand("SELECT [CustomerName], [Count], [Date],[DeliveryId] FROM [OrdersView] WHERE [Id]=@id", sqlConnection);
                        getOrdersViewInfoCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView3.SelectedItems[0].SubItems[0].Text));
                        SqlDataReader sqlReader = null;

                        try
                        {
                            sqlReader = await getOrdersViewInfoCommand.ExecuteReaderAsync();
                            while (await sqlReader.ReadAsync())
                            {
                                comboBox1.Text = Convert.ToString(sqlReader["CustomerName"]);
                                textBox9.Text = Convert.ToString(sqlReader["Count"]);
                                dateTimePicker1.Text = Convert.ToString(sqlReader["Date"]);
                                comboBox3.Text = Convert.ToString(sqlReader["DeliveryId"]);


                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                    }
                    else
                    {
                        textBox9.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick3 = 1;
                    break;
                case 1:

                    if (listView3.SelectedItems.Count > 0)
                    {
                        if (label17.Visible)
                        {
                            label17.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text)
                            && !string.IsNullOrEmpty(comboBox2.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text)
                            && !string.IsNullOrEmpty(textBox9.Text) && !string.IsNullOrWhiteSpace(textBox9.Text)
                            && !string.IsNullOrEmpty(comboBox3.Text) && !string.IsNullOrWhiteSpace(comboBox3.Text)
                    )
                        {
                            SqlCommand updateOrderscommand = new SqlCommand("UPDATE [Orders] SET [CustomerID] = @CustomerID, [ProductID] = @ProductID, [Count] = @Count,[Date] = @Date, [DeliveryId] = @DeliveryId WHERE [Id] = @id", sqlConnection);
                            updateOrderscommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView3.SelectedItems[id].SubItems[id].Text));
                            updateOrderscommand.Parameters.AddWithValue("CustomerID", (int)comboBox1.SelectedValue);
                            updateOrderscommand.Parameters.AddWithValue("ProductID", (int)comboBox2.SelectedValue);
                            updateOrderscommand.Parameters.AddWithValue("Count", textBox9.Text);
                            updateOrderscommand.Parameters.AddWithValue("Date", dateTimePicker1.Value);
                            updateOrderscommand.Parameters.AddWithValue("DeliveryId", (int)comboBox3.SelectedValue);

                            try
                            {
                                await updateOrderscommand.ExecuteNonQueryAsync();
                                listView1.Items.Clear();
                                listView2.Items.Clear();
                                listView3.Items.Clear();
                                listView4.Items.Clear();
                                listView5.Items.Clear();

                                await LoadTableAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            label17.Visible = true;
                            label17.Text = "";

                        }
                        textBox9.Clear();


                    }
                    else
                    {
                        textBox9.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick3 = 0;
                    break;
                default:
                    break;

            }
        }

        byte IsFirstClick4 = 0;
        private async void button11_Click(object sender, EventArgs e)
        {
            switch (IsFirstClick4)
            {


                case 0:
                    if (listView4.SelectedItems.Count > 0)
                    {
                        SqlCommand getProductDeliveriesViewInfoCommand = new SqlCommand("SELECT [DeliveryName] FROM [ProductDeliveriesView] WHERE [Id]=@id", sqlConnection);
                        getProductDeliveriesViewInfoCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView4.SelectedItems[0].SubItems[0].Text));
                        SqlDataReader sqlReader = null;

                        try
                        {
                            sqlReader = await getProductDeliveriesViewInfoCommand.ExecuteReaderAsync();
                            while (await sqlReader.ReadAsync())
                            {
                                comboBox5.Text = Convert.ToString(sqlReader["DeliveryName"]);



                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                    }
                    else
                    {

                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick4 = 1;
                    break;
                case 1:

                    if (listView4.SelectedItems.Count > 0)
                    {
                        if (label9.Visible)
                        {
                            label9.Visible = false;
                        }


                        if (!string.IsNullOrEmpty(comboBox5.Text) && !string.IsNullOrWhiteSpace(comboBox5.Text)
                            && !string.IsNullOrEmpty(comboBox4.Text) && !string.IsNullOrWhiteSpace(comboBox4.Text)

                    )
                        {
                            SqlCommand updateProductDeliveriescommand = new SqlCommand("UPDATE [ProductDeliveries] SET [ProductID] = @ProductID, [DeliveryID] = @DeliveryID WHERE [Id] = @id", sqlConnection);
                            updateProductDeliveriescommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView4.SelectedItems[0].SubItems[0].Text));
                            updateProductDeliveriescommand.Parameters.AddWithValue("ProductID", (int)comboBox4.SelectedValue);
                            updateProductDeliveriescommand.Parameters.AddWithValue("DeliveryID", (int)comboBox5.SelectedValue);


                            try
                            {
                                await updateProductDeliveriescommand.ExecuteNonQueryAsync();
                                listView1.Items.Clear();
                                listView2.Items.Clear();
                                listView3.Items.Clear();
                                listView4.Items.Clear();
                                listView5.Items.Clear();

                                await LoadTableAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            label9.Visible = true;
                            label9.Text = "";

                        }


                    }
                    else
                    {

                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick4 = 0;
                    break;
                default:
                    break;


            }
        }

        byte IsFirstClick = 0;
        private async void button14_Click(object sender, EventArgs e)
        {




            switch (IsFirstClick)
            {


                case 0:
                    if (listView5.SelectedItems.Count > 0)
                    {
                        SqlCommand getProductsInfoCommand = new SqlCommand("SELECT [Price],[Description] FROM [Products] WHERE [Id]=@id", sqlConnection);
                        getProductsInfoCommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView5.SelectedItems[0].SubItems[0].Text));
                        SqlDataReader sqlReader = null;

                        try
                        {
                            sqlReader = await getProductsInfoCommand.ExecuteReaderAsync();
                            while (await sqlReader.ReadAsync())
                            {
                                textBox16.Text = Convert.ToString(sqlReader["Price"]);
                                textBox14.Text = Convert.ToString(sqlReader["Description"]);



                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        finally
                        {
                            if (sqlReader != null && !sqlReader.IsClosed)
                            {
                                sqlReader.Close();
                            }
                        }
                    }
                    else
                    {
                        textBox16.Clear();
                        textBox14.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick = 1;
                    break;
                case 1:

                    if (listView5.SelectedItems.Count > 0)
                    {
                        if (label24.Visible)
                        {
                            label24.Visible = false;
                        }

                        if (!string.IsNullOrEmpty(textBox16.Text) && !string.IsNullOrWhiteSpace(textBox16.Text)
                            && !string.IsNullOrEmpty(textBox14.Text) && !string.IsNullOrWhiteSpace(textBox14.Text)

                    )
                        {
                            SqlCommand updateProductscommand = new SqlCommand("UPDATE [Products] SET [Price] = @Price, [Description] = @Description WHERE [Id] = @id", sqlConnection);
                            updateProductscommand.Parameters.AddWithValue("Id", Convert.ToInt32(listView5.SelectedItems[0].SubItems[0].Text));
                            updateProductscommand.Parameters.AddWithValue("Price", textBox16.Text);
                            updateProductscommand.Parameters.AddWithValue("Description", textBox14.Text);


                            try
                            {
                                await updateProductscommand.ExecuteNonQueryAsync();
                                listView1.Items.Clear();
                                listView2.Items.Clear();
                                listView3.Items.Clear();
                                listView4.Items.Clear();
                                listView5.Items.Clear();

                                await LoadTableAsync();
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            label24.Visible = true;
                            label24.Text = "";

                        }
                        textBox16.Clear();
                        textBox14.Clear();
                    }
                    else
                    {
                        textBox16.Clear();
                        textBox14.Clear();
                        MessageBox.Show("Ни одна строка не была выделена!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    IsFirstClick = 0;
                    break;
                default:
                    break;

            }
        }
    }
}
