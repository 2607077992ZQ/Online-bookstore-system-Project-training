﻿using System;
namespace BookShop.Model
{
	/// <summary>
	/// Books:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Books
	{
		public Books()
		{}
		#region Model
		private int _id;
		private string _title;
		private string _author;
		private int? _publisherid;
		private string _isbn;
		private int _wordscount;
		private decimal? _unitprice;
		private string _contentdescription;
		private string _authordescription;
		private string _editorcomment;
		private int? _categoryid;
		private int _clicks;
		/// <summary>
		/// 
		/// </summary>
		public int Id
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Title
		{
			set{ _title=value;}
			get{return _title;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Author
		{
			set{ _author=value;}
			get{return _author;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? PublisherId
		{
			set{ _publisherid=value;}
			get{return _publisherid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ISBN
		{
			set{ _isbn=value;}
			get{return _isbn;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int WordsCount
		{
			set{ _wordscount=value;}
			get{return _wordscount;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal? UnitPrice
		{
			set{ _unitprice=value;}
			get{return _unitprice;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ContentDescription
		{
			set{ _contentdescription=value;}
			get{return _contentdescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string AuthorDescription
		{
			set{ _authordescription=value;}
			get{return _authordescription;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string EditorComment
		{
			set{ _editorcomment=value;}
			get{return _editorcomment;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? CategoryId
		{
			set{ _categoryid=value;}
			get{return _categoryid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Clicks
		{
			set{ _clicks=value;}
			get{return _clicks;}
		}
		#endregion Model

	}
}

