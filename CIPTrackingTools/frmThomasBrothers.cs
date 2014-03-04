using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
//using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace CIPTrackingTools
{
    public partial class frmThomasBrothers : Form
    {
        public frmThomasBrothers()
        {
            InitializeComponent();
            checkFindEnable();
            txtThomasBrothersPage.Focus();

        }

        private void txtThomasBrothersPage_TextChanged(object sender, EventArgs e)
        {
            checkFindEnable();
        }

        private void txtThomasBrothersRow_TextChanged(object sender, EventArgs e)
        {
            checkFindEnable();
        }

        private void txtThomasBrothersColumn_TextChanged(object sender, EventArgs e)
        {
            checkFindEnable();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
           if (txtThomasBrothersPage.Text == " " || txtThomasBrothersColumn.Text == " " || txtThomasBrothersRow.Text == " ")
           {
               MessageBox.Show("Invalid Thomas Brothers Page, Row, or Column Entered.", "Error On Search");
           }
           else
           {
               this.Cursor = Cursors.WaitCursor;
               IFeatureLayer pFL;
               commonsubs comSub = new commonsubs();
               IMxDocument pMxDoc = ArcMap.Document;
               IMap pMap = pMxDoc.FocusMap;
               ILayer player = null;
               string swhere = "";
               string ermsg = "";
               
               //Determine if it is the page or the tile
               if (txtThomasBrothersColumn.Text == "" && txtThomasBrothersRow.Text == "")
               {
                  player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_PAGE_TB");
                  swhere = "PAGE = '" + txtThomasBrothersPage.Text + "'";
                  ermsg = "The Page entered was now found";
               }
               else
               {
                  player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_TILE_TB");
                  swhere = "PAGE = '" + txtThomasBrothersPage.Text + "' AND ROW_ = '" + txtThomasBrothersRow.Text + "' AND COLUMN_ = '" + txtThomasBrothersColumn.Text.ToUpper() + "'";
                  ermsg = "The Page, Column, and Row combination entered was now found";
               }
      
               //Run the search
               int selcount = 0;
               IEnvelope pEnvelope = new EnvelopeClass();
               pEnvelope.SetEmpty();
               if (player != null)
                {
                   pFL = player as IFeatureLayer;
                    selcount = comSub.SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL,swhere);
                    if (selcount > 0)
                    {
                        player.Visible = true;
                        comSub.zoomtoselected(player, pEnvelope);
                        System.Diagnostics.Debug.WriteLine(player.Name);
                    }
                    else
                    {
                        MessageBox.Show(ermsg, "Please try another selection");
                    }

                }
               ResetTBForm();
               this.Cursor = Cursors.Default; 
           }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtThomasBrothersPage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar)) // && e.KeyChar != '.')
                e.Handled = true; 
        }

        private void txtThomasBrothersRow_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
                e.Handled = true; 
        }

        private void txtThomasBrothersColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((Char.IsLetter(e.KeyChar) || Char.IsControl(e.KeyChar)) && !char.IsDigit(e.KeyChar))
                // Allow input. 
                e.Handled = false;
            else
                e.Handled = true;
            
        }

        private void checkFindEnable()
        {
          if (txtThomasBrothersPage.Text == "")
           {
               btnFind.Enabled = false;
               txtThomasBrothersColumn.Enabled = false;
               txtThomasBrothersRow.Enabled = false;
           }
          else if (txtThomasBrothersPage.Text == "" && txtThomasBrothersColumn.Text == "" && txtThomasBrothersRow.Text == "")
          {
              btnFind.Enabled = false;
          }
          else if (txtThomasBrothersPage.Text == " " || txtThomasBrothersColumn.Text == " " || txtThomasBrothersRow.Text == " ")        
          {
               btnFind.Enabled = false;
          }
          else if (txtThomasBrothersPage.Text != "" && (txtThomasBrothersColumn.Text != "" ^ txtThomasBrothersRow.Text != ""))
          {
              btnFind.Enabled = false;
          }
          else
          {
              btnFind.Enabled = true;
              txtThomasBrothersColumn.Enabled = true;
              txtThomasBrothersRow.Enabled = true;
          }


        }

        private void ResetTBForm()
        {
            txtThomasBrothersPage.Text = "";
            txtThomasBrothersColumn.Text = "";
            txtThomasBrothersRow.Text = "";
            checkFindEnable();

        }


    }
}
