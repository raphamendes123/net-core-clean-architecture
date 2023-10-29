using PearlCore.ADO.NET; 

namespace Infrastructure.Common.Api
{
    public class Response<T> : ExecutionResult<T> where T : new()
    {

    }
}
