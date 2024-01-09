using Common.Dtos;
using Common.Models;

namespace WebApi.Services;

public interface IFightService
{
    public FightResult Fight(Character first, Character second);
}