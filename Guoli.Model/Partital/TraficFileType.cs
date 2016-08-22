/**  版本信息模板在安装目录下，可自行修改。
* TraficFileType.cs
*
* 功 能： N/A
* 类 名： TraficFileType
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2016/7/14 10:42:28   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Guoli.Model
{
	/// <summary>
	/// 行车资料分类表
	/// </summary>
	[Serializable]
	public partial class TraficFileType
	{
		public TraficFileType()
		{}
		#region Model
		private int _id;
		private string _typename;
		private int _parentid;
		/// <summary>
		/// 主键
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 分类名称
		/// </summary>
		public string TypeName
		{
			set{ _typename=value;}
			get{return _typename;}
		}
		/// <summary>
		/// 分类父级Id，关联本表主键，若为0则表示一级分类
		/// </summary>
		public int ParentId
		{
			set{ _parentid=value;}
			get{return _parentid;}
		}
		#endregion Model

	}
}

