using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
namespace BookShop.DAL
{
	/// <summary>
	/// 数据访问类:Books
	/// </summary>
	public partial class Books
	{
		public Books()
		{}
		#region  BasicMethod

		/// <summary>
		/// 得到最大ID
		/// </summary>
		public int GetMaxId()
		{
		return DbHelperSQL.GetMaxID("Id", "Books"); 
		}

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(int Id)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from Books");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public int Add(BookShop.Model.Books model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into Books(");
			strSql.Append("Title,Author,PublisherId,ISBN,WordsCount,UnitPrice,ContentDescription,AuthorDescription,EditorComment,CategoryId,Clicks)");
			strSql.Append(" values (");
			strSql.Append("@Title,@Author,@PublisherId,@ISBN,@WordsCount,@UnitPrice,@ContentDescription,@AuthorDescription,@EditorComment,@CategoryId,@Clicks)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@AuthorDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.PublisherId;
			parameters[3].Value = model.ISBN;
			parameters[4].Value = model.WordsCount;
			parameters[5].Value = model.UnitPrice;
			parameters[6].Value = model.ContentDescription;
			parameters[7].Value = model.AuthorDescription;
			parameters[8].Value = model.EditorComment;
			parameters[9].Value = model.CategoryId;
			parameters[10].Value = model.Clicks;

			object obj = DbHelperSQL.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(BookShop.Model.Books model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update Books set ");
			strSql.Append("Title=@Title,");
			strSql.Append("Author=@Author,");
			strSql.Append("PublisherId=@PublisherId,");
			strSql.Append("ISBN=@ISBN,");
			strSql.Append("WordsCount=@WordsCount,");
			strSql.Append("UnitPrice=@UnitPrice,");
			strSql.Append("ContentDescription=@ContentDescription,");
			strSql.Append("AuthorDescription=@AuthorDescription,");
			strSql.Append("EditorComment=@EditorComment,");
			strSql.Append("CategoryId=@CategoryId,");
			strSql.Append("Clicks=@Clicks");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Title", SqlDbType.NVarChar,200),
					new SqlParameter("@Author", SqlDbType.NVarChar,200),
					new SqlParameter("@PublisherId", SqlDbType.Int,4),
					new SqlParameter("@ISBN", SqlDbType.NVarChar,50),
					new SqlParameter("@WordsCount", SqlDbType.Int,4),
					new SqlParameter("@UnitPrice", SqlDbType.Money,8),
					new SqlParameter("@ContentDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@AuthorDescription", SqlDbType.NVarChar,-1),
					new SqlParameter("@EditorComment", SqlDbType.NVarChar,-1),
					new SqlParameter("@CategoryId", SqlDbType.Int,4),
					new SqlParameter("@Clicks", SqlDbType.Int,4),
					new SqlParameter("@Id", SqlDbType.Int,4)};
			parameters[0].Value = model.Title;
			parameters[1].Value = model.Author;
			parameters[2].Value = model.PublisherId;
			parameters[3].Value = model.ISBN;
			parameters[4].Value = model.WordsCount;
			parameters[5].Value = model.UnitPrice;
			parameters[6].Value = model.ContentDescription;
			parameters[7].Value = model.AuthorDescription;
			parameters[8].Value = model.EditorComment;
			parameters[9].Value = model.CategoryId;
			parameters[10].Value = model.Clicks;
			parameters[11].Value = model.Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Books ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string Idlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from Books ");
			strSql.Append(" where Id in ("+Idlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Books GetModel(int Id)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 Id,Title,Author,PublisherId,ISBN,WordsCount,UnitPrice,ContentDescription,AuthorDescription,EditorComment,CategoryId,Clicks from Books ");
			strSql.Append(" where Id=@Id");
			SqlParameter[] parameters = {
					new SqlParameter("@Id", SqlDbType.Int,4)
			};
			parameters[0].Value = Id;

			BookShop.Model.Books model=new BookShop.Model.Books();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public BookShop.Model.Books DataRowToModel(DataRow row)
		{
			BookShop.Model.Books model=new BookShop.Model.Books();
			if (row != null)
			{
				if(row["Id"]!=null && row["Id"].ToString()!="")
				{
					model.Id=int.Parse(row["Id"].ToString());
				}
				if(row["Title"]!=null)
				{
					model.Title=row["Title"].ToString();
				}
				if(row["Author"]!=null)
				{
					model.Author=row["Author"].ToString();
				}
				if(row["PublisherId"]!=null && row["PublisherId"].ToString()!="")
				{
					model.PublisherId=int.Parse(row["PublisherId"].ToString());
				}
				if(row["ISBN"]!=null)
				{
					model.ISBN=row["ISBN"].ToString();
				}
				if(row["WordsCount"]!=null && row["WordsCount"].ToString()!="")
				{
					model.WordsCount=int.Parse(row["WordsCount"].ToString());
				}
				if(row["UnitPrice"]!=null && row["UnitPrice"].ToString()!="")
				{
					model.UnitPrice=decimal.Parse(row["UnitPrice"].ToString());
				}
				if(row["ContentDescription"]!=null)
				{
					model.ContentDescription=row["ContentDescription"].ToString();
				}
				if(row["AuthorDescription"]!=null)
				{
					model.AuthorDescription=row["AuthorDescription"].ToString();
				}
				if(row["EditorComment"]!=null)
				{
					model.EditorComment=row["EditorComment"].ToString();
				}
				if(row["CategoryId"]!=null && row["CategoryId"].ToString()!="")
				{
					model.CategoryId=int.Parse(row["CategoryId"].ToString());
				}
				if(row["Clicks"]!=null && row["Clicks"].ToString()!="")
				{
					model.Clicks=int.Parse(row["Clicks"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select Id,Title,Author,PublisherId,ISBN,WordsCount,UnitPrice,ContentDescription,AuthorDescription,EditorComment,CategoryId,Clicks ");
			strSql.Append(" FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" Id,Title,Author,PublisherId,ISBN,WordsCount,UnitPrice,ContentDescription,AuthorDescription,EditorComment,CategoryId,Clicks ");
			strSql.Append(" FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM Books ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.Id desc");
			}
			strSql.Append(")AS Row, T.*  from Books T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "Books";
			parameters[1].Value = "Id";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

