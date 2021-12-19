using System;
using System.Data;
using System.Collections.Generic;

using BookShop.Model;
namespace BookShop.BLL
{
	/// <summary>
	/// UserRoles
	/// </summary>
	public partial class UserRoles
	{
		private readonly BookShop.DAL.UserRoles dal=new BookShop.DAL.UserRoles();
		public UserRoles()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
			return dal.GetMaxId();
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			return dal.Exists(Id);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int  Add(BookShop.Model.UserRoles model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.UserRoles model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			return dal.Delete(Id);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.UserRoles GetModel(int Id)
		{
			
			return dal.GetModel(Id);
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.UserRoles> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.UserRoles> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.UserRoles> modelList = new List<BookShop.Model.UserRoles>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.UserRoles model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
		//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		/// <summary>
		/// 取出用户id
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		public int UserId(string name)
		{
			List<Model.UserRoles> modList = GetModelList("");
			Model.UserRoles mod = modList.Find(p => p.Name == name);
			int i = mod.Id;
			return i;
		}

		#endregion  ExtensionMethod
	}
}

