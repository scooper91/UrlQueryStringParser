using System;
using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			var urlDictionary = new Dictionary<string, string>();

			if (HasLeadingQuestionMark(url))
			{
				url = url.Substring(1, (url.Length - 1));
			}

			var multipleQueryStrings = url.Split('&');

			foreach (var multipleQueryString in multipleQueryStrings)
			{
				var valueUrl = "";
				var singleQueryString = multipleQueryString;

				if (IsEmpty(singleQueryString))
				{
					return urlDictionary;
				}

				if (singleQueryString.Contains("="))
				{
					valueUrl = AddFieldAndValueToDictionary(singleQueryString, valueUrl, urlDictionary);
				}

				if (valueUrl == string.Empty)
				{
					urlDictionary.Add(singleQueryString, null);
				}
			}
			return urlDictionary;
		}

		private static string AddFieldAndValueToDictionary(
			string singleQueryString, string valueUrl, Dictionary<string, string> urlDictionary)
		{
			if (valueUrl == null) throw new ArgumentNullException("valueUrl");
			var equalsPos = singleQueryString.IndexOf('=');
			var fieldUrl = singleQueryString.Remove(equalsPos);
			valueUrl = singleQueryString.Substring(equalsPos + 1);
			urlDictionary.Add(fieldUrl, valueUrl);
			return valueUrl;
		}

		private static bool IsEmpty(string singleQueryString)
		{
			return singleQueryString == string.Empty;
		}

		private static bool HasLeadingQuestionMark(string url)
		{
			return url.StartsWith("?");
		}
	}
}