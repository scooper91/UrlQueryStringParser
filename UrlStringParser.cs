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

				if (HasLeadingQuestionMark(multipleQueryString))
				{
					singleQueryString = singleQueryString.Substring(1, (multipleQueryString.Length - 1));
				}

				if (QueryStringIsEmpty(singleQueryString))
				{
					return urlDictionary;
				}

				if (singleQueryString.Contains("="))
				{
					keyUrl = AddFieldAndValueToDictionary(singleQueryString, keyUrl, urlDictionary);
				}

				if (keyUrl == string.Empty)
				{
					urlDictionary.Add(singleQueryString, null);
				}
			}
			return urlDictionary;
		}

		private static string AddFieldAndValueToDictionary(
			string singleQueryString, string keyUrl, Dictionary<string, string> urlDictionary)
		{
			var equalsPos = singleQueryString.IndexOf('=');
			var fieldUrl = singleQueryString.Remove(equalsPos);
			keyUrl = singleQueryString.Substring(equalsPos + 1);
			urlDictionary.Add(fieldUrl, keyUrl);
			return keyUrl;
		}

		private static bool QueryStringIsEmpty(string singleQueryString)
		{
			return singleQueryString == string.Empty;
		}

		private static bool HasLeadingQuestionMark(string multipleQueryString)
		{
			return multipleQueryString.StartsWith("?");
		}
	}
}