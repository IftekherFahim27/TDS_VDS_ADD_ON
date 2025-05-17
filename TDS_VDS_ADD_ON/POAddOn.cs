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


    }
}
