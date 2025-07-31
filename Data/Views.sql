USE [LesothoMoGYSD]
GO
CREATE OR ALTER  VIEW [dbo].[SystemCodeDetailsView] AS
SELECT TOP 1000 t1.id, t1.Code,t1.Description,t1.description as Name,t2.code AS ParentCode,t2.Code as SystemCode,t1.OrderNo, t2.id as SystemCodeId
FROM SystemCodeDetails t1
INNER JOIN SystemCodes t2 ON t2.id=t1.SystemCodeId order by t1.OrderNo
GO

USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW UserSummaryView AS
SELECT
    u.Id,
    u.FirstName,
    u.MiddleName,
    u.Surname,
    u.Email,
    u.PhoneNumber,
    u.IsActive,
    u.CreatedOn,
	u.CountryCode,
	u.ModifiedOn,
    u.StatusId,
	u.IDNumber,
    u.PrivacyProtocolsAccepted,
	u.SourceOfRegistration,
    u.Documents,
	u.PhotoDocuments,
    s.Code AS StatusDescription,
    u.SexId,
    sx.Code AS SexDescription,
	u.IDTypeId,
	idt.Code As IDType,
    r.Id AS RoleId,
    r.Name AS RoleName,
    u.CreatedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByFullName,
    u.ModifiedById,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByFullName,

    -- Get Registration Centre info from RegistrationCentreVillages
    rc.Id AS  RegistrationCentreId,
    rc.CentreName AS RegistrationCentreName,

    -- Set IsSupervisor = 1 if user is Supervisor in RegistrationCentreVillages
 CAST(CASE 
        WHEN rc.SupervisorId IS NOT NULL THEN 1 
        ELSE 0 
    END AS BIT) AS IsSupervisor

FROM AspNetUsers u
LEFT JOIN SystemCodeDetails s ON u.StatusId = s.Id
LEFT JOIN SystemCodeDetails sx ON u.SexId = sx.Id
LEFT JOIN SystemCodeDetails idt ON u.IDTypeId = idt.Id
LEFT JOIN AspNetUserRoles ur ON u.Id = ur.UserId
LEFT JOIN AspNetRoles r ON ur.RoleId = r.Id
LEFT JOIN AspNetUsers cb ON u.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON u.ModifiedById = mb.Id

-- Optional: If you want to include registration centre details
LEFT JOIN RegistrationCentres rc ON rc.SupervisorId = u.Id AND rc.IsActive = 1;
GO

USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW MasterRegistrationView AS
SELECT
    mr.Id,
    mr.MasterPlanName,
    mr.Description,
    mr.FinancialYear,
    mr.ApprovedBudgetAmount,
    mr.EstimatedHHs,
	mr.CategorizationDiscrepancy,
	mr.ExchangeRate,
	mr.CurrencyAmount,
    mr.ProjectedStartDate,
    mr.ProjectedEndDate,
    mr.ActualStartDate,
    mr.ActualEndDate,

    mr.DataCollectionTypeId,
    dct.Code AS DataCollectionTypeName,

    mr.StatusId,
    st.Code AS StatusName,

    mr.CurrencyId,
    st.Code AS CurrencyName,

    mr.PlanTypeId,
    pt.Code AS PlanTypeName,

    mr.PMTFormulaId,
    pf.Name AS PMTFormulaName,

    mr.CreatedOn,
    mr.CreatedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
	cb.Email As CreatedByEmail,

    mr.ModifiedOn,
    mr.ModifiedById,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM MasterRegistrations mr
LEFT JOIN SystemCodeDetails dct ON mr.DataCollectionTypeId = dct.Id
LEFT JOIN SystemCodeDetails st ON mr.StatusId = st.Id
LEFT JOIN SystemCodeDetails cu ON mr.CurrencyId = cu.Id
LEFT JOIN SystemCodeDetails pt ON mr.PlanTypeId = pt.Id
LEFT JOIN PMTFormulas pf ON mr.PMTFormulaId = pf.Id
LEFT JOIN AspNetUsers cb ON mr.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON mr.ModifiedById = mb.Id;
GO


USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW RegistrationDistrictView AS
SELECT
    rd.Id,
    rd.MasterRegistrationPlanId,
    rd.DistrictId,
    rd.CurrentPopulation,
    rd.PriorCoverage,
    rd.TotalHHsToTarget,
    rd.CreatedOn,
    rd.CreatedById,
    rd.ModifiedOn,
    rd.ModifiedById,
    rd.EstimatedPopulation,
	rd.CurrentCoverage,
	rd.TotalPopulationToTarget,
    d.Name AS DistrictName,	
    mr.ProjectedEndDate,
    mr.MasterPlanName,
    mr.ProjectedStartDate,
    mr.ProjectedEndDate,	
	mr.StatusId as StatusId,
	st.Code As StatusName,
    
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,

    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM RegistrationDistricts rd
LEFT JOIN Districts d ON d.Id = rd.DistrictId
LEFT JOIN MasterRegistrations mr ON mr.Id = rd.MasterRegistrationPlanId
LEFT JOIN SystemCodeDetails st ON mr.StatusId = st.Id
LEFT JOIN AspNetUsers cb ON rd.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON rd.ModifiedById = mb.Id;
GO

USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW RegistrationDistrictCCView AS
SELECT
    rcc.Id,
    rcc.RegistrationDistrictId,
    rcc.CCId,
    rcc.ProjectedHHs,
    rcc.CreatedOn,
    rcc.CreatedById,
	mr.ProjectedStartDate AS DistrictProjectedStartDate,
	mr.ProjectedEndDate AS DistrictProjectedEndDate,
	dc.TotalHHsToTarget as TotalHHsToTarget,
	dc.DistrictId as DistrictId,
    rcc.ModifiedOn,
    rcc.ModifiedById,
	mr.MasterPlanName,
    mr.ProjectedStartDate,
    mr.ProjectedEndDate,	
	mr.StatusId as StatusId,
	st.Code As StatusName,
    cc.CommunityCouncilName,
    
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,

    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM RegistrationDistrictCCs rcc
LEFT JOIN CommunityCouncils cc ON cc.Id = rcc.CCId
LEFT JOIN RegistrationDistricts dc ON dc.Id = rcc.RegistrationDistrictId
LEFT JOIN MasterRegistrations mr ON mr.Id = dc.MasterRegistrationPlanId
LEFT JOIN SystemCodeDetails st ON mr.StatusId = st.Id
LEFT JOIN AspNetUsers cb ON rcc.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON rcc.ModifiedById = mb.Id;
GO

-- =========================================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW RegistrationCentreView AS
SELECT
    rc.Id,
    rc.CentreCode,
    rc.CentreName,
	rc.SupervisorId,
    rc.IsActive,
    rc.CreatedOn,
    rc.CreatedById,
    rc.ModifiedOn,
    rc.ModifiedById,
	
    sp.FirstName + ' ' + sp.MiddleName + ' ' + sp.Surname AS SupervisorName,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM RegistrationCentres rc
LEFT JOIN AspNetUsers sp ON rc.SupervisorId = sp.Id
LEFT JOIN AspNetUsers cb ON rc.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON rc.ModifiedById = mb.Id;
GO

-- ==========================================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW EnumeratorView AS
SELECT
    e.Id,
    e.UserId,
    e.RegistrationCentreId,
    e.IsSupervisor,
    e.IsActive,
    e.CreatedOn,
    e.CreatedById,
    e.ModifiedOn,
    e.ModifiedById,

    u.FirstName + ' ' + u.MiddleName + ' ' + u.Surname AS UserUserName,
    rc.CentreName AS RegistrationCentreName,
    
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM Enumerators e
LEFT JOIN AspNetUsers u ON e.UserId = u.Id
LEFT JOIN RegistrationCentres rc ON e.RegistrationCentreId = rc.Id
LEFT JOIN AspNetUsers cb ON e.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON e.ModifiedById = mb.Id;
GO
-- ============================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW PartnerView AS
SELECT 
	p.Id,
    p.OrgTypeId,
    ot.Code AS OrgTypeName,
    p.PartnerName,
    p.PhysicalAddress,
    p.PostalAddress,
	p.MobileNumberPrefix,
    p.TelephoneNumber,
    p.MobileNumber,
    p.EmailAddress,
	p.AreaOfOperation,
    p.DistrictId,
    d.Name AS DistrictName,
    p.RegistrationPurposeId,
    rp.Code AS RegistrationPurposeName,
    p.OtherPurpose,
    p.DetailedRemarks,
    p.PrivacyProtocolsAccepted,
    p.IsActive,
    p.StatusId,
    s.Code AS StatusName,
    p.CreatedById,
    p.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    Partners p
    LEFT JOIN SystemCodeDetails ot ON p.OrgTypeId = ot.Id
    LEFT JOIN Districts d ON p.DistrictId = d.Id
    LEFT JOIN SystemCodeDetails rp ON p.RegistrationPurposeId = rp.Id
    LEFT JOIN SystemCodeDetails s ON p.StatusId = s.Id
