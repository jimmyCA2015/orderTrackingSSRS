using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for currentPickup
/// </summary>
public class currentPickup
{
    private static String currentDeliveryTo2 = "";
    private static String currentShipToNumber2 = "";
    private static String currentDeliveryLocation2 = "";
    public static string getDeliveryTo2
    {
        get { return currentDeliveryTo2; }
        set { currentDeliveryTo2 = value; }

    }
    public static string getDeliveryLocation2
    {
        get { return currentDeliveryLocation2; }
        set { currentDeliveryLocation2 = value; }

    }
    public static string getShipToNumber2
    {
        get { return currentShipToNumber2; }
        set { currentShipToNumber2 = value; }

    }
  
}