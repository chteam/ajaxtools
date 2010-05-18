using System.Collections.Generic;

namespace MvcAjaxToolkit {
	public static class EnumerableExtensions {
		public static IEnumerable<T> ToNotNull<T>(this IEnumerable<T> ie)
		{
			return ie ?? new List<T>();
		}
		
	}
}
