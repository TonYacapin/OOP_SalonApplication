using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SalonAct
{
    public partial class Form1 : Form
    {
        DiscountRate discountRate = new DiscountRate();
        Customer customer = new Customer();
        Visit visit = new Visit();

        double totalPRODUCT = 0;
        double totalServices = 0;

        //prices
        double PriceShampoo = 250;
        double PriceConditioner = 250;
        double PriceHairSpray = 100;
        double PriceHaircut = 150;
        double PriceRebond = 1000;
        double PriceMassage = 500;

        double ConditionerBill = 0;
        double ShampooBill = 0;
        double HairSpayBill = 0;



        public Form1()
        {
            InitializeComponent();
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void bttnProceedtoSelection_Click(object sender, EventArgs e)
        {
            try
            {
                if (Name != "" && rdbNO.Checked || rdbYES.Checked && rdbsilver.Checked || rdbttnGold.Checked || rdbttnPremium.Checked)
                {
                    Visit visit = new Visit(txtName.Text, DateTime.Now);



                    customer = new Customer(txtName.Text);

                    if (rdbNO.Checked)
                    {
                        customer.setMember(false);
                    }
                    else if (rdbYES.Checked)
                    {
                        customer.setMember(true);
                    }

                    if (rdbttnPremium.Checked)
                    {
                        customer.setMemberType("Premium");
                    }
                    else if (rdbttnGold.Checked)
                    {
                        customer.setMemberType("Gold");
                    }
                    else if (rdbsilver.Checked)
                    {
                        customer.setMemberType("Silver");
                    }
                    else { customer.setMemberType("Non-Member"); }

                    lblWELCOME.Text = "Welcome, " + customer.getName();
                   
                    
                        lblmembertype.Text = "MemberType: " + customer.getMemberType();
                    
                   

                    panelLogIn.Visible = false;
                    PanelSelection.Visible = true;
                }
                else { MessageBox.Show("Data not filled properly! Please check the information and resubmit the form.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 
                }
            }
            catch (Exception a)
            {
               
                MessageBox.Show("An error occurred: " + a.Message);
            }
        }
        private void bttnHC_Click(object sender, EventArgs e)
        {
            bttnHC.Enabled = false;
            lblHC.Text = "AVAILED";
            totalServices = totalServices + PriceHaircut;
            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }
        private void bttnRB_Click(object sender, EventArgs e)
        {
            bttnRB.Enabled = false;
            lblRB.Text = "AVAILED";
            totalServices = totalServices + PriceRebond;
            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }
        private void bttnMSSG_Click(object sender, EventArgs e)
        {
            bttnMSSG.Enabled = false;
            lblMSSG.Text = "AVAILED";
            totalServices = totalServices + PriceMassage;
            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }

        private void numericUpDownSHAMPOO_ValueChanged(object sender, EventArgs e)
        {

           
            lblShampoo.Text = numericUpDownSHAMPOO.Value.ToString();
            ShampooBill = PriceShampoo * (int)numericUpDownSHAMPOO.Value;
            totalPRODUCT = HairSpayBill + ShampooBill + ConditionerBill;

            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }

        private void numericUpDownCONDITIONER_ValueChanged(object sender, EventArgs e)
        {
            lblconditioner.Text = numericUpDownCONDITIONER.Value.ToString();
            ConditionerBill = PriceConditioner *(int)numericUpDownCONDITIONER.Value;
            totalPRODUCT = HairSpayBill + ShampooBill + ConditionerBill;

            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }

        private void numericUpDownHAIRSPRAY_ValueChanged(object sender, EventArgs e)
        {
            lblHairSpray.Text = numericUpDownHAIRSPRAY.Value.ToString();



            HairSpayBill = PriceHairSpray * (int)numericUpDownHAIRSPRAY.Value;
            totalPRODUCT = HairSpayBill + ShampooBill + ConditionerBill;

            lblAvailedTotal.Text = (totalPRODUCT + totalServices).ToString("N") + " PHP";
        }

        private void bttnProceedtoBilling_Click(object sender, EventArgs e)
        {

            double finalProductBill = 0;
            double finalServiceBill = 0;

            finalProductBill = totalPRODUCT * (double)discountRate.getProductDiscountRate(customer.getMemberType());
            finalServiceBill = totalServices * (double)discountRate.getServiceDiscountRate(customer.getMemberType());


            lblproductdiscount.Text = finalProductBill.ToString("N") + " PHP";
            lblservicediscount.Text = finalServiceBill.ToString("N") + " PHP";
            lbltotaldiscount.Text = (finalServiceBill + finalProductBill).ToString("N") + " PHP";

            visit.setServiceExpense(totalPRODUCT);
            visit.setProductExpense(totalServices);

            lblreceiptdiscount.Text = (visit.getTotalExpense() - finalServiceBill +finalProductBill).ToString("N") + " PHP";

            PanelSelection.Visible = false;
            panelBilling.Visible = true;
        }

        private void bttnCheckout_Click(object sender, EventArgs e)
        {
            txtName.Text = "";
            rdbNO.Checked = false;
            rdbYES.Checked = false;
            rdbsilver.Checked = false;
            rdbttnGold.Checked = false;
            rdbttnPremium.Checked = false;
            panelLogIn.Enabled = true;

            bttnHC.Enabled = true;
            bttnRB.Enabled = true;
            bttnMSSG.Enabled = true;

            numericUpDownCONDITIONER.Value = 0;
            numericUpDownHAIRSPRAY.Value = 0;
            numericUpDownSHAMPOO.Value = 0;

            lblHC.Text = "N/A";
            lblRB.Text = "N/A";
            lblMSSG.Text = "N/A";

            totalPRODUCT = 0;
            totalServices = 0;

            ConditionerBill = 0;
            ShampooBill = 0;
            HairSpayBill = 0;

            lblAvailedTotal.Text = "0 PHP";




            panelLogIn.Visible = true;
            panelBilling.Visible = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           panelBilling.Visible = false;
            PanelSelection.Visible = true;
        }
    }
}

