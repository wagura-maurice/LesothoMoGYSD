using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MoGYSD.Business.Models.Common;
using MoGYSD.Business.Models.Missa.EligibilityTests;
using MoGYSD.Business.Models.Missa.Enrolments;
using MoGYSD.Business.Models.Missa.ProgrammeConfiguration;
using MoGYSD.Business.Models.Missa.Setups;
using MoGYSD.Business.Models.Missa.Validation;
using MoGYSD.Business.Models.Nissa.Admin;
using MoGYSD.Business.Models.Nissa.DistrictRegistrations;
using MoGYSD.Business.Models.Nissa.HouseHoldEnumerations;
using MoGYSD.Business.Models.Nissa.HouseHoldListings;
using MoGYSD.Business.Models.Nissa.MasterRegistrations;
using MoGYSD.Business.Models.Nissa.PMTCalculations;
using MoGYSD.Business.Models.Nissa.UserManagement;
using MoGYSD.Business.Persistence.Extensions;
using MoGYSD.Business.Views.HouseHoldListings;
using MoGYSD.Business.Views.Missa.EligibilityTests;
using MoGYSD.Business.Views.Missa.Enrolments;
using MoGYSD.Business.Views.Missa.Programmes;
using MoGYSD.Business.Views.Missa.Setups;
using MoGYSD.Business.Views.Nissa.Admin;
using MoGYSD.Business.Views.Nissa.Districtregistrations;
using MoGYSD.Business.Views.Nissa.HHEnumerations;
using MoGYSD.Business.Views.Nissa.MasterRegistrations;
using MoGYSD.ViewModels.Missa.Programmes;
using System.Reflection.Emit;
using System.Text.Json;

