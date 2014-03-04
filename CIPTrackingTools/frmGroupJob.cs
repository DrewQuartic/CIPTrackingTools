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
    public partial class frmGroupJob : Form
    {
        public frmGroupJob()
        {
            InitializeComponent();
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmdFind_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Run_FindGroupJobByName(txtCipName.Text);
            //added by rob to modularize code
            commonsubs comSub = new commonsubs();
            comSub.FindByString("TITLE = '" + txtCipName.Text + "'", "Project Title");
            this.Cursor = Cursors.Default;
            this.Close();
        }

        //private void Run_FindGroupJobByName(string p)
        //{
        //    commonsubs comSub = new commonsubs();
        //    IMxDocument pMxDoc = ArcMap.Document;
        //    IMap pMap = pMxDoc.FocusMap;
        //    IFeatureLayer pFL;
        //    int selcount = 0;
        //    IEnvelope pEnvelope = new EnvelopeClass();
        //    pEnvelope.SetEmpty();
        //    ILayer player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_LINE");
        //    if (player != null)
        //    {
        //        pFL = player as IFeatureLayer;
        //        selcount = comSub.SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, "TITLE = '" + txtCipName.Text + "'");
        //        if (selcount > 0)
        //        {
        //            comSub.zoomtoselected(player, pEnvelope);
        //            System.Diagnostics.Debug.WriteLine(player.Name);
        //        }
        //    }

        //    player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POINT");
        //    if (player != null)
        //    {
        //        pFL = player as IFeatureLayer;
        //        selcount = comSub.SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, "TITLE = '" + txtCipName.Text + "'");
        //        if (selcount > 0)
        //        {
        //            comSub.zoomtoselected(player, pEnvelope);
        //        }
        //    }


        //    player = comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POLY");
        //    if (player != null)
        //    {
        //        pFL = player as IFeatureLayer;
        //        selcount = comSub.SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, "TITLE = '" + txtCipName.Text + "'");
        //        if (selcount > 0)
        //        {                  
        //            comSub.zoomtoselected(player, pEnvelope);
        //        }
        //    }
        //    else
        //    {
        //        MessageBox.Show("Cannot find the ProjectID Please make sure that you have entered a correct value and that the CIP layers are in the .mxd");
        //    }


        //    this.Close();
        //}
    }
}
