using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SAPbouiCOM.Framework;

namespace TDS_VDS_ADD_ON
{
    class GRPOAddOn
    {
        public GRPOAddOn()
        {
            Application.SBO_Application.ItemEvent += new SAPbouiCOM._IApplicationEvents_ItemEventEventHandler(SBO_Application_ItemEvent);
           // Application.SBO_Application.FormDataEvent += new SAPbouiCOM._IApplicationEvents_FormDataEventEventHandler(oApplication_FormDataEvent);
        }

        public string formnum = "143";
        public string spos = "30";
        public string epos = "29";
        public string db = "OPDN";

        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            SAPFormHandlerBase.SBO_Application_ItemEvent(FormUID, ref pVal, out BubbleEvent,
                                                      formnum, spos, epos, db);
        }
       
    }
}
