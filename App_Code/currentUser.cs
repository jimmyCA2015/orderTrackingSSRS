using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for currentUser
/// </summary>
public class currentUser
{

    private static String userName = "";
    private static int isValidated = 0;
    private static String userAccountMapping = "";
    private static String userAccountMasterName = "";




    public static string getUser
    {
        get { return userName; }
        set { userName = value; }

    }
    public static int getValidation
    {
        get { return isValidated; }
        set { isValidated = value; }

    }
    public static string getUserAccountMaping
    {
        get { return userAccountMapping; }
        set { userAccountMapping= value; }

    }
    public static string getUserAccountMasterName
    {
        get { return userAccountMasterName; }
        set { userAccountMasterName= value; }

    }


}