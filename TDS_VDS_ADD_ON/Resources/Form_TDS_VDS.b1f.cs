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
            this.Button1 = ((SAPbouiCOM.Button)(this.GetItem("2").Specific));
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
    }
}
