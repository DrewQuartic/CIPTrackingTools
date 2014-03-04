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
using ESRI.ArcGIS.Geodatabase;
using ESRI.ArcGIS.Geometry;

namespace CIPTrackingTools
{
    public partial class frmFieldBook : Form
    {
        public frmFieldBook()
        {
            InitializeComponent();
        }

        private void frmFieldBook_Load(object sender, EventArgs e)
        {
            cboQuardrant.Items.Add("All");
            cboQuardrant.Items.Add("A");
            cboQuardrant.Items.Add("B");
            cboQuardrant.Items.Add("C");
            cboQuardrant.Items.Add("D");
            cboQuardrant.SelectedIndex = 0;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            commonsubs comSub = new commonsubs();
            IMxDocument pMxDoc = ArcMap.Document;
            IMap pMap = pMxDoc.FocusMap;
            IFeatureLayer pFL;
            int selcount = 0;
            IEnvelope pEnvelope = new EnvelopeClass();
            pEnvelope.SetEmpty();
            ILayer player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_SANGIS");
            if (player != null)
            {
                pFL = player as IFeatureLayer;
                selcount = comSub.SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, "FLD_BK_PG = '" + txtFBP.Text.ToUpper() + "'");
                if (selcount > 0)
                {
                    comSub.zoomtoselected(player, pEnvelope,cboQuardrant.Text);
                    System.Diagnostics.Debug.WriteLine(player.Name);


                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
