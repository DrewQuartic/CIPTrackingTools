using ESRI.ArcGIS.GlobeCore;
using ESRI.ArcGIS.Analyst3D;
using ESRI.ArcGIS.Geometry;
using ESRI.ArcGIS.esriSystem;
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
using System.Diagnostics;

namespace CIPTrackingTools
{
    class commonsubs
    {
        #region "Loop Through Layers of Specific UID"
        // ArcGIS Snippet Title:
        // Loop Through Layers of Specific UID
        // 
        // Long Description:
        // Stub code to loop through layers in a map where a specific UID is supplied.
        // 

        ///<summary>Stub code to loop through layers in a map where a specific UID is supplied.</summary>
        ///
        ///<param name="map">An IMap interface in which the layers reside.</param>
        ///<param name="layerCLSID">A System.String that is the layer GUID type. For example: "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" is the IGeoFeatureLayer.</param>
        /// 
        ///<remarks>In order of the code to be useful the user needs to write their own code to use the layer in the TODO section.
        ///
        /// The different layer GUID's and Interface's are:
        /// "{AD88322D-533D-4E36-A5C9-1B109AF7A346}" = IACFeatureLayer
        /// "{74E45211-DFE6-11D3-9FF7-00C04F6BC6A5}" = IACLayer
        /// "{495C0E2C-D51D-4ED4-9FC1-FA04AB93568D}" = IACImageLayer
        /// "{65BD02AC-1CAD-462A-A524-3F17E9D85432}" = IACAcetateLayer
        /// "{4AEDC069-B599-424B-A374-49602ABAD308}" = IAnnotationLayer
        /// "{DBCA59AC-6771-4408-8F48-C7D53389440C}" = IAnnotationSublayer
        /// "{E299ADBC-A5C3-11D2-9B10-00C04FA33299}" = ICadLayer
        /// "{7F1AB670-5CA9-44D1-B42D-12AA868FC757}" = ICadastralFabricLayer
        /// "{BA119BC4-939A-11D2-A2F4-080009B6F22B}" = ICompositeLayer
        /// "{9646BB82-9512-11D2-A2F6-080009B6F22B}" = ICompositeGraphicsLayer
        /// "{0C22A4C7-DAFD-11D2-9F46-00C04F6BC78E}" = ICoverageAnnotationLayer
        /// "{6CA416B1-E160-11D2-9F4E-00C04F6BC78E}" = IDataLayer
        /// "{0737082E-958E-11D4-80ED-00C04F601565}" = IDimensionLayer
        /// "{48E56B3F-EC3A-11D2-9F5C-00C04F6BC6A5}" = IFDOGraphicsLayer
        /// "{40A9E885-5533-11D0-98BE-00805F7CED21}" = IFeatureLayer
        /// "{605BC37A-15E9-40A0-90FB-DE4CC376838C}" = IGdbRasterCatalogLayer
        /// "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" = IGeoFeatureLayer
        /// "{34B2EF81-F4AC-11D1-A245-080009B6F22B}" = IGraphicsLayer
        /// "{EDAD6644-1810-11D1-86AE-0000F8751720}" = IGroupLayer
        /// "{D090AA89-C2F1-11D3-9FEF-00C04F6BC6A5}" = IIMSSubLayer
        /// "{DC8505FF-D521-11D3-9FF4-00C04F6BC6A5}" = IIMAMapLayer
        /// "{34C20002-4D3C-11D0-92D8-00805F7C28B0}" = ILayer
        /// "{E9B56157-7EB7-4DB3-9958-AFBF3B5E1470}" = IMapServerLayer
        /// "{B059B902-5C7A-4287-982E-EF0BC77C6AAB}" = IMapServerSublayer
        /// "{82870538-E09E-42C0-9228-CBCB244B91BA}" = INetworkLayer
        /// "{D02371C7-35F7-11D2-B1F2-00C04F8EDEFF}" = IRasterLayer
        /// "{AF9930F0-F61E-11D3-8D6C-00C04F5B87B2}" = IRasterCatalogLayer
        /// "{FCEFF094-8E6A-4972-9BB4-429C71B07289}" = ITemporaryLayer
        /// "{5A0F220D-614F-4C72-AFF2-7EA0BE2C8513}" = ITerrainLayer
        /// "{FE308F36-BDCA-11D1-A523-0000F8774F0F}" = ITinLayer
        /// "{FB6337E3-610A-4BC2-9142-760D954C22EB}" = ITopologyLayer
        /// "{005F592A-327B-44A4-AEEB-409D2F866F47}" = IWMSLayer
        /// "{D43D9A73-FF6C-4A19-B36A-D7ECBE61962A}" = IWMSGroupLayer
        /// "{8C19B114-1168-41A3-9E14-FC30CA5A4E9D}" = IWMSMapLayer
        ///</remarks>
        public ILayer LoopThroughLayersOfSpecificUID(IMap map, String layerCLSID, string LayerName)
        {
            ILayer myLayer;
            myLayer = null;
            ESRI.ArcGIS.esriSystem.UID uid = new UIDClass();
            //ESRI.ArcGIS.esriIUID uid = new ESRI.ArcGIS.esriUIDClass();
            uid.Value = layerCLSID; // Example: "{E156D7E5-22AF-11D3-9F99-00C04F6BC78E}" = IGeoFeatureLayer
            try
            {

                IEnumLayer enumLayer = map.get_Layers(((ESRI.ArcGIS.esriSystem.UID)(uid)), true); // Explicit Cast 
                enumLayer.Reset();
                ILayer layer;
                while ((layer = enumLayer.Next()) != null)
                {
                    IFeatureLayer2 pFL = layer as IFeatureLayer2;
                    IDataset pDS = pFL.FeatureClass as IDataset;
                    if (pDS != null)
                    {
                        if (pDS.Name == LayerName)
                        {
                            myLayer = layer;
                            break;
                        }
                    }

                    ////if (pFL != null)
                    ////{
                    ////    IQueryFilter pQF = new QueryFilter();
                    ////    pQF.WhereClause = "CIP_ID =" + txtCipNumber.Text;
                    ////    //IFeatureCursor pFCur =  pFL.Search(pQF,true);

                    ////    IDataset pDS = pFL.FeatureClass as IDataset;

                    ////    ISelectionSet pSS = pFL.FeatureClass.Select (pQF,esriSelectionType.esriSelectionTypeHybrid,esriSelectionOption.esriSelectionOptionNormal, pDS.Workspace);
                    ////    IMxDocument pMxDoc = ArcMap.Document;
                    ////    IMap pMap = pMxDoc.FocusMap;

                    ////    if (pDS != null)
                    ////    {
                    ////        IEnumDataset pEnumDS = pDS.Workspace.get_Datasets(esriDatasetType.esriDTFeatureClass);
                    ////        IFeatureClass pDS2 = pEnumDS.Next() as IFeatureClass;
                    ////        while (pDS2 != null)
                    ////        {
                    ////            if (pDS2.AliasName == "SANGIS.CIP_LINE" || pDS2.AliasName == "SANGIS.CIP_POINT" || pDS2.AliasName == "SANGIS.CIP_POLY") 
                    ////            {
                    ////                IQueryFilter pQF = new QueryFilter();
                    ////                pQF.WhereClause = "CIP_ID =" + txtCipNumber.Text;
                    ////                IFeatureCursor pFCur =  pDS2.Search(pQF,true);
                    ////                IFeature pFeat =  pFCur.NextFeature();


                    ////            }
                    ////        }
                    ////    }


                    //}

                    //if (myLayer.Fe ==  typeof(IFeatureClass))
                    //{

                    //    IFeatureClass pFC =(IFeatureClass) myLayer;
                    //    if (pFC.FeatureDataset.Workspace.WorkspaceFactory.WorkspaceType == esriWorkspaceType.esriRemoteDatabaseWorkspace)
                    //    {
                    //        IRemoteDatabaseWorkspaceFactory pRDWF = (IRemoteDatabaseWorkspaceFactory) pFC.FeatureDataset.Workspace.WorkspaceFactory;

                    //    }


                }

                return myLayer;
            }
            catch (Exception ex)
            {
                //Windows.Forms.MessageBox.Show("No layers of type: " + uid.Value.ToString);
                return myLayer;
            }
            finally
            {

            }
        }
        #endregion