LEFT JOIN AspNetUsers cb ON p.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON p.ModifiedById = mb.Id;
GO

-- ========================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW ContactPersonView AS
SELECT 
    cp.Id,
    cp.PartnerId,
    p.PartnerName AS PartnerName,
	s.Code AS OrgTypeName,
    cp.ContactTypeId,
    cp.FirstName,
    cp.Surname,
    cp.MobileNumber,
    cp.EmailAddress,
    cp.CreatedById,
    cp.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    ContactPersons cp
    LEFT JOIN Partners p ON cp.PartnerId = p.Id
    LEFT JOIN SystemCodeDetails s ON p.OrgTypeId = s.Id
	LEFT JOIN AspNetUsers cb ON cp.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON cp.ModifiedById = mb.Id;
GO

-- ===========================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[DistrictRegistrationPlanView] AS
SELECT 
    drp.Id,
    drp.MasterRegistrationPlanId,
    mrp.MasterPlanName AS MasterRegistrationName,
    drp.DistrictId,
    d.Name AS DistrictName,
    drp.StatusId,
    s.Code AS StatusName,
    drp.RegistrationPlanName,
    drp.Description,
    drp.ApprovedBudgetAmount,
    drp.ExpectedNoHouseholds,
    drp.ProjectedStartDate,
    drp.ProjectedEndDate,
    drp.ActualStartDate,
    drp.ActualEndDate,
    drp.CreatedOn,
    drp.CreatedById,
    drp.ModifiedOn,
    drp.ModifiedById,
	cb.Email AS CreatedByEmail,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    DistrictRegistrationPlans drp
	LEFT JOIN MasterRegistrations mrp ON drp.MasterRegistrationPlanId = mrp.Id
	LEFT JOIN Districts d ON drp.DistrictId = d.Id
	LEFT JOIN SystemCodeDetails s ON drp.StatusId = s.Id
	LEFT JOIN AspNetUsers cb ON drp.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON drp.ModifiedById = mb.Id;
GO

-- =================================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[CCsRegisteredView] AS
SELECT 
    ccr.Id,
    ccr.DistrictRegistrationPlanId,
    drp.RegistrationPlanName AS DistrictRegistrationPlanName,
    ccr.CommunityCouncilId,
    cc.CommunityCouncilName AS CommunityCouncilName,
    ccr.StatusId,
    s.Code AS StatusName,
    ccr.CreatedOn,
    ccr.CreatedById,
    ccr.ModifiedOn,
    ccr.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    CCsRegistereds ccr
	LEFT JOIN DistrictRegistrationPlans drp ON ccr.DistrictRegistrationPlanId = drp.Id
	LEFT JOIN CommunityCouncils cc ON ccr.CommunityCouncilId = cc.Id
	LEFT JOIN SystemCodeDetails s ON ccr.StatusId = s.Id
	LEFT JOIN AspNetUsers cb ON drp.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON drp.ModifiedById = mb.Id;
GO

