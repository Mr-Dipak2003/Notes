using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using ApplicationLayer;

namespace DataLayer
{
    public class DL_Org_AddEmployee
    {
        Global gb = new Global();
        SqlCommand cmd = new SqlCommand();
        public bool FnSaveEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@InitialId", objAL_Org_AddEmployee.InitialId);
            cmd.Parameters.AddWithValue("@ModuleId", objAL_Org_AddEmployee.ModuleId);
            cmd.Parameters.AddWithValue("@BranchId", objAL_Org_AddEmployee.BranchId);
            cmd.Parameters.AddWithValue("@CollCenterId", objAL_Org_AddEmployee.intCenterId);
            cmd.Parameters.AddWithValue("@DepartmentId", objAL_Org_AddEmployee.DepartmentId);
            cmd.Parameters.AddWithValue("@DesignationId", objAL_Org_AddEmployee.DesignationId);
            cmd.Parameters.AddWithValue("@EmployeeCode", objAL_Org_AddEmployee.strEmployeeCode);
            cmd.Parameters.AddWithValue("@FirstName", objAL_Org_AddEmployee.strFirstName);
            cmd.Parameters.AddWithValue("@MiddleName", objAL_Org_AddEmployee.strMiddleName);
            cmd.Parameters.AddWithValue("@LastName", objAL_Org_AddEmployee.strLastName);
            cmd.Parameters.AddWithValue("@Gender", objAL_Org_AddEmployee.strGender);
            cmd.Parameters.AddWithValue("@MobileNo", objAL_Org_AddEmployee.strMobileNo);
            cmd.Parameters.AddWithValue("@EmailId", objAL_Org_AddEmployee.strEmail);
            cmd.Parameters.AddWithValue("@DatOfBirth", objAL_Org_AddEmployee.dtDatOfBirth);
            cmd.Parameters.AddWithValue("@AnneversaryDate", objAL_Org_AddEmployee.dtAnneversaryDate);
            cmd.Parameters.AddWithValue("@Address", objAL_Org_AddEmployee.strAddress);
            cmd.Parameters.AddWithValue("@DesireLevel", objAL_Org_AddEmployee.strDesireLevel);
            cmd.Parameters.AddWithValue("@Category", objAL_Org_AddEmployee.strCategory);
          //  cmd.Parameters.AddWithValue("@Employeephoto", objAL_Org_AddEmployee.byteEmployeephoto);
            cmd.Parameters.AddWithValue("@EmpDigitalSign", objAL_Org_AddEmployee.byteEmpDigitalSign);
            cmd.Parameters.AddWithValue("@Degree", objAL_Org_AddEmployee.strDegree);
            cmd.Parameters.AddWithValue("@UserName", objAL_Org_AddEmployee.strUserName);
            cmd.Parameters.AddWithValue("@DoctorId", objAL_Org_AddEmployee.intDoctorId);
           cmd.Parameters.AddWithValue("@EmpPhotos", objAL_Org_AddEmployee.strPath);
            cmd.Parameters.AddWithValue("@DocDetails", objAL_Org_AddEmployee.strCKDocDetails);

            cmd.Parameters.AddWithValue("@OnlineStatus", objAL_Org_AddEmployee.stronlineStatus); 
            cmd.Parameters.AddWithValue("@FatherName", objAL_Org_AddEmployee.strFatherName);
            cmd.Parameters.AddWithValue("@Age", objAL_Org_AddEmployee.strAge);
            cmd.Parameters.AddWithValue("@AgeYMD", objAL_Org_AddEmployee.strAgeYMD);
            cmd.Parameters.AddWithValue("@BloodGroup", objAL_Org_AddEmployee.strBloodGroup);
            cmd.Parameters.AddWithValue("@Nationality", objAL_Org_AddEmployee.strNationality);
            cmd.Parameters.AddWithValue("@State", objAL_Org_AddEmployee.strState);
            cmd.Parameters.AddWithValue("@City", objAL_Org_AddEmployee.strCity);
            cmd.Parameters.AddWithValue("@Village", objAL_Org_AddEmployee.strVillage);
            cmd.Parameters.AddWithValue("@MaritalStatus", objAL_Org_AddEmployee.strMaritalStatus);
            cmd.Parameters.AddWithValue("@Passport", objAL_Org_AddEmployee.strPassport);
            cmd.Parameters.AddWithValue("@Driving", objAL_Org_AddEmployee.strDriving);
            cmd.Parameters.AddWithValue("@CorreAddress", objAL_Org_AddEmployee.strCorreAddress);
            cmd.Parameters.AddWithValue("@CorresMo", objAL_Org_AddEmployee.strCorresMo);
            cmd.Parameters.AddWithValue("@DateOfJoining", objAL_Org_AddEmployee.strDateOfJoining);
            cmd.Parameters.AddWithValue("@EmployeeType", objAL_Org_AddEmployee.strEmployeeType);
            cmd.Parameters.AddWithValue("@ShiftName", objAL_Org_AddEmployee.strShiftName);
            cmd.Parameters.AddWithValue("@DOJPF", objAL_Org_AddEmployee.strDOJPF);
            cmd.Parameters.AddWithValue("@ESICAccNo", objAL_Org_AddEmployee.strESICAccNo);
            cmd.Parameters.AddWithValue("@PFAccNo", objAL_Org_AddEmployee.strPFAccNo);
            cmd.Parameters.AddWithValue("@BankName", objAL_Org_AddEmployee.strBankName);
            cmd.Parameters.AddWithValue("@BankAccNo", objAL_Org_AddEmployee.strBankAccNo);
            cmd.Parameters.AddWithValue("@PANNo", objAL_Org_AddEmployee.strPANNo);
            cmd.Parameters.AddWithValue("@PolicyName", objAL_Org_AddEmployee.strPolicyName);
            cmd.Parameters.AddWithValue("@FinPrintId", objAL_Org_AddEmployee.strFinPrintId);
            cmd.Parameters.AddWithValue("@WorkingStatus", objAL_Org_AddEmployee.strWorkingStatus);
            cmd.Parameters.AddWithValue("@ReportingEmpName", objAL_Org_AddEmployee.strReportingEmpName);
            cmd.Parameters.AddWithValue("@BankAccName", objAL_Org_AddEmployee.strBankAccName);
            


