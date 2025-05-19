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
        }

        public string formnum = "142";
        public string spos = "30";
        public string epos = "29";
        public string db = "OPOR";


        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            SAPFormHandlerBase.SBO_Application_ItemEvent(FormUID, ref pVal, out BubbleEvent,
                                                      formnum, spos, epos, db);

        }





    }
}
