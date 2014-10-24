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
		public void Should_return_key_value_if_only_key_entered()
		{
			var urlInput = _parser.ParsedQueryString("test");

			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput["test"], Is.Null);
			Assert.That(urlInput.Count, Is.EqualTo(1));
		}

		[Test]
		public void Should_ignore_leading_question_mark_when_present()
		{
			var urlInput = _parser.ParsedQueryString("?test");

			Assert.That(urlInput.Count, Is.EqualTo(1));
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput["test"], Is.Null);
		}

		[TestCase("test=hello", 1, "test", "hello")]
		[TestCase("test=hello&name=sophie", 2, "test", "hello")]
		[TestCase("test=hello&name=sophie&age=22", 3, "age", "22")]
		[TestCase("a=b&c=d&e&f=g", 4, "c", "d")]
		public void Should_add_query_strings_to_dictionary(
			string queryString, int expectedCount, string expectedKey, string expectedValue)
		{
			var urlInput = _parser.ParsedQueryString(queryString);

			Assert.That(urlInput.Count, Is.EqualTo(expectedCount));
			Assert.That(urlInput.ContainsKey(expectedKey));

			CollectionAssert.Contains(urlInput[expectedKey], expectedValue);
		}

		[Test]
		public void Should_return_null_list_when_no_values_entered()
		{
			var urlInput = _parser.ParsedQueryString("test&hello");
			Assert.That(urlInput.Count, Is.EqualTo(2));
			Assert.That(urlInput["test"], Is.Null);
		}

		[Test]
		public void Should_split_pairs_on_semicolon()
		{
			var urlInput = _parser.ParsedQueryString("test;hello");

			Assert.That(urlInput.Count, Is.EqualTo(2));
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsKey("hello"));
			Assert.That(urlInput["test"], Is.Null);
		}

		[TestCase("test=hello&test=goodbye", 1)]
		[TestCase("test=hello&test=goodbye&test=sophie", 1)]
		[TestCase("field=value&test=hello&test=goodbye", 2)]
		public void Should_add_multiple_values_for_one_field(string urlQueryString , int expectedOutcome )
		{
			var urlInput =_parser.ParsedQueryString(urlQueryString);

			Assert.That(urlInput.Count, Is.EqualTo(expectedOutcome));
		}
	}
}