using MoGYSD.Business.Models.Nissa.Admin;
using System.ComponentModel.DataAnnotations;

namespace MoGYSD.ViewModels.Nissa.Administration;

public class CountryViewModel
{
    /// <summary>
    /// Unique identifier for the Country
    /// </summary>
    public int Id { get; set; }
    /// <summary>
    /// Unique code identifying the Country
    /// </summary>
    [Required(ErrorMessage = "Country code is required")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Code must be between 2 characters")]
    [Display(Name = "Country Code")]
    public string Code { get; set; }
    /// <summary>
    /// Name of the Country
    /// </summary>
    [Required(ErrorMessage = "Country name is required")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 100 characters")]
    [Display(Name = "Country Name")]
    public string Name { get; set; }
    /// <summary>
    /// Population of the Country
    /// </summary>
    [Required(ErrorMessage = "Country population is required")]    /// 
    [Display(Name = "Population")]
    public string Population { get; set; }
    /// <summary>
    /// Indicates whether the Country is currently active
    /// </summary>
    [Display(Name = "Active")]
    public bool Status { get; set; }
    public string CreatedById { get; set; }
    public DateTime CreatedOn { get; set; }
}

public class CountryCodeViewModel
{
    public string Name { get; set; }
    public string Code { get; set; }  // Country code (e.g., "US")
    public string PhoneCode { get; set; }  // Phone prefix (e.g., "+1")
    public string Flag { get; set; }  // Optional: flag emoji or image path
}

public static class CountryCodeDataService
{
    public static List<CountryCodeViewModel> GetCountries()
    {
        return new List<CountryCodeViewModel>
        {
            // Africa (all 54 countries)
            new() { Name = "Algeria", Code = "DZ", PhoneCode = "+213", Flag = "🇩🇿" },
            new() { Name = "Angola", Code = "AO", PhoneCode = "+244", Flag = "🇦🇴" },
            new() { Name = "Benin", Code = "BJ", PhoneCode = "+229", Flag = "🇧🇯" },
            new() { Name = "Botswana", Code = "BW", PhoneCode = "+267", Flag = "🇧🇼" },
            new() { Name = "Burkina Faso", Code = "BF", PhoneCode = "+226", Flag = "🇧🇫" },
            new() { Name = "Burundi", Code = "BI", PhoneCode = "+257", Flag = "🇧🇮" },
            new() { Name = "Cabo Verde", Code = "CV", PhoneCode = "+238", Flag = "🇨🇻" },
            new() { Name = "Cameroon", Code = "CM", PhoneCode = "+237", Flag = "🇨🇲" },
            new() { Name = "Central African Republic", Code = "CF", PhoneCode = "+236", Flag = "🇨🇫" },
            new() { Name = "Chad", Code = "TD", PhoneCode = "+235", Flag = "🇹🇩" },
            new() { Name = "Comoros", Code = "KM", PhoneCode = "+269", Flag = "🇰🇲" },
            new() { Name = "Congo (DRC)", Code = "CD", PhoneCode = "+243", Flag = "🇨🇩" },
            new() { Name = "Congo (Republic)", Code = "CG", PhoneCode = "+242", Flag = "🇨🇬" },
            new() { Name = "Côte d'Ivoire", Code = "CI", PhoneCode = "+225", Flag = "🇨🇮" },
            new() { Name = "Djibouti", Code = "DJ", PhoneCode = "+253", Flag = "🇩🇯" },
            new() { Name = "Egypt", Code = "EG", PhoneCode = "+20", Flag = "🇪🇬" },
            new() { Name = "Equatorial Guinea", Code = "GQ", PhoneCode = "+240", Flag = "🇬🇶" },
            new() { Name = "Eritrea", Code = "ER", PhoneCode = "+291", Flag = "🇪🇷" },
            new() { Name = "Eswatini", Code = "SZ", PhoneCode = "+268", Flag = "🇸🇿" },
            new() { Name = "Ethiopia", Code = "ET", PhoneCode = "+251", Flag = "🇪🇹" },
            new() { Name = "Gabon", Code = "GA", PhoneCode = "+241", Flag = "🇬🇦" },
            new() { Name = "Gambia", Code = "GM", PhoneCode = "+220", Flag = "🇬🇲" },
            new() { Name = "Ghana", Code = "GH", PhoneCode = "+233", Flag = "🇬🇭" },
            new() { Name = "Guinea", Code = "GN", PhoneCode = "+224", Flag = "🇬🇳" },
            new() { Name = "Guinea-Bissau", Code = "GW", PhoneCode = "+245", Flag = "🇬🇼" },
            new() { Name = "Kenya", Code = "KE", PhoneCode = "+254", Flag = "🇰🇪" },
            new() { Name = "Lesotho", Code = "LS", PhoneCode = "+266", Flag = "🇱🇸" },
            new() { Name = "Liberia", Code = "LR", PhoneCode = "+231", Flag = "🇱🇷" },
            new() { Name = "Libya", Code = "LY", PhoneCode = "+218", Flag = "🇱🇾" },
            new() { Name = "Madagascar", Code = "MG", PhoneCode = "+261", Flag = "🇲🇬" },
            new() { Name = "Malawi", Code = "MW", PhoneCode = "+265", Flag = "🇲🇼" },
            new() { Name = "Mali", Code = "ML", PhoneCode = "+223", Flag = "🇲🇱" },
            new() { Name = "Mauritania", Code = "MR", PhoneCode = "+222", Flag = "🇲🇷" },
            new() { Name = "Mauritius", Code = "MU", PhoneCode = "+230", Flag = "🇲🇺" },
            new() { Name = "Morocco", Code = "MA", PhoneCode = "+212", Flag = "🇲🇦" },
            new() { Name = "Mozambique", Code = "MZ", PhoneCode = "+258", Flag = "🇲🇿" },
            new() { Name = "Namibia", Code = "NA", PhoneCode = "+264", Flag = "🇳🇦" },
            new() { Name = "Niger", Code = "NE", PhoneCode = "+227", Flag = "🇳🇪" },
            new() { Name = "Nigeria", Code = "NG", PhoneCode = "+234", Flag = "🇳🇬" },
            new() { Name = "Rwanda", Code = "RW", PhoneCode = "+250", Flag = "🇷🇼" },
            new() { Name = "São Tomé and Príncipe", Code = "ST", PhoneCode = "+239", Flag = "🇸🇹" },
            new() { Name = "Senegal", Code = "SN", PhoneCode = "+221", Flag = "🇸🇳" },
            new() { Name = "Seychelles", Code = "SC", PhoneCode = "+248", Flag = "🇸🇨" },
            new() { Name = "Sierra Leone", Code = "SL", PhoneCode = "+232", Flag = "🇸🇱" },
            new() { Name = "Somalia", Code = "SO", PhoneCode = "+252", Flag = "🇸🇴" },
            new() { Name = "South Africa", Code = "ZA", PhoneCode = "+27", Flag = "🇿🇦" },
            new() { Name = "South Sudan", Code = "SS", PhoneCode = "+211", Flag = "🇸🇸" },
            new() { Name = "Sudan", Code = "SD", PhoneCode = "+249", Flag = "🇸🇩" },
            new() { Name = "Tanzania", Code = "TZ", PhoneCode = "+255", Flag = "🇹🇿" },
            new() { Name = "Togo", Code = "TG", PhoneCode = "+228", Flag = "🇹🇬" },
            new() { Name = "Tunisia", Code = "TN", PhoneCode = "+216", Flag = "🇹🇳" },
            new() { Name = "Uganda", Code = "UG", PhoneCode = "+256", Flag = "🇺🇬" },
            new() { Name = "Zambia", Code = "ZM", PhoneCode = "+260", Flag = "🇿🇲" },
            new() { Name = "Zimbabwe", Code = "ZW", PhoneCode = "+263", Flag = "🇿🇼" },

            // Europe (all countries)
            new() { Name = "Albania", Code = "AL", PhoneCode = "+355", Flag = "🇦🇱" },
            new() { Name = "Andorra", Code = "AD", PhoneCode = "+376", Flag = "🇦🇩" },
            new() { Name = "Armenia", Code = "AM", PhoneCode = "+374", Flag = "🇦🇲" },
            new() { Name = "Austria", Code = "AT", PhoneCode = "+43", Flag = "🇦🇹" },
            new() { Name = "Azerbaijan", Code = "AZ", PhoneCode = "+994", Flag = "🇦🇿" },
            new() { Name = "Belarus", Code = "BY", PhoneCode = "+375", Flag = "🇧🇾" },
            new() { Name = "Belgium", Code = "BE", PhoneCode = "+32", Flag = "🇧🇪" },
            new() { Name = "Bosnia and Herzegovina", Code = "BA", PhoneCode = "+387", Flag = "🇧🇦" },
            new() { Name = "Bulgaria", Code = "BG", PhoneCode = "+359", Flag = "🇧🇬" },
            new() { Name = "Croatia", Code = "HR", PhoneCode = "+385", Flag = "🇭🇷" },
            new() { Name = "Cyprus", Code = "CY", PhoneCode = "+357", Flag = "🇨🇾" },
            new() { Name = "Czech Republic", Code = "CZ", PhoneCode = "+420", Flag = "🇨🇿" },
            new() { Name = "Denmark", Code = "DK", PhoneCode = "+45", Flag = "🇩🇰" },
            new() { Name = "Estonia", Code = "EE", PhoneCode = "+372", Flag = "🇪🇪" },
            new() { Name = "Finland", Code = "FI", PhoneCode = "+358", Flag = "🇫🇮" },
            new() { Name = "France", Code = "FR", PhoneCode = "+33", Flag = "🇫🇷" },
            new() { Name = "Georgia", Code = "GE", PhoneCode = "+995", Flag = "🇬🇪" },
            new() { Name = "Germany", Code = "DE", PhoneCode = "+49", Flag = "🇩🇪" },
            new() { Name = "Greece", Code = "GR", PhoneCode = "+30", Flag = "🇬🇷" },
            new() { Name = "Hungary", Code = "HU", PhoneCode = "+36", Flag = "🇭🇺" },
            new() { Name = "Iceland", Code = "IS", PhoneCode = "+354", Flag = "🇮🇸" },
            new() { Name = "Ireland", Code = "IE", PhoneCode = "+353", Flag = "🇮🇪" },
            new() { Name = "Italy", Code = "IT", PhoneCode = "+39", Flag = "🇮🇹" },
            new() { Name = "Kazakhstan", Code = "KZ", PhoneCode = "+7", Flag = "🇰🇿" },
            new() { Name = "Kosovo", Code = "XK", PhoneCode = "+383", Flag = "🇽🇰" },
            new() { Name = "Latvia", Code = "LV", PhoneCode = "+371", Flag = "🇱🇻" },
            new() { Name = "Liechtenstein", Code = "LI", PhoneCode = "+423", Flag = "🇱🇮" },
            new() { Name = "Lithuania", Code = "LT", PhoneCode = "+370", Flag = "🇱🇹" },
            new() { Name = "Luxembourg", Code = "LU", PhoneCode = "+352", Flag = "🇱🇺" },
            new() { Name = "Malta", Code = "MT", PhoneCode = "+356", Flag = "🇲🇹" },
            new() { Name = "Moldova", Code = "MD", PhoneCode = "+373", Flag = "🇲🇩" },
            new() { Name = "Monaco", Code = "MC", PhoneCode = "+377", Flag = "🇲🇨" },
            new() { Name = "Montenegro", Code = "ME", PhoneCode = "+382", Flag = "🇲🇪" },
            new() { Name = "Netherlands", Code = "NL", PhoneCode = "+31", Flag = "🇳🇱" },
            new() { Name = "North Macedonia", Code = "MK", PhoneCode = "+389", Flag = "🇲🇰" },
            new() { Name = "Norway", Code = "NO", PhoneCode = "+47", Flag = "🇳🇴" },
            new() { Name = "Poland", Code = "PL", PhoneCode = "+48", Flag = "🇵🇱" },
            new() { Name = "Portugal", Code = "PT", PhoneCode = "+351", Flag = "🇵🇹" },
            new() { Name = "Romania", Code = "RO", PhoneCode = "+40", Flag = "🇷🇴" },
            new() { Name = "Russia", Code = "RU", PhoneCode = "+7", Flag = "🇷🇺" },
            new() { Name = "San Marino", Code = "SM", PhoneCode = "+378", Flag = "🇸🇲" },
            new() { Name = "Serbia", Code = "RS", PhoneCode = "+381", Flag = "🇷🇸" },
            new() { Name = "Slovakia", Code = "SK", PhoneCode = "+421", Flag = "🇸🇰" },
            new() { Name = "Slovenia", Code = "SI", PhoneCode = "+386", Flag = "🇸🇮" },
            new() { Name = "Spain", Code = "ES", PhoneCode = "+34", Flag = "🇪🇸" },
            new() { Name = "Sweden", Code = "SE", PhoneCode = "+46", Flag = "🇸🇪" },
            new() { Name = "Switzerland", Code = "CH", PhoneCode = "+41", Flag = "🇨🇭" },
            new() { Name = "Turkey", Code = "TR", PhoneCode = "+90", Flag = "🇹🇷" },
            new() { Name = "Ukraine", Code = "UA", PhoneCode = "+380", Flag = "🇺🇦" },
            new() { Name = "United Kingdom", Code = "GB", PhoneCode = "+44", Flag = "🇬🇧" },
            new() { Name = "Vatican City", Code = "VA", PhoneCode = "+379", Flag = "🇻🇦" },

            // North America
            new() { Name = "United States", Code = "US", PhoneCode = "+1", Flag = "🇺🇸" },
            new() { Name = "Canada", Code = "CA", PhoneCode = "+1", Flag = "🇨🇦" }
        }.OrderBy(c => c.Name).ToList();
    }
}