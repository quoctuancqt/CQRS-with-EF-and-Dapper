﻿using Dapper;
using System.Collections.Generic;

namespace CQRS
{
    public class Session : ISession
    {
        private readonly IDapperContext _context;

        public Session()
        {
            _context = new DapperContext();
        }

        public Session(IDapperContext context)
        {
            _context = context;
        }

        public virtual IEnumerable<T> Query<T>(string query, object param)
        {
            return _context.Transaction(transaction =>
            {
                var result = _context.Connection.Query<T>(query, param, transaction);
                return result;
            });
        }
    }
}