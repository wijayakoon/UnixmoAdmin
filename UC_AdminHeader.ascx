<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AdminHeader.ascx.cs" Inherits="NeemoAdmin.UC_AdminHeader" %>
<style type="text/css">


div.menu
{
    padding: 4px 0px 4px 8px;
}

div.menu ul
{
    list-style: none;
    margin: 0px;
    padding: 0px;
    width: auto;
}

div.menu ul li a, div.menu ul li a:visited
{
    background-color: #465c71;
    border: 1px #4e667d solid;
    color: #dde4ec;
    display: block;
    line-height: 1.35em;
    padding: 4px 20px;
    text-decoration: none;
    white-space: nowrap;
}

a:link, a:visited
{
    color: #034af3;
}

</style>
                <asp:Menu ID="NavigationMenu" runat="server" CssClass="menu" EnableViewState="false" IncludeStyleBlock="false" Orientation="Horizontal">
                    <Items>
                        <asp:MenuItem NavigateUrl="~/Default.aspx" Text="Home"/>
                        <asp:MenuItem NavigateUrl="~/About.aspx" Text="About"/>
                         <asp:MenuItem NavigateUrl="~/Order_Progress.aspx" Text="Orders"/>
                        <asp:MenuItem Text="Lookups" Value="Lookups">

                           <asp:MenuItem Text="Makes" Value="Makes">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Make_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Make_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Models" Value="Models">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Model_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Model_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                              <asp:MenuItem Text="Badge" Value="Badge">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Badge_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Badge_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                            
                               <asp:MenuItem Text="Series" Value="Series">
                                <asp:MenuItem NavigateUrl="Series_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Series_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                                <asp:MenuItem Text="BodyType" Value="BodyType">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="BodyType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="BodyType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem> 
                            
                           
                        <asp:MenuItem Text="Engine No" Value="Engine Nos">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Engine_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="Engine_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            <asp:MenuItem Text="CC Rating" Value="CC Rating">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="CCRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="CCRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>  

                            <asp:MenuItem Text="Wheel Base" Value="Wheel Base">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="WheelBase_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="WheelBase_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            
                            <asp:MenuItem Text="Chassis No" Value="Chassis Nos">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Chassis_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="Chassis_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   



                                  <asp:MenuItem Text="Categories" Value="Categorys">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Category_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Category_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            
                              <asp:MenuItem Text="Engine Sizes" Value="Engine Sizes">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="EngineSize_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="EngineSize_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Fuel Types" Value="Fuel Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="FuelType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="FuelType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Colour" Value="Colour">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Colour_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" NavigateUrl="Colour_Search.aspx">
                                </asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Side" Value="Side">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Side_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" NavigateUrl="Side_Search.aspx">
                                </asp:MenuItem>
                            </asp:MenuItem>

                             <asp:MenuItem Text="Year" Value="Year">
                                <asp:MenuItem NavigateUrl="Year_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Year_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>  

                            <%--    <asp:MenuItem Text="Deal Types" Value="Deal Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="DealType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="DealType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                            
                                <asp:MenuItem Text="Listing Types" Value="Listing Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="ListingType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="ListingType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   


                            <asp:MenuItem Text="AncapRating" Value="AncapRating">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="AncapRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="AncapRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                      

                                <asp:MenuItem Text="Condition" Value="Condition">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Condition_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Condition_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                              <asp:MenuItem Text="Cylinders" Value="Cylinders">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Cylinder_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Cylinder_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                              <asp:MenuItem Text="Green Ratings" Value="Green Ratings">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="GreenRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="GreenRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Induction" Value="Induction">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Induction_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Induction_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                              <asp:MenuItem Text="KiloMeters" Value="KiloMeter">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="KiloMeter_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="KiloMeter_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                            
                              <asp:MenuItem Text="Power" Value="Power">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Power_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Power_Search.aspx"></asp:MenuItem>

                            </asp:MenuItem>                            
                            <asp:MenuItem Text="P-Plate Approve" Value="P-Plate Approve">
                                <asp:MenuItem NavigateUrl="PPlateApprove_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="PPlateApprove_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Prices" Value="Prices">
                                <asp:MenuItem NavigateUrl="Price_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Price_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>



                               <asp:MenuItem Text="Towing" Value="Towing">
                                <asp:MenuItem NavigateUrl="Towing_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Towing_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                               <asp:MenuItem Text="Transmission" Value="Transmission">
                                <asp:MenuItem NavigateUrl="Transmission_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Transmission_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                                 --%>                       

                         


                        </asp:MenuItem>

                        <asp:MenuItem Text="More Lookups" Value="More Lookups">
                            <asp:MenuItem Text="Wreck No" Value="Wreck Nos">
                                <asp:MenuItem NavigateUrl="Wreck_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Wreck_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Part_Search.aspx" Text="Parts" Value="Parts">
                                <asp:MenuItem NavigateUrl="~/Part_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Part_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Feature_Search.aspx" Text="Features" 
                                Value="Features">
                                <asp:MenuItem NavigateUrl="~/Feature_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Feature_Search.aspx" Text="Search &amp; Edit" 
                                    Value="Search &amp; Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Suburbs" Value="Suburbs">
                                <asp:MenuItem NavigateUrl="Suburb_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Suburb_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Regions" Value="Regions">
                                <asp:MenuItem NavigateUrl="Region_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="Region_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="States" Value="States">
                                <asp:MenuItem NavigateUrl="State_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="State_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                         <asp:MenuItem Text="Products" Value="Products">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="Product_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="Product_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>        
                    </Items>
                </asp:Menu>
            
