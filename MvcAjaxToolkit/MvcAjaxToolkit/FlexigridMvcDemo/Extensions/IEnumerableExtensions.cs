using System.Collections.Generic;

namespace MvcAjaxToolkit {
	public static class IEnumerableExtensions {
		public static IEnumerable<T> ToNotNull<T>(this IEnumerable<T> ie)
		{
			return ie ?? new List<T>();
		}
		
	}
}
