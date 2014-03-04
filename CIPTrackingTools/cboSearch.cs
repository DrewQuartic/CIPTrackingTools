using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;
using ESRI.ArcGIS.SystemUI;
using ESRI.ArcGIS.Framework;
using ESRI.ArcGIS.Desktop.AddIns;
using ESRI.ArcGIS.ArcMapUI;
using ESRI.ArcGIS.Carto;
using ESRI.ArcGIS.Geodatabase;

namespace CIPTrackingTools
{
    public class cboSearch : ESRI.ArcGIS.Desktop.AddIns.ComboBox
    {
        private static cboSearch s_comboBox;
        private int m_selAllCookie;
 
        public cboSearch()
        {
            int cookie; 
            cookie = this.Add("ECP Project Title");
            cookie = this.Add("ECP Project Number");
            cookie = this.Add("Fieldbook Page");
            cookie = this.Add("Thomas Brothers Page");
            m_selAllCookie = -1;
            s_comboBox = this;
               
        }

        protected override void OnUpdate()
        {
            Enabled = ArcMap.Application != null;
        }

        protected override void OnSelChange(int cookie)
        {
            //Look for the layers needed for each search.
            //Needs to be run on each selection change in case layers are loaded after mxd loads
            //broken out into each layer boolean so that code can be added to physically add the specific layer later
            commonsubs comSub = new commonsubs();
            IMxDocument pMxDoc = ArcMap.Document;
            IMap pMap = pMxDoc.FocusMap; 
            bool CIPPointLayer = false;
            bool CIPLineLayer =  false;
            bool CIPPolyLayer =  false;
            bool FieldBookLayer =  false;
            bool TBPageLayer =  false;
            bool TBTileLayer =  false;

           if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POINT") != null)
               CIPPointLayer = true;
            if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_LINE") != null)
               CIPLineLayer = true;
             if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POLY") != null)
               CIPPolyLayer = true;
            if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_SANGIS") != null)
               FieldBookLayer = true;
            if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_PAGE_TB")!= null)
               TBPageLayer = true;
            if (comSub.LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.GRID_TILE_TB") != null)
               TBTileLayer = true;

            //string strSelected = null;
            foreach (ComboBox.Item item in this.items)
            {
                //Debug.WriteLine(cookie.ToString() + "  " + item.Tag);
                if (item.Cookie == cookie)
                {
                    //strSelected = item.Caption;
                    switch (item.Caption)
                    {
                        case "ECP Project Title":
                            {
                                if (!CIPLineLayer || !CIPPointLayer || !CIPPolyLayer)
                                {
                                   System.Windows.Forms.MessageBox.Show("The CIP Point, Line, or Polygon Layer is missing from the TOC, Please add it to use this search");
                                }
                                else
                                {
                                    frmGroupJob frmgroupJob = new frmGroupJob();
                                    frmgroupJob.TopMost = true;
                                    frmgroupJob.Show();
                                }
                                break;
                            }
                        case "ECP Project Number":
                            {
                                if (!CIPLineLayer || !CIPPointLayer || !CIPPolyLayer)
                                {
                                   System.Windows.Forms.MessageBox.Show("The CIP Point, Line, or Polygon Layer is missing from the TOC, Please add it to use this search");
                                }
                                else
                                {                        
                                    frmCipNumber frmNum = new frmCipNumber();
                                    frmNum.TopMost = true;
                                    frmNum.Show();
                                }
                                break;
                            }
                        case "Fieldbook Page":
                            {
                                if (!FieldBookLayer)
                                {
                                   System.Windows.Forms.MessageBox.Show("The Field Book Layer is missing from the TOC, Please add it to use this search");
                                }
                                else
                                {
                                    frmFieldBook frmFld = new frmFieldBook();
                                    frmFld.TopMost = true;
                                    frmFld.Show();
                               }
                                break;
                            }
                        case "Thomas Brothers Page":
                            {
                                if (!TBPageLayer || !TBTileLayer)
                                {
                                    System.Windows.Forms.MessageBox.Show("The Thomas Brothers Page or Tile Layer is missing from the TOC, Please add it to use this search");
                                }
                                else
                                {
                                    frmThomasBrothers frmTB = new frmThomasBrothers();
                                    frmTB.TopMost = true;
                                    frmTB.Show();
                                }
                                break;
                            }

                    }
                }
            }


            //MessageBox.Show(cookie.ToString(), "Message", MessageBoxButtons.YesNoCancel);
        }
        

    }

}
