﻿using SAPbouiCOM.Framework;                 
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
           
        }


        public string formnum = "141";
        public string spos = "34";
        public string epos = "33";
        public string db = "OPCH";
        private void SBO_Application_ItemEvent(string FormUID, ref SAPbouiCOM.ItemEvent pVal, out bool BubbleEvent)
        {
            SAPFormHandlerBase.SBO_Application_ItemEvent(FormUID, ref pVal, out BubbleEvent,
                                                      formnum, spos, epos, db);
        }
           
    }
}
