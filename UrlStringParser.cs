using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			var urlDictionary = new Dictionary<string, string>();
			var keyUrl = "";

			var multipleQueryStrings = url.Split('&');

			foreach (var multipleQueryString in multipleQueryStrings)
			{
				var singleQueryString = multipleQueryString;

				if (multipleQueryString.StartsWith("?"))
				{
					singleQueryString = singleQueryString.Substring(1, (multipleQueryString.Length - 1));
				}

				if (singleQueryString == string.Empty)
				{
					return urlDictionary;
				}

				if (singleQueryString.Contains("="))
				{
					var equalsPos = singleQueryString.IndexOf('=');
					var fieldUrl = singleQueryString.Remove(equalsPos);
					keyUrl = singleQueryString.Substring(equalsPos + 1);
					urlDictionary.Add(fieldUrl, keyUrl);
				}

				if (keyUrl == string.Empty)
				{
					urlDictionary.Add(singleQueryString, null);
				}
			}
			return urlDictionary;
		}
	}
}