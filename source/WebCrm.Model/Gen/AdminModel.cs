
/*--------------------------------------------------------------------
 // 版权所有 Copyright (C) 2012 MicroSoft
 // 项目名称：Project
 // 文件名：Admin.cs
 // 创建者： 
 // 创建时间：2012-6-5
 // 文件功能描述：Tbl_Admin表实体类,字段枚举
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
	///Admin数据实体
	/// </summary>
	[Serializable]
	public class AdminModel
	{
		#region 变量定义
		///<summary>
		///
		///</summary>
		private string createTime = String.Empty;
		///<summary>
		///
		///</summary>
		private string email = String.Empty;
		///<summary>
		///
		///</summary>
		private int iD = 0;
		///<summary>
		///
		///</summary>
		private string lastLoginTime = String.Empty;
		///<summary>
		///
		///</summary>
		private string password = String.Empty;
		///<summary>
		///
		///</summary>
		private string phone = String.Empty;
		///<summary>
		///
		///</summary>
		private string qQ = String.Empty;
		///<summary>
		///
		///</summary>
		private string realName = String.Empty;
		///<summary>
		///
		///</summary>
		private string remark = String.Empty;
		///<summary>
		///
		///</summary>
		private int status = 0;
		///<summary>
		///
		///</summary>
		private string tel = String.Empty;
		///<summary>
		///
		///</summary>
		private string updateTime = String.Empty;
		///<summary>
		///
		///</summary>
		private string userName = String.Empty;
		#endregion		
		
		#region 公共属性
		
		///<summary>
		///
		///</summary>
		public string CreateTime
		{
			get {return createTime;}
			set {createTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string Email
		{
			get {return email;}
			set {email = value;}
		}

		///<summary>
		///
		///</summary>
		public int ID
		{
			get {return iD;}
			set {iD = value;}
		}

		///<summary>
		///
		///</summary>
		public string LastLoginTime
		{
			get {return lastLoginTime;}
			set {lastLoginTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string Password
		{
			get {return password;}
			set {password = value;}
		}

		///<summary>
		///
		///</summary>
		public string Phone
		{
			get {return phone;}
			set {phone = value;}
		}

		///<summary>
		///
		///</summary>
		public string QQ
		{
			get {return qQ;}
			set {qQ = value;}
		}

		///<summary>
		///
		///</summary>
		public string RealName
		{
			get {return realName;}
			set {realName = value;}
		}

		///<summary>
		///
		///</summary>
		public string Remark
		{
			get {return remark;}
			set {remark = value;}
		}

		///<summary>
		///
		///</summary>
		public int Status
		{
			get {return status;}
			set {status = value;}
		}

		///<summary>
		///
		///</summary>
		public string Tel
		{
			get {return tel;}
			set {tel = value;}
		}

		///<summary>
		///
		///</summary>
		public string UpdateTime
		{
			get {return updateTime;}
			set {updateTime = value;}
		}

		///<summary>
		///
		///</summary>
		public string UserName
		{
			get {return userName;}
			set {userName = value;}
		}
	
		#endregion
		
	}
}
