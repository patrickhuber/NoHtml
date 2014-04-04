﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace NoHtml.Web
{
    public class WebFileSystem : IFileSystem
    {
        private IFileSystem internalFileSystem;
        private IHttpContextFactory httpContextFactory;

        public WebFileSystem(IFileSystem fileSystem, IHttpContextFactory httpContextFactory)
        {            
            this.internalFileSystem = fileSystem;
            this.httpContextFactory = httpContextFactory;
        }

        public WebFileSystem()
            : this(DependencyResolver.Instance.GetService<IFileSystem>("fileSystem"), 
            DependencyResolver.Instance.GetService<IHttpContextFactory>())
        { 
        }

        public System.IO.Stream OpenRead(string path)
        {
            var serverPath = GetServerPath(path);
            return internalFileSystem.OpenRead(serverPath);
        }

        public bool DirectoryExists(string path)
        {
            var serverPath = GetServerPath(path);
            return internalFileSystem.DirectoryExists(serverPath);
        }

        public bool FileExists(string path)
        {
            var serverPath = GetServerPath(path);
            return internalFileSystem.FileExists(serverPath);
        }
        
        private string GetServerPath(string path)
        {
            var serverPath = httpContextFactory.CreateContext().Server.MapPath(path);
            return serverPath;
        }
    }
}
