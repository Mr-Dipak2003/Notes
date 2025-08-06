using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ApplicationLayer
{
    public class AL_Org_AddEmployee
    {
        public string strEmpName { get; set; }
        public int intDoctorId { get; set; }
        public int intEmployeeId { get; set; }
        public int intCenterId { get; set; }
        public int ModuleId { get; set; }
        public int BranchId { get; set; }
        public int DepartmentId { get; set; }
        public int DesignationId { get; set; }
        public int InitialId { get; set; }
        public bool boolIsDelEmployee { get; set; }
        public String strEmployeeCode { get; set; }
        public String strFirstName { get; set; }
        public String strMiddleName { get; set; }
        public String strLastName { get; set; }
        public Char strGender { get; set; }
        public String strMobileNo { get; set; }
        public String strEmail { get; set; }
        public String dtDatOfBirth { get; set; }
        public String dtAnneversaryDate { get; set; }
        public String strAddress { get; set; }
        public String strDesireLevel { get; set; }
        public string strStatus { get; set; }
        public String strCategory { get; set; }
        public Byte[] byteEmployeephoto { get; set; }
        public Byte[] byteEmpDigitalSign { get; set; }
        public String strModifyReason { get; set; }
        public String strUserName { get; set; }
        public String strFlag { get; set; }
        public String strSearchQuery { get; set; }
        //public String strDatOfBirth { get; set; }
        //public String strAnneversaryDate { get; set; }
        public Boolean boolimgEmpPhoto { get; set; }
        public Boolean boolimgEmpSign { get; set; }
        public string strDegree { get; set; }
        public string strFatherName {get;set;}
        public string strAge { get; set; }
        public string strAgeYMD { get; set; }
        public string strBloodGroup { get; set; }
        public string strNationality { get; set; }
        public string strState { get; set; }
        public string strCity { get; set; }
        public string strVillage { get; set; }
        public string strMaritalStatus { get; set; }
        public string strPassport { get; set; }
        public string strDriving { get; set; }
        public string strCorreAddress { get; set; }
        public string strCorresMo { get; set; }
        public string strDateOfJoining { get; set; }
        public string strEmployeeType { get; set; }
        public string strShiftName { get; set; }
        public string strDOJPF { get; set; }
        public string strESICAccNo { get; set; }
        public string strPFAccNo { get; set; }
        public string strBankName { get; set; }
        public string strBankAccNo { get; set; }
        public string strPANNo { get; set; }
        public string strPolicyName { get; set; }
        public string strFinPrintId { get; set; }
        public string strWorkingStatus { get; set; }
        public string stronlineStatus { get; set; }
        public string strReportingEmpName { get; set; }
        public string strBankAccName { get; set; }
        public string strEmpSalaryId { get; set; }
        public string strEmpMachineId { get; set; }
        public string strEmpSalary { get; set; }

        public string strAadharCardNo { get; set; }
        public string strFileName { get; set; }
        public int intFileId { get; set; }

        public string strCKDocDetails { get; set; }
        public string strPath { get; set; }

        //Shobhit
        public string streducation { get; set; }
        public string struan { get; set; }
        //Shobhit

        //Rahul
        public string status { get; set; }
        public string onstatus { get; set; }
        //Rahul
        public string strIcard { get; set; }
        public DataTable dtSaveFiles { get; set; }
    }
}