using BuildingBlocks.Core.Response;

namespace Ordering.Domain.PrimitiveErrors;

public static class PrimitiveErrors
{
    public static Error CustomerIdInvalidError => new("ValueNotFound", "داده درخواستی یافت نشد.");
}