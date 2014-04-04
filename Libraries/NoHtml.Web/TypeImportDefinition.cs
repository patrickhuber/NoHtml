using System;
using System.Collections.Generic;
using System.ComponentModel.Composition.Primitives;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace NoHtml.Web
{
    public  class TypeImportDefinition : ImportDefinition
    {
        private Type type;
        public TypeImportDefinition()
        {
        }

        public TypeImportDefinition(Type type)
            : base(DefaultExpression(), string.Empty, ImportCardinality.ZeroOrMore, false, false)
        {
            this.type = type;
        }

        private static Expression<Func<ExportDefinition, bool>> DefaultExpression()
        {
            return e => false;
        }

        public override bool IsConstraintSatisfiedBy(ExportDefinition exportDefinition)
        {
            object value = null;
            if (!exportDefinition.Metadata.TryGetValue("ExportTypeIdentity", out value))
                return false;
            var stringValue = value as string;
            return stringValue != null && stringValue.Equals(type.FullName, StringComparison.Ordinal);
        }
    }
}
