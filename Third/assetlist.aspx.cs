using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Third
{
    public partial class assetlist : System.Web.UI.Page
    {
        string con = ConfigurationManager.ConnectionStrings["AssetRegister"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                AssetListGrids();
            }
        }
        
        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)AssetListGrid.Rows[e.RowIndex];
                using (SqlConnection cons = new SqlConnection(con))
                {
                    cons.Open();
                    SqlCommand cmd = new SqlCommand("delete from Asset where AssetId='" + Convert.ToInt32(AssetListGrid.DataKeys[e.RowIndex].Value.ToString()) + "'", cons);
                    cmd.ExecuteNonQuery();
                    AssetListGrids();
                    Response.Write("<script>alert('Data Deleted')</script>");
                }
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Grid Row Not Deleting Please Try Again Later...Thanks')</script>");
            }
        }
        
        protected void SearchButton_Click(object sender, EventArgs e)
        {
            SearchAsset();
        }

        protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            try
            {
                DropDownListEditVendorAsset.Items.Clear();
                TextBoxEditAssetId.Text = AssetListGrid.Rows[e.NewSelectedIndex].Cells[0].Text;
                TextBoxEditAssetName.Text = AssetListGrid.Rows[e.NewSelectedIndex].Cells[1].Text;
                DropDownListEditVendorAsset.Items.Insert(0, new ListItem(AssetListGrid.Rows[e.NewSelectedIndex].Cells[2].Text));
                EditDropDown();
                TextBoxEditCost.Text = AssetListGrid.Rows[e.NewSelectedIndex].Cells[3].Text;
            }
            catch(Exception)
            {
                Response.Write("<script>alert('Grid Not Loaded Please Try Again Later...Thanks')</script>");
            }
        }
        
        protected void ButtonEditAsset_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection cons = new SqlConnection(con))
                {
                    cons.Open();
                    SqlCommand cmd = new SqlCommand("update Asset set AssetName='" + TextBoxEditAssetName.Text + "',VendorName='" + DropDownListEditVendorAsset.Text + "', Cost='" + Convert.ToDecimal(TextBoxEditCost.Text) + "' where AssetId='" + Convert.ToInt32(TextBoxEditAssetId.Text) + "'", cons);
                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Data Updated')</script>");
                }
                AssetListGrids();
                Clear();
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Please Update The Value Proper Thanks')</script>");
            }
        }

        public void Clear()
        {
            TextBoxEditAssetId.Text = "";
            TextBoxEditAssetName.Text = "";
            DropDownListEditVendorAsset.Items.Clear();
            TextBoxEditCost.Text = "";
        }

        protected void ButtonCancelEdit_Click(object sender, EventArgs e)
        {
            Clear();
        }
        /***********************************VendorNameDropDown******************************************/
        void EditDropDown()
        {
            try
            {
                using (SqlConnection cons = new SqlConnection(con))
                {
                    cons.Open();
                    SqlCommand cmd = new SqlCommand("select VendorName from Vendor", cons);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DropDownListEditVendorAsset.Items.Add(ds.Tables[0].Rows[i][0].ToString());
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Value Not Selected Try Again Later... Thanks')</script>");
            }
        }
        /********************************Search_Button**************************************/
        void SearchAsset()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(con))
                {
                    connect.Open();
                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "select AssetID,AssetName,VendorName,Cost from Asset where AssetName like '%' +@AssetName+ '%'";
                    cmd.Connection = connect;
                    cmd.Parameters.AddWithValue("@AssetName", assetsearch.Text.Trim());
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    AssetListGrid.DataSource = dataSet;
                    AssetListGrid.DataBind();
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Search Not Proper Please Try Again Later...Thanks')</script>");
            }
        }
        /***************************************DataLoaded******************************************/
        void AssetListGrids()
        {
            try
            {
                using (SqlConnection connect = new SqlConnection(con))
                {
                    connect.Open();
                    SqlCommand sqlcom = new SqlCommand("select * from Asset", connect);
                    SqlDataReader dr = sqlcom.ExecuteReader();
                    if (dr.HasRows == true)
                    {
                        AssetListGrid.DataSource = dr;
                        AssetListGrid.DataBind();
                    }
                }
            }
            catch (Exception)
            {
                Response.Write("<script>alert('Data Not Loading Proper Please Try Again Later...Thanks')</script>");
            }
        }
    }
}