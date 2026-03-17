using KeyManager.Domain.Models;
using KeyManager.Dtos;
using KeyManager.DTOs;

namespace KeyManager.Mappers;

public static class DtoMappers
{
    public static Key ToModel(this KeyDto dto)
    {
        return new Key
        {
            Id = dto.Id,
            KeyIdentifier = dto.KeyIdentifier,
            Brand = dto.Brand,

        };
    }

    public static KeyDto ToDto(this Key key)
    {
        return new KeyDto
        {
            Id = key.Id,
            KeyIdentifier = key.KeyIdentifier,
            Brand = key.Brand,
        };
    }

    public static Resident ToModel(this ResidentDto dto)
    {
        return new Resident
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Pnum = dto.Pnum,
            Email = dto.Email
        };
    }

    public static ResidentDto ToDto(this Resident user)
    {
        return new ResidentDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Pnum = user.Pnum,
            Email = user.Email
        };
    }

    public static Property ToModel(this PropertyDto dto)
    {
        return new Property
        {
            Id = dto.Id,
            LeaseStart = dto.LeaseStart,
            LeaseEnd = dto.LeaseEnd,
            Address = dto.FullAddress,
            Resident = dto.User?.ToModel(),
            Keys = dto.Keys?.Select(k => k.ToModel()).ToList()
        };
    }


}