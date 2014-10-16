using System;
using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		public IDictionary<string,string> ParsedQueryString(string url)
		{
			if (HasLeadingQuestionMark(url))
			{
				url = url.Substring(1);
			}

			if (url == string.Empty)
			{
				return new Dictionary<string, string>();
			}

			var fieldValuePairs = url.Split('&');
			var urlDictionary = new Dictionary<string, string>();

			foreach (var fieldValuePair in fieldValuePairs)
			{
				if (fieldValuePair.Contains("="))
				{
					AddFieldAndValueToDictionary(fieldValuePair, urlDictionary);
				}
				else
				{
					urlDictionary.Add(fieldValuePair, null);
				}
			}
			return urlDictionary;
		}

		private static void AddFieldAndValueToDictionary(
			string singleQueryString, Dictionary<string, string> urlDictionary)
		{
			var equalsPos = singleQueryString.IndexOf('=');
			var fieldUrl = singleQueryString.Remove(equalsPos);
			var valueUrl = singleQueryString.Substring(equalsPos + 1);
			urlDictionary.Add(fieldUrl, valueUrl);
		}

		private static bool HasLeadingQuestionMark(string url)
		{
			return url.StartsWith("?");
		}
	}
}