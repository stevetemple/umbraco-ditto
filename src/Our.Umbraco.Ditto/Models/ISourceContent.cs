using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace Our.Umbraco.Ditto.Models
{
	public interface ISourceContent
	{
		string Id { get; }
		string SourceType { get; }
		Guid Version { get; }

		bool HasValue(string key);
		object Value(string key, bool recursive = false);
	}

	public class PublishedContentSource : ISourceContent
	{
		private readonly IPublishedContent _publishedContent;

		public PublishedContentSource(IPublishedContent publishedContent)
		{
			_publishedContent = publishedContent;
		}

		public string Id => _publishedContent.Id.ToString();
		public string SourceType => _publishedContent.DocumentTypeAlias;
		public Guid Version => _publishedContent.Version;

		public bool HasValue(string key)
		{
			return _publishedContent.HasProperty(key);
		}

		public object Value(string key, bool recursive = false)
		{
			return _publishedContent.GetPropertyValue(key, recursive);
		}
	}
}
