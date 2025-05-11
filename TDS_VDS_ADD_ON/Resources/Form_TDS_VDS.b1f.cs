using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TDS_VDS_ADD_ON.Resources
{
    [FormAttribute("TDS_VDS_ADD_ON.Resources.Form_TDS_VDS", "Resources/Form_TDS_VDS.b1f")]
    class Form_TDS_VDS : UserFormBase
    {
        public Form_TDS_VDS()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.StaticText0 = ((SAPbouiCOM.StaticText)(this.GetItem("STTCODE").Specific));
            this.StaticText1 = ((SAPbouiCOM.StaticText)(this.GetItem("STTDESC").Specific));
            this.StaticText2 = ((SAPbouiCOM.StaticText)(this.GetItem("STTDS").Specific));
            this.StaticText3 = ((SAPbouiCOM.StaticText)(this.GetItem("STVDS").Specific));
            this.StaticText4 = ((SAPbouiCOM.StaticText)(this.GetItem("STTDSGL").Specific));
            this.StaticText5 = ((SAPbouiCOM.StaticText)(this.GetItem("STVDSGL").Specific));
            this.StaticText6 = ((SAPbouiCOM.StaticText)(this.GetItem("STEFDAT").Specific));
            this.StaticText7 = ((SAPbouiCOM.StaticText)(this.GetItem("STETDAT").Specific));
            this.StaticText8 = ((SAPbouiCOM.StaticText)(this.GetItem("STSEC").Specific));
            this.StaticText9 = ((SAPbouiCOM.StaticText)(this.GetItem("STTYPE").Specific));
            this.StaticText10 = ((SAPbouiCOM.StaticText)(this.GetItem("STACT").Specific));
            this.EditText0 = ((SAPbouiCOM.EditText)(this.GetItem("ETTCODE").Specific));
            this.EditText1 = ((SAPbouiCOM.EditText)(this.GetItem("ETTDESC").Specific));
            this.EditText2 = ((SAPbouiCOM.EditText)(this.GetItem("ETTDS").Specific));
            this.EditText3 = ((SAPbouiCOM.EditText)(this.GetItem("ETVDS").Specific));
            this.EditText4 = ((SAPbouiCOM.EditText)(this.GetItem("ETTDSGL").Specific));
            this.EditText5 = ((SAPbouiCOM.EditText)(this.GetItem("ETVDSGL").Specific));
            this.EditText6 = ((SAPbouiCOM.EditText)(this.GetItem("ETEFDAT").Specific));
            this.EditText7 = ((SAPbouiCOM.EditText)(this.GetItem("ETETDAT").Specific));
            this.EditText8 = ((SAPbouiCOM.EditText)(this.GetItem("ETSEC").Specific));
            this.CheckBox0 = ((SAPbouiCOM.CheckBox)(this.GetItem("CHKACT").Specific));
            this.ComboBox0 = ((SAPbouiCOM.ComboBox)(this.GetItem("COMBTYPE").Specific));
            this.Button0 = ((SAPbouiCOM.Button)(this.GetItem("1").Specific));
            this.Button0.PressedBefore += new SAPbouiCOM._IButtonEvents_PressedBeforeEventHandler(this.Button0_PressedBefore);
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
            this.EditText9 = ((SAPbouiCOM.EditText)(this.GetItem("ETDOCTRY").Specific));
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private SAPbouiCOM.StaticText StaticText0;

        private void OnCustomInitialize()
        {

        }

        private SAPbouiCOM.StaticText StaticText1;
        private SAPbouiCOM.StaticText StaticText2;
        private SAPbouiCOM.StaticText StaticText3;
        private SAPbouiCOM.StaticText StaticText4;
        private SAPbouiCOM.StaticText StaticText5;
        private SAPbouiCOM.StaticText StaticText6;
        private SAPbouiCOM.StaticText StaticText7;
        private SAPbouiCOM.StaticText StaticText8;
        private SAPbouiCOM.StaticText StaticText9;
        private SAPbouiCOM.StaticText StaticText10;
        private SAPbouiCOM.EditText EditText0;
        private SAPbouiCOM.EditText EditText1;
        private SAPbouiCOM.EditText EditText2;
        private SAPbouiCOM.EditText EditText3;
        private SAPbouiCOM.EditText EditText4;
        private SAPbouiCOM.EditText EditText5;
        private SAPbouiCOM.EditText EditText6;
        private SAPbouiCOM.EditText EditText7;
        private SAPbouiCOM.EditText EditText8;
        private SAPbouiCOM.CheckBox CheckBox0;
        private SAPbouiCOM.ComboBox ComboBox0;
        private SAPbouiCOM.Button Button0;
        private SAPbouiCOM.Button Button1;
        private SAPbouiCOM.EditText EditText9;

        private void Button0_PressedBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            SAPbouiCOM.Form oform = Application.SBO_Application.Forms.Item(pVal.FormUID);
            if (oform.Mode == SAPbouiCOM.BoFormMode.fm_ADD_MODE || oform.Mode == SAPbouiCOM.BoFormMode.fm_UPDATE_MODE)
            {
                ValidateForm(ref oform, ref BubbleEvent);
            }

        }

        private bool ValidateForm(ref SAPbouiCOM.Form pForm, ref bool BubbleEvent)
        {
            string Code  = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("Code", 0);
            string Desc  = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_TAXDESC", 0);
            string TDS   = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_TDSP", 0);
            string VDS   = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_VDSP", 0);
            string TDSGL = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_TDSGL", 0);
            string VDSGL = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_VDSGL", 0);
            string efd   = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_EFRMDATE", 0);
            string etd   = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_ETODATE", 0);
            string sec   = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_TSECTION", 0);
            string type  = pForm.DataSources.DBDataSources.Item("@FIL_MH_TDSVDSM").GetValue("U_TYPE", 0);

            if (Code == "")
            {
                Global.GFunc.ShowError("Enter Tax Code");
                pForm.ActiveItem = "ETTCODE";
                return BubbleEvent = false;
            }
            else if (Desc == "")
            {
                Global.GFunc.ShowError("Enter Tax Description");
                pForm.ActiveItem = "ETTDESC";
                return BubbleEvent = false;
            }
            else if (TDS == "")
            {
                Global.GFunc.ShowError("Enter TDS");
                pForm.ActiveItem = "ETTDS";
                return BubbleEvent = false;
            }
            else if (VDS == "")
            {
                Global.GFunc.ShowError("Enter VDS");
                pForm.ActiveItem = "ETVDS";
                return BubbleEvent = false;
            }
            else if (TDSGL == "")
            {
                Global.GFunc.ShowError("Enter TDSGL");
                pForm.ActiveItem = "ETTDSGL";
                return BubbleEvent = false;
            }
            else if (VDSGL == "")
            {
                Global.GFunc.ShowError("Enter VDSGL");
                pForm.ActiveItem = "ETVDSGL";
                return BubbleEvent = false;
            }
            else if (efd == "")
            {
                Global.GFunc.ShowError("Enter Effective From Date ");
                pForm.ActiveItem = "ETEFDAT";
                return BubbleEvent = false;
            }
            else if (etd == "")
            {
                Global.GFunc.ShowError("Enter Effective To Date");
                pForm.ActiveItem = "ETETDAT";
                return BubbleEvent = false;
            }
            else if (sec == "")
            {
                Global.GFunc.ShowError("Enter Section ");
                pForm.ActiveItem = "ETTDESC";
                return BubbleEvent = false;
            }
            else if (type == "")
            {
                Global.GFunc.ShowError("Select The TYPE");
                pForm.ActiveItem = "COMBTYPE";
                return BubbleEvent = false;
            }
            return BubbleEvent;
        }
    }
}
