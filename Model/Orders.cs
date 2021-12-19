using System;
namespace BookShop.Model
{
	/// <summary>
	/// Orders:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class Orders
	{
		public Orders()
		{}
		#region Model
		private int _id;
		private DateTime _orderdate;
		private int? _userid;
		private decimal _totalprice;
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
		public DateTime OrderDate
		{
			set{ _orderdate=value;}
			get{return _orderdate;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int? UserId
		{
			set{ _userid=value;}
			get{return _userid;}
		}
		/// <summary>
		/// 
		/// </summary>
		public decimal TotalPrice
		{
			set{ _totalprice=value;}
			get{return _totalprice;}
		}
		#endregion Model

	}
}

