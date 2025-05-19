using SAPbouiCOM.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDS_VDS_ADD_ON
{
    using SAPbouiCOM;
    

    public static class TDSVDSHelper
    {
        public static void CalculateTotalTDSVDS(Form oForm)
        {
            try
            {
                Matrix oMatrix = (Matrix)oForm.Items.Item("38").Specific;

                double totalTDS = 0.0;
                double totalVDS = 0.0;

                for (int i = 1; i <= oMatrix.RowCount; i++)
                {
                    string tdsValStr = ((EditText)oMatrix.Columns.Item("U_TDSAMT").Cells.Item(i).Specific).Value;
                    string vdsValStr = ((EditText)oMatrix.Columns.Item("U_VDSAMT").Cells.Item(i).Specific).Value;

                    if (double.TryParse(tdsValStr, out double tdsRow))
                        totalTDS += tdsRow;

                    if (double.TryParse(vdsValStr, out double vdsRow))
                        totalVDS += vdsRow;
                }

                ((EditText)oForm.Items.Item("ET_TDS").Specific).Value = totalTDS.ToString("F2");
                ((EditText)oForm.Items.Item("ET_VDS").Specific).Value = totalVDS.ToString("F2");
            }
            catch (Exception ex)
            {
                Global.G_UI_Application.SetStatusBarMessage("Error in total TDS/VDS calculation: " + ex.Message, BoMessageTime.bmt_Short, true);
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
