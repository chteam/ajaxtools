using System.Web.Script.Serialization;
using System.Text;
namespace MvcHelper
{
	/// <summary>
	/// 序列化与反序列化WEB传递的 JSON数据
	/// 重典 http://chsword.cnblogs.com
	/// http://bbs.eice.com.cn
	/// </summary>
	public static class JsonAdapter
	{
		/// <summary>
		/// 序列化
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		static public string Serialize(object obj)
		{
			var serialize = new JavaScriptSerializer();
			var outputStringBuilder = new StringBuilder();
			serialize.Serialize(obj, outputStringBuilder);
			return outputStringBuilder.ToString();
		}
		/// <summary>
		/// 反序列化
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="o"></param>
		/// <returns></returns>
		static public T Deserialize<T>(string o)
		{
			try
			{
				var serialize = new JavaScriptSerializer();
				return serialize.Deserialize<T>(o);
			}
			catch
			{
				return default(T);
			}
		}
	}
}
