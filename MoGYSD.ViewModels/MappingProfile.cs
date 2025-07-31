using AutoMapper;
using MoGYSD.Business.Models.Missa.EligibilityTests;
using MoGYSD.Business.Models.Missa.Enrolments;

//using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Missa.Validation;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using MoGYSD.Business.Models.Nissa.HouseHoldListings;
using MoGYSD.Business.Models.Nissa.MasterRegistrations;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.ViewModels.Missa.Enrolments;
using MoGYSD.Business.ViewModels.Missa.Setups;
using MoGYSD.Business.Views.HouseHoldListings;
using MoGYSD.Business.Views.HouseHoldListings;
using MoGYSD.Business.Views.Missa.Programmes;
using MoGYSD.Business.Views.Missa.Setups;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Business.Views.Nissa.Districtregistrations;
using MoGYSD.Business.Views.Nissa.HHEnumerations;
using MoGYSD.Business.Views.Nissa.MasterRegistrations;
using MoGYSD.ViewModels.Missa.Eligibility;
using MoGYSD.ViewModels.Missa.Programmes;
using MoGYSD.ViewModels.Missa.Setups;
using MoGYSD.ViewModels.Nissa.Administration;
using MoGYSD.ViewModels.Nissa.DistrictRegistrations;
using MoGYSD.ViewModels.Nissa.HouseholdEnumerations;
using MoGYSD.ViewModels.Nissa.HouseHoldListings;
using MoGYSD.ViewModels.Nissa.MasterRegistrations;
using MoGYSD.ViewModels.Nissa.Nissa.MasterRegistrations;
using MoGYSD.ViewModels.Nissa.Security.UserViewModels;


