using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NoHtml
{
    public static class DependencyResolver
    {
        public static IDependencyResolver Instance { get; private set; }
        
        private static object writeLock = new object();

        public static void SetResolver(IDependencyResolver resolver)
        {
            lock (writeLock)
            {
                Instance = resolver;
            }
        }
    }
}