-- ========================================================================================>
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW dbo.CCRegistrationActivityView
AS
SELECT 
    ra.Id,
    ra.CCsRegisteredId,
    ccs.CommunityCouncilName AS CCsRegisteredName,
    ccs.CommunityCouncilName AS CommunityCouncilName,	
	ccs.Id as CommunityCouncilId,
    ra.ActivityId,
    a.Code AS ActivityName,
    ra.StatusId,
    s.Code AS StatusName,
    ra.ActivityDescription AS ActivityDescription,
    ra.NumberOfHouseholds,
    ra.PartnersId,
    p.PartnerName AS PartnersName,
	o.Code AS OrgTypeName,
    ra.ContactPersonId AS ContactPersonId,
    cp.FirstName + ' ' + cp.Surname AS ContactPersonName,
    cp.EmailAddress AS ContactPersonEmail,
	dr.Id as DistrictRegistrationPlanId,
	dr.RegistrationPlanName as DistrictRegistrationPlanName,
	ra.ProjectedStartDate,
	ra.ProjectedEndDate,
	ra.Documents As DocumentsJson,
    ra.CreatedOn,
	ra.IsRequired,
    ra.CreatedById,    
    ra.ModifiedOn,
    ra.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    CCRegistrationActivities ra
	LEFT JOIN CCsRegistereds cc ON ra.CCsRegisteredId = cc.Id
	LEFT JOIN DistrictRegistrationPlans dr ON cc.DistrictRegistrationPlanId = dr.Id	
	LEFT JOIN CommunityCouncils ccs ON cc.CommunityCouncilId = ccs.Id
	LEFT JOIN SystemCodeDetails a ON ra.ActivityId = a.Id
	LEFT JOIN SystemCodeDetails s ON ra.StatusId = s.Id
	LEFT JOIN Partners p ON ra.PartnersId = p.Id
	LEFT JOIN SystemCodeDetails o ON p.OrgTypeId = o.Id	
	LEFT JOIN ContactPersons cp ON ra.ContactPersonId = cp.Id
	LEFT JOIN AspNetUsers cb ON ra.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON ra.ModifiedById = mb.Id;
GO

-- ===============================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[VillageView]
AS
SELECT
    v.Id,
    v.Code,
    v.Name,
    v.CommunityCouncilId,
    cc.CommunityCouncilName AS CommunityCouncilName,
	e.Name AS ConstituencyName,
	cc.ConstituencyId,
    cc.DistrictId,
    d.Name AS DistrictName,
    v.IsActive,
    v.CreatedOn,
    v.CreatedById,    
    v.ModifiedOn,
    v.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM
    Villages v
	LEFT JOIN CommunityCouncils cc ON v.CommunityCouncilId = cc.Id
	Left Join Constituencies e On cc.ConstituencyId = e.Id
	LEFT JOIN Districts d ON cc.DistrictId = d.Id
	LEFT JOIN AspNetUsers cb ON v.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON v.ModifiedById = mb.Id;
GO
-- ========================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW ConstituencyView AS
SELECT
    ed.Id,
    ed.Code,
    ed.Name,
    ed.DistrictId,
    d.Name AS DistrictName,
    ed.Status
FROM Constituencies ed
INNER JOIN Districts d ON ed.DistrictId = d.Id;
GO
-- ========================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[CommunityCouncilView]
AS
SELECT
	cc.Id,
    cc.Code,
    cc.CommunityCouncilName AS CommunityCouncilName,
    cc.DistrictId,
    d.Name AS DistrictName,
	e.Name AS ConstituencyName,
	cc.ConstituencyId,
    cc.IsActive,
    cc.CreatedOn,
    cc.CreatedById,    
    cc.ModifiedOn,
    cc.ModifiedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM
    CommunityCouncils cc
	LEFT JOIN Districts d ON cc.DistrictId = d.Id
	Left Join Constituencies e On cc.ConstituencyId = e.Id
	LEFT JOIN AspNetUsers cb ON cc.CreatedById = cb.Id
	LEFT JOIN AspNetUsers mb ON cc.ModifiedById = mb.Id;
GO

-- =========================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW RegistrationCentreVillageView AS
SELECT
    v.Id AS Id,
    rc.Id AS RegistrationCentreId,
    rc.CentreName AS RegistrationCentreName,
    rc.CentreCode AS RegistrationCentreCode,
    rc.IsActive AS RegistrationCentreIsActive,
    vg.Id AS VillageId,
    vg.Name AS VillageName,	
	cc.Id As CommunityCouncilId,
    cc.CommunityCouncilName,
	e.Name AS ConstituencyName,
	cc.ConstituencyId,
	d.Id As DistrictId,
    d.Name AS DistrictName,
    rc.SupervisorId AS SupervisorId,
	su.FirstName + ' ' + su.MiddleName + ' ' + su.Surname AS SupervisorName,
    rc.CreatedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    rc.ModifiedById,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName

