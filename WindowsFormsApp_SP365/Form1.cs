using Microsoft.SharePoint.Client;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SP = Microsoft.SharePoint.Client;

using System.IO;
using System.Xml;

namespace WindowsFormsApp_SP365
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        List<AllList> Lists = new List<AllList>();
        List<AllView> Views = new List<AllView>();
        MsOnlineClaimsHelper claimsHelper;
        ClientContext clientContext;
        Web oWebsite;

        public Form1()
        {
            InitializeComponent();
        }

       

        private void btOpenList_Click(object sender, EventArgs e)
        {
           

           

        }

        private void btLoadSite_Click(object sender, EventArgs e)
        {
            claimsHelper = new MsOnlineClaimsHelper(tbSiteURL.Text, tbLogin.Text, tbPwd.Text);
            clientContext = new ClientContext(tbSiteURL.Text);
           
                clientContext.ExecutingWebRequest += claimsHelper.clientContext_ExecutingWebRequest;

                oWebsite = clientContext.Web;
                ListCollection collList = oWebsite.Lists;
            
             
                clientContext.Load(collList);

                clientContext.ExecuteQuery();


                clientContext.Load(oWebsite);
                clientContext.ExecuteQuery();
                lWeb.Text = oWebsite.Title;
               
                foreach (SP.List oList in collList)
                {
                    Lists.Add(new AllList { Title = oList.Title, Id = oList.Id });

                    lbLists.Items.Add(oList.Title);
                }
            
        }

        private void lbLists_DoubleClick(object sender, EventArgs e)
        {
        
        }

        private void lbLists_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var sList = Lists.Where(x => x.Title == lbLists.SelectedItem.ToString());
            //Get view
            //Views.Clear();
            List list = clientContext.Web.Lists.GetByTitle(sList.First().Title.ToString());
            //ViewCollection viewColl = list.Views;
            //clientContext.Load(viewColl,
            //    views => views.Include(
            //        view => view.Title,
            //        view => view.Id));
            //clientContext.ExecuteQuery();
            //foreach (SP.View view in viewColl)
            //{
              
            //    lbViews.Items.Add(view.Title);
            //    Views.Add(new AllView { Name = view.Title, Id = view.Id });
            //}


            SP.List oList = clientContext.Web.Lists.GetByTitle(sList.First().Title.ToString());
            var camlQuery = new CamlQuery { ViewXml = "<View><RowLimit>100000</RowLimit></View>" };
            ListItemCollection collListItem = oList.GetItems(camlQuery);

            clientContext.Load(collListItem,
             items => items.Include(
                item => item.Id,
                item => item.DisplayName,
                item => item.HasUniqueRoleAssignments));

            clientContext.ExecuteQuery();

          //  MessageBox.Show("In list "+sList.First().Id.ToString()+Environment.NewLine+"Found items: "+ collListItem.Count);

            DialogResult dialogResult = MessageBox.Show("Really delete "+ collListItem.Count+" items?", "Deleting items list "+ sList.First().Title.ToString(), MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Delete items
                CamlQuery q = new CamlQuery();
                q.ViewXml = "<View><RowLimit>10000</RowLimit></View>";
                // We get the results
                SP.ListItemCollection coll = list.GetItems(q);

                clientContext.Load(coll);
                clientContext.ExecuteQuery();


                if (coll.Count > 0)
                {
                    for (int i = coll.Count - 1; i >= 0; i--)
                    {
                        coll[i].DeleteObject();

                        progressBar1.Value = (int)(i/collListItem.Count  ) * 100;
                        int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                        progressBar1.Refresh();
                        progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                            new Font("Arial", (float)8.25, FontStyle.Regular),
                            Brushes.Black,
                            new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                    }
                    clientContext.ExecuteQuery();
                }
                MessageBox.Show("Done!");
                progressBar1.Value = 0;
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
                DialogResult dialogResult2 = MessageBox.Show("Import rows?", "Import from Excel in list " + sList.First().Title.ToString(), MessageBoxButtons.YesNo);
                if (dialogResult2 == DialogResult.Yes)
                {
                    // Create an instance of the open file dialog box.
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();

                    // Set filter options and filter index.
                    openFileDialog1.Filter = "Excel File (.xlsx)|*.xlsx";
                    openFileDialog1.FilterIndex = 1;

                    openFileDialog1.Multiselect = false;

                    // Call the ShowDialog method to show the dialog box.
                    if (openFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        try
                        {
                            var bookFileNULL = new LinqToExcel.ExcelQueryFactory(openFileDialog1.FileName);
                            List<AllItem>PoliciesNULL =
                            (from row in bookFileNULL.Worksheet("Table1")
                            let item = new AllItem
                            {
                                Name = row["Title"].Cast<string>()
                            }
                            // where item.Supplier == "Walmart"
                            select item).ToList();

                            MessageBox.Show("Found items for import: " + PoliciesNULL.Count());
                            //Add items
                            int i = 0;
                            foreach(AllItem pol in PoliciesNULL)
                            {
                                i++;
                                AddItems(sList.First().Title.ToString(), Views.First().Id.ToString(), pol);

                                progressBar1.Value = (int)(i/ PoliciesNULL.Count)*100;
                                int percent = (int)(((double)progressBar1.Value / (double)progressBar1.Maximum) * 100);
                                progressBar1.Refresh();
                                progressBar1.CreateGraphics().DrawString(percent.ToString() + "%",
                                    new Font("Arial", (float)8.25, FontStyle.Regular),
                                    Brushes.Black,
                                    new PointF(progressBar1.Width / 2 - 10, progressBar1.Height / 2 - 7));
                            }
                            MessageBox.Show("Done!");
                            progressBar1.Value = 0;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                        }
                        
                    }
                }
                else if (dialogResult2 == DialogResult.No)
                {
                    //do something else
                }
            }
        }

        private static String BuildBatchDeleteCommand(SP.List list, SP.ListItemCollection coll)
        {
            StringBuilder sbDelete = new StringBuilder();
            sbDelete.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?><Batch>");

            // We prepare a String.Format with a String.Format, this is why we have a {{0}}
            string command = String.Format("<Method><SetList Scope=\"Request\">{0}</SetList><SetVar Name=\"ID\">{{0}}</SetVar><SetVar Name=\"Cmd\">Delete</SetVar></Method>", list.Id);
            foreach (SP.ListItem item in coll)
            {
                sbDelete.Append(string.Format(command, item.Id.ToString()));
            }
            sbDelete.Append("</Batch>");
            return sbDelete.ToString();
        }

        private void AddItems(string listGUID, string activeItemViewGUID, AllItem item)
        {
            var list = clientContext.Web.Lists.GetByTitle(listGUID);
            var itemCreateInfo = new ListItemCreationInformation();
            var listItem = list.AddItem(itemCreateInfo);
            listItem["Title"] = item.Name;
            listItem.Update();     //prepare to create new List Item
            clientContext.ExecuteQuery();   //submit request to the server goes here   
        }
    }



    internal class AllList
    {
        public String Title { get; set; }
        public Guid Id { get; set; }
    }

    internal class AllView
    {
        public String Name { get; set; }
        public Guid Id { get; set; }
    }

    internal class AllItem
    {
        public String Name { get; set; }
       
    }
}
