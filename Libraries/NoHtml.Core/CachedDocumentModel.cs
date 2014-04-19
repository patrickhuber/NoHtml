using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public class CachedDocumentModel : IQueryable<Document>
    {
        private IQueryable<Document> _documentCache;
        
        public CachedDocumentModel(IEnumerable<Document> documentIterator)
        {
            _documentCache = documentIterator.AsQueryable();
        }

        public IEnumerator<Document> GetEnumerator()
        {
            return _documentCache.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _documentCache.GetEnumerator();
        }

        public Type ElementType
        {
            get { return _documentCache.ElementType; }
        }

        public System.Linq.Expressions.Expression Expression
        {
            get { return _documentCache.Expression; }
        }

        public IQueryProvider Provider
        {
            get { return _documentCache.Provider; }
        }
    }
}
