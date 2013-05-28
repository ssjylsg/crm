<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ER_ExpenseTrend.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.Children.ER_ExpenseTrend" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>消费记录分析->客户消费走势分析</title>
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
        客户：<asp:DropDownList ID="ddlCustomer" runat="server" AutoPostBack="true">
            <asp:ListItem>全部</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
    </div>
    <table class="sampleTable">
        <tr>
            <td width="500px" class="tdchart">
                <asp:Chart ID="Chart1" runat="server" BackColor="#F3DFC1" Width="500px" Height="296px"
                    BorderlineDashStyle="Solid" Palette="BrightPastel" BackGradientStyle="TopBottom"
                    BorderWidth="2" BorderColor="181, 64, 1" ImageType="Png" ImageLocation="~/TempImages/ChartPic_#SEQ(300,3)">
                    <Titles>
                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                            Text="客户消费走势气泡图" ForeColor="26, 59, 105">
                        </asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend Enabled="False" IsTextAutoFit="False" Name="Default" BackColor="Transparent"
                            Font="Trebuchet MS, 8.25pt, style=Bold">
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                        <asp:Series IsValueShownAsLabel="True" YValuesPerPoint="1" Name="Series1" ChartType="Bubble"
                            BorderColor="180, 26, 59, 105" Color="220, 65, 140, 240" Font="Trebuchet MS, 9pt"
                            YValueType="Double">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BorderDashStyle="Solid"
                            BackSecondaryColor="White" BackColor="OldLace" ShadowColor="Transparent">
                            <Area3DStyle Rotation="10" Perspective="10" Enable3D="True" Inclination="15" IsRightAngleAxes="False"
                                WallWidth="0" IsClustered="False" />
                            <AxisY LineColor="64, 64, 64, 64" Title="消 费 金 额" TitleForeColor="26, 59, 105" TitleFont=" 宋体, 12px, style=Bold">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" Title="日期段" TitleForeColor="26, 59, 105" TitleFont=" Microsoft Sans Serif, 12px, style=Bold">
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
                            气泡形状:
                        </td>
                        <td>
                            <asp:DropDownList ID="Shape" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
                                <asp:ListItem Value="Circle" Selected="True">圆形</asp:ListItem>
                                <asp:ListItem Value="Square">方形</asp:ListItem>
                                <asp:ListItem Value="Diamond">菱形</asp:ListItem>
                                <asp:ListItem Value="Triangle">三角形</asp:ListItem>
                                <asp:ListItem Value="Cross">交叉</asp:ListItem>
                                <asp:ListItem Value="Star4">四角星</asp:ListItem>
                                <asp:ListItem Value="Star5">五角星</asp:ListItem>
                                <asp:ListItem Value="Star6">六角星</asp:ListItem>
                                <asp:ListItem Value="Star10">十角星</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            气泡最大半径(%):
                        </td>
                        <td>
                            <asp:DropDownList ID="MaxSize" runat="server" Width="100px" AutoPostBack="True" CssClass="spaceright">
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="10">10</asp:ListItem>
                                <asp:ListItem Value="15" Selected="True">15</asp:ListItem>
                                <asp:ListItem Value="20">20</asp:ListItem>
                                <asp:ListItem Value="25">25</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            显示为3D:
                        </td>
                        <td>
                            <asp:CheckBox ID="Show3D" TabIndex="6" runat="server" AutoPostBack="True" Text="">
                            </asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <div style="font-size: 13px; margin: 10px">
        注：日期范围大于一年则智能按年统计，日期小于一年按月统计
    </div>
    </form>
</body>
</html>
