<%@ Page Title="" Language="C#" MasterPageFile="~/frm/Organization.Master" ClientIDMode="Static" AutoEventWireup="true" CodeBehind="frm_Org_AddEmployee.aspx.cs" Inherits="Thealth.frm.frm_Org_AddEmployee" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="../plugins/Chosen/chosen.jquery.js"></script>
    <link href="../plugins/Chosen/chosen.css" rel="stylesheet" />
     
    <%--    Following Styele is Used for DropDownlWQith Automcomplete--%>
    <style>
        #lblAddressForIdentity{
            margin-left:10px;
            line-height:50px;
        }
        a img {
            border: none;
        }

        ol li {
            list-style: decimal outside;
        }

        div#containerAuto {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }

        div.side-by-side {
            width: 100%;
            margin-bottom: 1em;
        }

            div.side-by-side > div {
                float: left;
                width: 70%;
            }

                div.side-by-side > div > em {
                    margin-bottom: 10px;
                    display: block;
                }

        .clearfix:after {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
    </style>
    <script type="text/javascript">
        function OpenModal(stimsg) {
            $('#myModal').modal('show');
        }
        function pageLoad() {
            $(".chzn-select").chosen();
            $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
            $('#txtDOB').unbind();
            $('#txtDOB').datepicker();
            $('#txtAnneversaryDate').unbind();
            $('#txtAnneversaryDate').datepicker();
            $('#txtDateOfJoining').unbind();
            $('#txtDateOfJoining').datepicker();
            $('#txtDatePF').unbind();
            $('#txtDatePF').datepicker();

            $("#txtDOB").change(function () {

                CheckDOBDate();

            })
            $("#txtDateOfJoining").change(function () {

                CheckJoiningDate();

            })

            $("#txtAnneversaryDate").change(function () {

                CheckAnnDate();
            })
            function CheckDOBDate() {

                var StartDate = document.getElementById("txtDOB").value; //for javascript

                var date1 = StartDate.substring(0, 2);
                var month1 = StartDate.substring(3, 5);
                var year1 = StartDate.substring(6, 10);
                var myStartDate = new Date(year1, month1 - 1, date1);

                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!

                var yyyy = today.getFullYear();
                if (dd < 10) {
                    dd = '0' + dd
                }
                if (mm < 10) {
                    mm = '0' + mm
                }
                var todate = dd + "/" + mm + "/" + yyyy;

                var date3 = todate.substring(0, 2);
                var month3 = todate.substring(3, 5);
                var year3 = todate.substring(6, 10);
                var myTodateChk = new Date(year3, month3 - 1, date3);

                if (myStartDate > myTodateChk) {
                    InfoModal("BirthDate date must be less than todays Date ");
                    $('#txtDOB').val("");
                    return false;
                }
            }

            function CheckAnnDate() {
                var StartDate = document.getElementById("txtDOB").value; //for javascript
                var EndDate = document.getElementById("txtAnneversaryDate").value; //for javascript


                var date1 = StartDate.substring(0, 2);
                var month1 = StartDate.substring(3, 5);
                var year1 = StartDate.substring(6, 10);
                var myStartDate = new Date(year1, month1 - 1, date1);

                var date2 = EndDate.substring(0, 2);
                var month2 = EndDate.substring(3, 5);
                var year2 = EndDate.substring(6, 10);
                var myEndDate = new Date(year2, month2 - 1, date2);

                if (StartDate == "") {
                    InfoModal("Please enter Birthdate first");
                    $('#txtAnneversaryDate').val("");
                    return false;
                }

                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!

                var yyyy = today.getFullYear();
                if (dd < 10) {
                    dd = '0' + dd
                }
                if (mm < 10) {
                    mm = '0' + mm
                }
                var todate = dd + "/" + mm + "/" + yyyy;

                var date3 = todate.substring(0, 2);
                var month3 = todate.substring(3, 5);
                var year3 = todate.substring(6, 10);
                var myTodateChk = new Date(year3, month3 - 1, date3);

                var flag = "Red";

                if (myEndDate > myTodateChk) {
                    InfoModal("Anniversary date must be less than todays Date ");
                    $('#txtAnneversaryDate').val("");
                    flag = "Green";
                    return false;
                }


                if (myStartDate > myEndDate) {
                    InfoModal("Aniversary date must be greater than birthdate ");
                    $('#txtAnneversaryDate').val("");
                    flag = "Green";
                    return false;
                }



                //else {
                //    InfoModal("End Date is greater than Start date ");
                //    return false;
                //               }
            }



            function CheckJoiningDate() {

                var StartDate = document.getElementById("txtDateOfJoining").value; //for javascript

                var date1 = StartDate.substring(0, 2);
                var month1 = StartDate.substring(3, 5);
                var year1 = StartDate.substring(6, 10);
                var myStartDate = new Date(year1, month1 - 1, date1);

                var today = new Date();
                var dd = today.getDate();
                var mm = today.getMonth() + 1; //January is 0!

                var yyyy = today.getFullYear();
                if (dd < 10) {
                    dd = '0' + dd
                }
                if (mm < 10) {
                    mm = '0' + mm
                }
                var todate = dd + "/" + mm + "/" + yyyy;

                var date3 = todate.substring(0, 2);
                var month3 = todate.substring(3, 5);
                var year3 = todate.substring(6, 10);
                var myTodateChk = new Date(year3, month3 - 1, date3);

                if (myStartDate > myTodateChk) {
                    InfoModal("Joining date must be less than todays Date ");
                    $('#txtDateOfJoining').val("");
                    return false;
                }
            }

        }



        function FnChkAge(Age) {

            if (document.getElementById("<%=ddlAge.ClientID %>").value == "7") {
                if (parseInt(Age) <= 0) {
                    InfoModal('Age should be greater than zero');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
                if (parseInt(Age) > 150) {
                    InfoModal('Age should be less than 150');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
            }
            if (document.getElementById("<%=ddlAge.ClientID %>").value == "8") {
                var Result = parseFloat(Age) / 12;
                if (parseFloat(Result) <= 0) {
                    InfoModal('Age should be greater than zero');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
                if (parseInt(Result) > 150) {
                    InfoModal('Age should be less than 150');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
            }
            if (document.getElementById("<%=ddlAge.ClientID %>").value == "9") {
                var Result = parseFloat(Age) / 365;
                if (parseFloat(Result) <= 0) {
                    InfoModal('Age should be greater than zero');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
                if (parseInt(Result) > 150) {
                    InfoModal('Age should be less than 150');
                    document.getElementById("<%=txtDOB.ClientID %>").value = '';
                    document.getElementById("<%=ddlAge.ClientID %>").value = "7";
                    document.getElementById("<%=txtAge.ClientID %>").value = ''
                    return false;
                }
            }

        }


        function FnCHKEmpMachibeID(object) {
            if (object.value == '') {
                //InfoModal('Please Enter Employee Machine Id');
                return false;
            }

            else {

                var output = '';
                $.ajax({
                    type: "POST",
                    url: "frm_Org_AddEmployee.aspx/FnCheckEmpMachineID",
                    data: '{EmpMachineId: ' + object.value + '}',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    async: false,
                    success: function (result) {
                        output = result.d;
                    },
                    error: function failCallBk(XMLHttpRequest, textStatus, errorThrown) {
                    }
                });
                if (output == object.value) {
                    object.value = '';
                    InfoModal('Employee Machine Id Already Exists');
                    return false;
                }
            }
        }





        function ValidateForm() {
            var ddlmodule = document.getElementById("<%=ddlModuleName.ClientID%>").value;
            var ddldept = document.getElementById("<%=ddlDepartmentName.ClientID%>").value;
            var ddldesi = document.getElementById("<%=ddlDesiganationName.ClientID%>").value;

            if (ddlmodule == "") {
                InfoModal('Please Select Module Name');
                return false;
            }
            if (ddldept == "") {
                InfoModal('Please Select Department Name');
                return false;
            }
            if (ddldesi == "") {
                InfoModal('Please Select Designation Name');
                return false;
            }
        }



        function GetBirthDateondob() {
            var DOB = document.getElementById("<%=txtDOB.ClientID %>").value;
            var dateString = document.getElementById("<%=txtDOB.ClientID %>").value;
            ArrDob = dateString.split('/');
            var myDate = new Date(ArrDob[2], ArrDob[1] * 1 - 1, ArrDob[0]);
            var today = new Date();
            if (myDate > today) {
                document.getElementById("<%=txtAge.ClientID %>").value = '';
                document.getElementById("<%=txtDOB.ClientID %>").value = '';
                InfoModal('You cannot enter a date in the future!.');
                return false;
            }
            if (DOB.value != '') {
                now = new Date()
                var txtValue = document.getElementById("<%=txtDOB.ClientID %>").value;
                if (txtValue != null)
                    dob = txtValue.split('/');
                if (dob.length === 3) {
                    born = new Date(dob[2], dob[1] * 1 - 1, dob[0]);
                    age = now.getFullYear() - born.getFullYear();
                    if (isNaN(age) || age < 0) {
                        document.getElementById("<%=txtAge.ClientID %>").value = '';
                        document.getElementById("<%=txtDOB.ClientID %>").value = '';
                        InfoModal('Age should be greater than zero');
                        return false;
                    }
                    else {
                        document.getElementById("<%=ddlAge.ClientID %>").value = "Year";
                        if (age <= 0) {
                            age = now.getMonth() - born.getMonth();
                            document.getElementById("<%=ddlAge.ClientID %>").value = "Month";
                             if (age <= 0) {
                                 document.getElementById("<%=ddlAge.ClientID %>").value = "Day";
                                age = now.getDate() - born.getDate();
                            }
                        }
                        document.getElementById("<%=txtAge.ClientID %>").value = age;
                    }
                }
            }
        }

        //--------------
        function GetBirthDate() {
            var Age = document.getElementById("<%=txtAge.ClientID %>").value;
             var BDate = new Date();
             var BirthDt = (BDate.getDate()) + "/" + (BDate.getUTCMonth() + 1) + "/" + (BDate.getFullYear());
             if (document.getElementById("<%=ddlAge.ClientID %>").value == "Year") {
                if (BDate.getDate() > Age) {
                    BirthDt = (BDate.getDate() - Age) + "/" + (BDate.getUTCMonth() + 1) + "/" + (BDate.getFullYear());
                }
                else {
                    var agem = Age - BDate.getDate();
                    var agef = 30;
                    if (agem <= 29) {
                        BirthDt = (30 - agem) + "/" + (BDate.getUTCMonth()) + "/" + (BDate.getFullYear());
                    }
                    else if (agem <= 59) {
                        BirthDt = (60 - agem) + "/" + (BDate.getUTCMonth() - 1) + "/" + (BDate.getFullYear());
                    }
                    else if (agem <= 89) {
                        BirthDt = (90 - agem) + "/" + (BDate.getUTCMonth() - 2) + "/" + (BDate.getFullYear());
                    }
                    else if (agem > 0) {
                        BirthDt = (agef - agem) + "/" + (BDate.getUTCMonth()) + "/" + (BDate.getFullYear());
                    }
                    else {
                        BirthDt = (BDate.getDate()) + "/" + (BDate.getUTCMonth()) + "/" + (BDate.getFullYear());
                    }
                }
                document.getElementById("<%=txtDOB.ClientID %>").value = BirthDt;
            }
            else if (document.getElementById("<%=ddlAge.ClientID %>").value == "Month") {
                if ((BDate.getMonth() + 1) > Age) {
                    BirthDt = (BDate.getDate()) + "/" + ((BDate.getMonth() + 1) - Age) + "/" + (BDate.getFullYear());
                }
                else {
                    var agem = Age - BDate.getUTCMonth() - 1;
                    var agef = 12;
                    if (agem <= 11) {
                        BirthDt = (BDate.getDate()) + "/" + (12 - agem) + "/" + (BDate.getFullYear() - 1);
                    }
                    else if (agem <= 23) {
                        BirthDt = (BDate.getDate()) + "/" + (24 - agem) + "/" + (BDate.getFullYear() - 2);
                    }
                    else if (agem <= 35) {
                        BirthDt = (BDate.getDate()) + "/" + (36 - agem) + "/" + (BDate.getFullYear() - 3);
                    }
                    else if (agem > 0) {
                        BirthDt = (BDate.getDate()) + "/" + (agef - agem) + "/" + (BDate.getFullYear() - 1);
                    }
                    else { BirthDt = (BDate.getDate()) + "/" + agef + "/" + (BDate.getFullYear() - 1); }
                }
                document.getElementById("<%=txtDOB.ClientID %>").value = BirthDt;

            }
            else {
                BirthDt = (BDate.getDate()) + "/" + (BDate.getUTCMonth() + 1) + "/" + (BDate.getFullYear() - Age);
                if (Age >= 1) {
                    document.getElementById("<%=txtDOB.ClientID %>").value = BirthDt;
                }
                else {
                    document.getElementById("<%=txtDOB.ClientID %>").value = "";
                }
            }
        document.getElementById("<%=txtDOB.ClientID %>").value = '';
             return FnChkAge(Age);
         }


    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:ScriptManagerProxy ID="ScriptManagerProxy2" runat="server"></asp:ScriptManagerProxy>
    <asp:UpdatePanel ID="UpAddEmployee" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="bs-example">
                <div class="form-horizontal">
                    <asp:Panel ID="pnlAdd" Visible="false" runat="server">

                       

                        <div id="divCol" runat="server" class="box box-default box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Personal Information</h3>
                                <div class="box-tools pull-left">
                                    <button id="btnDemographic" runat="server" type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i id="iCoConInfoRout" runat="server" class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <asp:Panel ID="pnlAddDisease" runat="server">

                                        <div class="form-horizontal">
                                            <div class="col-sm-12">


                                                <div class="form-group">
                                                    <asp:Label ID="lblEmpCode" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Employee Code" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtEmpCode" required="readonly" TabIndex="1" runat="server" CssClass="form-control" placeholder="Enter Code"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtEmpCode" runat="server" TargetControlID="txtEmpCode"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" />
                                                    </div>

                                                    <asp:Label ID="lblInitial" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Initial" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlinitial" AutoPostBack="true" required="" TabIndex="2" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlinitial_SelectedIndexChanged">
                                                            <asp:ListItem Value="">--select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>


                                                <div class="form-group">
                                                    <asp:Label ID="lblGender" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Gender" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlGender" required="" TabIndex="3" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                            <%-- <asp:ListItem Value="Male">Male</asp:ListItem>
                                     <asp:ListItem Value="Female">Female</asp:ListItem>--%>
                                                            <%--  <asp:ListItem Value="Other">Other</asp:ListItem>--%>
                                                        </asp:DropDownList>
                                                    </div>

                                                    <asp:Label ID="lblFirstName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="First Name" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">

                                                        <asp:TextBox ID="txtFirstName" required="readonly" TabIndex="4" runat="server" CssClass="form-control" placeholder="Enter name"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtFirstName" runat="server" TargetControlID="txtFirstName"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ . " />
                                                    </div>
                                                </div>


                                                <div class="form-group">
                                                    <asp:Label ID="lblMiddleName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Middle Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtMiddleName" runat="server" TabIndex="5" CssClass="form-control" placeholder="Enter Middle Name"></asp:TextBox>
                                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtMiddleName" runat="server" TargetControlID="txtMiddleName"
                                    ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ" />--%>
                                                    </div>

                                                    <asp:Label ID="lblLastName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Last Name" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtLastName" required="" TabIndex="6" runat="server" CssClass="form-control" placeholder="Enter Last name"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtLastName" runat="server" TargetControlID="txtLastName"
                                                            ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ ." />
                                                    </div>
                                                </div>


                                                <div class="form-group">
                                                    <asp:Label ID="lblFatherName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Father/Husband Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtFatherName" runat="server" TabIndex="7" CssClass="form-control" placeholder="Enter Father Name"></asp:TextBox>
                                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtMiddleName" runat="server" TargetControlID="txtMiddleName"
                                    ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ" />--%>
                                                    </div>

                                                    <asp:Label ID="lblAge" Style="text-align: left" runat="server" CssClass="col-sm-2 control-label" Text="Age" Font-Bold="true"></asp:Label>
                                                    <div class="col-sm-2">
                                                        <asp:TextBox ID="txtAge" MaxLength="3" TabIndex="8" runat="server" CssClass="form-control" placeholder="Enter Age"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtAge"
                                                            ValidChars="0123456789 . " />
                                                    </div>
                                                    <div class="col-sm-2 ">
                                                        <asp:DropDownList ID="ddlAge" onchange="GetBirthDate()" TabIndex="9" runat="server" CssClass="form-control">
                                                            <%--<asp:ListItem Value="">--Select--</asp:ListItem>--%>
                                                            <asp:ListItem Value="Year">Years</asp:ListItem>
                                                            <asp:ListItem Value="Month">Month</asp:ListItem>
                                                            <asp:ListItem Value="Day">Day</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="form-group">

                                                    <asp:Label ID="lblBllodGroup" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Blood Group" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlBloodGroup" TabIndex="10" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblNationality" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Nationality" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlNationality" AutoPostBack="true" TabIndex="11" OnSelectedIndexChanged="ddlNationality_SelectedIndexChanged" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>

                                                </div>

                                                <div class="form-group">

                                                    <asp:Label ID="lblState" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="State" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlState" AutoPostBack="true" TabIndex="12" OnSelectedIndexChanged="ddlState_SelectedIndexChanged" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblCity" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="City" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlCity" AutoPostBack="true" TabIndex="13" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="lblVillage" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Location" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlVillage" aria-required="true" TabIndex="14" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblMaritalStatus" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Marital Status" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlMaritalStatus" aria-required="true" TabIndex="15" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Married">Married</asp:ListItem>
                                                            <asp:ListItem Value="UnMarried">UnMarried</asp:ListItem>
                                                            <asp:ListItem Value="Widow">Widow</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="lblPassportNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Passport No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtPasportNo" runat="server" TabIndex="16" CssClass="form-control" placeholder="Enter Passport No"></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblDrivingNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Driving Lic No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtDrivingLicNo" runat="server" TabIndex="17" CssClass="form-control" placeholder="Enter Driving Lic No"></asp:TextBox>
                                                    </div>

                                                </div>





                                                <asp:UpdatePanel runat="server" UpdateMode="Conditional" ID="upDate">
                                                    <ContentTemplate>


                                                        <div class="form-group requiredstar">
                                                            <asp:Label ID="lblDOF" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Date Of Birth" Font-Bold="true"></asp:Label>
                                                            <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                                <asp:TextBox ID="txtDOB" onchange="GetBirthDateondob();" runat="server" TabIndex="18" CssClass="form-control" placeholder="Select DOB"></asp:TextBox>
                                                            </div>


                                                            <asp:Label ID="lblAnneversaryDate" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Aniversary Date" Font-Bold="true"></asp:Label>
                                                            <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">

                                                                <asp:TextBox ID="txtAnneversaryDate" TabIndex="19" runat="server" CssClass="form-control" placeholder="Select Aniversary Date"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </ContentTemplate>
                                                </asp:UpdatePanel>

                                                <div class="form-group requiredstar">


                                                    <asp:Label ID="lblEmail" required="" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Email" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtEmail" TabIndex="20" pattern="[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?" title="Ex. example@gmail.com" runat="server" CssClass="form-control" placeholder="Enter email"></asp:TextBox>
                                                    </div>


                                                    <asp:Label ID="Label3" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Aadhar Card No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtAadarCardNo" MaxLength="20" TabIndex="19" runat="server" CssClass="form-control" placeholder="Enter Aadhar Card No"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtAadarCardNo" runat="server" TargetControlID="txtAadarCardNo" ValidChars="0123456789 " />
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>




                        <div id="div1" runat="server" class="box box-default box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Contact Information</h3>
                                <div class="box-tools pull-left">
                                    <button id="Button1" runat="server" type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i id="i1" runat="server" class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <asp:Panel ID="pnlContact" runat="server">

                                        <div class="form-horizontal">
                                            <div class="col-sm-12">

                                                <div class="form-group">
                                                    <asp:Label ID="lblAddress" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Permanent Address" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtAddress" runat="server" TabIndex="21" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Permanent Address" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblMobileNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Mobile No." Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtMobileNo" required="" TabIndex="22" MaxLength="15" runat="server" CssClass="form-control" placeholder="Enter Mobile No"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtMobileNo" runat="server" TargetControlID="txtMobileNo"
                                                            ValidChars="+0123456789" />
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Label ID="lblCorrAddres" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Corresponding Address" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtCorreAddes" runat="server" TabIndex="23" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Corresponding Address" TextMode="MultiLine"></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblCorrMo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Alternate No." Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtCorrMoNum" TabIndex="24" MaxLength="15" runat="server" CssClass="form-control" placeholder="Enter Alternate No"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server" TargetControlID="txtMobileNo"
                                                            ValidChars="+0123456789" />
                                                    </div>
                                                </div>



                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>


                        <div id="div2" runat="server" class="box box-default box-solid">
                            <div class="box-header with-border">
                                <h3 class="box-title">Official Information</h3>
                                <div class="box-tools pull-left">
                                    <button id="Button2" runat="server" type="button" class="btn btn-box-tool" data-widget="collapse">
                                        <i id="i2" runat="server" class="fa fa-minus"></i>
                                    </button>
                                </div>
                            </div>
                            <div class="box-body">
                                <div class="row">
                                    <asp:Panel ID="Panel1" runat="server">

                                        <div class="form-horizontal">
                                            <div class="col-sm-12">

                                                <div class="form-group">
                                                    <asp:Label ID="lblDateOfJoining" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Date Of Joining" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtDateOfJoining" runat="server" TabIndex="25" CssClass="form-control" placeholder="Select Date Of Joining"></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblEmpType" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Employee Type" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlEmpType" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Contract">Contract</asp:ListItem>
                                                            <asp:ListItem Value="Permanent">Permanent</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="lblBranchName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Branch" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlBranchName" required="readonly" autofocus="true" TabIndex="26" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>

                                                    </div>

                                                    <asp:Label ID="lblModule" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Module" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlModuleName" required="" TabIndex="27" aria-required="true" aria-invalid="true" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlModuleName_SelectedIndexChanged" CssClass="form-control chzn-select">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>

                                                <div class="form-group">
                                                    <asp:Label ID="lblDepartmentName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Department" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlDepartmentName" required="" TabIndex="28" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control chzn-select" OnSelectedIndexChanged="ddlDepartmentName_SelectedIndexChanged">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>


                                                    <asp:Label ID="lbDesiganationName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Designation" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlDesiganationName" required="" TabIndex="29" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control chzn-select">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Label ID="lblShiftName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Shift Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlShiftName" TabIndex="40" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                                            <asp:ListItem Value="Evening">Evening</asp:ListItem>
                                                            <asp:ListItem Value="Morning Shift">Morning Shift</asp:ListItem>
                                                            <asp:ListItem Value="Night Shift">Night Shift</asp:ListItem>
                                                            <asp:ListItem Value="General Shift">General Shift</asp:ListItem>
                                                            <asp:ListItem Value="Rotation Shift">Rotation Shift</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblDatePF" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Date Of Joining PF" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtDatePF" runat="server" TabIndex="41" CssClass="form-control" placeholder="Select Date Of Joining PF"></asp:TextBox>
                                                    </div>


                                                </div>
                                                <%--Shobhit--%>
                                                <div class="form-group">
                                                    <asp:Label ID="lbleducation" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Education" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txteducation" runat="server" MaxLength="300" TabIndex="61" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Education"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txteducation"
                                                            ValidChars="0123456789 QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm(){}[]<>#':;,./ \ -@$%&*" />
                                                    </div>
                                                    <asp:Label ID="lbluan" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="UAN" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtuan" TabIndex="62" MaxLength="300" runat="server" CssClass="form-control" placeholder="Enter UAN"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtuan"
                                                            ValidChars="0123456789 QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm(){}[]<>#':;, ./ \ -@$%&*" />
                                                    </div>
                                                </div>
                                                <%--Shobhit--%>
                                                <div class="form-group">
                                                    <asp:Label ID="lblESICAccNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="ESIC Account No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtESICAccNo" runat="server" TabIndex="42" CssClass="form-control SetfalseDragTextbox" placeholder="Enter ESIC Account No"></asp:TextBox>
                                                    </div>
                                                    <asp:Label ID="lblPFAccNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="PF Account No." Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtPFAccNO" TabIndex="43" MaxLength="20" runat="server" CssClass="form-control" placeholder="Enter PF Account No"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtPFAccNO"
                                                            ValidChars="0123456789 QWERTYUIOPASDFGHJKLZXCVBNMqwertyuiopasdfghjklzxcvbnm / \ -" />
                                                    </div>
                                                </div>


                                                <div class="form-group">
                                                    <asp:Label ID="lblBankName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Bank Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlBankName" TabIndex="44" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--select--</asp:ListItem>

                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblBankAccNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Bank Account No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtBankAccNo" runat="server" TabIndex="45" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Bank Account No"></asp:TextBox>
                                                    </div>


                                                </div>

                                                <div class="form-group">
                                                    <asp:Label ID="lblPanNo" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="PAN No" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtPanNo" runat="server" TabIndex="46" CssClass="form-control SetfalseDragTextbox" placeholder="Enter PAN No"></asp:TextBox>
                                                    </div>

                                                    <asp:Label ID="lblPolicyname" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Policy Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlPolicyName" TabIndex="47" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>

                                                <div class="form-group">
                                                    <asp:Label ID="lblFingrPrint" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Finger Print ID" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtFingrPrint" runat="server" TabIndex="48" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Finger Print ID"></asp:TextBox>
                                                    </div>

                                                    <asp:Label ID="lblWorkingStatus" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Working Status" Font-Bold="true"></asp:Label>
                                                    <div class="col-sm-4">
                                                        <asp:RadioButton ID="rbActive" Checked="true" GroupName="Status" Text="Active" runat="server" />
                                                        <asp:RadioButton ID="rbDeActive" GroupName="Status" Text="DeActive" runat="server" />

                                                        <asp:RadioButton ID="rbonlineAccess" Checked="true" GroupName="OnlineAcess" Text="Online Acess" runat="server" />
                                                        <asp:RadioButton ID="rbnoonlineAccess" GroupName="OnlineAcess" Text="No Acess" runat="server" />
                                                    </div>
                                                </div>


                                                <div class="form-group">

                                                    <asp:Label ID="lblEmpMachineId" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Employee Machine ID" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtEmpmachineId" onblur="return FnCHKEmpMachibeID(this);" runat="server" MaxLength="8" TabIndex="49" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Employee Machine ID"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_Machine" TargetControlID="txtEmpmachineId" runat="server" ValidChars="0123456789" />

                                                    </div>
                                                    <asp:Label ID="lblReportEmpName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Reporting Emp. Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlReportEmpName" TabIndex="50" runat="server" CssClass="form-control chzn-select">
                                                            <asp:ListItem Value="">--select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>





                                                </div>
                                                <div class="form-group">
                                                    <asp:Label ID="lblSalary" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Salary Type" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlsalary" OnSelectedIndexChanged="ddlsalary_SelectedIndexChanged" AutoPostBack="true" TabIndex="51" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="0">--select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <asp:Label ID="lblsalMonthYear" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Monthly/Yearly" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtsalmonthyear" runat="server" MaxLength="9" TabIndex="52" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Salary Monthly/Yearly"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtsalmonthyear" runat="server" TargetControlID="txtsalmonthyear"
                                                            ValidChars="0123456789 . " />

                                                    </div>


                                                </div>

                                                <div class="form-group">

                                                    <asp:Label ID="lblBankAccName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Bank Account Name" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtBankAccName" runat="server" TabIndex="53" CssClass="form-control SetfalseDragTextbox" placeholder="Enter Bank Account Name"></asp:TextBox>
                                                    </div>

                                                    <asp:Label ID="lblRemark" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Modify Reason" Font-Bold="true"></asp:Label>
                                                    <div id="divModifyReason" runat="server" class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:TextBox ID="txtRemark" required="readonly" TabIndex="54" runat="server" CssClass="form-control SetfalseDragTextbox" placeholder="Enter any update" TextMode="MultiLine"></asp:TextBox>
                                                    </div>

                                                </div>




                                                <div class="form-group">
                                                    <asp:Label ID="Label1" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Desire Level" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:UpdatePanel runat="server">
                                                            <ContentTemplate>
                                                                <asp:RadioButton ID="rbLvl1" Text="Level1" GroupName="Level" runat="server" Checked="true" TabIndex="52" />&nbsp;
                                        <asp:RadioButton ID="rbLvl2" Text="Level2" GroupName="Level" runat="server" />&nbsp;
                                        <asp:RadioButton ID="rbLvl3" Text="Level3" GroupName="Level" runat="server" />
                                                                <asp:RadioButton ID="rbLvl4" Text="Level4" GroupName="Level" runat="server" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>

                                                    <asp:Label ID="Label2" Style="text-align: left" runat="server" CssClass="col-md-1 control-label" Text="Category" Font-Bold="true"></asp:Label>
                                                    <div class="col-md-5">
                                                        <asp:UpdatePanel ID="UpdateRadio" runat="server">
                                                            <ContentTemplate>
                                                                <asp:RadioButton ID="rbStaff" Text="Staff" OnCheckedChanged="rbStaff_CheckedChanged" AutoPostBack="true" runat="server" GroupName="Category" Checked="true" TabIndex="53" />&nbsp;
                                        <asp:RadioButton ID="rbReferral" OnCheckedChanged="rbReferral_CheckedChanged" AutoPostBack="true" Text="Referral" runat="server" GroupName="Category" />&nbsp;
                                        <asp:RadioButton ID="rbCollCenter" OnCheckedChanged="rbCollCenter_CheckedChanged" AutoPostBack="true" Text="Collection Center" runat="server" GroupName="Category" />
                                                                <asp:RadioButton ID="rbConDoctor" OnCheckedChanged="rbConDoctor_CheckedChanged" AutoPostBack="true" Text="Clinical Staff" runat="server" GroupName="Category" />
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>

                                                <div id="divCenter" runat="server" class="form-group">
                                                    <div class="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label">
                                                    </div>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                    </div>


                                                    <asp:Label ID="lblCenter" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Center" Font-Bold="true"></asp:Label>
                                                    <div class="requiredstar col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                        <asp:DropDownList ID="ddlCenter" TabIndex="54" required="" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                            <asp:ListItem Value="">--Select--</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>

                                                </div>


                                                <div id="divDoc" runat="server" class="form-group">
                                                    <div class="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label">
                                                    </div>
                                                    <div class="col-xs-10 col-sm-4 col-md-4 col-lg-4">
                                                    </div>


                                                    <asp:Label ID="lblDoc" Style="text-align: left" runat="server" CssClass="col-sm-2 control-label" Text="Type" Font-Bold="true"></asp:Label>
                                                    <div class="col-sm-4 requiredstar" runat="server" id="DoctrStar">

                                                        <asp:DropDownList ID="ddlDoc" TabIndex="55" required="" autofocus="true" aria-required="true" aria-invalid="true" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <%--   <div class="col-sm-1">
                                   <span style="font-size: x-large; color: red">* </span>--%>

                                                        <%--    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Please select" ControlToValidate="ddlDoc"  InitialValue="0">

                                </asp:RequiredFieldValidator>--%>
                                                    </div>

                                                </div>
                                                <hr />
                                                <div class="form-group">
                                                    <asp:Label ID="Label7" Style="text-align: left" runat="server" CssClass="control-label col-xs-3" Text="Upload Employee Photo" Font-Bold="true"></asp:Label>
                                                    <div class="col-xs-3">
                                                        <asp:UpdatePanel ID="upimgEmpPhoto" UpdateMode="Conditional" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Image ID="imgEmpPhoto" AlternateText="Add Photo" runat="server" CssClass="img-bordered img-responsive" Height="100px" Width="100px" />
                                                                <asp:FileUpload ID="flimgEmpPhoto" runat="server" TabIndex="56" />
                                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" formnovalidate="formnovalidate" OnClick="btnUpload_Click" TabIndex="57" />
                                                                <asp:Label ID="lblChooseFile" runat="server" CssClass="control-label" Font-Bold="true"></asp:Label>

                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                    <asp:Label ID="Label8" Style="text-align: left" runat="server" CssClass="control-label col-xs-3" Text="Upload Electronic Signature" Font-Bold="true"></asp:Label>

                                                    <div class="col-xs-3">
                                                        <asp:UpdatePanel ID="upimgEmpSign" UpdateMode="Conditional" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Image ID="imgEmpSign" AlternateText="Add Digital Sign" runat="server" CssClass="img-bordered img-responsive" Height="100px" Width="100px" />
                                                                <asp:FileUpload ID="flimgEmpSign" runat="server" TabIndex="58" />
                                                                <asp:Button ID="btnUploadSign" runat="server" Text="Upload" formnovalidate="formnovalidate" OnClick="btnUploadSign_Click" TabIndex="59" />
                                                            </ContentTemplate>
                                                            <Triggers>
                                                                <asp:PostBackTrigger ControlID="btnUploadSign" />
                                                            </Triggers>
                                                        </asp:UpdatePanel>
                                                    </div>
                                                </div>


                                                <hr />


                                                <div class="form-group">
                                                    <asp:Label ID="lblComplaintDescrip" Style="text-align: left" runat="server" Font-Bold="true" Text="Doctor Details" CssClass="control-label col-xs-2"></asp:Label>
                                                    <div class="col-md-10">
                                                        <CKEditor:CKEditorControl ID="CKDocDetails" RemovePlugins="bidi,blockquote,smiley,save,specialchar,print,link,Unlink,newpage,templates,find,replace,div,,showblocks,preview,printnewpage,pagebreak,forms,horizontalrule,htmldataprocessor,iframe,indent,flash,about,a11yhelp" runat="server" TabIndex="2" Height="80" BasePath="~/ckeditor" ClientIDMode="Static">
                                                        </CKEditor:CKEditorControl>
                                                    </div>
                                                </div>



                                            </div>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </div>

                        <div class="form-group">

                            <div class="col-xs-offset-4 col-xs-6">

                                <asp:Button ID="btnSave" CssClass="btn btn-success" runat="server" Text="Save" OnClick="btnSave_Click" TabIndex="60" OnClientClick="return ValidateForm();" />
                                <asp:Button ID="btnEdit" CssClass="btn btn-success" runat="server" Text="Edit" formnovalidate="formnovalidate" OnClick="btnEdit_Click" />
                                <asp:Button ID="btnClear" CssClass="btn btn-primary" runat="server" Text="Clear" formnovalidate="formnovalidate" OnClick="btnClear_Click" />
                                <asp:Button ID="btnCancel" CssClass="btn btn-default" runat="server" Text="Cancel" formnovalidate="formnovalidate" OnClick="btnCancel_Click" />
                            </div>
                        </div>
                    </asp:Panel>

                    <asp:Panel ID="pnlEmployeegrdiview" runat="server" Visible="true">
                        <div class="bs-example">
                            <div class="form-horizontal">
                                <div class="form-group">
                                    <asp:Label ID="lblCode" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Code" Font-Bold="true"></asp:Label>
                                    <div class="col-xs-10 col-sm-3">
                                        <asp:TextBox ID="txtCode" runat="server" autofocus="true" CssClass="form-control" placeholder="Enter center code"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtCode" TargetControlID="txtCode" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789" />--%>
                                    </div>
                                    <asp:Label ID="lblName" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="First Name" Font-Bold="true"></asp:Label>
                                    <div class="col-xs-10 col-sm-3">
                                        <asp:TextBox ID="txtName" runat="server" CssClass="form-control" placeholder="Enter First name"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtName" TargetControlID="txtName" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ" />--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="lblDsig" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Designation" Font-Bold="true"></asp:Label>
                                    <div class="col-xs-10 col-sm-3">
                                        <asp:DropDownList ID="ddlDesignation" runat="server" CssClass="form-control chzn-select">
                                            <asp:ListItem Value="0">--select--</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:Label ID="lbllname" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Last Name" Font-Bold="true"></asp:Label>
                                    <div class="col-xs-10 col-sm-3">
                                        <asp:TextBox ID="txtlstname" runat="server" CssClass="form-control" placeholder="Enter Last name"></asp:TextBox>
                                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FTE_txtName" TargetControlID="txtName" runat="server" ValidChars="abcdefghijklmnopqrstuvwxyz ABCDEFGHIJKLMNOPQRSTUVWXYZ" />--%>
                                    </div>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="Label4" Style="text-align: left" runat="server" CssClass="col-xs-10 col-sm-2 col-md-2 col-lg-2 control-label" Text="Category" Font-Bold="true"></asp:Label>
                                    <div class="col-xs-10 col-sm-3">
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-control chzn-select" AutoPostBack="true">
                                            <asp:ListItem Value="0">--Select--</asp:ListItem>
                                            <asp:ListItem Value="Staff">Staff</asp:ListItem>
                                            <asp:ListItem Value="Clinical Staff">Clinical Staff</asp:ListItem>
                                            <asp:ListItem Value="Referral">Referral</asp:ListItem>

                                        </asp:DropDownList>
                                    </div>

                                </div>

                                <asp:Panel runat="server" ID="pnlPrint">
                                    <div class="form-group">
                                        <%--<div class="col-sm-2">
                                        </div>--%>
                                        <div class="col-sm-4">
                                            <asp:RadioButton ID="rbAll" Checked="true" runat="server" Text="All Employee" GroupName="OnlineType" CssClass="radio-inline" CausesValidation="true" />
                                            <asp:RadioButton ID="rbOnline" runat="server" Text="Online Employee" GroupName="OnlineType" CssClass="radio-inline" CausesValidation="true" />

                                        </div>
                                        <div class="col-sm-3">
                                            <asp:RadioButton ID="rbActiveSrch" Checked="true" runat="server" Text="Active" GroupName="WorkingStaus" CssClass="radio-inline" CausesValidation="true" />
                                            <asp:RadioButton ID="rbDeactiveSrch" runat="server" Text="Deactive" GroupName="WorkingStaus" CssClass="radio-inline" CausesValidation="true" />
                                        </div>

                                        <div class="col-sm-4">
                                            <asp:RadioButton ID="rbWithHeader" Checked="true" runat="server" Text="Print with header" GroupName="Header" CssClass="radio-inline" CausesValidation="true" />
                                            <asp:RadioButton ID="rbWithoutHeader" runat="server" Text="Print without header" GroupName="Header" CssClass="radio-inline" CausesValidation="true" />
                                        </div>
                                        <%-- <div class="col-sm-2">
                                        </div>--%>
                                    </div>
                                </asp:Panel>
                                <div class="form-group">
                                    <div class="col-sm-offset-3 col-xs-4  ">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClick="btnSearch_Click" />
                                        <asp:Button Text="Report" runat="server" ID="btnPrint" CssClass="btn btn-primary" OnClick="btnPrint_Click" />
                                        <asp:Button ID="btnClearSearch" runat="server" CssClass="btn btn-default" Text="Cancel" formnovalidate="formnovalidate" OnClick="btnClearSearch_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:LinkButton ID="lnkAddEmployee" runat="server" OnClick="lnkAddEmployee_Click">
                                            <img src="../Images/Add.png" title="Add" height="25" width="25" />
                     <span class="hidden-xs">Add</span>
                        </asp:LinkButton>

                        <asp:Label Text="" runat="server" CssClass="control-label" Font-Bold="true" ID="lblCount" Style="margin-left: 900px;" />
                        <br />
                        <%--<div class="box">
                            <div class="box-body">
                                <asp:Panel ScrollBars="Auto" runat="server">--%>
                        <div class="box">
                            <div class="box-body table-responsive">
                                <asp:UpdatePanel ID="upGrid" UpdateMode="Conditional" runat="server">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvAddEmployee" DataKeyNames="EmployeeId, InitialId, ModuleId, BranchId, DepartmentId, DesignationId,OriginalCategory,Gender,Address,CorreAddress" CssClass="table table-hover table-responsive mGrid" PageSize="10" AllowPaging="true" OnPageIndexChanging="gvAddEmployee_PageIndexChanging" EmptyDataText="No Data Found" runat="server" AutoGenerateColumns="false" OnRowCommand="gvAddEmployee_RowCommand" ShowHeaderWhenEmpty="true">
                                            <Columns>
                                                <%--         <asp:BoundField DataField="EmployeeId" HeaderText="EmpId" />--%>
                                                <asp:BoundField DataField="EmployeeCode" HeaderText="Code" />
                                                <asp:BoundField DataField="EmployeeName" HeaderText="Name" />
                                                <asp:BoundField ControlStyle-CssClass="hidden" DataField="FirstName" HeaderStyle-CssClass="hidden" HeaderText="First Name" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="MiddleName" HeaderText="Middle Name" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="LastName" HeaderText="Last Name" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="Gender" HeaderText="Gender" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField ControlStyle-CssClass="hidden" DataField="MobileNo" HeaderStyle-CssClass="hidden" HeaderText="MobileNo" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField ControlStyle-CssClass="hidden" DataField="EmailId" HeaderStyle-CssClass="hidden" HeaderText="Email Id" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField ControlStyle-CssClass="hidden" DataField="DatOfBirth" HeaderStyle-CssClass="hidden" HeaderText="DOB" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField ControlStyle-CssClass="hidden" DataField="AnneversaryDate" HeaderStyle-CssClass="hidden" HeaderText="Anneversary Date" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="Address" HeaderText="Address" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <%-- 10 --%>
                                                <asp:BoundField DataField="ModifyReason" HeaderText="Modify Reason" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="DesireLevel" HeaderText="Level" />
                                                <asp:BoundField DataField="Category" HeaderText="Category" />
                                                <%-- ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" --%>
                                                <asp:BoundField DataField="InitialName" HeaderText="Initial Name" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="ModuleName" HeaderText="Module" />
                                                <asp:BoundField DataField="BranchName" HeaderText="Branch" />
                                                <asp:BoundField DataField="DepartmentName" HeaderText="Department" />
                                                <asp:BoundField DataField="DesignationName" HeaderText="Designation" />
                                                <asp:BoundField DataField="Name" HeaderText="Gender" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />



                                                <asp:TemplateField HeaderText="Upload">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnUploadEmployee" runat="server" formnovalidate="formnovalidate" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="lnkbtnUploadEmployee">
                                                        <img src="../Images/upload.png" title="Upload" height="25" width="25"/> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="View/Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnModifyEmployee" runat="server" formnovalidate="formnovalidate" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="lnkbtnModifyEmployee">
                                            <img src="../Images/View.png" title="Edit" height="25" width="25"/> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- 21 --%>
                                                <asp:TemplateField HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnDeleteEmployee" runat="server" formnovalidate="formnovalidate" CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="lnkbtnDeleteEmployee" OnClientClick="return confirm('Are you sure you want to delete this Record ?');">
                                            <img src="../Images/Delete.png" title="Delete" height="25" width="25"/>
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="CollCenterId" HeaderText="CollCenterId" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="DoctorId" HeaderText="DoctorId" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />


                                                <asp:BoundField DataField="OrgFatherName" HeaderText="FatherName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="OrgAge" HeaderText="Age" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="AgeYMD" HeaderText="AgeYMD" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="BloodGroup" HeaderText="BloodGroup" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="Nationality" HeaderText="Nationality" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="State" HeaderText="State" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="City" HeaderText="City" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <%-- 31 --%>
                                                <asp:BoundField DataField="Village" HeaderText="Village" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="MaritalStatus" HeaderText="MaritalStatus" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="Passport" HeaderText="Passport" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="Driving" HeaderText="Driving" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="CorreAddress" HeaderText="CorreAddress" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="CorresMo" HeaderText="CorresMo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="DateOfJoining" HeaderText="DateOfJoining" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="EmployeeType" HeaderText="EmployeeType" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="ShiftName" HeaderText="ShiftName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="DOJPF" HeaderText="DOJPF" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <%-- 41 --%>
                                                <asp:BoundField DataField="ESICAccNo" HeaderText="ESICAccNo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="PFAccNo" HeaderText="PFAccNo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="BankName" HeaderText="BankName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="BankAccNo" HeaderText="BankAccNo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="PANNo" HeaderText="PANNo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="PolicyName" HeaderText="PolicyName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="FinPrintId" HeaderText="FinPrintId" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="WorkingStatus" HeaderText="WorkingStatus" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="ReportingEmpName" HeaderText="ReportingEmpName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="BankAccName" HeaderText="BankAccName" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />

                                                <%-- 51 --%>


                                                <asp:BoundField DataField="EmpMachineId" HeaderText="EmpMachineId" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="EmpSalaryId" HeaderText="EmpSalaryId" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="EmpSalary" HeaderText="Employee Salary" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="AadharCardNo" HeaderText="AadharCardNo" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="OnlineStatus" HeaderText="OnlineStatus" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="DocDetails" HeaderText="DocDetails" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="EmpPhotos" HeaderText="EmpPhotos" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />

                                                <%--Shobhit--%>
                                                <asp:BoundField DataField="Education" HeaderText="Education" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <asp:BoundField DataField="UAN" HeaderText="UAN" ControlStyle-CssClass="hidden" HeaderStyle-CssClass="hidden" ItemStyle-CssClass="hidden" />
                                                <%--Shobhit--%>
                                                <asp:TemplateField HeaderText="Generate Id">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="lnkbtnGenerateId" runat="server" ClientIDMode="Static"  CommandArgument="<%#((GridViewRow)Container).RowIndex%>" CommandName="lnkGenerateIdCard">
                                                        <img src="../Images/idCard.png" title="Generate Id Card" height="25" width="25"/> 
                                                        </asp:LinkButton>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>

                                            <HeaderStyle Wrap="false" />
                                            <PagerSettings Mode="NumericFirstLast" FirstPageText="First" LastPageText="Last" />
                                            <PagerStyle CssClass="GridviewPagination" HorizontalAlign="Right" />

                                        </asp:GridView>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                        </div>
                        <%--</asp:Panel>
                            </div>
                        </div>--%>
                    </asp:Panel>
                </div>
            </div>
             <div id="idprint">
    <div id="myModal" runat="server" class="modal fade" role="dialog">
        <div class="modal-dialog" style="width: 40rem;">
            <div class="modal-content">
                <div class="modal-header bg-aqua-gradient">
                    <button type="button" class="close"  data-dismiss="modal">&times;</button>
                    <div style="display:flex"> <asp:Image runat="server" ID="imgLogoForIdentity" CssClass="image img-thumbnail img-responsive" ImageUrl="~/Images/flowerimg.jpg" Height="80px" Width="80px" />
                     <h5><asp:Label runat="server" CssClass="text-center" ID="lblAddressForIdentity" Text="MIMHANS Neuroscience Hospital Meerut"></asp:Label></h5></div>
                </div>
                <div class="modal-body">
                    <div runat="server" id="divFrontEnd">
                    <table class="table no-border table-responsive table-condensed">
                       
                        <tr>
                            <th colspan="2">
                                <asp:Image runat="server" ID="EmpPhotoForIdentity" CssClass="image img-thumbnail img-responsive" ImageUrl="~/Images/flowerimg.jpg" Height="120px" Width="120px" /></th>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Label runat="server" ID="lblEmpNameForIdentity" Text="Dr.Vishal Marathe"></asp:Label>
                            </th>
                        </tr>
                        <tr>
                            <th colspan="2">
                                <asp:Label runat="server" ID="lblDesignationForIdentity" Text="MCA HOLDER"></asp:Label>
                            </th>
                        </tr>
                    </table>
                    <table  class="table table-responsive table-bordered table-striped">
                        <tr><td class="text-bold text-center">Emp ID :</td><td class="text-bold"><asp:Label runat="server" ID="lblEmpIdForIdentity" ></asp:Label></td></tr>
                        <tr><td class="text-bold text-center">D.O.J :</td><td class="text-bold"><asp:Label runat="server" ID="lblDOJForIdentity" ></asp:Label></td></tr>
                        <tr><td class="text-bold text-center">Blood Group:</td><td class="text-bold"><asp:Label runat="server" ID="lblBloodGroupForIdentity" ></asp:Label></td></tr>
                    </table>
                    <table class="table table-responsive no-border">
                        <tr>
                            <th><asp:Label runat="server" ID="lblDrNameForIdentity" Text="Dr. ANSHUMAN SHARMA"></asp:Label></th>
                        </tr>
                         <tr>
                            <th><asp:Label runat="server" ID="lblDrDesignationForIdentity" Text="MEDICAL DIRECTOR"></asp:Label></th>
                        </tr>
                         <tr>
                            <th><asp:Label runat="server" ID="lblDrAuthorizedSignatureForIdentity" Text="AUTHORIZED SIGNATORY"></asp:Label></th>
                        </tr>
                    </table>
                        </div>
                    <div runat="server" style="display:none" id="divBackEnd">
                        <h3><asp:Label runat="server" ID="lblHospitalNameForIdentityBackSide" Text="Mimhans"></asp:Label></h3>
                        <p class="text-bold">
                            <asp:Label runat="server" ID="lblHospitalAddressForIdentityBackSide" Text="
                                Neuroscience Hospital
                            281,283 Sector-1, Mangal
                            Pandey Nagar,Meerut 250004
                            Ph:9927005678,9837021937
                                "></asp:Label>
                           
                        </p>
                            <table  class="table table-responsive table-bordered table-striped">
                        <tr><td class="text-bold text-center">Emergency Contact No</td></tr>
                        <tr><td class="text-bold text-center"><asp:Label runat="server" ID="lblEmergencyAddressForIdentityBackSide"></asp:Label></td></tr>                   
                    </table>
                        <p class="text-bold">
                            <asp:Label runat="server" ID="lblNoteForIdentityBackSide" Text="
                            Note:- This Card Belongs To Our
                            Permanent Employee & If Found
                            Please Return To The Address
                                "></asp:Label>
                   
                        </p>
                    </div>
                </div>
                </div>
                <div class="modal-footer">
                    <button class="btn btn-default" id="btnFrontSide">Front Side</button>
                    <button class="btn btn-default" id="btnBackSide">Back Side</button>
                    <asp:button runat="server" class="btn btn-default" id="btnIdPrint" Text="Print" OnClick="btnIdPrint_Click"></asp:button>
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
        
    </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
    
<%-- 
EmpPhotoForIdentity1
lblEmpNameForIdentity1
lblDesignationForIdentity1
lblEmpIdForIdentity1
lblDOJForIdentity1
lblBloodGroupForIdentity1

lblDrNameForIdentity1
lblDrDesignationForIdentity1
lblDrAuthorizedSignatureForIdentity1

lblHospitalNameForIdentityBackSide

lblHospitalAddressForIdentityBackSide1
lblEmergencyAddressForIdentityBackSide1

lblNoteForIdentityBackSide1
    </div>--%>
    <script type="text/javascript">
        var FrontEnd = document.getElementById("btnFrontSide");
        var BackEnd = document.getElementById("btnBackSide");
        var FrontDiv = document.getElementById("divFrontEnd");
        var BackDiv = document.getElementById("divBackEnd");
        var myModal11 = document.getElementById("myModal");
        var btnIdPrint11 = document.getElementById("btnIdPrint");
        var lnkbtnGenerateId11 = document.getElementById("lnkbtnGenerateId");
        FrontEnd.onclick = function (e) {
            e.preventDefault();
            FrontDiv.style = "display:block";
            BackDiv.style = "display:none";
        }
        BackEnd.onclick = function (e) {
            e.preventDefault();
            BackDiv.style = "display:block";
            FrontDiv.style = "display:none";
        }
       
        //btnIdPrint11.onclick = function (e) {
        //    e.preventDefault();
        //    PrintDiv();
        //}
        //function PrintDiv() {
        //    var divContents = document.getElementById("idprint").innerHTML;
        //    var printWindow = window.open('', '', 'height=400,width=400');
        //    printWindow.document.write('<html><head><title>Print DIV Content</title>');
        //    printWindow.document.write('<link href="../Bootstrap/css/bootstrap.min.css" rel="stylesheet" />');
        //    printWindow.document.write('<style>#divBackEnd{display:block;}</style>');
        //    printWindow.document.write('</head><body >');
        //    printWindow.document.write(divContents);
        //    printWindow.document.write('</body></html>');
        //    printWindow.document.close();
        //    printWindow.print();
        //}
    </script>
</asp:Content>
