using BuildingBlocks.Common.Response;

namespace BuildingBlocks.Core.Common;

public class BaseMessages
{
    public static Message OperationSuccessfulMessage => new("عملیات با موفقیت انجام شد.");
    public static Message SomeValuesAreInvalid => new("برخی از اطلاعات وارد شده معتبر نمیباشند.");
    public static Message OperationFailedMessage => new("عملیات با خطا مواجه شد.");
    public static Message InvalidArgumentException => new("پارامتر وارد شده معتبر نمیباشد.");
}