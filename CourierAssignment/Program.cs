using Syncfusion.Windows.Forms;
using Syncfusion.WinForms.Controls;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Windows.Forms;

namespace Order_Processing
{
    static class Program
    {
        public static string ConnectionString { get; set; }
        public static List<CUSTOM_ORDER_COURIER_CONFIG> CourierConfigurations { get; set; }
        public static List<CUSTOM_ORDER_COURIER> CourierList { get; set; }
        public static List<CUSTOM_ORDER_PICKUP_LOCATION> PickUpLocations { get; set; }
        public static List<CUSTOM_ORDER_CITY> FullCityList { get; set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>

        static System.Threading.Mutex mutex = null;
        [STAThread]
        static void Main()
        {
            try
            {
                var exeName = ConfigurationManager.AppSettings["BrandName"].ToString();

                mutex = new System.Threading.Mutex(true, exeName, out bool createdNew);
                if (createdNew)
                {
                    Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MzY3NTcyNEAzMjM4MmUzMDJlMzBLOWNTUmgrUUROOHBNbytGdjloa294emhzUUZzNEg1UjFLcFlyN3lkUHdBPQ==");
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new DataGrid1());
                }
            }
            catch (Exception ex)
            {
                File.AppendAllText(Application.StartupPath + "\\log.txt", ex.Message);
            }
        }
    }
}
