using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			var urlDictionary = new Dictionary<string, string>();
			var keyUrl = "";

			if (url.StartsWith("?"))
			{
				url = url.Substring(1, (url.Length - 1));
			}

			if (url == string.Empty)
			{
				return urlDictionary;
			}

			if (url.Contains("="))
			{
				var equalsPos = url.IndexOf('=');
				var fieldUrl = url.Remove(equalsPos);
				keyUrl = url.Substring(equalsPos + 1);
				urlDictionary.Add(fieldUrl, keyUrl);
			}

			if (keyUrl == string.Empty)
			{
				urlDictionary.Add(url, null);
			}

			return urlDictionary;
		}
	}
}