namespace Web.Service.Cap7.Requests;

public sealed record NewEquipmentRequest(
    string Name,
    double ConsumptionPerHour,
    int MaxActiveHours,
    DateTime LastActivedAt,
    int SectorId
);