FROM RegistrationCentreVillages v
INNER JOIN RegistrationCentres rc ON v.RegistrationCentreId = rc.Id
INNER JOIN Villages vg ON v.VillageId = vg.Id
LEFT JOIN CommunityCouncils cc ON vg.CommunityCouncilId = cc.Id
Left Join Constituencies e On cc.ConstituencyId = e.Id
LEFT JOIN Districts d ON cc.DistrictId = d.Id
LEFT JOIN AspNetUsers su ON rc.SupervisorId = su.Id
LEFT JOIN AspNetUsers cb ON rc.CreatedById = cb.Id
LEFT JOIN AspNetUsers mb ON rc.ModifiedById = mb.Id;
GO
-- ===============================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[HHListingPlanView] AS
SELECT 
    hlp.Id,
	
	hlp.HHListingActivityName,

    hlp.DistrictId,
    d.Name AS DistrictName,

    hlp.DistrictRegistrationPlanId,
    drp.RegistrationPlanName AS DistrictRegistrationPlanName,
	drp.DataCollectionTypeId,
	drp.DataCollectionTypeName,
    mrp.MasterPlanName AS MasterRegistrationPlanName,
    drp.ExpectedNoHouseholds,
	
    hlp.PartnersId,
    pr.PartnerName AS PartnerName,

    hlp.ContactPersonId,
    c.FirstName + ' ' + c.Surname AS ContactPersonName,
	
	
    hlp.StatusId,
    s.Code AS StatusName,
    hlp.ProjectedStartDate,
    hlp.ProjectedEndDate,
    hlp.ActualStartDate,
    hlp.ActualEndDate,
    hlp.CreatedOn,
    hlp.CreatedById,
    cb.FirstName + ' ' + ISNULL(cb.MiddleName, '') + ' ' + cb.Surname AS CreatedByName,
    cb.Email AS CreatedByEmail,
    hlp.ModifiedOn,
    hlp.ModifiedById,
    mb.FirstName + ' ' + ISNULL(mb.MiddleName, '') + ' ' + mb.Surname AS ModifiedByName
FROM 
    HHListingPlans hlp
	LEFT JOIN Districts d ON hlp.DistrictId = d.Id
	LEFT JOIN DistrictRegistrationPlanView drp ON hlp.DistrictRegistrationPlanId = drp.Id
	LEFT JOIN MasterRegistrations mrp ON drp.MasterRegistrationPlanId = mrp.Id
	LEFT JOIN Partners pr ON hlp.PartnersId = pr.Id
	LEFT JOIN ContactPersons c ON hlp.ContactPersonId = c.Id
    LEFT JOIN SystemCodeDetails s ON hlp.StatusId = s.Id
    LEFT JOIN AspNetUsers cb ON hlp.CreatedById = cb.Id
    LEFT JOIN AspNetUsers mb ON hlp.ModifiedById = mb.Id
GO

-- ==================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[CbcActivitiesView] AS
SELECT 
    ca.Id,
    ca.HHListingPlanId,
	hh.HHListingActivityName as HHListingActivityName,
    ca.DateCBCConducted,
    ca.TotalNumberofCBCParticipants,
	ca.CommunityCouncilId,
    cc.CommunityCouncilName,
	ca.StatusId,
    s.Code AS StatusName,
	d.Id As DistrictId,
    d.Name AS DistrictName,
	ca.PartnerId,
	p.PartnerName AS PartnerName,
	ca.ContactPersonId,
	cp.FirstName + ' ' + cp.Surname AS ContactPersonName,
    ca.CreatedOn,
    ca.CreatedById,
    cb.FirstName + ' ' + cb.MiddleName + ' ' + cb.Surname AS CreatedByName,
    ca.ModifiedOn,
    ca.ModifiedById,
    mb.FirstName + ' ' + mb.MiddleName + ' ' + mb.Surname AS ModifiedByName
FROM 
    CbcActivities ca
	LEFT JOIN HHListingPlans hh ON hh.Id = ca.HHListingPlanId
	LEFT JOIN SystemCodeDetails s ON ca.StatusId = s.Id
    LEFT JOIN Districts d ON hh.DistrictId = d.Id
	LEFT Join CommunityCouncils cc ON cc.Id = ca.CommunityCouncilId
    LEFT JOIN AspNetUsers cb ON ca.CreatedById = cb.Id
    LEFT JOIN AspNetUsers mb ON ca.ModifiedById = mb.Id
	LEFT JOIN Partners p ON ca.PartnerId = p.Id
	LEFT JOIN ContactPersons cp ON ca.ContactPersonId = cp.Id
