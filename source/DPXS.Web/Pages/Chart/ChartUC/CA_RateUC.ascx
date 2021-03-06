﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CA_RateUC.ascx.cs" Inherits="WebCrm.Web.Pages.Chart.ChartUC.CA_RateUC" %>
<script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
<!-- 客户结构分析:单位和散客比例 -->
<div>
    开始日期：
   <input id="startDate" runat="Server"   type="text" class="Wdate" readonly="readonly"  onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'endDate\')}'});"/>
   结束日期：
   <input id="endDate" runat="Server" type="text"  class="Wdate" readonly="readonly"  onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate:'#F{$dp.$D(\'startDate\')}',maxDate:'%y-%M-%d'});"/>
   <asp:TextBox ID="hiddenStartDate"  runat="server"></asp:TextBox>
   <asp:TextBox ID="hiddenEndDate" runat="server"></asp:TextBox>                                                                          
</div>
<table class="sampleTable">
	<tr>
		<td width="412" class="tdchart">
			<asp:CHART id="Chart1" runat="server" Palette="BrightPastel" BackColor="WhiteSmoke" Height="296px" Width="412px" BorderlineDashStyle="Solid" BackSecondaryColor="White" BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
				<titles>
					<asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3" Text="Pie Chart" Name="Title1" ForeColor="26, 59, 105"></asp:Title>
				</titles>
				<legends>
					<asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Name="Default" LegendStyle="Row"></asp:Legend>
				</legends>
				<borderskin SkinStyle="Emboss"></borderskin>
				<series>
					<asp:Series Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240"></asp:Series>
				</series>
				<chartareas>
					<asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent" BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
						<area3dstyle Rotation="0" />
						<axisy LineColor="64, 64, 64, 64">
							<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
							<MajorGrid LineColor="64, 64, 64, 64" />
						</axisy>
						<axisx LineColor="64, 64, 64, 64">
							<LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
							<MajorGrid LineColor="64, 64, 64, 64" />
						</axisx>
					</asp:ChartArea>
				</chartareas>
			</asp:CHART>
		</td>
		<td valign="top">
			<table class="controls" cellpadding="4">
				<tr>
					<td class="label">图表类型:</td>
					<td><asp:dropdownlist id="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
							<asp:ListItem Value="Doughnut">圆环图</asp:ListItem>
							<asp:ListItem Value="Pie">饼图</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="label">标签样式:</td>
					<td><asp:dropdownlist id="LabelStyleList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
							<asp:ListItem Value="Inside" Selected="True">内部显示</asp:ListItem>
							<asp:ListItem Value="Outside">外部显示</asp:ListItem>
							<asp:ListItem Value="Disabled">不显示</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="label">数据点分离:</td>
					<td><asp:dropdownlist id="ExplodedPointList" runat="server" AutoPostBack="True" CssClass="spaceright" Width="112px">
							<asp:ListItem Value="None" Selected="True">无</asp:ListItem>
							<asp:ListItem Value="单位">单位</asp:ListItem>
							<asp:ListItem Value="散客">散客</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="label">圆环半径 (%):</td>
					<td><asp:dropdownlist id="HoleSizeList" runat="server" AutoPostBack="True" Enabled="False" CssClass="spaceright" Width="112px">
							<asp:ListItem Value="20">20</asp:ListItem>
							<asp:ListItem Value="30">30</asp:ListItem>
							<asp:ListItem Value="40">40</asp:ListItem>
							<asp:ListItem Value="50">50</asp:ListItem>
							<asp:ListItem Value="60" Selected="True">60</asp:ListItem>
							<asp:ListItem Value="70">70</asp:ListItem>
						</asp:dropdownlist>
					</td>
				</tr>
				<tr>
					<td class="label">显示图例:</td>
					<td><asp:checkbox id="ShowLegend" runat="server" AutoPostBack="True" Checked="True" Text=""></asp:checkbox></td>
				</tr>
				<tr>
					<td class="label">数据点绘制样式:</td>
					<td>
						<asp:dropdownlist id="Dropdownlist1" runat="server" Width="112px" CssClass="spaceright" AutoPostBack="True">
							<asp:ListItem Value="Default">默认</asp:ListItem>
							<asp:ListItem Value="SoftEdge" Selected="True">柔化边缘</asp:ListItem>
							<asp:ListItem Value="Concave">凹面</asp:ListItem>
						</asp:dropdownlist></td>
				</tr>
				<tr>
					<td class="label">显示为3D:</td>
					<td><asp:checkbox id="CheckboxShow3D" runat="server" AutoPostBack="True" Text="" Checked="true"></asp:checkbox></td>
				</tr>
			</table>
		</td>
	</tr>
</table>