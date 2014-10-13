using System.Collections.Generic;
using System.Linq;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			var urlDictionary = new Dictionary<string, string>();

			if (url.StartsWith("?"))
			{
				url = url.Substring(1, (url.Length - 1));
			}

			if (url == string.Empty)
			{
				return urlDictionary;
			}
			
			urlDictionary.Add(url, null);
			return urlDictionary;
		}
	}
}