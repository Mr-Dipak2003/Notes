using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using System.Data.SqlClient;
using ApplicationLayer;
using BusinessLayer;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using LogFramework;
using System.Web.Services;
using Microsoft.Reporting.WebForms;


namespace Thealth.frm
{
    public partial class frm_Org_AddEmployee : System.Web.UI.Page
    {
        Logger logger = new Logger();
        AL_Org_AddEmployee objAL_Org_AddEmployee = new AL_Org_AddEmployee();
        BL_Org_AddEmployee objBL_Org_AddEmployee = new BL_Org_AddEmployee();
        BL_FillAllDropDownList objBL_FillAllDropDownList = new BL_FillAllDropDownList();

        bool Result = false;
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == null)
                {
                    Response.Redirect("~/frm/frmLogin.aspx");
                }
                if (!IsPostBack)
                {
                    Label lblMainHeader = this.Master.FindControl("lblMainHeader") as Label;
                    lblMainHeader.Text = "Organization - Add Employee";
                    objBL_FillAllDropDownList.FnReturnddlModuleIDName(ddlModuleName);
                    objBL_FillAllDropDownList.FnReturnddlBranchIDName(ddlBranchName);
                    objBL_FillAllDropDownList.FnReturnddlDesignationIDName(ddlDesiganationName);
                    objBL_FillAllDropDownList.FnReturnddlInitialIDName(ddlinitial);
                    objBL_FillAllDropDownList.FnReturnddlDesignationIDName(ddlDesignation);
                    objBL_FillAllDropDownList.FnReturnddlCountryIDName(ddlNationality);
                    objBL_FillAllDropDownList.FnReturnddlBloodGroupIDName(ddlBloodGroup);
                    objBL_FillAllDropDownList.FnReturnddlConsultanatDoctIDName(ddlDoc);
                    objBL_FillAllDropDownList.FnReturnddlSalary(ddlsalary);
                    objBL_FillAllDropDownList.FnReturnALLEmployee(ddlReportEmpName);
                    objBL_FillAllDropDownList.FnBankName(ddlBankName);
                    txtsalmonthyear.Enabled = false;
                    ddlDepartmentName.Enabled = false;
                    FnFillgvAddEmployee();
                    rbLvl1.Checked = true;
                    rbStaff.Checked = true;
                    txtRemark.Visible = false;
                    lblRemark.Visible = false;
                    divCenter.Visible = false;
                    divDoc.Visible = false;


                    String strCtrlAccRights = objBL_FillAllDropDownList.FngetControlAccessRights(Convert.ToString(Session["UserName"]), "frm_Org_AddEmployee", 3);
                    if (!strCtrlAccRights.Contains("9"))
                    {
                        if (strCtrlAccRights.Contains("1"))
                        {
                            lnkAddEmployee.Enabled = true;
                        }
                        else
                        {
                            lnkAddEmployee.Enabled = false;
                        }
                        if (strCtrlAccRights.Contains("2"))
                        {
                            btnEdit.Enabled = true;
                        }
                        else
                        {
                            btnEdit.Enabled = false;
                        }
                        if (strCtrlAccRights.Contains("3"))
                        {
                            gvAddEmployee.Columns[21].Visible = true;
                        }
                        else
                        {
                            gvAddEmployee.Columns[21].Visible = false;
                        }
                        if (strCtrlAccRights.Contains("4"))
                        {
                            btnPrint.Enabled = true;
                        }
                        else
                        {
                            btnPrint.Enabled = false;
                        }


                    }
                }
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }


        [WebMethod]
        public static string FnCheckEmpMachineID(string EmpMachineId)
        {
            BL_Org_AddEmployee objBL_Org_AddEmployee = new BL_Org_AddEmployee();
            return objBL_Org_AddEmployee.FnCheckEmpMachineId(EmpMachineId);
        }
        protected void ddlModuleName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlModuleName.SelectedIndex > 0)
            {

                if (ddlModuleName.SelectedItem.Text == "Consultant" || ddlModuleName.SelectedItem.Text == "Nurse Module")
                {
                    objBL_FillAllDropDownList.FnReturnddlDepartmentIDNameClinic(ddlDepartmentName, ddlModuleName.SelectedValue);
                    ddlDoc.SelectedIndex = 0;
                    if (ddlDepartmentName.Items.Count == 1)
                    {
                        ddlDepartmentName.Enabled = false;
                    }
                    else
                    {
                        ddlDepartmentName.Enabled = true;
                    }
                    ddlDoc.Visible = false;
                    DoctrStar.Visible = false;
                    lblDoc.Visible = false;
                    rbConDoctor.Visible = true;
                    rbConDoctor.Checked = false;
                    rbCollCenter.Checked = false;
                    rbReferral.Checked = false;
                    rbStaff.Checked = true;
                }
                else if (ddlModuleName.SelectedIndex > 0)
                {
                    UpAddEmployee.Update();
                    lblDoc.Visible = false;
                    ddlDoc.Visible = false;
                    rbStaff.Checked = true;
                    rbConDoctor.Visible = false;
                    UpAddEmployee.Update();
                    objBL_FillAllDropDownList.FnReturnddlDepartmentIDName(ddlDepartmentName, ddlModuleName.SelectedValue);
                    UpAddEmployee.Update();
                    lblDoc.Visible = false;
                    ddlDoc.Visible = false;
                    DoctrStar.Visible = false;
                    rbStaff.Checked = true;
                    rbConDoctor.Visible = false;
                    UpAddEmployee.Update();
                    if (ddlDepartmentName.Items.Count == 1)
                    {
                        ddlDepartmentName.Enabled = false;
                    }
                    else
                    {
                        ddlDepartmentName.Enabled = true;
                    }
                }
            }
        }


        public void FnFillgvAddEmployee()
        {
            try
            {
                dt.Clear();
                objAL_Org_AddEmployee.strFlag = "GetEmployeefillgrd";
                dt = objBL_Org_AddEmployee.FnGetAllEmployeeData(objAL_Org_AddEmployee);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        gvAddEmployee.DataSource = dt;
                        gvAddEmployee.DataBind();
                        btnPrint.Visible = true;
                    }
                    else
                    {
                        gvAddEmployee.DataSource = null;
                        gvAddEmployee.DataBind();
                        btnPrint.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected bool FnCheckIsExist(String strFlag)
        {
            dt.Clear();
            objAL_Org_AddEmployee.strEmployeeCode = txtEmpCode.Text.Trim();
            if (strFlag == "2")
            {
                objAL_Org_AddEmployee.intEmployeeId = Convert.ToInt32(ViewState["EmployeeId"]);
            }
            objAL_Org_AddEmployee.strFlag = "CheckEmpIsExist";
            return objBL_Org_AddEmployee.FnCheckEmployeeIsExist(objAL_Org_AddEmployee);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                //FnFillgvAddEmployee();
                //Response.Redirect("~/frm/frm_Org_AddUploadFile.aspx?EmpId=" + 1, false);
                //pnlEmployeegrdiview.Visible = true;
                Result = FnCheckIsExist(btnSave.Attributes["value"]);
                if (Result == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('Record Already Exist.');", true);
                    return;
                }

                if (btnSave.Attributes["value"] == "1")
                {
                    FnSaveUpdateEmployee("1");
                }
                else if (btnSave.Attributes["value"] == "2")
                {
                    FnSaveUpdateEmployee("2");

                }

                //ViewState["EmployeeId"] = gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                //string empName = ViewState["EmployeeId"];

            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }
        //****************code by chetan
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string YesNo;
                string onstatus;
                string status;
                if (rbWithHeader.Checked == true)
                {
                    YesNo = "Y";
                }
                else
                {
                    YesNo = "N";
                }
                string ddldesignation;
                if (ddlDesignation.SelectedIndex == 0)
                {
                    ddldesignation = "0";
                }
                else
                {
                    ddldesignation = ddlDesignation.SelectedValue;
                }
                //Add By Rahul
                if (rbAll.Checked == true)
                {
                    onstatus = "yes";
                }
                else
                {
                    onstatus = "no";
                }
                if (rbActiveSrch.Checked == true)
                {
                    status = "A";
                }
                else
                {
                    status = "D";
                }
                //Add By Rahul
                Response.Redirect("~/frm/frm_Org_ViewReport.Aspx?reportName=rpt_AddEmployee" + "&WithHeader=" + YesNo + "&DesignationId=" + ddldesignation + "&WorkingStatus=" + status + "&OnlineStatus=" + onstatus, false);
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }
        public void FnSaveUpdateEmployee(String flag)
        {
            try
            {

                if (flag == "1")
                {
                    objAL_Org_AddEmployee.strFlag = "SaveEmployee";
                }
                else if (flag == "2")
                {
                    objAL_Org_AddEmployee.strFlag = "UpdateEmployee";
                    objAL_Org_AddEmployee.intEmployeeId = Convert.ToInt32(ViewState["EmployeeId"]);
                    objAL_Org_AddEmployee.strModifyReason = txtRemark.Text.Trim();
                }
                objAL_Org_AddEmployee.ModuleId = Convert.ToInt32(ddlModuleName.Text.Trim());
                objAL_Org_AddEmployee.BranchId = Convert.ToInt32(ddlBranchName.Text.Trim());

                if (ddlDepartmentName.SelectedIndex != 0)
                {
                    objAL_Org_AddEmployee.DepartmentId = Convert.ToInt32(ddlDepartmentName.Text.Trim());
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('Please Select Department.');", true);
                    return;
                }
                objAL_Org_AddEmployee.DesignationId = Convert.ToInt32(ddlDesiganationName.Text.Trim());
                objAL_Org_AddEmployee.strEmployeeCode = txtEmpCode.Text.Trim();
                objAL_Org_AddEmployee.strFirstName = txtFirstName.Text.Trim();
                objAL_Org_AddEmployee.strMiddleName = txtMiddleName.Text.Trim();
                objAL_Org_AddEmployee.strLastName = txtLastName.Text.Trim();
                objAL_Org_AddEmployee.InitialId = Convert.ToInt32(ddlinitial.SelectedValue);
                objAL_Org_AddEmployee.strGender = Convert.ToChar(ddlGender.SelectedValue);
                //if (ViewState["imgEmpPhoto"] is String)
                //{
                //    objAL_Org_AddEmployee.boolimgEmpPhoto = false;
                //    objAL_Org_AddEmployee.byteEmployeephoto = null;
                //}
                //else
                //{
                //    objAL_Org_AddEmployee.boolimgEmpPhoto = true;
                //    objAL_Org_AddEmployee.byteEmployeephoto = (byte[])ViewState["imgEmpPhoto"];
                //}

                if (ViewState["imgEmpSign"] is String)
                {
                    objAL_Org_AddEmployee.boolimgEmpSign = false;
                    objAL_Org_AddEmployee.byteEmpDigitalSign = null;
                }
                else
                {
                    objAL_Org_AddEmployee.boolimgEmpSign = true;
                    objAL_Org_AddEmployee.byteEmpDigitalSign = (byte[])ViewState["imgEmpSign"];
                }


                if (txtMobileNo.Text == string.Empty)
                {
                    objAL_Org_AddEmployee.strMobileNo = string.Empty;
                }
                else
                {
                    objAL_Org_AddEmployee.strMobileNo = txtMobileNo.Text.Trim();
                }
                objAL_Org_AddEmployee.strEmail = txtEmail.Text.Trim();
                if (txtDOB.Text.Trim() == "")
                {
                    objAL_Org_AddEmployee.dtDatOfBirth = null;
                }
                else
                {
                    objAL_Org_AddEmployee.dtDatOfBirth = txtDOB.Text.Trim().ToString();
                }
                if (txtAnneversaryDate.Text.Trim() == "")
                {
                    objAL_Org_AddEmployee.dtAnneversaryDate = null;
                }
                else
                {
                    objAL_Org_AddEmployee.dtAnneversaryDate = txtAnneversaryDate.Text.Trim().ToString();
                }

                objAL_Org_AddEmployee.strAddress = txtAddress.Text.Trim();
                if (rbLvl1.Checked == true)
                {
                    objAL_Org_AddEmployee.strDesireLevel = "Level1";
                }
                if (rbLvl2.Checked == true)
                {
                    objAL_Org_AddEmployee.strDesireLevel = "Level2";
                }
                if (rbLvl3.Checked == true)
                {
                    objAL_Org_AddEmployee.strDesireLevel = "Level3";
                }
                if (rbLvl4.Checked == true)
                {
                    objAL_Org_AddEmployee.strDesireLevel = "Level4";
                }

                if (rbStaff.Checked == true)
                {
                    objAL_Org_AddEmployee.strCategory = "Staff";
                }
                if (rbReferral.Checked == true)
                {
                    objAL_Org_AddEmployee.strCategory = "Referral";

                }
                if (rbCollCenter.Checked == true)
                {
                    objAL_Org_AddEmployee.strCategory = "Collection Center";
                    if (ddlCenter.SelectedIndex == 0)
                    {
                        objAL_Org_AddEmployee.intCenterId = 0;
                    }
                    else
                    {
                        objAL_Org_AddEmployee.intCenterId = Convert.ToInt32(ddlCenter.SelectedValue);
                    }
                }
                if (rbConDoctor.Checked == true)
                {
                    objAL_Org_AddEmployee.strCategory = "Clinical Staff";
                    if (ddlDoc.SelectedIndex == 0)
                    {
                        objAL_Org_AddEmployee.intDoctorId = 0;
                    }
                    else
                    {
                        objAL_Org_AddEmployee.intDoctorId = Convert.ToInt32(ddlDoc.SelectedValue);
                    }

                }
                objAL_Org_AddEmployee.strModifyReason = txtRemark.Text.Trim();

                objAL_Org_AddEmployee.strUserName = Convert.ToString(Session["UserName"]);

                if (txtFatherName.Text.Trim() == "")
                {
                    objAL_Org_AddEmployee.strFatherName = null;
                }
                else
                {
                    objAL_Org_AddEmployee.strFatherName = txtFatherName.Text.Trim().ToString();
                }
                objAL_Org_AddEmployee.strAge = txtAge.Text.Trim();
                objAL_Org_AddEmployee.strAgeYMD = ddlAge.SelectedValue;
                objAL_Org_AddEmployee.strBloodGroup = ddlBloodGroup.SelectedValue;
                if (ddlNationality.SelectedIndex == 0)
                {
                    objAL_Org_AddEmployee.strNationality = "0";
                }
                else
                {
                    objAL_Org_AddEmployee.strNationality = ddlNationality.SelectedValue;
                }
                if (ddlState.SelectedIndex == 0)
                {
                    objAL_Org_AddEmployee.strState = "0";
                }
                else
                {
                    objAL_Org_AddEmployee.strState = ddlState.SelectedValue;
                }
                objAL_Org_AddEmployee.strCity = ddlCity.SelectedValue;
                objAL_Org_AddEmployee.strVillage = ddlVillage.SelectedValue;
                objAL_Org_AddEmployee.strMaritalStatus = ddlMaritalStatus.SelectedValue;
                objAL_Org_AddEmployee.strPassport = txtPasportNo.Text.Trim();
                objAL_Org_AddEmployee.strDriving = txtDrivingLicNo.Text.Trim();
                objAL_Org_AddEmployee.strCorreAddress = txtCorreAddes.Text.Trim();
                if (txtCorrMoNum.Text == string.Empty)
                {
                    objAL_Org_AddEmployee.strCorresMo = string.Empty;
                }
                else
                {
                    objAL_Org_AddEmployee.strCorresMo = txtCorrMoNum.Text.Trim();
                }
                objAL_Org_AddEmployee.strDateOfJoining = txtDateOfJoining.Text.Trim();
                objAL_Org_AddEmployee.strEmployeeType = ddlEmpType.SelectedValue;
                objAL_Org_AddEmployee.strShiftName = ddlShiftName.SelectedValue;
                objAL_Org_AddEmployee.strDOJPF = txtDatePF.Text.Trim();
                objAL_Org_AddEmployee.strESICAccNo = txtESICAccNo.Text.Trim();
                objAL_Org_AddEmployee.strPFAccNo = txtPFAccNO.Text.Trim();
                if (ddlBankName.SelectedIndex == 0)
                {
                    objAL_Org_AddEmployee.strBankName = "0";
                }
                else
                {
                    objAL_Org_AddEmployee.strBankName = ddlBankName.SelectedValue;
                }

                objAL_Org_AddEmployee.strBankAccNo = txtBankAccNo.Text.Trim();
                objAL_Org_AddEmployee.strPANNo = txtPanNo.Text.Trim();
                objAL_Org_AddEmployee.strPolicyName = ddlPolicyName.SelectedValue;
                objAL_Org_AddEmployee.strFinPrintId = txtFingrPrint.Text.Trim();
                if (rbActive.Checked == true)
                {

                    objAL_Org_AddEmployee.strWorkingStatus = rbActive.Text.Trim();
                }
                else
                {
                    objAL_Org_AddEmployee.strWorkingStatus = rbDeActive.Text.Trim();
                }
                if (rbnoonlineAccess.Checked == true)
                {

                    objAL_Org_AddEmployee.stronlineStatus = "1";

                }
                else
                {
                    objAL_Org_AddEmployee.stronlineStatus = "0";

                }
                objAL_Org_AddEmployee.strReportingEmpName = ddlReportEmpName.SelectedValue;
                objAL_Org_AddEmployee.strBankAccName = txtBankAccName.Text.Trim();
                objAL_Org_AddEmployee.strEmpMachineId = txtEmpmachineId.Text.Trim();
                if (ddlsalary.SelectedIndex == 0)
                {
                    objAL_Org_AddEmployee.strEmpSalaryId = "0";
                }
                else
                {
                    objAL_Org_AddEmployee.strEmpSalaryId = ddlsalary.SelectedValue;
                }

                objAL_Org_AddEmployee.strEmpSalary = txtsalmonthyear.Text.Trim();
                objAL_Org_AddEmployee.strAadharCardNo = txtAadarCardNo.Text.Trim();


                objAL_Org_AddEmployee.strCKDocDetails = CKDocDetails.Text.Trim();
                objAL_Org_AddEmployee.strPath = Convert.ToString(ViewState["ImgPath"]);
                // objAL_Org_AddEmployee.strPath = objAL_Org_AddEmployee.strPath.Replace(@"\", "/");

                //Shobhit
                objAL_Org_AddEmployee.streducation = txteducation.Text.Trim();
                objAL_Org_AddEmployee.struan = txtuan.Text.Trim();
                //Shobhit
                Result = objBL_Org_AddEmployee.FnSaveEmployee(objAL_Org_AddEmployee);
                if (Result == true && flag == "1")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SucessModal('Record Inserted Successfully.');", true);
                }
                else if (Result == true && flag == "2")
                {
                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SucessModal('Record Updated Successfully.');", true);
                }
                lblRemark.Visible = false;
                divModifyReason.Visible = false;
                ClerField();
                pnlAdd.Visible = false;
                pnlEmployeegrdiview.Visible = true;
                FnFillgvAddEmployee();
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }
        public void ddclear()
        {
            ddlCenter.Visible = false;
            lblCenter.Visible = false;
            ddlDoc.Visible = false;
            lblDoc.Visible = false;
        }

        public void ClerField()
        {
            //  ddclear();
            ddlDesignation.SelectedIndex = 0;
            txtAddress.Text = "";
            txtDOB.Text = "";
            txtAnneversaryDate.Text = "";  // DateTime.Now;
            txtEmail.Text = "";
            txtEmpCode.Text = "";
            txtFirstName.Text = "";
            CKDocDetails.Text = "";
            txtLastName.Text = "";
            txtMiddleName.Text = "";
            txtMobileNo.Text = "";
            txtRemark.Text = "";
            ddlMaritalStatus.SelectedIndex = 0;
            ddlBranchName.SelectedIndex = 0;
            ddlDepartmentName.SelectedIndex = 0;
            ddlDesiganationName.SelectedIndex = 0;
            ddlinitial.SelectedIndex = 0;
            ddlModuleName.SelectedIndex = 0;
            ddlGender.SelectedIndex = 0;
            btnSave.Text = "Save";
            btnSave.Attributes["value"] = "1";
            rbLvl1.Checked = true;
            rbLvl2.Checked = false;
            rbLvl3.Checked = false;
            rbLvl4.Checked = false;
            rbStaff.Checked = true;
            rbReferral.Checked = false;
            ddlCenter.SelectedIndex = 0;
            rbCollCenter.Checked = false;
            txtRemark.Visible = false;
            ddlDoc.SelectedIndex = 0;
            txtFatherName.Text = "";
            txtAge.Text = "";
            ddlAge.SelectedIndex = 0;
            ddlBloodGroup.SelectedIndex = 0;
            ddlNationality.SelectedIndex = 0;
            ddlState.SelectedIndex = 0;
            ddlCity.SelectedIndex = 0;
            txtPasportNo.Text = "";
            txtDrivingLicNo.Text = "";
            txtCorreAddes.Text = "";
            txtCorrMoNum.Text = "";
            txtDateOfJoining.Text = "";
            ddlEmpType.SelectedIndex = 0;
            ddlShiftName.SelectedIndex = 0;
            txtDatePF.Text = "";
            txtESICAccNo.Text = "";
            txtPFAccNO.Text = "";
            ddlBankName.SelectedIndex = 0;
            txtBankAccNo.Text = "";
            txtPanNo.Text = "";
            ddlPolicyName.SelectedIndex = 0;
            txtFingrPrint.Text = "";
            rbActive.Checked = true;
            ddlReportEmpName.SelectedIndex = 0;
            txtBankAccName.Text = "";
            txtsalmonthyear.Text = "";
            ddlsalary.SelectedIndex = 0;
            txtEmpmachineId.Text = "";
            txtAadarCardNo.Text = "";
            lblChooseFile.Text = "";
            //Shobhit
            txteducation.Text = "";
            txtuan.Text = "";
            //Shobhit
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClerField();

        }
        protected void lnkAddEmployee_Click(object sender, EventArgs e)
        {
            txtsalmonthyear.Enabled = false;
            lblRemark.Visible = false;
            pnlAdd.Visible = true;
            pnlEmployeegrdiview.Visible = false;
            divModifyReason.Visible = false;
            FnEnTrueFalse(true);
            btnEdit.Visible = false;
            btnSave.Visible = true;
            btnClear.Visible = true;
            btnCancel.Visible = true;
            ClerField();
            imgEmpPhoto.ImageUrl = null;
            imgEmpSign.ImageUrl = null;
            rbLvl1.Checked = true;
            rbStaff.Checked = true;
            rbReferral.Checked = false;
            rbCollCenter.Checked = false;
            rbConDoctor.Checked = false;
            divDoc.Visible = false;
            rbConDoctor.Visible = false;
            divCenter.Visible = false;

            objBL_FillAllDropDownList.FnReturnddlCountryIDName(ddlNationality);
            ddlNationality.SelectedValue = objBL_Org_AddEmployee.fnReturnBranchId("GetCountrtyId");
            objBL_FillAllDropDownList.FnReturnddlStateIDName(ddlState, ddlNationality.SelectedValue.ToString());
            ddlState.SelectedValue = objBL_Org_AddEmployee.fnReturnBranchId("GetStateId");
            objBL_FillAllDropDownList.FnReturnddlCityIDName(ddlCity, ddlState.SelectedValue.ToString());
            ddlCity.SelectedValue = objBL_Org_AddEmployee.fnReturnBranchId("GetCitysId");
            objBL_FillAllDropDownList.FnReturnddlLocationIDName(ddlVillage, ddlCity.SelectedValue);
            rbonlineAccess.Checked = false;
            rbnoonlineAccess.Checked = true;

        }

        protected void gvAddEmployee_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                //int RowIndex = Convert.ToInt32((e.CommandArgument).ToString());

                int RowIndex = 0;
                if (Convert.ToString(e.CommandArgument) != "First" && Convert.ToString(e.CommandArgument) != "Last")
                {
                    RowIndex = Convert.ToInt32(e.CommandArgument);
                }

                if (e.CommandName == "lnkbtnModifyEmployee")
                {
                    ViewState["EmployeeId"] = gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                  
                    ddlinitial.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["InitialId"].ToString();
                    ddlModuleName.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["ModuleId"].ToString();
                    if (ddlModuleName.SelectedValue == "13" || ddlModuleName.SelectedValue == "14")
                    {
                        rbConDoctor.Visible = true;
                    }
                    else
                    {
                        rbConDoctor.Visible = false;
                    }
                    ddlBranchName.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["BranchId"].ToString();
                    objBL_FillAllDropDownList.FnReturnddlDepartmentIDName(ddlDepartmentName, ddlModuleName.SelectedValue);
                    ddlDepartmentName.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["DepartmentId"].ToString();
                    ddlDesiganationName.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["DesignationId"].ToString();

                    txtEmpCode.Text = gvAddEmployee.Rows[RowIndex].Cells[0].Text.Trim();


                    if (gvAddEmployee.Rows[RowIndex].Cells[2].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[2].Text.Trim() != "&nbsp;")
                    { txtFirstName.Text = gvAddEmployee.Rows[RowIndex].Cells[2].Text.Trim(); }
                    else
                    { txtFirstName.Text = ""; }
                    if (gvAddEmployee.Rows[RowIndex].Cells[3].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[3].Text.Trim() != "&nbsp;")
                    { txtMiddleName.Text = gvAddEmployee.Rows[RowIndex].Cells[3].Text.Trim(); }
                    else
                    { txtMiddleName.Text = ""; }

                    // txtLastName.Text = gvAddEmployee.Rows[RowIndex].Cells[4].Text;
                    if (gvAddEmployee.Rows[RowIndex].Cells[4].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[4].Text.Trim() != "&nbsp;")
                    { txtLastName.Text = gvAddEmployee.Rows[RowIndex].Cells[4].Text; }
                    else
                    { txtLastName.Text = ""; }

                    objBL_FillAllDropDownList.FnReturnddlGender(ddlGender);
                    ddlGender.SelectedValue = objBL_Org_AddEmployee.fnReturnGender("GetdefaultSex", ddlinitial.SelectedValue);
                    ddlGender.SelectedValue = gvAddEmployee.DataKeys[RowIndex]["Gender"].ToString();
                    if (gvAddEmployee.Rows[RowIndex].Cells[6].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[6].Text.Trim() != "&nbsp;")
                    {
                        txtMobileNo.Text = gvAddEmployee.Rows[RowIndex].Cells[6].Text.Trim();
                    }
                    else
                    {
                        txtMobileNo.Text = "";
                    }


                    if (gvAddEmployee.Rows[RowIndex].Cells[7].Text != null && gvAddEmployee.Rows[RowIndex].Cells[7].Text != "&nbsp;")
                    {
                        txtEmail.Text = gvAddEmployee.Rows[RowIndex].Cells[7].Text;
                    }
                    else
                    {
                        txtEmail.Text = "";
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[8].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[8].Text.Trim() != "&nbsp;")
                    {
                        txtDOB.Text = gvAddEmployee.Rows[RowIndex].Cells[8].Text;
                    }
                    else
                    {
                        txtDOB.Text = string.Empty;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[9].Text != null && gvAddEmployee.Rows[RowIndex].Cells[9].Text != "&nbsp;")
                    {
                        txtAnneversaryDate.Text = gvAddEmployee.Rows[RowIndex].Cells[9].Text.Trim();
                    }
                    else
                    {
                        txtAnneversaryDate.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[10].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[10].Text.Trim() != "&nbsp;")
                    {
                        txtAddress.Text = gvAddEmployee.DataKeys[RowIndex]["Address"].ToString();
                    }
                    else
                    {
                        txtAddress.Text = "";
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[11].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[11].Text.Trim() != "&nbsp;")
                    {
                        txtRemark.Text = gvAddEmployee.Rows[RowIndex].Cells[11].Text;
                    }
                    else
                    {
                        txtRemark.Text = "";
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[12].Text.Trim() == "Level1")
                    {
                        rbLvl1.Checked = true;
                        rbLvl2.Checked = false;
                        rbLvl3.Checked = false;
                        rbLvl4.Checked = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[12].Text.Trim() == "Level2")
                    {
                        rbLvl2.Checked = true;
                        rbLvl1.Checked = false;
                        rbLvl3.Checked = false;
                        rbLvl4.Checked = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[12].Text.Trim() == "Level3")
                    {
                        rbLvl3.Checked = true;
                        rbLvl1.Checked = false;
                        rbLvl2.Checked = false;
                        rbLvl4.Checked = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[12].Text.Trim() == "Level4")
                    {
                        rbLvl4.Checked = true;
                        rbLvl1.Checked = false;
                        rbLvl2.Checked = false;
                        rbLvl3.Checked = false;

                    }
                    if (gvAddEmployee.DataKeys[RowIndex].Values["OriginalCategory"].ToString().Trim() == "Staff")
                    {
                        rbStaff.Checked = true;
                        rbReferral.Checked = false;
                        rbCollCenter.Checked = false;
                        rbConDoctor.Checked = false;
                    }
                    if (gvAddEmployee.DataKeys[RowIndex].Values["OriginalCategory"].ToString().Trim() == "Referral")
                    {
                        rbReferral.Checked = true;
                        rbCollCenter.Checked = false;
                        rbStaff.Checked = false;
                        rbConDoctor.Checked = false;
                    }
                    if (gvAddEmployee.DataKeys[RowIndex].Values["OriginalCategory"].ToString().Trim() == "Collection Center")
                    {
                        rbCollCenter.Checked = true;
                        rbStaff.Checked = false;
                        rbReferral.Checked = false;
                        rbConDoctor.Checked = false;
                    }
                    if (gvAddEmployee.DataKeys[RowIndex].Values["OriginalCategory"].ToString().Trim() == "Clinical Staff")
                    {
                        rbConDoctor.Checked = true;
                        rbConDoctor.Visible = true;
                        ddlDoc.Visible = true;
                        DoctrStar.Visible = true;
                        lblDoc.Visible = true;
                        rbCollCenter.Checked = false;
                        rbStaff.Checked = false;
                        rbReferral.Checked = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[23].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[23].Text.Trim() != "&nbsp;")
                    {
                        objBL_FillAllDropDownList.FnReturnddlCollCenterIDName(ddlCenter, ddlBranchName.SelectedValue);
                        ddlCenter.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[23].Text.Trim();
                        divCenter.Visible = true;
                    }
                    else
                    {
                        ddlCenter.SelectedIndex = 0;
                        divCenter.Visible = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[24].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[24].Text.Trim() != "&nbsp;")
                    {
                        ddlDoc.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[24].Text.Trim();
                        divDoc.Visible = true;
                    }
                    else
                    {
                        ddlDoc.SelectedIndex = 0;
                        divDoc.Visible = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[25].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[25].Text.Trim() != "&nbsp;")
                    {
                        txtFatherName.Text = gvAddEmployee.Rows[RowIndex].Cells[25].Text;
                    }
                    else
                    {
                        txtFatherName.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[26].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[26].Text.Trim() != "&nbsp;")
                    {
                        txtAge.Text = gvAddEmployee.Rows[RowIndex].Cells[26].Text;
                    }
                    else
                    {
                        txtAge.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[27].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[27].Text.Trim() != "&nbsp;")
                    {
                        ddlAge.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[27].Text;
                    }
                    else
                    {
                        ddlAge.SelectedValue = string.Empty;
                    }
                    objBL_FillAllDropDownList.FnReturnddlBloodGroupIDName(ddlBloodGroup);
                    if (gvAddEmployee.Rows[RowIndex].Cells[28].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[28].Text.Trim() != "&nbsp;")
                    {
                        ddlBloodGroup.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[28].Text;
                    }
                    else
                    {
                        ddlBloodGroup.SelectedValue = "0";
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[29].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[29].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[29].Text.Trim() != "0")
                    {
                        ddlNationality.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[29].Text;
                    }
                    else
                    {
                        ddlNationality.SelectedValue = string.Empty;
                    }
                    objBL_FillAllDropDownList.FnReturnddlStateIDName(ddlState, ddlNationality.SelectedValue);
                    if (gvAddEmployee.Rows[RowIndex].Cells[30].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[30].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[30].Text.Trim() != "0")
                    {
                        ddlState.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[30].Text;
                    }
                    else
                    {
                        ddlState.SelectedValue = string.Empty;
                    }
                    objBL_FillAllDropDownList.FnReturnddlCityIDName(ddlCity, ddlState.SelectedValue);
                    if (gvAddEmployee.Rows[RowIndex].Cells[31].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[31].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[30].Text.Trim() != "0")
                    {
                        ddlCity.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[31].Text;
                    }
                    else
                    {
                        ddlCity.SelectedValue = string.Empty;
                    }
                    objBL_FillAllDropDownList.FnReturnddlLocationIDName(ddlVillage, ddlCity.SelectedValue);
                    if (gvAddEmployee.Rows[RowIndex].Cells[32].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[32].Text.Trim() != "&nbsp;")
                    {
                        ddlVillage.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[32].Text;
                    }
                    else
                    {
                        ddlVillage.SelectedValue = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[33].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[33].Text.Trim() != "&nbsp;")
                    {
                        ddlMaritalStatus.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[33].Text;
                    }
                    else
                    {
                        ddlMaritalStatus.SelectedValue = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[34].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[34].Text.Trim() != "&nbsp;")
                    {
                        txtPasportNo.Text = gvAddEmployee.Rows[RowIndex].Cells[34].Text;
                    }
                    else
                    {
                        txtPasportNo.Text = string.Empty;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[35].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[35].Text.Trim() != "&nbsp;")
                    {
                        txtDrivingLicNo.Text = gvAddEmployee.Rows[RowIndex].Cells[35].Text;
                    }
                    else
                    {
                        txtDrivingLicNo.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[36].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[36].Text.Trim() != "&nbsp;")
                    {
                        txtCorreAddes.Text = gvAddEmployee.DataKeys[RowIndex]["CorreAddress"].ToString();
                    }
                    else
                    {
                        txtCorreAddes.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[37].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[37].Text.Trim() != "&nbsp;")
                    {
                        txtCorrMoNum.Text = gvAddEmployee.Rows[RowIndex].Cells[37].Text;
                    }
                    else
                    {
                        txtCorrMoNum.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[38].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[38].Text.Trim() != "&nbsp;")
                    {
                        txtDateOfJoining.Text = gvAddEmployee.Rows[RowIndex].Cells[38].Text;
                    }
                    else
                    {
                        txtDateOfJoining.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[39].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[39].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[39].Text.Trim() != "0")
                    {
                        ddlEmpType.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[39].Text;
                    }
                    else
                    {
                        ddlEmpType.SelectedIndex = 0;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[40].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[40].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[40].Text.Trim() != "0")
                    {
                        ddlShiftName.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[40].Text;
                    }
                    else
                    {
                        ddlShiftName.SelectedIndex = 0;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[41].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[41].Text.Trim() != "&nbsp;")
                    {
                        txtDatePF.Text = gvAddEmployee.Rows[RowIndex].Cells[41].Text;
                    }
                    else
                    {
                        txtDatePF.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[42].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[42].Text.Trim() != "&nbsp;")
                    {
                        txtESICAccNo.Text = gvAddEmployee.Rows[RowIndex].Cells[42].Text;
                    }
                    else
                    {
                        txtESICAccNo.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[43].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[43].Text.Trim() != "&nbsp;")
                    {
                        txtPFAccNO.Text = gvAddEmployee.Rows[RowIndex].Cells[43].Text;
                    }
                    else
                    {
                        txtPFAccNO.Text = string.Empty;
                    }
                    objBL_FillAllDropDownList.FnBankName(ddlBankName);

                    if (gvAddEmployee.Rows[RowIndex].Cells[44].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[44].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[44].Text.Trim() != "0")
                    {
                        ddlBankName.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[44].Text;
                    }
                    else
                    {
                        ddlBankName.SelectedIndex = 0;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[45].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[45].Text.Trim() != "&nbsp;")
                    {
                        txtBankAccNo.Text = gvAddEmployee.Rows[RowIndex].Cells[45].Text;
                    }
                    else
                    {
                        txtBankAccNo.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[46].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[46].Text.Trim() != "&nbsp;")
                    {
                        txtPanNo.Text = gvAddEmployee.Rows[RowIndex].Cells[46].Text;
                    }
                    else
                    {
                        txtPanNo.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[47].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[47].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[46].Text.Trim() != "0")
                    {
                        ddlPolicyName.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[47].Text;
                    }
                    else
                    {
                        ddlPolicyName.SelectedIndex = 0;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[48].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[48].Text.Trim() != "&nbsp;")
                    {
                        txtFingrPrint.Text = gvAddEmployee.Rows[RowIndex].Cells[48].Text;
                    }
                    else
                    {
                        txtFingrPrint.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[49].Text.Trim() == "Active")
                    {
                        rbActive.Checked = true;
                        rbDeActive.Checked = false;
                    }
                    else
                    {
                        rbDeActive.Checked = true;
                        rbActive.Checked = false;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[50].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[50].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[49].Text.Trim() != "0")
                    {
                        ddlReportEmpName.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[50].Text;
                    }
                    else
                    {
                        ddlReportEmpName.SelectedIndex = 0;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[51].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[51].Text.Trim() != "&nbsp;")
                    {
                        txtBankAccName.Text = gvAddEmployee.Rows[RowIndex].Cells[51].Text;
                    }
                    else
                    {
                        txtBankAccName.Text = string.Empty;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[52].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[52].Text.Trim() != "&nbsp;")
                    {
                        txtEmpmachineId.Text = gvAddEmployee.Rows[RowIndex].Cells[52].Text;
                    }
                    else
                    {
                        txtEmpmachineId.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[53].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[53].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[53].Text.Trim() != "0")
                    {
                        ddlsalary.SelectedValue = gvAddEmployee.Rows[RowIndex].Cells[53].Text;
                    }
                    else
                    {
                        ddlsalary.SelectedIndex = 0;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[54].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[54].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[54].Text.Trim() != "0")
                    {
                        txtsalmonthyear.Text = gvAddEmployee.Rows[RowIndex].Cells[54].Text.Trim();
                    }
                    else
                    {
                        txtsalmonthyear.Text = string.Empty;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[55].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[55].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[55].Text.Trim() != "0")
                    {
                        txtAadarCardNo.Text = gvAddEmployee.Rows[RowIndex].Cells[55].Text.Trim();
                    }
                    else
                    {
                        txtAadarCardNo.Text = string.Empty;
                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[56].Text.Trim() == "1")
                    {
                        rbonlineAccess.Checked = false;
                        rbnoonlineAccess.Checked = true;

                        // rbonlineAccess.Checked = true;
                        // rbnoonlineAccess.Checked = false;
                    }
                    else
                    {
                        rbonlineAccess.Checked = true;
                        rbnoonlineAccess.Checked = false;

                        //rbonlineAccess.Checked = false;
                        // rbnoonlineAccess.Checked = true;


                    }
                    if (gvAddEmployee.Rows[RowIndex].Cells[57].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[57].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[57].Text.Trim() != "0")
                    {
                        CKDocDetails.Text = gvAddEmployee.Rows[RowIndex].Cells[57].Text.Trim();
                    }
                    else
                    {
                        CKDocDetails.Text = string.Empty;
                    }


                    if (gvAddEmployee.Rows[RowIndex].Cells[58].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[58].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[58].Text.Trim() != "0")
                    {
                        //ViewState["ImgPath"] = null;
                        imgEmpPhoto.ImageUrl = gvAddEmployee.Rows[RowIndex].Cells[58].Text.Trim();
                        //ViewState["EmpPhotos"]  Shobhit
                    }
                    else
                    {
                        //  ViewState["ImgPath"] = string.Empty;
                        imgEmpPhoto.ImageUrl = "";
                    }

                    //Shobhit
                    if (gvAddEmployee.Rows[RowIndex].Cells[59].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[59].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[59].Text.Trim() != "0")
                    {
                        txteducation.Text = gvAddEmployee.Rows[RowIndex].Cells[59].Text.Trim();
                    }
                    else
                    {
                        txteducation.Text = string.Empty;
                    }

                    if (gvAddEmployee.Rows[RowIndex].Cells[60].Text.Trim() != null && gvAddEmployee.Rows[RowIndex].Cells[60].Text.Trim() != "&nbsp;" && gvAddEmployee.Rows[RowIndex].Cells[60].Text.Trim() != "0")
                    {
                        txtuan.Text = gvAddEmployee.Rows[RowIndex].Cells[60].Text.Trim();
                    }
                    else
                    {
                        txtuan.Text = string.Empty;
                    }

                    //Shobhit

                    //   OnlineStatus
                    //imgEmpPhoto.ImageUrl = "~/ImageHandler.ashx?sqlQuery=SELECT Employeephoto FROM tbl_Org_AddEmployeeMaster WHERE EmployeeId = " + gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    //ViewState["imgEmpPhoto"] = imgEmpPhoto.ImageUrl;
                    imgEmpSign.ImageUrl = "~/ImageHandler.ashx?sqlQuery=SELECT EmpDigitalSign FROM tbl_Org_AddEmployeeMaster WHERE EmployeeId =" + gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    ViewState["imgEmpSign"] = imgEmpSign.ImageUrl;
                    btnSave.Text = "Update";
                    btnSave.Attributes["value"] = "2";
                    FnEnTrueFalse(false);
                    pnlAdd.Visible = true;
                    pnlEmployeegrdiview.Visible = false;
                    lblRemark.Visible = true;
                    txtRemark.Visible = true;
                    divModifyReason.Visible = true;
                    btnCancel.Visible = true;
                    btnEdit.Visible = true;

                    btnClear.Visible = false;
                    btnSave.Visible = false;
                    return;

                }
                else if (e.CommandName == "lnkbtnUploadEmployee")
                {
                    ViewState["EmployeeId"] = gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    string EmpId = Convert.ToString(ViewState["EmployeeId"]);
               
                    Response.Redirect("~/frm/frm_Org_AddUploadFile.aspx?EmpId=" + EmpId, false);

                    //imgEmpPhoto.ImageUrl = "~/ImageHandler.ashx?sqlQuery=SELECT Employeephoto FROM tbl_Org_AddEmployeeMaster WHERE EmployeeId = " + gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    //ViewState["imgEmpPhoto"] = imgEmpPhoto.ImageUrl;
                    //imgEmpSign.ImageUrl = "~/ImageHandler.ashx?sqlQuery=SELECT EmpDigitalSign FROM tbl_Org_AddEmployeeMaster WHERE EmployeeId =" + gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    //ViewState["imgEmpSign"] = imgEmpSign.ImageUrl;
                    //btnSave.Text = "Update";
                    //btnSave.Attributes["value"] = "2";
                    //FnEnTrueFalse(false);
                    //pnlAdd.Visible = true;
                    //pnlEmployeegrdiview.Visible = false;
                    //lblRemark.Visible = true;
                    //txtRemark.Visible = true;
                    //divModifyReason.Visible = true;
                    //btnCancel.Visible = true;
                    //btnEdit.Visible = true;
                    //btnClear.Visible = false;
                    //btnSave.Visible = false;
                    //return;

                }
                else if(e.CommandName== "lnkGenerateIdCard")
                {
                    dt.Clear();
                    objAL_Org_AddEmployee.strFlag = "GenerateIdCard";
                    string strempid = gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString();
                    objAL_Org_AddEmployee.intEmployeeId = Convert.ToInt32(strempid);
                    Session["Employeecode"] = objAL_Org_AddEmployee.intEmployeeId;
                    dt = objBL_Org_AddEmployee.fnGenerateId(objAL_Org_AddEmployee);
                    if (dt != null)
                    {
                        if (dt.Rows.Count > 0)
                        {
                            imgLogoForIdentity.ImageUrl = dt.Rows[0]["imgLogoForIdentity"].ToString();
                            lblAddressForIdentity.Text = dt.Rows[0]["AddressForIdentity"].ToString();
                            EmpPhotoForIdentity.ImageUrl = dt.Rows[0]["EmpPhotoForIdentity"].ToString();
                            lblEmpNameForIdentity.Text = dt.Rows[0]["EmpNameForIdentity"].ToString();
                            lblDesignationForIdentity.Text = dt.Rows[0]["DesignationForIdentity"].ToString();
                            lblEmpIdForIdentity.Text = dt.Rows[0]["EmpIdForIdentity"].ToString();
                            lblDOJForIdentity.Text = dt.Rows[0]["DOJForIdentity"].ToString();
                            lblBloodGroupForIdentity.Text = dt.Rows[0]["BloodGroupForIdentity"].ToString();
                            lblDrNameForIdentity.Text = dt.Rows[0]["DrNameForIdentity"].ToString();
                            lblDrDesignationForIdentity.Text = dt.Rows[0]["DrDesignationForIdentity"].ToString();
                            lblDrAuthorizedSignatureForIdentity.Text = dt.Rows[0]["DrAuthorizedSignatureForIdentity"].ToString();
                            lblHospitalNameForIdentityBackSide.Text = dt.Rows[0]["HospitalNameForIdentityBackSide"].ToString();
                            lblHospitalAddressForIdentityBackSide.Text = dt.Rows[0]["HospitalAddressForIdentityBackSide"].ToString();
                            lblEmergencyAddressForIdentityBackSide.Text = dt.Rows[0]["EmergencyAddressForIdentityBackSide"].ToString();
                            lblNoteForIdentityBackSide.Text = dt.Rows[0]["NoteForIdentityBackSide"].ToString();
                          
                            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "OpenModal();", true);
                            UpAddEmployee.Update();
                        }
                    }

                }

                else if (e.CommandName == "lnkbtnDeleteEmployee")
                {
                    objAL_Org_AddEmployee.intEmployeeId = Convert.ToInt32(gvAddEmployee.DataKeys[RowIndex]["EmployeeId"].ToString());

                    objAL_Org_AddEmployee.strFlag = "DeleteEmployee";
                    Result = objBL_Org_AddEmployee.FnDelteEmployee(objAL_Org_AddEmployee);
                    if (Result == true)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SucessModal('Record Deleted Successfully.');", true);
                        FnFillgvAddEmployee();
                        pnlAdd.Visible = false;
                        pnlEmployeegrdiview.Visible = true;
                        return;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('Record Already Used.');", true);
                        return;
                    }
                }

            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            imgEmpPhoto.ImageUrl = "";
            pnlAdd.Visible = false;
            pnlEmployeegrdiview.Visible = true;
        }
        protected void ddlDepartmentName_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            try
            {
                if (flimgEmpPhoto.HasFile)
                {
                    string filePath = flimgEmpPhoto.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string folderPath = Server.MapPath("~/EmployeePhoto/");
                    string contenttype = String.Empty;

                    //Set the contenttype based on File Extension
                    switch (ext)
                    {
                        case ".jpeg":
                            contenttype = "image/jpeg";
                            break;
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                    }
                    if (contenttype != String.Empty)
                    {

                        flimgEmpPhoto.Visible = true;



                        ViewState["ImgPath"] = null;

                        string fExtension = Path.GetExtension(flimgEmpPhoto.PostedFile.FileName);

                        if (File.Exists(folderPath + filename))
                        {
                            //If Directory (Folder) does not exists. Create it.
                            File.Delete(folderPath + filename);
                        }
                        this.flimgEmpPhoto.SaveAs(folderPath + Path.GetFileName(filename));
                        string path = System.IO.Path.Combine(Server.MapPath("~/EmployeePhoto/"), filename);
                        lblChooseFile.Text = filename + " Uploded Successfully";
                        ViewState["ImgPath"] = "~/EmployeePhoto/" + filename;
                        ViewState["fileType"] = fExtension;
                        imgEmpPhoto.ImageUrl = "~/EmployeePhoto/" + filename;


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('File format not recognised. Upload png/jpg formats only.');", true);
                        return;
                    }
                    upimgEmpPhoto.Update();
                    UpAddEmployee.Update();
                }
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected void btnUploadSign_Click(object sender, EventArgs e)
        {
            try
            {
                if (flimgEmpSign.HasFile)
                {
                    string filePath = flimgEmpSign.PostedFile.FileName;
                    string filename = Path.GetFileName(filePath);
                    string ext = Path.GetExtension(filename);
                    string contenttype = String.Empty;

                    //Set the contenttype based on File Extension
                    switch (ext)
                    {
                        case ".jpeg":
                            contenttype = "image/jpeg";
                            break;
                        case ".jpg":
                            contenttype = "image/jpg";
                            break;
                        case ".png":
                            contenttype = "image/png";
                            break;
                    }
                    if (contenttype != String.Empty)
                    {
                        Stream fs = flimgEmpSign.PostedFile.InputStream;
                        BinaryReader br = new BinaryReader(fs);
                        Byte[] bytes = br.ReadBytes((Int32)fs.Length);
                        //    ViewState["imgEmpSign"] = null;
                        ViewState["imgEmpSign"] = bytes;
                        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
                        imgEmpSign.ImageUrl = "data:image/png;base64," + base64String;
                        imgEmpSign.Visible = true;
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('File format not recognised. Upload png/jpg formats only.');", true);
                        return;
                    }
                    upimgEmpSign.Update();
                }
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected void gvAddEmployee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvAddEmployee.PageIndex = e.NewPageIndex;
            // FnFillgvAddEmployee();
            fmemp_Search();
            // fmemp_Search();
            // upGrid.Update();
            // upDate.Update();

        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            FnEnTrueFalse(true);
            btnSave.Visible = true;
            btnCancel.Visible = true;
            btnEdit.Visible = false;
            btnClear.Visible = false;
            upDate.Update();
        }

        public void FnEnTrueFalse(bool boolvalue)
        {
            txtAddress.Enabled = boolvalue;
            txtAnneversaryDate.Enabled = boolvalue;
            txtDOB.Enabled = boolvalue;
            txtEmail.Enabled = boolvalue;
            txtEmpCode.Enabled = boolvalue;
            txtFirstName.Enabled = boolvalue;
            txtMiddleName.Enabled = boolvalue;
            txtLastName.Enabled = boolvalue;
            txtMobileNo.Enabled = boolvalue;
            txtRemark.Enabled = boolvalue;
            ddlBranchName.Enabled = boolvalue;
            ddlDepartmentName.Enabled = boolvalue;
            ddlDesiganationName.Enabled = boolvalue;
            ddlGender.Enabled = boolvalue;
            ddlinitial.Enabled = boolvalue;
            ddlModuleName.Enabled = boolvalue;
            flimgEmpPhoto.Enabled = boolvalue;
            flimgEmpSign.Enabled = boolvalue;
            btnUpload.Enabled = boolvalue;
            btnUploadSign.Enabled = boolvalue;
            rbStaff.Enabled = boolvalue;
            rbReferral.Enabled = boolvalue;
            rbCollCenter.Enabled = boolvalue;
            rbLvl1.Enabled = boolvalue;
            rbLvl2.Enabled = boolvalue;
            rbLvl3.Enabled = boolvalue;
            rbLvl4.Enabled = boolvalue;
            ddlCenter.Enabled = boolvalue;
            ddlDoc.Enabled = boolvalue;
            txtFatherName.Enabled = boolvalue;
            txtAge.Enabled = boolvalue;
            ddlAge.Enabled = boolvalue;
            ddlBloodGroup.Enabled = boolvalue;
            ddlNationality.Enabled = boolvalue;
            ddlState.Enabled = boolvalue;
            ddlCity.Enabled = boolvalue;
            ddlVillage.Enabled = boolvalue;
            txtDrivingLicNo.Enabled = boolvalue;
            txtCorreAddes.Enabled = boolvalue;
            txtCorrMoNum.Enabled = boolvalue;
            txtDateOfJoining.Enabled = boolvalue;
            ddlEmpType.Enabled = boolvalue;
            ddlShiftName.Enabled = boolvalue;
            txtDatePF.Enabled = boolvalue;
            txtESICAccNo.Enabled = boolvalue;
            txtPFAccNO.Enabled = boolvalue;
            ddlBankName.Enabled = boolvalue;
            txtBankAccNo.Enabled = boolvalue;
            txtPanNo.Enabled = boolvalue;
            ddlPolicyName.Enabled = boolvalue;
            txtFingrPrint.Enabled = boolvalue;
            rbActive.Enabled = boolvalue;
            rbDeActive.Enabled = boolvalue;
            ddlReportEmpName.Enabled = boolvalue;
            txtBankAccName.Enabled = boolvalue;
            ddlMaritalStatus.Enabled = boolvalue;
            txtPasportNo.Enabled = boolvalue;
            txtsalmonthyear.Enabled = boolvalue;
            CKDocDetails.Enabled = boolvalue;
            ddlsalary.Enabled = boolvalue;
            txtEmpmachineId.Enabled = boolvalue;
            txtAadarCardNo.Enabled = boolvalue;
            rbonlineAccess.Enabled = boolvalue;
            rbnoonlineAccess.Enabled = boolvalue;
            //Shobhit
            txteducation.Enabled = boolvalue;
            txtuan.Enabled = boolvalue;
            //Shobhit
        }

        public void fmemp_Search()
        {
            try
            {

                string qry = "";
                if (ddlDesignation.SelectedIndex != 0)
                {
                    qry += " and toe.DesignationId =" + ddlDesignation.SelectedValue;
                }

                if (!string.IsNullOrEmpty(txtCode.Text))
                {
                    qry += " and toe.EmployeeCode like '" + txtCode.Text.Trim() + "%'";
                }

                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    qry += " and toe.FirstName like '" + txtName.Text.Trim() + "%'";
                }
                if (!string.IsNullOrEmpty(txtlstname.Text))
                {
                    qry += " and toe.LastName like '" + txtlstname.Text.Trim() + "%'";
                }
                if (rbAll.Checked == true)
                {
                    qry += " and toe.OnlineStatus =" + 1;
                }
                else
                { qry += " and toe.OnlineStatus =" + 0; }

                if ((ddlCategory.SelectedIndex != 0))
                {
                    qry += " and toe.Category='" + ddlCategory.SelectedValue + "'";
                }

                if (rbActiveSrch.Checked == true)
                {
                    qry += " and toe.WorkingStatus = 'Active'";
                }
                else
                {
                    qry += " and toe.WorkingStatus = 'Deactive'";
                }

                objAL_Org_AddEmployee.strFlag = "SearchEmployee";
                objAL_Org_AddEmployee.strSearchQuery = qry.Trim();

                dt = objBL_Org_AddEmployee.FnSearchEmployee(objAL_Org_AddEmployee);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        gvAddEmployee.DataSource = dt;
                        gvAddEmployee.DataBind();
                        lblCount.Text = "Total Record(s) Count :" + Convert.ToInt32(dt.Rows.Count);
                    }
                    else
                    {
                        gvAddEmployee.DataSource = null;
                        gvAddEmployee.DataBind();
                        lblCount.Text = "Total Record(s) Count :" + Convert.ToInt32(dt.Rows.Count);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            fmemp_Search();
        }

        protected void btnClearSearch_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            txtCode.Text = "";
            ddlDesignation.SelectedIndex = 0;
            FnFillgvAddEmployee();
            lblChooseFile.Text = "";
        }
        protected void rbStaff_CheckedChanged(object sender, EventArgs e)
        {
            if (rbStaff.Checked == true)
            {
                divCenter.Visible = false;
                divDoc.Visible = false;
                ddlCenter.SelectedIndex = 0;
            }
        }

        protected void rbReferral_CheckedChanged(object sender, EventArgs e)
        {
            if (rbReferral.Checked == true)
            {
                divCenter.Visible = false;
                divDoc.Visible = false;
                ddlCenter.SelectedIndex = 0;
            }
        }
        protected void rbCollCenter_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCollCenter.Checked == true)
            {
                objBL_FillAllDropDownList.FnReturnddlCollCenterIDName(ddlCenter, ddlBranchName.SelectedValue);
                divCenter.Visible = true;
                divDoc.Visible = false;
            }
        }
        protected void rbConDoctor_CheckedChanged(object sender, EventArgs e)
        {
            if (rbConDoctor.Checked == true)
            {
                //UpdateRadio.Update();
                ddlDoc.SelectedIndex = 0;
                objBL_FillAllDropDownList.FnReturnddlConsultanatDoctIDName(ddlDoc);
                ddlDoc.SelectedIndex = 0;
                DoctrStar.Visible = true;
                divDoc.Visible = true;
                divCenter.Visible = false;
                lblDoc.Visible = true;
                ddlDoc.Visible = true;
            }
        }

        protected void ddlinitial_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                objBL_FillAllDropDownList.FnReturnddlGender(ddlGender);
                ddlGender.SelectedValue = objBL_Org_AddEmployee.fnReturnGender("GetdefaultSex", ddlinitial.SelectedValue);
                UpAddEmployee.Update();
            }
            catch (Exception ex)
            {
                logger.UserName = Convert.ToString(Session["UserName"]);
                logger.ClassName = this.ToString();
                logger.Exception(ex);
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
            }
        }

        protected void ddlNationality_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlNationality.SelectedIndex > 0)
            {
                objBL_FillAllDropDownList.FnReturnddlStateIDName(ddlState, ddlNationality.SelectedValue);
                if (ddlState.Items.Count > 1)
                {
                    ddlCity.SelectedIndex = 0;
                    ddlVillage.SelectedIndex = 0;
                    ddlCity.Enabled = false;
                    ddlVillage.Enabled = false;
                }
            }
            else
            {
                ddlState.SelectedIndex = 0;
                ddlCity.SelectedIndex = 0;
                ddlVillage.SelectedIndex = 0;
                ddlCity.Enabled = false;
                ddlVillage.Enabled = false;
                ddlState.Enabled = false;

            }
        }

        protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlState.SelectedIndex > 0)
            {
                objBL_FillAllDropDownList.FnReturnddlCityIDName(ddlCity, ddlState.SelectedValue);
                if (ddlCity.Items.Count > 1)
                {
                    ddlVillage.SelectedIndex = 0;
                    ddlVillage.Enabled = false;
                }
            }
            else
            {
                ddlCity.SelectedIndex = 0;
                ddlVillage.SelectedIndex = 0;
                ddlVillage.Enabled = false;
                ddlCity.Enabled = false;
            }
        }

        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCity.SelectedIndex > 0)
            {
                objBL_FillAllDropDownList.FnReturnddlLocationIDName(ddlVillage, ddlCity.SelectedValue);
                ddlVillage.Enabled = true;
                ddlVillage.SelectedIndex = 0;
            }
            else
            {
                ddlVillage.Enabled = false;
                ddlVillage.SelectedIndex = 0;
            }
        }

        protected void ddlsalary_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlsalary.SelectedIndex > 0)
            {
                txtsalmonthyear.Enabled = true;
            }
            else
            {
                txtsalmonthyear.Enabled = false;
                txtsalmonthyear.Text = "";
            }
        }

        protected void btnIdPrint_Click(object sender, EventArgs e)
        {
            FnPrintReport();
            UpAddEmployee.Update();
        }
        public void FnPrintReport()
        {
            ReportViewer rv_ViewReport = new ReportViewer();
            Warning[] warnings;

            string[] streamIds;
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;
            objAL_Org_AddEmployee.intEmployeeId =Convert.ToInt32(Session["Employeecode"]);
           
            objAL_Org_AddEmployee.strFlag = "GenerateIdCard";                   
            DataTable dtEmployeeIcardDetails = objBL_Org_AddEmployee.FnRptEmployeeIcard(objAL_Org_AddEmployee);
            ReportDataSource rdsEmployeeIcard = new ReportDataSource("DsEmployeeIcard", dtEmployeeIcardDetails);                                          
            string EmployeeICardReport = "Print_Files/" + Convert.ToString(Session["UserName"]) + "EmployeeICardReport.pdf";
            rv_ViewReport.LocalReport.ReportPath = Server.MapPath("~/Reports/RptEmployeeIcard.rdlc");


            rv_ViewReport.LocalReport.EnableExternalImages = true;
            string imagePath = new Uri(Server.MapPath(dtEmployeeIcardDetails.Rows[0]["EmpPhotoForIdentity"].ToString())).AbsoluteUri;
            ReportParameter EmployeeID = new ReportParameter("ImagePath", imagePath); 
            rv_ViewReport.LocalReport.SetParameters(EmployeeID);
            rv_ViewReport.LocalReport.Refresh();


            rv_ViewReport.LocalReport.DataSources.Clear();
            rv_ViewReport.LocalReport.DataSources.Add(rdsEmployeeIcard);          
            byte[] bytes = rv_ViewReport.LocalReport.Render("PDF", null, out mimeType, out encoding, out extension, out streamIds, out warnings);
            string path = Server.MapPath(EmployeeICardReport);
            System.IO.FileInfo fileW = new System.IO.FileInfo(path);
            if (fileW.Exists) //check file exsit or not
            {
                fileW.Delete();
            }
            FileStream fileSW = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            fileSW.Write(bytes, 0, bytes.Length);
            fileSW.Dispose();
            //   ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", " window.open('Print_Files/PatientIPDBillReport.pdf', '_blank');", true);
            ScriptManager.RegisterStartupScript(this, typeof(string), "OPEN_WINDOW", " window.open('" + EmployeeICardReport + "', '_blank');", true);
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "location.reload();", true);
        }


        //protected void btnIcardUPload_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (flDocICard.HasFile)
        //        {
        //            foreach (HttpPostedFile postedFile in flDocICard.PostedFiles)
        //            {
        //                string filePath = postedFile.FileName;
        //                String StrFilePathName = Path.GetFileName(filePath);
        //                string ext = Path.GetExtension(filePath);
        //                string filename = Path.GetFileNameWithoutExtension(filePath);
        //                string contenttypeSys = postedFile.ContentType;

        //                string contenttype = string.Empty;

        //                int fileSize = postedFile.ContentLength;
        //                //string uploadStatus = "File Uploaded Successfully.";
        //                switch (ext)
        //                {
        //                    case ".jpg":
        //                        contenttype = "image/jpg";
        //                        break;
        //                    case ".jpeg":
        //                        contenttype = "image/jpeg";
        //                        break;
        //                    case ".png":
        //                        contenttype = "image/png";
        //                        break;
        //                    case ".pdf":
        //                        contenttype = "application/pdf";
        //                        break;
        //                    case ".xlsx":
        //                        contenttype = "application/xlsx";
        //                        break;
        //                    case ".xls":
        //                        contenttype = "application/xls";
        //                        break;
        //                }

        //                if (fileSize > 6000000)
        //                {
        //                    //uploadStatus = "File Size Must Less Than OR Equal 5 MB.";
        //                    byte[] bytes = null;
        //                    FnSaveIDcard(filename, bytes, contenttypeSys, ext);
        //                }
        //                else if (contenttype == String.Empty)
        //                {
        //                    // uploadStatus = " Upload png/jpg/jpeg/pdf formats only.";
        //                    byte[] bytes = null;

        //                    FnSaveIDcard(filename, bytes, contenttypeSys, ext);
        //                }
        //                else
        //                {
        //                    using (Stream fs = postedFile.InputStream)
        //                    {
        //                        using (BinaryReader br = new BinaryReader(fs))
        //                        {
        //                            byte[] bytes = br.ReadBytes((Int32)fs.Length);
        //                            FnSaveIDcard(filename, bytes, contenttype, ext);
        //                        }
        //                    }
        //                }
        //                if (gvuploadFiles.Rows.Count > 0)
        //                {
        //                    btnSave.Visible = true;
        //                }
        //                else
        //                {
        //                    btnSave.Visible = false;
        //                }
        //            }
        //            ScriptManager.RegisterStartupScript(this, GetType(), "Open", "openModalmyIcardUploadDoc();", true);
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('Please Select File For Upload.');", true);
        //            return;
        //            ScriptManager.RegisterStartupScript(this, GetType(), "Close", "openModalmyIcardUploadDoc();", true);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.UserName = Convert.ToString(Session["UserName"]);
        //        logger.ClassName = this.ToString();
        //        logger.Exception(ex);
        //        ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
        //    }
        //}
        //public void FnSaveIDcard(string filename, byte[] bytes, string contenttype, string ext)
        //{
        //    DataTable dttmp = new DataTable();
        //    dttmp.Clear();
        //    dttmp.Columns.Add("DocName");
        //    dttmp.Columns.Add("Data", typeof(byte[]));
        //    dttmp.Columns.Add("DocumentType");           
        //    dttmp.Columns.Add("Extention");
        //    dttmp.Rows.Add(filename, bytes, contenttype, ext);
        //    DataTable dtRead = (DataTable)ViewState["TmpDataIDCardFile"];
        //    if (dtRead != null)
        //    {
        //        if (dtRead.Rows.Count > 0)
        //        {
        //            dtRead.Merge(dttmp);
        //            gvuploadFiles.DataSource = dtRead;
        //            gvuploadFiles.DataBind();
        //            ViewState["TmpDataIDCardFile"] = null;
        //            ViewState["TmpDataIDCardFile"] = dtRead;
        //        }
        //        else
        //        {
        //            gvuploadFiles.DataSource = dttmp;
        //            gvuploadFiles.DataBind();
        //            ViewState["TmpDataIDCardFile"] = null;
        //            ViewState["TmpDataIDCardFile"] = dttmp;
        //        }
        //    }
        //    else
        //    {
        //        gvuploadFiles.DataSource = dttmp;
        //        gvuploadFiles.DataBind();
        //        ViewState["TmpDataIDCardFile"] = null;
        //        ViewState["TmpDataIDCardFile"] = dttmp;
        //    }
        //}

        //protected void btnICardSave_Click(object sender, EventArgs e)
        //{
        //    if (ViewState["TmpDataIDCardFile"] != null)
        //    {
        //        try
        //        {
        //            DataTable dtForSave = (DataTable)ViewState["TmpDataIDCardFile"];
        //            int incre = 0;
        //            foreach (GridViewRow gvr in gvuploadFiles.Rows)
        //            {

        //                TextBox txtDocName = gvr.FindControl("txtDocName") as TextBox;
        //                dtForSave.Rows[incre].SetField("DocName", txtDocName.Text.Trim());

        //                incre++;
        //            }

        //            DataView view = dtForSave.AsDataView();
        //            //view.RowFilter = "UploadStatus='File Uploaded Successfully.'";
        //            DataTable dtForupLoad = view.ToTable();
        //            DataTable dtForupLoad1 = new DataTable();
        //            dtForupLoad1.Clear();
        //            dtForupLoad1.Columns.Add("DocName");
        //            dtForupLoad1.Columns.Add("Data", typeof(byte[]));
        //            dtForupLoad1.Columns.Add("DocumentType");
        //            dtForupLoad1.Columns.Add("FileUrlPath");
        //            for (int i = 0; i < dtForupLoad.Rows.Count; i++)
        //            {
        //                byte[] bytes = (byte[])dtForupLoad.Rows[i]["Data"];
        //                string strFileName = dtForupLoad.Rows[i]["DocName"].ToString();
        //                string Dtype = dtForupLoad.Rows[i]["DocumentType"].ToString();
        //                string extension = dtForupLoad.Rows[i]["Extention"].ToString();
        //                if (strFileName == "" || strFileName == " ")
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('please Enter File Name .');", true);
        //                    return;
        //                }
        //                string Name = string.Empty;
        //                string ProfileID = Request.QueryString["ProfileID"];
        //                string FName = ViewState["FName"].ToString();
        //                string LName = ViewState["LName"].ToString();
        //                Name = FName + " " + LName;
        //                if (ProfileID.Contains("/"))
        //                {
        //                    ProfileID = ProfileID.Replace("/", "-");
        //                }
        //                if (Name.Contains("/"))
        //                {
        //                    Name = Name.Replace("/", "-");
        //                }
        //                ////check directory or folder exists or not

        //                if (!Directory.Exists(Server.MapPath("~/Data/HRMDocuments/" + ProfileID + '_' + Name)))
        //                {
        //                    Directory.CreateDirectory(Server.MapPath("~/Data/HRMDocuments/" + ProfileID + '_' + Name));
        //                }
        //                string path = Server.MapPath("~/Data/HRMDocuments/" + ProfileID + '_' + Name + "/" + "IDCARD-" + strFileName + "" + extension);
        //                // string path = Server.MapPath("Print_Files//" + "PatientTestReports.pdf");
        //                FileInfo filedel = new FileInfo(path);
        //                if (filedel.Exists)//che ck file exsit or not
        //                {

        //                    ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "InfoModal('This" + strFileName + " File Is Already Exist. .');", true);
        //                    return;
        //                }
        //                string fileUrl = "~/Data/HRMDocuments/" + ProfileID + '_' + Name + "/" + "IDCARD-" + strFileName + "" + extension;
        //                FileStream file1 = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        //                file1.Write(bytes, 0, bytes.Length);
        //                file1.Dispose();

        //                byte[] bytesNew = null;
        //                dtForupLoad1.Rows.Add(strFileName, bytes, Dtype, fileUrl);
        //                Session["IcardPath"] = fileUrl;
        //                objAL_Org_AddEmployee.strIcard = Session["IcardPath"].ToString();
        //            }

        //            objAL_Org_AddEmployee.intEmployeeId = Convert.ToInt32(ViewState["CandidateID"]);

        //            objAL_Org_AddEmployee.strUserName = Convert.ToString(Session["UserName"]);
        //            objAL_Org_AddEmployee.dtSaveFiles = dtForupLoad1;
        //            objAL_Org_AddEmployee.strFlag = "SaveData";
        //            Result = objBL_Org_AddEmployee.FnSaveMaltipleFiles(objAL_Org_AddEmployee);
        //            if (Result == true)
        //            {
        //                gvuploadFiles.DataSource = null;
        //                gvuploadFiles.DataBind();
        //                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "SucessModal('Record Inserted Successfully.');", true);
        //                ViewState["TmpDataIDCardFile"] = null;
        //                btnSave.Visible = false;
        //                ScriptManager.RegisterStartupScript(this, GetType(), "Close", "Closemodal();", true);

        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            logger.UserName = Convert.ToString(Session["UserName"]);
        //            logger.ClassName = this.ToString();
        //            logger.Exception(ex);
        //            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "DangerModal('Something Wrong ! Contact STARTLAZAA PVT LTD Support');", true);
        //        }
        //    }
        //    }
    }
}
