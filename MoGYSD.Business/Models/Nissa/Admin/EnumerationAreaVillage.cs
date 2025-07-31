namespace MoGYSD.Business.Models.Nissa.Admin;

public class EnumerationAreaVillage
{
    public int EnumerationAreaId { get; set; }
    public EnumerationArea EnumerationArea { get; set; }

    public int VillageId { get; set; }
    public Village Village { get; set; }
}
