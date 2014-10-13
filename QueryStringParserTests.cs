using NUnit.Framework;
using System.Collections.Generic;

namespace QueryStringParser
{
	public class QueryStringParserTests
	{
		[Test]
		public void Should_return_empty_list_when_empty_string_passed_in()
		{
			var parser = new UrlStringParser();
			
			Assert.That(parser.ParsedQueryString("").Count, Is.EqualTo(0));
		}

		[Test]
		public void Should_return_empty_list_when_only_question_mark_entered()
		{
			var parser = new UrlStringParser();
			
			Assert.That(parser.ParsedQueryString("?").Count, Is.EqualTo(0));
		}

		[Test]
		public void Should_return_key_value_if_key_entered()
		{
			var parser = new UrlStringParser();
			var urlInput = (Dictionary<string, string>)parser.ParsedQueryString("test");
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsValue(null));
			Assert.That(urlInput.Count, Is.EqualTo(1));
		}

		[Test]
		public void Should_ignore_leading_question_mark_when_present()
		{
			var parser = new UrlStringParser();
			var urlInput = (Dictionary<string, string>) parser.ParsedQueryString("?test");

			Assert.That(urlInput.Count, Is.EqualTo(1));
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsValue(null));
		}

		[Test, Ignore]
		public void Should_add_value_if_value_entered()
		{
			var parser = new UrlStringParser();
			var urlInput = (Dictionary<string, string>)parser.ParsedQueryString("test=hello");
			
			Assert.That(urlInput.ContainsKey("test"));
			Assert.That(urlInput.ContainsValue("hello"));
			Assert.That(urlInput.Count, Is.EqualTo(1));
		}
	}
}