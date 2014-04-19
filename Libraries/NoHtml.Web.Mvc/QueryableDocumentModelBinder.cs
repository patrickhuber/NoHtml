using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace NoHtml.Web.Mvc
{
    public class QueryableDocumentModelBinder : IModelBinder
    {
        private IDocumentModelFactory _factory;

        public QueryableDocumentModelBinder(IDocumentModelFactory factory)
        {
            _factory = factory;
        }
        
        public QueryableDocumentModelBinder()
            : this(NoHtml.DependencyResolver.Instance.GetService<IDocumentModelFactory>())
        { }

        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            const string SessionKey = "NoHtml.Web.Mvc.DocumentModel";
            
            var httpSessionBase = controllerContext.RequestContext.HttpContext.Session;
            var queryableDocumentModel = httpSessionBase[SessionKey] as IQueryable<Document>;
            
            if(queryableDocumentModel == null)
            {
                httpSessionBase[SessionKey] = _factory.CreateDocumentModel();
            }

            return httpSessionBase[SessionKey];
        }
    }
}
