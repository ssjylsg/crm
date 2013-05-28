using System;
using System.Text;

namespace WebCX.DAL
{
	public static class SplitPage
	{
		/// <summary>
		/// 获取用于显示分页情况的字符串
		/// </summary>
		/// <param name="pageIndex">当前页</param>
		/// <param name="pageSize">每页数</param>
		/// <param name="recordCount">记录总数</param>
		/// <param name="urlFormat">urlFormat 表示页码地址，其中 “$” 将被替换成页码</param>
		/// <param name="mode">分页方式</param>
		/// <returns>返回 string 类型，表示分页情况</returns>
		public static string GetPageSet(int pageIndex, int pageSize, int recordCount, string urlFormat, int mode)
		{
			string pageSet;
			switch (mode)
			{
				case 0:
					pageSet = GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
					break;
				case 1:
					pageSet = GetPageSet1(pageIndex, pageSize, recordCount, urlFormat);
					break;
				default:
					pageSet = GetPageSet0(pageIndex, pageSize, recordCount, urlFormat);
					break;
			}
			return pageSet;
		}

		private static string GetPageSet0(int pageIndex, int pageSize, int recordCount, string urlFormat)
		{
			int pageCount;
			pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;
			if (pageCount <= 1)
			{
				return "";
			}
			if (pageIndex < 1)
			{
				pageIndex = 1;
			}
			if (pageIndex > pageCount)
			{
				pageIndex = pageCount;
			}

			string[] urlFormatAry = urlFormat.Split('$');

			StringBuilder pageSet = new StringBuilder(800);
			pageSet.Append("共" + recordCount + "条 | ");
			pageSet.Append("每页" + pageSize + "条 | ");
			pageSet.Append("此为" + pageIndex + "/" + pageCount + "页 | ");
			if (pageIndex <= 1)
			{
				pageSet.Append("首页 | 上页 | ");
			}
			else
			{
				pageSet.Append("<a href=\"" + urlFormatAry[0] + "1" + urlFormatAry[1] + "\">首页</a> | ");
				pageSet.Append("<a href=\"" + urlFormatAry[0] + (pageIndex - 1).ToString() + urlFormatAry[1] + "\">上页</a> | ");
			}
			if (pageIndex >= pageCount)
			{
				pageSet.Append("下页 | 尾页 | ");
			}
			else
			{
				pageSet.Append("<a href=\"" + urlFormatAry[0] + (pageIndex + 1).ToString() + urlFormatAry[1] + "\">下页</a> | ");
				pageSet.Append("<a href=\"" + urlFormatAry[0] + pageCount.ToString() + urlFormatAry[1] + "\">尾页</a> | ");
			}
			pageSet.Append("转到 <input id=\"Paging_PageIndex_Text\" name=\"Paging_PageIndex_Text\" type=\"text\" width=40px value=\"" + pageIndex + "\" maxlength=\"10\" size=\"3\" /> 页 ");
			pageSet.Append("<input id=\"Paging_PageIndex_Button\" name=\"Paging_PageIndex_Button\" type=\"button\" value=\"GO\" width=40px onclick=\"javascript: document.location.href = '" + urlFormatAry[0] + "' + document.getElementById('Paging_PageIndex_Text').value + '" + urlFormatAry[1] + "';\" />");

			return pageSet.ToString();
		}

		private static string GetPageSet1(int pageIndex, int pageSize, int recordCount, string urlFormat)
		{
			int pageCount, groupNum, pageNum, startPageNum, endPageNum;
			pageCount = recordCount % pageSize == 0 ? recordCount / pageSize : recordCount / pageSize + 1;
			if (pageCount <= 1)
			{
				return "";
			}
			if (pageIndex < 1)
			{
				pageIndex = 1;
			}
			if (pageIndex > pageCount)
			{
				pageIndex = pageCount;
			}
			groupNum = 8;
			pageNum = pageIndex % groupNum == 0 ? pageIndex / groupNum : pageIndex / groupNum + 1;
			startPageNum = pageNum * groupNum - (groupNum - 1);
			endPageNum = pageNum * groupNum;
			if (pageCount < endPageNum)
			{
				endPageNum = pageCount;
			}

			string[] urlFormatAry = urlFormat.Split('$');
			StringBuilder pageSet = new StringBuilder(800);

			pageSet.Append("<ul id=\"pageSet\">");

			//左侧箭头
			if (startPageNum > groupNum)
			{
				pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex - groupNum).ToString() + urlFormatAry[1] + "\">&lt;&lt;</a></li>");
			}
			if (pageIndex > 1)
			{
				pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex - 1).ToString() + urlFormatAry[1] + "\">&lt;</a></li>");
			}
			//中间数字
			for (int i = startPageNum; i <= endPageNum; i++)
			{
				if (pageIndex == i)
				{
					pageSet.Append("<li ><a >" + i + "</a></li>");
				}
				else
				{
					pageSet.Append("<li><a href=\"" + urlFormatAry[0] + i.ToString() + urlFormatAry[1] + "\">" + i + "</a></li>");
				}
			}
			//右侧箭头
			if (pageIndex < pageCount)
			{
				pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex + 1).ToString() + urlFormatAry[1] + "\">&gt;</a></li>");
			}
			if (endPageNum < pageCount)
			{
				pageSet.Append("<li><a href=\"" + urlFormatAry[0] + (pageIndex + groupNum).ToString() + urlFormatAry[1] + "\">&gt;&gt;</a></li>");
			}

			pageSet.Append("</ul>");

			return pageSet.ToString();
		}
	}
}