GO

-- ===============================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW [dbo].[CbcActivityVillageView] AS
SELECT 
    ca.CbcActivityId,
	ca.VillageId,
	v.Name AS VillageName
FROM 
    CbcActivityVillages ca
	LEFT JOIN Villages v ON v.Id = ca.VillageId
GO

-- ===============================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW dbo.DistrictCensusHHDataView AS
SELECT
    dchh.Id,
    dchh.DistrictId,
    d.Name AS DistrictName,
    dchh.Year,
    dchh.HouseholdData,
    dchh.PopulationData
FROM
    DistrictCensusHHDatas dchh
INNER JOIN
    Districts d ON dchh.DistrictId = d.Id;
GO
-- ==================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW dbo.DistrictView AS
SELECT
    d.Id,
    d.Code,
    d.Name,
    d.IsActive,
    d.CountryId,
    c.Year AS CensusYear,
    c.HouseholdData AS CensusHouseholdData,
    c.PopulationData AS CensusPopulationData
FROM
    Districts d
OUTER APPLY (
    SELECT TOP 1 
        Year,
        HouseholdData,
        PopulationData
    FROM 
        DistrictCensusHHDatas
    WHERE 
        DistrictId = d.Id
    ORDER BY Year DESC
) c;
GO
-- =======================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW CCHouseHoldListingAreaView AS
SELECT
    a.Id,
    a.CCId,
    cc.CommunityCouncilName AS CommunityCouncilName,
    a.HHListingPlanId,
    hhl.HHListingActivityName AS HHListingPlanName
FROM
    CCHouseHoldListingAreas a
LEFT JOIN
    CommunityCouncils cc ON a.CCId = cc.Id
LEFT JOIN
    HHListingPlans hhl ON a.HHListingPlanId = hhl.Id;

GO
-- =======================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW HHListingView AS
SELECT 
    h.Id,
    h.Guid,
    h.HHListingPlanId,
    p.HHListingActivityName AS HHListingActivityName,
    h.VillageId,
    v.Name AS VillageName,
	v.CommunityCouncilId,
    cc.CommunityCouncilName AS CommunityCouncilName,
    cc.DistrictId,
    d.Name AS DistrictName,
    h.StatusId,
    s.Code AS StatusName,
    RTRIM(
        COALESCE(h.HHHeadFirstName, '') + ' ' +
        COALESCE(h.HHHeadMiddleName + ' ', '') +
        COALESCE(h.HHHeadSurname, '')
    ) AS HHHeadFullName,
    h.NationalId,
    h.NationalIDPhoto,
    h.HHSize,
    h.GeoCoordinates,
    h.PhysicalAddress,
	h.CreatedOn,
    h.CreatedById,
    cb.FirstName + ' ' + ISNULL(cb.MiddleName, '') + ' ' + cb.Surname AS CreatedByName,
    cb.Email AS CreatedByEmail,
    h.ModifiedOn,
    h.ModifiedById,
    mb.FirstName + ' ' + ISNULL(mb.MiddleName, '') + ' ' + mb.Surname AS ModifiedByName
FROM 
    HHListings h
	LEFT JOIN HHListingPlans p ON h.HHListingPlanId = p.Id
	LEFT JOIN Villages v ON h.VillageId = v.Id
	LEFT JOIN CommunityCouncils cc ON v.CommunityCouncilId = cc.Id
	LEFT JOIN Districts d ON cc.DistrictId = d.Id
	LEFT JOIN SystemCodeDetails s ON h.StatusId = s.Id
	LEFT JOIN AspNetUsers cb ON h.CreatedById = cb.Id
    LEFT JOIN AspNetUsers mb ON h.ModifiedById = mb.Id
	
GO

