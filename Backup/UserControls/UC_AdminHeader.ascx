<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UC_AdminHeader.ascx.cs" Inherits="Neemo.UserControls.UC_AdminHeader" %>
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
                        <asp:MenuItem NavigateUrl="../Admin/~/Default.aspx" Text="Home"/>
                        <asp:MenuItem NavigateUrl="../Admin/~/About.aspx" Text="About"/>
                        
                        <asp:MenuItem Text="Lookups" Value="Lookups">

                           <asp:MenuItem Text="Makes" Value="Makes">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Make_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Make_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Models" Value="Models">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Model_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Model_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                              <asp:MenuItem Text="Badge" Value="Badge">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Badge_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Badge_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                            
                               <asp:MenuItem Text="Series" Value="Series">
                                <asp:MenuItem NavigateUrl="../Admin/Series_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Series_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                                <asp:MenuItem Text="BodyType" Value="BodyType">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/BodyType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/BodyType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem> 
                            
                           
                        <asp:MenuItem Text="Engine No" Value="Engine Nos">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Engine_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="../Admin/Engine_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            <asp:MenuItem Text="CC Rating" Value="CC Rating">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/CCRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="../Admin/CCRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>  

                            <asp:MenuItem Text="Wheel Base" Value="Wheel Base">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/WheelBase_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="../Admin/WheelBase_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            
                            <asp:MenuItem Text="Chassis No" Value="Chassis Nos">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Chassis_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="../Admin/Chassis_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   



                                  <asp:MenuItem Text="Categories" Value="Categorys">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Category_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Category_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   

                            
                              <asp:MenuItem Text="Engine Sizes" Value="Engine Sizes">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/EngineSize_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/EngineSize_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Fuel Types" Value="Fuel Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/FuelType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/FuelType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Colour" Value="Colour">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Colour_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" NavigateUrl="../Admin/Colour_Search.aspx">
                                </asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Side" Value="Side">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Side_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" NavigateUrl="../Admin/Side_Search.aspx">
                                </asp:MenuItem>
                            </asp:MenuItem>

                             <asp:MenuItem Text="Year" Value="Year">
                                <asp:MenuItem NavigateUrl="../Admin/Year_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Year_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>  

                            <%--    <asp:MenuItem Text="Deal Types" Value="Deal Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/DealType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/DealType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                            
                                <asp:MenuItem Text="Listing Types" Value="Listing Types">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/ListingType_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/ListingType_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   


                            <asp:MenuItem Text="AncapRating" Value="AncapRating">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/AncapRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit" 
                                    NavigateUrl="../Admin/AncapRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                      

                                <asp:MenuItem Text="Condition" Value="Condition">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Condition_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Condition_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                              <asp:MenuItem Text="Cylinders" Value="Cylinders">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Cylinder_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Cylinder_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                              <asp:MenuItem Text="Green Ratings" Value="Green Ratings">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/GreenRating_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/GreenRating_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                                <asp:MenuItem Text="Induction" Value="Induction">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Induction_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Induction_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>   
                            
                              <asp:MenuItem Text="KiloMeters" Value="KiloMeter">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/KiloMeter_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/KiloMeter_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>                            

                            
                              <asp:MenuItem Text="Power" Value="Power">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Power_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Power_Search.aspx"></asp:MenuItem>

                            </asp:MenuItem>                            
                            <asp:MenuItem Text="P-Plate Approve" Value="P-Plate Approve">
                                <asp:MenuItem NavigateUrl="../Admin/PPlateApprove_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/PPlateApprove_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Prices" Value="Prices">
                                <asp:MenuItem NavigateUrl="../Admin/Price_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Price_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>



                               <asp:MenuItem Text="Towing" Value="Towing">
                                <asp:MenuItem NavigateUrl="../Admin/Towing_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Towing_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                               <asp:MenuItem Text="Transmission" Value="Transmission">
                                <asp:MenuItem NavigateUrl="../Admin/Transmission_New.aspx" Text="New" Value="New"></asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Transmission_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>

                                 --%>                       

                         


                        </asp:MenuItem>

                        <asp:MenuItem Text="More Lookups" Value="More Lookups">
                            <asp:MenuItem Text="Wreck No" Value="Wreck Nos">
                                <asp:MenuItem NavigateUrl="../Admin/Wreck_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Wreck_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Admin/Part_Search.aspx" Text="Parts" Value="Parts">
                                <asp:MenuItem NavigateUrl="~/Admin/Part_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Admin/Part_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem NavigateUrl="~/Admin/Feature_Search.aspx" Text="Features" 
                                Value="Features">
                                <asp:MenuItem NavigateUrl="~/Admin/Feature_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="~/Admin/Feature_Search.aspx" Text="Search &amp; Edit" 
                                    Value="Search &amp; Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Suburbs" Value="Suburbs">
                                <asp:MenuItem NavigateUrl="../Admin/Suburb_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Suburb_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="Regions" Value="Regions">
                                <asp:MenuItem NavigateUrl="../Admin/Region_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/Region_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                            <asp:MenuItem Text="States" Value="States">
                                <asp:MenuItem NavigateUrl="../Admin/State_New.aspx" Text="New" Value="New">
                                </asp:MenuItem>
                                <asp:MenuItem NavigateUrl="../Admin/State_Search.aspx" Text="Search and Edit" 
                                    Value="Search and Edit"></asp:MenuItem>
                            </asp:MenuItem>
                        </asp:MenuItem>
                         <asp:MenuItem Text="Products" Value="Products">
                                <asp:MenuItem Text="New" Value="New" NavigateUrl="../Admin/Product_New.aspx"></asp:MenuItem>
                                <asp:MenuItem Text="Search and Edit" Value="Search and Edit"  NavigateUrl="../Admin/Product_Search.aspx"></asp:MenuItem>
                            </asp:MenuItem>        
                    </Items>
                </asp:Menu>
            