namespace MoGYSD.ViewModels;
/// <summary>
/// AutoMapper configuration profile that defines object-to-object mappings
/// for the application. Inherits from AutoMapper's Profile base class.
/// </summary>
public class MappingProfile : Profile
{
    // Mappings will be configured in the constructor
    public MappingProfile()
    {
        CreateMap<ApplicationUser, RegisterUserViewModel>().ReverseMap();
        CreateMap<UserSummaryView, RegisterUserViewModel>().ForMember(dest => dest.Documents, opt => opt.Ignore())
            .ForMember(dest => dest.PhotoDocuments, opt => opt.Ignore()).ReverseMap();
        CreateMap<Country, CountryViewModel>().ReverseMap();
        CreateMap<District, DistrictViewModel>().ReverseMap();
        CreateMap<Constituency, ConstituencyViewModel>().ReverseMap();
        CreateMap<ConstituencyView, ConstituencyViewModel>().ReverseMap();
        CreateMap<CommunityCouncil, CommunityCouncilViewModel>().ReverseMap();
        CreateMap<CommunityCouncilView, CommunityCouncilViewModel>().ReverseMap();
        CreateMap<Village, VillageViewModel>().ReverseMap();
        CreateMap<VillageView, VillageViewModel>().ReverseMap();
        CreateMap<SystemCodeDetail, SystemCodeDetailViewModel>().ReverseMap();
        CreateMap<SystemCodeDetailsView, SystemCodeDetailViewModel>().ReverseMap();
        CreateMap<DistrictCensusHHData, DistrictCensusHHDataViewModel>().ReverseMap();
        CreateMap<DistrictCensusHHDataView, DistrictCensusHHDataViewModel>().ReverseMap();


        CreateMap<MasterRegistration, MasterRegistrationViewModel>().ReverseMap();
        CreateMap<RegistrationDistrict, RegistrationDistrictViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<RegistrationDistrictView, RegistrationDistrictViewModel>().ReverseMap();
        CreateMap<RegistrationDistrictCC, RegistrationDistrictCCViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<RegistrationDistrictCCView, RegistrationDistrictCCViewModel>().ReverseMap();

        CreateMap<RegistrationCentre, RegistrationCentreViewModel>().ReverseMap();
        CreateMap<RegistrationCentreViewModel, RegistrationCentreView>().ReverseMap();
        CreateMap<Enumerator, EnumeratorView>().ReverseMap();

        CreateMap<PartnerView, PartnerViewModel>().ReverseMap();
        CreateMap<Partner, PartnerViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<ContactPersonView, ContactPersonViewModel>().ReverseMap();
        CreateMap<ContactPerson, ContactPersonViewModel>().ReverseMap();

        CreateMap<CCsRegistered, CCsRegisteredViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<DistrictRegistrationPlan, DistrictRegistrationPlanViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<CCRegistrationActivity, CCRegistrationActivityViewModel>().ForMember(dest => dest.Id, opt => opt.Ignore()).ReverseMap();
        CreateMap<CCRegistrationActivityView, CCRegistrationActivityViewModel>().ReverseMap();
        CreateMap<CCsRegisteredView, CCsRegisteredViewModel>().ReverseMap();
        CreateMap<DistrictRegistrationPlanView, DistrictRegistrationPlanViewModel>().ReverseMap();

        CreateMap<HHListingPlan, HHListingPlanViewModel>().ReverseMap();
        CreateMap<HHListingPlan, HHListingPlanView>().ReverseMap();
        CreateMap<HHListingPlanView, HHListingPlanViewModel>().ReverseMap();

        CreateMap<CCHouseHoldListingArea, CCHouseHoldListingAreaViewModel>().ReverseMap();
        CreateMap<CCHouseHoldListingAreaView, CCHouseHoldListingAreaViewModel>().ReverseMap();

        CreateMap<HHListing, HHListingView>().ReverseMap();

        CreateMap<HHEnumerationPlan, HHEnumerationPlanViewModel>().ReverseMap();
        CreateMap<HHEnumerationPlanView, HHEnumerationPlanViewModel>().ReverseMap();




        CreateMap<CbcActivity, CbcActivitiesViewModel>().ReverseMap();
        CreateMap<CbcActivitiesView, CbcActivitiesViewModel>().ReverseMap();

   
        // **** MISSA ****

        CreateMap<ProgrammeViewModel, Programmes>()
            .ForMember(dest => dest.AssistanceUnit, opt => opt.Ignore())
            .ForMember(dest => dest.ProgramType, opt => opt.Ignore())
            .ForMember(dest => dest.ProofOfLifeSpanValue, opt => opt.Ignore())
            .ForMember(dest => dest.PaymentFrequency, opt => opt.Ignore())
            .ForMember(dest => dest.PaymentModesAllowed, opt => opt.Ignore())
            .ForMember(dest => dest.EligibilityCriteria, opt => opt.Ignore()) 
            .ForMember(dest => dest.TopUps, opt => opt.Ignore()) 
            .ForMember(dest => dest.BenefitRule, opt => opt.Ignore()) 
            .ForMember(dest => dest.ProgramTypeId, opt => opt.MapFrom(src => src.ProgramTypeId))
            .ForMember(dest => dest.ProxiesAllowed, opt => opt.MapFrom(src => src.ProxiesAllowed))
            .ForMember(dest => dest.ProofOfLifeSpanId, opt => opt.MapFrom(src => src.ProofOfLifeSpanId))
            .ForMember(dest => dest.PaymentFrequencyId, opt => opt.MapFrom(src => src.PaymentFrequencyId))
            .ForMember(dest => dest.ColourScheme, opt => opt.MapFrom(src => src.ColourScheme))
            .ForMember(dest => dest.OVCBConfigurations, opt => opt.MapFrom(src => src.OVCBConfigurations));

        CreateMap<Programmes, ProgrammeViewModel>()
            .ForMember(dest => dest.ColourScheme, opt => opt.MapFrom(src => src.ColourScheme))          
            .ForMember(dest => dest.EligibilityCriteria, opt => opt.MapFrom(src => src.EligibilityCriteria))
            .ForMember(dest => dest.TopUps, opt => opt.MapFrom(src => src.TopUps))
            .ForMember(dest => dest.BenefitRule, opt => opt.MapFrom(src => src.BenefitRule))
             .ForMember(dest => dest.OVCBConfigurations, opt => opt.Ignore()); ;


        // --- CORRECTED MAPPINGS FOR ELIGIBILITY CRITERIA ---
        // --- MAPPING FROM ENTITY TO VIEWMODEL ---

        CreateMap<EligibilityCriteria, EligibilityCriteriaViewModel>()
            // Location (Districts)
            .ForMember(dest => dest.SelectedLocationIds, opt => opt.MapFrom(src =>
                src.EligibilityCriteriaLocations
                    .Select(l => l.DistrictId)
                    .ToList()))

            // Other Programmes
            .ForMember(dest => dest.SelectedOtherProgrammeIds, opt => opt.MapFrom(src =>
                src.EnrolledInOtherProgrammes
                    .Select(p => p.ProgrammeId)
                    .ToList()))

            // Vulnerability Types
            .ForMember(dest => dest.SelectedVulnerabilityTypeIds, opt => opt.MapFrom(src =>
                src.EligibilityCriteriaVulnerabilityTypes
                    .Select(x => x.VulnerabilityTypeId)
                    .ToList()))

            // Poverty Statuses
            .ForMember(dest => dest.SelectedPovertyStatusIds, opt => opt.MapFrom(src =>
                src.EligibilityCriteriaPovertyStatuses
                    .Select(x => x.PovertyStatusId)
                    .ToList()))

            // Community-Based Categorisations
            .ForMember(dest => dest.SelectedCBCIds, opt => opt.MapFrom(src =>
                src.EligibilityCriteriaCBCs
                    .Select(x => x.CBCId)
                    .ToList()));


        // --- MAPPING FROM VIEWMODEL TO ENTITY ---

        CreateMap<EligibilityCriteriaViewModel, EligibilityCriteria>()
            // Ignore navigation collections — handled manually in service layer
            .ForMember(dest => dest.EligibilityCriteriaLocations, opt => opt.Ignore())
            .ForMember(dest => dest.EnrolledInOtherProgrammes, opt => opt.Ignore())
            .ForMember(dest => dest.EligibilityCriteriaVulnerabilityTypes, opt => opt.Ignore())
            .ForMember(dest => dest.EligibilityCriteriaPovertyStatuses, opt => opt.Ignore())
            .ForMember(dest => dest.EligibilityCriteriaCBCs, opt => opt.Ignore())

            // Ignore navigation properties managed by EF Core
            .ForMember(dest => dest.Programme, opt => opt.Ignore())
            .ForMember(dest => dest.AssistanceUnit, opt => opt.Ignore())           
            .ForMember(dest => dest.CommunityValidationStatus, opt => opt.Ignore());


        // --- MAPPINGS FOR TOPUP ---
        CreateMap<TopUpViewModel, TopUps>().ForMember(dest => dest.Programme, opt => opt.Ignore()).ForMember(dest => dest.ProgrammeId, opt => opt.Ignore());
        CreateMap<TopUps, TopUpViewModel>();

        // --- MAPPINGS FOR BENEFIT RULE ---
        CreateMap<BenefitRuleViewModel, BenefitRule>().ForMember(dest => dest.Programme, opt => opt.Ignore()).ForMember(dest => dest.ProgrammeId, opt => opt.Ignore());
        CreateMap<BenefitRule, BenefitRuleViewModel>();


        // ValidationList
        CreateMap<ValidationList, ValidationListViewModel>()            
            .ForMember(dest => dest.CommunityCouncilName, opt => opt.MapFrom(src => src.CommunityCouncil.CommunityCouncilName));            
        CreateMap<ValidationListViewModel, ValidationList>();
        CreateMap<ValidationList, ValidationListView>()          
            .ForMember(dest => dest.CommunityCouncilName, opt => opt.MapFrom(src => src.CommunityCouncil.CommunityCouncilName));          
        CreateMap<ValidationListView, ValidationListViewModel>().ReverseMap();

        // ValidationDetail
        CreateMap<ValidationDetail, ValidationDetailViewModel>()
            .ForMember(dest => dest.HouseholdMemberName, opt => opt.MapFrom(src => src.HouseholdMember.Household))
            .ForMember(dest => dest.ValidationStatusName, opt => opt.MapFrom(src => src.ValidationStatus.Name));
        CreateMap<ValidationDetailViewModel, ValidationDetail>();      

        CreateMap<PaymentFrequencies, PaymentFrequencyViewModels>()
            .ForMember(dest => dest.FrequencyName, opt => opt.MapFrom(src => src.Frequency.Description))
            .ReverseMap();
        CreateMap<EligibilityTestViewModel, EligibilityTests>()       
         .ForMember(dest => dest.Id, opt => opt.Ignore())        
         .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => DateTime.UtcNow));
        CreateMap<EligibilityTests, EligibilityTestViewModel>().ReverseMap();

        CreateMap<FinancialYear, FinancialYearViewModel>().ReverseMap();
        CreateMap<Bank, BankViewModel>().ReverseMap();
        CreateMap<GradeViewModel, Grade>()
    .ForMember(dest => dest.Facilities, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedById, opt => opt.Ignore())
    .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
    .ForMember(dest => dest.ModifiedById, opt => opt.Ignore())
    .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());
        CreateMap<Grade, GradeViewModel>();

        CreateMap<FacilityType, FacilityTypeViewModel>().ReverseMap();

        CreateMap<Facility, FacilityViewModel>();
        CreateMap<FacilityViewModel, Facility>()
            .ForMember(dest => dest.Bank, opt => opt.Ignore())
            .ForMember(dest => dest.FacilityType, opt => opt.Ignore())
            .ForMember(dest => dest.Category, opt => opt.Ignore())
            .ForMember(dest => dest.Grades, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());
        CreateMap<OVCBConfiguration, OVCBConfigurationFormViewModel>();

        CreateMap<OVCBConfigurationFormViewModel, OVCBConfiguration>()
            .ForMember(dest => dest.Programme, opt => opt.Ignore())
            .ForMember(dest => dest.FacilityType, opt => opt.Ignore())
            .ForMember(dest => dest.Grade, opt => opt.Ignore())
            .ForMember(dest => dest.FeeType, opt => opt.Ignore())
            .ForMember(dest => dest.FinancialYear, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore());

        CreateMap<ArrearsConfiguration, ArrearsConfigurationViewModel>();

        CreateMap<ArrearsConfigurationViewModel, ArrearsConfiguration>()
            .ForMember(dest => dest.Programme, opt => opt.Ignore());
        CreateMap<EnrolmentEvent, EnrolmentEventViewModel>()
                  .ForMember(dest => dest.EnrolmentEventId, opt => opt.MapFrom(src => src.Id))
                  .ForMember(dest => dest.EnrolmentEventName, opt => opt.MapFrom(src => src.Name))
                  .ForMember(dest => dest.ProgrammeName, opt => opt.MapFrom(src => src.Programme.Name))
                  .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District.Name))
                  .ForMember(dest => dest.CommunityCouncilName, opt => opt.MapFrom(src => src.CommunityCouncil.CommunityCouncilName))
                  .ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Village.Name))
                  .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy.Id))
                  .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy.UserName))
                  .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy.Id))
                  .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy.UserName));

        // Reverse mapping: use this when updating EnrolmentEvent from ViewModel
        CreateMap<EnrolmentEventViewModel, EnrolmentEvent>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentEventId))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.EnrolmentEventName))
            .ForMember(dest => dest.Programme, opt => opt.Ignore())
            .ForMember(dest => dest.District, opt => opt.Ignore())
            .ForMember(dest => dest.CommunityCouncil, opt => opt.Ignore())
            .ForMember(dest => dest.Village, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        CreateMap<EnrolmentEventDetail, EnrolmentEventDetailViewModel>()
            .ForMember(dest => dest.EnrolmentEventDetailId, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.EnrolmentEventName, opt => opt.MapFrom(src => src.EnrolmentEvent.Name))
            .ForMember(dest => dest.HouseholdMemberFullName, opt => opt.MapFrom(src =>
                src.HouseholdMember != null ? $"{src.HouseholdMember.FirstName} {src.HouseholdMember.Surname}" : null))
            .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
            .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
            .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
            .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        // Optional reverse mapping: ViewModel -> Entity
        CreateMap<EnrolmentEventDetailViewModel, EnrolmentEventDetail>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentEventDetailId))
            .ForMember(dest => dest.EnrolmentEvent, opt => opt.Ignore())
            .ForMember(dest => dest.HouseholdMember, opt => opt.Ignore())
            .ForMember(dest => dest.Household, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
            .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
            .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        //    CreateMap<EnrolmentSchedule, EnrolmentScheduleViewModel>()
        //          .ForMember(dest => dest.EnrolmentScheduleId, opt => opt.MapFrom(src => src.Id))
        //          .ForMember(dest => dest.EnrolmentEventName, opt => opt.MapFrom(src => src.EnrolmentEvent != null ? src.EnrolmentEvent.Name : null))
        //          .ForMember(dest => dest.DistrictName, opt => opt.MapFrom(src => src.District != null ? src.District.Name : null))
        //          .ForMember(dest => dest.CommunityCouncilName, opt => opt.MapFrom(src => src.CommunityCouncil != null ? src.CommunityCouncil.CommunityCouncilName : null))
        //          .ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null))
        //          .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //          .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //          .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //          .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //    CreateMap<EnrolmentScheduleViewModel, EnrolmentSchedule>()
        //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentScheduleId))
        //        .ForMember(dest => dest.EnrolmentEventId, opt => opt.MapFrom(src => src.EnrolmentEventId))
        //        .ForMember(dest => dest.DistrictId, opt => opt.MapFrom(src => src.DistrictId))
        //        .ForMember(dest => dest.CommunityCouncilId, opt => opt.MapFrom(src => src.CommunityCouncilId))
        //        .ForMember(dest => dest.VillageId, opt => opt.MapFrom(src => src.VillageId))
        //        .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
        //        .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
        //        .ForMember(dest => dest.Venue, opt => opt.MapFrom(src => src.Venue))
        //        .ForMember(dest => dest.EnrolmentEvent, opt => opt.Ignore())
        //        .ForMember(dest => dest.District, opt => opt.Ignore())
        //        .ForMember(dest => dest.CommunityCouncil, opt => opt.Ignore())
        //        .ForMember(dest => dest.Village, opt => opt.Ignore())
        //        .ForMember(dest => dest.EnrolmentScheduleDetails, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        //    CreateMap<EnrolmentScheduleDetail, EnrolmentScheduleDetailViewModel>()
        //       .ForMember(dest => dest.EnrolmentScheduleDetailId, opt => opt.MapFrom(src => src.Id))
        //       .ForMember(dest => dest.EnrolmentScheduleVenue, opt => opt.MapFrom(src => src.EnrolmentSchedule != null ? src.EnrolmentSchedule.Venue : null))
        //       .ForMember(dest => dest.EnrolmentEventName, opt => opt.MapFrom(src => src.EnrolmentEvent != null ? src.EnrolmentEvent.Name : null))
        //       .ForMember(dest => dest.VillageName, opt => opt.MapFrom(src => src.Village != null ? src.Village.Name : null))
        //       .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //       .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //       .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //       .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //    CreateMap<EnrolmentScheduleDetailViewModel, EnrolmentScheduleDetail>()
        //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentScheduleDetailId))
        //        .ForMember(dest => dest.EnrolmentScheduleId, opt => opt.MapFrom(src => src.EnrolmentScheduleId))
        //        .ForMember(dest => dest.EnrolmentEventId, opt => opt.MapFrom(src => src.EnrolmentEventId))
        //        .ForMember(dest => dest.VillageId, opt => opt.MapFrom(src => src.VillageId))
        //        .ForMember(dest => dest.ScheduleDate, opt => opt.MapFrom(src => src.ScheduleDate))
        //        .ForMember(dest => dest.EnrolmentSchedule, opt => opt.Ignore())
        //        .ForMember(dest => dest.EnrolmentEvent, opt => opt.Ignore())
        //        .ForMember(dest => dest.Village, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());


        //    CreateMap<Enrolment, EnrolmentsViewModel>()
        //.ForMember(dest => dest.EnrolmentId, opt => opt.MapFrom(src => src.Id))
        //.ForMember(dest => dest.EnrolmentGUId, opt => opt.MapFrom(src => src.GUId))
        //.ForMember(dest => dest.EnrolmentScheduleId, opt => opt.MapFrom(src => src.EnrolmentScheduleId))
        //.ForMember(dest => dest.EnrolmentEventDetailId, opt => opt.MapFrom(src => src.EnrolmentEventDetailId))
        //.ForMember(dest => dest.HouseholdId, opt => opt.MapFrom(src => src.HouseholdId))
        //.ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress))
        //.ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //.ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //.ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //.ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null))
        //.ForMember(dest => dest.EnrolmentDetails, opt => opt.MapFrom(src =>
        //    src.EnrolmentDetails != null && src.EnrolmentDetails.Any()
        //    ? src.EnrolmentDetails.FirstOrDefault()
        //    : null));

        //    CreateMap<EnrolmentsViewModel, Enrolment>()
        //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentId))
        //        .ForMember(dest => dest.GUId, opt => opt.MapFrom(src => src.EnrolmentGUId))
        //        .ForMember(dest => dest.EnrolmentScheduleId, opt => opt.MapFrom(src => src.EnrolmentScheduleId))
        //        .ForMember(dest => dest.EnrolmentEventDetailId, opt => opt.MapFrom(src => src.EnrolmentEventDetailId))
        //        .ForMember(dest => dest.HouseholdId, opt => opt.MapFrom(src => src.HouseholdId))
        //        .ForMember(dest => dest.PostalAddress, opt => opt.MapFrom(src => src.PostalAddress))
        //        .ForMember(dest => dest.EnrolmentSchedule, opt => opt.Ignore())
        //        .ForMember(dest => dest.EnrolmentEventDetail, opt => opt.Ignore())
        //        .ForMember(dest => dest.Household, opt => opt.Ignore())
        //        .ForMember(dest => dest.EnrolmentDetails, opt => opt.Ignore())
        //        .ForMember(dest => dest.PaymentDetails, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());




        //    CreateMap<EnrolmentDetail, EnrolmentDetailsViewModel>()
        //           .ForMember(dest => dest.EnrolmentDetailId, opt => opt.MapFrom(src => src.Id))
        //           .ForMember(dest => dest.HouseholdMemberFullName, opt => opt.MapFrom(src =>
        //               src.HouseholdMember != null
        //                   ? src.HouseholdMember.FirstName + " " + src.HouseholdMember.Surname
        //                   : null))
        //           .ForMember(dest => dest.GradeName, opt => opt.MapFrom(src =>
        //               src.Grade != null ? src.Grade.Code : null))
        //           .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src =>
        //               src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //           .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src =>
        //               src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //    // ViewModel → Entity
        //    CreateMap<EnrolmentDetailsViewModel, EnrolmentDetail>()
        //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.EnrolmentDetailId))
        //        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.HouseholdMember, opt => opt.Ignore())
        //        .ForMember(dest => dest.Grade, opt => opt.Ignore())
        //        .ForMember(dest => dest.Enrolment, opt => opt.Ignore());

        //    CreateMap<PaymentDetail, PaymentDetailViewModel>()
        //           .ForMember(dest => dest.PaymentDetailId, opt => opt.MapFrom(src => src.Id))
        //           .ForMember(dest => dest.PaymentModeName, opt => opt.MapFrom(src => src.PaymentMode != null ? src.PaymentMode.Name : null))
        //           .ForMember(dest => dest.FacilityName, opt => opt.MapFrom(src => src.Facility != null ? src.Facility.Name : null))
        //           .ForMember(dest => dest.PayeeFullName, opt => opt.MapFrom(src =>
        //               src.Payee != null ? $"{src.Payee.FirstName} {src.Payee.Surname}" : null))
        //           .ForMember(dest => dest.PayPointName, opt => opt.MapFrom(src => src.PayPoint != null ? src.PayPoint.Name : null))
        //           .ForMember(dest => dest.PayeeTypeName, opt => opt.MapFrom(src => src.PayeeType != null ? src.PayeeType.Code : null))
        //           .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //           .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //           .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //           .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //    CreateMap<PaymentDetailViewModel, PaymentDetail>()
        //        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PaymentDetailId))
        //        .ForMember(dest => dest.EnrolmentId, opt => opt.MapFrom(src => src.EnrolmentId))
        //        .ForMember(dest => dest.PaymentModeId, opt => opt.MapFrom(src => src.PaymentModeId))
        //        .ForMember(dest => dest.MobileNumber, opt => opt.MapFrom(src => src.MobileNumber))
        //        .ForMember(dest => dest.FacilityId, opt => opt.MapFrom(src => src.FacilityId))
        //        .ForMember(dest => dest.PayeeId, opt => opt.MapFrom(src => src.PayeeId))
        //        .ForMember(dest => dest.PayPointId, opt => opt.MapFrom(src => src.PayPointId))
        //        .ForMember(dest => dest.PayeeTypeId, opt => opt.MapFrom(src => src.PayeeTypeId))
        //        .ForMember(dest => dest.Enrolment, opt => opt.Ignore())
        //        .ForMember(dest => dest.PaymentMode, opt => opt.Ignore())
        //        .ForMember(dest => dest.Facility, opt => opt.Ignore())
        //        .ForMember(dest => dest.Payee, opt => opt.Ignore())
        //        .ForMember(dest => dest.PayPoint, opt => opt.Ignore())
        //        .ForMember(dest => dest.PayeeType, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //        .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());


        //CreateMap<Proxie, ProxieViewModel>()
        //       .ForMember(dest => dest.ProxieId, opt => opt.MapFrom(src => src.Id))
        //       .ForMember(dest => dest.GenderName, opt => opt.MapFrom(src => src.Gender != null ? src.Gender.Code : null))
        //       .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //       .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //       .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //       .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //CreateMap<ProxieViewModel, Proxie>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ProxieId))
        //    .ForMember(dest => dest.GUId, opt => opt.MapFrom(src => src.GUId))
        //    .ForMember(dest => dest.PaymentDetailsId, opt => opt.MapFrom(src => src.PaymentDetailsId))
        //    .ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber))
        //    .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName))
        //    .ForMember(dest => dest.MiddleName, opt => opt.MapFrom(src => src.MiddleName))
        //    .ForMember(dest => dest.GenderId, opt => opt.MapFrom(src => src.GenderId))
        //    .ForMember(dest => dest.DateofBirth, opt => opt.MapFrom(src => src.DateofBirth))
        //    .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumber))
        //    .ForMember(dest => dest.PaymentDetail, opt => opt.Ignore())
        //    .ForMember(dest => dest.Gender, opt => opt.Ignore())
        //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //.ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //.ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //.ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());


        //CreateMap<PaymentMode, PaymentModeViewModel>()
        //       .ForMember(dest => dest.PaymentModeId, opt => opt.MapFrom(src => src.Id))
        //       .ForMember(dest => dest.CreatedById, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.Id : null))
        //       .ForMember(dest => dest.CreatedByName, opt => opt.MapFrom(src => src.CreatedBy != null ? src.CreatedBy.UserName : null))
        //       .ForMember(dest => dest.ModifiedById, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.Id : null))
        //       .ForMember(dest => dest.ModifiedByName, opt => opt.MapFrom(src => src.ModifiedBy != null ? src.ModifiedBy.UserName : null));

        //CreateMap<PaymentModeViewModel, PaymentMode>()
        //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PaymentModeId))
        //    .ForMember(dest => dest.CreatedBy, opt => opt.Ignore())
        //    .ForMember(dest => dest.ModifiedBy, opt => opt.Ignore())
        //    .ForMember(dest => dest.PaymentDetails, opt => opt.Ignore())
        //    .ForMember(dest => dest.CreatedOn, opt => opt.Ignore())
        //    .ForMember(dest => dest.ModifiedOn, opt => opt.Ignore());

        //CreateMap<PaymentMode, PaymentModeViewModel>().ReverseMap();
        //CreateMap<PaymentMode, PaymentModeView>().ReverseMap();
        //CreateMap<PayPoint, PayPointViewModel>().ReverseMap();
        //CreateMap<PayPoint, PayPointView>().ReverseMap();
    }


}


