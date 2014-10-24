using System.Collections.Generic;

namespace QueryStringParser
{
	public class UrlStringParser
	{
		//var valueList = new List<string>();

		public IDictionary<string,List<string>> ParsedQueryString(string url)
		{
			if (HasLeadingQuestionMark(url))
			{
				url = url.Substring(1);
			}

			if (url == string.Empty)
			{
				return new Dictionary<string, List<string>>();
			}

			var fieldValuePairs = url.Split('&', ';');
			var urlDictionary = new Dictionary<string, List<string>>();
			

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
			string singleQueryString, Dictionary<string, List<string>> urlDictionary)
		{
			var equalsPos = singleQueryString.IndexOf('=');
			var fieldUrl = singleQueryString.Remove(equalsPos);
			var valueUrl = singleQueryString.Substring(equalsPos + 1);
			List<string> valuesForParameter;
			var parameterAlreadyExists = urlDictionary.TryGetValue(fieldUrl, out valuesForParameter);
			if (parameterAlreadyExists)
			{
				valuesForParameter.Add(fieldUrl);
			}
			else
			{
				urlDictionary[fieldUrl] = new List<string> {valueUrl};
			}
		}

		private static bool HasLeadingQuestionMark(string url)
		{
			return url.StartsWith("?");
		}
	}
}