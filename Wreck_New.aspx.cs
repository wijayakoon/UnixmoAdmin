using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using NeemoAdmin.SupportClasses;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using Neemo.SupportClasses;
using System.Configuration;
using System.Globalization;
using NeemoAdmin.DataServices;

namespace NeemoAdmin
{
    public partial class Wreck_New : System.Web.UI.Page
    {
        Wrecks wreck = new Wrecks();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                PopulateDll();
                if ((Request.QueryString["WreckID"] != null))
                {
                    PopulateWrecks();
                    btn_Update.Enabled = true;
                    Button_Save.Enabled = false;
                }
                else
                {                  
                    TextBox_EffectiveDateFrom.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    btn_Update.Enabled = false;
                    Button_Save.Enabled = true;
                }
            }
            
        }

        protected void Button_Reset_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wreck_New.aspx");
        }



        protected void Button_Save_Click(object sender, EventArgs e)
        {
            {

                try
                {
                    //agent = (Agent)Session["Agent"];
                    RegistrationDetails rd = (RegistrationDetails )Session["RegistrationDetails"];                    
                    wreck.WreckNo = txt_WreckNo.Text;
                    wreck.KeyWord = txt_KeyWord.Text;
                    wreck.MakeID = Convert.ToInt16(drp_Make.SelectedValue);
                    wreck.ModelID = Convert.ToInt16(drp_Model.SelectedValue);
                    wreck.ChassisID = Convert.ToInt16(drp_Chassis.SelectedValue);
                    wreck.EngineID = Convert.ToInt16(drp_EngineNo.SelectedValue);
                    wreck.EngineSizeID = Convert.ToInt16(drp_EngineSize.SelectedValue);
                    wreck.CCRatingID = Convert.ToInt16(drp_CCRating.SelectedValue);
                    wreck.FuelTypeID = Convert.ToInt16(drp_FuelType.SelectedValue);
                    wreck.BodyTypeID = Convert.ToInt16(drp_BodyType.SelectedValue);
                    wreck.WheelBaseID = Convert.ToInt16(drp_WheelBase.SelectedValue);
                    wreck.YearID = Convert.ToInt16(drp_Year.SelectedValue);
                    wreck.Image = Path.GetFileName(Image_Icon.ImageUrl);
                    wreck.Active = chk_Active.Checked;
                    wreck.CreatedDateTime = DateTime.Now;
                    wreck.LastModifiedDateTime = DateTime.Now;
                    wreck.CreatedByUser = rd.UserName;
                    wreck.LastModifiedByUser = rd.UserName;
                    if (Request.QueryString["WreckID"] != null)
                    {
                        wreck.WreckID = Convert.ToInt32(Request.QueryString["WreckID"].ToString());                        
                    }
                    if (wreck.Save())
                    {                        
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Completed", "javascript:Display('Record Saved')", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Error", "javascript:Display('Operation Failed')", true);
                    }
                }
                catch (Exception ex)
                {

                }

            }
            Response.Redirect("~/Wreck_New.aspx");
        }

       

        protected void btn_Upload_Click(object sender, EventArgs e)
        {
            PhotoUpload pupl = new PhotoUpload();

            Image_Icon = pupl.UploadNewImages(FileUpload_Image, Image_Icon, ConfigurationManager.AppSettings["LookupIcons"].ToString(), txt_WreckNo.Text);
        }

        protected void PopulateDll()
        {
            Makes makes = new Makes(); makes.PopulateDllAll(drp_Make);
            Models models = new Models(); models.PopulateDllAll(drp_Model);
            Chassiss chassiss = new Chassiss(); chassiss.PopulateDllAll(drp_Chassis);
            Engines engines = new Engines(); engines.PopulateDllAll(drp_EngineNo);
            EngineSizes engineSizes = new EngineSizes(); engineSizes.PopulateDllAll(drp_EngineSize);
            FuelTypes fuelTypes = new FuelTypes(); fuelTypes.PopulateDllAll(drp_FuelType);
            WheelBases wheelbases = new WheelBases(); wheelbases.PopulateDllAll(drp_WheelBase);
            CCRatings ccRatings = new CCRatings(); ccRatings.PopulateDllAll(drp_CCRating);
            BodyTypes bodyTypes = new BodyTypes(); bodyTypes.PopulateDllAll(drp_BodyType);
            Years years = new Years(); years.PopulateDllAll(drp_Year);
        }

        protected void btn_SearchMake_Click(object sender, EventArgs e)
        {
            Makes makes = new Makes(); makes.PopulateByName(drp_Make,txt_Make.Text);

        }

        protected void btn_SearchModel_Click(object sender, EventArgs e)
        {
            Models models = new Models(); models.PopulateByName(drp_Model, txt_Model.Text);

        }

        protected void Button_SearchChassisNo_Click(object sender, EventArgs e)
        {
            Chassiss chassiss = new Chassiss(); chassiss.PopulateByName(drp_Chassis, txt_ChassisNo.Text);

        }

        protected void btn_SearchEngineNo_Click(object sender, EventArgs e)
        {
            Engines engines = new Engines(); engines.PopulateByName(drp_EngineNo, txt_EngineNo.Text);

        }

        protected void btn_EngineSize_Click(object sender, EventArgs e)
        {
            EngineSizes engineSizes = new EngineSizes(); engineSizes.PopulateByName(drp_EngineSize, txt_EngineSize.Text);

        }

        protected void btn_SearchFuelType_Click(object sender, EventArgs e)
        {
            FuelTypes fuelTypes = new FuelTypes(); fuelTypes.PopulateByName(drp_FuelType, txt_FuelType.Text);

        }

        protected void btn_SearchWheelBase_Click(object sender, EventArgs e)
        {
            WheelBases wheelBases = new WheelBases(); wheelBases.PopulateByName(drp_WheelBase, txt_WheelBase.Text);

        }

        protected void btn_SearchBodyType_Click(object sender, EventArgs e)
        {
            BodyTypes bodyTypes = new BodyTypes(); bodyTypes.PopulateByName(drp_BodyType, txt_BodyType.Text);

        }

        protected void btn_SearchYear_Click(object sender, EventArgs e)
        {
            Years years = new Years(); years.PopulateByName(drp_Year, txt_Year.Text);

        }


         protected void PopulateWrecks()
        {
            
            wreck.WreckID= Convert.ToInt16(Request.QueryString["WreckID"].ToString());
            wreck.WreckNo = null;
            wreck.Status = null;
            wreck.Usage = "SearchByID";

            if (wreck.Load())
            {

               btn_Update.Enabled = true;
               Button_Save.Enabled = false;               
                
                txt_KeyWord.Text = wreck.KeyWord;
                txt_WreckNo.Text = wreck.WreckNo;
                drp_Make.SelectedValue = wreck.MakeID.ToString();
                drp_Model.SelectedValue = wreck.ModelID.ToString();
                drp_Chassis.SelectedValue = wreck.ChassisID.ToString();
                drp_CCRating.SelectedValue = wreck.CCRatingID.ToString();
                drp_EngineNo.SelectedValue = wreck.EngineID.ToString();
                drp_EngineSize.SelectedValue = wreck.EngineSizeID.ToString();
                drp_FuelType.SelectedValue = wreck.FuelTypeID.ToString();
                drp_BodyType.SelectedValue = wreck.BodyTypeID.ToString();
                drp_WheelBase.SelectedValue = wreck.WheelBaseID.ToString();
                drp_Year.SelectedValue = wreck.YearID.ToString();
                chk_Active.Checked = wreck.Active;
                Image_Icon.ImageUrl = ConfigurationManager.AppSettings["LookupIcons_Display"].ToString() + wreck.Image;
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Warning", "javascript:Display('Operation Failed')", true);
                return;
            }
         }

         protected void btn_SearchCCRating_Click(object sender, EventArgs e)
         {
             CCRatings ccRatings = new CCRatings(); ccRatings.PopulateByName(drp_CCRating, txt_CCRating.Text);
         }

       
    }

}