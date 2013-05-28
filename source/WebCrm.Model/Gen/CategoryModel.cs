
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2012 MicroSoft
 // 项目名称：Project
 // 文件名：Category.cs
 // 创建者： 
 // 创建时间：2012-6-5
 // 文件功能描述：Tbl_Category表实体类,字段枚举
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
	///Category数据实体
	/// </summary>
	[Serializable]
	public class CategoryModel
	{
		#region 变量定义
		///<summary>
		///编号
		///</summary>
		private string code = String.Empty;
		///<summary>
		///父ID
		///</summary>
		private int fID = 0;
		///<summary>
		///类别ID
		///</summary>
		private int iD = 0;
		///<summary>
		///名称
		///</summary>
		private string name = String.Empty;
		///<summary>
		///排序
		///</summary>
		private int sort = 0;
		#endregion		
		
		#region 公共属性
		
		///<summary>
		///编号
		///</summary>
		public string Code
		{
			get {return code;}
			set {code = value;}
		}

		///<summary>
		///父ID
		///</summary>
		public int FID
		{
			get {return fID;}
			set {fID = value;}
		}

		///<summary>
		///类别ID
		///</summary>
		public int ID
		{
			get {return iD;}
			set {iD = value;}
		}

		///<summary>
		///名称
		///</summary>
		public string Name
		{
			get {return name;}
			set {name = value;}
		}

		///<summary>
		///排序
		///</summary>
		public int Sort
		{
			get {return sort;}
			set {sort = value;}
		}
	
		#endregion
		
	}
}
