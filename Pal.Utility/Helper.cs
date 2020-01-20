using Pal.Emailing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Pal.Utility
{
	class EnumHelper
	{
		public static T Parse<T>(string input)
		{
			return (T)Enum.Parse(typeof(T), input, true);
		}
	}

	public class Helper
	{
		public static string GetAutoCode(int id)
		{
			id = id + 1;
			if (id < 10)
				return "00" + id.ToString();
			else if (id > 9 && id < 100)
				return "0" + id.ToString();
			else
				return id.ToString();
		}

		public static string GetListToString(List<string> lstValue)
		{
			string sValue = "";
			foreach (var item in lstValue)
			{
				sValue += item.ToString() + ",";
			}

			return sValue;
		}

		public static string GetSQLValue(object value)
		{
			string sqlValue = string.Empty;

			if (value is DateTime)
			{
				sqlValue = "'" + Convert.ToString((DateTime)value) + "'";
			}

			if (value is string)
			{
				sqlValue = "'" + ((string)value).Replace("'", "''") + "'";
			}

			if (value is int || value is double || value is long || value is decimal)
			{
				sqlValue = value.ToString();
			}

			if (value is bool)
			{
				sqlValue = (value.Equals(true) ? "1" : "0");
			}
			if (value == null)
			{
				sqlValue = "null";
			}
			return sqlValue;
		}

		//public static string GetSQLValue(object value, Field f)
		//{

		//	string sqlValue = string.Empty;
		//	if (value == null || value.Equals(string.Empty) )
		//	{
		//		return "null";
		//	}

		//	switch (f.FieldType.ToLower())
		//	{
		//		case "datetime":
		//			{
		//				sqlValue = "'" + value.ToString() + "'" ;//"'" + Convert.ToString((DateTime)value) + "'";
		//				break;
		//			}
		//		case "text":
		//		case "longtext":
		//		case "char":
		//		case "html":
		//		case "multiline text":
		//		case "multiselect":
		//			{
		//				sqlValue = "'" + ((string)value).Replace("'", "''") + "'";
		//				break;
		//			}
		//		case "integer":
		//		case "double":
		//		case "numeric":
		//		case "listitem":
		//		case "singleselection":
		//			{
		//				sqlValue = value.ToString();
		//				break;
		//			}
		//		case "boolean":
		//			{
		//				sqlValue = (value.Equals(true) ? "1" : "0");
		//				break;
		//			}
		//		case "documentattachment":
		//			{
		//				if (f.EntityId == 6)
		//				{
		//					sqlValue = "'" + ((string)value).Replace("'", "''") + "'";
		//				}
		//				else
		//				{
		//					sqlValue = value.ToString();
		//				}
		//				break;
		//			}
		//		default:
		//			{
		//				throw new InvalidOperationException();
		//			}
		//	}

		//	return sqlValue;

		//}

		public static string GetString(object value)
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)))
			{
				return string.Empty;
			}
			else
			{
				return System.Convert.ToString(value);
			}
		}

		public static int GetInt32(object value)
		{
			if ((value == null) || (value.Equals(DBNull.Value)) || (value is string && string.IsNullOrEmpty((string)value)))
			{
				return 0;
			}
			else
			{
				return System.Convert.ToInt32(value);
			}
		}

		public static bool GetBoolean(object value)
		{
			if (value == null || (value is DBNull && value.Equals(DBNull.Value)))
			{
				return false;
			}
			else
			{
				return System.Convert.ToBoolean(value);
			}
		}

		public static DateTime GetDateTime(object value)
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)))
			{
				return DateTime.MinValue;
			}
			else
			{
				return System.Convert.ToDateTime(value);
			}
		}

		public static DateTime GetDateTimeFromJavaScript(string val)
		{
			try
			{
				string s = val.Substring(4, 11);
				return System.DateTime.Parse(s);
			}
			catch
			{
				return DateTime.MinValue;
			}
		}

		public static string GetDateString(object value, string format = "dd/MM/yyyy")
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)))
			{
				return string.Empty;
			}
			else
			{
				return Convert.ToDateTime(value).ToString(format);
			}
		}

		public static string GetInt32Text(object value, int emptyValue)
		{
			int i = GetInt32(value);

			return (i.Equals(emptyValue)) ? String.Empty : i.ToString();
		}

		public static string GetDateShortText(DateTime dt)
		{
			return (dt.Equals(DateTime.MinValue)) ? string.Empty : dt.ToShortDateString();
		}

		public static string GetDateShortText(object o)
		{
			return GetDateShortText(GetDateTime(o));
		}

		public static double GetDouble(object value)
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)) || (value.Equals(string.Empty)))
			{
				return 0;
			}
			else
			{
				return System.Convert.ToDouble(value);
			}
		}

		public static decimal GetDecimal(object value)
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)) || (value is string && string.IsNullOrEmpty(value as string)))
			{
				return 0;
			}
			else
			{
				return System.Convert.ToDecimal(value);
			}
		}

		public static object GetValueIfContains(DataRow dr, string col)
		{
			return GetValueIfContains(dr.Table.Columns, dr, col);
		}

		public static object GetValueIfContains(DataColumnCollection columns, DataRow dr, string col)
		{
			return (columns.Contains(col) ? dr[col] : null);
		}

		public static DateTime GetString2Date(object value, string formatType = "dd/MM/yyyy")
		{
			if ((value == null) || (value is DBNull && value.Equals(DBNull.Value)))
			{
				return DateTime.MinValue;
			}
			else
			{
				return DateTime.ParseExact(value.ToString(), formatType, System.Globalization.CultureInfo.CreateSpecificCulture("en-GB"));
			}

		}

		//public static string ConvertDataTableToJSon(DataTable dt)
		//{
		//	System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
		//	List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
		//	Dictionary<string, object> row = new Dictionary<string, object>();
		//	DataColumnCollection columns = dt.Columns;

		//	try
		//	{
		//		foreach (DataRow dr in dt.Rows)
		//		{
		//			row = new Dictionary<string, object>();
		//			foreach (DataColumn col in columns)
		//			{
		//				row.Add(col.ColumnName, dr[col].ToString());
		//			}
		//			rows.Add(row);
		//		}

		//		return serializer.Serialize(rows);
		//	}

		//	catch (Exception ex)
		//	{
		//		throw;
		//	}
		//}

		public static List<SelectionDropdownVM> ConvertToSelectionDropdownVM(DataTable dt, string primaryKeyColName, string nameColName, string otherDataColName)
		{
			DataColumnCollection columns = dt.Columns;
			bool isOtherData = !string.IsNullOrEmpty(otherDataColName);
			List<SelectionDropdownVM> lst = new List<SelectionDropdownVM>();
			try
			{
				foreach (DataRow dr in dt.Rows)
				{
					SelectionDropdownVM row = new SelectionDropdownVM();
					row.PrimaryKey = GetInt32(dr[primaryKeyColName]).ToString();
					row.Name = GetString(dr[nameColName]);
					if (isOtherData)
						row.OtherField = GetString(dr[otherDataColName]);

					lst.Add(row);
				}

				return lst;
			}

			catch (Exception ex)
			{
				throw;
			}
		}

		public static DateTime ConvertUTCtoUserDate(string userTimeZone, DateTime utcDate)
		{
			DateTime dt = TimeZoneInfo.ConvertTimeFromUtc(utcDate, GetTZI(userTimeZone));
			dt = DateTime.SpecifyKind(dt, DateTimeKind.Unspecified);

			return dt;
		}

		public static TimeZoneInfo GetTZI(string userTimeZone)
		{
			TimeZoneInfo tzi;
			try
			{
				tzi = TimeZoneInfo.FindSystemTimeZoneById(userTimeZone);
			}
			catch
			{
				// Default is Eastern Standard Time if TimeZone is not found. 
				tzi = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time");
			}

			return tzi;
		}


		public static ResponseViewModel SendMail(string ToEmail, string Body, string Subject = "", string EmailFrom = "")
		{
			return SendMail(ToEmail, Body, Subject, EmailFrom, null, "", "");
		}

		public static ResponseViewModel SendMail(string ToEmail, string Body, string Subject = "", string EmailFrom = "", byte[] attachmentData = null, string fileName = "", string fileType = "")
		{
			ResponseViewModel res = new ResponseViewModel();
			try
			{
				if (string.IsNullOrEmpty(Subject))
					Subject = EmailConfig.PALEmailSubject;

				IEmailing emailing = EmailingFactory.Create();
				EmailingMessage mail = new EmailingMessage();
				mail.FromEmail = (!string.IsNullOrEmpty(EmailFrom) ? EmailFrom : EmailConfig.PALEmailSMTPServerAuthUserName);
				mail.Format = EmailFormat.Html;
				mail.Body = Body;
				mail.Subject = Subject;

				if (attachmentData != null && attachmentData.Length > 0)
				{
					mail.AttachmentList = new List<System.Net.Mail.Attachment>();
					MemoryStream ms = new MemoryStream(attachmentData);
					System.Net.Mail.Attachment attachment = new System.Net.Mail.Attachment(ms, fileName, fileType);
					mail.AttachmentList.Add(attachment);
				}

				if (EmailConfig.PALEmailMode.ToUpper() == "TEST")
					mail.ToEmail = EmailConfig.PALEmailTo;
				else
					mail.ToEmail = ToEmail;
				emailing.SendEmail(mail);

				res.Status = "SUCCESS";
				res.Message = "";
			}
			catch (Exception ex)
			{
				res.Status = "FAIL";
				res.Message = "SEND ERROR : " + ex.Message;
			}
			return res;
		}

		public static string SaveFileToLocal(HttpPostedFileBase objfile)
		{
			try
			{
				string fname = "";
				var FilePath = HttpContext.Current.Server.MapPath("~/MediaFiles/");
				if (objfile != null)
				{
					//var InputFileName = Path.GetFileName(Promofile.FileName);

					string[] testfiles = objfile.FileName.Split(new char[] { '\\' });
					fname = testfiles[testfiles.Length - 1];
					fname = DateTime.Now.Ticks + fname;

					var ServerSavePath = Path.Combine(FilePath, fname);
					objfile.SaveAs(ServerSavePath);
				}
				return fname;
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

		public static void DeleteFile(string FileName)
		{
			var FilePath = HttpContext.Current.Server.MapPath("~/MediaFiles/" + FileName);
			if (File.Exists(FilePath))
			{
				File.Delete(FilePath);
			}

		}

		public DataSet ToDataSet<T>(List<T> items)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);
			//Get all the properties
			PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (PropertyInfo prop in Props)
			{
				//Setting column names as Property names
				dataTable.Columns.Add(prop.Name);
			}
			foreach (T item in items)
			{
				var values = new object[Props.Length];
				for (int i = 0; i < Props.Length; i++)
				{
					values[i] = Props[i].GetValue(item, null);
				}
				dataTable.Rows.Add(values);
			}
			DataSet ds = new DataSet();
			ds.Tables.Add(dataTable);
			return ds;
		}

		public static List<T> ConvertDataTable<T>(DataTable dt)
		{
			List<T> data = new List<T>();
			foreach (DataRow row in dt.Rows)
			{
				T item = GetItem<T>(row);
				data.Add(item);
			}
			return data;
		}

		private static T GetItem<T>(DataRow dr)
		{
			Type temp = typeof(T);
			T obj = Activator.CreateInstance<T>();

			foreach (DataColumn column in dr.Table.Columns)
			{
				foreach (System.Reflection.PropertyInfo pro in temp.GetProperties())
				{
					if (pro.Name == column.ColumnName)
					{
						switch (dr[column.ColumnName].GetType().Name)
						{
							case "DateTime":
								pro.SetValue(obj, GetDateTime(dr[column.ColumnName]), null);
								break;
							case "Decimal":
								pro.SetValue(obj, GetDecimal(dr[column.ColumnName]), null);
								break;
							case "Int16":
							case "Int32":
							case "Int64":
								pro.SetValue(obj, GetInt32(dr[column.ColumnName]), null);
								break;
							case "DBNull":
								object value = dr[column.ColumnName];
								if (value == DBNull.Value)
									value = null;
								pro.SetValue(obj, value, null);
								break;
							default:
								pro.SetValue(obj, dr[column.ColumnName], null);
								break;
						}
					}
					else
						continue;
				}
			}
			return obj;
		}
		///////////////////// Other Data Type
		//Boolean
		//Byte
		//Char
		//DateTime
		//Decimal
		//Double
		//Int16
		//Int32
		//Int64
		//SByte
		//Single
		//String
		//TimeSpan
		//UInt16
		//UInt32
		//UInt64


		/// <summary>
		/// Generates a Random Password
		/// respecting the given strength requirements.
		/// </summary>
		/// <param name="opts">A valid PasswordOptions object
		/// containing the password strength requirements.</param>
		/// <returns>A random password</returns>
		public static string GenerateRandomPassword()
		{

			var RequiredLength = 8;
			var RequiredUniqueChars = 4;
			var RequireDigit = true;
			var RequireLowercase = true;
			var RequireNonAlphanumeric = true;
			var RequireUppercase = true;

			string[] randomChars = new[] {
					"ABCDEFGHJKLMNOPQRSTUVWXYZ",    // uppercase 
				    "abcdefghijkmnopqrstuvwxyz",    // lowercase
					"0123456789",                   // digits
					"!@$?_-"                        // non-alphanumeric
					};

			Random rand = new Random(Environment.TickCount);
			List<char> chars = new List<char>();

			if (RequireUppercase)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[0][rand.Next(0, randomChars[0].Length)]);

			if (RequireLowercase)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[1][rand.Next(0, randomChars[1].Length)]);

			if (RequireDigit)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[2][rand.Next(0, randomChars[2].Length)]);

			if (RequireNonAlphanumeric)
				chars.Insert(rand.Next(0, chars.Count),
					randomChars[3][rand.Next(0, randomChars[3].Length)]);

			for (int i = chars.Count; i < RequiredLength
				|| chars.Distinct().Count() < RequiredUniqueChars; i++)
			{
				string rcs = randomChars[rand.Next(0, randomChars.Length)];
				chars.Insert(rand.Next(0, chars.Count),
					rcs[rand.Next(0, rcs.Length)]);
			}

			return new string(chars.ToArray());
		}
	}

	public static class DHExtension
	{
		//private static Logger logger = LogManager.GetCurrentClassLogger();

		public static bool ContainsData(this DataSet ds)
		{
			return (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0);
		}
		public static void ConvertUTCToActualDate(this DataColumn column, string timeZone)
		{
			foreach (DataRow row in column.Table.Rows)
			{

				object value = row[column];
				if (value != null && "".Equals(value) == false)
				{
					DateTime dt = Helper.GetDateTime(value);
					if (dt.Equals(DateTime.MinValue) == true)
					{
						value = DBNull.Value;
					}
					else
					{
						dt = Helper.ConvertUTCtoUserDate(timeZone, dt);
						value = dt.ToString("g");
					}

				}
				row[column] = value;

			}
		}
	}

	public class SelectionDropdownVM
	{
		public string PrimaryKey { get; set; }
		public string Name { get; set; }
		public string OtherField { get; set; }

	}

	public static class IEnumerableExtensions
	{
		public static DataTable AsDataTable<T>(this IEnumerable<T> data)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
			var table = new DataTable();
			foreach (PropertyDescriptor prop in properties)
				table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
			foreach (T item in data)
			{
				DataRow row = table.NewRow();
				foreach (PropertyDescriptor prop in properties)
					row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
				table.Rows.Add(row);
			}
			return table;
		}
	}

	public class ResponseViewModel
	{
		public string Status { get; set; }
		public string StatusCode { get; set; }
		public string Message { get; set; }
	}
}
