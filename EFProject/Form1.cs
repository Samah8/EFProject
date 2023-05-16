using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EFProject
{
    public partial class Form1 : Form
    {
        ListBox list1 = new ListBox();
        Model1 ent = new Model1();
        System.Windows.Forms.Button b1 = new System.Windows.Forms.Button();
        System.Windows.Forms.Button b2 = new System.Windows.Forms.Button();
        System.Windows.Forms.Button b3 = new System.Windows.Forms.Button();
        System.Windows.Forms.Button b4 = new System.Windows.Forms.Button();
        
        public Form1()
        {
            InitializeComponent(); 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           stores.Visible = false;
           items.Visible = false;
           customers.Visible = false;
           suppliers.Visible = false;
           orders.Visible = false;
           imports.Visible = false;
            
            b1.Click += new EventHandler(b1_Click);
            b2.Click += new EventHandler(b2_Click);
            b3.Click += new EventHandler(b3_Click);
            b4.Click += new EventHandler(b4_Click);


            var stor = from d in ent.Stores select d;
            foreach (Store store in stor)
            {
                comboStore.Items.Add(store.store_name);
            }

            var item = from d in ent.Items select d;
            foreach (Item i in item)
            {
                comboItem.Items.Add(i.item_name);
                comImpItem.Items.Add(i.item_name);
                comOrderItem.Items.Add(i.item_name);
                comImpItem.SelectedValue = i.item_id;
            }

            var cus = from d in ent.Customers select d;
            foreach (Customer c in cus)
            {
                comboCus.Items.Add(c.cus_name);
            }

            var sup = from d in ent.Suppliers select d;
            foreach (Supplier s in sup)
            {
                comboSup.Items.Add(s.sup_name);
            }

            var import = from d in ent.Import_Perrmission select d;
            foreach (Import_Perrmission im in import)
            {
                comboImport.Items.Add(im.import_id);
            }

            var order = from d in ent.Orders select d;
            foreach (Order o in order)
            {
                comboOrder.Items.Add(o.order_id);
            }

            


        }

        private void button7_Click(object sender, EventArgs e)
        {
            list1.Visible = true;
            list1.Items.Clear();
            list1.Location = suppliers.Location;
            list1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            list1.BorderStyle= BorderStyle.None;
            list1.Width = 500;
            DateTime time = DateTime.Now;
            list1.Items.Add("Time  :  " + time);
            list1.Items.Add("");
            foreach(Store s in ent.Stores)
            {
                string str = s.store_id.ToString() + " \t" + s.store_address + " \t" + s.store_name + " \t  " + s.Employee.Ename;

                list1.Items.Add(str);
            }
            Controls.Add(list1);
        }

        private void itemReport_Click(object sender, EventArgs e)
        {
            b1.Location = new Point(230, 281);
            b1.Text = "Details";
            b2.Location = new Point(340, 281);
            b2.Text = "Transform";
            b3.Location = new Point(450, 281);
            b3.Text = "Time";
            b4.Location = new Point(560, 281);
            b4.Text = "Expiry";
            Controls.Add(b1);
            Controls.Add(b2);
            Controls.Add(b3);
            Controls.Add(b4);

        }

        private void b1_Click(object sender, EventArgs e)
        {
            ListBox list1 = new ListBox();
            list1.Items.Clear();
            list1.Location = new Point(753, 50);
            list1.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            list1.BorderStyle = BorderStyle.None;
            list1.Width = 500;
            string strr = "Name"+  "\t" +"Code" +"\t     " + "Measure" + "   \t" + "Quantity " + " \t" + "Production Date" + "  \t    " + "Expiry Date";
            list1.Items.Add(strr);
            foreach (Import_Items item in ent.Import_Items)
            { 
                
                string str = item.Item.item_name +"\t"+item.Item.item_code + " \t"+item.Item.unit_measure + " \t"+
                   item.item_quantity+ " \t" + item.item_production+" \t" + item.item_expiry;
                list1.Items.Add(str);
            }
            Controls.Add(list1);

        }

        private void b2_Click(object sender, EventArgs e)
        {
            list1.Visible = false;
            System.Windows.Forms.TextBox text = new System.Windows.Forms.TextBox();
            text.Location = new Point(753,30);
            Transformation transformation = ent.Transformations.Select(d => d).FirstOrDefault();
            text.Text = transformation.date.ToString();
            ListBox list = new ListBox();
            list.Items.Clear();
            list.Location = new Point(753, 50);
            list.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            list.BorderStyle = BorderStyle.None;
            list.Width = 500;
            list.Items.Add("\n");
            list.Items.Add(transformation.Item.item_name+"\t"+transformation.item_quantity + "\t" + transformation.item_expiry + "\t" + transformation.date);
            Controls.Add(text);
            Controls.Add(list);
        }

        private void b3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = new System.Windows.Forms.TextBox();
            text.Location = new Point(753, 30);
            Transformation transformation = ent.Transformations.Select(d => d).FirstOrDefault();
            text.Text = transformation.production_item.ToString();
            ListBox list = new ListBox();
            list.Items.Clear();
            list.Location = new Point(753, 50);
            list.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            list.BorderStyle = BorderStyle.None;
            list.Width = 500;
            list.Items.Add("\n");
            list.Items.Add(transformation.Item.item_name + "\t" + transformation.item_quantity + "\t" + transformation.item_expiry + "\t" + transformation.date);
            Controls.Add(text);
            Controls.Add(list);
        }

        private void b4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox text = new System.Windows.Forms.TextBox();
            text.Location = new Point(753, 30);
            Transformation transformation = ent.Transformations.Select(d => d).FirstOrDefault();
            text.Text = transformation.item_expiry.ToString();
            ListBox list = new ListBox();
            list.Items.Clear();
            list.Location = new Point(753, 50);
            list.BackColor = System.Drawing.Color.FromArgb(255, 255, 192);
            list.BorderStyle = BorderStyle.None;
            list.Width = 500;
            list.Items.Add("\n");
            list.Items.Add(transformation.Item.item_name + "\t" + transformation.item_quantity + "\t" + transformation.item_expiry + "\t" + transformation.production_item + "\t" + transformation.date);
            Controls.Add(text);
            Controls.Add(list);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            items.Visible = customers.Visible = suppliers.Visible = imports.Visible = orders.Visible = false;
            if (stores.Visible)
            {
                stores.Visible = false;
            }
            else
            {
                stores.Visible = true;

            }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            stores.Visible = customers.Visible = suppliers.Visible = imports.Visible = orders.Visible = list1.Visible = false; ;
            items.Location = stores.Location;
            if (items.Visible)
            {
                items.Visible = false;
            }
            else
            {
                items.Visible = true;

            }

        }

        private void label5_Click(object sender, EventArgs e)
        {
            stores.Visible =items.Visible = suppliers.Visible = imports.Visible =orders.Visible= list1.Visible = false; ;
           
            customers.Location = stores.Location;
            if (customers.Visible)
            {
                customers.Visible = false;
            }
            else
            {
                customers.Visible = true;

            }

        }

        private void label6_Click(object sender, EventArgs e)
        {
            stores.Visible=customers.Visible = orders.Visible = imports.Visible =items.Visible= list1.Visible = false;
            
            suppliers.Location = stores.Location;
            if (suppliers.Visible)
            {
                suppliers.Visible = false;
            }
            else
            {
                suppliers.Visible = true;

            }

        }

        private void label7_Click(object sender, EventArgs e)
        {
            stores.Visible = items.Visible = customers.Visible =suppliers.Visible= orders.Visible= list1.Visible = false;

            imports.Location = stores.Location;
            if (imports.Visible)
            {
                imports.Visible = false;
            }
            else
            {
                imports.Visible = true;

            }
        }

        private void label8_Click(object sender, EventArgs e)
        {
            stores.Visible = items.Visible = customers.Visible = suppliers.Visible=imports.Visible= list1.Visible = false;

            orders.Location = stores.Location;
            if (orders.Visible)
            {
                orders.Visible = false;
            }
            else
            {
                orders.Visible = true;

            }
        }

        private void comboStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboStore.Text;
            Store stor = ent.Stores.Where(d => d.store_name == name).Select(d => d).FirstOrDefault();
            if (stor != null)
            {
                StoreID.Text =stor.store_id.ToString();
                StoreName.Text = stor.store_name ;
                StoreAddress.Text = stor.store_address;
                ManagerID.Text = stor.manager_id.ToString();
                
            }
            else
            {
                MessageBox.Show("Invalid Store Name ");
            }
        }

        private void addStore_Click(object sender, EventArgs e)
        {
            Store stor = new Store();
            int ID =int.Parse(StoreID.Text);
            Store st = (ent.Stores.Where(d => d.store_id == ID).Select(d => d)).FirstOrDefault();
            if (st == null)
            {
                if (StoreID.Text != "" && StoreAddress.Text != "" && StoreName.Text != "" && ManagerID.Text != "")
                {
                    stor.store_id =int.Parse( StoreID.Text);
                    stor.store_name = StoreName.Text;
                    stor.store_address = StoreAddress.Text;
                    stor.manager_id = int.Parse(ManagerID.Text);
                    Employee emp = (ent.Employees.Where(d => d.Eid == stor.manager_id).Select(d => d)).FirstOrDefault();
                    if(emp !=null)
                    { 
                        ent.Stores.Add(stor);
                        ent.SaveChanges();
                        comboStore.Items.Add(stor.store_name);
                        StoreID.Text = StoreName.Text = StoreAddress.Text = ManagerID.Text="";
                        MessageBox.Show("Store is Added Successfully");
                    }
                    else
                    {
                        MessageBox.Show("Invalid ManagerID");
                    }
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void editStore_Click(object sender, EventArgs e)
        {
            var ID =int.Parse( StoreID.Text);
            Store stor = (ent.Stores.Where(d => d.store_id == ID).Select(d => d)).FirstOrDefault();
            if (stor != null)
            {
                if (StoreName.Text != "" && StoreAddress.Text != "" && ManagerID.Text != "")
                {
                    stor.store_name = StoreName.Text;
                    stor.store_address = StoreAddress.Text;
                    stor.manager_id =int.Parse( ManagerID.Text);
                    Employee emp = (ent.Employees.Where(d => d.Eid == stor.manager_id).Select(d => d)).FirstOrDefault();
                    if(emp !=null)
                    {
                        ent.SaveChanges();
                        StoreID.Text = StoreName.Text = StoreAddress.Text = ManagerID.Text = "";
                        MessageBox.Show("Store is Updated");
                    }
                    else
                    {
                        MessageBox.Show("Invalid ManagerID");
                    }

                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Store ID");
        }

        private void comboSup_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboSup.Text;
            Supplier sup = ent.Suppliers.Where(d => d.sup_name == name).Select(d => d).FirstOrDefault();
            if (sup != null)
            {
                SupID.Text = sup.sup_id.ToString();
                SupName.Text = sup.sup_name;
                SupEmail.Text = sup.sup_email;
                SupFax.Text = sup.sup_fax;
                SupMobile.Text = sup.sup_mobile;
                SupPhone.Text = sup.sup_phone;

            }
            else
            {
                MessageBox.Show("Invalid Suuplier Name ");
            }
        }

        private void AddSup_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier();
            int ID = int.Parse(SupID.Text);
            Supplier st = (ent.Suppliers.Where(d => d.sup_id == ID).Select(d => d)).FirstOrDefault();
            if (st == null)
            {
                if (SupID.Text != "" && SupName.Text != "" && SupEmail.Text != "" && SupFax.Text != "" && SupMobile.Text != "" && SupPhone.Text != "")
                {
                    sup.sup_id = int.Parse(SupID.Text);
                    sup.sup_name = SupName.Text;
                    sup.sup_fax = SupFax.Text;
                    sup.sup_phone = SupPhone.Text;
                    sup.sup_mobile = SupMobile.Text;
                    sup.sup_email = SupEmail.Text;
                    ent.Suppliers.Add(sup);
                    ent.SaveChanges();
                    comboSup.Items.Add(sup.sup_name);
                    SupID.Text = SupName.Text = SupEmail.Text = SupFax.Text = SupMobile.Text = SupPhone.Text = "";
                    MessageBox.Show("Supplier is Added Successfully");
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void EditSup_Click(object sender, EventArgs e)
        {
            var ID = int.Parse(SupID.Text);
            Supplier sup = (ent.Suppliers.Where(d => d.sup_id == ID).Select(d => d)).FirstOrDefault();
            if (sup != null)
            {
                if (SupID.Text != "" && SupName.Text != "" && SupEmail.Text != "" && SupFax.Text != "" && SupMobile.Text != "" && SupPhone.Text != "")
                {
                    sup.sup_name = SupName.Text;
                    sup.sup_fax = SupFax.Text;
                    sup.sup_phone = SupPhone.Text;
                    sup.sup_mobile = SupMobile.Text;
                    sup.sup_email = SupEmail.Text;
                    ent.SaveChanges();
                    SupID.Text = SupName.Text = SupEmail.Text = SupFax.Text = SupMobile.Text = SupPhone.Text = "";
                    MessageBox.Show("Supplier is Updated");
                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Supplier ID");
        }

        private void comboCus_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboCus.Text;
            Customer cus = ent.Customers.Where(d => d.cus_name == name).Select(d => d).FirstOrDefault();
            if (cus != null)
            {
                CusID.Text = cus.cus_id.ToString();
                CusName.Text = cus.cus_name;
                CusEmail.Text = cus.cus_email;
                CusFax.Text = cus.cus_fax;
                CusMobile.Text = cus.cus_mobile;
                CusPhone.Text = cus.cus_phone;

            }
            else
            {
                MessageBox.Show("Invalid Customer Name ");
            }
        }

        private void addCus_Click(object sender, EventArgs e)
        {
            Customer cus = new Customer();
            int ID = int.Parse(CusID.Text);
            Customer st = (ent.Customers.Where(d => d.cus_id == ID).Select(d => d)).FirstOrDefault();
            if (st == null)
            {
                if (CusID.Text != "" && CusName.Text != "" && CusEmail.Text != "" && CusFax.Text != "" && CusMobile.Text != "" && CusPhone.Text != "")
                {
                    cus.cus_id = int.Parse(CusID.Text);
                    cus.cus_name = CusName.Text;
                    cus.cus_fax = CusFax.Text;
                    cus.cus_phone = CusPhone.Text;
                    cus.cus_mobile = CusMobile.Text;
                    cus.cus_email = CusEmail.Text;
                    ent.Customers.Add(cus);
                    ent.SaveChanges();
                    comboCus.Items.Add(cus.cus_name);
                    CusID.Text = CusName.Text = CusEmail.Text = CusFax.Text = CusMobile.Text = CusPhone.Text = "";
                    MessageBox.Show("Customer is Added Successfully");
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void editCus_Click(object sender, EventArgs e)
        {

            var ID = int.Parse(CusID.Text);
            Customer cus = (ent.Customers.Where(d => d.cus_id == ID).Select(d => d)).FirstOrDefault();
            if (cus != null)
            {
                if ( CusName.Text != "" && CusEmail.Text != "" && CusFax.Text != "" && CusMobile.Text != "" && CusPhone.Text != "")
                {
                    cus.cus_name = CusName.Text;
                    cus.cus_fax = CusFax.Text;
                    cus.cus_phone = CusPhone.Text;
                    cus.cus_mobile = CusMobile.Text;
                    cus.cus_email = CusEmail.Text;
                    ent.SaveChanges();
                    CusID.Text = CusName.Text = CusEmail.Text = CusFax.Text = CusMobile.Text = CusPhone.Text = "";
                    MessageBox.Show("Customer is Updated");
                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Customer ID");
        }

        private void comboItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = comboItem.Text;
            Item item = ent.Items.Where(d => d.item_name == name).Select(d => d).FirstOrDefault();
            if (item != null)
            {
                ItemID.Text = item.item_id.ToString();
                ItemName.Text = item.item_name;
                ItemCode.Text = item.item_code;
                ItemUnit.Text = item.unit_measure;
            }
            else
            {
                MessageBox.Show("Invalid Item Name ");
            }
        }

        private void addItem_Click(object sender, EventArgs e)
        {
            Item item = new Item();
            int ID = int.Parse(ItemID.Text);
            Item st = (ent.Items.Where(d => d.item_id == ID).Select(d => d)).FirstOrDefault();
            if (st == null)
            {
                if (ItemID.Text != "" && ItemName.Text != "" && ItemCode.Text != "" && ItemUnit.Text != "" )
                {
                    item.item_id = int.Parse(ItemID.Text);
                    item.item_name = ItemName.Text;
                    item.item_code = ItemCode.Text;
                    item.unit_measure = ItemUnit.Text;
                    ent.Items.Add(item);
                    ent.SaveChanges();
                    comboItem.Items.Add(item.item_name);
                    ItemID.Text = ItemName.Text = ItemCode.Text = ItemUnit.Text = "";
                    MessageBox.Show("Item is Added Successfully");
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void editItem_Click(object sender, EventArgs e)
        {
            var ID = int.Parse(ItemID.Text);
            Item item = (ent.Items.Where(d => d.item_id == ID).Select(d => d)).FirstOrDefault();
            if (item != null)
            {
                if (ItemID.Text != "" && ItemName.Text != "" && ItemCode.Text != "" && ItemUnit.Text != "")
                {
                    item.item_name = ItemName.Text;
                    item.item_code = ItemCode.Text;
                    item.unit_measure = ItemUnit.Text;
                    ent.SaveChanges();
                    ItemID.Text = ItemName.Text = ItemCode.Text = ItemUnit.Text = "";
                    MessageBox.Show("Item is Updated");
                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Item Name");
        }

        private void comboImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID =int.Parse( comboImport.Text);
            Import_Perrmission import = ent.Import_Perrmission.Where(d => d.import_id == ID).Select(d => d).FirstOrDefault();
            comImpItem.Items.Clear();
            if (import != null)
            {
                ImpID.Text = import.import_id.ToString();
                ImpDate.Text = import.import_date.ToString();
                ImpStoreID.Text = import.store_id.ToString();
                ImpSupID.Text = import.supplier_id.ToString();
                foreach (Import_Items m in import.Import_Items)
                {
                    comImpItem.Items.Add(m.Item.item_name);
                    
                }
                
            }
            else
            {
                MessageBox.Show("Invalid Import Permission ID ");
            }
        }

        private void comImpItem_SelectedIndexChanged(object sender, EventArgs e)
        {
           int id= int.Parse(ImpID.Text);
           Import_Items import=ent.Import_Items.Where(d=>d.import_id==id).Select(d => d).FirstOrDefault();
            if(import !=null)
            {
                string name = comImpItem.Text;
                Import_Items impItem = ent.Import_Items.Where(d => d.Item.item_name == name&&d.import_id==import.import_id).Select(d => d).FirstOrDefault();
                if(impItem !=null)
                {
                    quantity.Text = impItem.item_quantity.ToString();
                    ProducDate.Text = impItem.item_production.ToString();
                    ExpiryDate.Text = impItem.item_expiry.ToString();
                }
            }

        }

        private void addImport_Click(object sender, EventArgs e)
        {
            Import_Perrmission import = new Import_Perrmission();
            Import_Items impItem = new Import_Items();
            int ID = int.Parse(ImpID.Text);
            Import_Perrmission st = (ent.Import_Perrmission.Where(d => d.import_id == ID).Select(d => d)).FirstOrDefault();
            if (st == null)
            {
                if (ImpID.Text != "" && ImpDate.Text != "" && ImpStoreID.Text != "" && ImpSupID.Text != ""&& quantity.Text!=""&&ProducDate.Text!="" &&ExpiryDate.Text!="")
                {
                    import.import_id = int.Parse(ImpID.Text);
                    import.import_date = DateTime.Parse(ImpDate.Text);
                    import.store_id =int.Parse(ImpStoreID.Text);
                    import.supplier_id = int.Parse(ImpSupID.Text);
                    impItem.import_id=int.Parse(ImpID.Text);
                    var name =comImpItem.SelectedItem.ToString();
                    if(name==null)
                    {
                        MessageBox.Show("Select Item From List");
                    }
                    Item i =ent.Items.Where(d=>d.item_name==name).Select(d=>d).FirstOrDefault();
                    impItem.item_id = i.item_id;
                    impItem.item_quantity = int.Parse(quantity.Text);
                    impItem.item_production=DateTime.Parse(ProducDate.Text);
                    impItem.item_expiry = DateTime.Parse(ExpiryDate.Text);
                    ent.Import_Perrmission.Add(import);
                    ent.Import_Items.Add(impItem);
                    ent.SaveChanges();
                    comboImport.Items.Add(import.import_id);
                    comImpItem.Items.Add(impItem.Item.item_name);
                    ImpID.Text = ImpDate.Text = ImpStoreID.Text = ImpSupID.Text =quantity.Text=ProducDate.Text=ExpiryDate.Text= "";
                    MessageBox.Show("Import Permission is Added Successfully");
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void editImport_Click(object sender, EventArgs e)
        {
            var ID = int.Parse(ImpID.Text);
            Import_Perrmission import = (ent.Import_Perrmission.Where(d => d.import_id == ID).Select(d => d)).FirstOrDefault();
            Import_Items impItem = (ent.Import_Items.Where(d => d.import_id == ID).Select(d => d)).FirstOrDefault();
            if (import != null && impItem != null)
            {
                if (ImpID.Text != "" && ImpDate.Text != "" && ImpStoreID.Text != "" && ImpSupID.Text != "" && quantity.Text != "" && ProducDate.Text != "" && ExpiryDate.Text != "")
                {
                    import.import_date = DateTime.Parse(ImpDate.Text);
                    import.store_id = int.Parse(ImpStoreID.Text);
                    import.supplier_id = int.Parse(ImpSupID.Text);
                    impItem.import_id = int.Parse(ImpID.Text);
                    var name = comImpItem.SelectedItem.ToString();
                    if (name == null)
                    {
                        MessageBox.Show("Select Item From List");
                    }
                    Item i = ent.Items.Where(d => d.item_name == name).Select(d => d).FirstOrDefault();
                    Import_Items im =ent.Import_Items.Where(d=>d.item_id==i.item_id).Select(d => d).FirstOrDefault();
                    if (im !=null)
                    {
                        im.item_quantity = int.Parse(quantity.Text);
                        im.item_production = DateTime.Parse(ProducDate.Text);
                        im.item_expiry = DateTime.Parse(ExpiryDate.Text);
                    }
                    else
                        MessageBox.Show("Selected Item is not found");
                    
                    ent.SaveChanges();
                    ImpID.Text = ImpDate.Text = ImpStoreID.Text = ImpSupID.Text = quantity.Text = ProducDate.Text = ExpiryDate.Text = "";
                    
                    MessageBox.Show("Import Permission is Updated");
                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Import Permission Name");

        }

        private void comboOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = int.Parse(comboOrder.Text);
            Order order = ent.Orders.Where(d => d.order_id == ID).Select(d => d).FirstOrDefault();
            if (order != null)
            {
                OrderID.Text = order.order_id.ToString();
                OrderDate.Text = order.order_date.ToString();
                OrderStoreID.Text = order.store_id.ToString();
                OrderCusID.Text = order.cus_id.ToString();
                comOrderItem.Items.Clear();
                foreach (Order_Items m in order.Order_Items)
                {
                    comOrderItem.Items.Add(m.Item.item_name);

                }
            }
            else
            {
                MessageBox.Show("Invalid Order  ID ");
            }
        }

        private void comOrderItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(OrderID.Text);
            Order_Items item = ent.Order_Items.Where(d => d.order_id == id).Select(d => d).FirstOrDefault();
            if (item != null)
            {
                string name = comOrderItem.Text;
                Order_Items ordItem = ent.Order_Items.Where(d => d.Item.item_name == name && d.order_id == item.order_id).Select(d => d).FirstOrDefault();
                if(ordItem!=null)
                {
                    orderQuantity.Text = ordItem.item_quantity.ToString();
                }

            }
            
        }

        private void addOrder_Click(object sender, EventArgs e)
        {
            Order_Items orditem = new Order_Items();
            Order order = new Order();
            int ID = int.Parse(OrderID.Text);
            Order st = (ent.Orders.Where(d => d.order_id == ID).Select(d => d)).FirstOrDefault();
          
            if (st == null)
            {
                if (OrderID.Text != "" && OrderDate.Text != "" && OrderCusID.Text != "" && OrderStoreID.Text != "" && orderQuantity.Text != "")
                {
                    order.order_id = int.Parse(OrderID.Text);
                    order.order_date = DateTime.Parse(OrderDate.Text);
                    order.store_id = int.Parse(OrderStoreID.Text);
                    order.cus_id = int.Parse(OrderCusID.Text);
                    orditem.order_id = int.Parse(OrderID.Text);
                    var name = comOrderItem.SelectedItem.ToString();
                    if (name == null)
                    {
                        MessageBox.Show("Select Item From List");
                    }
                    Item i = ent.Items.Where(d => d.item_name == name).Select(d => d).FirstOrDefault();
                    orditem.item_id = i.item_id;
                    orditem.item_quantity = int.Parse(orderQuantity.Text);
                    ent.Orders.Add(order);
                    ent.Order_Items.Add(orditem);
                    ent.SaveChanges();
                    comboOrder.Items.Add(order.order_id);
                    comOrderItem.Items.Add(orditem.Item.item_name);
                    OrderID.Text = OrderDate.Text = OrderCusID.Text = OrderStoreID.Text = orderQuantity.Text= "";
                    MessageBox.Show("Order is Added Successfully");
                }
                else
                    MessageBox.Show("Please Enter Data in All Fields");
            }
            else
                MessageBox.Show("Duplicate ID");
        }

        private void editOrder_Click(object sender, EventArgs e)
        {
            var ID = int.Parse(OrderID.Text);
            Order order = (ent.Orders.Where(d => d.order_id == ID).Select(d => d)).FirstOrDefault();
            Order_Items ordItem = (ent.Order_Items.Where(d => d.order_id == ID).Select(d => d)).FirstOrDefault();
            if (order != null && ordItem!=null)
            {
                if (OrderID.Text != "" && OrderDate.Text != "" && OrderCusID.Text != "" && OrderStoreID.Text != "" && orderQuantity.Text!="")
                {
                    order.order_date = DateTime.Parse(OrderDate.Text);
                    order.store_id = int.Parse(OrderStoreID.Text);
                    order.cus_id = int.Parse(OrderCusID.Text);
                    var name = comOrderItem.SelectedItem.ToString();
                    if (name == null)
                    {
                        MessageBox.Show("Select Item From List");
                    }
                    Item i = ent.Items.Where(d => d.item_name == name).Select(d => d).FirstOrDefault();
                    Order_Items im = ent.Order_Items.Where(d => d.item_id == i.item_id).Select(d => d).FirstOrDefault();
                    if (im != null)
                    {
                        im.item_quantity = int.Parse(orderQuantity.Text);
                    }
                    else
                        MessageBox.Show("Selected Item is not found");
                    ent.SaveChanges();
                    OrderID.Text = OrderDate.Text = OrderCusID.Text = OrderStoreID.Text =orderQuantity.Text= "";
                    MessageBox.Show("Order is Updated");
                }
                else
                    MessageBox.Show("Enter Data in All TextBoxes");
            }
            else
                MessageBox.Show("Invalid Order ID");
        }


    }
}
