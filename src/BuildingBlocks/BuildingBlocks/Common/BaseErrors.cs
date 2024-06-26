using BuildingBlocks.Common.Response;

namespace BuildingBlocks.Common;

public class BaseErrors
{
    public static Error InternalServerError => new("ApplicationFailure", "An internal server error has occured");
    //TODO  -- Learn about it
    public static Error IdentityConflictError => new("IdentityConflict", "Identity values do not match each other");
}