using NUnit.Framework;

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
			var urlInput = parser.ParsedQueryString("test");
			Assert.That(urlInput.ContainsKey("test"));
			//Assert.That(urlInput.ContainsValue(null));
			Assert.That(urlInput.Count, Is.EqualTo(1));
		}
	}
}