namespace MoGYSD.Business.Persistence;
/// <summary>
/// Represents the application's database context, combining ASP.NET Core Identity
/// with custom application entities in a single database context.
/// </summary>
/// <remarks>
/// <para>
/// This context extends <see cref="IdentityDbContext{TUser, TRole, TKey, TUserClaim, TUserRole, TUserLogin, TRoleClaim, TUserToken}"/>
/// to integrate custom user and role types with the authentication system.
/// </para>
/// <para>
/// Includes DbSets for all application-specific entities and configures their
/// relationships via Fluent API in OnModelCreating.
/// </para>
/// </remarks>
/// <param name="options">The configuration options for this context</param>
public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser, ApplicationRole, string,
IdentityUserClaim<string>, ApplicationUserRole, IdentityUserLogin<string>,
ApplicationRoleClaim, IdentityUserToken<string>>(options)
{
    #region Entities for DB
    // ==============================================
    // System Configuration Entities
    // ==============================================

    /// <summary>
    /// Gets or sets the system tasks/menu items for role-based access control.
    /// </summary>
    public DbSet<SystemTask> SystemTasks { get; set; }

    /// <summary>
    /// Gets or sets the system-wide configuration settings.
    /// </summary>
    public DbSet<SystemSetting> SystemSettings { get; set; }

    /// <summary>
    /// Gets or sets the role-task permissions mapping for authorization.
    /// </summary>
    public DbSet<RoleProfile> RoleProfiles { get; set; }

    /// <summary>
    /// Gets or sets the system code categories for reference data.
    /// </summary>
    public DbSet<SystemCode> SystemCodes { get; set; }

    /// <summary>
    /// Gets or sets the system code values within each category.
    /// </summary>
    public DbSet<SystemCodeDetail> SystemCodeDetails { get; set; }

    /// <summary>
    /// Gets or sets the audit trail records for system activity tracking.
    /// </summary>
    public DbSet<AuditTrail> AuditTrail { get; set; }

    /// <summary>
    /// Gets or sets the approval workflow records for transactional approvals.
    /// </summary>
    public DbSet<Approval> Approvals { get; set; }
    public DbSet<EnumerationAreaVillage> EnumerationAreaVillages { get; set; }
    public DbSet<EnumerationArea> EnumerationAreas { get; set; }
    public DbSet<SettlementType> SettlementTypes { get; set; }
    public DbSet<EcologicalZone> EcologicalZones { get; set; }
    // ==============================================
    // Geographic Entities
    // ==============================================

    /// <summary>
    /// Gets or sets the Countries geographical units.
    /// </summary>
    public DbSet<Country> Countries { get; set; }
    /// <summary>
    /// Gets or sets the district geographical units.
    /// </summary>
    public DbSet<District> Districts { get; set; }
    /// <summary>
    /// Gets or sets the Constituency within districts.
    /// </summary>
    public DbSet<Constituency> Constituencies { get; set; }

    /// <summary>
    /// Gets or sets the community councils within districts.
    /// </summary>
    public DbSet<CommunityCouncil> CommunityCouncils { get; set; }

    /// <summary>
    /// Gets or sets the villages within community councils.
    /// </summary>
    public DbSet<Village> Villages { get; set; }

    public DbSet<DistrictCensusHHData> DistrictCensusHHDatas { get; set; }


    // ==============================================
    // Registration Infrastructure
    // ==============================================

    /// <summary>
    /// Gets or sets the registration centers for field operations.
    /// </summary>
    public DbSet<RegistrationCentre> RegistrationCentres { get; set; }

    /// <summary>
    /// Gets or sets the contact persons for partner organizations.
    /// </summary>
    public DbSet<ContactPerson> ContactPersons { get; set; }

    /// <summary>
    /// Gets or sets the partner organizations collaborating in registrations.
    /// </summary>
    public DbSet<Partner> Partners { get; set; }

    /// <summary>
    /// Gets or sets the field enumerators conducting registrations.
    /// </summary>
    public DbSet<Enumerator> Enumerators { get; set; }

    // ==============================================
    // Registration Master Entities
    // ==============================================

    /// <summary>
    /// Gets or sets the master registration plans coordinating large-scale initiatives.
    /// </summary>
    public DbSet<MasterRegistration> MasterRegistrations { get; set; }

    /// <summary>
    /// Gets or sets the district-level implementations of registration plans.
    /// </summary>
    public DbSet<RegistrationDistrict> RegistrationDistricts { get; set; }

    /// <summary>
    /// Gets or sets the community council assignments within registration districts.
    /// </summary>
    public DbSet<RegistrationDistrictCC> RegistrationDistrictCCs { get; set; }

    // ==============================================
    // Registration Distric Entities
    // ==============================================

    /// <summary>
    /// Gets or sets the district-specific registration plan implementations.
    /// </summary>
    public DbSet<DistrictRegistrationPlan> DistrictRegistrationPlans { get; set; }

    /// <summary>
    /// Gets or sets the registered community council records.
    /// </summary>
    public DbSet<CCsRegistered> CCsRegistereds { get; set; }

    /// <summary>
    /// Gets or sets the registration activities conducted at community councils.
    /// </summary>
    public DbSet<CCRegistrationActivity> CCRegistrationActivities { get; set; }

    // ==============================================
    // Assessment Tools
    // ==============================================

    /// <summary>
    /// Gets or sets the Poverty Means Test formulas for eligibility calculations.
    /// </summary>
    public DbSet<RegistrationCentreVillage> RegistrationCentreVillages { get; set; }


    public DbSet<HHListingPlan> HHListingPlans { get; set; }
    public DbSet<CCHouseHoldListingArea> CCHouseHoldListingAreas { get; set; }
    public DbSet<HHListing> HHListings { get; set; }
    public DbSet<CbcActivity> CbcActivities { get; set; }
    public DbSet<CbcActivityVillage> CbcActivityVillages { get; set; }
    public DbSet<CbcCategorization> CbcCategorizations { get; set; }

    // HouseHoldEnumeration Models
    public DbSet<HHEnumerationPlan> HHEnumerationPlans { get; set; }
    public DbSet<HHEnumerationPlanCC> HHEnumerationPlanCCs { get; set; }
    public DbSet<EnumerationTeam> EnumerationTeams { get; set; }
    public DbSet<Household> Households { get; set; }
    public DbSet<HouseholdMember> HouseholdMembers { get; set; }
    public DbSet<HouseholdAsset> HouseholdAssets { get; set; }
    public DbSet<HHDwellingCharacteristic> HHDwellingCharacteristics { get; set; }
    public DbSet<HHLivingCondition> HHLivingConditions { get; set; }
    public DbSet<HHFoodSecurityVulnerability> HHFoodSecurityVulnerabilities { get; set; }
    public DbSet<Disability> Disabilities { get; set; }
    public DbSet<CRVSValidation> CRVSValidations { get; set; }
    public DbSet<NICRValidation> NICRValidations { get; set; }

    public DbSet<PMTFormula> PMTFormulas { get; set; }
    public DbSet<PMTFormulaCoefficient> PMTFormulaCoefficients { get; set; }
    public DbSet<PMTIndicatorCategory> PMTIndicatorCategories { get; set; }
    public DbSet<PMTIndicator> PMTIndicators { get; set; }
    public DbSet<HHPMT> HHPMTs { get; set; } 

    public DbSet<UserDistrictAssignment> UserDistrictAssignments { get; set; }
    public DbSet<UserCommunityCouncilAssignment> UserCommunityCouncilAssignments { get; set; }
    public DbSet<UserVillageAssignment> UserVillageAssignments { get; set; }
    public DbSet<UserRegistrationCentreAssignment> UserRegistrationCentreAssignments { get; set; }

    #region  Missa
    /// <summary>
    /// Gets or sets the Missa program entities, including program definitions, benefit rules,
    /// payment frequencies, eligibility criteria, and top-up configurations.
    /// </summary>
    public DbSet<Programmes> Programmes { get; set; }
    /// <summary>
    /// Gets or sets the benefit rules for Missa programs, defining eligibility and payment logic.
    /// </summary>
    public DbSet<BenefitRule> BenefitRules { get; set; }
    /// <summary>
    /// Gets or sets the available payment frequencies for Missa program disbursements.
    /// </summary>
    public DbSet<PaymentFrequencies> PaymentFrequencies { get; set; }
    /// <summary>
    /// Gets or sets the eligibility criteria for Missa program participation.
    /// </summary>
    public DbSet<EligibilityCriteria> EligibilityCriterias { get; set; }
    public DbSet<EligibilityCriteriaLocation> EligibilityCriteriaLocations { get; set; }
    public DbSet<EnrolledInOtherProgramme> EnrolledInOtherProgrammes { get; set; }
    public DbSet<EligibilityCriteriaCBC> EligibilityCriteriaCBCs { get; set; }
    public DbSet<EligibilityCriteriaVulnerabilityType> EligibilityCriteriaVulnerabilityTypes { get; set; }
    public DbSet<EligibilityCriteriaPovertyStatus> EligibilityCriteriaPovertyStatus { get; set; }
    public DbSet<TopUps> TopUps { get; set; }

    public DbSet<ValidationList> ValidationLists { get; set; }
    public DbSet<ValidationDetail> ValidationDetails { get; set; }
    public DbSet<EligibilityTests> EligibilityTests { get; set; }
    public DbSet<EligibilityTestDetail> EligibilityTestDetails { get; set; }
    public DbSet<EligibilityTestDistrict> EligibilityTestDistricts { get; set; }   
    public DbSet<Grade> Grades { get; set; }
    public DbSet<Bank> Banks { get; set; }
    public DbSet<Facility> Facilities { get; set; }
    public DbSet<FacilityType> FacilityTypes { get; set; }
    public DbSet<FinancialYear> FinancialYears { get; set; }
    public DbSet<OVCBConfiguration> OVCBConfigurations { get; set; }
    public DbSet<ArrearsConfiguration> ArrearsConfigurations { get; set; }
    public DbSet<Enrolment> Enrolments { get; set; }
    public DbSet<EnrolmentDetail> EnrolmentDetails { get; set; }
    public DbSet<EnrolmentEvent> EnrolmentEvents { get; set; }
    public DbSet<EnrolmentEventDetail> EnrolmentEventDetails { get; set; }
    public DbSet<EnrolmentSchedule> EnrolmentSchedules { get; set; }
    public DbSet<EnrolmentScheduleDetail> EnrolmentScheduleDetails { get; set; }
    public DbSet<PaymentDetail> PaymentDetails { get; set; }
    public DbSet<Proxie> Proxies { get; set; }
    public DbSet<PaymentMode> PaymentModes { get; set; }
    public DbSet<PayPoint> PayPoints { get; set; }
    #endregion Missa 

    #endregion Entities for DB

    #region SQL Views
    // ==============================================
    // System Configuration database views
    // ==============================================

    /// <summary>
    /// Gets or sets the database view representing system code details with additional calculated fields.
    /// </summary>
    public DbSet<SystemCodeDetailsView> SystemCodeDetailsView { get; set; }

    /// <summary>
    /// Gets or sets the database view providing summarized user information across multiple tables.
    /// </summary>
    /// <remarks>
    /// Includes aggregated data from user profiles, roles, and geographic associations.
    /// </remarks>
    public DbSet<UserSummaryView> UserSummaryView { get; set; }

    /// <summary>
    /// Gets or sets the database view combining master registration data with related status information.
    /// </summary>
    public DbSet<MasterRegistrationView> MasterRegistrationView { get; set; }

    /// <summary>
    /// Gets or sets the database view showing registration districts with calculated coverage metrics.
    /// </summary>
    public DbSet<RegistrationDistrictView> RegistrationDistrictView { get; set; }

    /// <summary>
    /// Gets or sets the database view linking registration districts to community councils with projected targets.
    /// </summary>
    public DbSet<RegistrationDistrictCCView> RegistrationDistrictCCView { get; set; }
    public DbSet<DistrictUserEmailNotificationView> DistrictUserEmailNotificationView { get; set; }

    /// <summary>
    /// Gets or sets the database view providing enumerator information with associated registration center details.
    /// </summary>
    public DbSet<EnumeratorView> EnumeratorView { get; set; }

    /// <summary>
    /// Gets or sets the database view showing registration centers with supervisor and location information.
    /// </summary>
    public DbSet<RegistrationCentreView> RegistrationCentreView { get; set; }

    /// <summary>
    /// Gets or sets the database view combining partner organizations with their contact information.
    /// </summary>
    public DbSet<PartnerView> PartnerView { get; set; }

    /// <summary>
    /// Gets or sets the database view showing contact persons with their associated partner organizations.
    /// </summary>
    public DbSet<ContactPersonView> ContactPersonView { get; set; }

    /// <summary>
    /// Gets or sets the database view presenting district registration plans with progress metrics.
    /// </summary>
    public DbSet<DistrictRegistrationPlanView> DistrictRegistrationPlanView { get; set; }

    /// <summary>
    /// Gets or sets the database view showing registered community councils with status information.
    /// </summary>
    public DbSet<CCsRegisteredView> CCsRegisteredView { get; set; }

    /// <summary>
    /// Gets or sets the database view combining registration activities with related partner and contact details.
    /// </summary>
    public DbSet<CCRegistrationActivityView> CCRegistrationActivityView { get; set; }
    public DbSet<DistrictRegistrationUserEmailNotificationView> DistrictRegistrationUserEmailNotificationView { get; set; }
    public DbSet<CommunityCouncilView> CommunityCouncilView { get; set; }
    public DbSet<VillageView> VillageView { get; set; }
    public DbSet<DistrictCensusHHDataView> DistrictCensusHHDataView { get; set; }
    public DbSet<DistrictView> DistrictView { get; set; }
    public DbSet<ConstituencyView> ConstituencyView { get; set; }
    public DbSet<RegistrationCentreVillageView> RegistrationCentreVillageView { get; set; }
    public DbSet<HHListingPlanView> HHListingPlanView { get; set; }
    public DbSet<HHListingView> HHListingView { get; set; }
    public DbSet<CCHouseHoldListingAreaView> CCHouseHoldListingAreaView { get; set; }
    public DbSet<CbcActivitiesView> CbcActivitiesView { get; set; }
    public DbSet<CbcActivityVillageView> CbcActivityVillageView { get; set; }
    public DbSet<CbcCategorizationView> CbcCategorizationView { get; set; }
    public DbSet<HHEnumerationPlanView> HHEnumerationPlanView { get; set; }
    public DbSet<EnumerationAreaView> EnumerationAreaView { get; set; }
    public DbSet<EnumeratorsCCView> EnumeratorsCCView { get; set; }
    public DbSet<EnumerationTeamView> EnumerationTeamView { get; set; }


    #region Missa
    public DbSet<ProgrammeView> ProgrammeView { get; set; }
    /// <summary>
    /// Gets or sets the database view representing Missa program benefit rules.
    /// </summary>
    public DbSet<BenefitRuleView> BenefitRuleView { get; set; }
    /// <summary>
    /// Gets or sets the database view representing Missa program eligibility criteria.
    /// </summary>
    public DbSet<EligibilityCriteriaView> EligibilityCriteriaView { get; set; }
    /// <summary>
    /// Gets or sets the database view representing Missa program payment frequencies.
    /// </summary>
    public DbSet<PaymentFrequencyView> PaymentFrequencyView { get; set; }
    /// <summary>
    /// Gets or sets the database view representing Missa program top-up configurations.
    /// </summary>
    public DbSet<TopUpView> TopUpView { get; set; }
    public DbSet<ValidationListView> ValidationListView { get; set; }
    public DbSet<EligibilityTestsView> EligibilityTestsView { get; set; }
    public DbSet<EligibilityTestDetailsView> EligibilityTestDetailsView { get; set; }   

    public DbSet<BankView> BankView { get; set; }
    public DbSet<FacilityView> FacilityView { get; set; }
    public DbSet<FacilityTypeView> FacilityTypeView { get; set; }
    public DbSet<FinancialYearView> FinancialYearView { get; set; }
    public DbSet<GradeView> GradeView { get; set; }
    public DbSet<OVCBConfigurationView> OVCBConfigurationView { get; set; }
    public DbSet<ArrearsConfigurationView> ArrearsConfigurationView { get; set; }
    public DbSet<EnrolmentsView> EnrolmentsView { get; set; }
    public DbSet<EnrolmentDetailsView> EnrolmentDetailsView { get; set; }
    public DbSet<EnrolmentScheduleView> EnrolmentScheduleView { get; set; }
    public DbSet<EnrolmentScheduleDetailView> EnrolmentScheduleDetailView { get; set; }
    public DbSet<EnrolmentEventView> EnrolmentEventView { get; set; }
    public DbSet<EnrolmentEventDetailView> EnrolmentEventDetailView { get; set; }
    public DbSet<PaymentDetailView> PaymentDetailView { get; set; }
    public DbSet<ProxieView> ProxieView { get; set; }
    public DbSet<PayPointView> PayPointView { get; set; }
    public DbSet<PaymentModeView> PaymentModeView { get; set; }


    #endregion Missa





    #endregion End Views

    /// <summary>
    /// Configures the model relationships and constraints using Fluent API.
    /// </summary>
    /// <param name="builder">The model builder instance</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        const int precision = 18;
        const int scale = 2;

        // Apply precision to all decimal properties in all entities
        foreach (var entityType in builder.Model.GetEntityTypes())
        {
            var decimalProperties = entityType
                .GetProperties()
                .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?));

            foreach (var property in decimalProperties)
            {
                property.SetPrecision(precision);
                property.SetScale(scale);
            }
        }

        #region System Configuration
        builder.Entity<UserDistrictAssignment>()
            .HasKey(uda => new { uda.ApplicationUserId, uda.DistrictId });

        builder.Entity<UserDistrictAssignment>()
            .HasOne(uda => uda.ApplicationUser)
            .WithMany(u => u.UserDistricts)
            .HasForeignKey(uda => uda.ApplicationUserId);

        builder.Entity<UserDistrictAssignment>()
            .HasOne(uda => uda.District)
            .WithMany(d => d.UserAssignments)
            .HasForeignKey(uda => uda.DistrictId);

        builder.Entity<UserCommunityCouncilAssignment>()
            .HasKey(uda => new { uda.ApplicationUserId, uda.CommunityCouncilId });

        builder.Entity<UserCommunityCouncilAssignment>()
            .HasOne(uda => uda.ApplicationUser)
            .WithMany(u => u.UserCommunityCouncils)
            .HasForeignKey(uda => uda.ApplicationUserId);

        builder.Entity<UserCommunityCouncilAssignment>()
            .HasOne(uda => uda.CommunityCouncil)
            .WithMany(d => d.UserAssignments)
            .HasForeignKey(uda => uda.CommunityCouncilId);

        builder.Entity<UserVillageAssignment>()
            .HasKey(uda => new { uda.ApplicationUserId, uda.VillageId });

        builder.Entity<UserVillageAssignment>()
            .HasOne(uda => uda.ApplicationUser)
            .WithMany(u => u.UserVillages)
            .HasForeignKey(uda => uda.ApplicationUserId);

        builder.Entity<UserVillageAssignment>()
            .HasOne(uda => uda.Village)
            .WithMany(d => d.UserAssignments)
            .HasForeignKey(uda => uda.VillageId);

        builder.Entity<UserRegistrationCentreAssignment>()
            .HasKey(uda => new { uda.ApplicationUserId, uda.RegistrationCentreId });

        builder.Entity<UserRegistrationCentreAssignment>()
            .HasOne(uda => uda.ApplicationUser)
            .WithMany(u => u.UserRegistrationCentres)
            .HasForeignKey(uda => uda.ApplicationUserId);

        builder.Entity<UserRegistrationCentreAssignment>()
            .HasOne(uda => uda.RegistrationCentre)
            .WithMany(d => d.UserAssignments)
            .HasForeignKey(uda => uda.RegistrationCentreId);

        // Configure System Tasks
        builder.Entity<ApplicationRoleClaim>()
            .HasOne(d => d.Role)
            .WithMany(p => p.RoleClaims)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ApplicationUserRole>()
            .HasOne(d => d.Role)
            .WithMany(p => p.UserRoles)
            .HasForeignKey(d => d.RoleId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ApplicationUser>()
            .HasMany(e => e.UserRoles)
            .WithOne()
            .HasForeignKey(ur => ur.UserId)
            .IsRequired();
        builder.Entity<ApplicationUser>().Property(e => e.Documents)
            .HasConversion(
                v => JsonSerializer.Serialize(v, DefaultJsonSerializerOptions.Options),
                v => JsonSerializer.Deserialize<List<RegistrationImage>>(v, DefaultJsonSerializerOptions.Options),
                new ValueComparer<List<RegistrationImage>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));
        builder.Entity<ApplicationUser>().Property(e => e.PhotoDocuments)
            .HasConversion(
                v => JsonSerializer.Serialize(v, DefaultJsonSerializerOptions.Options),
                v => JsonSerializer.Deserialize<List<RegistrationImage>>(v, DefaultJsonSerializerOptions.Options),
                new ValueComparer<List<RegistrationImage>>(
                    (c1, c2) => c1.SequenceEqual(c2),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()));

        builder.ApplyConfiguration(new BaseAuditableEntityConfiguration<CommunityCouncil>());

        builder.Entity<ApplicationUser>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUser>().HasOne(x => x.IDTypeDetail).WithMany().HasForeignKey(x => x.IDTypeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUser>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUser>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUser>().HasOne(x => x.Sex).WithMany().HasForeignKey(x => x.SexId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUser>().Property(a => a.IDNumber).IsRequired(false);
        builder.Entity<ApplicationUser>().Property(a => a.ModifiedOn).IsRequired(false);

        builder.Entity<ApplicationRole>().HasIndex(x => x.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique(false);
        builder.Entity<ApplicationRole>().HasOne(x => x.SystemCodeDetail).WithMany().HasForeignKey(x => x.SystemCodeDetailId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationRole>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationRole>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ApplicationUserRole>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationUserRole>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ApplicationRoleClaim>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ApplicationRoleClaim>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Enumerator>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Enumerator>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Enumerator>().HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Enumerator>().HasOne(x => x.RegistrationCentre).WithMany().HasForeignKey(x => x.RegistrationCentreId).IsRequired().OnDelete(DeleteBehavior.NoAction);


        builder.Entity<RoleProfile>()
            .HasKey(c => new { c.RoleId, c.TaskId });

        builder.Entity<AuditTrail>().ToTable("AuditTrail");
        builder.Entity<AuditTrail>().Property(a => a.OldValue).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.UserAgent).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.RequestIpAddress).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.ChangeType).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.RecordId).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.PcName).IsRequired(false);
        builder.Entity<AuditTrail>().Property(a => a.Description).IsRequired(false);
        builder.Entity<AuditTrail>(entity =>
        {
            entity.Property(e => e.UserId).HasMaxLength(450);
            entity.Property(e => e.UserAgent).HasMaxLength(512);
            entity.Property(e => e.RequestIpAddress).HasMaxLength(45);
            entity.Property(e => e.ChangeType).HasMaxLength(50);
            entity.Property(e => e.TableName).HasMaxLength(128);
            entity.Property(e => e.RecordId).HasMaxLength(64);
            entity.Property(e => e.PcName).HasMaxLength(255);
            entity.Property(e => e.Description).HasMaxLength(1000);
        });
        builder.Entity<RegistrationCentre>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationCentre>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationCentre>().HasIndex(a => a.CentreCode).IsUnique();
        builder.Entity<RegistrationCentre>().Property(a => a.CentreName).IsRequired().HasMaxLength(100);
        builder.Entity<RegistrationCentre>().HasOne(t => t.Supervisor).WithMany().HasForeignKey(x => x.SupervisorId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<RegistrationCentreVillage>().HasOne(t => t.Village).WithMany().HasForeignKey(x => x.VillageId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationCentreVillage>().HasOne(t => t.RegistrationCentre).WithMany().HasForeignKey(x => x.RegistrationCentreId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationCentreVillage>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationCentreVillage>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<ContactPerson>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ContactPerson>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ContactPerson>().HasOne(t => t.Partner).WithMany().HasForeignKey(x => x.PartnerId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ContactPerson>().HasIndex(a => a.EmailAddress).IsUnique();
        builder.Entity<ContactPerson>().Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);
        builder.Entity<ContactPerson>().Property(a => a.FirstName).IsRequired().HasMaxLength(50);
        builder.Entity<ContactPerson>().Property(a => a.Surname).IsRequired().HasMaxLength(50);

        builder.Entity<Partner>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasOne(t => t.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasOne(t => t.OrgType).WithMany().HasForeignKey(x => x.OrgTypeId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasOne(t => t.RegistrationPurpose).WithMany().HasForeignKey(x => x.RegistrationPurposeId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasOne(t => t.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Partner>().HasIndex(a => a.PartnerName).IsUnique();
        builder.Entity<Partner>().Property(a => a.PartnerName).IsRequired().HasMaxLength(100);
        builder.Entity<Partner>().Property(a => a.PhysicalAddress).IsRequired().HasMaxLength(200);
        builder.Entity<Partner>().Property(a => a.PostalAddress).IsRequired().HasMaxLength(200);
        builder.Entity<Partner>().HasIndex(a => a.EmailAddress).IsUnique();
        builder.Entity<Partner>().Property(a => a.EmailAddress).IsRequired().HasMaxLength(100);
        builder.Entity<Partner>().Property(a => a.AreaOfOperation).IsRequired(false).HasMaxLength(100);

        builder.Entity<Country>().HasIndex(a => a.Code).IsUnique();
        builder.Entity<Country>().Property(a => a.Code).IsRequired().HasMaxLength(2);
        builder.Entity<Country>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Country>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Country>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<District>().HasIndex(a => a.Code).IsUnique();
        builder.Entity<District>().Property(a => a.Code).IsRequired().HasMaxLength(2);
        builder.Entity<District>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<District>().HasOne(t => t.Country).WithMany().HasForeignKey(x => x.CountryId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<District>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<District>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<DistrictCensusHHData>().HasOne(t => t.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictCensusHHData>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictCensusHHData>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictCensusHHData>().Property(a => a.Year).IsRequired();


        builder.Entity<Constituency>().HasIndex(a => a.Code).IsUnique();
        builder.Entity<Constituency>().Property(a => a.Code).IsRequired().HasMaxLength(6);
        builder.Entity<Constituency>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Constituency>().HasOne(t => t.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Constituency>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Constituency>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<CommunityCouncil>().HasIndex(a => a.Code).IsUnique();
        builder.Entity<CommunityCouncil>().Property(a => a.Code).IsRequired().HasMaxLength(10);
        builder.Entity<CommunityCouncil>().Property(a => a.CommunityCouncilName).IsRequired().HasMaxLength(100);
        builder.Entity<CommunityCouncil>().HasOne(t => t.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CommunityCouncil>().HasOne(t => t.Constituency).WithMany().HasForeignKey(x => x.ConstituencyId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CommunityCouncil>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CommunityCouncil>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Village>().HasIndex(a => a.Code).IsUnique();
        builder.Entity<Village>().Property(a => a.Code).IsRequired().HasMaxLength(14);
        builder.Entity<Village>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Village>().HasOne(t => t.CommunityCouncil).WithMany().HasForeignKey(x => x.CommunityCouncilId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Village>().Navigation(e => e.CommunityCouncil).AutoInclude();
        builder.Entity<Village>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Village>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EnumerationAreaVillage>()
            .HasKey(eav => new { eav.EnumerationAreaId, eav.VillageId });

        builder.Entity<EnumerationAreaVillage>()
            .HasOne(eav => eav.EnumerationArea)
            .WithMany(ea => ea.EnumerationAreaVillages)
            .HasForeignKey(eav => eav.EnumerationAreaId);

        builder.Entity<EnumerationAreaVillage>()
            .HasOne(eav => eav.Village)
            .WithMany(v => v.EnumerationAreaVillages)
            .HasForeignKey(eav => eav.VillageId);

        builder.Entity<EnumerationArea>().HasIndex(a => a.Name).IsUnique();
        builder.Entity<EnumerationArea>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<EnumerationArea>().HasOne(t => t.HHEnumerationPlan).WithMany().HasForeignKey(x => x.HHEnumerationPlanId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EnumerationArea>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EnumerationArea>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<SettlementType>().HasIndex(a => a.Name).IsUnique();
        builder.Entity<SettlementType>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<SettlementType>().HasOne(t => t.Village).WithMany().HasForeignKey(x => x.VillageId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<SettlementType>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<SettlementType>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EcologicalZone>().HasIndex(a => a.Name).IsUnique();
        builder.Entity<EcologicalZone>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<EcologicalZone>().HasOne(t => t.Village).WithMany().HasForeignKey(x => x.VillageId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EcologicalZone>().HasOne(t => t.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EcologicalZone>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<MasterRegistration>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().HasOne(x => x.Currency).WithMany().HasForeignKey(x => x.CurrencyId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().HasOne(x => x.PlanType).WithMany().HasForeignKey(x => x.PlanTypeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().HasOne(x => x.DataCollectionType).WithMany().HasForeignKey(x => x.DataCollectionTypeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<MasterRegistration>().Property(a => a.EstimatedHHs).IsRequired(false);

        builder.Entity<RegistrationDistrict>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrict>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrict>().HasOne(x => x.MasterRegistration).WithMany().HasForeignKey(x => x.MasterRegistrationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrict>().HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        builder.Entity<RegistrationDistrictCC>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrictCC>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrictCC>().HasOne(x => x.RegistrationDistrict).WithMany().HasForeignKey(x => x.RegistrationDistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<RegistrationDistrictCC>().HasOne(x => x.CommunityCouncil).WithMany().HasForeignKey(x => x.CCId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        builder.Entity<DistrictRegistrationPlan>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictRegistrationPlan>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictRegistrationPlan>().HasOne(x => x.MasterRegistration).WithMany().HasForeignKey(x => x.MasterRegistrationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictRegistrationPlan>().HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<DistrictRegistrationPlan>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        builder.Entity<CCsRegistered>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCsRegistered>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCsRegistered>().HasOne(x => x.DistrictRegistrationPlan).WithMany().HasForeignKey(x => x.DistrictRegistrationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCsRegistered>().HasOne(x => x.CommunityCouncil).WithMany().HasForeignKey(x => x.CommunityCouncilId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCsRegistered>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        builder.Entity<CCRegistrationActivity>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.CCsRegistered).WithMany().HasForeignKey(x => x.CCsRegisteredId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.Activity).WithMany().HasForeignKey(x => x.ActivityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.Partners).WithMany().HasForeignKey(x => x.PartnersId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().HasOne(x => x.ContactPerson).WithMany().HasForeignKey(x => x.ContactPersonId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCRegistrationActivity>().Property(e => e.Documents)
                .HasConversion(
                    v => JsonSerializer.Serialize(v, DefaultJsonSerializerOptions.Options),
                    v => JsonSerializer.Deserialize<List<DocumentImage>>(v, DefaultJsonSerializerOptions.Options),
                    new ValueComparer<List<DocumentImage>>(
                        (c1, c2) => c1.SequenceEqual(c2),
                        c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                        c => c.ToList()));
                    builder.Entity<Approval>().Property(a => a.TransactionType).IsRequired().HasMaxLength(200);

        //------------------------------------------------
        // HHListingPlans 
        builder.Entity<HHListingPlan>().HasOne(x => x.District).WithMany().HasForeignKey(x => x.DistrictId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListingPlan>().HasOne(x => x.DistrictRegistrationPlan).WithMany().HasForeignKey(x => x.DistrictRegistrationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListingPlan>().HasOne(x => x.Partners).WithMany().HasForeignKey(x => x.PartnersId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListingPlan>().HasOne(x => x.ContactPerson).WithMany().HasForeignKey(x => x.ContactPersonId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListingPlan>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<HHListingPlan>().Property(a => a.HHListingActivityName).IsRequired().HasMaxLength(100);

        builder.Entity<CCHouseHoldListingArea>().HasOne(x => x.CommunityCouncil).WithMany().HasForeignKey(x => x.CCId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CCHouseHoldListingArea>().HasOne(x => x.HHListingPlan).WithMany().HasForeignKey(x => x.HHListingPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        // HHListings → HHListingPlans (Many-to-One, Mandatory)
        builder.Entity<HHListing>().HasOne(x => x.HHListingPlan).WithMany(x => x.HHListings).HasForeignKey(x => x.HHListingPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListing>().Property(a => a.Guid).IsRequired(); 
        builder.Entity<HHListing>().HasIndex(a => a.Guid).IsUnique();                                                                     
        builder.Entity<HHListing>().HasOne(x => x.Village).WithMany().HasForeignKey(x => x.VillageId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHListing>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities

        // CBCActivities → HHListingPlans (Many-to-One, Mandatory)
        builder.Entity<CbcActivity>().HasOne(x => x.HHListingPlan).WithMany(x => x.CbcActivities).HasForeignKey(x => x.HHListingPlanId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcActivity>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<CbcActivity>().HasOne(x => x.ContactPerson).WithMany().HasForeignKey(x => x.ContactPersonId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<CbcActivity>().HasOne(x => x.CommunityCouncil).WithMany().HasForeignKey(x => x.CommunityCouncilId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<CbcActivity>().HasOne(x => x.Partner).WithMany().HasForeignKey(x => x.PartnerId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities

        builder.Entity<CbcActivityVillage>()
               .HasKey(av => new { av.CbcActivityId, av.VillageId }); // Composite Key

        builder.Entity<CbcActivityVillage>()
            .HasOne(av => av.CbcActivity)
            .WithMany(a => a.CbcActivityVillages)
            .HasForeignKey(av => av.CbcActivityId);

        builder.Entity<CbcActivityVillage>()
            .HasOne(av => av.Village)
            .WithMany(v => v.CbcActivityVillages)
            .HasForeignKey(av => av.VillageId);

        builder.Entity<CbcCategorization>().HasOne(x => x.CBCActivity).WithMany(x => x.CbcCategorizations).HasForeignKey(x => x.CBCActivityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcCategorization>().HasOne(x => x.HHListing).WithMany(x => x.CbcCategorizations).HasForeignKey(x => x.HHListingId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcCategorization>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcCategorization>().HasOne(x => x.CBCOutcomeCategory).WithMany().HasForeignKey(x => x.CBCOutcomeCategoryId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcCategorization>().HasOne(x => x.CBCOutcomeCategoryReason).WithMany().HasForeignKey(x => x.CBCOutcomeCategoryReasonId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<CbcCategorization>().HasOne(x => x.ValidatedBy).WithMany().HasForeignKey(x => x.ValidatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<CbcCategorization>().Property(a => a.ValidatedNames).HasMaxLength(100);

        // HouseHoldEnumeration Model Configurations with OnDelete NoAction
        builder.Entity<HHEnumerationPlan>().HasOne(x => x.HHListingPlan).WithMany().HasForeignKey(x => x.HHListingPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlan>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlan>().HasOne(x => x.RegistrationCentre).WithMany().HasForeignKey(x => x.RegistrationCentreId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);            // Remove problematic relationship configurations that try to use string properties as entities
        builder.Entity<HHEnumerationPlan>().Property(a => a.Name).IsRequired().HasMaxLength(100);
        builder.Entity<HHEnumerationPlan>().Property(a => a.Description).HasMaxLength(250);

        builder.Entity<HHEnumerationPlanCC>().HasOne(x => x.HHEnumerationPlan).WithMany().HasForeignKey(x => x.HHEnumerationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlanCC>().HasOne(x => x.CC).WithMany().HasForeignKey(x => x.CCId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlanCC>().HasOne(x => x.CCRegistrationActivity).WithMany().HasForeignKey(x => x.CCRegistrationActivityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlanCC>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHEnumerationPlanCC>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EnumerationTeam>().HasOne(x => x.EnumerationArea).WithMany().HasForeignKey(x => x.EnumerationAreaId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EnumerationTeam>().HasOne(x => x.Enumerator).WithMany().HasForeignKey(x => x.EnumeratorId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EnumerationTeam>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<EnumerationTeam>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<Household>().HasOne(x => x.HHEnumerationPlan).WithMany(x => x.Households).HasForeignKey(x => x.HHEnumerationPlanId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.HHListing).WithMany().HasForeignKey(x => x.HHListingId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.Village).WithMany().HasForeignKey(x => x.VillageId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.CommunityValidationStatus).WithMany().HasForeignKey(x => x.CommunityValidationStatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.FinalValidationStatus).WithMany().HasForeignKey(x => x.FinalValidationStatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.EnumerationVisitStatus).WithMany().HasForeignKey(x => x.EnumerationVisitResultId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasOne(x => x.AgriculturalService).WithMany().HasForeignKey(x => x.AgriculturalServicesId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Household>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<Household>().Property(a => a.GUId).IsRequired();


        builder.Entity<HouseholdMember>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.Household).WithMany().HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        // HouseholdAsset doesn't inherit from BaseAuditableEntity, so no CreatedBy/ModifiedBy
        builder.Entity<HouseholdAsset>().HasOne(x => x.Household).WithMany(x => x.HouseholdAssets).HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction); 
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.Household).WithMany(x => x.HHDwellingCharacteristics).HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.RoofMaterial).WithMany().HasForeignKey(x => x.RoofMaterialId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.FloorMaterial).WithMany().HasForeignKey(x => x.FloorMaterialId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasOne(x => x.ToiletType).WithMany().HasForeignKey(x => x.ToiletTypeId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHDwellingCharacteristic>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<HHDwellingCharacteristic>().Property(a => a.GUId).IsRequired();

        builder.Entity<HHLivingCondition>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHLivingCondition>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHLivingCondition>().HasOne(x => x.Household).WithMany(x => x.HHLivingConditions).HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHLivingCondition>().HasOne(x => x.CookingFuel).WithMany().HasForeignKey(x => x.CookingFuelId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHLivingCondition>().HasOne(x => x.HeatingFuel).WithMany().HasForeignKey(x => x.HeatingFuelId).IsRequired().OnDelete(DeleteBehavior.NoAction);            // HHFoodSecurityVulnerability likely doesn't inherit from BaseAuditableEntity, configuring basic relationship
        builder.Entity<HHLivingCondition>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<HHLivingCondition>().Property(a => a.GUId).IsRequired();

        builder.Entity<HHFoodSecurityVulnerability>().HasOne(x => x.Household).WithMany(x => x.HHFoodSecurityVulnerabilities).HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHFoodSecurityVulnerability>().HasOne(x => x.FarmingActivity).WithMany().HasForeignKey(x => x.FarmingActivityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHFoodSecurityVulnerability>().HasOne(x => x.FoodAvailability).WithMany().HasForeignKey(x => x.FoodAvailabilityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHFoodSecurityVulnerability>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<HHFoodSecurityVulnerability>().Property(a => a.GUId).IsRequired();

        builder.Entity<Disability>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Disability>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Disability>().HasOne(x => x.HouseholdMember).WithMany(x => x.Disabilities).HasForeignKey(x => x.HouseholdMemberId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Disability>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<Disability>().Property(a => a.GUId).IsRequired();

        // CRVSValidation and NICRValidation likely don't inherit from BaseAuditableEntity
        builder.Entity<CRVSValidation>().HasOne(x => x.HouseholdMember).WithMany(x => x.CRVSValidations).HasForeignKey(x => x.HouseholdMemberId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<NICRValidation>().HasOne(x => x.HouseholdMember).WithMany(x => x.NICRValidations).HasForeignKey(x => x.HouseholdMemberId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        // HouseholdMember relationships
        builder.Entity<HouseholdMember>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.Household).WithMany(x => x.HouseholdMembers).HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.HHMemberType).WithMany().HasForeignKey(x => x.HHMemberTypeId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.Sex).WithMany().HasForeignKey(x => x.SexId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.WhereMemberLived).WithMany().HasForeignKey(x => x.WhereMemberLivedId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.WhereMemberIsLiving).WithMany().HasForeignKey(x => x.WhereMemberIsLivingId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.MainActivity).WithMany().HasForeignKey(x => x.MainActivityId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.MaritalStatus).WithMany().HasForeignKey(x => x.MaritalStatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.IsAttendingSchool).WithMany().HasForeignKey(x => x.IsAttendingSchoolId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.EducationLevel).WithMany().HasForeignKey(x => x.EducationLevelId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.SocialProgramme).WithMany().HasForeignKey(x => x.SocialProgrammeId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.Caregiver).WithMany().HasForeignKey(x => x.CaregiverId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.SchoolLevel).WithMany().HasForeignKey(x => x.SchoolLevelId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasOne(x => x.Status).WithMany().HasForeignKey(x => x.StatusId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HouseholdMember>().HasIndex(a => a.GUId).IsUnique();
        builder.Entity<HouseholdMember>().Property(a => a.GUId).IsRequired();

        // PMT related entities likely don't inherit from BaseAuditableEntity
        builder.Entity<PMTFormulaCoefficient>().HasOne(x => x.PMTFormula).WithMany(x => x.PMTFormulaCoefficients).HasForeignKey(x => x.PMTFormulaId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<PMTFormulaCoefficient>().HasOne(x => x.PMTIndicator).WithMany(x => x.PMTFormulaCoefficients).HasForeignKey(x => x.PMTIndicatorId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<PMTIndicator>().HasOne(x => x.PMTIndicatorCategory).WithMany(x => x.PMTIndicators).HasForeignKey(x => x.PMTIndicatorCategoryId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        // HHPMT basic relationship configurations
        builder.Entity<HHPMT>().HasOne(x => x.Household).WithMany().HasForeignKey(x => x.HouseholdId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHPMT>().HasOne(x => x.PMTFormula).WithMany().HasForeignKey(x => x.PMTFormulaId).IsRequired().OnDelete(DeleteBehavior.NoAction);
        builder.Entity<HHPMT>().HasOne(x => x.PMTClassificationThreshhlds).WithMany().HasForeignKey(x => x.PMTClassificationThreshhldsId).IsRequired().OnDelete(DeleteBehavior.NoAction);

        // Configure relationships for Missa program-related entities
        // Programmes Entity Configuration
        // Configure relationships for Missa program-related entities
        // Programmes Entity Configuration
        builder.Entity<Programmes>().HasOne(p => p.PaymentFrequency).WithMany().HasForeignKey(p => p.PaymentFrequencyId).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Programmes>().HasOne(p => p.AssistanceUnit).WithMany().HasForeignKey(p => p.AssistanceUnitId).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Programmes>().HasOne(p => p.ProgramType).WithMany().HasForeignKey(p => p.ProgramTypeId).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<Programmes>().HasMany(p => p.PaymentModesAllowed).WithMany().UsingEntity(j => j.ToTable("ProgrammePaymentModesAllowed"));

        // EligibilityCriteria,Location and enrolled programme Entity Configuration
        builder.Entity<EligibilityCriteria>(entity => {
            entity.HasKey(e => e.Id);
            entity.HasOne(e => e.Programme).WithMany().HasForeignKey(e => e.ProgrammeId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.AssistanceUnit).WithMany().HasForeignKey(e => e.AssistanceUnitId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.CommunityValidationStatus).WithMany().HasForeignKey(e => e.CommunityValidationStatusId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EligibilityCriteriaPovertyStatus>(entity => {
            entity.HasKey(e => new { e.EligibilityCriteriaId, e.PovertyStatusId });
            entity.HasOne(e => e.EligibilityCriteria).WithMany(e => e.EligibilityCriteriaPovertyStatuses).HasForeignKey(e => e.EligibilityCriteriaId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.PovertyStatus).WithMany().HasForeignKey(e => e.PovertyStatusId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EligibilityCriteriaVulnerabilityType>(entity => {
            entity.HasKey(e => new { e.EligibilityCriteriaId, e.VulnerabilityTypeId });
            entity.HasOne(e => e.EligibilityCriteria).WithMany(e => e.EligibilityCriteriaVulnerabilityTypes).HasForeignKey(e => e.EligibilityCriteriaId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.VulnerabilityType).WithMany().HasForeignKey(e => e.VulnerabilityTypeId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EligibilityCriteriaCBC>(entity => {
            entity.HasKey(e => new { e.EligibilityCriteriaId, e.CBCId });
            entity.HasOne(e => e.EligibilityCriteria).WithMany(e => e.EligibilityCriteriaCBCs).HasForeignKey(e => e.EligibilityCriteriaId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(e => e.CBC).WithMany().HasForeignKey(e => e.CBCId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EligibilityCriteriaLocation>(entity => {
            entity.HasKey(ecl => new { ecl.EligibilityCriteriaId, ecl.DistrictId });
            entity.HasOne(ecl => ecl.EligibilityCriteria).WithMany(ec => ec.EligibilityCriteriaLocations).HasForeignKey(ecl => ecl.EligibilityCriteriaId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(ecl => ecl.District).WithMany().HasForeignKey(ecl => ecl.DistrictId).OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<EnrolledInOtherProgramme>(entity => {
            entity.HasKey(eop => new { eop.EligibilityCriteriaId, eop.ProgrammeId });
            entity.HasOne(eop => eop.EligibilityCriteria).WithMany(ec => ec.EnrolledInOtherProgrammes).HasForeignKey(eop => eop.EligibilityCriteriaId).OnDelete(DeleteBehavior.Cascade);
            entity.HasOne(eop => eop.Programme).WithMany().HasForeignKey(eop => eop.ProgrammeId).OnDelete(DeleteBehavior.Restrict);
        });

        // TopUps Entity Configuration
        builder.Entity<TopUps>().HasOne(t => t.Programme).WithMany(p => p.TopUps).HasForeignKey(t => t.ProgrammeId).OnDelete(DeleteBehavior.NoAction);
        // BenefitRule Entity Configuration
        builder.Entity<BenefitRule>().HasOne(b => b.Programme).WithMany(p => p.BenefitRule).HasForeignKey(b => b.ProgrammeId).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<BenefitRule>().HasOne(b => b.CreatedBy).WithMany().HasForeignKey(b => b.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<BenefitRule>().HasOne(b => b.ModifiedBy).WithMany().HasForeignKey(b => b.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);


        // ValidationList relationships
       
        builder.Entity<ValidationList>().HasOne(v => v.CommunityCouncil).WithMany().HasForeignKey(v => v.CommunityCouncilId).OnDelete(DeleteBehavior.NoAction);
       
        // ValidationDetail relationships
        builder.Entity<ValidationDetail>().HasOne(vd => vd.ValidationList).WithMany(v => v.ValidationDetails).HasForeignKey(vd => vd.ValidationListId).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ValidationDetail>().HasOne(vd => vd.HouseholdMember).WithMany().HasForeignKey(vd => vd.HouseholdMemberId).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<ValidationDetail>().HasOne(vd => vd.ValidationStatus).WithMany().HasForeignKey(vd => vd.ValidationStatusId).OnDelete(DeleteBehavior.NoAction);

       // For Eligibility and EligibilityTestDetails
        builder.Entity<EligibilityTests>().HasMany(e => e.EligibilityTestDetails).WithOne(d => d.EligibilityTest).HasForeignKey(d => d.EligibilityTestId).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<EligibilityTestDetail>().HasOne(d => d.EnrolmentEventDetail).WithMany().HasForeignKey(d => d.EnrolmentEventDetailId).OnDelete(DeleteBehavior.NoAction);


        // Bank 
        builder.Entity<Bank>().HasKey(x => x.Id);
        builder.Entity<Bank>().Property(x => x.Name).IsRequired().HasMaxLength(150);
        builder.Entity<Bank>().Property(x => x.BankDescription).HasMaxLength(300);

        // Facility
        builder.Entity<Facility>(entity => { entity.HasKey(f => f.Id); entity.HasIndex(f => f.Code).IsUnique(); entity.HasOne(f => f.Bank).WithMany().HasForeignKey(f => f.BankId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(f => f.Category).WithMany().HasForeignKey(f => f.CategoryId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(f => f.CreatedBy).WithMany().HasForeignKey(f => f.CreatedById).OnDelete(DeleteBehavior.NoAction); entity.HasOne(f => f.ModifiedBy).WithMany().HasForeignKey(f => f.ModifiedById).OnDelete(DeleteBehavior.NoAction); });

        //FacilityType
        builder.Entity<FacilityType>().HasKey(x => x.Id);
        builder.Entity<FacilityType>().Property(x => x.Name).IsRequired().HasMaxLength(150);   
        builder.Entity<FacilityType>().HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        builder.Entity<FacilityType>().HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        // FinancialYear
        builder.Entity<FinancialYear>().HasKey(x => x.Id);
        builder.Entity<FinancialYear>().Property(x => x.Name).IsRequired().HasMaxLength(100);
        builder.Entity<FinancialYear>().Property(x => x.StartDate).HasColumnType("date");
        builder.Entity<FinancialYear>().Property(x => x.EndDate).HasColumnType("date");

        //Grade
        builder.Entity<Grade>(entity => { entity.HasKey(g => g.Id); entity.Property(g => g.Code).IsRequired().HasMaxLength(50); entity.HasMany(g => g.Facilities).WithMany(f => f.Grades).UsingEntity(j => j.ToTable("FacilityGrades")); entity.HasOne(g => g.CreatedBy).WithMany().HasForeignKey(g => g.CreatedById).OnDelete(DeleteBehavior.NoAction); entity.HasOne(g => g.ModifiedBy).WithMany().HasForeignKey(g => g.ModifiedById).OnDelete(DeleteBehavior.NoAction); });
         //OVCBConfiguration
        builder.Entity<OVCBConfiguration>(entity => { entity.HasKey(e => e.Id); entity.Property(e => e.FeeAmount).HasColumnType("decimal(18,2)"); entity.HasOne(e => e.Programme).WithMany(p => p.OVCBConfigurations).HasForeignKey(e => e.ProgrammeId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(e => e.FacilityType).WithMany().HasForeignKey(e => e.FacilityTypeId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(e => e.Grade).WithMany().HasForeignKey(e => e.GradeId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(e => e.FeeType).WithMany().HasForeignKey(e => e.FeeTypeId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(e => e.FinancialYear).WithMany().HasForeignKey(e => e.FinYearId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(x => x.CreatedBy).WithMany().HasForeignKey(x => x.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction); entity.HasOne(x => x.ModifiedBy).WithMany().HasForeignKey(x => x.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction); });
        //Arrears Configuration      
        builder.Entity<ArrearsConfiguration>(entity => { entity.HasKey(e => e.Id); entity.Property(e => e.MaximumCycles).IsRequired(); entity.Property(e => e.AccruedAfterPenalty).IsRequired(); entity.Property(e => e.ArrearsOverYear).IsRequired(); entity.Property(e => e.IsActive).IsRequired(); entity.HasOne(e => e.Programme).WithMany(p => p.ArrearsConfigurations).HasForeignKey(e => e.ProgrammeId).OnDelete(DeleteBehavior.Restrict); entity.HasOne(e => e.Penalty).WithMany().HasForeignKey(e => e.PenaltyId).OnDelete(DeleteBehavior.Restrict); });

        //Enrolments
        builder.Entity<Enrolment>().HasMany(e => e.EnrolmentDetails).WithOne(d => d.Enrolment).HasForeignKey(d => d.EnrolmentId).OnDelete(DeleteBehavior.Cascade);
        builder.Entity<Enrolment>().HasMany(e => e.PaymentDetails).WithOne(pd => pd.Enrolment).HasForeignKey(pd => pd.EnrolmentId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Enrolment>().HasOne(e => e.EnrolmentSchedule).WithMany().HasForeignKey(e => e.EnrolmentScheduleId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Enrolment>().HasOne(e => e.EnrolmentEventDetail).WithMany().HasForeignKey(e => e.EnrolmentEventDetailId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Enrolment>().HasOne(e => e.Household).WithMany(h => h.Enrolments).HasForeignKey(e => e.HouseholdId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EnrolmentDetail>().HasOne(d => d.HouseholdMember).WithMany(hm => hm.EnrolmentDetails).HasForeignKey(d => d.HouseholdMemberId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<EnrolmentDetail>().HasOne(d => d.Grade).WithMany(g => g.EnrolmentDetails).HasForeignKey(d => d.GradeId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EnrolmentEvent>().HasMany(ee => ee.EnrolmentSchedules).WithOne(es => es.EnrolmentEvent).HasForeignKey(es => es.EnrolmentEventId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<EnrolmentEvent>().HasMany(ee => ee.EnrolmentEventDetails).WithOne(eed => eed.EnrolmentEvent).HasForeignKey(eed => eed.EnrolmentEventId).OnDelete(DeleteBehavior.Cascade);
        //builder.Entity<EnrolmentEvent>().HasMany(ee => ee.Approvals).WithOne(a => a.EnrolmentEvent).HasForeignKey(a => a.EnrolmentEventId).OnDelete(DeleteBehavior.Cascade);
        //builder.Entity<EnrolmentEvent>().HasOne(ee => ee.Programme).WithMany(p => p.EnrolmentEvents).HasForeignKey(ee => ee.ProgrammeId).OnDelete(DeleteBehavior.Restrict);
        //builder.Entity<EnrolmentEvent>().HasOne(ee => ee.District).WithMany(d => d.EnrolmentEvents).HasForeignKey(ee => ee.DistrictId).OnDelete(DeleteBehavior.Restrict);
        //builder.Entity<EnrolmentEvent>().HasOne(ee => ee.CommunityCouncil).WithMany(cc => cc.EnrolmentEvents).HasForeignKey(cc => cc.CommunityCouncilId).OnDelete(DeleteBehavior.NoAction);
        //builder.Entity<EnrolmentEvent>().HasOne(ee => ee.Village).WithMany(v => v.EnrolmentEvents).HasForeignKey(ee => ee.VillageId).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EnrolmentEventDetail>().HasOne(eed => eed.HouseholdMember).WithMany(hm => hm.EnrolmentEventDetails).HasForeignKey(eed => eed.HouseholdMemberId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<EnrolmentEventDetail>().HasOne(eed => eed.Household).WithMany(h => h.EnrolmentEventDetails).HasForeignKey(eed => eed.HouseholdId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<EnrolmentSchedule>().HasMany(es => es.EnrolmentScheduleDetails).WithOne(esd => esd.EnrolmentSchedule).HasForeignKey(esd => esd.EnrolmentScheduleId).OnDelete(DeleteBehavior.Cascade);
        //builder.Entity<EnrolmentSchedule>().HasOne(es => es.District).WithMany(d => d.EnrolmentSchedules).HasForeignKey(es => es.DistrictId).OnDelete(DeleteBehavior.Restrict);
        //builder.Entity<EnrolmentSchedule>().HasOne(es => es.CommunityCouncil).WithMany(cc => cc.EnrolmentSchedules).HasForeignKey(es => es.CommunityCouncilId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);
        //builder.Entity<EnrolmentSchedule>().HasOne(es => es.Village).WithMany(v => v.EnrolmentSchedules).HasForeignKey(es => es.VillageId).IsRequired(false).OnDelete(DeleteBehavior.NoAction);

        builder.Entity<EnrolmentScheduleDetail>().HasOne(esd => esd.EnrolmentEvent).WithMany().HasForeignKey(esd => esd.EnrolmentEventId).OnDelete(DeleteBehavior.Restrict);
       // builder.Entity<EnrolmentScheduleDetail>().HasOne(esd => esd.Village).WithMany(v => v.EnrolmentScheduleDetails).HasForeignKey(esd => esd.VillageId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PaymentDetail>().HasOne(pd => pd.PaymentMode).WithMany(pm => pm.PaymentDetails).HasForeignKey(pd => pd.PaymentModeId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PaymentDetail>().HasOne(pd => pd.Facility).WithMany(f => f.PaymentDetails).HasForeignKey(pd => pd.FacilityId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PaymentDetail>().HasOne(pd => pd.Payee).WithMany(hm => hm.PaymentDetailsAsPayee).HasForeignKey(pd => pd.PayeeId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PaymentDetail>().HasOne(pd => pd.PayPoint).WithMany(pp => pp.PaymentDetails).HasForeignKey(pd => pd.PayPointId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<PaymentDetail>().HasMany(pd => pd.Proxies).WithOne(p => p.PaymentDetail).HasForeignKey(p => p.PaymentDetailsId).OnDelete(DeleteBehavior.Cascade);


        builder.Entity<PaymentMode>().HasMany(pm => pm.PaymentDetails).WithOne(pd => pd.PaymentMode).HasForeignKey(pd => pd.PaymentModeId).OnDelete(DeleteBehavior.Restrict);

        builder.Entity<PayPoint>().HasMany(pp => pp.PaymentDetails).WithOne(pd => pd.PayPoint).HasForeignKey(pd => pd.PayPointId).OnDelete(DeleteBehavior.Restrict);
        //builder.Entity<PayPoint>().HasOne(pp => pp.CommunityCouncil).WithMany(cc => cc.PayPoints).HasForeignKey(pp => pp.CommunityCouncilId).OnDelete(DeleteBehavior.Restrict);
        //builder.Entity<PayPoint>().HasOne(pp => pp.District).WithMany(d => d.PayPoints).HasForeignKey(d => d.DistrictId).OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Proxie>(e => { e.HasKey(p => p.Id); e.Property(p => p.GUId).IsRequired(); e.HasIndex(p => p.GUId).IsUnique(); e.HasOne(p => p.PaymentDetail).WithMany(pd => pd.Proxies).HasForeignKey(p => p.PaymentDetailsId).IsRequired().OnDelete(DeleteBehavior.NoAction); e.HasOne(p => p.Gender).WithMany().HasForeignKey(p => p.GenderId).IsRequired().OnDelete(DeleteBehavior.NoAction); e.HasOne(p => p.CreatedBy).WithMany().HasForeignKey(p => p.CreatedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction); e.HasOne(p => p.ModifiedBy).WithMany().HasForeignKey(p => p.ModifiedById).IsRequired(false).OnDelete(DeleteBehavior.NoAction); e.Property(p => p.IDNumber).HasMaxLength(50); e.Property(p => p.FirstName).IsRequired().HasMaxLength(100); e.Property(p => p.MiddleName).HasMaxLength(100); e.Property(p => p.PhoneNumber).HasMaxLength(20); e.Property(p => p.DateofBirth).IsRequired(); });


        #endregion System Configuration

        #region SQL Views
        // Configure SQL Views
        builder.Entity<SystemCodeDetailsView>().HasNoKey().ToView("SystemCodeDetailsView");
        builder.Entity<UserSummaryView>().HasNoKey().ToView("UserSummaryView");
        builder.Entity<MasterRegistrationView>().HasNoKey().ToView("MasterRegistrationView");
        builder.Entity<DistrictUserEmailNotificationView>().HasNoKey().ToView("DistrictUserEmailNotificationView");
        builder.Entity<RegistrationDistrictView>().HasNoKey().ToView("RegistrationDistrictView");
        builder.Entity<RegistrationDistrictCCView>().HasNoKey().ToView("RegistrationDistrictCCView");
        builder.Entity<EnumeratorView>().HasNoKey().ToView("EnumeratorView");
        builder.Entity<RegistrationCentreView>().HasNoKey().ToView("RegistrationCentreView");
        builder.Entity<RegistrationCentreVillageView>().HasNoKey().ToView("RegistrationCentreVillageView");
        builder.Entity<PartnerView>().HasNoKey().ToView("PartnerView");
        builder.Entity<ContactPersonView>().HasNoKey().ToView("ContactPersonView");
        builder.Entity<DistrictRegistrationPlanView>().HasNoKey().ToView("DistrictRegistrationPlanView");
        builder.Entity<DistrictRegistrationUserEmailNotificationView>().HasNoKey().ToView("DistrictRegistrationUserEmailNotificationView");
        builder.Entity<CCsRegisteredView>().HasNoKey().ToView("CCsRegisteredView");
        builder.Entity<CCRegistrationActivityView>().HasNoKey().ToView("CCRegistrationActivityView");
        builder.Entity<CommunityCouncilView>().HasNoKey().ToView("CommunityCouncilView");
        builder.Entity<VillageView>().HasNoKey().ToView("VillageView");
        builder.Entity<DistrictCensusHHDataView>().HasNoKey().ToView("DistrictCensusHHDataView");
        builder.Entity<DistrictView>().HasNoKey().ToView("DistrictView");
        builder.Entity<ConstituencyView>().HasNoKey().ToView("ConstituencyView");
        builder.Entity<HHListingPlanView>().HasNoKey().ToView("HHListingPlanView");
        builder.Entity<HHListingView>().HasNoKey().ToView("HHListingView");
        builder.Entity<CCHouseHoldListingAreaView>().HasNoKey().ToView("CCHouseHoldListingAreaView");
        builder.Entity<CbcActivitiesView>().HasNoKey().ToView("CbcActivitiesView");
        builder.Entity<CbcActivityVillageView>().HasNoKey().ToView("CbcActivityVillageView");
        builder.Entity<CbcCategorizationView>().HasNoKey().ToView("CbcCategorizationView");
        builder.Entity<HHEnumerationPlanView>().HasNoKey().ToView("HHEnumerationPlanView");
        builder.Entity<EnumerationAreaView>().HasNoKey().ToView("EnumerationAreaView");
        builder.Entity<EnumeratorsCCView>().HasNoKey().ToView("EnumeratorsCCView");
        builder.Entity<EnumerationTeamView>().HasNoKey().ToView("EnumerationTeamView");

        //Missa Program Views
        builder.Entity<ProgrammeView>().HasNoKey().ToView("ProgrammeView");
        builder.Entity<BenefitRuleView>().HasNoKey().ToView("BenefitRuleView");
        builder.Entity<TopUpView>().HasNoKey().ToView("TopUpView");
        builder.Entity<EligibilityCriteriaView>().HasNoKey().ToView("EligibilityCriteriaView");
        builder.Entity<PaymentFrequencyView>().HasNoKey().ToView("PaymentFrequencyView");       
        builder.Entity<ValidationListView>().HasNoKey().ToView("ValidationListView");
        builder.Entity<EligibilityTestsView>().HasNoKey().ToView("EligibilityTestsView");
        builder.Entity<EligibilityTestDetailsView>().HasNoKey().ToView("EligibilityTestDetailsView");       
        builder.Entity<BankView>().HasNoKey().ToView("BankView");
        builder.Entity<FacilityView>().HasNoKey().ToView("FacilityView");
        builder.Entity<FacilityTypeView>().HasNoKey().ToView("FacilityTypeView");
        builder.Entity<FinancialYearView>().HasNoKey().ToView("FinancialYearView");
        builder.Entity<GradeView>().HasNoKey().ToView("GradeView");
        builder.Entity<OVCBConfigurationView>().HasNoKey().ToView("OVCBConfigurationView");
        builder.Entity<ArrearsConfigurationView>().HasNoKey().ToView("ArrearsConfigurationView");
        builder.Entity<EnrolmentsView>().HasNoKey().ToView("EnrolmentsView");
        builder.Entity<EnrolmentDetailsView>().HasNoKey().ToView("EnrolmentDetailsView");
        builder.Entity<EnrolmentScheduleView>().HasNoKey().ToView("EnrolmentScheduleView");
        builder.Entity<EnrolmentScheduleDetailView>().HasNoKey().ToView("EnrolmentScheduleDetailView");
        builder.Entity<EnrolmentEventView>().HasNoKey().ToView("EnrolmentEventView");
        builder.Entity<EnrolmentEventDetailView>().HasNoKey().ToView("EnrolmentEventDetailView");
        builder.Entity<ProxieView>().HasNoKey().ToView("ProxieView");
        builder.Entity<PayPointView>().HasNoKey().ToView("PayPointView");
        builder.Entity<PaymentModeView>().HasNoKey().ToView("PaymentModeView");
        builder.Entity<PaymentDetailView>().HasNoKey().ToView("PaymentDetailView");


        #endregion SQL Views
    }
}
public class BaseAuditableEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity>
    where TEntity : BaseAuditableEntity<int>
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.Property(e => e.CreatedById).HasMaxLength(450);
        builder.Property(e => e.ModifiedById).HasMaxLength(450);
    }
}