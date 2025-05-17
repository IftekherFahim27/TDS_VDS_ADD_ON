using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDS_VDS_ADD_ON
{
    class ApInvoiceAddOn
    {
        public ApInvoiceAddOn()
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
