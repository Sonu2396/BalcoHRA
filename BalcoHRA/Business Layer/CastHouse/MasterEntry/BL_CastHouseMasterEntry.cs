using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.SqlTypes;

namespace BalcoHRA.Business_Layer.CastHouse.MasterEnrty
{
    public class BL_CastHouseMasterEntry
    {
        
        FPManager cn = new FPManager();

        #region Location Details Start..........
        public DataTable Get_CastHouseList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_CASTHOUSELOCATION"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string CastHouse_Save(string Location,string TotalCapacity,string InsideCH,string Priority, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CASTHOUSELOCATION"
                , new string[] { "@CASTHOUSELOCATION", "@TOTALCAPACITY", "@INSIDECASTHOUSE", "@ASSIGNPRIORITY", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Location,TotalCapacity,InsideCH,Priority, isactive, userid, Entrystatus });
            return Result;
        }
        public string CastHouse_Update(string ID, string Location, string TotalCapacity, string InsideCH, string Priority, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CASTHOUSELOCATION"
                , new string[] { "@ID", "@CASTHOUSELOCATION", "@TOTALCAPACITY", "@INSIDECASTHOUSE", "@ASSIGNPRIORITY", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, Location, TotalCapacity, InsideCH, Priority, isactive, userid, Entrystatus });
            return Result;
        }
        public string CastHouse_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CASTHOUSELOCATION"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }
        public string CastHouse_ResetPriority()
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CASTHOUSELOCATION"
                , new string[] { "@ENTRYSTATUS" }
                , new string[] { "ResetAssign" });
            return Result;
        }
        #endregion Location Details End******


        #region Product Details Start..........
        public DataTable Get_ProductList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_PRODUCT"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public DataTable Get_ProductView(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_PRODUCT"
              , new string[] { "@ID","@ENTRYSTATUS" }
              , new string[] { Id,"View" });
            return dt;
        }
        public static object DBNullValueorStringIfNotNull(string value)
        {
            object o;
            if (value == null || value == "")
            {
                o = DBNull.Value;
            }
            else
            {
                o = value;
            }
            return o;
        }
        
        public string Product_Save(string Name, string fe, string si, string ti, string v, string tiv, string Mn, string Zn, string Cu, string Cr, string Zr, string B, string Ga, string Na, string Ni, string Mg, string Sr, string Alper, string AI, string Pb, string Sn,string Ca,string Be,string Co,string P1,string Li, string purity, string Priority, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_PRODUCT"
                , new string[] { "@PRODNAME", "@FE", "@SI", "@TI", "@V", "@TIV", "@Mn","@Zn","@Cu","@Cr","@Zr","@B","@Ga","@Na","@Ni","@Mg","@Sr","@Alper","@AI","@Pb","@Sn", "@Ca", "@Be", "@Co", "@P1", "@Li", "@PURITY", "@ASSIGNPRIORITY", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Name, fe, si, ti, v, tiv,  Mn,  Zn,  Cu , Cr,  Zr,  B,  Ga,  Na,  Ni,  Mg,  Sr,  Alper,  AI,  Pb,  Sn,Ca,Be,Co,P1,Li, purity, Priority, isactive, userid, Entrystatus });
           
            return Result;
        }
        public string Product_Update(string ID,string Name, string fe, string si, string ti, string v, string tiv, string Mn, string Zn, string Cu, string Cr, string Zr, string B, string Ga, string Na, string Ni, string Mg, string Sr, string Alper, string AI, string Pb, string Sn, string Ca, string Be, string Co, string P1, string Li, string purity, string Priority, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_PRODUCT"
                , new string[] {"@ID", "@PRODNAME", "@FE", "@SI", "@TI", "@V", "@TIV", "@Mn", "@Zn", "@Cu", "@Cr", "@Zr", "@B", "@Ga", "@Na", "@Ni", "@Mg", "@Sr", "@Alper", "@AI", "@Pb", "@Sn", "@Ca", "@Be", "@Co", "@P1", "@Li", "@PURITY", "@ASSIGNPRIORITY", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] {ID, Name, fe, si, ti, v, tiv, Mn, Zn, Cu, Cr, Zr, B, Ga, Na, Ni, Mg, Sr, Alper, AI, Pb, Sn, Ca, Be, Co, P1, Li, purity, Priority, isactive, userid, Entrystatus });

            return Result;
        }
        public string Product_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_PRODUCT"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }
        public string Product_ResetPriority()
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_PRODUCT"
                , new string[] { "@ENTRYSTATUS" }
                , new string[] { "ResetAssign" });
            return Result;
        }
        #endregion Product Details End******

        #region Furnace Details Start..........
        public DataTable Get_Furnace()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_FURNACE"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Furnace_Save(string chid,string furname, string prodid, string castno ,string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_FURNACE"
                , new string[] { "@CASTHOUSEID", "@FURNAME", "@PRODUCTID", "@CASTNO", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { chid, furname, prodid, castno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Furnace_Update(string ID, string chid, string furname, string prodid, string castno, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_FURNACE"
                , new string[] { "@ID", "@CASTHOUSEID", "@FURNAME", "@PRODUCTID", "@CASTNO", "@IsActive", "@MODIFIEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, chid, furname, prodid, castno, isactive, userid, Entrystatus });
            return Result;
        }
        public string Furnace_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_FURNACE"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Furnace Details End******


        #region Emergency Details Start..........
        public DataTable Get_Emergency()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_EMERGENCY_CONTACT"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public string Emergency_Save(string Location, string Authority, string Mobileno ,string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_EMERGENCY_CONTACT"
                , new string[] { "@LOCATION", "@AUTHORITYNAME", "@MOBILENAME", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Location, Authority, Mobileno, userid, Entrystatus });
            return Result;
        }


        #endregion Emergency Details End******



        #region Customer Details Start..........
        public DataTable Get_CustomerList()
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_CUSTOMER"
              , new string[] { "@ENTRYSTATUS" }
              , new string[] { "List" });
            return dt;
        }
        public DataTable Get_CustomerView(string Id)
        {
            DataTable dt = new DataTable();
            dt = cn.GetDataTable("SP_CH_MASTER_CUSTOMER"
              , new string[] { "@ID", "@ENTRYSTATUS" }
              , new string[] { Id, "View" });
            return dt;
        }
       

        public string Customer_Save(string Name,string Product, string fe, string si, string ti, string v,  string Mg, string Sr, string FeSiRatio,  string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CUSTOMER"
                , new string[] { "@CUSTNAME","@PRODNAME", "@FE", "@SI", "@TI", "@V", "@Mg", "@Sr", "@FeSiRatio", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { Name,Product, fe, si, ti, v,  Mg, Sr, FeSiRatio,  isactive, userid, Entrystatus });

            return Result;
        }
        public string Customer_Update(string ID,string Name, string Product, string fe, string si, string ti, string v,  string Mg, string Sr, string FeSiRatio, string isactive, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CUSTOMER"
                , new string[] { "@ID","@CUSTNAME", "@PRODNAME", "@FE", "@SI", "@TI", "@V",  "@Mg", "@Sr", "@FeSiRatio", "@IsActive", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID,Name, Product, fe, si, ti, v,  Mg, Sr, FeSiRatio, isactive, userid, Entrystatus });

            return Result;
        }
        public string Customer_Delete(string ID, string userid, string Entrystatus)
        {
            string Result = "";
            Result = cn.ExecuteQuerySP_Retrun_String("SP_CH_MASTER_CUSTOMER"
                , new string[] { "@ID", "@CREATEDBY", "@ENTRYSTATUS" }
                , new string[] { ID, userid, Entrystatus });
            return Result;
        }

        #endregion Customer Details End******

    }
}