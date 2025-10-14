using Web.Service.Cap7.Dtos;
using Web.Service.Cap7.Models;
using Web.Service.Cap7.Requests;
using Web.Service.Cap7.UseCases.NewEquipmentUseCase.Boundaries;

namespace Web.Service.Cap7.Mappers;

public static class EquipmentMapper
{
    public static Equipment MapToModel(this NewEquipmentInput input)
    {
        return new Equipment(
            input.Name,
            input.ConsumptionPerHour,
            input.MaxActiveHours,
            input.LastActivedAt,
            input.SectorId
        );
    }

    public static NewEquipmentInput MapToInput(this NewEquipmentRequest request, int userId)
    {
        return new NewEquipmentInput(
            request.Name,
            request.ConsumptionPerHour,
            request.MaxActiveHours,
            request.LastActivedAt,
            request.SectorId,
            userId
        );
    }

    public static EquipmentsListDto MapToDto(this Equipment equipment)
    {
        return new EquipmentsListDto(
            equipment.Id,
            equipment.Name,
            equipment.IsActive
        );
    }
}
