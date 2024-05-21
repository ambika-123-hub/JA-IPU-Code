<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="simulation_gamma.aspx.cs" Inherits="simulation_gamma.chi_sqr" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    <style type="text/css">
        body{                                   
    background-image: url(file:///C:/Ambika/simulation_gamma/simulation_gamma/blue-mermaid-lines-pattern.jpg); 
    }
        .style1
        {
            width: 4px;
        }
        .style2
        {
            height: 23px;
        }
        .style3
        {
            width: 4px;
            height: 23px;
        }
        .style4
        {
            background-color: #CCCCCC;
        }
        .style10
        {
            width: 125px;
        }
        .style12
        {
            width: 268435456px;
        }
        .style15
        {
            width: 102px;
        }
        .style16
        {
            height: 25px;
        }
        .style17
        {
            width: 4px;
            height: 25px;
        }
        .style18
        {
            width: 153px;
        }
        .style19
        {
            height: 61px;
        }
        .style20
        {
            width: 4px;
            height: 61px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="background-color: #CCCCCC" align="center" title="AmbikaTundwal">
    
        &nbsp;&nbsp;<table align="center" bgcolor="White" 
            style="background-color: #CCCCCC" frame="box">
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8">
                                <asp:Button ID="Btn_rand" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Random number" Width="181px" 
                                    onclick="Btn_rand_Click" style="background-color: #CCCCCC" />
                                <asp:Button ID="Btn_pos" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Source Co-ordinates" 
                                    onclick="Btn_pos_Click" Width="181px" style="background-color: #CCCCCC" />
                                <asp:Button ID="Btn_dir" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Direction Cosines" Width="170px" 
                                    onclick="Btn_dir_Click" style="background-color: #CCCCCC" />
                                <asp:Button ID="Btn_int" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Interaction Points" 
                                    Width="180px" onclick="Btn_int_Click" style="background-color: #CCCCCC" />
                            </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="9" align="center" rowspan="2" style="background-color: #CCCCCC" 
                    bgcolor="#CCCCCC">
                    <asp:Label ID="Label11" runat="server" Font-Bold="True" 
                        Font-Size="X-Large" ForeColor="Black" 
                        Text="JA-IPU (A Monte Carlo Code of Radiation Damage)" BorderColor="#CCCCCC" 
                        BorderStyle="Outset" Width="697px"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style2">
                    </td>
                <td class="style3">
                    </td>
                <td class="style2">
                    </td>
                <td class="style2">
                    </td>
            </tr>
            <tr>
                <td>
                                &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                                &nbsp;</td>
            </tr>
            <tr>
                <td>
                                <asp:Button ID="Btn_cross" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="photon cross-sections" Width="198px" 
                                    onclick="Btn_cross_Click" 
                                    style="background-color: #CCCCCC; height: 26px;" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_attenuation" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Attenuation Coefficient" 
                                    Width="198px" onclick="Btn_attenuation_Click" 
                                    style="background-color: #CCCCCC" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_eElastic_cross" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="electron elastic cross-section" 
                                    Width="198px" onclick="Btn_eElastic_cross_Click" 
                                    style="background-color: #CCCCCC" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_e_stp" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="stopping power of electron" 
                                    Width="198px" onclick="Btn_e_stp_Click" 
                                    style="background-color: #CCCCCC" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_atm_cross" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="atom atom cross-section" 
                                    Width="198px" onclick="Btn_atm_cross_Click" 
                                    style="background-color: #CCCCCC" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_atm_e_loss" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="energy loss by charged particle" 
                                    Width="198px" onclick="Btn_atm_e_loss_Click" 
                                    style="background-color: #CCCCCC" />
                            </td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <table style="width:80%;" bgcolor="#CCCCCC" frame="box">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Lbl_element" runat="server" Font-Bold="True" ForeColor="Black" 
                                    Text="Target element"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:DropDownList ID="DDL_element" runat="server" 
                                    onselectedindexchanged="DDL_element_SelectedIndexChanged" 
                                    AutoPostBack="True" Height="22px" Width="128px">
                                    <asp:ListItem Selected="True">Choose element...</asp:ListItem>
                                    <asp:ListItem>C</asp:ListItem>
                                    <asp:ListItem>Al</asp:ListItem>
                                    <asp:ListItem>Si</asp:ListItem>
                                    <asp:ListItem>Ni</asp:ListItem>
                                    <asp:ListItem>V</asp:ListItem>
                                    <asp:ListItem>Fe</asp:ListItem>
                                    <asp:ListItem>Cu</asp:ListItem>
                                    <asp:ListItem>Nb</asp:ListItem>
                                    <asp:ListItem>Pb</asp:ListItem>
                                    <asp:ListItem>U</asp:ListItem>
                                    <asp:ListItem>SiC</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td colspan="4">
                                <asp:Label ID="Lbl_atom_no" runat="server" Font-Bold="True" ForeColor="Black" 
                                    Text="Atomic Number (Z)"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_Z" runat="server" Enabled="False" Width="110px" ></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Lbl_atom_wt" runat="server" Font-Bold="True" ForeColor="Black" 
                                    Text="Atomic Weight (A)"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:TextBox ID="Txt_atom_wt" runat="server" Enabled="False" Width="128px" 
                                     ></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:Label ID="Lbl_u" runat="server" 
                                    
                                    
                                    
                                    Text="Attenuation Coefficient (µ&lt;sub&gt;max&lt;/sub&gt;)(cm&lt;sup&gt;-1&lt;/sup&gt;) " Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_u" runat="server" Enabled="False" Width="110px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label40" runat="server" Text="Energy of Photon" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:DropDownList ID="DDL_E" runat="server" 
                                    onselectedindexchanged="DDL_E_SelectedIndexChanged" 
                                    AutoPostBack="True" Height="22px" Width="130px" style="margin-bottom: 0px">
                                    <asp:ListItem>Choose Energy...</asp:ListItem>
                                    <asp:ListItem Value="0.01">0.01 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.02">0.02 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.03">0.03 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.04">0.04 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.05">0.05 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.06">0.06 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.07">0.07 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.08">0.08 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.09">0.09 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.1">0.1 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.2">0.2 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.3">0.3 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.4">0.4 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.5">0.5 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.6">0.6 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.7">0.7 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.8">0.8 MeV</asp:ListItem>
                                    <asp:ListItem Value="0.9">0.9 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.0">1.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.1">1.1 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.2">1.2 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.25">1.25 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.28">1.28 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.3">1.3 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.4">1.4 MeV</asp:ListItem>
                                    <asp:ListItem Value="1.5">1.5 MeV</asp:ListItem>
                                    <asp:ListItem Value="2.0">2.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="3.0">3.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="3.5">3.5 MeV</asp:ListItem>
                                    <asp:ListItem Value="4.0">4.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="5.0">5.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="6.0">6.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="8.0">8.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="10">10.0 MeV</asp:ListItem>
                                    <asp:ListItem Value="11">HFIR</asp:ListItem>                                
                                    <asp:ListItem Value="12">Co-60</asp:ListItem>  
                                </asp:DropDownList>
                            </td>
                            <td colspan="4">
                                <asp:Label ID="Lbl_d" runat="server" Font-Bold="True" ForeColor="Black" 
                                    Text="Density (d) (g/cm&lt;sup&gt;3&lt;/sup&gt;)"></asp:Label>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="Txt_d" runat="server" Enabled="False" Width="111px"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label65" runat="server" Text="displacement energy" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_E_th" runat="server" Enabled="False" Width="111px"></asp:TextBox>
                                </td>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                            <td colspan="4">
                    <asp:Label ID="Label43" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Lattice parameters of element (in cm)" Font-Size="Large"></asp:Label>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lbl_struc" runat="server" Text="Lattice structure" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_ls" runat="server" Enabled="False" Width="132px"></asp:TextBox>
                            </td>
                            <td colspan="4">
                                <asp:Label ID="Lbl_r" runat="server" Text="Radius (cm)" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:TextBox ID="Txt_r" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="8">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lbl_a" runat="server" Text="a" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_a" runat="server" Enabled="False" Width="113px"></asp:TextBox>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="Lbl_b" runat="server" Text="b" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_b" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style12">
                                <asp:Label ID="Lbl_c" runat="server" Text="c" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="1">
                                <asp:TextBox ID="Txt_c" runat="server" Enabled="False" Width="99px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Lbl_alpha" runat="server" Text="α" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_alpha" runat="server" Enabled="False" Width="113px"></asp:TextBox>
                            </td>
                            <td colspan="1">
                                <asp:Label ID="Lbl_beta" runat="server" Text="β" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="Txt_beta" runat="server" Enabled="False" Width="100px"></asp:TextBox>
                            </td>
                            <td colspan="2" class="style12">
                                <asp:Label ID="Lbl_gamma" runat="server" Text="γ" Font-Bold="True" 
                                    ForeColor="Black"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Txt_gamma" runat="server" Enabled="False" Width="98px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                            <td class="style10">
                                <asp:Label ID="Lbl_photon" runat="server" Font-Bold="True" ForeColor="Black" 
                                    Text="Photons tracks"></asp:Label>
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="Txt_N" runat="server" Width="99px" 
                                   >1000</asp:TextBox>
                                <asp:RequiredFieldValidator ID="Reqval_photon" runat="server" 
                                    ControlToValidate="Txt_N" ErrorMessage="Required field can not be empty">*</asp:RequiredFieldValidator>
                            </td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                            <td class="style10">
                                &nbsp;</td>
                            <td colspan="3">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                                <asp:Button ID="Btn_atom_coll" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Atom Atom collision" 
                                    Width="198px" onclick="Btn_atom_coll_Click" 
                                    style="background-color: #CCCCCC" Height="25px" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_atom_coll_dE" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="Atom Atom collision (incl dE)" 
                                    Width="198px" onclick="Btn_atom_coll_dE_Click" 
                                    style="background-color: #CCCCCC" Height="25px" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_atom_coll0" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="electron Atom collision" 
                                    Width="198px" onclick="Btn_atom_coll_Click" 
                                    style="background-color: #CCCCCC" Height="25px" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_e_atom_coll_dE" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="electron Atom collision (incl dE)" 
                                    Width="208px" onclick="Btn_e_atom_coll_dE_Click" 
                                    style="background-color: #CCCCCC" Height="25px" />
                                <br />
                                <br />
                                <asp:Button ID="Btn_Kerma_cal" runat="server" BackColor="#99CCFF" 
                                    Font-Bold="True" ForeColor="Black" Text="KERMA" 
                                    Width="208px" onclick="Btn_Kerma_cal_Click" 
                                    style="background-color: #CCCCCC" Height="25px" />
                            </td>
            </tr>
            <tr>
                <td>
                                &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Label ID="Label58" runat="server" 
                        Text="----------------------------------------------------------------------------------------------------------------------"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style16">
                    </td>
                <td class="style17">
                    </td>
                <td align="center" colspan="8" class="style16">
                    <table align="center" bgcolor="#CCCCCC" frame="box" style="width: 84%;">
                        <tr>
                            <td colspan="4">
                                &nbsp;</td>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="4">
                    <asp:Label ID="Lbl_thickness1" runat="server" Font-Bold="True" ForeColor="Black" 
                        
                        Text="Attenuation Coefficient of dry air(µ&lt;sub&gt;max&lt;/sub&gt;)(cm&lt;sup&gt;-1&lt;/sup&gt;) " 
                        Font-Size="Large"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_air" runat="server" Enabled="False"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                    <asp:Label ID="Lbl_thickness0" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Distance of target from source " Font-Size="Large"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_dis" runat="server" Enabled="False">0</asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="6">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="6">
                    <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Dimension of target (in cm)" Font-Size="Large"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                    <asp:Label ID="Lbl_length" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Length" Font-Size="Large"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="Txt_2a" runat="server" ontextchanged="Txt_2a_TextChanged" Enabled="False">60</asp:TextBox>
                    <asp:RequiredFieldValidator ID="Reqval_a" runat="server" 
                        ControlToValidate="Txt_2a" ErrorMessage="Required field can not be empty">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                    <asp:Label ID="Lbl_width" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Width" Font-Size="Large"></asp:Label>
                            </td>
                            <td>
                    <asp:TextBox ID="Txt_2b" runat="server" Enabled="False">60</asp:TextBox>
                    <asp:RequiredFieldValidator ID="Reqval_b" runat="server" 
                        ControlToValidate="Txt_2b" ErrorMessage="Required field can not be empty">*</asp:RequiredFieldValidator>
                            </td>
                            <td>
                    <asp:Label ID="Lbl_thickness" runat="server" Font-Bold="True" ForeColor="Black" 
                        Text="Thickness" Font-Size="Large"></asp:Label>
                            </td>
                            <td class="style18">
                    <asp:TextBox ID="Txt_2c" runat="server">60</asp:TextBox>
                    <asp:RequiredFieldValidator ID="Reqval_c" runat="server" 
                        ControlToValidate="Txt_2c" ErrorMessage="Required field can not be empty">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </table>
                    </td>
                <td class="style16">
                    </td>
                <td class="style16">
                    </td>
            </tr>
            <tr>
                <td class="style19">
                    </td>
                <td class="style20">
                    </td>
                <td colspan="8" class="style19">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
                </td>
                <td class="style19">
                    </td>
                <td class="style19">
                    </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Button ID="Btn_Enter" runat="server" Text="Enter" 
                        onclick="Btn_Enter_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Btn_Graph" runat="server" Text="Photon Interaction" 
                        onclick="Btn_Graph_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Chart ID="Chart1" runat="server" Visible="False" Width="348px" 
                        ImageStorageMode="UseImageLocation">
                        <Titles>
                            <asp:Title Name="Title1" Text="Photons inside target">
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartType="Point" Name="Series1" YValueType="Double">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Title="y(cm)-->" Enabled="True">
                                </AxisY>
                                <AxisX Title="x(cm)-->" Enabled="True">
                                </AxisX>
                                </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <table style="width:100%; background-color: #CCCCCC;" bgcolor="#66CCFF">
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label13" runat="server" ForeColor="Black" 
                                    Text="Number of lattice cell generated in the given volume"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_lattice" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label14" runat="server" ForeColor="Black" 
                                    Text="Number of atoms present in the given volume"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_atom" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label17" runat="server" ForeColor="Black" 
                                    Text="Number of photon histories generated in the air"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_sphoton" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label18" runat="server" ForeColor="Black" 
                                    Text="Number of photons histories inside the target (MC)" BackColor="#66CCFF" 
                                    style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_tphoton" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label19" runat="server" ForeColor="Black" 
                                    Text="Number of photon  interactions" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_photon_I" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label53" runat="server" ForeColor="Black" 
                                    Text="Number of electron  interactions" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_electron" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label27" runat="server" ForeColor="Black" 
                                    Text="Number of displaced atoms (PKA > r_disp)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_dis_atom" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label52" runat="server" ForeColor="Black" 
                                    Text="Number of displaced atoms (generation > r_disp)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_dis_SKA" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label56" runat="server" ForeColor="Black" 
                                    Text="Number of displaced atoms (NRT)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_dis_atom0" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label57" runat="server" ForeColor="Black" 
                                    Text="Efficiency" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_dis_SKA0" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label22" runat="server" ForeColor="Black" 
                                    Text="Photoelectric interactions" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_photoelectric" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label20" runat="server" ForeColor="Black" 
                                    Text="Compton Scattering" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_comp" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label21" runat="server" ForeColor="Black" 
                                    Text="Pair-Production" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_PP" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="8" class="style4">
                                <asp:Label ID="Label59" runat="server" ForeColor="Black" 
                                    Text="Time taken (m sec)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                            </td>
                            <td colspan="2">
                    <asp:TextBox ID="Txt_time" runat="server"></asp:TextBox>
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label23" runat="server" ForeColor="Black" 
                                    Text="K" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_K" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label44" runat="server" ForeColor="Black" 
                                    Text="L" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_L" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                <asp:Label ID="Label25" runat="server" ForeColor="Black" 
                                    Text="M" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_M" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label26" runat="server" ForeColor="Black" 
                                    Text="N" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_Nshell" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style4">
                                <asp:Label ID="Label54" runat="server" ForeColor="Black" 
                                    Text="O" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_O" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                <asp:Label ID="Label55" runat="server" ForeColor="Black" 
                                    Text="P" 
                                    BackColor="#CCCCCC"></asp:Label>
                            </td>
                            <td class="style4">
                    <asp:TextBox ID="Txt_P" runat="server"></asp:TextBox>
                            </td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                            <td class="style4">
                                &nbsp;</td>
                        </tr>
                        </table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                                <asp:Label ID="Label45" runat="server" ForeColor="Black" 
                                    Text="Number of displaced atoms from various types of interactions" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center">
                                <asp:Label ID="Label46" runat="server" ForeColor="Black" 
                                    Text="Photoelectric interactions" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center" colspan="2">
                    <asp:TextBox ID="Txt_photo_disp" runat="server"></asp:TextBox>
                </td>
                <td align="center">
                                <asp:Label ID="Label47" runat="server" ForeColor="Black" 
                                    Text="Compton Scattering" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="Txt_comp_disp" runat="server"></asp:TextBox>
                </td>
                <td align="center" colspan="2">
                                <asp:Label ID="Label48" runat="server" ForeColor="Black" 
                                    Text="Pair-Production" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center" class="style15">
                    <asp:TextBox ID="Txt_PP_disp" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center">
                                <asp:Label ID="Label51" runat="server" ForeColor="Black" 
                                    Text="Photoelectric cross-section (barn)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center" colspan="2">
                    <asp:TextBox ID="Txt_photo_cross" runat="server"></asp:TextBox>
                </td>
                <td align="center">
                                <asp:Label ID="Label50" runat="server" ForeColor="Black" 
                                    Text="Compton cross-section (barn)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center">
                    <asp:TextBox ID="Txt_comp_cross" runat="server"></asp:TextBox>
                </td>
                <td align="center" colspan="2">
                                <asp:Label ID="Label49" runat="server" ForeColor="Black" 
                                    Text="PP cross-section (barn)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td align="center" class="style15">
                    <asp:TextBox ID="Txt_PP_cross" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="2" align="center">
                                <asp:Label ID="Label64" runat="server" ForeColor="Black" 
                                    Text="Photon energy inside (MeV)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="Txt_Eph_in" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" align="center">
                                &nbsp;</td>
                <td colspan="2" align="center">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="2" align="center">
                                <asp:Label ID="Label60" runat="server" ForeColor="Black" 
                                    Text="Photon energy outside (MeV)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="Txt_Eph_out" runat="server"></asp:TextBox>
                </td>
                <td colspan="2" align="center">
                                <asp:Label ID="Label62" runat="server" ForeColor="Black" 
                                    Text="Electron energy outside (MeV)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="Txt_Elec_out" runat="server" 
                        ></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="2" align="center">
                                <asp:Label ID="Label61" runat="server" ForeColor="Black" 
                                    Text="Photon energy Excitation (MeV)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="Txt_Eph_ext" runat="server" 
                        ></asp:TextBox>
                </td>
                <td colspan="2" align="center">
                                <asp:Label ID="Label63" runat="server" ForeColor="Black" 
                                    Text="Electron energy Excitation (MeV)" 
                                    BackColor="#66CCFF" style="background-color: #CCCCCC"></asp:Label>
                </td>
                <td colspan="2" align="center">
                    <asp:TextBox ID="Txt_Elec_ext" runat="server"></asp:TextBox>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_table" runat="server" Text="Interactions inside the target" 
                        onclick="Btn_table_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Table ID="Table1" runat="server" BackColor="#99CCFF" Font-Bold="True" 
                        style="background-color: #CCCCCC">
                    </asp:Table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_Path" runat="server" Text="Photon track" 
                        onclick="Btn_Path_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Chart ID="Chart3" runat="server" Visible="False" 
                        ImageStorageMode="UseImageLocation">
                        <Titles>
                            <asp:Title Name="Title1" Text="Photons track from source to target" >
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartType="Point" Name="Series1" YValueType="Double">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Title="y(cm)-->">
                                </AxisY>
                                <AxisX Title="x(cm)-->">
                                </AxisX>
                                </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                &nbsp;</td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Table ID="Table_PE" runat="server" BackColor="#99CCFF" Font-Bold="True" 
                        style="background-color: #CCCCCC">
                    </asp:Table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Button ID="Btn_compton_Sca_Click" runat="server" Text="Compton Scattering " 
                        onclick="Btn_compton__Sca_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Table ID="Table2" runat="server" BackColor="#99CCFF" Font-Bold="True" 
                        style="background-color: #CCCCCC">
                    </asp:Table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Button ID="Btn_compton" runat="server" Text="Compton Profile" 
                        onclick="Btn_Compton_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Btn_kerma" runat="server" Text="KERMA" 
                        onclick="Btn_kerma_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td align="center" colspan="8">
                    <asp:Chart ID="Chart4" runat="server" Visible="False" 
                        ImageStorageMode="UseImageLocation">
                        <Titles>
                            <asp:Title Name="CPM" Text="Compton Profile" >
                            </asp:Title>
                        </Titles>
                        <Series>
                            <asp:Series ChartType= "Point" Name="Series1" IsXValueIndexed="True" 
                                MarkerSize="5" XValueType="Double" YValueType="Double">
                            </asp:Series>
                            
                         <asp:Series ChartArea="ChartArea1" ChartType= "Point" Name="Series2" IsXValueIndexed="True" 
                                MarkerSize="5" XValueType="Double" YValueType="Double">
                            </asp:Series>
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Title="Number of electrons-->">
                                </AxisY>
                                <AxisX Title="KE-->" ArrowStyle="Lines">
                                </AxisX>
                                </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Chart ID="Chart5" runat="server" Visible="False" 
                        ImageStorageMode="UseImageLocation">
                        <Titles>
                            <asp:Title Name="kerma" Text="KERMA" >
                            </asp:Title>
                        </Titles>
                        <Series>
                         <asp:Series ChartArea="ChartArea1" ChartType= "Point" Name="Series1" IsXValueIndexed="True" 
                                MarkerSize="5" XValueType="Double" YValueType="Double">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" Name="photoelectric">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" 
                                Name="compton">
                            </asp:Series>
                            <asp:Series ChartArea="ChartArea1" ChartType="Point" Legend="Legend1" 
                                Name="Pair-production">
                            </asp:Series>
                           
                        </Series>
                        <ChartAreas>
                            <asp:ChartArea Name="ChartArea1">
                                <AxisY Title="dE/dm-->">
                                </AxisY>
                                <AxisX Title="Depth-->" ArrowStyle="Lines">
                                </AxisX>
                                </asp:ChartArea>
                        </ChartAreas>
                    </asp:Chart>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_elec_history" runat="server" Text="Electron History" 
                        onclick="Btn_elec_history_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                    <asp:Button ID="Btn_elec_history_Ed" runat="server" Text="Electron History (non-interacting Electron)" 
                        onclick="Btn_elec_history__Ed_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_dam_atom" runat="server" Text="PKA History (> r_disp)" 
                        onclick="Btn_dam_atom_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                    
                    <asp:Button ID="Btn_dam_atom_r" runat="server" Text="PKA History (< r_disp)" 
                        onclick="Btn_dam_atom_r_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                    
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_dam_SKA" runat="server" Text="SKA History (> r_disp)" 
                        onclick="Btn_dam_SKA_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                   
                    <asp:Button ID="Btn_dam_SKA_r" runat="server" Text="SKA History (< r_disp)" 
                        onclick="Btn_dam_SKA_r_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                   
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_dam_Ed" runat="server" Text="PKA Histories (< Ed)" 
                        onclick="Btn_dam_Ed_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                    <asp:Button ID="Btn_SKA_Ed" runat="server" Text="SKA Histories (< Ed)" 
                        onclick="Btn_SKA_Ed_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Button ID="Btn_vac" runat="server" Text="Vaccancy" 
                        onclick="Btn_vac_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                    <asp:Button ID="Btn_intl" runat="server" Text="Interstitial" 
                        onclick="Btn_intl_Click" BackColor="#99CCFF" Font-Bold="True" 
                        ForeColor="Black" style="background-color: #CCCCCC" />
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td class="style1">
                    &nbsp;</td>
                <td colspan="8" align="center">
                    <asp:Table ID="Table4" runat="server" BackColor="#99CCFF" Font-Bold="True" 
                        style="background-color: #CCCCCC">
                    </asp:Table>
                </td>
                <td>
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
