using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorApp.Bootstrap.Business
{
    public class CommandResults
    {
        public List<Exception>? Errors { get; set; }

        public void AddError(string message)
        {
            AddError(new Exception(message));
        }
        public void AddError(Exception ex)
        {
            Errors ??= [];
            Errors.Add(ex);
        }

        public bool HasErrors => Errors != null;

        public object? Id { get; set; }

        public long IdAsLong
        {
            get
            {
                try
                {
                    if (Id == null)
                        return 0;

                    if (long.TryParse(Id.ToString(), out long value))
                        return value;
                    else
                        throw new InvalidCastException("Id value is not a long.");
                }
                catch (Exception)
                {
                    throw new InvalidCastException("Id value is not a long.");
                }

            }
        }

    }
}


