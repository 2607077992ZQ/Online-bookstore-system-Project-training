using System;
using System.Data;
using System.Collections.Generic;
namespace BookShop.BLL
{
    /// <summary>
    /// Books
    /// </summary>
    public partial class Books
	{
		private readonly BookShop.DAL.Books dal=new BookShop.DAL.Books();
		public Books()
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
		public int  Add(BookShop.Model.Books model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Books model)
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
		public BookShop.Model.Books GetModel(int Id)
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
		public List<BookShop.Model.Books> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<BookShop.Model.Books> DataTableToList(DataTable dt)
		{
			List<BookShop.Model.Books> modelList = new List<BookShop.Model.Books>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				BookShop.Model.Books model;
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

		/// <summary>
		/// 取出书籍ID
		/// </summary>
		public decimal GetUnitprice(int index)
        {
			//$"[id] = '{index}'"
			List<Model.Books> modList = GetModelList("");
			Model.Books mod = modList.Find(p => p.Id == index);
			return Convert.ToDecimal(mod.UnitPrice);
        }

		/// <summary>
		/// 取出当前书籍的信息
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>
		public Model.Books GetBooks(int id)
        {
			List<Model.Books> modList = GetModelList("");
			Model.Books mod = modList.Find(p => p.Id == id);
			return mod;
		}

		public DataSet Getbook(int bId)
        {
			DAL.DbHelperSQL db = new DAL.DbHelperSQL();
			DataSet ds = DAL.DbHelperSQL.Query($"select * from ShowInfo where BId='{bId}'");
			return ds;

        }

		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

