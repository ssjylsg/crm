<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ER_IncomeTrend.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.OperatingIncome.ER_IncomeTrend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消费记录分析->营业收入组成分析</title>
    <link href="../ChartCommon.css" rel="stylesheet" type="text/css" />
    <script src="/My97DatePicker/WdatePicker.js" type="text/javascript"></script>
</head>
<body>
  <form id="form1" runat="server">
    <div class="tb_condition">
        开始日期：
        <input id="startDate" runat="Server" style="width: 95px; height: 18px;" type="text"
            class="Wdate" readonly="readonly" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd',maxDate:'#F{$dp.$D(\'endDate\')}'});" />
        结束日期：
        <input id="endDate" runat="Server" style="width: 95px; height: 18px;" type="text"
            class="Wdate" readonly="readonly" onclick=" WdatePicker({ dateFmt: 'yyyy-MM-dd', minDate:'#F{$dp.$D(\'startDate\')}',maxDate:'%y-%M-%d'});" />
        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
    </div>
    <table class="sampleTable">
        <tr>
            <td width="412" class="tdchart">
                <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="WhiteSmoke"
                    Height="296px" Width="412px" BorderlineDashStyle="Solid" BackSecondaryColor="White"
                    BackGradientStyle="TopBottom" BorderWidth="2" BorderColor="26, 59, 105" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                    <Titles>
                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                            Text="Pie Chart" Name="Title1" ForeColor="26, 59, 105">
                        </asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend BackColor="Transparent" Alignment="Center" Docking="Bottom" Font="Trebuchet MS, 8.25pt, style=Bold"
                            IsTextAutoFit="False" Name="Default" LegendStyle="Row">
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                        <asp:Series Name="Default" ChartType="Pie" BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="Transparent"
                            BackColor="Transparent" ShadowColor="Transparent" BorderWidth="0">
                            <Area3DStyle Rotation="0" />
                            <AxisY LineColor="64, 64, 64, 64">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisX>
                        </asp:ChartArea>
                    </ChartAreas>
                </asp:Chart>
            </td>
            <td valign="top">
                <table class="controls" cellpadding="4">
                    <tr>
                        <td class="label">
                            图表类型:
                        </td>
                        <td>
                            <asp:DropDownList ID="ChartTypeList" runat="server" AutoPostBack="True" CssClass="spaceright"
                                Width="112px">
                                <asp:ListItem Value="Doughnut">圆环图</asp:ListItem>
                                <asp:ListItem Value="Pie">饼图</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            标签样式:
                        </td>
                        <td>
                            <asp:DropDownList ID="LabelStyleList" runat="server" AutoPostBack="True" CssClass="spaceright"
                                Width="112px">
                                <asp:ListItem Value="Inside" Selected="True">内部显示</asp:ListItem>
                                <asp:ListItem Value="Outside">外部显示</asp:ListItem>
                                <asp:ListItem Value="Disabled">不显示</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            数据点分离:
                        </td>
                        <td>
                            <asp:DropDownList ID="ExplodedPointList" runat="server" AutoPostBack="True" CssClass="spaceright"
                                Width="112px">
                                <asp:ListItem Value="None" Selected="True">无</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            圆环半径 (%):
                        </td>
                        <td>
                            <asp:DropDownList ID="HoleSizeList" runat="server" AutoPostBack="True" Enabled="False"
                                CssClass="spaceright" Width="112px">
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="30">30</asp:ListItem>
                                <asp:ListItem Value="40">40</asp:ListItem>
                                <asp:ListItem Value="50">50</asp:ListItem>
                                <asp:ListItem Value="60" Selected="True">60</asp:ListItem>
                                <asp:ListItem Value="70">70</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            显示图例:
                        </td>
                        <td>
                            <asp:CheckBox ID="ShowLegend" runat="server" AutoPostBack="True" Checked="True" Text="">
                            </asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            数据点绘制样式:
                        </td>
                        <td>
                            <asp:DropDownList ID="Dropdownlist1" runat="server" Width="112px" CssClass="spaceright"
                                AutoPostBack="True">
                                <asp:ListItem Value="Default" Selected="True">默认</asp:ListItem>
                                <asp:ListItem Value="SoftEdge">柔化边缘</asp:ListItem>
                                <asp:ListItem Value="Concave">凹面</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            显示为3D:
                        </td>
                        <td>
                            <asp:CheckBox ID="CheckboxShow3D" runat="server" AutoPostBack="True" Text="" Checked="true">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
