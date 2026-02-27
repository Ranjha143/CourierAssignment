using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Order_Processing
{

    public partial class CUSTOM_ORDER_COURIER_CONFIG
    {
        public decimal ROW_ID { get; set; }
        public Nullable<int> COURIER_ID { get; set; }
        public string CONFIGURATION { get; set; }
        public Nullable<decimal> STORE_NO { get; set; }
    }
    
    public class CUSTOM_ORDER_COURIER
    {
        public int COURIER_ID { get; set; }
        public string COURIERNAME { get; set; }
        public string PRIORITY_CITY { get; set; }
        public bool IS_ENABLED { get; set; }
        public byte? PRIORITY_ORDER { get; set; }
        public string PRIORITY_CITY_2 { get; set; }
    }

    public class CUSTOM_ORDER_CITY
    {
        public int ROW_ID { get; set; }
        public int CITY_ID { get; set; }
        public string CITY_NAME { get; set; }
        public int COURIER_ID { get; set; }
    }


    public class CUSTOM_ORDER_PICKUP_LOCATION
    {
        public int COURIER_ID { get; set; }
        public string PICKUP_NAME { get; set; }
        public string PICKUP_ID { get; set; }
    }
}


