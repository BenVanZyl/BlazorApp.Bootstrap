using BlazorApp.Bootstrap.Business.Queries.Regions;
using BlazorApp.Bootstrap.Data.Domain;
using BlazorApp.Bootstrap.Data.Dtos;
using BlazorApp.Bootstrap.Data.Infrastructure;
using MediatR;

namespace BlazorApp.Bootstrap.Business.Commands
{
    public class ManageRegionCommand(RegionDto data) : IRequest<CommandResults>
    {
        public RegionDto Data { get; set; } = data;
        public ManageActions? Action { get; set; } = ManageActions.Update;

        public ManageRegionCommand Create() { Action = ManageActions.Add; return this; }
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

                Region? region = null;
                switch (request.Action)
                {
                    case ManageActions.Add:
                        region = await _queries.Add<Region>(new Region(request.Data.RegionName));
                        request.Data.Id = region.Id;
                        request.Data = await _queries.Get<Region, RegionDto>(new RegionQueries(request.Data));
                        break;

                    case ManageActions.Update:
                        await _queries.Update<Region>(new RegionQueries(request.Data));
                        break;

                    case ManageActions.Delete:
                            await _queries.Delete(new RegionQueries(request.Data));
                        break;

                    default:
                        throw new NullReferenceException("Invalid action specified.");
                }

                results.Data = request.Data;
                results.Id = request.Data != null ? request.Data.Id : -1;

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
