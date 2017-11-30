using System;
using System.Threading.Tasks;
using aspnetcoregraphql.Models;
using GraphQL;
using GraphQL.Instrumentation;
using GraphQL.Types;
using GraphQL.Validation.Complexity;
using Microsoft.AspNetCore.Mvc;

namespace aspnetcoregraphql.Controllers
{
    [Route("graphql")]
    public class GraphQLController : Controller
    {
        private readonly IDocumentExecuter _executer;
        private readonly ISchema _schema;

        public GraphQLController(IDocumentExecuter executer, ISchema schema)
        {
            _executer = executer;
            _schema = schema;
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]GraphQLQuery query)
        {
            if (query == null) { throw new ArgumentNullException(nameof(query)); }

            try
            {
                var result = await _executer.ExecuteAsync(_ =>
                {
                    _.Schema = _schema;
                    _.Query = query.Query;
                    _.OperationName = query.OperationName;

                    _.ComplexityConfiguration = new ComplexityConfiguration { MaxDepth = 15 };
                    _.FieldMiddleware.Use<InstrumentFieldsMiddleware>();
                }).ConfigureAwait(false);

                if (result.Errors?.Count > 0)
                    return BadRequest(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}