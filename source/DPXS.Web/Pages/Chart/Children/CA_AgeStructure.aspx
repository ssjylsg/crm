<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CA_AgeStructure.aspx.cs"
    Inherits="WebCrm.Web.Pages.Chart.Children.CA_AgeStructure" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>客户结构分析->年龄层次</title>
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
                <asp:Chart ID="Chart1" runat="server" Palette="BrightPastel" BackColor="#F3DFC1"
                    Width="412px" Height="296px" BorderlineDashStyle="Solid" BackGradientStyle="TopBottom"
                    BorderWidth="2" BorderColor="181, 64, 1">
                    <Titles>
                        <asp:Title ShadowColor="32, 0, 0, 0" Font="Trebuchet MS, 14.25pt, style=Bold" ShadowOffset="3"
                            Text="Column Chart" Name="Title1" ForeColor="26, 59, 105">
                        </asp:Title>
                    </Titles>
                    <Legends>
                        <asp:Legend TitleFont="Microsoft Sans Serif, 8pt, style=Bold" BackColor="Transparent"
                            Font="Trebuchet MS, 8.25pt, style=Bold" IsTextAutoFit="False" Enabled="False"
                            Name="Default">
                        </asp:Legend>
                    </Legends>
                    <BorderSkin SkinStyle="Emboss"></BorderSkin>
                    <Series>
                        <asp:Series XValueType="String" Name="Series1" BorderColor="180, 26, 59, 105" YValueType="Int32">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1" BorderColor="64, 64, 64, 64" BackSecondaryColor="White"
                            BackColor="OldLace" ShadowColor="Transparent" BackGradientStyle="TopBottom">
                            <Area3DStyle Rotation="10" Perspective="10" Inclination="15" IsRightAngleAxes="False"
                                WallWidth="0" IsClustered="False" />
                            <AxisY LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="客户人数" TitleForeColor="26, 59, 105"
                                TitleFont="Trebuchet MS, 8pt, style=Bold">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" />
                                <MajorGrid LineColor="64, 64, 64, 64" />
                            </AxisY>
                            <AxisX LineColor="64, 64, 64, 64" LabelAutoFitMaxFontSize="8" Title="年龄段" TitleForeColor="26, 59, 105"
                                TitleFont="Trebuchet MS, 8pt, style=Bold">
                                <LabelStyle Font="Trebuchet MS, 8.25pt, style=Bold" IsEndLabelVisible="False" />
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
                            <asp:DropDownList ID="ChartType" runat="server" Width="120px" AutoPostBack="True"
                                CssClass="spaceright">
                                <asp:ListItem Value="Column">柱形图</asp:ListItem>
                                <asp:ListItem Value="Bar">条形图</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            数据点宽度:
                        </td>
                        <td>
                            <asp:DropDownList ID="BarWidthList" runat="server" AutoPostBack="True" CssClass="spaceright"
                                Width="120px">
                                <asp:ListItem Value="1.0">1.0</asp:ListItem>
                                <asp:ListItem Value="0.8" Selected="True">0.8</asp:ListItem>
                                <asp:ListItem Value="0.6">0.6</asp:ListItem>
                                <asp:ListItem Value="0.4">0.4</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            数据点绘制样式:
                        </td>
                        <td>
                            <asp:DropDownList ID="DrawingStyle" runat="server" Width="120px" AutoPostBack="True"
                                CssClass="spaceright">
                                <asp:ListItem Value="Default">默认</asp:ListItem>
                                <asp:ListItem Value="Emboss">浮雕效果</asp:ListItem>
                                <asp:ListItem Value="Cylinder">圆柱体</asp:ListItem>
                                <asp:ListItem Value="Wedge">楔形</asp:ListItem>
                                <asp:ListItem Value="LightToDark">LightToDark</asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="label">
                            显示为3D:
                        </td>
                        <td>
                            <asp:CheckBox ID="Show3D" TabIndex="6" runat="server" Text="" AutoPostBack="True">
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
