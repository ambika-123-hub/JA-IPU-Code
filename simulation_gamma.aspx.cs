using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.IO;
using System.Web.UI.DataVisualization.Charting.ChartTypes;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.ProviderBase;

namespace simulation_gamma
{
    public partial class chi_sqr : System.Web.UI.Page
    {
        double comp_cross_sect = 0;
        double photo_cross_sect = 0;
        double photo_Kcross_sect = 0;
        double pair_cross_sect = 0;
        double total_cross_sect = 0;

        double photo_at_cons = 0;
        double photo_at_Kcons = 0;
        double comp_at_cons = 0;
        double pair_at_cons = 0;
        double total_at_cons = 0;
        Calculation1 objCalc = new Calculation1();
        double E = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            Reqval_a.Enabled = false;
            Reqval_b.Enabled = false;
            Reqval_c.Enabled = true;
            Reqval_photon.Enabled = false;
        }

        protected void DDL_element_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_element.SelectedValue == "C")
            {
                Txt_Z.Text = "6";
                Txt_d.Text = "2.62";
                Txt_atom_wt.Text = "12.0107";
                Txt_a.Text = "2.464e-8";
                Txt_b.Text = "2.464e-8";
                Txt_c.Text = "6.711e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "120";
                Txt_ls.Text = "hcp";
                Txt_r.Text = "0.90459e-8";
            }
            else if (DDL_element.SelectedValue == "Al")
            {
                Txt_Z.Text = "13";
                Txt_d.Text = "2.6989";
                Txt_atom_wt.Text = "26.981539";
                Txt_a.Text = "4.050e-8";
                Txt_b.Text = "4.050e-8";
                Txt_c.Text = "4.050e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "FCC";
                Txt_r.Text = "1.43e-8";
            }
            else if (DDL_element.SelectedValue == "Si")
            {
                Txt_Z.Text = "14";
                Txt_d.Text = "2.329";
                Txt_atom_wt.Text = "28.0855";
                Txt_a.Text = "5.430710e-8";
                Txt_b.Text = "5.430710e-8";
                Txt_c.Text = "5.430710e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "CCP";
                Txt_r.Text = "1.10e-8";
            }
            else if (DDL_element.SelectedValue == "V")
            {
                Txt_Z.Text = "23";
                Txt_d.Text = "5.96";
                Txt_atom_wt.Text = "50.94";
                Txt_a.Text = "3.03e-8";
                Txt_b.Text = "3.03e-8";
                Txt_c.Text = "3.03e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "BCC";
                Txt_r.Text = "1.35e-8";
                Txt_E_th.Text = "44e-6";
            }
            else if (DDL_element.SelectedValue == "Fe")
            {
                Txt_Z.Text = "26";
                Txt_d.Text = "7.874";
                Txt_atom_wt.Text = "55.845";
                Txt_a.Text = "2.8665e-8";
                Txt_b.Text = "2.8665e-8";
                Txt_c.Text = "2.8665e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "BCC";
                Txt_r.Text = "1.3754e-8";
                Txt_E_th.Text = "40e-6";
            }
            else if (DDL_element.SelectedValue == "Ni")
            {
                Txt_Z.Text = "28";
                Txt_d.Text = "8.912";
                Txt_atom_wt.Text = "58.6934";
                Txt_a.Text = "3.524e-8";
                Txt_b.Text = "3.524e-8";
                Txt_c.Text = "3.524e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "CCP";
                Txt_r.Text = "1.35e-8";
            }
            else if (DDL_element.SelectedValue == "Cu")
            {
                Txt_Z.Text = "29";
                Txt_d.Text = "8.96";
                Txt_atom_wt.Text = "63.546";
                Txt_a.Text = "3.610e-8";
                Txt_b.Text = "3.610e-8";
                Txt_c.Text = "3.610e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "FCC";
                Txt_r.Text = "1.28e-8";
            }
            else if (DDL_element.SelectedValue == "Nb")
            {
                Txt_Z.Text = "41";
                Txt_d.Text = "8.57";
                Txt_atom_wt.Text = "92.9064";
                Txt_a.Text = "3.3004e-8";
                Txt_b.Text = "3.3004e-8";
                Txt_c.Text = "3.3004e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "CCP";
                Txt_r.Text = "1.45e-8";
            }
            else if (DDL_element.SelectedValue == "Pb")
            {
                Txt_Z.Text = "82";
                Txt_d.Text = "11.3";
                Txt_atom_wt.Text = "207.2";
                Txt_a.Text = "4.950e-8";
                Txt_b.Text = "4.950e-8";
                Txt_c.Text = "4.950e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "CCP";
                Txt_r.Text = "2.475e-8";
            }
            else if (DDL_element.SelectedValue == "U")
            {
                Txt_Z.Text = "92";
                Txt_d.Text = "18.7";
                Txt_atom_wt.Text = "238.028";
                Txt_a.Text = "2.85e-8";
                Txt_b.Text = "2.85e-8";
                Txt_c.Text = "2.85e-8";
                Txt_alpha.Text = "90";
                Txt_beta.Text = "90";
                Txt_gamma.Text = "90";
                Txt_ls.Text = "Orthorhombic";
                Txt_r.Text = "1.38e-8";
            }
            else if (DDL_element.SelectedValue == "SiC")
            {
                Txt_Z.Text = "";
                Txt_d.Text = "3.21";//gm/cm3
                Txt_atom_wt.Text = "";
                Txt_a.Text = "3.079e-8";
                Txt_b.Text = "3.079e-8";
                Txt_c.Text = "15.12e-8";
                Txt_alpha.Text = "120";
                Txt_beta.Text = "120";
                Txt_gamma.Text = "120";
                Txt_ls.Text = "HCP";
                Txt_r.Text = "";
            }          
            else if (DDL_element.SelectedValue == "Choose element...")
            {
                Txt_Z.Text = null;
            }
            
        }

        protected void DDL_E_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DDL_element.SelectedValue == "U")
            {
                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 92);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 92);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 92);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.002530 * 18.7;
                    comp_at_cons = comp_cross_sect * (Double)0.002530 * 18.7;
                    pair_at_cons = pair_cross_sect * (Double)0.002530 * 18.7;
                    total_at_cons = total_cross_sect * (Double)0.002530 * 18.7;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
               
            }
            else if (DDL_element.SelectedValue == "Pb")
            {
                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 82);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 82);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 82);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.002907 * 11.3;
                    comp_at_cons = comp_cross_sect * (Double)0.002907 * 11.3;
                    pair_at_cons = pair_cross_sect * (Double)0.002907 * 11.3;
                    total_at_cons = total_cross_sect * (Double)0.002907 * 11.3;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
               
            }
            else if (DDL_element.SelectedValue == "Nb")
            {
                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 41);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 41);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 41);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.0064817 * 8.57;
                    comp_at_cons = comp_cross_sect * (Double)0.0064817 * 8.57;
                    pair_at_cons = pair_cross_sect * (Double)0.0064817 * 8.57;
                    total_at_cons = total_cross_sect * (Double)0.0064817 * 8.57;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
            }
            else if (DDL_element.SelectedValue == "Cu")
            { //attenuation constant is taken from Hubbell

                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 29);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 29);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 29);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.009478 * 8.96;
                    comp_at_cons = comp_cross_sect * (Double)0.009478 * 8.96;
                    pair_at_cons = pair_cross_sect * (Double)0.009478 * 8.96;
                    total_at_cons = total_cross_sect * (Double)0.009478 * 8.96;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
            }
            else if (DDL_element.SelectedValue == "V")
            { //attenuation constant is taken from Hubbell
                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 23);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 23);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 23);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.011821 * 5.96;
                    comp_at_cons = comp_cross_sect * (Double)0.011821 * 5.96;
                    pair_at_cons = pair_cross_sect * (Double)0.0118211 * 5.96;
                    total_at_cons = total_cross_sect * (Double)0.0118211 * 5.96;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
            }
            else if (DDL_element.SelectedValue == "Fe")
            { //attenuation constant is taken from Hubbell
                if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 26);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 26);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 26);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.010780 * 7.874;
                    comp_at_cons = comp_cross_sect * (Double)0.010780 * 7.874;
                    pair_at_cons = pair_cross_sect * (Double)0.010780 * 7.874;
                    total_at_cons = total_cross_sect * (Double)0.010780 * 7.874;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
                
            }
            else if (DDL_element.SelectedValue == "Al")
            { //attenuation constant is taken from Hubbell
               if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                {
                    E = Convert.ToDouble(DDL_E.SelectedValue);
                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 26);
                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 26);
                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 26);
                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                    photo_at_cons = photo_cross_sect * (Double)0.022320 * 2.6989;
                    comp_at_cons = comp_cross_sect * (Double)0.022320 * 2.6989;
                    pair_at_cons = pair_cross_sect * (Double)0.022320 * 2.6989;
                    total_at_cons = total_cross_sect * (Double)0.022320 * 2.6989;
                    Txt_u.Text = total_at_cons.ToString();
                    Txt_air.Text = "0";
                }
                else
                {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                }
                
            }
                else if (DDL_element.SelectedValue == "C")
                {
                    if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
                    {
                        E = Convert.ToDouble(DDL_E.SelectedValue);
                        photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 6);
                        comp_cross_sect = objCalc.CalculateCompCrossSect(E, 6);
                        pair_cross_sect = objCalc.CalculatePairCrossSect(E, 6);
                        total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;
                        photo_at_cons = photo_cross_sect * (Double)0.050240 * 2.62;
                        comp_at_cons = comp_cross_sect * (Double)0.050240 * 2.62;
                        pair_at_cons = pair_cross_sect * (Double)0.050240 * 2.62;
                        total_at_cons = total_cross_sect * (Double)0.050240 * 2.62;
                        Txt_u.Text = total_at_cons.ToString();
                        Txt_air.Text = "0";
                    }
                    else
                    {
                    Txt_u.Text = "NA";
                    Txt_air.Text = "0";
                    }
              }
        }

        protected void Btn_Enter_Click(object sender, EventArgs e)
        {
            Reqval_a.Enabled = true;
            Reqval_b.Enabled = true;
            Reqval_c.Enabled = true;
            Reqval_photon.Enabled = true;

            Int32 N = Convert.ToInt32(Txt_N.Text);
            Double V_a = Convert.ToDouble(Txt_2a.Text);
            Double V_b = Convert.ToDouble(Txt_2b.Text);
            Double V_c = Convert.ToDouble(Txt_2c.Text);
            Double atom_no = Convert.ToDouble(Txt_Z.Text);
            Double th_E = Convert.ToDouble(Txt_E_th.Text);
            if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12")
            {
                Double U_max = Convert.ToDouble(Txt_u.Text);
            }
            Double d = Convert.ToDouble(Txt_d.Text);
            Double Atom_wt = Convert.ToDouble(Txt_atom_wt.Text);
            Double a = Convert.ToDouble(Txt_a.Text);
            Double b = Convert.ToDouble(Txt_b.Text);
            Double c = Convert.ToDouble(Txt_c.Text);
            Double radius = Convert.ToDouble(Txt_r.Text);
            Double dis_sample = Convert.ToDouble(Txt_dis.Text);
            Double air_u = Convert.ToDouble(Txt_air.Text);
            String l_struc = Convert.ToString(Txt_ls.Text);
            //*************************************************************************************************************
            //units are in cm. 
            double a_e = Math.Floor(V_a / a);
            double b_e = Math.Floor(V_b / b);
            double c_e = Math.Floor(V_c / c);
            double N_lattice = a_e * b_e * c_e; //No of lattice cells
            double atom = N_lattice * 2;
            //*************************************************************************************************************
            // Dimension of source (units are in cm)
            // double a_s = 0.0025;
            //double b_s = 0.0015;
            //double c_s = 0.001;
            //*************************************************************************************************************
            // Constants (in cm)
            double inl_lambda = 0, final_lamda = 0;
            double h = 4.135667 * (Math.Pow(10, -21)); //units are in MeV-s
            double h_cross = h / (2 * 3.14);
            double c_light = 2.99792458 * (Math.Pow(10, 10)); // in cm/s
            double mass_ele = 9.10938291 * Math.Pow(10, -28); // in gm //0.511 in MeV/c2 //
            //double mass_iron = 9.27e-23;//in gm
            double M = 0, atom_d=0;
            //double amu = 1.66e-24;//1amu in gm
            //double fermi_E = 11.1 * Math.Pow(10, -6);//MeV
            //double Ion_p = 7.87e-6;
            //double Na = 6.0221415e+23;
            //double Atom_wt = 55.845;
           // double e_charge = 1.60217657e-13;//(1MeV charge in joule)
            //double e_esu = 4.8032e-10;//electron charge in esu
            double re = 2.817940e-13; // cm
            
            M = 931.5 * Atom_wt / Math.Pow(c_light, 2);// Mass of the atom in MeV/c2
            double total_mass = (0.511 / Math.Pow(c_light, 2)) + M; // in MeV/c2
            double rad_length = (716.4 * Atom_wt) / (d * atom_no * (atom_no + 1) * Math.Log(287 / Math.Sqrt(atom_no)));//cm
            double e_th_E = Math.Sqrt(M * Math.Pow(c_light, 2) * (th_E / 2) + Math.Pow(0.511, 2)) - 0.511;

            //*************************************************************************************************************            

            double x0=0, y0=0, z0=0, ix = 0, iy = 0, iz = 0,x = 0, y = 0, z = 0, ix0 = 0, iy0 = 0, iz0 = 0;
            double cos_phi=0, sin_phi=0, cos_theta=0, sin_theta=0,ncos_phi=0, nsin_phi=0, ncos_theta=0, nsin_theta=0, e_phi = 0, pie_c=0;
            double u, v, w, s = 0;
            double elec_x0 = 0, elec_y0 = 0, elec_z0 = 0,elec_x = 0, elec_y = 0, elec_z = 0,e_l=0;
            double atom_x0 = 0, atom_y0 = 0, atom_z0 = 0, atom_x = 0, atom_y = 0, atom_z = 0;
            //double sca_E=0, s1;
            //double Ion_P = 0, rem_E=0, Pair_E = 0;
            double KE = 0, momentum=0;
            //double fermi_P = 0;
            int ipoint = 0, dpoint = 0, spoint = 0,epoint = 0,e_his = 0,N0 = 0, Photon_N = 0,apoint = 0,ska_id=0;
            double int_point = 0,e_point = 0, a_point = 0;
            double E_elec = 0, PE = 0, PP = 0, Comp = 0;
            int K_contri = 0, M_contri = 0, N_contri = 0, L_contri = 0,O_contri=0,P_contri=0;
            double K_r = 0, L_r = 0, M_r = 0, N_r = 0,O_r=0,P_r=0;
            double Sca_E = 0, BE_K = 0, BE_L = 0, BE_M = 0, BE_N = 0,BE_O=0,BE_P=0;
            double new_u = 0, new_v = 0, new_w = 0, theta = 0;
            double PE_dis_cross = 0, Comp_dis_cross = 0, PP_dis_cross = 0;
            //double PE_Ed = 0, Comp_Ed = 0, PP_Ed = 0;
            //double t_PE_dis_cross = 0, t_Comp_dis_cross = 0, t_PP_dis_cross = 0;
            double Comp_dis_atom = 0, PE_dis_atom = 0, PP_dis_atom = 0;
            double Comp_def_atom = 0, PE_def_atom = 0, PP_def_atom = 0;
            //double Avg_dis_cross_Comp = 0;
            double r_s = 0, r_c = 0, sc = 0;
            double E_out = 0, e_E_out = 0, e_E_ext = 0, ph_E_ext = 0, E_in=0, phi=0, N_NRT = 0, Fix_KE=0,E_PKA=0;
            string interaction = "",shell="",Ph_box="",t_struc="",t_atom="";
            double disp_atom = 0, disp_cross = 0, def_atom = 0, def_cross = 0;
            double PKA = 0, SKA = 0, TKA = 0, FKA = 0, PtKA = 0, SxKA = 0, SvKA = 0, EtKA = 0, NiKA = 0, TnKA = 0;
            double PKA_l = 0, SKA_l = 0, TKA_l = 0, FKA_l = 0, PtKA_l = 0, SxKA_l = 0, SvKA_l = 0, EtKA_l = 0, NiKA_l = 0, TnKA_l = 0;
            //*************************************************************************************************************

            Random rand = new Random();

            //*************************************************************************************************************

            //*************************************************************************************************************

            double dE_atom = 0, dE=0;
            double Ini_E = 0, threshold_E = 0;
            
            Stoping_power objStpo = new Stoping_power();
            energy_loss_chargedparticle objcharge = new energy_loss_chargedparticle();
            dc obj_dc = new dc();
            ele_coord obj_elec = new ele_coord();
            PKA_coord obj_pka = new PKA_coord();
            source_struc obj_source = new source_struc();
            atomic_cascade obj_pos = new atomic_cascade();
            file_store obj_file = new file_store();
            coordinate obj_cord = new coordinate();
            gamma_spec_react obj_gamma_spec = new gamma_spec_react();
            elec_cross obj_e_cross = new elec_cross();
            PKA_cross obj_PKA_cross = new PKA_cross();
            atom_cross1 obj_atom_cross = new atom_cross1();

            //****************************************************************************************************************            
            //spoint is number of source photon and ipoint is number of photon inside the volume
            //int spoint = 0;
            double[] void_cord = new double[3];
            ArrayList x_val = new ArrayList();
            ArrayList y_val = new ArrayList();
            ArrayList y1_val = new ArrayList();
            ArrayList x_int = new ArrayList();
            ArrayList y_int = new ArrayList();
            ArrayList Path_x = new ArrayList();
            ArrayList Path_y = new ArrayList();
            ArrayList Path_x1 = new ArrayList();
            ArrayList Path_y1 = new ArrayList();
            ArrayList Kerma_x = new ArrayList();
            ArrayList Kerma_y = new ArrayList();
            ArrayList Kerma_PE_y = new ArrayList();
            ArrayList Kerma_Comp_y = new ArrayList();
            ArrayList Kerma_PP_y = new ArrayList();
            double cls_w = 0;
            double no_class = 10;
            double[] n_moment = new double[11];
            double psx, psy, psz;
            double mindis = 0, close_atom = 0;
            int t_ipoint = 0, t_epoint = 0, t_apoint = 0;
            double close_x = 0, close_y = 0, close_z = 0;
            double rem_KE = 0,count_1=0,count_2=0;
            // ArrayList source_list = new ArrayList();
            ArrayList atom_list = new ArrayList();
            //ArrayList photn_list = new ArrayList();
            int PE_e = 0, PP_e = 0, Comp_e = 0;
            ArrayList array_int = new ArrayList();
            ArrayList C_array_int = new ArrayList();
            ArrayList e_array_int = new ArrayList();
            ArrayList Photon_int = new ArrayList();
            ArrayList Comp_int = new ArrayList();
            ArrayList Ele_int = new ArrayList();
            double[] pz = new double[1000000];

            //double gen = 0,gen_l=0;
            // sw.WriteLine("S/no.\t\tMomentum\t\tNumber of photon");
            //obj_cord.Fe_data(V_a,V_b,V_c,a,b,c);
            string int_type = "", type_atom="";

            //*****************************************************************************************
            //                        Photon History Data Table
            //*****************************************************************************************
            DataTable photon_int = new DataTable("photon_int");
            DataTable photon_h = new DataTable("photon_int");

            //*****************************************************************************************
            //                        Compton Profile Data Table
            //*****************************************************************************************
            DataTable Comp_pro = new DataTable("Comp_pro");

            DataColumn Serial_comp = new DataColumn();
            Serial_comp.DataType = Type.GetType("System.Double");
            Serial_comp.ColumnName = "Serial No";

           // DataColumn Time_comp = new DataColumn();
           // Time_comp.DataType = Type.GetType("System.DateTime");
           // Time_comp.ColumnName = "Time Photon";

            DataColumn Ini_Spec_PE = new DataColumn();
            Ini_Spec_PE.DataType = Type.GetType("System.Double");
            Ini_Spec_PE.ColumnName = "Spectrum Energy (MeV)";

           // DataColumn Ini_E_P = new DataColumn();
           // Ini_E_P.DataType = Type.GetType("System.Double");
           // Ini_E_P.ColumnName = "Initial Photon Energy (MeV)";

            DataColumn Ini_theta_P = new DataColumn();
            Ini_theta_P.DataType = Type.GetType("System.Double");
            Ini_theta_P.ColumnName = "Photon Theta";

            DataColumn Ini_phi_P = new DataColumn();
            Ini_phi_P.DataType = Type.GetType("System.Double");
            Ini_phi_P.ColumnName = "Photon Phi";

            DataColumn Ini_lambda = new DataColumn();
            Ini_lambda.DataType = Type.GetType("System.Double");
            Ini_lambda.ColumnName = "Initial Lambda (cm)";

            DataColumn Ini_moment = new DataColumn();
            Ini_moment.DataType = Type.GetType("System.Double");
            Ini_moment.ColumnName = "Initial Momentum (MeV/c)";

            DataColumn KE_elec = new DataColumn();
            KE_elec.DataType = Type.GetType("System.Double");
            KE_elec.ColumnName = "Kinetic Energy of electron (MeV)";


            DataColumn Comp_shell = new DataColumn();
            Comp_shell.DataType = Type.GetType("System.String");
            Comp_shell.ColumnName = "Shell";

            DataColumn Cross_sect_e = new DataColumn();
            Cross_sect_e.DataType = Type.GetType("System.Double");
            Cross_sect_e.ColumnName = "Cross-section (b)";

            DataColumn Elec_theta = new DataColumn();
            Elec_theta.DataType = Type.GetType("System.Double");
            Elec_theta.ColumnName = "Electron Theta";

            DataColumn Elec_phi = new DataColumn();
            Elec_phi.DataType = Type.GetType("System.Double");
            Elec_phi.ColumnName = "Electron Phi";

            DataColumn Sca_E_P = new DataColumn();
            Sca_E_P.DataType = Type.GetType("System.Double");
            Sca_E_P.ColumnName = "Scattered Photon Energy (MeV)";

            DataColumn Sca_P_theta = new DataColumn();
            Sca_P_theta.DataType = Type.GetType("System.Double");
            Sca_P_theta.ColumnName = "Scattered Photon Theta";

            DataColumn Sca_P_phi = new DataColumn();
            Sca_P_phi.DataType = Type.GetType("System.Double");
            Sca_P_phi.ColumnName = "Scattered Photon Phi";

            DataColumn Sca_moment_P = new DataColumn();
            Sca_moment_P.DataType = Type.GetType("System.Double");
            Sca_moment_P.ColumnName = "Scattered Photon momentum (MeV/c)";

            DataColumn lambda_shift = new DataColumn();
            lambda_shift.DataType = Type.GetType("System.Double");
            lambda_shift.ColumnName = "lambda shift";

            Comp_pro.Columns.Add(Serial_comp);
           // Comp_pro.Columns.Add(Time_comp);
            Comp_pro.Columns.Add(Ini_Spec_PE);
           // Comp_pro.Columns.Add(Ini_E_P);
            Comp_pro.Columns.Add(Ini_theta_P);
            Comp_pro.Columns.Add(Ini_phi_P);
            Comp_pro.Columns.Add(Ini_lambda);
            Comp_pro.Columns.Add(Ini_moment);
            Comp_pro.Columns.Add(KE_elec);
            Comp_pro.Columns.Add(Comp_shell);
            Comp_pro.Columns.Add(Cross_sect_e);
            Comp_pro.Columns.Add(Elec_theta);
            Comp_pro.Columns.Add(Elec_phi);
            Comp_pro.Columns.Add(Sca_E_P);
            Comp_pro.Columns.Add(Sca_P_theta);
            Comp_pro.Columns.Add(Sca_P_phi);
            Comp_pro.Columns.Add(Sca_moment_P);
            Comp_pro.Columns.Add(lambda_shift);
            //*****************************************************************************************
            //                        Electron History Data Table 
            //*****************************************************************************************
            DataTable elec_hist = new DataTable("elec_history");
            DataTable elec_h = new DataTable("elec_history");
            //*****************************************************************************************
            //                        Electron History Data Table (<e_th_E)
            //*****************************************************************************************
            DataTable elec_Ed_hist = new DataTable("elec_Ed_history");
            DataTable elec_Ed_h = new DataTable("elec_Ed_history");

            //*****************************************************************************************
            //                        PKA History Data Table 
            //*****************************************************************************************
            DataTable PKA_hist = new DataTable("PKA_history");
            DataTable PKA_h = new DataTable("PKA_history");

            //*****************************************************************************************
            //                        PKA History Data Table (<Ed)
            //*****************************************************************************************
            DataTable PKA_Ed_hist = new DataTable("PKA_Ed_history");
            DataTable PKA_Ed_h = new DataTable("PKA_Ed_history");
            //*****************************************************************************************
            //                         Vaccancy Data Table
            //*****************************************************************************************
            DataTable vac_hist = new DataTable("vac_history");
            DataTable vac_h = new DataTable("vac_history");
            //*****************************************************************************************
            //                         Interstitial Data Table
            //*****************************************************************************************
            DataTable int_hist = new DataTable("Int_history");
            DataTable int_h = new DataTable("Int_history");
            //*****************************************************************************************
            //                        PKA History Data Table (out)
            //*****************************************************************************************
            DataTable pka_out_hist = new DataTable("PKA_out_history");
            DataTable pka_out_h = new DataTable("PKA_out_history");

            
            double cross = 0, BE=0;
            int geom = 2;
            int bin = 47,t_bin=0,spec=0;
            //var st_time,end_time,diff_time;
            var st_time = System.Diagnostics.Stopwatch.StartNew();

            if (DDL_E.SelectedValue == "12")
            {
                t_bin = 50; // 
                spec = 12;
            }
            else if (DDL_E.SelectedValue == "11")
            {
                t_bin = 47;
                spec = 11;
            }
            else
            {
                t_bin = bin;
                spec = 0;
            }
                while (bin <= t_bin)
                {
                    if (DDL_E.SelectedValue == "11")
                    {
                        N = obj_gamma_spec.cal_N(bin,spec);
                        if (bin >= 10 && bin < 20)
                        {
                            N0 = 100000;
                        }
                        else
                        {
                            N0 = 500000;
                        }
                    }
                    else if (DDL_E.SelectedValue == "12")
                    {
                        N = obj_gamma_spec.cal_N(bin, spec);
                        if (bin < 20)
                        {
                            N0 = 100000;
                        }
                        else
                        {
                            N0 = N;
                        }
                    }
                    else
                    {
                        N0 = 500000;
                    }

                    while (Photon_N < N)
                    {
                        //********************************************************************************************                                               
                        //       point source
                        //********************************************************************************************
                        obj_source.source(V_a, V_b, V_c, ref x0, ref y0, ref z0);
                        //**********************************************************************************************
                        //      Position Coordinate of photon
                        //**********************************************************************************************
                        if (geom == 1) // rectangular geometry 
                        {
                            x = x0 ;
                            y = y0 ;
                            z = z0 - dis_sample;
                        }
                        else if (geom == 2) // point source geometry 
                        {
                            x = x0;// +(V_a * 0.5);
                            y = y0;// +(V_b * 0.5);
                            z = 0 - dis_sample;
                        }
                        //*************************************************************************
                        //   Interaction Point of Photon
                        //*************************************************************************
                        ix =x;//+u * s;
                        iy =y;//+v * s;
                        iz =z;//+w * s;
                        obj_pos.dir_cos(ref phi, ref theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                        
                        //************************************************************************************************
                        //      Initial direction of photon 
                        //************************************************************************************************
                        u = 0;// cos_phi* sin_theta;
                        v = 0;// sin_theta* sin_phi;
                        w = 1;// cos_theta; 
                        //************************************************************************************************
                        //       Photon Energy
                        //************************************************************************************************
                        if (DDL_E.SelectedValue != "11" && DDL_E.SelectedValue != "12") 
                        {
                            E = Convert.ToDouble(DDL_E.SelectedValue);
                            
                        }
                        else
                        {
                            E = obj_gamma_spec.cal_E(bin,spec);
                        }
                        //=================================================================
                        //Call the functions to get the values
                        Ini_E = E;
                        double Emax = 2 * E * E / (0.511 + (2 * E));
                        double Pcut = 1e-6;//0.6298 for radiation damage;// 7.53e-6; 100eV
                        //=================================================================
                        //Number of photon striking the target
                        dpoint = dpoint + 1;
                                              
                        while (E >= Pcut)
                        {
                            if (atom_no == 6)
                            {
                                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, 6);
                                    comp_cross_sect = objCalc.CalculateCompCrossSect(E, 6);
                                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, 6);
                                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                    photo_at_cons = photo_cross_sect * (Double)0.050240 * 2.62;
                                    comp_at_cons = comp_cross_sect * (Double)0.050240 * 2.62;
                                    pair_at_cons = pair_cross_sect * (Double)0.050240 * 2.62;
                                    total_at_cons = total_cross_sect * (Double)0.050240 * 2.62;

                                threshold_E = 5e-6;//photoelectric workfunction
                                K_r = 0.14283e-8; //cutoff raius of C for 1s2 (0.9 au)
                                L_r = 0.90459e-8; // cutoff radius of C for 2p4 (1.6 au)
                                BE_K = 284.2e-6;
                                BE_L = 11.27e-6;
                            }
                            if (atom_no == 13)
                            {
                                comp_cross_sect = objCalc.CalculateCompCrossSect(E, atom_no);
                                photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, atom_no);
                                pair_cross_sect = objCalc.CalculatePairCrossSect(E, atom_no);
                                photo_Kcross_sect = objCalc.CalculatePhotoKCrossSect(E, atom_no);
                                total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                photo_at_cons = photo_cross_sect * (Double)0.02232 * d;
                                comp_at_cons = comp_cross_sect * atom_no * (Double)0.02232 * d;
                                pair_at_cons = pair_cross_sect * (Double)0.02232 * d;
                                total_at_cons = total_cross_sect * (Double)0.02232 * d;
                                photo_at_Kcons = photo_Kcross_sect * (Double)0.02232 * d;
                                threshold_E = 4.08e-6;
                                //fermi_E = 11.7e-6;
                            }
                            else if (atom_no == 23)
                            { // cross_section are in barn
                                atom_d = 7.0455e22;
                                comp_cross_sect = objCalc.CalculateCompCrossSect(E, atom_no);
                                photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, atom_no);
                                pair_cross_sect = objCalc.CalculatePairCrossSect(E, atom_no);
                                total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                photo_at_cons = photo_cross_sect * (Double)0.0118211 * d;
                                comp_at_cons = comp_cross_sect * (Double)0.0118211 * d;
                                pair_at_cons = pair_cross_sect * (Double)0.0118211 * d;
                                total_at_cons = (photo_at_cons + comp_at_cons + pair_at_cons);
                                
                                threshold_E = 4.3e-6;//photoelectric workfunction
                                K_r = 4.761e-9;// cutoff radius of He for 1s2 (0.9 au)
                                L_r = 8.464e-9;// cutoff radius of Ne for 2p6 (1.6 au)     
                                M_r = 8.993e-9; //cutoff radius of V for 3d given by T. Ozaki (1.70 a.u.)
                                N_r = 1.32255e-8;  // cutoff radius of V for 4s by T. Ozaki (2.50 a.u)
                                BE_K = 5465e-6;
                                BE_L = 512.1e-6;
                                BE_M = 37.2e-6;
                                BE_N = 6.7463e-6;//first ionization potential
                               // fermi_E = 11.1e-6;
                            }
                            else if (atom_no == 26)
                            {
                                atom_d = 8.4817e22;
                                comp_cross_sect = objCalc.CalculateCompCrossSect(E, atom_no);
                                photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, atom_no);
                                pair_cross_sect = objCalc.CalculatePairCrossSect(E, atom_no);
                                photo_Kcross_sect = objCalc.CalculatePhotoKCrossSect(E, atom_no);
                                total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                photo_at_cons = photo_cross_sect * (Double)0.010780 * d;
                                comp_at_cons = comp_cross_sect * (Double)0.010780 * d;
                                pair_at_cons = pair_cross_sect * (Double)0.010780 * d;
                                total_at_cons = (photo_at_cons + comp_at_cons + pair_at_cons);
                                photo_at_Kcons = photo_Kcross_sect * (Double)0.010780 * d;
                               
                                threshold_E = 4.5e-6;//photoelectric workfunction
                                K_r = 4.761e-9;// (1.6 a.u. modified on 9 sep2014) 4.761e-9; //cutoff radius of He for 1s2 (0.9 au)
                                L_r = 8.464e-9;// (1.9 a.u. modified on 9 sep2014) 8.464e-9; // cutoff radius of Ne for 2p6 (1.6 au)     
                                M_r = 1.058e-8; //cutoff radius of Fe for 3d given by T. Ozaki
                                N_r = 1.3754e-8;  // cutoff radius of Fe for 4s by T. Ozaki
                                BE_K = 7112e-6;
                                BE_L = 706.8e-6;
                                BE_M = 52.7e-6;
                                BE_N = 7.87e-6;// Ionization potential
                               // fermi_E = 11.1e-6;
                            }
                            else if (atom_no == 29)
                            {
                                comp_cross_sect = objCalc.CalculateCompCrossSect(E, atom_no);
                                photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, atom_no);
                                pair_cross_sect = objCalc.CalculatePairCrossSect(E, atom_no);
                                photo_Kcross_sect = objCalc.CalculatePhotoKCrossSect(E, atom_no);
                                total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                photo_at_cons = photo_cross_sect * (Double)0.009478 * d;
                                comp_at_cons = comp_cross_sect * atom_no * (Double)0.009478 * d;
                                pair_at_cons = pair_cross_sect * (Double)0.009478 * d;
                                total_at_cons = total_cross_sect * (Double)0.009478 * d;
                                photo_at_Kcons = photo_Kcross_sect * (Double)0.009478 * d;
                                threshold_E = 4.7e-6;
                                //fermi_E = 7e-6;
                            }
                            else if (atom_no == 82)
                            {
                                    comp_cross_sect = atom_no * objCalc.CalculateCompCrossSect(E, atom_no);
                                    photo_cross_sect = objCalc.CalculatePhotoCrossSect(E, atom_no);
                                    pair_cross_sect = objCalc.CalculatePairCrossSect(E, atom_no);
                                    photo_Kcross_sect = objCalc.CalculatePhotoKCrossSect(E, atom_no);
                                    total_cross_sect = photo_cross_sect + comp_cross_sect + pair_cross_sect;

                                    photo_at_cons = photo_cross_sect * (Double)0.002907 * d;
                                    comp_at_cons = comp_cross_sect * atom_no * (Double)0.002907 * d;
                                    pair_at_cons = pair_cross_sect * (Double)0.002907 * d;
                                    total_at_cons = total_cross_sect * (Double)0.002907 * d;
                                    photo_at_Kcons = photo_Kcross_sect * (Double)0.002907 * d;
                                    threshold_E = 4.14e-6;
                                    K_r = 4.761e-9; //cutoff radius of He for 1s2 (0.9 au)
                                    L_r = 8.464e-9; //cutoff radius of Ne for 2p6 (1.6 au)
                                    M_r = 9.522e-9; //cutoff radius of Zn for 3d10 (1.8 au) since 3d is completely filled so it will be reduced.
                                    N_r = 1.058e-8;  //cutoff radius of Pb for 4f14 (2.0 au) 
                                    O_r = 1.1109e-8;  //cutoff radius of Pb for 5d10 (2.1 au) quantum expresso
                                    P_r = 1.3754e-8; //cutoff radius of Pb for 6p2 (2.6 au)
                                    BE_K = 88005e-6;
                                    BE_L = 13035e-6;
                                    BE_M= 2484e-6;
                                    BE_N = 136.9e-6;
                                    BE_O = 18.1e-6;
                                    BE_P = 7.4167e-6;
                                   // fermi_E = 9.47e-6;
                            }
                            else if (atom_no == 92)
                            {
                                photo_at_cons = photo_cross_sect * (Double)0.002530 * d;
                                comp_at_cons = comp_cross_sect * atom_no * (Double)0.002530 * d;
                                pair_at_cons = pair_cross_sect * (Double)0.002530 * d;
                                total_at_cons = total_cross_sect * (Double)0.002530 * d;
                                photo_at_Kcons = photo_Kcross_sect * (Double)0.002530 * d;
                                threshold_E = 3.6e-6;
                            }
                            inl_lambda = h * c_light / E; // Initial wavelength of photon in cm

                            double ini_p = E; // Initial momentum of photon in units of Energy (MeV)/c
                           // Path_x.Add(x); // x position of photon
                           // Path_y.Add(y); // y position of photon

                            //*************************************************************************
                            //    Path length of photon
                            //*************************************************************************
                            r_s = rand.NextDouble();
                            s = -Math.Log(r_s) / total_at_cons;

                            ix0 = ix + u * s;
                            iy0 = iy + v * s;
                            iz0 = iz + dis_sample + w * s;
                            //*************************************************************************
                            //    Condition to check whether the point lie inside the target or not
                            //*************************************************************************
                            if (((ix0 >= 0 && ix0 <= V_a)) && (iy0 >= 0 && iy0 <= V_b) && (iz0 >= 0 && iz0 <= V_c))
                            {
                                E_in = E_in + E;
                                Ph_box = "Inside";
                                ipoint = ipoint + 1; // Number of photons histories inside the target

                                x_int.Add(ix0); // to add interaction point inside the target
                                y_int.Add(iy0); // to add interaction point inside the target

                                psx = (Math.Truncate(ix0 / a)) * a; //coordinates of the lattice
                                psy = (Math.Truncate(iy0 / b)) * b;
                                psz = (Math.Truncate(iz0 / c)) * c;
                                //photon_cord[0] = ix0;
                                //photon_cord[1] = iy0;
                                //photon_cord[2] = iz0;
                                //-------To find minimum distance of photon with an atom-----------------
                                
                                obj_cord.struc(psx, psy, psz, ix, iy, iz, ix0, iy0, iz0, a, b, c, ipoint, bin, atom_no,N,l_struc,ref mindis,ref type_atom);
                                close_atom = obj_cord.close(ipoint, bin, N, mindis, l_struc, ref close_x, ref close_y, ref close_z);//give index of closest atom in a particular unit cell
                                //close_x = obj_cord.close_x1(ipoint);
                                //close_y = obj_cord.close_y1(ipoint);
                                //close_z = obj_cord.close_z1(ipoint);

                                elec_x0 = close_x;
                                elec_y0 = close_y;
                                elec_z0 = close_z;

                                if (l_struc == "HCP")
                                {
                                    if (type_atom == "Si")
                                    {
                                        count_1 = count_1 + 1;
                                    }
                                    else
                                    {
                                        count_2 = count_2 + 1;
                                    }
                                }
                                //---------------------------------------------------   

                                double lambda_elec = 0;
                                lambda_elec = (2 * 3.14 * radius) / (double)4;

                                if ((mindis <= (radius + inl_lambda)) && (mindis >= 0))
                                {
                                    DataRow photonrow = photon_int.NewRow();
                                    //double J_pz = 0;
                                    double e_theta = 0;
                                    if ((mindis > 0) && (mindis <= K_r))
                                    {
                                        shell = " K ";
                                        BE = BE_K;
                                    }
                                    else if ((mindis <= L_r) && (mindis > K_r))
                                    {
                                        shell = " L ";
                                        BE = BE_L;
                                    }
                                    else if ((mindis <= M_r) && (mindis > L_r))
                                    {
                                        shell = " M ";
                                        BE = BE_M;
                                    }
                                    else if ((mindis > M_r) && (mindis <=radius)) //N_r + inl_lambda +radius))
                                    {
                                        shell = " N ";
                                        BE = BE_N;
                                    }
                                    else if ((mindis > N_r) && (mindis <= O_r))
                                    {
                                        shell = " O ";
                                        BE = BE_O;
                                    }
                                    else if ((mindis > O_r) && (mindis <= P_r))
                                    {
                                        shell = " P ";
                                        BE = BE_P;
                                    }

                                    r_s = rand.NextDouble();//on 12 sep 2014

                                    if (r_s <= (photo_at_cons / total_at_cons) && (E >= threshold_E + BE))
                                    {
                                        interaction = "PE";
                                        if (Ini_E == E)
                                        {
                                            int_point = int_point + 1.1;
                                        }
                                        else
                                        {
                                            int_point = int_point + 0.1;
                                        }

                                        PE = PE + 1;
                                        e_point = int_point;
                                        double PE_2 = 0;
                                        if (shell == " K ")
                                        {
                                            K_contri = K_contri + 1;
                                            KE = E - BE_K - threshold_E;//E-BE of iron
                                            E_elec = KE + BE_K + threshold_E;
                                            PE_2 = BE_K;
                                        }
                                        else if (shell == " L ")
                                        {
                                            L_contri = L_contri + 1;
                                            KE = E - BE_L - threshold_E;//E-BE of iron
                                            E_elec = KE + BE_L + threshold_E;
                                            PE_2 = BE_L;
                                        }
                                        else if (shell == " M ")
                                        {
                                            M_contri = M_contri + 1;
                                            KE = E - BE_M - threshold_E;//E-BE of iron
                                            E_elec = KE + BE_M + threshold_E;
                                            PE_2 = BE_M;
                                        }
                                        else if (shell == " N ")
                                        {
                                            N_contri = N_contri + 1;
                                            KE = E - BE_N - threshold_E;//E-BE of iron
                                            E_elec = KE + BE_N + threshold_E;
                                            PE_2 = BE_N;
                                        }
                                        else if (shell == " O ")
                                        {
                                            O_contri = O_contri + 1;
                                            KE = E - BE_O - threshold_E + threshold_E;//E-BE of iron
                                            E_elec = KE + BE_O;
                                        }
                                        else if (shell == " P ")
                                        {
                                            P_contri = P_contri + 1;
                                            KE = E - BE_P - threshold_E + threshold_E;//E-BE of iron
                                            E_elec = KE + BE_P;
                                        }

                                        if (E > 1)
                                        {
                                            //momentum = Math.Sqrt((E*E)+(Sca_E*Sca_E) - (2*E*Sca_E*ncos_theta)); // MeV/c Momentum of electron
                                            momentum = Math.Round(Math.Sqrt(((E_elec * E_elec) - (0.511 * 0.511)) / Math.Pow(c_light, 2)), 8);
                                        }
                                        else
                                        {
                                            momentum = Math.Round(Math.Sqrt(2 * 0.511 * KE / Math.Pow(c_light, 2)), 8); // MeV/c Momentum of electron
                                        }
                                        //if (E > 2)
                                        //{
                                        // double PE_1 = 1.5 * 0.6653 * (Math.Pow(atom_no, 5) / Math.Pow(137, 4)) * (Math.Pow((0.511 / E), 5));
                                        //double lam = (E - PE_2 - 0.511) / 0.511;
                                        //double PE_3 = 1.3333 + (lam * (lam - 2) / (lam + 1)) * (1 - ((1 / (2 * lam*(lam * lam - 1))) * Math.Log((lam + Math.Pow((Math.Pow(lam, 2) - 1), 0.5)) / (lam - Math.Pow((Math.Pow(lam, 2) - 1), 0.5)))));
                                        //PE_dis_cross = PE_1 * Math.Pow(lam,1.5) * PE_3;
                                        //}
                                        //else
                                        //{
                                        // double dis_cross_1 = (1.25 * Math.Pow(atom_no, 5)) / (Math.Pow(137, 4) * E);
                                        //double dis_cross_2 = Math.Exp(-(3.14 * atom_no / 137) + (2 * Math.Pow((atom_no / 137), 2) * (1 - Math.Log(atom_no / 137))));
                                        //double dis_cross_3 = Math.Pow((Math.Pow(KE, 2) + (2 * KE)), 1.5) / Math.Pow(E, 2);
                                        //double Log_x = Math.Log((KE + 1 + Math.Pow((2 * KE + (KE * KE)), 0.5)) / (KE + 1 - Math.Pow((2 * KE + (KE * KE)), 0.5)));
                                        double beta_sqr = 1 - Math.Pow(0.511 / (KE + 0.511), 2);
                                        double g = (E + 0.511) / (0.511 * Math.Sqrt(1 - Math.Sqrt(beta_sqr)));
                                        double Log_x = 1 - Math.Log((g + Math.Sqrt((g * g) - 1)) / (g - Math.Sqrt((g * g) - 1))) / (2 * g * Math.Sqrt((g * g) - 1));
                                        double dis_cross_2 = (4 / 3) + ((g * (g - 2) / (g + 1)) * Log_x);
                                        double dis_cross_1 = (5 / 4) * 4 * 3.14 * (Math.Pow(atom_no, 5)) / (Math.Pow(137, 4)) * 0.079407850 * Math.Pow(g + 1, 1.5) / Math.Pow(g - 1, 3.5); //0.079 is square of classical electron radius 
                                        cross = photo_at_cons;// dis_cross_1* dis_cross_2;
                                        //}
                                        // New direction of photon
                                        obj_pos.dir_cos(ref e_phi, ref e_theta, ref ncos_phi, ref nsin_phi, ref ncos_theta, ref nsin_theta);
                                        E = 0;
                                    }
                                    else if (r_s > (photo_at_cons / total_at_cons) && r_s <= ((comp_at_cons + photo_at_cons) / total_at_cons))
                                    {
                                        DataRow Comp_pro_row = Comp_pro.NewRow();
                                        Comp = Comp + 1; //Number of Compton Scattering
                                        interaction = "Comp";
                                        if (Ini_E == E)
                                        {
                                            int_point = int_point + 1.1;
                                        }
                                        else
                                        {
                                            int_point = int_point + 0.1;
                                        }
                                        e_point = int_point;

                                        //*********************************************************************************
                                        // Angle (theta) of scattered photon
                                        //*********************************************************************************
                                        // line_Rc = Rc.ReadLine();
                                        //double.TryParse(line_Rc, out r_c);
                                        r_c = rand.NextDouble();

                                        sc = (E / 0.511) / (1 + (0.5625 * (E / 0.511))); // in units of m0c2
                                        Sca_E = (E / 0.511) / (1 + (sc * r_c) + (((2 * (E / 0.511)) - sc) * (Math.Pow(r_c, 3))));//Energy of Scattered photon
                                        Sca_E = Sca_E * 0.511; // in units of MeV
                                        ncos_theta = 1 - (0.511 * ((1 / Sca_E) - (1 / E)));
                                        theta = Math.Acos(ncos_theta); //angle of scattred photon from incident photon
                                        nsin_theta = Math.Sqrt(1 - Math.Pow(ncos_theta, 2));

                                        double pz_photon_n = 0;
                                        pz_photon_n = (Sca_E - E) + (Sca_E * (E / 0.511) * (1 - ncos_theta));
                                        double pz_photon_d = Math.Sqrt(((Sca_E * Sca_E) + (E * E)) - (2 * Sca_E * E * ncos_theta));
                                        double pz_photon = (pz_photon_n * 0.511) / (pz_photon_d); //MeV/c

                                        //********************************************************************************
                                        // Azimuthal angle (phi) of Photon
                                        //********************************************************************************
                                        ncos_phi = obj_dc.cosphi();
                                        nsin_phi = obj_dc.sinphi();
                                        //********************************************************************************
                                        // Angle (theta) of Recoiled electron 
                                        //********************************************************************************
                                        double cot_phi = (1 + ((E / 0.511))) * Math.Tan(theta / 2);
                                        double cosec_phi = Math.Sqrt(1 + (cot_phi * cot_phi));
                                        pie_c = 1 / cosec_phi;
                                        double cos_pie_c = Math.Sqrt(1 - (pie_c * pie_c));
                                        e_theta = Math.Asin(pie_c);
                                        // electron angle with respect to the direction of scattered photon is 3.14159(180 degree)-sca_theta. (angles are in radian)
                                        //********************************************************************************
                                        // Kinetic energy of electron
                                        //********************************************************************************

                                        //KE = (E * (E / 0.511) * (1 - ncos_theta)) / (1 + ((E / 0.511) * (1 - ncos_theta)));
                                        E_elec = E + 0.511 - Sca_E;
                                        // Kinenetic energy of electron using both the formula(E * (E / 0.511) * (1 - ncos_theta)) / (1 + ((E / 0.511) * (1 - ncos_theta))) and KE = E - Sca_E is same.
                                        KE = E - Sca_E;
                                        if (shell == " K ")
                                        {
                                            K_contri = K_contri + 1;
                                        }
                                        else if (shell == " L ")
                                        {
                                            L_contri = L_contri + 1;
                                        }
                                        else if (shell == " M ")
                                        {
                                            M_contri = M_contri + 1;
                                        }
                                        else if (shell == " N ")
                                        {
                                            N_contri = N_contri + 1;
                                        }
                                        else if (shell == " O ")
                                        {
                                            O_contri = O_contri + 1;
                                        }
                                        else if (shell == " P ")
                                        {
                                            P_contri = P_contri + 1;
                                        }

                                        //E_elec = KE + 0.511;
                                        double cons_E = (E_elec + Sca_E - 0.511);

                                        if (E_elec > 1)
                                        {
                                            momentum = Math.Sqrt(((E * E) + (Sca_E * Sca_E) - (2 * E * Sca_E * ncos_theta)) / Math.Pow(c_light, 2)); // MeV/c Momentum of electron
                                            //momentum = Math.Sqrt((E_elec*E_elec)-(0.511*0.511));
                                        }
                                        else
                                        {
                                            momentum = Math.Round(Math.Sqrt(2 * 0.511 * KE / Math.Pow(c_light, 2)), 8); // MeV/c Momentum of electron
                                        }
                                        //**********************************************************************************
                                        // Displacement cross-section
                                        //**********************************************************************************
                                        double E_max = KE;// E - Sca_E;// (2 * E) / ((0.511 / E) + 2);
                                        double dis_cross_1 = (3.14 * Math.Pow(re, 2) * atom_no * 0.511) / (Math.Pow((E-KE), 2));
                                        double dis_cross_2 = Math.Pow((0.511 * KE / Math.Pow(E, 2)),2) + (2 * Math.Pow((E-KE) / E, 2));
                                        double dis_cross_3 = ((E-KE) / Math.Pow(E, 3)) * (Math.Pow((KE - 0.511), 2) - (0.511 * 0.511));
                                        cross = (dis_cross_1 * (dis_cross_2 + dis_cross_3)) * 1e24; // cm2/MeV * 1e24

                                        double elec_phi = obj_dc.cosphi();
                                        e_phi = obj_dc.phi_a();//Math.Acos(obj_dc.cosphi()); 
                                        //e_theta = obj_dc.theta_a();//Math.Acos(obj_dc.costheta());
                                        Comp_pro_row["Serial No"] = int_point;
                                        // Comp_pro_row["Time Photon"] = DateTime.Now.ToString("yyyy-MM-dd");
                                        Comp_pro_row["Spectrum Energy (MeV)"] = Ini_E;
                                        // Comp_pro_row["Initial Photon Energy (MeV)"] = E;
                                        Comp_pro_row["Photon Theta"] = obj_dc.theta_a(); //Math.Acos(cos_theta);
                                        Comp_pro_row["Photon Phi"] = obj_dc.phi_a();// Math.Acos(cos_phi);
                                        Comp_pro_row["Initial Lambda (cm)"] = inl_lambda;
                                        Comp_pro_row["Initial Momentum (MeV/c)"] = ini_p;
                                        Comp_pro_row["Kinetic Energy of electron (MeV)"] = KE;
                                        Comp_pro_row["Shell"] = shell;
                                        Comp_pro_row["Cross-section (b)"] = Comp_dis_cross;
                                        Comp_pro_row["Electron Theta"] = e_theta;
                                        Comp_pro_row["Electron Phi"] = e_phi;
                                        cls_w = E / 10;
                                        E = Sca_E; // MeV Final energy of photon
                                        final_lamda = h * c_light / E; // wavelength of scattered photon
                                        double final_moment = E; // momentum of scattered photon
                                        double lam_shift = final_lamda - inl_lambda;

                                        Comp_pro_row["Scattered Photon Energy (MeV)"] = Sca_E;
                                        Comp_pro_row["Scattered Photon Theta"] = theta;
                                        Comp_pro_row["Scattered Photon Phi"] = Math.Acos(ncos_phi);
                                        Comp_pro_row["Scattered Photon momentum (MeV/c)"] = final_moment;
                                        Comp_pro_row["lambda shift"] = lam_shift;
                                        Comp_pro.Rows.Add(Comp_pro_row);
                                        Comp_pro_row = null;
                                        // fermi_P = Math.Sqrt(2 * fermi_E * 0.511);
                                        cls_w = E / 10;

                                        for (int j = 0; j <= no_class; j++)
                                        {
                                            if (KE > ((j - 1) * cls_w) && KE <= (j * cls_w))
                                            {
                                                n_moment[j] = n_moment[j] + 1;
                                                pz[j] = pz[j] + Comp_dis_cross;
                                            }
                                            else
                                            {
                                                n_moment[j] = n_moment[j];
                                                pz[j] = pz[j];
                                            }
                                        }
                                        if (iz0 == V_c || iz0 == 0)
                                        {
                                            new_u = nsin_theta * ncos_phi;
                                            new_v = nsin_theta * nsin_phi;
                                            new_w = ncos_theta * Math.Sign(w);
                                        }
                                        else
                                        {
                                            new_u = (ncos_theta * u) + ((nsin_theta * ncos_phi * w * u) + (nsin_theta * nsin_phi * v)) / Math.Sqrt(1 - Math.Pow(w, 2));
                                            new_v = (ncos_theta * v) + ((nsin_theta * ncos_phi * w * v) + (nsin_theta * nsin_phi * u)) / Math.Sqrt(1 - Math.Pow(w, 2));
                                            new_w = (ncos_theta * w) - (Math.Sqrt(1 - Math.Pow(w, 2)) * nsin_theta * ncos_phi);
                                        }
                                        u = new_u;
                                        v = new_v;
                                        w = new_w;
                                        ix = ix0;
                                        iy = iy0;
                                        iz = iz0;
                                    }
                                    else if (r_s > ((photo_at_cons + comp_at_cons) / total_at_cons) && r_s <= ((comp_at_cons + photo_at_cons + pair_at_cons) / total_at_cons) && (E > 0.511))
                                    {
                                        PP = PP + 1;
                                        interaction = "PP";
                                        if (Ini_E == E)
                                        {
                                            int_point = int_point + 1.1;
                                        }
                                        else
                                        {
                                            int_point = int_point + 0.1;
                                        }
                                        e_point = int_point;
                                        if (shell == " K ")
                                        {
                                            K_contri = K_contri + 1;
                                        }
                                        else if (shell == " L ")
                                        {
                                            L_contri = L_contri + 1;
                                        }
                                        else if (shell == " M ")
                                        {
                                            M_contri = M_contri + 1;
                                        }
                                        else if (shell == " N ")
                                        {
                                            N_contri = N_contri + 1;
                                        }
                                        else if (shell == " O ")
                                        {
                                            O_contri = O_contri + 1;
                                        }
                                        else if (shell == " P ")
                                        {
                                            P_contri = P_contri + 1;
                                        }

                                        KE = (E - (2 * 0.511)) / 2;
                                        E_elec = KE + 0.511;

                                        if (E_elec > 1)
                                        {
                                            //momentum = Math.Sqrt((E*E)+(Sca_E*Sca_E) - (2*E*Sca_E*ncos_theta)); // MeV/c Momentum of electron
                                            momentum = Math.Sqrt(((E_elec * E_elec) - (0.511 * 0.511)) / Math.Pow(c_light, 2));
                                        }
                                        else
                                        {
                                            momentum = Math.Sqrt(2 * 0.511 * KE / Math.Pow(c_light, 2)); // MeV/c Momentum of electron
                                        }
                                        if (E > 4)
                                        {
                                            cross = (2.8 * Math.Pow(10, -4)) * Math.Pow(atom_no, 2) * ((3.1111 * (Math.Log((2 * E) / 0.511))) - (8.0740));
                                            //PP_dis_cross = pair_cross_sect;
                                        }
                                        else
                                        {
                                            double pp_u = Math.Log(E / 0.511);
                                            double g_u = (-0.1835 * Math.Pow(pp_u, 3)) + (1.653 * Math.Pow(pp_u, 2)) - (2.1543 * pp_u) + 0.7614;
                                            double h_u = (0.2193 * pp_u) + 0.1825;
                                            double PP_s = KE / (E - 1.02);
                                            double F_s = g_u * ((h_u * (1 - (Math.Pow(2, 8) * Math.Pow((PP_s - 0.5), 8)))) + ((1 - h_u) * (1 - (Math.Pow(2, 2) * Math.Pow((PP_s - 0.5), 2)))));
                                            cross = (Math.Pow(atom_no, 2) / 137) * 0.079407858 * F_s / (E - 1.02);
                                        }
                                        E = 0;
                                        // New direction of photon
                                        obj_pos.dir_cos(ref e_phi, ref e_theta, ref ncos_phi, ref nsin_phi, ref ncos_theta, ref nsin_theta);
                                    }

                                    //=================================================================
                                    //-------Electron trajectory---------------------------------------
                                    //=================================================================
                                    if (KE >= e_th_E)
                                    {
                                        Fix_KE = KE;
                                        double elec_path_l = 0, e_cross = 0, E_trans_PKA = 0, elec_ix = 0, elec_iy = 0, elec_iz = 0;
                                        //***********************************************************************
                                        // Initial directions of electron
                                        //***********************************************************************
                                        double e_u = Math.Sin(e_theta) * Math.Cos(e_phi);
                                        double e_v = Math.Sin(e_theta) * Math.Sin(e_phi);
                                        double e_w = Math.Cos(e_theta);
                                        double N_out = 0, intes = 0;

                                        while (KE >= e_th_E)
                                        {
                                            e_point = e_point + 0.1;
                                            obj_pos.e_l(KE, atom_no, atom_d, Atom_wt, ref e_cross, ref elec_path_l); //PKA cross section unit cm-1
                                            dE = objStpo.Cal_Col_StopingPower(KE, atom_no, d, Atom_wt) + objStpo.Cal_Rad_StopingPower(KE, atom_no, d, Atom_wt);
                                            //dE is in the unit of MeV-cm2/gm. So multiply dE by density d(gm/cm3) Ambika Tundwal..21July2015
                                            dE = dE * d;
                                            KE = KE - (dE * elec_path_l);
                                            if (KE < (dE * elec_path_l))
                                            {
                                                KE = KE + (dE * elec_path_l);
                                                elec_path_l = KE / dE;
                                                KE = KE - (dE * elec_path_l);
                                            }
                                            //***********************************************************************
                                            // final position of electron
                                            //***********************************************************************
                                            obj_pos.next_pos(elec_x0, elec_y0, elec_z0, elec_path_l, e_u, e_v, e_w, ref elec_x, ref elec_y, ref elec_z);

                                            if (((elec_x >= 0) && (elec_x <= V_a)) && ((elec_y >= 0) && (elec_y <= V_b)) && (((elec_z >= 0) && (elec_z <= V_c))))
                                            {//call function of lattice coordinate
                                                obj_pos.lat_cord(elec_x, elec_y, elec_z, a, b, c, ref elec_ix, ref elec_iy, ref elec_iz);

                                                if (KE >= e_th_E)
                                                {
                                                    e_his = e_his + 1;
                                                    mindis=obj_elec.struc(elec_ix, elec_iy, elec_iz, elec_x0, elec_y0, elec_z0, elec_x, elec_y, elec_z, a, b, c, epoint, N0, bin, atom_no, N);
                                                    // minimum distance of electron with the atoms of unit cell
                                                    close_atom = obj_elec.close(elec_ix, elec_iy, elec_iz, elec_x0, elec_y0, elec_z0, elec_x, elec_y, elec_z, a, b, c, apoint, N0, bin, atom_no, N, ref atom_x0, ref atom_y0, ref atom_z0);
                                                    if (mindis <= K_r)
                                                     {
                                                        //***********************************************************************
                                                        // New directions of elec 
                                                        //***********************************************************************
                                                        obj_pos.dir_cos(ref e_phi, ref e_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);

                                                        E_trans_PKA = 2 * KE * (KE + (2 * 0.511)) * Math.Pow(Math.Sin(e_theta), 2) / (M * (Math.Pow((c_light), 2)));
                                                        rem_KE = KE - E_trans_PKA;
                                                        double Pka_Sin_theta = -(Math.Sqrt((rem_KE * rem_KE) - (0.511 * 0.511)) / c_light) * Math.Sin(e_theta) / Math.Sqrt(2 * M * E_trans_PKA);
                                                        double Pka_theta = Math.Asin(Pka_Sin_theta);

                                                        E_PKA = E_trans_PKA;

                                                        if (E_trans_PKA >= th_E)
                                                        {
                                                            double  dum_theta = 0;
                                                            double atom_phi = 0, atom_theta=0, atom_u = 0, atom_v = 0, atom_w = 0, pka_cross = 0, PKA_path_l = 0, atom_ix = 0, atom_iy = 0, atom_iz = 0,Rem_PKA=0;
                                                            int gen = 0;
                                                            //***********************************************************************
                                                            // New directions of PKA 
                                                            //***********************************************************************
                                                            obj_pos.dir_cos(ref atom_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                            atom_u = cos_phi * Pka_Sin_theta;
                                                            atom_v = Pka_Sin_theta * sin_phi;
                                                            atom_w = Math.Sqrt(1 - Math.Pow(Pka_Sin_theta, 2));
                                                            N_NRT = ((0.8 * E_trans_PKA) / (2 * th_E)) + N_NRT;
                                                            a_point = e_point;

                                                            while (E_trans_PKA >= th_E)
                                                            {
                                                                obj_pos.p_l(E_trans_PKA, atom_no, ref pka_cross, ref PKA_path_l); //PKA cross section unit cm-1
                                                                dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_PKA, atom_no, d, Atom_wt);
                                                                E_trans_PKA = E_trans_PKA - (dE_atom * PKA_path_l);

                                                                if (E_trans_PKA < (dE_atom * PKA_path_l))
                                                                {
                                                                    E_trans_PKA = E_trans_PKA + (dE_atom * PKA_path_l);
                                                                    PKA_path_l = E_trans_PKA / dE_atom;
                                                                    E_trans_PKA = E_trans_PKA - (dE_atom * PKA_path_l);
                                                                }
                                                                //***********************************************************************
                                                                // Position of PKA
                                                                //***********************************************************************
                                                                obj_pos.next_pos(atom_x0, atom_y0, atom_z0, PKA_path_l, atom_u, atom_v, atom_w, ref atom_x, ref atom_y, ref atom_z);
                                                                if (((atom_x >= 0) && (atom_x <= V_a)) && ((atom_y >= 0) && (atom_y <= V_b)) && (((atom_z >= 0) && (atom_z <= V_c))))
                                                                {//call function of lattice coordinate
                                                                    obj_pos.lat_cord(atom_x, atom_y, atom_z, a, b, c, ref atom_ix, ref atom_iy, ref atom_iz);
                                                                    //pka_point = pka_point + 1; // number of PKA histories inside the target
                                                                    if (E_trans_PKA >= th_E) // because dE is included in MC simulation
                                                                    {
                                                                        double SKA_x0 = 0, SKA_y0 = 0, SKA_z0 = 0, E_trans_SKA = 0;
                                                                        if (PKA_path_l >= 0.75e-8)
                                                                        {//displaced atom that will further generate cascade
                                                                            PKA = PKA + 1;
                                                                            // a vacancy is created at the position SKA_x0, SKA_y0, SKA_z0
                                                                            int_type = "Disp PKA";

                                                                            if (int_type == "Disp PKA")
                                                                            {
                                                                                vac_hist = obj_pos.vac_his(elec_ix, elec_iy, elec_iz, a, b, c, a_point, gen, atom_no, atom_x0, atom_y0, atom_z0, E_trans_PKA, E_PKA, int_type);
                                                                                vac_h.Merge(vac_hist);
                                                                            }
                                                                            PKA_hist = obj_pos.PKA_his(a_point, Fix_KE, KE, elec_x, elec_y, elec_z, dE_atom, PKA_path_l, E_trans_PKA, atom_x0, atom_y0, atom_z0, pka_cross, int_type);
                                                                            PKA_h.Merge(PKA_hist);

                                                                            obj_pka.struc(atom_ix, atom_iy, atom_iz, atom_x0, atom_y0, atom_z0, atom_x, atom_y, atom_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                            // minimum distance of PKA with the atoms of unit cell
                                                                            close_atom = obj_pka.close(atom_ix, atom_iy, atom_iz, atom_x0, atom_y0, atom_z0, atom_x, atom_y, atom_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref SKA_x0, ref SKA_y0, ref SKA_z0);
                                                                            //if (mindis<= 2*4.761e-9)
                                                                            //***********************************************************************
                                                                            // New directions of PKA 
                                                                            //***********************************************************************
                                                                            obj_pos.dir_cos(ref atom_phi, ref atom_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                            // the value of theta should be between 0 to 90 degree in lab frame of reference
                                                                            E_trans_SKA = obj_atom_cross.Cal_KE_SKA(E_trans_PKA, atom_no, d, Atom_wt, (atom_theta));//in MeV
                                                                            double ska_sin_theta = 0, ska_phi = 0, ska_theta = 0;
                                                                            ska_theta = (3.14159 / 2) - (atom_theta);
                                                                            //double E_trans_new = E * Math.Pow(Math.Cos(ska_theta), 2);
                                                                            //double E_ratio = Math.Sqrt((Double)(E-E_trans) / (Double)E_trans);
                                                                            // ska_sin_theta = Math.Sin(atom_theta) * E_ratio;// *Math.Sin(atom_theta / (Double)2);
                                                                            // ska_theta = Math.Asin(ska_sin_theta);
                                                                            a_point = a_point + 0.01;
                                                                            gen = 1;
                                                                            Rem_PKA = E_trans_PKA - E_trans_SKA;
                                                                            //E_trans_SKA = E_trans_SKA - th_E;
                                                                            if (E_trans_SKA >= th_E)
                                                                            {
                                                                                double SKA_u = 0, SKA_v = 0, SKA_w = 0, SKA_path_l = 0, SKA_ix = 0, SKA_iy = 0, SKA_iz = 0,Rem_SKA = 0, s_point = 0, ska_cross = 0, SKA_x = 0, SKA_y = 0, SKA_z = 0;
                                                                                //***********************************************************************
                                                                                // Directions of SKA
                                                                                //***********************************************************************
                                                                                ska_sin_theta = Math.Sin(ska_theta);
                                                                                obj_pos.dir_cos(ref ska_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                SKA_u = cos_phi * ska_sin_theta;
                                                                                SKA_v = sin_phi * ska_sin_theta;
                                                                                SKA_w = Math.Sqrt(1 - Math.Pow(ska_sin_theta, 2));
                                                                                //ska_phi = obj_dc.phi_a();
                                                                                void_cord = new double[3];
                                                                                void_cord[0] = SKA_x0;
                                                                                void_cord[1] = SKA_y0;
                                                                                void_cord[2] = SKA_z0;
                                                                                atom_list.Add(void_cord);
                                                                                gen = 2;
                                                                                //Since we are interested in dose calculation for 1 cm thickness so we do not account for vacancy and interstitials. (on 29/08/2014)
                                                                                s_point = a_point;

                                                                                while (E_trans_SKA >= th_E)
                                                                                {//history of SKA
                                                                                    obj_pos.p_l(E_trans_SKA, atom_no, ref ska_cross, ref SKA_path_l);
                                                                                    dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_SKA, atom_no, d, Atom_wt);
                                                                                    E_trans_SKA = E_trans_SKA - (dE_atom * SKA_path_l);
                                                                                    if (E_trans_SKA < (dE_atom * SKA_path_l))
                                                                                    {
                                                                                        E_trans_SKA = E_trans_SKA + (dE_atom * SKA_path_l);
                                                                                        SKA_path_l = E_trans_SKA / dE_atom;
                                                                                        E_trans_SKA = E_trans_SKA - (dE_atom * SKA_path_l);
                                                                                    }
                                                                                    //**********************************************************************
                                                                                    // Position of SKA
                                                                                    //***********************************************************************
                                                                                    obj_pos.next_pos(SKA_x0, SKA_y0, SKA_z0, SKA_path_l, SKA_u, SKA_v, SKA_w, ref SKA_x, ref SKA_y, ref SKA_z);

                                                                                    if (((SKA_x >= 0) && (SKA_x <= V_a)) && ((SKA_y >= 0) && (SKA_y <= V_b)) && (((SKA_z >= 0) && (SKA_z <= V_c))))
                                                                                    {
                                                                                        obj_pos.lat_cord(SKA_x, SKA_y, SKA_z, a, b, c, ref SKA_ix, ref SKA_iy, ref SKA_iz);
                                                                                       // ska_point = ska_point + 1;// number of SKA histories inside the target
                                                                                        s_point = s_point + 0.001;

                                                                                        if (E_trans_SKA >= th_E)
                                                                                        {
                                                                                            double TKA_x0 = 0, TKA_y0 = 0, TKA_z0 = 0, E_trans_TKA = 0;
                                                                                            if (SKA_path_l >= 0.75e-8)
                                                                                            {//displaced atom that will further generate cascade
                                                                                                SKA = SKA + 1;
                                                                                                // a vacancy is created at the position SKA_x0, SKA_y0, SKA_z0

                                                                                                int_type = "Disp SKA";

                                                                                                if (int_type == "Disp SKA")
                                                                                                {
                                                                                                    vac_hist = obj_pos.vac_his(atom_ix, atom_iy, atom_iz, a, b, c, a_point, gen, atom_no, SKA_x0, SKA_y0, SKA_z0, E_trans_SKA, E_PKA, int_type);
                                                                                                    vac_h.Merge(vac_hist);
                                                                                                }

                                                                                                PKA_hist = obj_pos.PKA_his(s_point, E_PKA, E_trans_PKA, atom_x, atom_y, atom_z, dE_atom, SKA_path_l, E_trans_SKA, SKA_x0, SKA_y0, SKA_z0, ska_cross, int_type);
                                                                                                PKA_h.Merge(PKA_hist);

                                                                                                obj_pka.struc(SKA_ix, SKA_iy, SKA_iz, SKA_x0, SKA_y0, SKA_z0, SKA_x, SKA_y, SKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                close_atom = obj_pka.close(SKA_ix, SKA_iy, SKA_iz, SKA_x0, SKA_y0, SKA_z0, SKA_x, SKA_y, SKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref TKA_x0, ref TKA_y0, ref TKA_z0);
                                                                                                //***********************************************************************
                                                                                                // New directions of SKA 
                                                                                                //***********************************************************************
                                                                                                obj_pos.dir_cos(ref ska_phi, ref ska_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                //ska_phi = obj_dc.cosphi(); // to change random number r1 r2
                                                                                                //ska_phi = obj_dc.phi_a();
                                                                                                //ska_theta = obj_dc.theta_a();

                                                                                                E_trans_TKA = obj_atom_cross.Cal_KE_SKA(E_trans_SKA, atom_no, d, Atom_wt, ska_theta);//in MeV
                                                                                                Rem_SKA = E_trans_SKA - E_trans_TKA;

                                                                                                double tka_s_theta = 0, tka_phi = 0, tka_theta = 0;

                                                                                                tka_theta = (3.14159 / 2) - ska_theta;//Math.Sqrt(E_trans / E_trans_TKA) * Math.Sign(ska_theta);
                                                                                                tka_s_theta = Math.Sin(tka_theta);// 
                                                                                                //E_trans_TKA = E_trans_TKA - th_E;

                                                                                                if (E_trans_TKA >= th_E)
                                                                                                {
                                                                                                    double TKA_u = 0, TKA_v = 0, TKA_w = 0, TKA_path_l = 0, TKA_ix = 0, TKA_iy = 0, TKA_iz = 0, Rem_TKA = 0, t_point = 0, tka_cross = 0, TKA_x = 0, TKA_y = 0, TKA_z = 0;
                                                                                                    //***********************************************************************
                                                                                                    // Directions of TKA
                                                                                                    //***********************************************************************
                                                                                                    obj_pos.dir_cos(ref tka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                    TKA_u = cos_phi * tka_s_theta;
                                                                                                    TKA_v = sin_phi * tka_s_theta;
                                                                                                    TKA_w = Math.Sqrt(1 - Math.Pow(tka_s_theta, 2));
                                                                                                    gen = 3;
                                                                                                    void_cord = new double[3];
                                                                                                    void_cord[0] = TKA_x0;
                                                                                                    void_cord[1] = TKA_y0;
                                                                                                    void_cord[2] = TKA_z0;
                                                                                                    atom_list.Add(void_cord);
                                                                                                    //Since we are interested in dose calculation for 1 cm thickness so we do not account for vacancy and interstitials. (on 29/08/2014)
                                                                                                    t_point = s_point;

                                                                                                    while (E_trans_TKA >= th_E)
                                                                                                    {
                                                                                                        //history of TKA
                                                                                                        obj_pos.p_l(E_trans_TKA, atom_no, ref tka_cross, ref TKA_path_l);
                                                                                                        dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_TKA, atom_no, d, Atom_wt);
                                                                                                        E_trans_TKA = E_trans_TKA - (dE_atom * TKA_path_l);
                                                                                                        if (E_trans_TKA < (dE_atom * TKA_path_l))
                                                                                                        {
                                                                                                            E_trans_TKA = E_trans_TKA + (dE_atom * TKA_path_l);
                                                                                                            TKA_path_l = E_trans_TKA / dE_atom;
                                                                                                            E_trans_TKA = E_trans_TKA - (dE_atom * TKA_path_l);
                                                                                                        }
                                                                                                        //**********************************************************************
                                                                                                        // Position of TKA
                                                                                                        //***********************************************************************
                                                                                                        obj_pos.next_pos(TKA_x0, TKA_y0, TKA_z0, TKA_path_l, TKA_u, TKA_v, TKA_w, ref TKA_x, ref TKA_y, ref TKA_z);

                                                                                                        if (((TKA_x >= 0) && (TKA_x <= V_a)) && ((TKA_y >= 0) && (TKA_y <= V_b)) && (((TKA_z >= 0) && (TKA_z <= V_c))))
                                                                                                        {
                                                                                                            obj_pos.lat_cord(TKA_x, TKA_y, TKA_z, a, b, c, ref TKA_ix, ref TKA_iy, ref TKA_iz);
                                                                                                            //tpoint = tpoint + 1;// number of TKA histories inside the target
                                                                                                            t_point = t_point + 0.0001;
                                                                                                            if (E_trans_TKA >= th_E)
                                                                                                            {
                                                                                                                double FKA_x0 = 0, FKA_y0 = 0, FKA_z0 = 0, E_trans_FKA = 0;
                                                                                                                if (TKA_path_l >= 0.75e-8)
                                                                                                                {
                                                                                                                    TKA = TKA + 1;
                                                                                                                    int_type = "Disp TKA";
                                                                                                                    if (int_type == "Disp TKA")
                                                                                                                    {
                                                                                                                        vac_hist = obj_pos.vac_his(SKA_ix, SKA_iy, SKA_iz, a, b, c, s_point, gen, atom_no, TKA_x0, TKA_y0, TKA_z0, E_trans_TKA, E_PKA, int_type);
                                                                                                                        vac_h.Merge(vac_hist);
                                                                                                                    }

                                                                                                                    PKA_hist = obj_pos.PKA_his(t_point, E_PKA, E_trans_SKA, SKA_x, SKA_y, SKA_z, dE_atom, TKA_path_l, E_trans_TKA, TKA_x0, TKA_y0, TKA_z0, tka_cross, int_type);
                                                                                                                    PKA_h.Merge(PKA_hist);
                                                                                                                    obj_pka.struc(TKA_ix, TKA_iy, TKA_iz, TKA_x0, TKA_y0, TKA_z0, TKA_x, TKA_y, TKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                    close_atom = obj_pka.close(TKA_ix, TKA_iy, TKA_iz, TKA_x0, TKA_y0, TKA_z0, TKA_x, TKA_y, TKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref FKA_x0, ref FKA_y0, ref FKA_z0);
                                                                                                                    //***********************************************************************
                                                                                                                    // New directions of TKA 
                                                                                                                    //***********************************************************************
                                                                                                                    obj_pos.dir_cos(ref tka_phi, ref tka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);

                                                                                                                    E_trans_FKA = obj_atom_cross.Cal_KE_SKA(E_trans_TKA, atom_no, d, Atom_wt, tka_theta);//in MeV

                                                                                                                    Rem_TKA = E_trans_TKA - E_trans_FKA;
                                                                                                                    double fka_phi = 0;
                                                                                                                    double fka_theta = (3.14159 / 2) - tka_theta;//Math.Sqrt(E_trans / E_trans_TKA) * Math.Sign(ska_theta);
                                                                                                                    double fka_s_theta = Math.Sin(fka_theta);
                                                                                                                    //E_trans_FKA = E_trans_FKA - th_E;
                                                                                                                    if (E_trans_FKA >= th_E)
                                                                                                                    {
                                                                                                                        double FKA_u = 0, FKA_v = 0, FKA_w = 0, FKA_path_l = 0, FKA_ix = 0, FKA_iy = 0, FKA_iz = 0, Rem_FKA = 0, f_point = 0, fka_cross = 0, FKA_x = 0, FKA_y = 0, FKA_z = 0;
                                                                                                                        //***********************************************************************
                                                                                                                        // Directions of FKA
                                                                                                                        //***********************************************************************
                                                                                                                        obj_pos.dir_cos(ref fka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                        FKA_u = cos_phi * fka_s_theta;
                                                                                                                        FKA_v = sin_phi * fka_s_theta;
                                                                                                                        FKA_w = Math.Sqrt(1 - Math.Pow(fka_s_theta, 2));
                                                                                                                        gen = 4;
                                                                                                                        void_cord = new double[3];
                                                                                                                        void_cord[0] = FKA_x0;
                                                                                                                        void_cord[1] = FKA_y0;
                                                                                                                        void_cord[2] = FKA_z0;
                                                                                                                        atom_list.Add(void_cord);
                                                                                                                        //Since we are interested in dose calculation for 1 cm thickness so we do not account for vacancy and interstitials. (on 29/08/2014)
                                                                                                                        f_point = t_point;
                                                                                                                        while (E_trans_FKA >= th_E)
                                                                                                                        {
                                                                                                                            obj_pos.p_l(E_trans_FKA, atom_no, ref fka_cross, ref FKA_path_l);
                                                                                                                            dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_FKA, atom_no, d, Atom_wt);
                                                                                                                            E_trans_FKA = E_trans_FKA - (dE_atom * FKA_path_l);
                                                                                                                            if (E_trans_FKA < (dE_atom * FKA_path_l))
                                                                                                                            {
                                                                                                                                E_trans_FKA = E_trans_FKA + (dE_atom * FKA_path_l);
                                                                                                                                FKA_path_l = E_trans_FKA / dE_atom;
                                                                                                                                E_trans_FKA = E_trans_FKA - (dE_atom * FKA_path_l);
                                                                                                                            }
                                                                                                                            //**********************************************************************
                                                                                                                            // Position of FKA
                                                                                                                            //***********************************************************************
                                                                                                                            obj_pos.next_pos(FKA_x0, FKA_y0, FKA_z0, FKA_path_l, FKA_u, FKA_v, FKA_w, ref FKA_x, ref FKA_y, ref FKA_z);

                                                                                                                            if (((FKA_x >= 0) && (FKA_x <= V_a)) && ((FKA_y >= 0) && (FKA_y <= V_b)) && (((FKA_z >= 0) && (FKA_z <= V_c))))
                                                                                                                            {
                                                                                                                                obj_pos.lat_cord(FKA_x, FKA_y, FKA_z, a, b, c, ref FKA_ix, ref FKA_iy, ref FKA_iz);
                                                                                                                                //fpoint = fpoint + 1;// number of TKA histories inside the target
                                                                                                                                f_point = f_point + 0.00001;
                                                                                                                                if (E_trans_FKA >= th_E)
                                                                                                                                {
                                                                                                                                    double PtKA_x0 = 0, PtKA_y0 = 0, PtKA_z0 = 0, E_trans_PtKA = 0;
                                                                                                                                    if (FKA_path_l >= 0.75e-8)
                                                                                                                                    {
                                                                                                                                        FKA = FKA + 1;
                                                                                                                                        int_type = "Disp FKA";

                                                                                                                                        if (int_type == "Disp FKA")
                                                                                                                                        {
                                                                                                                                            vac_hist = obj_pos.vac_his(TKA_ix, TKA_iy, TKA_iz, a, b, c, t_point, gen, atom_no, FKA_x0, FKA_y0, FKA_z0, E_trans_FKA, E_PKA, int_type);
                                                                                                                                            vac_h.Merge(vac_hist);
                                                                                                                                        }

                                                                                                                                        PKA_hist = obj_pos.PKA_his(f_point, E_PKA, E_trans_TKA, TKA_x, TKA_y, TKA_z, dE_atom, FKA_path_l, E_trans_FKA, FKA_x0, FKA_y0, FKA_z0, fka_cross, int_type);
                                                                                                                                        PKA_h.Merge(PKA_hist);
                                                                                                                                        obj_pka.struc(FKA_ix, FKA_iy, FKA_iz, FKA_x0, FKA_y0, FKA_z0, FKA_x, FKA_y, FKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                        close_atom = obj_pka.close(FKA_ix, FKA_iy, FKA_iz, FKA_x0, FKA_y0, FKA_z0, FKA_x, FKA_y, FKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref PtKA_x0, ref PtKA_y0, ref PtKA_z0);
                                                                                                                                        //***********************************************************************
                                                                                                                                        // New directions of FKA 
                                                                                                                                        //***********************************************************************
                                                                                                                                        obj_pos.dir_cos(ref fka_phi, ref fka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                        E_trans_PtKA = obj_atom_cross.Cal_KE_SKA(E_trans_FKA, atom_no, d, Atom_wt, fka_theta);//in MeV

                                                                                                                                        Rem_FKA = E_trans_FKA - E_trans_PtKA;
                                                                                                                                        double Ptka_phi = 0;
                                                                                                                                        double Ptka_theta = (3.14159 / 2) - fka_theta;
                                                                                                                                        double Ptka_s_theta = Math.Sin(Ptka_theta);
                                                                                                                                        //E_trans_PtKA = E_trans_PtKA - th_E;
                                                                                                                                        if (E_trans_PtKA > th_E)
                                                                                                                                        {
                                                                                                                                            double PtKA_u = 0, PtKA_v = 0, PtKA_w = 0, PtKA_path_l = 0, PtKA_ix = 0, PtKA_iy = 0, PtKA_iz = 0, Rem_PtKA = 0, pt_point = 0, Ptka_cross = 0, PtKA_x = 0, PtKA_y = 0, PtKA_z = 0;
                                                                                                                                            //***********************************************************************
                                                                                                                                            // Directions of PtKA
                                                                                                                                            //***********************************************************************
                                                                                                                                            obj_pos.dir_cos(ref Ptka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                            PtKA_u = cos_phi * Ptka_s_theta;
                                                                                                                                            PtKA_v = sin_phi * Ptka_s_theta;
                                                                                                                                            PtKA_w = Math.Sqrt(1 - Math.Pow(Ptka_s_theta, 2));
                                                                                                                                            gen = 5;
                                                                                                                                            void_cord = new double[3];
                                                                                                                                            void_cord[0] = PtKA_x0;
                                                                                                                                            void_cord[1] = PtKA_y0;
                                                                                                                                            void_cord[2] = PtKA_z0;
                                                                                                                                            atom_list.Add(void_cord);
                                                                                                                                            //Since we are interested in dose calculation for 1 cm thickness so we do not account for vacancy and interstitials. (on 29/08/2014)
                                                                                                                                            pt_point = f_point;
                                                                                                                                            while (E_trans_PtKA >= th_E)
                                                                                                                                            {
                                                                                                                                                obj_pos.p_l(E_trans_PtKA, atom_no, ref Ptka_cross, ref PtKA_path_l);
                                                                                                                                                dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_PtKA, atom_no, d, Atom_wt);
                                                                                                                                                E_trans_PtKA = E_trans_PtKA - (dE_atom * PtKA_path_l);

                                                                                                                                                if (E_trans_PtKA < (dE_atom * PtKA_path_l))
                                                                                                                                                {
                                                                                                                                                    E_trans_PtKA = E_trans_PtKA + (dE_atom * PtKA_path_l);
                                                                                                                                                    PtKA_path_l = E_trans_PtKA / dE_atom;
                                                                                                                                                    E_trans_PtKA = E_trans_PtKA - (dE_atom * PtKA_path_l);
                                                                                                                                                }
                                                                                                                                                //**********************************************************************
                                                                                                                                                // Position of FKA
                                                                                                                                                //***********************************************************************
                                                                                                                                                obj_pos.next_pos(PtKA_x0, PtKA_y0, PtKA_z0, PtKA_path_l, PtKA_u, PtKA_v, PtKA_w, ref PtKA_x, ref PtKA_y, ref PtKA_z);

                                                                                                                                                if (((PtKA_x >= 0) && (PtKA_x <= V_a)) && ((PtKA_y >= 0) && (PtKA_y <= V_b)) && (((PtKA_z >= 0) && (PtKA_z <= V_c))))
                                                                                                                                                {
                                                                                                                                                    obj_pos.lat_cord(PtKA_x, PtKA_y, PtKA_z, a, b, c, ref PtKA_ix, ref PtKA_iy, ref PtKA_iz);
                                                                                                                                                    //ptpoint = ptpoint + 1;// number of PtKA histories inside the target
                                                                                                                                                    pt_point = pt_point + 0.000001;
                                                                                                                                                    if (E_trans_PtKA >= th_E)
                                                                                                                                                    {
                                                                                                                                                        //PtKA = PtKA + 1;
                                                                                                                                                        double SxKA_x0 = 0, SxKA_y0 = 0, SxKA_z0 = 0, E_trans_SxKA = 0;
                                                                                                                                                        if (PtKA_path_l >= 0.75e-8)
                                                                                                                                                        {
                                                                                                                                                            PtKA = PtKA + 1;
                                                                                                                                                            int_type = "Disp PtKA";

                                                                                                                                                            if (int_type == "Disp PtKA")
                                                                                                                                                            {
                                                                                                                                                                vac_hist = obj_pos.vac_his(FKA_ix, FKA_iy, FKA_iz, a, b, c, f_point, gen, atom_no, PtKA_x0, PtKA_y0, PtKA_z0, E_trans_PtKA, E_PKA, int_type);
                                                                                                                                                                vac_h.Merge(vac_hist);
                                                                                                                                                            }

                                                                                                                                                            PKA_hist = obj_pos.PKA_his(pt_point, E_PKA, E_trans_FKA, FKA_x, FKA_y, FKA_z, dE_atom, PtKA_path_l, E_trans_PtKA, PtKA_x0, PtKA_y0, PtKA_z0, Ptka_cross, int_type);
                                                                                                                                                            PKA_h.Merge(PKA_hist);
                                                                                                                                                            obj_pka.struc(PtKA_ix, PtKA_iy, PtKA_iz, PtKA_x0, PtKA_y0, PtKA_z0, PtKA_x, PtKA_y, PtKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                                            close_atom = obj_pka.close(PtKA_ix, PtKA_iy, PtKA_iz, PtKA_x0, PtKA_y0, PtKA_z0, PtKA_x, PtKA_y, PtKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref SxKA_x0, ref SxKA_y0, ref SxKA_z0);
                                                                                                                                                            //***********************************************************************
                                                                                                                                                            // New directions of PtKA 
                                                                                                                                                            //***********************************************************************
                                                                                                                                                            obj_pos.dir_cos(ref Ptka_phi, ref Ptka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                            E_trans_SxKA = obj_atom_cross.Cal_KE_SKA(E_trans_PtKA, atom_no, d, Atom_wt, Ptka_theta);//in MeV

                                                                                                                                                            Rem_PtKA = E_trans_PtKA - E_trans_SxKA;
                                                                                                                                                            double Sxka_phi = 0;
                                                                                                                                                            double Sxka_theta = (3.14159 / 2) - Ptka_theta;
                                                                                                                                                            double Sxka_s_theta = Math.Sin(Sxka_theta);
                                                                                                                                                            //E_trans_SxKA = E_trans_SxKA - th_E;
                                                                                                                                                            if (E_trans_SxKA > th_E)
                                                                                                                                                            {
                                                                                                                                                                double SxKA_u = 0, SxKA_v = 0, SxKA_w = 0, SxKA_path_l = 0, SxKA_ix = 0, SxKA_iy = 0, SxKA_iz = 0, Rem_SxKA = 0, sx_point = 0, Sxka_cross = 0, SxKA_x = 0, SxKA_y = 0, SxKA_z = 0;
                                                                                                                                                                //***********************************************************************
                                                                                                                                                                // Directions of SxKA
                                                                                                                                                                //***********************************************************************
                                                                                                                                                                obj_pos.dir_cos(ref Sxka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                SxKA_u = cos_phi * Sxka_s_theta;
                                                                                                                                                                SxKA_v = sin_phi * Sxka_s_theta;
                                                                                                                                                                SxKA_w = Math.Sqrt(1 - Math.Pow(Sxka_s_theta, 2));
                                                                                                                                                                gen = 6;
                                                                                                                                                                void_cord = new double[3];
                                                                                                                                                                void_cord[0] = SxKA_x0;
                                                                                                                                                                void_cord[1] = SxKA_y0;
                                                                                                                                                                void_cord[2] = SxKA_z0;
                                                                                                                                                                atom_list.Add(void_cord);
                                                                                                                                                                //Since we are interested in dose calculation for 1 cm thickness so we do not account for vacancy and interstitials. (on 29/08/2014)
                                                                                                                                                                sx_point = pt_point;
                                                                                                                                                                while (E_trans_SxKA >= th_E)
                                                                                                                                                                {
                                                                                                                                                                    obj_pos.p_l(E_trans_SxKA, atom_no, ref Sxka_cross, ref SxKA_path_l);
                                                                                                                                                                    dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_SxKA, atom_no, d, Atom_wt);
                                                                                                                                                                    E_trans_SxKA = E_trans_SxKA - (dE_atom * SxKA_path_l);
                                                                                                                                                                    if (E_trans_SxKA < (dE_atom * SxKA_path_l))
                                                                                                                                                                    {
                                                                                                                                                                        E_trans_SxKA = E_trans_SxKA + (dE_atom * SxKA_path_l);
                                                                                                                                                                        SxKA_path_l = E_trans_SxKA / dE_atom;
                                                                                                                                                                        E_trans_SxKA = E_trans_SxKA - (dE_atom * SxKA_path_l);
                                                                                                                                                                    }
                                                                                                                                                                    //**********************************************************************
                                                                                                                                                                    // Position of SxKA
                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                    obj_pos.next_pos(SxKA_x0, SxKA_y0, SxKA_z0, SxKA_path_l, SxKA_u, SxKA_v, SxKA_w, ref SxKA_x, ref SxKA_y, ref SxKA_z);

                                                                                                                                                                    if (((SxKA_x >= 0) && (SxKA_x <= V_a)) && ((SxKA_y >= 0) && (SxKA_y <= V_b)) && (((SxKA_z >= 0) && (SxKA_z <= V_c))))
                                                                                                                                                                    {
                                                                                                                                                                        obj_pos.lat_cord(SxKA_x, SxKA_y, SxKA_z, a, b, c, ref SxKA_ix, ref SxKA_iy, ref SxKA_iz);
                                                                                                                                                                        //sxpoint = sxpoint + 1;// number of SxKA histories inside the target
                                                                                                                                                                        sx_point = sx_point + 0.0000001;
                                                                                                                                                                        if (E_trans_SxKA >= th_E)
                                                                                                                                                                        {
                                                                                                                                                                            double SvKA_x0 = 0, SvKA_y0 = 0, SvKA_z0 = 0, E_trans_SvKA = 0;
                                                                                                                                                                            if (SxKA_path_l >= 0.75e-8)
                                                                                                                                                                            {
                                                                                                                                                                                SxKA = SxKA + 1;
                                                                                                                                                                                int_type = "Disp SxKA";

                                                                                                                                                                                if (int_type == "Disp SxKA")
                                                                                                                                                                                {
                                                                                                                                                                                    vac_hist = obj_pos.vac_his(PtKA_ix, PtKA_iy, PtKA_iz, a, b, c, pt_point, gen, atom_no, SxKA_x0, SxKA_y0, SxKA_z0, E_trans_SxKA, E_PKA, int_type);
                                                                                                                                                                                    vac_h.Merge(vac_hist);
                                                                                                                                                                                }

                                                                                                                                                                                PKA_hist = obj_pos.PKA_his(sx_point, E_PKA, E_trans_PtKA, PtKA_x, PtKA_y, PtKA_z, dE_atom, SxKA_path_l, E_trans_SxKA, SxKA_x0, SxKA_y0, SxKA_z0, Sxka_cross, int_type);
                                                                                                                                                                                PKA_h.Merge(PKA_hist);
                                                                                                                                                                                obj_pka.struc(SxKA_ix, SxKA_iy, SxKA_iz, SxKA_x0, SxKA_y0, SxKA_z0, SxKA_x, SxKA_y, SxKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                                                                close_atom = obj_pka.close(SxKA_ix, SxKA_iy, SxKA_iz, SxKA_x0, SxKA_y0, SxKA_z0, SxKA_x, SxKA_y, SxKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref SvKA_x0, ref SvKA_y0, ref SvKA_z0);
                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                // New directions of SxKA 
                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                obj_pos.dir_cos(ref Sxka_phi, ref Sxka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                E_trans_SvKA = obj_atom_cross.Cal_KE_SKA(E_trans_SxKA, atom_no, d, Atom_wt, Sxka_theta);//in MeV

                                                                                                                                                                                Rem_SxKA = E_trans_SxKA - E_trans_SvKA;
                                                                                                                                                                                double Svka_phi = 0;
                                                                                                                                                                                double Svka_theta = (3.14159 / 2) - Sxka_theta;
                                                                                                                                                                                double Svka_s_theta = Math.Sin(Sxka_theta);
                                                                                                                                                                                //E_trans_SvKA = E_trans_SvKA - th_E;
                                                                                                                                                                                if (E_trans_SvKA > th_E)
                                                                                                                                                                                {
                                                                                                                                                                                    double SvKA_u = 0, SvKA_v = 0, SvKA_w = 0, SvKA_path_l = 0, SvKA_ix = 0, SvKA_iy = 0, SvKA_iz = 0, Rem_SvKA = 0, sv_point = 0, Svka_cross = 0, SvKA_x = 0, SvKA_y = 0, SvKA_z = 0;
                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                    // Directions of SvKA
                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                    obj_pos.dir_cos(ref Svka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                    SvKA_u = cos_phi * Svka_s_theta;
                                                                                                                                                                                    SvKA_v = sin_phi * Svka_s_theta;
                                                                                                                                                                                    SvKA_w = Math.Sqrt(1 - Math.Pow(Svka_s_theta, 2));
                                                                                                                                                                                    gen = 6;
                                                                                                                                                                                    void_cord = new double[3];
                                                                                                                                                                                    void_cord[0] = SvKA_x0;
                                                                                                                                                                                    void_cord[1] = SvKA_y0;
                                                                                                                                                                                    void_cord[2] = SvKA_z0;
                                                                                                                                                                                    atom_list.Add(void_cord);
                                                                                                                                                                                    sv_point = sx_point;

                                                                                                                                                                                    while (E_trans_SvKA >= th_E)
                                                                                                                                                                                    {
                                                                                                                                                                                        obj_pos.p_l(E_trans_SvKA, atom_no, ref Svka_cross, ref SvKA_path_l);
                                                                                                                                                                                        dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_SvKA, atom_no, d, Atom_wt);
                                                                                                                                                                                        E_trans_SvKA = E_trans_SvKA - (dE_atom * SvKA_path_l);

                                                                                                                                                                                        if (E_trans_SvKA < (dE_atom * SvKA_path_l))
                                                                                                                                                                                        {
                                                                                                                                                                                            E_trans_SvKA = E_trans_SvKA + (dE_atom * SvKA_path_l);
                                                                                                                                                                                            SvKA_path_l = E_trans_SvKA / dE_atom;
                                                                                                                                                                                            E_trans_SvKA = E_trans_SvKA - (dE_atom * SvKA_path_l);
                                                                                                                                                                                        }
                                                                                                                                                                                        //**********************************************************************
                                                                                                                                                                                        // Position of SvKA
                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                        obj_pos.next_pos(SvKA_x0, SvKA_y0, SvKA_z0, SvKA_path_l, SvKA_u, SvKA_v, SvKA_w, ref SvKA_x, ref SvKA_y, ref SvKA_z);

                                                                                                                                                                                        if (((SvKA_x >= 0) && (SvKA_x <= V_a)) && ((SvKA_y >= 0) && (SvKA_y <= V_b)) && (((SvKA_z >= 0) && (SvKA_z <= V_c))))
                                                                                                                                                                                        {
                                                                                                                                                                                            obj_pos.lat_cord(SvKA_x, SvKA_y, SvKA_z, a, b, c, ref SvKA_ix, ref SvKA_iy, ref SvKA_iz);
                                                                                                                                                                                            //svpoint = svpoint + 1;// number of SxKA histories inside the target
                                                                                                                                                                                            sv_point = sv_point + 0.0000001;
                                                                                                                                                                                            if (E_trans_SvKA >= th_E)
                                                                                                                                                                                            {
                                                                                                                                                                                                double EtKA_x0 = 0, EtKA_y0 = 0, EtKA_z0 = 0, E_trans_EtKA = 0;
                                                                                                                                                                                                if (SvKA_path_l >= 0.75e-8)
                                                                                                                                                                                                {
                                                                                                                                                                                                    SvKA = SvKA + 1;
                                                                                                                                                                                                    int_type = "Disp SvKA";

                                                                                                                                                                                                    if (int_type == "Disp SvKA")
                                                                                                                                                                                                    {
                                                                                                                                                                                                        vac_hist = obj_pos.vac_his(SxKA_ix, SxKA_iy, SxKA_iz, a, b, c, sx_point, gen, atom_no, SvKA_x0, SvKA_y0, SvKA_z0, E_trans_SvKA, E_PKA, int_type);
                                                                                                                                                                                                        vac_h.Merge(vac_hist);
                                                                                                                                                                                                    }

                                                                                                                                                                                                    PKA_hist = obj_pos.PKA_his(sv_point, E_PKA, E_trans_SxKA, SxKA_x, SxKA_y, SxKA_z, dE_atom, SvKA_path_l, E_trans_SvKA, SvKA_x0, SvKA_y0, SvKA_z0, Svka_cross, int_type);
                                                                                                                                                                                                    PKA_h.Merge(PKA_hist);

                                                                                                                                                                                                    obj_pka.struc(SvKA_ix, SvKA_iy, SvKA_iz, SvKA_x0, SvKA_y0, SvKA_z0, SvKA_x, SvKA_y, SvKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                                                                                    close_atom = obj_pka.close(SvKA_ix, SvKA_iy, SvKA_iz, SvKA_x0, SvKA_y0, SvKA_z0, SvKA_x, SvKA_y, SvKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref EtKA_x0, ref EtKA_y0, ref EtKA_z0);
                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                    // New directions of SxKA 
                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                    obj_pos.dir_cos(ref Svka_phi, ref Svka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                    E_trans_EtKA = obj_atom_cross.Cal_KE_SKA(E_trans_SvKA, atom_no, d, Atom_wt, Svka_theta);//in MeV

                                                                                                                                                                                                    Rem_SvKA = E_trans_SvKA - E_trans_EtKA;
                                                                                                                                                                                                    double Etka_phi = 0;
                                                                                                                                                                                                    double Etka_theta = (3.14159 / 2) - Svka_theta;
                                                                                                                                                                                                    double Etka_s_theta = Math.Sin(Etka_theta);
                                                                                                                                                                                                    //E_trans_EtKA = E_trans_EtKA - th_E;
                                                                                                                                                                                                    if (E_trans_EtKA > th_E)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        double EtKA_u = 0, EtKA_v = 0, EtKA_w = 0, EtKA_path_l = 0, EtKA_ix = 0, EtKA_iy = 0, EtKA_iz = 0, Rem_EtKA = 0, et_point = 0, Etka_cross = 0, EtKA_x = 0, EtKA_y = 0, EtKA_z = 0;
                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                        // Directions of SvKA
                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                        obj_pos.dir_cos(ref Etka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                        EtKA_u = cos_phi * Etka_s_theta;
                                                                                                                                                                                                        EtKA_v = sin_phi * Etka_s_theta;
                                                                                                                                                                                                        EtKA_w = Math.Sqrt(1 - Math.Pow(Etka_s_theta, 2));
                                                                                                                                                                                                        gen = 8;
                                                                                                                                                                                                        void_cord = new double[3];
                                                                                                                                                                                                        void_cord[0] = EtKA_x0;
                                                                                                                                                                                                        void_cord[1] = EtKA_y0;
                                                                                                                                                                                                        void_cord[2] = EtKA_z0;
                                                                                                                                                                                                        atom_list.Add(void_cord);
                                                                                                                                                                                                        et_point = sv_point;

                                                                                                                                                                                                        while (E_trans_EtKA >= th_E)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            obj_pos.p_l(E_trans_EtKA, atom_no, ref Etka_cross, ref EtKA_path_l);
                                                                                                                                                                                                            dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_EtKA, atom_no, d, Atom_wt);
                                                                                                                                                                                                            E_trans_EtKA = E_trans_EtKA - (dE_atom * EtKA_path_l);
                                                                                                                                                                                                            if (E_trans_EtKA < (dE_atom * EtKA_path_l))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                E_trans_EtKA = E_trans_EtKA + (dE_atom * EtKA_path_l);
                                                                                                                                                                                                                EtKA_path_l = E_trans_EtKA / dE_atom;
                                                                                                                                                                                                                E_trans_EtKA = E_trans_EtKA - (dE_atom * EtKA_path_l);
                                                                                                                                                                                                            }
                                                                                                                                                                                                            //**********************************************************************
                                                                                                                                                                                                            // Position of EtKA
                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                            obj_pos.next_pos(EtKA_x0, EtKA_y0, EtKA_z0, EtKA_path_l, EtKA_u, EtKA_v, EtKA_w, ref EtKA_x, ref EtKA_y, ref EtKA_z);

                                                                                                                                                                                                            if (((EtKA_x >= 0) && (EtKA_x <= V_a)) && ((EtKA_y >= 0) && (EtKA_y <= V_b)) && (((EtKA_z >= 0) && (EtKA_z <= V_c))))
                                                                                                                                                                                                            {
                                                                                                                                                                                                                obj_pos.lat_cord(EtKA_x, EtKA_y, EtKA_z, a, b, c, ref EtKA_ix, ref EtKA_iy, ref EtKA_iz);
                                                                                                                                                                                                                //etpoint = etpoint + 1;// number of EtKA histories inside the target
                                                                                                                                                                                                                et_point = et_point + 0.000000001;
                                                                                                                                                                                                                if (E_trans_EtKA >= th_E)
                                                                                                                                                                                                                {//
                                                                                                                                                                                                                    double NiKA_x0 = 0, NiKA_y0 = 0, NiKA_z0 = 0, E_trans_NiKA = 0;
                                                                                                                                                                                                                    if (EtKA_path_l >= 0.75e-8)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        EtKA = EtKA + 1;
                                                                                                                                                                                                                        int_type = "Disp EtKA";
                                                                                                                                                                                                                        if (int_type == "Disp EtKA")
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            vac_hist = obj_pos.vac_his(SvKA_ix, SvKA_iy, SvKA_iz, a, b, c, sv_point, gen, atom_no, EtKA_x0, EtKA_y0, EtKA_z0, E_trans_EtKA, E_PKA, int_type);
                                                                                                                                                                                                                            vac_h.Merge(vac_hist);
                                                                                                                                                                                                                        }

                                                                                                                                                                                                                        PKA_hist = obj_pos.PKA_his(et_point, E_PKA, E_trans_SvKA, SvKA_x, SvKA_y, SvKA_z, dE_atom, EtKA_path_l, E_trans_EtKA, EtKA_x0, EtKA_y0, EtKA_z0, Etka_cross, int_type);
                                                                                                                                                                                                                        PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                        obj_pka.struc(EtKA_ix, EtKA_iy, EtKA_iz, EtKA_x0, EtKA_y0, EtKA_z0, EtKA_x, EtKA_y, EtKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                                                                                                        close_atom = obj_pka.close(EtKA_ix, EtKA_iy, EtKA_iz, EtKA_x0, EtKA_y0, EtKA_z0, EtKA_x, EtKA_y, EtKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref NiKA_x0, ref NiKA_y0, ref NiKA_z0);
                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                        // New directions of EtKA 
                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                        obj_pos.dir_cos(ref Etka_phi, ref Etka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                        E_trans_NiKA = obj_atom_cross.Cal_KE_SKA(E_trans_EtKA, atom_no, d, Atom_wt, Etka_theta);//in MeV

                                                                                                                                                                                                                        Rem_EtKA = E_trans_EtKA - E_trans_NiKA;
                                                                                                                                                                                                                        double Nika_phi = 0;
                                                                                                                                                                                                                        double Nika_theta = (3.14159 / 2) - Etka_theta;
                                                                                                                                                                                                                        double Nika_s_theta = Math.Sin(Nika_theta);
                                                                                                                                                                                                                        //E_trans_NiKA = E_trans_NiKA - th_E;
                                                                                                                                                                                                                        if (E_trans_NiKA >= th_E)
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            double NiKA_u = 0, NiKA_v = 0, NiKA_w = 0, NiKA_path_l = 0, NiKA_ix = 0, NiKA_iy = 0, NiKA_iz = 0, Rem_NiKA = 0, ni_point = 0, Nika_cross = 0, NiKA_x = 0, NiKA_y = 0, NiKA_z = 0;
                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                            // Directions of NiKA
                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                            obj_pos.dir_cos(ref Nika_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                            NiKA_u = cos_phi * Nika_s_theta;
                                                                                                                                                                                                                            NiKA_v = sin_phi * Nika_s_theta;
                                                                                                                                                                                                                            NiKA_w = Math.Sqrt(1 - Math.Pow(Nika_s_theta, 2));
                                                                                                                                                                                                                            gen = 9;
                                                                                                                                                                                                                            void_cord = new double[3];
                                                                                                                                                                                                                            void_cord[0] = NiKA_x0;
                                                                                                                                                                                                                            void_cord[1] = NiKA_y0;
                                                                                                                                                                                                                            void_cord[2] = NiKA_z0;
                                                                                                                                                                                                                            atom_list.Add(void_cord);
                                                                                                                                                                                                                            ni_point = et_point;

                                                                                                                                                                                                                            while (E_trans_NiKA >= th_E)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                obj_pos.p_l(E_trans_NiKA, atom_no, ref Nika_cross, ref NiKA_path_l);
                                                                                                                                                                                                                                dE_atom = objcharge.Cal_energy_loss_chargedparticle(E_trans_NiKA, atom_no, d, Atom_wt);
                                                                                                                                                                                                                                E_trans_NiKA = E_trans_NiKA - (dE_atom * NiKA_path_l);
                                                                                                                                                                                                                                if (E_trans_NiKA < (dE_atom * NiKA_path_l))
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    E_trans_NiKA = E_trans_NiKA + (dE_atom * NiKA_path_l);
                                                                                                                                                                                                                                    NiKA_path_l = E_trans_NiKA / dE_atom;
                                                                                                                                                                                                                                    E_trans_NiKA = E_trans_NiKA - (dE_atom * NiKA_path_l);
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                //**********************************************************************
                                                                                                                                                                                                                                // Position of EtKA
                                                                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                                                                obj_pos.next_pos(NiKA_x0, NiKA_y0, NiKA_z0, NiKA_path_l, NiKA_u, NiKA_v, NiKA_w, ref NiKA_x, ref NiKA_y, ref NiKA_z);

                                                                                                                                                                                                                                if (((NiKA_x >= 0) && (NiKA_x <= V_a)) && ((NiKA_y >= 0) && (NiKA_y <= V_b)) && (((NiKA_z >= 0) && (NiKA_z <= V_c))))
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    obj_pos.lat_cord(NiKA_x, NiKA_y, NiKA_z, a, b, c, ref NiKA_ix, ref NiKA_iy, ref NiKA_iz);
                                                                                                                                                                                                                                    //nipoint = nipoint + 1;// number of EtKA histories inside the target
                                                                                                                                                                                                                                    ni_point = ni_point + 0.0000000001;
                                                                                                                                                                                                                                    if (E_trans_NiKA >= th_E)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        double TnKA_x0 = 0, TnKA_y0 = 0, TnKA_z0 = 0, E_trans_TnKA = 0;
                                                                                                                                                                                                                                        if (NiKA_path_l >= 0.75e-8)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            NiKA = NiKA + 1;
                                                                                                                                                                                                                                            int_type = "Disp NiKA";
                                                                                                                                                                                                                                            if (int_type == "Disp NiKA")
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                vac_hist = obj_pos.vac_his(EtKA_ix, EtKA_iy, EtKA_iz, a, b, c, et_point, gen, atom_no, NiKA_x0, NiKA_y0, NiKA_z0, E_trans_NiKA, E_PKA, int_type);
                                                                                                                                                                                                                                                vac_h.Merge(vac_hist);
                                                                                                                                                                                                                                            }

                                                                                                                                                                                                                                            PKA_hist = obj_pos.PKA_his(ni_point, E_PKA, E_trans_EtKA, EtKA_x, EtKA_y, EtKA_z, dE_atom, NiKA_path_l, E_trans_NiKA, NiKA_x0, NiKA_y0, NiKA_z0, Nika_cross, int_type);
                                                                                                                                                                                                                                            PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                                            obj_pka.struc(NiKA_ix, NiKA_iy, NiKA_iz, NiKA_x0, NiKA_y0, NiKA_z0, NiKA_x, NiKA_y, NiKA_z, a, b, c, apoint, N0, bin, atom_no, N, l_struc, ref mindis, ref t_atom);
                                                                                                                                                                                                                                            close_atom = obj_pka.close(NiKA_ix, NiKA_iy, NiKA_iz, NiKA_x0, NiKA_y0, NiKA_z0, NiKA_x, NiKA_y, NiKA_z, a, b, c, apoint, N0, bin, atom_no, N, mindis, l_struc, ref TnKA_x0, ref TnKA_y0, ref TnKA_z0);
                                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                                            // New directions of NiKA 
                                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                                            obj_pos.dir_cos(ref Nika_phi, ref Nika_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                                            E_trans_TnKA = obj_atom_cross.Cal_KE_SKA(E_trans_NiKA, atom_no, d, Atom_wt, Nika_theta);//in MeV
                                                                                                                                                                                                                                            PKA_hist = obj_pos.PKA_his(a_point, E_PKA, E_trans_NiKA, NiKA_x, NiKA_y, NiKA_z, dE_atom, NiKA_path_l, E_trans_TnKA, TnKA_x0, TnKA_y0, TnKA_z0, Nika_cross, int_type);
                                                                                                                                                                                                                                            PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                                            Rem_NiKA = E_trans_NiKA - E_trans_TnKA;
                                                                                                                                                                                                                                            double Tnka_phi = 0;
                                                                                                                                                                                                                                            double Tnka_theta = (3.14159 / 2) - Nika_theta;
                                                                                                                                                                                                                                            double Tnka_s_theta = Math.Sin(Tnka_theta);
                                                                                                                                                                                                                                            //E_trans_TnKA = E_trans_TnKA - th_E;
                                                                                                                                                                                                                                            if (E_trans_TnKA >= th_E)
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                double TnKA_u = 0, TnKA_v = 0, TnKA_w = 0, TnKA_path_l = 0, TnKA_ix = 0, TnKA_iy = 0, TnKA_iz = 0, Rem_TnKA = 0, Tn_point = 0, Tnka_cross = 0, TnKA_x = 0, TnKA_y = 0, TnKA_z = 0;
                                                                                                                                                                                                                                                TnKA = TnKA + 1;
                                                                                                                                                                                                                                                //tn_point = ni_point;
                                                                                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                                                                                // Directions of NiKA
                                                                                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                                                                                obj_pos.dir_cos(ref Tnka_phi, ref dum_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                                                NiKA_u = cos_phi * Tnka_s_theta;
                                                                                                                                                                                                                                                NiKA_v = sin_phi * Tnka_s_theta;
                                                                                                                                                                                                                                                NiKA_w = Math.Sqrt(1 - Math.Pow(Tnka_s_theta, 2));
                                                                                                                                                                                                                                                void_cord = new double[3];
                                                                                                                                                                                                                                                void_cord[0] = TnKA_x0;
                                                                                                                                                                                                                                                void_cord[1] = TnKA_y0;
                                                                                                                                                                                                                                                void_cord[2] = TnKA_z0;
                                                                                                                                                                                                                                                atom_list.Add(void_cord);
                                                                                                                                                                                                                                                obj_pos.p_l(E_trans_TnKA, atom_no, ref Tnka_cross, ref TnKA_path_l);
                                                                                                                                                                                                                                                //tn_point = tn_point + 1;
                                                                                                                                                                                                                                                gen = 10;
                                                                                                                                                                                                                                                if (TnKA_path_l > 0.75e-8)
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    int_type = "Disp TnKA";
                                                                                                                                                                                                                                                    if (int_type == "Disp TnKA")
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        vac_hist = obj_pos.vac_his(NiKA_ix, NiKA_iy, NiKA_iz, a, b, c, ni_point, gen, atom_no, TnKA_x0, TnKA_y0, TnKA_z0, E_trans_TnKA, E_PKA, int_type);
                                                                                                                                                                                                                                                        vac_h.Merge(vac_hist);
                                                                                                                                                                                                                                                    }

                                                                                                                                                                                                                                                    PKA_hist = obj_pos.PKA_his(Tn_point, E_PKA, E_trans_NiKA, NiKA_x, NiKA_y, NiKA_z, dE_atom, TnKA_path_l, E_trans_TnKA, TnKA_x0, TnKA_y0, TnKA_z0, Tnka_cross, int_type);
                                                                                                                                                                                                                                                    PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    int_type = "Defect TnKA";
                                                                                                                                                                                                                                                    PKA_hist = obj_pos.PKA_his(Tn_point, E_PKA, E_trans_NiKA, NiKA_x, NiKA_y, NiKA_z, dE_atom, TnKA_path_l, E_trans_TnKA, TnKA_x0, TnKA_y0, TnKA_z0, Tnka_cross, int_type);
                                                                                                                                                                                                                                                    PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                                                    E_trans_TnKA = 0;
                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                //  int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                                                                                                                                //energy transferred to SKA will go into excitation
                                                                                                                                                                                                                                                PKA_Ed_hist = obj_pos.PKA_Ed_his(ni_point, E_PKA, E_trans_TnKA, TnKA_x0, TnKA_y0, TnKA_z0, dE_atom, NiKA_path_l, int_type);
                                                                                                                                                                                                                                                PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                            E_trans_NiKA = Rem_NiKA;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            NiKA_l = NiKA_l + 1;
                                                                                                                                                                                                                                            int_type = "Defect NiKA";
                                                                                                                                                                                                                                            PKA_hist = obj_pos.PKA_his(ni_point, E_PKA, E_trans_EtKA, EtKA_x, EtKA_y, EtKA_z, dE_atom, NiKA_path_l, E_trans_NiKA, NiKA_x0, NiKA_y0, NiKA_z0, Nika_cross, int_type);
                                                                                                                                                                                                                                            PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                                            E_trans_NiKA = 0;
                                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                                            // New directions of NiKA 
                                                                                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                                                                                            //obj_pos.dir_cos(ref Nika_phi, ref NiKA_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                                        // new coordinates of NiKA
                                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                                        double new_Nikau = 0, new_Nikav = 0, new_Nikaw = 0;
                                                                                                                                                                                                                                        obj_pos.new_dir(NiKA_x0, NiKA_y0, NiKA_z0, Nika_phi, Nika_theta, NiKA_u, NiKA_v, NiKA_w, V_a, V_b, V_c, ref new_Nikau, ref new_Nikav, ref new_Nikaw);
                                                                                                                                                                                                                                        NiKA_u = new_Nikau;
                                                                                                                                                                                                                                        NiKA_v = new_Nikav;
                                                                                                                                                                                                                                        NiKA_w = new_Nikaw;
                                                                                                                                                                                                                                        NiKA_x0 = NiKA_x;
                                                                                                                                                                                                                                        NiKA_y0 = NiKA_y;
                                                                                                                                                                                                                                        NiKA_z0 = NiKA_z;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    else // (E_trans_NiKA-dE)<=Ed
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        if (NiKA_path_l >= 0.75e-8)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            int_type = "Disp NiKA";
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            int_type = "Defect NiKA";
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        //E_trans_NiKA = 0;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                else // outside the given target volume
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    int_type = "outside";
                                                                                                                                                                                                                                    E_trans_NiKA = 0;
                                                                                                                                                                                                                                    N_out = ni_point;
                                                                                                                                                                                                                                    pka_out_hist = obj_pos.PKA_out_his(ni_point, E_PKA, int_type);
                                                                                                                                                                                                                                    pka_out_h.Merge(pka_out_hist);
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                            }//end of while loop on NiKA
                                                                                                                                                                                                                            if ((int_type == "Disp NiKA" || int_type == "Defect NiKA") && ni_point != N_out)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                int_hist = obj_pos.int_his(NiKA_ix, NiKA_iy, NiKA_iz, a, b, c, ni_point, gen, atom_no, NiKA_x, NiKA_y, NiKA_z, int_type, E_trans_NiKA, E_PKA);
                                                                                                                                                                                                                                int_h.Merge(int_hist);
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        else // E_trans_NiKA <=40eV, so no furthur displacement terminate history
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            // record it 
                                                                                                                                                                                                                            //no vacancy
                                                                                                                                                                                                                            //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                                                                                                            //energy transferred to SKA will go into excitation
                                                                                                                                                                                                                            PKA_Ed_hist = obj_pos.PKA_Ed_his(et_point, E_PKA, E_trans_NiKA, NiKA_x0, NiKA_y0, NiKA_z0, dE_atom, EtKA_path_l, int_type);
                                                                                                                                                                                                                            PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        E_trans_EtKA = Rem_EtKA;
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        EtKA_l = EtKA_l + 1;
                                                                                                                                                                                                                        int_type = "Defect EtKA";
                                                                                                                                                                                                                        PKA_hist = obj_pos.PKA_his(et_point, E_PKA, E_trans_SvKA, SvKA_x, SvKA_y, SvKA_z, dE_atom, EtKA_path_l, E_trans_EtKA, EtKA_x0, EtKA_y0, EtKA_z0, Etka_cross, int_type);
                                                                                                                                                                                                                        PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                                        E_trans_EtKA = 0;
                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                        // New directions of NiKA 
                                                                                                                                                                                                                        //***********************************************************************
                                                                                                                                                                                                                        //obj_pos.dir_cos(ref Etka_phi, ref EtKA_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                                    // new coordinates of EtKA
                                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                                    double new_Etkau = 0, new_Etkav = 0, new_Etkaw = 0;
                                                                                                                                                                                                                    obj_pos.new_dir(EtKA_x0, EtKA_y0, EtKA_z0, Etka_phi, Etka_theta, EtKA_u, EtKA_v, EtKA_w, V_a, V_b, V_c, ref new_Etkau, ref new_Etkav, ref new_Etkaw);
                                                                                                                                                                                                                    EtKA_u = new_Etkau;
                                                                                                                                                                                                                    EtKA_v = new_Etkav;
                                                                                                                                                                                                                    EtKA_w = new_Etkaw;
                                                                                                                                                                                                                    EtKA_x0 = EtKA_x;
                                                                                                                                                                                                                    EtKA_y0 = EtKA_y;
                                                                                                                                                                                                                    EtKA_z0 = EtKA_z;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else // (E_trans_EtKA-dE)<=40eV
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (EtKA_path_l >= 0.75e-8)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        int_type = "Disp EtKA";
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        int_type = "Defect EtKA";
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    // E_trans_EtKA = 0;
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                int_type = "outside";
                                                                                                                                                                                                                E_trans_EtKA = 0; // outside volume
                                                                                                                                                                                                                N_out = et_point;
                                                                                                                                                                                                                pka_out_hist = obj_pos.PKA_out_his(et_point, E_PKA, int_type);
                                                                                                                                                                                                                pka_out_h.Merge(pka_out_hist);
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }//end of while loop on EtKA
                                                                                                                                                                                                        if ((int_type == "Disp EtKA" || int_type == "Defect EtKA") && et_point != N_out)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            int_hist = obj_pos.int_his(EtKA_ix, EtKA_iy, EtKA_iz, a, b, c, et_point, gen, atom_no, EtKA_x, EtKA_y, EtKA_z, int_type, E_trans_EtKA, E_PKA);
                                                                                                                                                                                                            int_h.Merge(int_hist);
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else
                                                                                                                                                                                                    {
                                                                                                                                                                                                        //record excitation energy
                                                                                                                                                                                                        //no vacancy
                                                                                                                                                                                                        //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                                                                                        //energy transferred to SKA will go into excitation
                                                                                                                                                                                                        PKA_Ed_hist = obj_pos.PKA_Ed_his(sv_point, E_PKA, E_trans_EtKA, EtKA_x0, EtKA_y0, EtKA_z0, dE_atom, SvKA_path_l, int_type);
                                                                                                                                                                                                        PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                                                                                    }
                                                                                                                                                                                                    E_trans_SvKA = Rem_SvKA;
                                                                                                                                                                                                }//No 7 th genration energy is lost in excitation
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    SvKA_l = SvKA_l + 1;
                                                                                                                                                                                                    //record excitation energy
                                                                                                                                                                                                    int_type = "Defect SvKA";
                                                                                                                                                                                                    PKA_hist = obj_pos.PKA_his(sv_point, E_PKA, E_trans_SxKA, SxKA_x, SxKA_y, SxKA_z, dE_atom, SvKA_path_l, E_trans_SvKA, SvKA_x0, SvKA_y0, SvKA_z0, Svka_cross, int_type);
                                                                                                                                                                                                    PKA_h.Merge(PKA_hist);
                                                                                                                                                                                                    E_trans_SvKA = 0;
                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                    // New directions of SvKA 
                                                                                                                                                                                                    //***********************************************************************
                                                                                                                                                                                                    //obj_pos.dir_cos(ref Svka_phi, ref SvKA_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                                                }
                                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                                // new coordinates of SvKA
                                                                                                                                                                                                //***********************************************************************
                                                                                                                                                                                                double new_Svkau = 0, new_Svkav = 0, new_Svkaw = 0;
                                                                                                                                                                                                obj_pos.new_dir(SvKA_x0, SvKA_y0, SvKA_z0, Svka_phi, Svka_theta, SvKA_u, SvKA_v, SvKA_w, V_a, V_b, V_c, ref new_Svkau, ref new_Svkav, ref new_Svkaw);
                                                                                                                                                                                                SvKA_u = new_Svkau;
                                                                                                                                                                                                SvKA_v = new_Svkav;
                                                                                                                                                                                                SvKA_w = new_Svkaw;
                                                                                                                                                                                                SvKA_x0 = SvKA_x;
                                                                                                                                                                                                SvKA_y0 = SvKA_y;
                                                                                                                                                                                                SvKA_z0 = SvKA_z;
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (SvKA_path_l >= 0.75e-8)
                                                                                                                                                                                                {
                                                                                                                                                                                                    int_type = "Disp SvKA";
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    int_type = "Defect SvKA";
                                                                                                                                                                                                }
                                                                                                                                                                                                //E_trans_SvKA = 0;
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                        else
                                                                                                                                                                                        {
                                                                                                                                                                                            // no disp atom outside the boundary
                                                                                                                                                                                            int_type = "outside";
                                                                                                                                                                                            E_trans_SvKA = 0;
                                                                                                                                                                                            N_out = sv_point;
                                                                                                                                                                                            pka_out_hist = obj_pos.PKA_out_his(sv_point, E_PKA, int_type);
                                                                                                                                                                                            pka_out_h.Merge(pka_out_hist);
                                                                                                                                                                                        }
                                                                                                                                                                                    }//end of while loop on 7th generation history
                                                                                                                                                                                    if ((int_type == "Disp SvKA" || int_type == "Defect SvKA") && sv_point != N_out)
                                                                                                                                                                                    {
                                                                                                                                                                                        int_hist = obj_pos.int_his(SvKA_ix, SvKA_iy, SvKA_iz, a, b, c, sv_point, gen, atom_no, SvKA_x, SvKA_y, SvKA_z, int_type, E_trans_SvKA, E_PKA);
                                                                                                                                                                                        int_h.Merge(int_hist);
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    //no vacancy
                                                                                                                                                                                    //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                                                                    //energy transferred to SKA will go into excitation
                                                                                                                                                                                    PKA_Ed_hist = obj_pos.PKA_Ed_his(sx_point, E_PKA, E_trans_SvKA, SvKA_x0, SvKA_y0, SvKA_z0, dE_atom, SxKA_path_l, int_type);
                                                                                                                                                                                    PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                                                                }
                                                                                                                                                                                E_trans_SxKA = Rem_SxKA;
                                                                                                                                                                            }//No 6 th genration energy is lost in excitation
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                SxKA_l = SxKA_l + 1;
                                                                                                                                                                                //record excitation energy
                                                                                                                                                                                int_type = "Defect SxKA";
                                                                                                                                                                                PKA_hist = obj_pos.PKA_his(sx_point, E_PKA, E_trans_PtKA, PtKA_x, PtKA_y, PtKA_z, dE_atom, SxKA_path_l, E_trans_SxKA, SxKA_x0, SxKA_y0, SxKA_z0, Sxka_cross, int_type);
                                                                                                                                                                                PKA_h.Merge(PKA_hist);
                                                                                                                                                                                E_trans_SxKA = 0;
                                                                                                                                                                                //obj_pos.dir_cos(ref Sxka_phi, ref Sxka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                                            }
                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                            // new coordinates of SxKA
                                                                                                                                                                            //***********************************************************************
                                                                                                                                                                            double new_Sxkau = 0, new_Sxkav = 0, new_Sxkaw = 0;
                                                                                                                                                                            obj_pos.new_dir(SxKA_x0, SxKA_y0, SxKA_z0, Sxka_phi, Sxka_theta, SxKA_u, SxKA_v, SxKA_w, V_a, V_b, V_c, ref new_Sxkau, ref new_Sxkav, ref new_Sxkaw);
                                                                                                                                                                            SxKA_u = new_Sxkau;
                                                                                                                                                                            SxKA_v = new_Sxkav;
                                                                                                                                                                            SxKA_w = new_Sxkaw;
                                                                                                                                                                            SxKA_x0 = SxKA_x;
                                                                                                                                                                            SxKA_y0 = SxKA_y;
                                                                                                                                                                            SxKA_z0 = SxKA_z;
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (SxKA_path_l >= 0.75e-8)
                                                                                                                                                                            {
                                                                                                                                                                                int_type = "Disp SxKA";
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                int_type = "Defect SxKA";
                                                                                                                                                                            }
                                                                                                                                                                            //E_trans_SxKA = 0;
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        // no disp atom outside the boundary
                                                                                                                                                                        int_type = "outside";
                                                                                                                                                                        E_trans_SxKA = 0;
                                                                                                                                                                        N_out = sx_point;
                                                                                                                                                                        pka_out_hist = obj_pos.PKA_out_his(sx_point, E_PKA, int_type);
                                                                                                                                                                        pka_out_h.Merge(pka_out_hist);
                                                                                                                                                                    }
                                                                                                                                                                }//end of while loop on 5th generation history
                                                                                                                                                                if ((int_type == "Disp SxKA" || int_type == "Defect SxKA") && sx_point != N_out)
                                                                                                                                                                {
                                                                                                                                                                    int_hist = obj_pos.int_his(SxKA_ix, SxKA_iy, SxKA_iz, a, b, c, sx_point, gen, atom_no, SxKA_x, SxKA_y, SxKA_z, int_type, E_trans_SxKA, E_PKA);
                                                                                                                                                                    int_h.Merge(int_hist);
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                //E transferred to 6th gen will go in excitation only
                                                                                                                                                                // no vacancy
                                                                                                                                                                //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                                                //energy transferred to SKA will go into excitation
                                                                                                                                                                PKA_Ed_hist = obj_pos.PKA_Ed_his(pt_point, E_PKA, E_trans_SxKA, SxKA_x0, SxKA_y0, SxKA_z0, dE_atom, PtKA_path_l, int_type);
                                                                                                                                                                PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                                            }
                                                                                                                                                            E_trans_PtKA = Rem_PtKA;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            //record excitation energy
                                                                                                                                                            PtKA_l = PtKA_l + 1;
                                                                                                                                                            int_type = "Defect PtKA";
                                                                                                                                                            PKA_hist = obj_pos.PKA_his(pt_point, E_PKA, E_trans_FKA, FKA_x, FKA_y, FKA_z, dE_atom, PtKA_path_l, E_trans_PtKA, PtKA_x0, PtKA_y0, PtKA_z0, Ptka_cross, int_type);
                                                                                                                                                            PKA_h.Merge(PKA_hist);
                                                                                                                                                            E_trans_PtKA = 0;
                                                                                                                                                            //obj_pos.dir_cos(ref Ptka_phi, ref Ptka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                                        }
                                                                                                                                                        //***********************************************************************
                                                                                                                                                        // new coordinates of PtKA
                                                                                                                                                        //***********************************************************************
                                                                                                                                                        double new_Ptkau = 0, new_Ptkav = 0, new_Ptkaw = 0;
                                                                                                                                                        obj_pos.new_dir(PtKA_x0, PtKA_y0, PtKA_z0, Ptka_phi, Ptka_theta, PtKA_u, PtKA_v, PtKA_w, V_a, V_b, V_c, ref new_Ptkau, ref new_Ptkav, ref new_Ptkaw);
                                                                                                                                                        PtKA_u = new_Ptkau;
                                                                                                                                                        PtKA_v = new_Ptkav;
                                                                                                                                                        PtKA_w = new_Ptkaw;
                                                                                                                                                        PtKA_x0 = PtKA_x;
                                                                                                                                                        PtKA_y0 = PtKA_y;
                                                                                                                                                        PtKA_z0 = PtKA_z;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (PtKA_path_l >= 0.75e-8)
                                                                                                                                                        {
                                                                                                                                                            int_type = "Disp PtKA";
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            int_type = "Defect PtKA";
                                                                                                                                                        }
                                                                                                                                                        //E_trans_PtKA = 0;
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    // no disp atom outside the boundary
                                                                                                                                                    int_type = "outside";
                                                                                                                                                    E_trans_PtKA = 0;
                                                                                                                                                    N_out = pt_point;
                                                                                                                                                    pka_out_hist = obj_pos.PKA_out_his(pt_point, E_PKA, int_type);
                                                                                                                                                    pka_out_h.Merge(pka_out_hist);
                                                                                                                                                }
                                                                                                                                            }//end of while loop on 5th generation history
                                                                                                                                            if ((int_type == "Disp PtKA" || int_type == "Defect PtKA") && pt_point != N_out)
                                                                                                                                            {
                                                                                                                                                int_hist = obj_pos.int_his(PtKA_ix, PtKA_iy, PtKA_iz, a, b, c, pt_point, gen, atom_no, PtKA_x, PtKA_y, PtKA_z, int_type, E_trans_PtKA, E_PKA);
                                                                                                                                                int_h.Merge(int_hist);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            //E transferred to 5th gen will go in excitation only
                                                                                                                                            //no vacancy
                                                                                                                                            // int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                                            //energy transferred to SKA will go into excitation
                                                                                                                                            PKA_Ed_hist = obj_pos.PKA_Ed_his(f_point, E_PKA, E_trans_PtKA, PtKA_x0, PtKA_y0, PtKA_z0, dE_atom, FKA_path_l, int_type);
                                                                                                                                            PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                                        }
                                                                                                                                        E_trans_FKA = Rem_FKA;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        // energy of 4rth gen will go in excitation (E-dE<Eth)
                                                                                                                                        FKA_l = FKA_l + 1;
                                                                                                                                        int_type = "Defect FKA";
                                                                                                                                        PKA_hist = obj_pos.PKA_his(f_point, E_PKA, E_trans_TKA, TKA_x, TKA_y, TKA_z, dE_atom, FKA_path_l, E_trans_FKA, FKA_x0, FKA_y0, FKA_z0, fka_cross, int_type);
                                                                                                                                        PKA_h.Merge(PKA_hist);
                                                                                                                                        E_trans_FKA = 0;
                                                                                                                                        //obj_pos.dir_cos(ref fka_phi, ref fka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                                    }
                                                                                                                                    //***********************************************************************
                                                                                                                                    // new coordinates of FKA
                                                                                                                                    //***********************************************************************
                                                                                                                                    double new_fkau = 0, new_fkav = 0, new_fkaw = 0;
                                                                                                                                    obj_pos.new_dir(FKA_x0, FKA_y0, FKA_z0, fka_phi, fka_theta, FKA_u, FKA_v, FKA_w, V_a, V_b, V_c, ref new_fkau, ref new_fkav, ref new_fkaw);
                                                                                                                                    FKA_u = new_fkau;
                                                                                                                                    FKA_v = new_fkav;
                                                                                                                                    FKA_w = new_fkaw;
                                                                                                                                    FKA_x0 = FKA_x;
                                                                                                                                    FKA_y0 = FKA_y;
                                                                                                                                    FKA_z0 = FKA_z;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (FKA_path_l >= 0.75e-8)
                                                                                                                                    {
                                                                                                                                        int_type = "Disp FKA";
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        int_type = "Defect FKA";
                                                                                                                                    }
                                                                                                                                    // E_trans_FKA = 0;
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {// outside the given volume
                                                                                                                                int_type = "outside";
                                                                                                                                E_trans_FKA = 0;
                                                                                                                                N_out = f_point;
                                                                                                                                pka_out_hist = obj_pos.PKA_out_his(f_point, E_PKA, int_type);
                                                                                                                                pka_out_h.Merge(pka_out_hist);
                                                                                                                            }
                                                                                                                        } // end of while loop E transfered to FKA
                                                                                                                        if ((int_type == "Disp FKA" || int_type == "Defect FKA") && f_point != N_out)
                                                                                                                        {
                                                                                                                            intes = intes + 1;
                                                                                                                            int_hist = obj_pos.int_his(FKA_ix, FKA_iy, FKA_iz, a, b, c, f_point, gen, atom_no, FKA_x, FKA_y, FKA_z, int_type, E_trans_FKA, E_PKA);
                                                                                                                            int_h.Merge(int_hist);
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        // E transferred to FKA will go in excitation.
                                                                                                                        //no vacancy
                                                                                                                        //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                                        //energy transferred to SKA will go into excitation
                                                                                                                        PKA_Ed_hist = obj_pos.PKA_Ed_his(t_point, E_PKA, E_trans_FKA, FKA_x0, FKA_y0, FKA_z0, dE_atom, TKA_path_l, int_type);
                                                                                                                        PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                                    }
                                                                                                                    E_trans_TKA = Rem_TKA;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    TKA_l = TKA_l + 1;
                                                                                                                    int_type = "Defect TKA";
                                                                                                                    PKA_hist = obj_pos.PKA_his(t_point, E_PKA, E_trans_SKA, SKA_x, SKA_y, SKA_z, dE_atom, TKA_path_l, E_trans_TKA, TKA_x0, TKA_y0, TKA_z0, tka_cross, int_type);
                                                                                                                    PKA_h.Merge(PKA_hist);
                                                                                                                    E_trans_TKA = 0;
                                                                                                                    //obj_pos.dir_cos(ref tka_phi, ref tka_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                                                }
                                                                                                                //***********************************************************************
                                                                                                                // new coordinates of TKA
                                                                                                                //***********************************************************************
                                                                                                                double new_tkau = 0, new_tkav = 0, new_tkaw = 0;
                                                                                                                obj_pos.new_dir(TKA_x0, TKA_y0, TKA_z0, tka_phi, tka_theta, TKA_u, TKA_v, TKA_w, V_a, V_b, V_c, ref new_tkau, ref new_tkav, ref new_tkaw);
                                                                                                                TKA_u = new_tkau;
                                                                                                                TKA_v = new_tkav;
                                                                                                                TKA_w = new_tkaw;
                                                                                                                TKA_x0 = TKA_x;
                                                                                                                TKA_y0 = TKA_y;
                                                                                                                TKA_z0 = TKA_z;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (TKA_path_l >= 0.75e-8)
                                                                                                                {
                                                                                                                    int_type = "Disp TKA";
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    int_type = "Defect TKA";
                                                                                                                }
                                                                                                                //E_trans_TKA = 0;
                                                                                                            }
                                                                                                        }
                                                                                                        else// outside the given volume
                                                                                                        {
                                                                                                            int_type = "outside";
                                                                                                            E_trans_TKA = 0;
                                                                                                            N_out = t_point;
                                                                                                            pka_out_hist = obj_pos.PKA_out_his(a_point, E_PKA, int_type);
                                                                                                            pka_out_h.Merge(pka_out_hist);
                                                                                                        }
                                                                                                    }//end of while loop E transferred to TKA
                                                                                                    if ((int_type == "Disp TKA" || int_type == "Defect TKA") && t_point != N_out)
                                                                                                    {
                                                                                                        intes = intes + 1;
                                                                                                        int_hist = obj_pos.int_his(TKA_ix, TKA_iy, TKA_iz, a, b, c, t_point, gen, atom_no, TKA_x, TKA_y, TKA_z, int_type, E_trans_TKA, E_PKA);
                                                                                                        int_h.Merge(int_hist);
                                                                                                    }
                                                                                                }
                                                                                                else // E transferred to TKA < Ed
                                                                                                {
                                                                                                    // no vacancy
                                                                                                    //E transferred to TKA will go in excitation
                                                                                                    //int_type = ""; // If E_trans < Ed atom will vibrate around it mean position and energy is appear as heat
                                                                                                    //energy transferred to TKA will go into excitation
                                                                                                    PKA_Ed_hist = obj_pos.PKA_Ed_his(s_point, E_PKA, E_trans_TKA, TKA_x0, TKA_y0, TKA_z0, dE_atom, SKA_path_l, int_type);
                                                                                                    PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                                }
                                                                                                E_trans_SKA = Rem_SKA;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                //defect atom
                                                                                                int_type = "Defect SKA";
                                                                                                PKA_hist = obj_pos.PKA_his(s_point, E_PKA, E_trans_PKA, atom_x, atom_y, atom_z, dE_atom, SKA_path_l, E_trans_SKA, SKA_x0, SKA_y0, SKA_z0, ska_cross, int_type);
                                                                                                PKA_h.Merge(PKA_hist);
                                                                                                SKA_l = SKA_l + 1;
                                                                                                E_trans_SKA = 0;
                                                                                                //obj_pos.dir_cos(ref ska_phi, ref ska_theta, ref cos_phi, ref sin_phi, ref cos_theta, ref sin_theta);
                                                                                            }
                                                                                            //***********************************************************************
                                                                                            // new coordinates of SKA
                                                                                            //***********************************************************************
                                                                                            double new_skaw = 0, new_skav = 0, new_skau = 0;
                                                                                            obj_pos.new_dir(SKA_x0, SKA_y0, SKA_z0, ska_phi, ska_theta, SKA_u, SKA_v, SKA_w, V_a, V_b, V_c, ref new_skau, ref new_skav, ref new_skaw);
                                                                                            SKA_u = new_skau;
                                                                                            SKA_v = new_skav;
                                                                                            SKA_w = new_skaw;
                                                                                            SKA_x0 = SKA_x;
                                                                                            SKA_y0 = SKA_y;
                                                                                            SKA_z0 = SKA_z;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (SKA_path_l >= 0.75e-8)
                                                                                            {
                                                                                                int_type = "Disp SKA";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                int_type = "Defect SKA";
                                                                                            }
                                                                                            //E_trans_SKA = 0;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        int_type = "outside";
                                                                                        E_trans_SKA = 0;
                                                                                        N_out = s_point;
                                                                                        pka_out_hist = obj_pos.PKA_out_his(s_point, E_PKA, int_type);
                                                                                        pka_out_h.Merge(pka_out_hist);
                                                                                    }
                                                                                } //end of while loop (E_trans>=th_E)
                                                                                if ((int_type == "Disp SKA" || int_type == "Defect SKA") && s_point != N_out)
                                                                                {
                                                                                    intes = intes + 1;
                                                                                    int_hist = obj_pos.int_his(SKA_ix, SKA_iy, SKA_iz, a, b, c, s_point, gen, atom_no, SKA_x, SKA_y, SKA_z, int_type, E_trans_SKA, E_PKA);
                                                                                    int_h.Merge(int_hist);
                                                                                }
                                                                            }
                                                                            else
                                                                            {// E_trans_PKA<Ed
                                                                                PKA_Ed_hist = obj_pos.PKA_Ed_his(a_point, E_PKA, E_trans_SKA, SKA_x0, SKA_y0, SKA_z0, dE_atom, PKA_path_l, int_type);
                                                                                PKA_Ed_h.Merge(PKA_Ed_hist);
                                                                                //pka_less = pka_less + 1;
                                                                                // PKA/ion/chraged particle loses its energy in the form of dE/dx
                                                                            }
                                                                            E_trans_PKA = Rem_PKA;
                                                                        }
                                                                        else
                                                                        {
                                                                            //defect atom
                                                                            int_type = "Defect PKA";
                                                                            PKA_hist = obj_pos.PKA_his(a_point, E_PKA, KE, elec_x, elec_y, elec_z, dE, PKA_path_l, E_trans_PKA, atom_x0, atom_y0, atom_z0, pka_cross, int_type);
                                                                            PKA_h.Merge(PKA_hist);
                                                                            PKA_l = PKA_l + 1;
                                                                            E_trans_PKA = 0;
                                                                        }
                                                                        //***********************************************************************
                                                                        // new Azimuthal angle of atom
                                                                        //***********************************************************************
                                                                        double new_au = 0, new_av = 0, new_aw = 0;
                                                                        obj_pos.new_dir(atom_x0, atom_y0, atom_z0, atom_phi, atom_theta, atom_u, atom_v, atom_w, V_a, V_b, V_c, ref new_au, ref new_av, ref new_aw);
                                                                        atom_u = new_au;
                                                                        atom_v = new_av;
                                                                        atom_w = new_aw;
                                                                        atom_x0 = atom_x;
                                                                        atom_y0 = atom_y;
                                                                        atom_z0 = atom_z;
                                                                    }
                                                                    else
                                                                    {//E_PKA-dE<th_E no furthur displacement will produced but PKA will be displaced from its position 
                                                                        if (PKA_path_l >= 0.75e-8)
                                                                        {
                                                                            int_type = "Disp PKA";
                                                                        }
                                                                        else
                                                                        {
                                                                            int_type = "Defect PKA";
                                                                        }
                                                                    }
                                                                }
                                                                else
                                                                {// PKA outside the target
                                                                    int_type = "outside"; //outside the given volume
                                                                    N_out = a_point;
                                                                    pka_out_hist = obj_pos.PKA_out_his(a_point, E_PKA, int_type);
                                                                    pka_out_h.Merge(pka_out_hist);
                                                                    E_trans_PKA = 0;
                                                                }
                                                            }
                                                            if ((int_type == "Disp PKA" || int_type == "Defect PKA") && a_point != N_out)
                                                            {
                                                                intes = intes + 1;
                                                                int_hist = obj_pos.int_his(atom_ix, atom_iy, atom_iz, a, b, c, a_point, gen, atom_no, atom_x, atom_y, atom_z, int_type, E_trans_PKA, E_PKA);
                                                                int_h.Merge(int_hist);
                                                            }
                                                        }
                                                        else
                                                        {//energy transferred to PKA is less than threshold energy
                                                            // E_trans_PKA<Ed
                                                            int_type = "";
                                                            PKA_Ed_hist = obj_pos.PKA_Ed_his(a_point, E_PKA, E_trans_PKA, atom_x0, atom_y0, atom_z0, dE, elec_path_l, int_type);
                                                            PKA_Ed_h.Merge(PKA_Ed_hist);
                                                        }
                                                        disp_atom =(PKA + SKA + TKA + FKA + PtKA + SxKA + SvKA + EtKA + NiKA + TnKA);
                                                        def_atom = (PKA_l + SKA_l + TKA_l + FKA_l + PtKA_l + SxKA_l + SvKA_l + EtKA_l + NiKA_l);
                                                        //disp_cross = disp_atom * cross;
                                                        //def_cross = def_atom * cross;
                                                        if (interaction == "PE")
                                                        {
                                                            PE_dis_atom = PE_dis_atom + disp_atom;
                                                            PE_def_atom = PE_def_atom + def_atom;
                                                            PE_dis_cross = PE_dis_cross + (disp_atom * cross);
                                                        }
                                                        else if (interaction == "Comp")
                                                        {
                                                            Comp_dis_atom = Comp_dis_atom + disp_atom;
                                                            Comp_def_atom = Comp_def_atom + def_atom;
                                                            Comp_dis_cross = Comp_dis_cross + (disp_atom * cross);
                                                        }
                                                        else if (interaction == "PP")
                                                        {
                                                            PP_dis_atom = PP_dis_atom + disp_atom;
                                                            PP_def_atom = PP_def_atom + def_atom;
                                                            PP_dis_cross = PP_dis_cross + (PP_dis_atom * cross);
                                                        }

                                                        elec_hist = obj_file.elec_his(e_point, Fix_KE, KE, dE, elec_path_l, e_cross, elec_x0, elec_y0, elec_z0, E_PKA, atom_x0, atom_y0, atom_z0, disp_atom, def_atom, rem_KE);
                                                        elec_h.Merge(elec_hist);
                                                        if (Ph_box == "Inside" && Fix_KE >= e_th_E)
                                                        {
                                                            photon_int = obj_file.Photon_his(int_point, Ini_E, E, ix, iy, iz, interaction, shell, E_elec, ix0, iy0, iz0, Fix_KE, disp_atom, def_atom, cross, cross);
                                                            photon_h.Merge(photon_int);
                                                        }
                                                        KE = rem_KE;
                                                        disp_atom = def_atom = disp_cross = def_cross = 0;
                                                        PKA = SKA = TKA = FKA = PtKA = SxKA = SvKA = EtKA = NiKA = TnKA = 0;
                                                        PKA_l = SKA_l = TKA_l = FKA_l = PtKA_l = SxKA_l = SvKA_l = EtKA_l = NiKA_l = 0;
                                                        
                                                    }
                                                    else
                                                    {
                                                        //mindistance is less than radius of K-shell
                                                        int_type = "";
                                                        elec_Ed_hist = obj_file.elec_Ed_his(e_point, Fix_KE, KE, dE, elec_path_l, elec_x, elec_y, elec_z);
                                                        elec_Ed_h.Merge(elec_Ed_hist);
                                                        KE = 0;
                                                    }
                                                }
                                                else
                                                {
                                                    //(KE-dE)is less than the energy required to produce damage
                                                    //energy is deposited in the target to produce heat
                                                    int_type = "";
                                                    elec_Ed_hist = obj_file.elec_Ed_his(e_point, Fix_KE, KE, dE, elec_path_l, elec_x, elec_y, elec_z);
                                                    elec_Ed_h.Merge(elec_Ed_hist);
                                                    e_l = e_l + 1;
                                                    KE = 0;
                                                }
                                                //***********************************************************************
                                                // new parameters of elec
                                                //***********************************************************************
                                                double new_eu = 0, new_ev = 0, new_ew = 0;
                                                obj_pos.new_dir(elec_x0, elec_y0, elec_z0, e_phi, e_theta, e_u, e_v, e_w, V_a, V_b, V_c, ref new_eu, ref new_ev, ref new_ew);
                                                e_u = new_eu;
                                                e_v = new_ev;
                                                e_w = new_ew;
                                                elec_x0 = elec_x;
                                                elec_y0 = elec_y;
                                                elec_z0 = elec_z;
                                            }
                                            else
                                            {// electron outside the boundary
                                                KE = 0;
                                            }
                                        }// end of While loop on electron KE
                                       // if (Ph_box == "Inside" && Fix_KE >= e_th_E)
                                        //{
                                          //  photon_int = obj_file.Photon_his(int_point, Ini_E, E, ix, iy, iz, interaction, shell, E_elec, ix0, iy0, iz0, Fix_KE, disp_atom, def_atom, cross, cross);
                                           // photon_h.Merge(photon_int);
                                        //}
                                    }
                                    else
                                    {
                                        e_E_ext = e_E_ext + KE;
                                        KE = 0;
                                    }
                                    } // condition for mindistance of photon interaction <= radius of atom
                                else
                                {
                                    ph_E_ext = ph_E_ext + E;
                                    E = 0;
                                }
                                
                            }// Condition for photon inside the volume 
                            else
                            {
                                E_out = E_out + E;
                                Ph_box = "Outside";
                                E = 0;
                            }
                        }//end of while loop on photon energy
                        //if (Ph_box=="Inside" && Fix_KE>=e_th_E)
                        //{
                          //  photon_int = obj_file.Photon_his(int_point, Ini_E, E, ix, iy, iz, interaction, shell, E_elec, ix0, iy0, iz0, Fix_KE, disp_atom, def_atom, disp_cross, def_cross);
                           // photon_h.Merge(photon_int);
                       // }
                        int_point = Math.Round(int_point);
                        Photon_N = Photon_N + 1;
                    }
                    bin = bin + 1;
                    t_ipoint = t_ipoint + ipoint;
                    t_epoint = t_epoint + epoint;
                    t_apoint = t_apoint + apoint;
                    ipoint = epoint = apoint = Photon_N = 0;
                }

                for (int j = 1; j <= no_class; j++)
                {
                    x_val.Add(j * cls_w);
                    y_val.Add(comp_cross_sect*n_moment[j]);
                    y1_val.Add(pz[j]);
                    // sw.WriteLine(j.ToString() + "\t\t" + (j*cls_w).ToString() + "\t\t" + pz[j].ToString());
                }
                //sw.Flush();

                //sw.Close();

                //fs.Close();
                Txt_lattice.Text = Convert.ToString(N_lattice);
                Txt_atom.Text = Convert.ToString(atom);
                Txt_sphoton.Text = Convert.ToString(spoint);
                Txt_tphoton.Text = Convert.ToString(t_ipoint);
                Txt_photon_I.Text = Convert.ToString(PE + Comp + PP);
                Txt_electron.Text = Convert.ToString(e_his);
                Txt_dis_atom.Text = Convert.ToString(PE_dis_atom+Comp_dis_atom+PP_dis_atom);
                Txt_dis_SKA.Text = Convert.ToString(PE_def_atom+Comp_def_atom+PP_def_atom);
                Txt_dis_atom0.Text = Convert.ToString(N_NRT);
                Txt_dis_SKA0.Text = Convert.ToString((PE_dis_atom+Comp_dis_atom+PP_dis_atom)/N_NRT);
                Txt_photoelectric.Text = Convert.ToString(PE);
                Txt_comp.Text = Convert.ToString(Comp);
                Txt_PP.Text = Convert.ToString(PP);

                Txt_K.Text = Convert.ToString(K_contri);
                Txt_L.Text = Convert.ToString(L_contri);
                Txt_M.Text = Convert.ToString(M_contri);
                Txt_Nshell.Text = Convert.ToString(N_contri);
                Txt_O.Text = Convert.ToString(O_contri);
                Txt_P.Text = Convert.ToString(P_contri);

                Txt_photo_disp.Text = Convert.ToString(PE_dis_atom);
                Txt_comp_disp.Text = Convert.ToString(Comp_dis_atom);
                Txt_PP_disp.Text = Convert.ToString(PP_dis_atom);

                Txt_photo_cross.Text = Convert.ToString(PE_dis_cross);
                Txt_comp_cross.Text = Convert.ToString(Comp_dis_cross);
                Txt_PP_cross.Text = Convert.ToString(PP_dis_cross);

                Txt_Eph_in.Text = Convert.ToString(E_in);
                Txt_Eph_out.Text = Convert.ToString(E_out);
                Txt_Eph_ext.Text = Convert.ToString(ph_E_ext);
                Txt_Elec_out.Text = Convert.ToString(e_E_out);
                Txt_Elec_ext.Text = Convert.ToString(e_E_ext);

                Session["Compton"] = Comp_int;
                Session["Damaged_Atom"] = Ele_int;
                Session["Int_x"] = x_val;
                Session["Int_y1"] = y_val;
                Session["Int_y"] = y1_val;
                Session["Path_x"] = Path_x;
                Session["Path_y"] = Path_y;
                Session["x_int"] = x_int;
                Session["y_int"] = y_int;
                
                Session["photon_History"] = photon_h;
                Session["Compton_Profile"] = Comp_pro;
                Session["Electron_History"] = elec_h;
                Session["PKA_History"] = PKA_h;
               // Session["SKA_History"] = SKA_h;
                // Session["PKA_l_History"] = PKA_l_h;
                //Session["SKA_l_History"] = SKA_l_history;
                //Session["PKA_Ed_History"] = PKA_Ed_history;
                //Session["SKA_Ed_History"] = SKA_Ed_history;
                Session["Elec_Ed_History"] = elec_Ed_h;
                //Session["Vac_History"] = vac_history;
                //Session["Int_History"] = Int_history;
                //end_time = DateTime.Now.Ticks;
                //diff_time = end_time - st_time;
                st_time.Stop();
                Txt_time.Text = Convert.ToString(st_time.ElapsedMilliseconds);
            }
                          
             
        
        protected void Btn_rand_Click(object sender, EventArgs e)
        {
            Response.Redirect("Random_no.aspx");
        }

        protected void Btn_pos_Click(object sender, EventArgs e)
        {
            Response.Redirect("pos_cor.aspx");
        }

        protected void Btn_dir_Click(object sender, EventArgs e)
        {
            Response.Redirect("direct_cosine.aspx");
        }

        protected void Btn_int_Click(object sender, EventArgs e)
        {
            Response.Redirect("int_point.aspx");
        }

        protected void Btn_cross_Click(object sender, EventArgs e)
        {
            Response.Redirect("cross_sect.aspx");
        }

        protected void Btn_attenuation_Click(object sender, EventArgs e)
        {
            Response.Redirect("Attenuation.aspx");

        }
        protected void Btn_atom_coll_Click(object sender, EventArgs e)
        {
            Response.Redirect("Atom_col.aspx");
        }

        protected void Txt_2a_TextChanged(object sender, EventArgs e)
        {
           
        }

        protected void Btn_table_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable p = new DataTable();
            p = (DataTable)Session["photon_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy photon = new SqlBulkCopy(dbConnection))
                    {
                        photon.BulkCopyTimeout = 0;
                        //photon.BatchSize = 2000000;
                        photon.ColumnMappings.Clear();
                        photon.DestinationTableName = "photon_int";
                        foreach (var column in p.Columns)
                            photon.ColumnMappings.Add(column.ToString(), column.ToString());
                        try
                        {
                            photon.WriteToServer(p);
                        }
                    finally 
                    {
                        dbConnection.Close();
                    }
                        
                    }
                
            }
            Btn_table.Enabled = false;
        }

        protected void Btn_Graph_Click(object sender, EventArgs e)
        {
            Chart1.Visible = true;
            ArrayList x_intplot = new ArrayList();
            ArrayList y_intplot = new ArrayList();

            x_intplot = (ArrayList)Session["x_int"];
            y_intplot = (ArrayList)Session["y_int"];

            Chart1.Series[0].Points.DataBindXY(x_intplot.ToArray(), y_intplot.ToArray());           
         }

        protected void Btn_Path_Click(object sender, EventArgs e)
        {
            Chart3.Visible = true;
            ArrayList Path_xplot = new ArrayList();
            ArrayList Path_yplot = new ArrayList();
            Path_xplot = (ArrayList)Session["Path_x"];
            Path_yplot = (ArrayList)Session["Path_y"];
           // Chart.ImageStorageMode="UseImageLocation
           
            Chart3.Series[0].Points.DataBindXY(Path_xplot.ToArray(), Path_yplot.ToArray());
        }

        protected void Btn_Compton_Click(object sender, EventArgs e)
        {
            Chart4.Visible = true;
            ArrayList Int_xplot = new ArrayList();
            ArrayList Int_yplot = new ArrayList();
            ArrayList Int_y1plot = new ArrayList();

            Int_xplot = (ArrayList)Session["Int_x"];
            Int_yplot = (ArrayList)Session["Int_y"];
            Int_y1plot = (ArrayList)Session["Int_y1"];
            Chart4.Series[0].Points.DataBindXY(Int_xplot.ToArray(), Int_yplot.ToArray());
            Chart4.Series[1].Points.DataBindXY(Int_xplot.ToArray(), Int_y1plot.ToArray());
        }
       
        protected void Btn_compton__Sca_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable comp_sca = new DataTable();
            comp_sca = (DataTable)Session["Compton_Profile"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy Compton = new SqlBulkCopy(dbConnection))
                {
                    Compton.ColumnMappings.Clear();
                    Compton.DestinationTableName = "Comp_pro";
                    foreach (var column in comp_sca.Columns)
                    Compton.ColumnMappings.Add(column.ToString(), column.ToString());
                    Compton.WriteToServer(comp_sca);
                    dbConnection.Close();
                }
            }
            Btn_compton_Sca_Click.Enabled = false;
        }

        protected void Btn_dam_atom_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable PKA_his = new DataTable();
            PKA_his = (DataTable)Session["PKA_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dpa = new SqlBulkCopy(dbConnection))
                {
                    dpa.ColumnMappings.Clear();
                    dpa.DestinationTableName = "PKA_history";
                    foreach (var column in PKA_his.Columns)
                    dpa.ColumnMappings.Add(column.ToString(), column.ToString());
                    dpa.WriteToServer(PKA_his);
                    dbConnection.Close();
                }
            }
            Btn_dam_atom.Enabled = false;
        }

        protected void Btn_stoping_power_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stoping_power.aspx");
        }

        protected void Btn_PE_Click(object sender, EventArgs e)
        {
            Response.Redirect("PE.aspx");
        }

        protected void Btn_kerma_Click(object sender, EventArgs e)
        {
            
            
        }

        protected void Btn_elec_history_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable elec_his = new DataTable();
            elec_his = (DataTable)Session["Electron_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy elec = new SqlBulkCopy(dbConnection))
                {
                    elec.ColumnMappings.Clear();
                    elec.DestinationTableName = "elec_history";
                    foreach (var column in elec_his.Columns)
                        elec.ColumnMappings.Add(column.ToString(), column.ToString());
                    elec.WriteToServer(elec_his);
                    dbConnection.Close();
                }

            }
            Btn_elec_history.Enabled = false;
        }

        protected void Btn_dam_SKA_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable SKA_his = new DataTable();
            SKA_his = (DataTable)Session["SKA_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dpska = new SqlBulkCopy(dbConnection))
                {
                    dpska.ColumnMappings.Clear();
                    dpska.DestinationTableName = "SKA_history";
                    foreach (var column in SKA_his.Columns)
                      dpska.ColumnMappings.Add(column.ToString(), column.ToString());
                    dpska.WriteToServer(SKA_his);
                    dbConnection.Close();
                }

            }
            Btn_dam_SKA.Enabled = false;
        }

        protected void Btn_dam_atom_r_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable PKA_his_l = new DataTable();
            PKA_his_l = (DataTable)Session["PKA_l_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dpska = new SqlBulkCopy(dbConnection))
                {
                    dpska.ColumnMappings.Clear();
                    dpska.DestinationTableName = "PKA_l_history";
                    foreach (var column in PKA_his_l.Columns)
                        dpska.ColumnMappings.Add(column.ToString(), column.ToString());
                    dpska.WriteToServer(PKA_his_l);
                    dbConnection.Close();
                }

            }
            Btn_dam_atom_r.Enabled = false;
        }

        protected void Btn_dam_SKA_r_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable SKA_his_l = new DataTable();
            SKA_his_l = (DataTable)Session["SKA_l_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dbska = new SqlBulkCopy(dbConnection))
                {
                    dbska.ColumnMappings.Clear();
                    dbska.DestinationTableName = "SKA_l_history";
                    foreach (var column in SKA_his_l.Columns)
                        dbska.ColumnMappings.Add(column.ToString(), column.ToString());
                    dbska.WriteToServer(SKA_his_l);
                    dbConnection.Close();
                }

            }
            Btn_dam_SKA_r.Enabled = false;
        }

        protected void Btn_dam_Ed_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable PKA_his_Ed = new DataTable();
            PKA_his_Ed = (DataTable)Session["PKA_Ed_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dppka = new SqlBulkCopy(dbConnection))
                {
                    dppka.ColumnMappings.Clear();
                    dppka.DestinationTableName = "PKA_Ed_history";
                    foreach (var column in PKA_his_Ed.Columns)
                        dppka.ColumnMappings.Add(column.ToString(), column.ToString());
                    dppka.WriteToServer(PKA_his_Ed);
                    dbConnection.Close();
                }

            }
            Btn_dam_Ed.Enabled = false;
        }

        protected void Btn_SKA_Ed_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable SKA_his_Ed = new DataTable();
            SKA_his_Ed = (DataTable)Session["SKA_Ed_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy dpska = new SqlBulkCopy(dbConnection))
                {
                    dpska.ColumnMappings.Clear();
                    dpska.DestinationTableName = "SKA_Ed_history";
                    foreach (var column in SKA_his_Ed.Columns)
                        dpska.ColumnMappings.Add(column.ToString(), column.ToString());
                    dpska.WriteToServer(SKA_his_Ed);
                    dbConnection.Close();
                }

            }
            Btn_SKA_Ed.Enabled = false;
        }

        protected void Btn_elec_history__Ed_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable e_his_Ed = new DataTable();
            e_his_Ed = (DataTable)Session["Elec_Ed_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy e_Ed = new SqlBulkCopy(dbConnection))
                {
                    e_Ed.ColumnMappings.Clear();
                    e_Ed.DestinationTableName = "Elec_Ed_history";
                    foreach (var column in e_his_Ed.Columns)
                        e_Ed.ColumnMappings.Add(column.ToString(), column.ToString());
                    e_Ed.WriteToServer(e_his_Ed);
                    dbConnection.Close();
                }

            }
            Btn_elec_history_Ed.Enabled = false;
        }

        protected void Btn_vac_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable vac_his = new DataTable();
            vac_his = (DataTable)Session["Vac_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy vac = new SqlBulkCopy(dbConnection))
                {
                    vac.ColumnMappings.Clear();
                    vac.DestinationTableName = "vac_history";
                    foreach (var column in vac_his.Columns)
                        vac.ColumnMappings.Add(column.ToString(), column.ToString());
                    vac.WriteToServer(vac_his);
                    dbConnection.Close();
                }
            }
            Btn_vac.Enabled = false;
        }

        protected void Btn_intl_Click(object sender, EventArgs e)
        {
            string constring = ("Data Source=AMBIKATUNDWAL;Initial Catalog=Fe_dpa_3march16;Integrated Security=True");
            DataTable int_his = new DataTable();
            int_his = (DataTable)Session["Int_History"];
            using (SqlConnection dbConnection = new SqlConnection(constring))
            {
                dbConnection.Open();
                using (SqlBulkCopy intl = new SqlBulkCopy(dbConnection))
                {
                    intl.ColumnMappings.Clear();
                    intl.DestinationTableName = "Int_history";
                    foreach (var column in int_his.Columns)
                        intl.ColumnMappings.Add(column.ToString(), column.ToString());
                        intl.WriteToServer(int_his);
                    dbConnection.Close();
                }

            }
            Btn_intl.Enabled = false;
        }

        protected void Btn_eElastic_cross_Click(object sender, EventArgs e)
        {
            Response.Redirect("eElastic_cross.aspx");
        }

        protected void Btn_e_stp_Click(object sender, EventArgs e)
        {
            Response.Redirect("Stoping_power.aspx");
        }

        protected void Btn_atm_cross_Click(object sender, EventArgs e)
        {
            Response.Redirect("atomic_cross.aspx");
        }

        protected void Btn_atm_e_loss_Click(object sender, EventArgs e)
        {
            Response.Redirect("atom_e_loss.aspx");
        }

        protected void Btn_atom_coll_dE_Click(object sender, EventArgs e)
        {
            Response.Redirect("atom_col_dE.aspx");
        }

        protected void Btn_e_atom_coll_dE_Click(object sender, EventArgs e)
        {
            Response.Redirect("elec_cascade.aspx");
        }

        protected void Btn_Kerma_cal_Click(object sender, EventArgs e)
        {
            Response.Redirect("KERMA.aspx");
        }
    }
}
