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
            KeyIdentifier = dto.KeyIdentifier
        };
    }

    public static KeyDto ToDto(this Key key)
    {
        return new KeyDto
        {
            Id = key.Id,
            KeyIdentifier = key.KeyIdentifier
        };
    }

    public static User ToModel(this UserDto dto)
    {
        return new User
        {
            Id = dto.Id,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Pnum = dto.Pnum,
            Email = dto.Email
        };
    }

    public static UserDto ToDto(this User user)
    {
        return new UserDto
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            Pnum = user.Pnum,
            Email = user.Email
        };
    }

    public static Address ToModel(this AddressDto dto)
    {
        return new Address
        {
            Id = dto.Id,
            LeaseStart = dto.LeaseStart,
            LeaseEnd = dto.LeaseEnd,
            FullAddress = dto.FullAddress,
            User = dto.User != null ? dto.User.ToModel() : null,
            Key = dto.Key != null ? dto.Key.ToModel() : null
        };
    }


}