        #region "Select Map Features by Attribute Query"
        // ArcGIS Snippet Title:
        // Select Map Features by Attribute Query
        // 
        // Long Description:
        // Select features in the IActiveView by an attribute query using a SQL syntax in a where clause.
        // 

        ///<summary>Select features in the IActiveView by an attribute query using a SQL syntax in a where clause.</summary>
        /// 
        ///<param name="activeView">An IActiveView interface</param>
        ///<param name="featureLayer">An IFeatureLayer interface to select upon</param>
        ///<param name="whereClause">A System.String that is the SQL where clause syntax to select features. Example: "CityName = 'Redlands'"</param>
        ///  
        ///<remarks>Providing and empty string "" will return all records.</remarks>
        public int SelectMapFeaturesByAttributeQuery(IActiveView activeView, IFeatureLayer featureLayer, System.String whereClause)
        {
            if (activeView == null || featureLayer == null || whereClause == null)
            {
                return 0;
            }
            IFeatureSelection featureSelection = featureLayer as IFeatureSelection; // Dynamic Cast

            // Set up the query
            IQueryFilter queryFilter = new QueryFilterClass();
            queryFilter.WhereClause = whereClause;

            // Invalidate only the selection cache. Flag the original selection
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);

            // Perform the selection
            featureSelection.SelectFeatures(queryFilter, esriSelectionResultEnum.esriSelectionResultNew, false);


            // Flag the new selection
            activeView.PartialRefresh(esriViewDrawPhase.esriViewGeoSelection, null, null);
            return featureSelection.SelectionSet.Count;
        }
        #endregion

