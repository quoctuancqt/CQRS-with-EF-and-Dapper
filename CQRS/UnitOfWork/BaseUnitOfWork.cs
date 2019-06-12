namespace CQRS.UnitOfWork
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.Security.Claims;

    public abstract class BaseUnitOfWork<TContext> : IBaseUnitOfWork
    {
        protected HttpContext _httpContext;

        protected TContext _context { get; set; }

        public string UserId
        {
            get
            {
                if (_httpContext == null) return string.Empty;

                return _httpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            }
        }

        public string UserName
        {
            get
            {
                if (_httpContext.User == null) return string.Empty;

                return _httpContext.User.Identity.Name;
            }
        }

        public string Email
        {
            get
            {
                if (_httpContext.User == null) return string.Empty;

                return _httpContext.User.FindFirstValue("Email");
            }
        }

        protected BaseUnitOfWork(HttpContext httpContext, TContext context)
        {
            _httpContext = httpContext;

            _context = context;

            InitializeRepository();
        }

        protected abstract void InitializeRepository();

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected abstract void Dispose(bool disposing);
    }
}
