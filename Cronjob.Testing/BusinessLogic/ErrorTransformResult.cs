namespace Cronjob.Testing.BusinessLogic;

public record ErrorTransformResult(Guid Id, string Message) : ITransformResult;