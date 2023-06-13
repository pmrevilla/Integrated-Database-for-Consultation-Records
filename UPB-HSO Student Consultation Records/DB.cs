﻿using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Linq.Expressions;
using System.Security.Permissions;

public class DB
{
    DataSet ds;

    public DB()
    {
        ds = new DataSet();

    }

    public string QueryScalar(string Query)
    {
        string str;
        MySqlConnection mySqlConnection = new MySqlConnection(ConfigurationManager.ConnectionStrings["ConString"].ToString());
        MySqlCommand mySqlCommand = new MySqlCommand(Query, mySqlConnection);
        mySqlConnection.Open();
        try
        {
            try
            {
                str = mySqlCommand.ExecuteScalar().ToString();
            }
            finally
            {
                mySqlCommand.Dispose();
                mySqlConnection.Close();
                mySqlCommand.Dispose();
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        return str;
    }
}