        #region "Zoom to Selected"

        public void zoomtoselected(ILayer player, IEnvelope envelope, string Quadrant = "All" )
        {
            //IFeatureLayer featureLayer = (IFeatureLayer)player; // Explicit Cast
            IFeatureSelection featureSelection = (IFeatureSelection)player; // Explicit Cast
            IFeatureLayer pFL = player as IFeatureLayer;
            ISelectionSet selectionSet = featureSelection.SelectionSet;
            IFeatureClass featureClass = pFL.FeatureClass;
            String shapeField = featureClass.ShapeFieldName;
            //IEnvelope envelope = new EnvelopeClass();
            //envelope.SetEmpty();
            ISpatialFilter spatialFilter = new SpatialFilterClass();
            spatialFilter.GeometryField = shapeField;
            //spatialFilter.set_OutputSpatialReference(shapeField, spatialReference);

            // The next 2 lines of code are different from many other ArcObjects programming techniques in that the 
            // ICursor Interface variable 'cursor' is initialized to a Null value. It is set by reference with the 
            // call to the Search method; hence the need for the 'out' argument (see MSDN for more information).
            ICursor cursor;
            selectionSet.Search(spatialFilter, true, out cursor);

            IFeatureCursor featureCursor = (IFeatureCursor)cursor; // Explicit Cast


            IFeature feature;  // Automatically initialized to null. Used to test existence of a feature in the featureCursor
            while ((feature = featureCursor.NextFeature()) != null)
            {
                IGeometry geometry = feature.Shape;
                IEnvelope featureEnv = geometry.Envelope;
                //added by Rob to handle point geometry which doesn't work well with envelopes
                if (feature.Shape.GeometryType == esriGeometryType.esriGeometryPoint)
                {
                    featureEnv.Expand(2, 2, false);
                }
                if (Quadrant == "All")
                {
                    envelope.Union(featureEnv);
                }
                else
                {
                        double minX;
                        double minY;
                        double maxX;
                        double maxY;
                        featureEnv.QueryCoords(out minX, out minY, out maxX, out maxY);
                        double dXmed = (minX + maxX) / 2;
                        double dYmed = (minY + maxY) / 2;
                        envelope.Union(featureEnv);
                    switch (Quadrant)
                    {
                        case "A":
                            {
                                envelope.XMax = dXmed;
                                envelope.YMin = dYmed;
                                //envelope.YMax = maxY;
                                //envelope.XMin = minX;
                                break;
                            }
                        case "B":
                            {
                                envelope.XMin = dXmed;
                                envelope.YMin = dYmed;
                                break;
                            }
                        case "C":
                            {
                                envelope.XMax = dXmed;
                                envelope.YMax = dYmed;
                                break;
                            }
                        case "D":
                            {
                                envelope.XMin = dXmed;
                                envelope.YMax = dYmed;
                                break;
                            }
                    }
                }
                
            }
            IMxDocument pMxDoc = ArcMap.Document;
            pMxDoc.ActiveView.Extent = envelope;
            pMxDoc.ActiveView.Refresh();
        }
        #endregion


        #region "Find Projects"

        public void FindByString(string input, string msgtype)
        {
            //commonsubs comSub = new commonsubs();
            IMxDocument pMxDoc = ArcMap.Document;
            IMap pMap = pMxDoc.FocusMap;
            IFeatureLayer pFL;
            int selcount = 0;
            //added by rob to get total selection as selcount gets reset
            int allselcount = 0;
            IEnvelope pEnvelope = new EnvelopeClass();
            pEnvelope.SetEmpty();
            ILayer player = LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_LINE");
            if (player != null)
            {
                pFL = player as IFeatureLayer;
                selcount = SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, input);
                if (selcount > 0)
                {
                    allselcount = allselcount + selcount;
                    zoomtoselected(player, pEnvelope);
                    System.Diagnostics.Debug.WriteLine(player.Name);
                }
            }

            player = LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POINT");
            if (player != null)
            {
                pFL = player as IFeatureLayer;
                selcount = SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, input);
                if (selcount > 0)
                {
                    allselcount = allselcount + selcount;
                    zoomtoselected(player, pEnvelope);
                }
            }


            player = LoopThroughLayersOfSpecificUID(pMap, "{40A9E885-5533-11D0-98BE-00805F7CED21}", "SANGIS.CIP_POLY");
            if (player != null)
            {
                pFL = player as IFeatureLayer;
                selcount = SelectMapFeaturesByAttributeQuery(pMxDoc.ActiveView, pFL, input);
                if (selcount > 0)
                {
                    allselcount = allselcount + selcount;
                    zoomtoselected(player, pEnvelope);
                }
            }

            //added by rob to check the all selected count if none ever found
            //else
            if (allselcount == 0)
            {
                MessageBox.Show("Cannot find the " + msgtype + " Please make sure that you have entered a correct value and that the CIP layers are in the .mxd");
            }

        }

        #endregion


    }
}
