using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace ControladorGRD.Entities
{
    static class ClassPage
    {
        public static DataTable sqlDataTable = new DataTable();
        public static int TotalRec; //Variable for getting Total Records of the Table
        public static int NRPP; //Variable for Setting the Number of Recrods per listiview page
        public static int Page; //List View Page for Navigate or move
        public static int TotalPages; //Varibale for Counting Total Pages.
        public static int RecStart; //Variable for Getting Every Page Starting Record Index
        public static int RecEnd; //Variable for Getting Every Page End Record Index

        public static void DadosListView(DataTable dt, ListView lista)
        {

            int l, k;

            DataTableReader reader = new DataTableReader(dt);

            lista.Items.Clear();

            TotalRec = dt.Rows.Count;

            try
            {
                TotalPages = TotalRec / NRPP;

                if (TotalRec % NRPP > 0)
                {
                    TotalPages++;
                }
            }
            catch (DivideByZeroException e)
            {
                MessageBox.Show(e.Message);
            }

            l = (Page - 1) * NRPP;
            k = Page * NRPP;

            RecStart = l + 1;

            if (k > TotalRec)
            {
                RecEnd = TotalRec;
            }
            else
            {
                RecEnd = k;
            }

            for (; l < k; l++)
            {
                if (l >= TotalRec)
                {
                    break;
                }

                    string[] row = {
                        dt.Rows[l].ItemArray[0].ToString().Substring(0, 10),
                        dt.Rows[l].ItemArray[1].ToString(),
                        dt.Rows[l].ItemArray[2].ToString(),
                        dt.Rows[l].ItemArray[3].ToString(),
                        dt.Rows[l].ItemArray[4].ToString(),
                        dt.Rows[l].ItemArray[5].ToString()
                    };
                    var linha_list = new ListViewItem(row);
                    lista.Items.Add(linha_list);
               
            }
        }
    }
}
