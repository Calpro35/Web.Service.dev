namespace Web.Service.Cap7.Requests;

public sealed record NewSectorRequest(
    string Name,
    string? Description,
    double ConsumptionLimit
);
