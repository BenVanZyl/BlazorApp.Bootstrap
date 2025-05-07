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
    public class ManageActivityCommand(ActivityDto activity) : IRequest<CommandResults>
    {
        public ActivityDto Data { get; set; } = activity;
        public ManageActions? Action { get; set; } = ManageActions.Save;
        public ManageActivityCommand Save() { Action = ManageActions.Save; return this; }
        public ManageActivityCommand Delete() { Action = ManageActions.Delete; return this; }
    }

    public class SaveActivityCommandHandler(DataContext dataContext, QueryRunner queries) : IRequestHandler<ManageActivityCommand, CommandResults>
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly QueryRunner _queries = queries;

        public async Task<CommandResults> Handle(ManageActivityCommand request, CancellationToken cancellationToken)
        {
            CommandResults results = new();
            try
            {
                if (request.Data == null)
                    throw new NullReferenceException("Action failed. Record does not exist.");

                var value = await _queries.GetById<Activity>(request.Data.Id);

                switch (request.Action)
                {
                    case ManageActions.Save:
                        if (request.Data.Id == -1)
                            value = await Activity.Create(request.Data);
                        else
                            if (value == null)
                            throw new ArgumentNullException($"Activity not found. [{request.Data.Id}]");

                        value.Save(request.Data);
                        break;

                    case ManageActions.Delete:
                        if (value != null)
                            _dataContext.Remove<Activity>(value);
                        else
                            throw new NullReferenceException("Delete failed. Record does not exist.");
                        break;

                    default:
                        throw new NullReferenceException("Save or Delete Action not specified.");
                }

                await _dataContext.SaveChangesAsync();

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