            cmd.Parameters.AddWithValue("@EmpMachineId", objAL_Org_AddEmployee.strEmpMachineId);
            cmd.Parameters.AddWithValue("@EmpSalaryId", objAL_Org_AddEmployee.strEmpSalaryId);
            cmd.Parameters.AddWithValue("@EmpSalary", objAL_Org_AddEmployee.strEmpSalary);
            cmd.Parameters.AddWithValue("@AadharCardNo", objAL_Org_AddEmployee.strAadharCardNo);

            //Shobhit
            cmd.Parameters.AddWithValue("@Education", objAL_Org_AddEmployee.streducation);
            cmd.Parameters.AddWithValue("@UAN", objAL_Org_AddEmployee.struan);
            //Shobhit

            if (objAL_Org_AddEmployee.strFlag == "UpdateEmployee")
            {
                cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);
                cmd.Parameters.AddWithValue("@ModifyReason", objAL_Org_AddEmployee.strModifyReason);
              //  cmd.Parameters.AddWithValue("@BitImgPhoto", objAL_Org_AddEmployee.boolimgEmpPhoto);
                cmd.Parameters.AddWithValue("@BitImgSign", objAL_Org_AddEmployee.boolimgEmpSign);
            }
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnSaveData(cmd);
        }

        public DataTable FnRptEmployeeIcard(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);

            return gb.FnReturnDataTable(cmd);
        }

        public bool FnSaveMaltipleFiles(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);
            cmd.Parameters.AddWithValue("@MobileNo", objAL_Org_AddEmployee.strMobileNo);
            cmd.Parameters.AddWithValue("@DepartmentId", objAL_Org_AddEmployee.DepartmentId);
            cmd.Parameters.AddWithValue("@Address", objAL_Org_AddEmployee.strAddress);
            return gb.FnSaveData(cmd);
        }

        public DataTable fnGenerateId(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@Flag",objAL_Org_AddEmployee.strFlag);
            cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);
           
            return gb.FnReturnDataTable(cmd);
        }

        public string FnCheckEmpMachineId(string strEmpMachineid)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@Flag", "checkEmpMachineId");
            cmd.Parameters.AddWithValue("@EmpMachineId", strEmpMachineid);
            return gb.fnReturnString(cmd);
        }
        public DataTable FnGetAllEmployeeData(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnReturnDataTable(cmd);
        }
        public bool FnCheckEmployeeIsExist(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@EmployeeCode", objAL_Org_AddEmployee.strEmployeeCode);
            cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnRetTrueFalse(cmd);
        }
        public DataTable FnSearchEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@EmpSearchQuery", objAL_Org_AddEmployee.strSearchQuery);
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnReturnDataTable(cmd);
        }
        public bool FnDelteEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@EmployeeId", objAL_Org_AddEmployee.intEmployeeId);
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnCheckIsUsed(cmd);
        }
        public string fnReturnGender(string strFlag, string strInitial)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_InitialMaster";
            cmd.Parameters.AddWithValue("@Flag", strFlag);
            cmd.Parameters.AddWithValue("@InitialId", strInitial);
            return gb.fnReturnString(cmd);
        }
        public bool FnUploadEmployee(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "SP_tbl_AddUploadFile";
            cmd.Parameters.AddWithValue("@FileId", objAL_Org_AddEmployee.intFileId);
            cmd.Parameters.AddWithValue("@FileName", objAL_Org_AddEmployee.strFileName);
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            return gb.FnCheckIsUsed(cmd);
        }


        public string fnReturnBranchId(string strFlag)
        {
            cmd = new SqlCommand();
            cmd.CommandText = "SP_Org_AddEmployeeMaster";
            cmd.Parameters.AddWithValue("@Flag", strFlag);
            return gb.fnReturnString(cmd);
        }
        public DataTable FnGetAllEmployeeReport(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd.Parameters.Clear();
            cmd.CommandText = "[SP_AddEmployeeReport]";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
            cmd.Parameters.AddWithValue("@DesignationId", objAL_Org_AddEmployee.DesignationId);
            cmd.Parameters.AddWithValue("@Workingstatus", objAL_Org_AddEmployee.status);//------add rahul 26/11/2021
            cmd.Parameters.AddWithValue("@OnlineStatus", objAL_Org_AddEmployee.onstatus);//------add rahul 26/11/2021
            return gb.FnReturnDataTable(cmd);
        }
        public DataTable FnGetAllHeaderData(AL_Org_AddEmployee objAL_Org_AddEmployee)
        {
            cmd = new SqlCommand();
            try
            {
                cmd.Parameters.Clear();
                cmd.CommandText = "SP_Rpt_ReportSetting";
                cmd.Parameters.AddWithValue("@Flag", objAL_Org_AddEmployee.strFlag);
                // cmd.Parameters.AddWithValue("@CenterID", objAL_PBA_ViewReport.strCenterID.TrimStart().TrimEnd());
                cmd.Parameters.AddWithValue("@WithHeader", objAL_Org_AddEmployee.strStatus);
            }
            catch (Exception ex)
            {

            }
            return gb.FnReturnDataTable(cmd);
        }
    }
}