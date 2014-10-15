using NUnit.Framework;
using System.Collections.Generic;

namespace QueryStringParser
{
	public class QueryStringParserTests
	{
		private UrlStringParser _parser;

		[SetUp]
		public void Setup()
		{
			_parser = new UrlStringParser();
		}

		[Test]
		public void Should_return_empty_list_when_empty_string_passed_in()
		{
			Assert.That(_parser.ParsedQueryString("").Count, Is.EqualTo(0));
		}

		[Test]
		public void Should_return_empty_list_when_only_question_mark_entered()
		{
			Assert.That(_parser.ParsedQueryString("?").Count, Is.EqualTo(0));
		}

		[Test]
		public void Should_return_key_value_if_key_entered()
		{
			var urlInput = (Dictionary<string, string>)_parser.ParsedQueryString("test");

			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsValue(null));
			Assert.That(urlInput.Count, Is.EqualTo(1));
		}

		[Test]
		public void Should_ignore_leading_question_mark_when_present()
		{
			var urlInput = (Dictionary<string, string>)_parser.ParsedQueryString("?test");

			Assert.That(urlInput.Count, Is.EqualTo(1));
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsValue(null));
		}

		[TestCase("test=hello", 1, "test", "hello")]
		[TestCase("test=hello&name=sophie", 2, "name", "hello")]
		[TestCase("test=hello&name=sophie&age=22", 3, "age", "22")]
		[TestCase("test&hello", 2, "test", null)]
		[TestCase("a=b&c=d&e&f=g", 4, "f", "d")]
		public void Should_add_query_strings_to_dictionary(
			string queryString, int expectedCount, string expectedKey, string expectedValue)
		{
			var urlInput = (Dictionary<string, string>) _parser.ParsedQueryString(queryString);

			Assert.That(urlInput.Count, Is.EqualTo(expectedCount));
			Assert.That(urlInput.ContainsKey(expectedKey));
			Assert.That(urlInput.ContainsValue(expectedValue));
		}
	}
}