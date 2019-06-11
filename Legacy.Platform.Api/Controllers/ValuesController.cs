using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Legacy.Platform.Api.Requests.Values;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Legacy.Platform.Api.Controllers
{
    public class ValuesController : BaseController
    {
        private readonly IMediator _mediator;

        public ValuesController(IMediator mediator)
        {
            this._mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpGet("")]
        public async Task<IEnumerable<string>> GetAll(CancellationToken cancellationToken)
        {
            return await this._mediator.Send(new GetAllValuesQuery(), cancellationToken);
        }

        [HttpGet("{index}")]
        public async Task<string> GetByIndex(int index, CancellationToken cancellationToken)
        {
            return await this._mediator.Send(new GetValueByIndexQuery(index), cancellationToken);
        }

        [HttpPost("")]
        public async Task Post([FromBody] CreateValueCommand command, CancellationToken cancellationToken)
        {
            await this._mediator.Send(command, cancellationToken);
        }
    }
}
