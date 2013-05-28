
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2012 MicroSoft
 // 项目名称：Project
 // 文件名：Article.cs
 // 创建者： 
 // 创建时间：2012-07-10
 // 文件功能描述：Tbl_Article表实体类,字段枚举
 //
 //-------------------------------------------------------------------
 // 修改者：
 // 修改时间：
 // 修改描述：
 //
//------------------------------------------------------------------*/

using System;
namespace DPXS.Model
{
	/// <summary>
	///Article数据实体
	/// </summary>
	[Serializable]
	public class ArticleModel
	{
		#region 变量定义
		///<summary>
		///简介
		///</summary>
		private string about = String.Empty;
		///<summary>
		///类别
		///</summary>
		private int categoryID = 0;
		///<summary>
		///编辑人员
		///</summary>
		private string compiler = String.Empty;
		///<summary>
		///内容
		///</summary>
		private string content = String.Empty;
		///<summary>
		///创建时间
		///</summary>
		private string createTime = String.Empty;
		///<summary>
		///点击
		///</summary>
		private int hits = 0;
		///<summary>
		///文章编号
		///</summary>
		private int iD = 0;
		///<summary>
		///是否置顶
		///</summary>
		private int isTop = 0;
		///<summary>
		///缩略图1
		///</summary>
		private string pic1 = String.Empty;
		///<summary>
		///缩略图2
		///</summary>
		private string pic2 = String.Empty;
		///<summary>
		///排序
		///</summary>
		private int sort = 0;
		///<summary>
		///状态：未审核，审核通过，审核不通过
		///</summary>
		private int status = 0;
		///<summary>
		///标签
		///</summary>
		private string tag = String.Empty;
		///<summary>
		///标题
		///</summary>
		private string title = String.Empty;
		///<summary>
		///副标题
		///</summary>
		private string title2 = String.Empty;
		///<summary>
		///信息栏目代号
		///</summary>
		private string type = String.Empty;
		///<summary>
		///更新时间
		///</summary>
		private string updateTime = String.Empty;
		///<summary>
		///
		///</summary>
		private string url = String.Empty;
		#endregion		
		
		#region 公共属性
		
		///<summary>
		///简介
		///</summary>
		public string About
		{
			get {return about;}
			set {about = value;}
		}

		///<summary>
		///类别
		///</summary>
		public int CategoryID
		{
			get {return categoryID;}
			set {categoryID = value;}
		}

		///<summary>
		///编辑人员
		///</summary>
		public string Compiler
		{
			get {return compiler;}
			set {compiler = value;}
		}

		///<summary>
		///内容
		///</summary>
		public string Content
		{
			get {return content;}
			set {content = value;}
		}

		///<summary>
		///创建时间
		///</summary>
		public string CreateTime
		{
			get {return createTime;}
			set {createTime = value;}
		}

		///<summary>
		///点击
		///</summary>
		public int Hits
		{
			get {return hits;}
			set {hits = value;}
		}

		///<summary>
		///文章编号
		///</summary>
		public int ID
		{
			get {return iD;}
			set {iD = value;}
		}

		///<summary>
		///是否置顶
		///</summary>
		public int IsTop
		{
			get {return isTop;}
			set {isTop = value;}
		}

		///<summary>
		///缩略图1
		///</summary>
		public string Pic1
		{
			get {return pic1;}
			set {pic1 = value;}
		}

		///<summary>
		///缩略图2
		///</summary>
		public string Pic2
		{
			get {return pic2;}
			set {pic2 = value;}
		}

		///<summary>
		///排序
		///</summary>
		public int Sort
		{
			get {return sort;}
			set {sort = value;}
		}

		///<summary>
		///状态：未审核，审核通过，审核不通过
		///</summary>
		public int Status
		{
			get {return status;}
			set {status = value;}
		}

		///<summary>
		///标签
		///</summary>
		public string Tag
		{
			get {return tag;}
			set {tag = value;}
		}

		///<summary>
		///标题
		///</summary>
		public string Title
		{
			get {return title;}
			set {title = value;}
		}

		///<summary>
		///副标题
		///</summary>
		public string Title2
		{
			get {return title2;}
			set {title2 = value;}
		}

		///<summary>
		///信息栏目代号
		///</summary>
		public string Type
		{
			get {return type;}
			set {type = value;}
		}

		///<summary>
		///更新时间
		///</summary>
		public string UpdateTime
		{
			get {return updateTime;}
			set {updateTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string Url
		{
			get {return url;}
			set {url = value;}
		}
	
		#endregion
		
	}
}
