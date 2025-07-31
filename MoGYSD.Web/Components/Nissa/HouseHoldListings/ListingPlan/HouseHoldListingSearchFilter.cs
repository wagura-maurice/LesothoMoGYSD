
namespace MoGYSD.Web.Components.HouseHoldListings;
/// <summary>
/// Represents filtering criteria for searching household listings with optional parameters.
/// All filter properties are nullable/optional to support flexible searching.
/// </summary>
public class HouseHoldListingSearchFilter
{
    public string Name { get; set; } = string.Empty;
    /// <summary>
    /// Filters listings by specific registration activity ID
    /// </summary>
    public int? DistrictId { get; set; }
    public int? DistrictPlanNameId { get; set; }

    /// <summary>
    /// Filters listings by current status ID
    /// </summary>
    public int? StatusId { get; set; }

    /// <summary>
    /// Filters listings with projected start date on or after this date
    /// </summary>
    public DateTime? ProjectedStartDate { get; set; }

    /// <summary>
    /// Filters listings with projected end date on or before this date
    /// </summary>
    public DateTime? ProjectedEndDate { get; set; }

    /// <summary>
    /// Filters listings with any activity (start/end/actual dates) occurring on or after this date
    /// </summary>
    public DateTime? ActivityDateFrom { get; set; }

    /// <summary>
    /// Filters listings with any activity (start/end/actual dates) occurring on or before this date
    /// </summary>
    public DateTime? ActivityDateTo { get; set; }

    /// <summary>
    /// Filters listings by specific Community Council/location ID
    /// </summary>
    public int? CommunityCouncilId { get; set; }

    /// <summary>
    /// Filters listings by partial or exact household head name match
    /// </summary>
    public string HHListingActivityName { get; set; } = string.Empty;

}
