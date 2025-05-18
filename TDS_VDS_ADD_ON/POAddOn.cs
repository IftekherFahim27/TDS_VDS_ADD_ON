using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TDS_VDS_ADD_ON
{
    class POAddOn
    {
        public POAddOn()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
            Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(oApplication_FormDataEvent);
        }

        public bool ItemCFLSelection = false;
       

        

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                if (pVal.FormTypeEx == "142" && pVal.EventType != SAPbouiCOM.BoEventTypes.et_FORM_UNLOAD)
                {
                    //define a form in 3 ways 
                    SAPbouiCOM.Form oform = Application.SBO_Application.Forms.GetFormByTypeAndCount(pVal.FormType, pVal.FormTypeCount);

                    if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_FORM_LOAD && pVal.BeforeAction == true)
                    {
                        //Total TDS Amount

                        SAPbouiCOM.Item StTDS = oform.Items.Add("ST_TDS", SAPbouiCOM.BoFormItemTypes.it_STATIC); // we are going to create
                        SAPbouiCOM.Item osrc = oform.Items.Item("30");
                        StTDS.Top = osrc.Top + 15;
                        StTDS.Height = osrc.Height;
                        StTDS.Width = osrc.Width;
                        StTDS.Left = osrc.Left;


                        //property static field
                        SAPbouiCOM.StaticText ostds = ((SAPbouiCOM.StaticText)(StTDS.Specific));
                        ostds.Caption = "Total TDS";


                        SAPbouiCOM.Item EtTDS = oform.Items.Add("ET_TDS", SAPbouiCOM.BoFormItemTypes.it_EDIT); // we are going to create
                        SAPbouiCOM.Item orsc1 = oform.Items.Item("29");
                        EtTDS.Top = StTDS.Top;
                        EtTDS.Height = orsc1.Height;
                        EtTDS.Width = orsc1.Width;
                        EtTDS.Left = orsc1.Left;

                        //specific property for edit text.
                        SAPbouiCOM.EditText oedtds = (SAPbouiCOM.EditText)(EtTDS.Specific);
                        oedtds.Item.Enabled = false; // to disABLE A FIELD.
                        oedtds.DataBind.SetBound(true, "OPOR", "U_TTDSAMT"); //TO SAVE THE VALUE IN TABLE


                        // Totol VDS Amount
                        SAPbouiCOM.Item StVDS = oform.Items.Add("ST_VDS", SAPbouiCOM.BoFormItemTypes.it_STATIC); // we are going to create
                        SAPbouiCOM.Item osrc2 = oform.Items.Item("ST_TDS");
                        StVDS.Top = osrc2.Top + 15;
                        StVDS.Height = osrc2.Height;
                        StVDS.Width = osrc2.Width;
                        StVDS.Left = osrc2.Left;


                        //property static field
                        SAPbouiCOM.StaticText osvds = ((SAPbouiCOM.StaticText)(StVDS.Specific));
                        osvds.Caption = "Total VDS";


                        SAPbouiCOM.Item EtVDS = oform.Items.Add("ET_VDS", SAPbouiCOM.BoFormItemTypes.it_EDIT); // we are going to create
                        SAPbouiCOM.Item orsc3 = oform.Items.Item("ET_TDS");
                        EtVDS.Top = StVDS.Top;
                        EtVDS.Height = orsc3.Height;
                        EtVDS.Width = orsc3.Width;
                        EtVDS.Left = orsc3.Left;

                        //specific property for edit text.
                        SAPbouiCOM.EditText oedvds = (SAPbouiCOM.EditText)(EtVDS.Specific);
                        oedvds.Item.Enabled = false; // to disABLE A FIELD.
                        oedvds.DataBind.SetBound(true, "OPOR", "U_TVDSAMT"); //TO SAVE THE VALUE IN TABLE


                        // Adding CFL 
                        // === Step 1: Add CFL ===
                        SAPbouiCOM.ChooseFromListCollection oCFLs = oform.ChooseFromLists;
                        SAPbouiCOM.ChooseFromListCreationParams oCFLParams = (SAPbouiCOM.ChooseFromListCreationParams)Application.SBO_Application.CreateObject(SAPbouiCOM.BoCreatableObjectType.cot_ChooseFromListCreationParams);

                        oCFLParams.MultiSelection = false;
                        oCFLParams.ObjectType = "FIL_M_TDSVDSM";  // UDO object type
                        oCFLParams.UniqueID = "CFL_TV";

                        SAPbouiCOM.ChooseFromList oCFL = oCFLs.Add(oCFLParams);

                        // === Step 2: Bind CFL to Matrix Column ===
                        SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oform.Items.Item("38").Specific;
                        SAPbouiCOM.Column oColumn = oMatrix.Columns.Item("U_TVCODE");

                        SAPbouiCOM.Column oColumn1 = oMatrix.Columns.Item("U_TDSAMT");
                        //oColumn1.Editable = true;

                        SAPbouiCOM.Column oColumn2 = oMatrix.Columns.Item("U_VDSAMT");
                        //oColumn2.Editable = true;

                        oColumn.ChooseFromListUID = "CFL_TV";
                        oColumn.ChooseFromListAlias = "Code";  // This must match the field in the UDO

                        Application.SBO_Application.SetStatusBarMessage("CFL successfully added to U_TVCODE", SAPbouiCOM.BoMessageTime.bmt_Short, false);

                    }

                    if (pVal.FormTypeEx == "142" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.BeforeAction == false && pVal.ItemUID == "38" && pVal.ColUID == "U_TVCODE")
                    {
                        if (ItemCFLSelection == true)
                        {
                            try
                            {
                                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;

                                // Get selected row from CFL
                                SAPbouiCOM.ChooseFromListEvent cflEvent = (SAPbouiCOM.ChooseFromListEvent)pVal;
                                SAPbouiCOM.DataTable dt = cflEvent.SelectedObjects;

                                if (dt != null)
                                {
                                    string tvCode = dt.GetValue("Code", 0).ToString();
                                    double  tdsPerc = Convert.ToDouble(dt.GetValue("U_TDSP", 0));
                                    double  vdsPerc = Convert.ToDouble(dt.GetValue("U_VDSP", 0));

                                    int row = pVal.Row;

                                    // Get amount from column 21
                                    SAPbouiCOM.EditText oAmtCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("21").Cells.Item(row).Specific;
                                    string amtStr = oAmtCell.Value.Trim();
                                    string numericValue = amtStr.StartsWith("BDT") ? amtStr.Substring(4).Trim() : amtStr;
                                    double amt = double.TryParse(numericValue, out double parsedAmt) ? parsedAmt : 0.0;


                                    // Calculate TDS and VDS
                                    (double tdsAmt, double vdsAmt) = CalculateTDSVDS(amt, tdsPerc, vdsPerc);

                                    // Set TDSAMT and VDSAMT in matrix (POR1 UDFs)
                                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TDSAMT").Cells.Item(row).Specific).Value = tdsAmt.ToString("F2");
                                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_VDSAMT").Cells.Item(row).Specific).Value = vdsAmt.ToString("F2");
                                    ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TVCODE").Cells.Item(row).Specific).Value = tvCode;


                                    CalculateTotalTDSVDS(oForm);

                                }
                            }

                            catch (Exception ex)
                            {
                                Application.SBO_Application.SetStatusBarMessage("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            }
                        }
                        else
                        {
                            Application.SBO_Application.SetStatusBarMessage("Select Item First " , SAPbouiCOM.BoMessageTime.bmt_Short, true);
                        }
                    }

                    if (pVal.FormTypeEx == "142" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST && pVal.BeforeAction == false && pVal.ItemUID == "38" && pVal.ColUID == "1") 
                    {
                        ItemCFLSelection = true;
                    }

                    if (pVal.FormTypeEx == "142" && pVal.ItemUID == "38" && pVal.EventType == SAPbouiCOM.BoEventTypes.et_LOST_FOCUS && pVal.BeforeAction == false)
                    {
                        if (pVal.ColUID == "11" || pVal.ColUID == "14" || pVal.ColUID == "15") 
                        {

                            try
                            {
                                SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;
                                int row = pVal.Row;
                                SAPbouiCOM.EditText etv = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TVCODE").Cells.Item(row).Specific;
                                string tvCode = etv.Value.Trim();

                                if (!string.IsNullOrWhiteSpace(tvCode)) 
                                { 


                                    // Get updated value of column 21
                                    SAPbouiCOM.EditText oAmtCell = (SAPbouiCOM.EditText)oMatrix.Columns.Item("21").Cells.Item(row).Specific;
                                    string amtStr = oAmtCell.Value.Trim();
                                    string numericValue = amtStr.StartsWith("BDT") ? amtStr.Substring(4).Trim() : amtStr;

                                    double amt = double.TryParse(numericValue, out double parsedAmt) ? parsedAmt : 0.0;

                                   
                                // Calculate TDS and VDS


                                    SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)Global.oComp.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
                                    string qstr = string.Format(@"SELECT U_TDSP, U_VDSP FROM {0}@FIL_MH_TDSVDSM{0} WHERE {0}Code{0} ='" + tvCode + "'", '"');
                                    oRS.DoQuery(qstr);



                                    double tdsPerc = Convert.ToDouble(oRS.Fields.Item("U_TDSP").Value);
                                    double vdsPerc = Convert.ToDouble(oRS.Fields.Item("U_VDSP").Value);



                                   //Calculate TDS VDS
                                   (double tdsAmt, double vdsAmt) = CalculateTDSVDS(amt, tdsPerc, vdsPerc);



                                    SAPbouiCOM.EditText TDS = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TDSAMT").Cells.Item(row).Specific;
                                    TDS.Value = tdsAmt.ToString("F2");

                                    SAPbouiCOM.EditText VDS = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_VDSAMT").Cells.Item(row).Specific;
                                    VDS.Value = vdsAmt.ToString("F2");

                                    CalculateTotalTDSVDS(oForm);


                                }
                            }
                            catch (Exception ex)
                            {
                                Application.SBO_Application.SetStatusBarMessage("Error: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
                            }

                        }
                        if(pVal.ColUID == "U_TVCODE")
                        {
                            SAPbouiCOM.Form oForm = Application.SBO_Application.Forms.Item(pVal.FormUID);
                            SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;
                            int row = pVal.Row;
                            SAPbouiCOM.EditText etv = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TVCODE").Cells.Item(row).Specific;
                            string tvCode = etv.Value.Trim();
                            if (string.IsNullOrWhiteSpace(tvCode))
                            {

                                
                                (double tdsAmt, double vdsAmt) = CalculateTDSVDS(0.0, 0.0, 0.0);

                                SAPbouiCOM.EditText TDS = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TDSAMT").Cells.Item(row).Specific;
                                TDS.Value = tdsAmt.ToString("F2");

                                SAPbouiCOM.EditText VDS = (SAPbouiCOM.EditText)oMatrix.Columns.Item("U_VDSAMT").Cells.Item(row).Specific;
                                VDS.Value = vdsAmt.ToString("F2");

                                CalculateTotalTDSVDS(oForm);
                            }
                        }
                    }


                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED && pVal.BeforeAction == true)
                    {

                    }


                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_KEY_DOWN && pVal.BeforeAction == true)
                    {

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_COMBO_SELECT && pVal.BeforeAction == true)
                    {
                        if (pVal.ItemUID == "btn" && oform.Mode != SAPbouiCOM.BoFormMode.fm_OK_MODE)
                        {

                        }

                    }

                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_COMBO_SELECT && pVal.BeforeAction == false)
                    {

                    }
                    else if (pVal.EventType == SAPbouiCOM.BoEventTypes.et_LOST_FOCUS && pVal.BeforeAction == false)
                    {




                    }
                }

            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in Itemevnt for SAP Screen - " + ex.ToString(), SAPbouiCOM.BoMessageTime.bmt_Medium, true);
            }
        }

        private static void oApplication_FormDataEvent(ref SAPbouiCOM.BusinessObjectInfo BusinessObjectInfo, out bool BubbleEvent)
        {
            BubbleEvent = true;
            if (BusinessObjectInfo.BeforeAction == true && BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_ADD)
            {
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "196":
                        {
                            //logic
                            //to get a data from grid
                            //insert query or use di api service to insert into udo as defaultform or non udo

                            break;
                        }
                }
            }
            else if (BusinessObjectInfo.BeforeAction == false && BusinessObjectInfo.EventType == SAPbouiCOM.BoEventTypes.et_FORM_DATA_LOAD)
            {
                switch (BusinessObjectInfo.FormTypeEx)
                {
                    case "196":
                        {
                            //logic
                            //to get with udo or non objective table where sales order number exist or not
                            //if so no is exist then execute a query and pass the values to grid.


                            break;
                        }
                }
            }
        }


        public void CalculateTotalTDSVDS(SAPbouiCOM.Form oForm)
        {
            try
            {
                SAPbouiCOM.Matrix oMatrix = (SAPbouiCOM.Matrix)oForm.Items.Item("38").Specific;

                double totalTDS = 0.0;
                double totalVDS = 0.0;

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string tdsValStr = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_TDSAMT").Cells.Item(i).Specific).Value;
                    string vdsValStr = ((SAPbouiCOM.EditText)oMatrix.Columns.Item("U_VDSAMT").Cells.Item(i).Specific).Value;

                    if (double.TryParse(tdsValStr, out double tdsRow))
                        totalTDS += tdsRow;

                    if (double.TryParse(vdsValStr, out double vdsRow))
                        totalVDS += vdsRow;
                }

                ((SAPbouiCOM.EditText)oForm.Items.Item("ET_TDS").Specific).Value = totalTDS.ToString("F2");
                ((SAPbouiCOM.EditText)oForm.Items.Item("ET_VDS").Specific).Value = totalVDS.ToString("F2");
            }
            catch (Exception ex)
            {
                Application.SBO_Application.SetStatusBarMessage("Error in total TDS/VDS calculation: " + ex.Message, SAPbouiCOM.BoMessageTime.bmt_Short, true);
            }
        }


        public static (double tdsAmt, double vdsAmt) CalculateTDSVDS(double amount, double tdsPerc, double vdsPerc)
        {
            double vdsAmt = amount * vdsPerc / 100;
            double famt = amount - vdsAmt;
            double tdsAmt = famt * tdsPerc / 100;

            return (tdsAmt, vdsAmt);
        }





    }
}
