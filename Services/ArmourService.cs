using Armours;
using Monster_Builder;
using Monster_Builder_Web_API.Models.DTOs;
using Monster_Builder_Web_API.Models.Exceptions;
using Monster_Builder_Web_API.Repositories;

namespace Monster_Builder_Web_API.Services;

public class ArmourService : IArmourService
{
    private readonly IArmourRepository _armourRepository;

    public ArmourService(IArmourRepository armourRepository)
    {
        _armourRepository = armourRepository;
    }

    public Armour GetArmourByName(string name)
    {
        //TODO add any security checks or validation you want.
        return _armourRepository.GetArmour(name);
    }

    public IEnumerable<Armour> GetAllArmour()
    {
        return _armourRepository.GetAllArmour();
    }

    public bool AddNewArmour(ArmourDTO newArmour)
    {
        var armour = new Armour(newArmour);
        return _armourRepository.CreateArmour(armour);
    }
}
