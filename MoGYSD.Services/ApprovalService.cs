using MoGYSD.Business.Models.Nissa.Admin;

namespace MoGYSD.Services;
public class ApprovalService : IApprovalService
{
    private readonly IGenericService _genericService;
    private readonly UserProfileService _userService;

    public ApprovalService(IGenericService genericService, UserProfileService userService)
    {
        _genericService = genericService;
        _userService = userService;
    }

    public async Task CreateApprovalAsync(int statusId, string transId, string table, string reason = null)
    {
        var approval = new Approval
        {
            UserId = _userService.UserId,
            StatusId = statusId,
            TransactionId = transId,
            Reason = reason,
            TransactionType = table,
            CreatedOn = DateTime.Now
        };

        await _genericService.Add(approval);
    }
}

public interface IApprovalService
{
    Task CreateApprovalAsync(int statusId, string transId, string table, string reason = null);
}