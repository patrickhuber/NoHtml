using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public class CachedDocumentModelFactory : IDocumentModelFactory
    {
        private IEnumerable<Document> _documentEnumerable;

        public CachedDocumentModelFactory()
            : this(DependencyResolver.Instance.GetService<IEnumerable<Document>>())
        { 
        }

        public CachedDocumentModelFactory(IEnumerable<Document> documentEnumerable)
        {
            _documentEnumerable = documentEnumerable;
        }

        public IQueryable<Document> CreateDocumentModel()
        {
            return new CachedDocumentModel(_documentEnumerable);
        }
    }
}
