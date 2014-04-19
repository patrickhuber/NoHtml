using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public interface IDocumentModelFactory
    {
        IQueryable<Document> CreateDocumentModel();
    }
}
