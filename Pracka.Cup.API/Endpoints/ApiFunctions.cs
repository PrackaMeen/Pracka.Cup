namespace Pracka.Cup.API.Endpoints
{
    using AutoMapper;
    using Microsoft.Extensions.Configuration;
    using Pracka.Cup.API.Mappers;
    using Pracka.Cup.Database;
    using System;
    using System.Text.RegularExpressions;

    public abstract class ApiFunctions
    {
        public int GetIdFromPathPart(Regex regex, string pathPart, string toReplace)
        {
            var result = -1;

            var pathWithId = regex.Match(pathPart);
            if (pathWithId.Success)
            {
                var stringId = pathWithId.Value
                    .Replace(toReplace, String.Empty)
                    .Replace("/", String.Empty);

                int.TryParse(stringId, out result);
                return result;
            }

            return result;
        }

        protected readonly CupContext _context;
        protected readonly IMapper _mapper;
        public ApiFunctions(IConfiguration configuration = null)
        {
            _context = new CupContextFactory(configuration).CreateDbContext(null);
            _mapper = GlobalMapper.Activate();
        }

        public class ResponseModel<T>
            where T : class
        {
            public ResponseModel(T data, string requestPath = "")
            {
                this.Data = data;
                this.RequestPath = requestPath;
            }
            public T Data { get; set; }
            public string ETag { get; set; }
            public string RequestPath { get; set; }
        }
        public class ResponseModel<T, R> : ResponseModel<T>
            where T : class
            where R : class
        {
            public ResponseModel(T data, string requestPath = "", R requestBody = null)
                : base(data, requestPath)
            {
                this.RequestBody = requestBody;
            }
            public R RequestBody { get; set; }
        }
    }
}
