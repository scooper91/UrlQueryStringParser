using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			var urlDictionary = new Dictionary<string, string>();

			if (url == string.Empty || url.Contains("?"))
			{
				return urlDictionary;
			}
			
			urlDictionary.Add(url, null);
			return urlDictionary;
		}
	}
}