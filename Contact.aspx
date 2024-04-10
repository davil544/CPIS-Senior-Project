<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CPIS_Senior_Project.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <h2 id="title"><%: Title %></h2>
        <h3>Any Questions? Comments? Concerns? </h3>
        <h5>Contact Us Either Through Phone OR Contact Form Below!</h5>
        <address>
            790 Fifth Avenue<br />
            New York, NY 10065<br />
            <abbr title="Phone">P:</abbr>
            800.592.3565
        </address>
       <div class="panel panel-primary" style="margin: 20px;"> 

        <div class="panel-heading"> 


            <h3 class="panel-title">Comment Form</h3> 


        </div> 


        <div class="panel-body"> 


 


            <div class="col-md-6 col-sm-6"> 


                <div class="form-group col-md-6 col-sm-6"> 


                    <label for="name">Name*     </label> 


                    <asp:TextBox ID="name" runat="server" CssClass="form-control  input-sm"></asp:TextBox> 


                   


                </div> 


                <div class="form-group col-md-6 col-sm-6"> 


                    <label for="email">Email*</label> 


                     <asp:TextBox ID="email" runat="server" CssClass="form-control  input-sm"></asp:TextBox> 


                    


                </div> 


 


                <div class="form-group col-md-6 col-sm-6"> 


                    <label for="mobile">Comment*</label> 


                   


                    <textarea class="form-control  input-sm" id="comment" placeholder="" cols="3" rows="3" runat="server" style="margin-right: 198px"> 


                </textarea> 


 


                </div> 


                <div class="form-group col-md-6 col-sm-6"> 


                    <br /> 


                    <br /> 


                    <asp:Button ID="Button1" runat="server" Text="Post" CssClass="btn  btn-success" OnClick="Button1_Click" /> 


                </div> 


 


            </div> 


            <div class="col-md-6 col-sm-6"> 


                <asp:Repeater ID="Repeater1" runat="server"> 


                    <ItemTemplate> 


                        <div class="commentbox"> 


                            <b> 


                                <asp:Label ID="Label1" runat="server" Text='<%#Eval("Name") %>'>'></asp:Label></b>&nbsp;(<asp:Label ID="Label2" runat="server" Text='<%#Eval("Email") %>'>'></asp:Label>):<br /> 


                            <asp:Label ID="Label3" runat="server" Text='<%#Eval("Comment") %>'></asp:Label><br /> 


                        </div> 


                    </ItemTemplate> 


                </asp:Repeater> 


 


 


            </div> 


        </div> 
    </main>
    </div>
</asp:Content>
