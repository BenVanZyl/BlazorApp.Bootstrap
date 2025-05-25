using BlazorApp.Bootstrap.Business.Queries.Regions;
using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Business.Commands
{
    public class ManageRegionCommand(RegionDto data) : IRequest<CommandResults>
    {
        public RegionDto Data { get; set; } = data;
        public ManageActions? Action { get; set; } = ManageActions.Update;
        public ManageRegionCommand Update() { Action = ManageActions.Update; return this; }
        public ManageRegionCommand Delete() { Action = ManageActions.Delete; return this; }
    }

    public class ManageRegionCommandHandler(QueryRunner queries) : IRequestHandler<ManageRegionCommand, CommandResults>
    {
        private readonly QueryRunner _queries = queries;

        public async Task<CommandResults> Handle(ManageRegionCommand request, CancellationToken cancellationToken)
        {
            //NOTE: This handler is where validations and business logic is applied before and after any data changes are made.

            CommandResults results = new();
            try
            {
                if (request.Data == null)
                    throw new NullReferenceException("Action failed. Record does not exist.");

                Region? value = null;
                switch (request.Action)
                {
                    case ManageActions.Add:
                        value = Region.Create(request.Data);
                        await _queries.Add(value);
                        break;

                    case ManageActions.Update:
                        await _queries.Update(new ManageRegionQuery(request.Data));
                        break;

                    case ManageActions.Delete:
                        if (value != null)
                            await _queries.Delete(new ManageRegionQuery(request.Data));
                        else
                            throw new NullReferenceException("Delete failed. Record does not exist.");
                        break;

                    default:
                        throw new NullReferenceException("Invalid action specified.");
                }

                results.Id = value != null ? value.Id : -1;

            }
            catch (Exception ex)
            {
                //Log.Error(ex, "SaveActivityCommandHandler.Handle() failed");
                results.AddError(ex);
            }
            return results;
        }
    }
}