-- ===============================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW RoleView AS
SELECT 
    r.Id,
    r.Name,
    r.SystemCodeDetailId,
    scd.Code AS AccessLevel,
    r.IsSelfRegister,
    r.IsActive,
	r.CreatedOn,
    r.CreatedById,
    cb.FirstName + ' ' + ISNULL(cb.MiddleName, '') + ' ' + cb.Surname AS CreatedByName,
    cb.Email AS CreatedByEmail,
    r.ModifiedOn,
    r.ModifiedById,
    mb.FirstName + ' ' + ISNULL(mb.MiddleName, '') + ' ' + mb.Surname AS ModifiedByName
FROM 
    AspNetRoles r
	LEFT JOIN SystemCodeDetails scd ON r.SystemCodeDetailId = scd.Id
	LEFT JOIN AspNetUsers cb ON r.CreatedById = cb.Id
    LEFT JOIN AspNetUsers mb ON r.ModifiedById = mb.Id
GO

-- ===============================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW DistrictUserEmailNotificationView AS
	SELECT DISTINCT usv.Email, mr.Id as MasterRegistrationId, usv.FirstName as Name
		FROM MasterRegistrations mr
		INNER JOIN RegistrationDistrictView rdv
			ON mr.Id = rdv.MasterRegistrationPlanId
		INNER JOIN UserDistrictAssignments uda
			ON rdv.DistrictId = uda.DistrictId
		INNER JOIN UserSummaryView usv
			ON uda.ApplicationUserId = usv.Id
GO

-- =======================================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW CbcCategorizationView AS
SELECT
	cc.Id,
    cc.Guid,
    cc.CBCActivityId,
	cc.ValidatedById,
	vb.Code AS ValidatedBy,
	cc.ValidatedNames,
	cc.StatusId,
    s.Code AS StatusName,
	hp.HHListingActivityName AS CBCPlanName,
    cc.HHListingId,
    hl.HHHeadFirstName + ' ' + hl.HHHeadSurname AS HHHeadNames,
    cc.CBCOutcomeCategoryId,
    oc.Code AS CBCOutcomeCategoryName,
    cc.CBCOutcomeCategoryReasonId,
    ocr.Code AS CBCOutcomeCategoryReasonName,
    cc.DateCBC,
    -- Additional fields from related tables as needed
    cc.CreatedOn,
    cc.CreatedById,
	cb.FirstName + ' ' + ISNULL(cb.MiddleName, '') + ' ' + cb.Surname AS CreatedByName,
    cc.ModifiedOn,
    cc.ModifiedById,
	mb.FirstName + ' ' + ISNULL(mb.MiddleName, '') + ' ' + mb.Surname AS ModifiedByName
FROM 
    CbcCategorizations cc
	LEFT JOIN CbcActivities ca ON cc.CBCActivityId = ca.Id
	LEFT JOIN SystemCodeDetails s ON cc.StatusId = s.Id
	LEFT JOIN HHListingPlans hp ON ca.HHListingPlanId = hp.Id
	LEFT JOIN HHListings hl ON cc.HHListingId = hl.Id
	LEFT JOIN SystemCodeDetails oc ON cc.CBCOutcomeCategoryId = oc.Id
	LEFT JOIN SystemCodeDetails ocr ON cc.CBCOutcomeCategoryReasonId = ocr.Id
	LEFT JOIN SystemCodeDetails vb ON vb.Id = cc.ValidatedById
	LEFT JOIN AspNetUsers cb ON cc.CreatedById = cb.Id
    LEFT JOIN AspNetUsers mb ON cc.ModifiedById = mb.Id;
	
GO

-- ======================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW HHEnumerationPlanView AS
SELECT 
    p.Id,
    p.Name,
    p.Description,
    p.ProjectedStartDate,
    p.ProjectedEndDate,
    p.ActualStartDate,
    p.ActualEndDate,
    p.StatusId,
    ISNULL(s.Code, '') AS StatusName,
    p.RegistrationCentreId,
    ISNULL(rc.CentreName, '') AS RegistrationCentreName,
	d.Id AS DistrictId,
	d.Name AS DistrictName,
	p.HHListingPlanId,
	hlp.HHListingActivityName AS HHListingPlanName
    --p.CCRegistrationActivityId,
    --ISNULL(cc.ActivityDescription, '') AS CCRegistrationActivityName,
    --p.PlanTypeId,
    --ISNULL(pt.Name, '') AS PlanTypeName
