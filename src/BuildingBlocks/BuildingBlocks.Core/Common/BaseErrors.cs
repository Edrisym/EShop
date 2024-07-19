using BuildingBlocks.Common.Response;
using BuildingBlocks.Core.Response;

namespace BuildingBlocks.Core.Common;

public class BaseErrors
{
    public static Error InternalServerError => new("ApplicationFailure", "An internal server error has occured");
    //TODO  -- Learn about it
    public static Error IdentityConflictError => new("IdentityConflict", "Identity values do not match each other");
}