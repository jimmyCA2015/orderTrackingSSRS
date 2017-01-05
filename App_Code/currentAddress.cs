using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for currentAddress
/// </summary>
public class currentAddress
{
    private static String currentDeliveryTo = "";
    private static String currentShipToNumber = "";
    private static String currentDeliveryLocation = "";




    public static string getDeliveryTo
    {
        get { return currentDeliveryTo; }
        set { currentDeliveryTo = value; }

    }
    public static string getDeliveryLocation
    {
        get { return currentDeliveryLocation; }
        set { currentDeliveryLocation = value; }

    }
    public static string getShipToNumber
    {
        get { return currentShipToNumber; }
        set { currentShipToNumber = value; }

    }
  
}