FROM HHEnumerationPlans p
LEFT JOIN SystemCodeDetails s ON p.StatusId = s.Id
LEFT JOIN RegistrationCentres rc ON p.RegistrationCentreId = rc.Id
LEFT JOIN HHListingPlanView hlp ON p.HHListingPlanId = hlp.Id
LEFT JOIN Districts d ON hlp.DistrictId = d.Id
--LEFT JOIN CCRegistrationActivities cc ON p.CCRegistrationActivityId = cc.Id
--LEFT JOIN PlanTypes pt ON p.PlanTypeId = pt.Id;
GO

-- ======================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW EnumerationAreaView AS
SELECT
    ea.Id,
    ea.Name,
    hplan.Id AS HHEnumerationPlanId,
    hplan.Name AS HHEnumerationPlanName,
    d.Id AS DistrictId,
    d.Name AS DistrictName,
    cc.Id AS CommunityCouncilId,
    cc.CommunityCouncilName AS CommunityCouncilName,
    v.Id AS VillageId,
    v.Name AS VillageName,
    cra.Id AS CCRegistrationActivityId,
    cra.ActivityDescription AS CCRegistrationActivityName

FROM EnumerationAreas ea

INNER JOIN HHEnumerationPlans hplan ON hplan.Id = ea.HHEnumerationPlanId

-- Link EnumerationArea to Villages
INNER JOIN EnumerationAreaVillages eav ON eav.EnumerationAreaId = ea.Id
INNER JOIN Villages v ON v.Id = eav.VillageId
INNER JOIN CommunityCouncils cc ON cc.Id = v.CommunityCouncilId
INNER JOIN Districts d ON d.Id = cc.DistrictId
LEFT JOIN HHEnumerationPlanCCs hhe ON hhe.HHEnumerationPlanId = ea.HHEnumerationPlanId
-- Get Activity linked to Village & CC (assuming this logic)
LEFT JOIN CCRegistrationActivities cra 
    ON cra.Id = hhe.CCRegistrationActivityId
	
GO
-- ======================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW EnumerationTeamView AS
SELECT 
    et.Id,
    et.EnumerationAreaId,
    ea.Name AS EnumerationAreaName,
	ea.HHEnumerationPlanId AS HHEnumerationPlanId,
	ea.Name AS HHEnumerationPlanName,
    e.Id AS EnumeratorId,
    e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.Surname AS EnumeratorNames,
    et.IsSupervisor,
    d.Id AS DistrictId,
    d.Name AS DistrictName,
    cc.Id AS CommunityCouncilId,
    cc.CommunityCouncilName AS CommunityCouncilName,
    v.Id AS VillageId,
    v.Name AS VillageName
FROM EnumerationTeams et
INNER JOIN EnumerationAreas ea ON ea.Id = et.EnumerationAreaId
INNER JOIN AspNetUsers e ON et.EnumeratorId = e.Id
LEFT JOIN UserDistrictAssignments uda ON uda.ApplicationUserId = et.EnumeratorId
LEFT JOIN Districts d ON uda.DistrictId = d.Id
LEFT JOIN UserCommunityCouncilAssignments uca ON uca.ApplicationUserId = et.EnumeratorId
LEFT JOIN CommunityCouncils cc ON uca.CommunityCouncilId = cc.Id
LEFT JOIN UserVillageAssignments uva ON uva.ApplicationUserId = et.EnumeratorId
LEFT JOIN Villages v ON uva.VillageId = v.Id;
GO
-- ======================================================================================
USE [LesothoMoGYSD]
GO
CREATE OR ALTER VIEW EnumeratorsCCView AS
SELECT 
    e.Id,
	e.FirstName + ' ' + ISNULL(e.MiddleName, '') + ' ' + e.Surname AS EnumeratorNames,
    v.Id AS CCId,
	v.CommunityCouncilName AS CCName,
	r.Name AS RoleName

FROM AspNetUsers e
LEFT JOIN Enumerators en ON en.UserId = e.Id
INNER JOIN UserCommunityCouncilAssignments uva ON uva.ApplicationUserId = en.UserId
LEFT JOIN CommunityCouncils v ON uva.CommunityCouncilId = v.Id
LEFT JOIN AspNetRoles r ON r.Id = e.RoleId
GO
-- ======================================================================================
