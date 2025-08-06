using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Web;
using ApplicationLayer;
using DataLayer;


namespace BusinessLayer
{
    public class BL_Org_AddEmployee
    {
        DL_Org_AddEmployee objDL_Org_AddEmployee = new DL_Org_AddEmployee();
        public bool FnSaveEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnSaveEmployee(objAL_Org_AddEmployee);
        }
        public string FnCheckEmpMachineId(string strEmpMachineId)
        {
            return objDL_Org_AddEmployee.FnCheckEmpMachineId(strEmpMachineId);
        }
        public DataTable FnGetAllEmployeeData(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnGetAllEmployeeData(objAL_Org_AddEmployee);
        }
        public bool FnCheckEmployeeIsExist(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnCheckEmployeeIsExist(objAL_Org_AddEmployee);
        }
        public bool FnDelteEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnDelteEmployee(objAL_Org_AddEmployee);
        }
        public DataTable FnSearchEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnSearchEmployee(objAL_Org_AddEmployee);
        }

        public string fnReturnGender(string strFlag, string strInitial)
        {
            return objDL_Org_AddEmployee.fnReturnGender(strFlag, strInitial);
        }
        public string fnReturnBranchId(string strFlag)
        {
            return objDL_Org_AddEmployee.fnReturnBranchId(strFlag);
        }
        public DataTable FnGetAllEmployeeReport(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnGetAllEmployeeReport(objAL_Org_AddEmployee);
        }
        public DataTable FnGetAllHeaderData(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnGetAllHeaderData(objAL_Org_AddEmployee);
        }
        public bool FnUploadEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnUploadEmployee(objAL_Org_AddEmployee);
        }

        public DataTable fnGenerateId(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.fnGenerateId(objAL_Org_AddEmployee);
        }

        public bool FnSaveMaltipleFiles(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnSaveMaltipleFiles(objAL_Org_AddEmployee);
        }

        public DataTable FnRptEmployeeIcard(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            return objDL_Org_AddEmployee.FnRptEmployeeIcard(objAL_Org_AddEmployee);
        }
    }
}