USE [LesothoMoGYSD];
GO

IF OBJECT_ID('dbo.ProgrammeView', 'V') IS NOT NULL
    DROP VIEW dbo.ProgrammeView;
GO

CREATE VIEW dbo.ProgrammeView AS
SELECT
    p.Id,
    p.Name,
    p.Code,
    p.AssistanceUnitId,
    au_scd.Description AS AssistanceUnitDescription,
    p.ProgramTypeId,
    pt_scd.Description AS ProgramTypeDescription,
    p.IsActive,
    p.ProxiesAllowed,
    p.Amount,
    p.ColourScheme,
    p.PaymentFrequencyId,
    pf.Name AS PaymentFrequencyDescription,
    p.ProofOfLifeSpan,
    p.ProofOfLifeSpanId,
    pols.Description AS ProofOfLifeSpanValueDescription,
    p.CreatedById,
    creator.UserName AS CreatedByUserName,
    p.CreatedOn,
    p.ModifiedById,
    modifier.UserName AS ModifiedByUserName,
    p.ModifiedOn,

    -- ✅ Payment Modes
    (
        SELECT ISNULL('[' + STRING_AGG(CONVERT(varchar, pm.PaymentModesAllowedId), ',') + ']', '[]')
        FROM ProgrammePaymentModesAllowed pm
        WHERE pm.ProgrammesId = p.Id
    ) AS PaymentModesAllowedIds,

    (
        SELECT ISNULL(
            '[' + STRING_AGG('"' + REPLACE(scd.Description, '"', '""') + '"', ',') + ']',
            '[]'
        )
        FROM ProgrammePaymentModesAllowed pm
        INNER JOIN SystemCodeDetails scd ON scd.Id = pm.PaymentModesAllowedId
        WHERE pm.ProgrammesId = p.Id
    ) AS PaymentModesAllowedDescriptions

FROM dbo.Programmes p
LEFT JOIN dbo.SystemCodeDetails au_scd ON p.AssistanceUnitId = au_scd.Id
LEFT JOIN dbo.SystemCodeDetails pt_scd ON p.ProgramTypeId = pt_scd.Id
LEFT JOIN dbo.SystemCodeDetails pols ON p.ProofOfLifeSpanId = pols.Id
LEFT JOIN dbo.PaymentFrequencies pf ON p.PaymentFrequencyId = pf.Id
LEFT JOIN dbo.AspNetUsers creator ON p.CreatedById = creator.Id
LEFT JOIN dbo.AspNetUsers modifier ON p.ModifiedById = modifier.Id;
GO


--------------------------------------------------------------------------------
-- View: PaymentFrequencyView
--------------------------------------------------------------------------------
IF OBJECT_ID('dbo.PaymentFrequencyView', 'V') IS NOT NULL
    DROP VIEW dbo.PaymentFrequencyView;
GO

CREATE VIEW dbo.PaymentFrequencyView
AS
SELECT
    pf.Id,
    pf.Name,
    pf.FrequencyId,
    scd.Description AS FrequencyName,
    pf.CreatedById,
    creator.UserName AS CreatedByUserName,
    pf.CreatedOn,
    pf.ModifiedById,
    modifier.UserName AS ModifiedByUserName,
    pf.ModifiedOn,
    pf.IsActive
FROM
    dbo.PaymentFrequencies AS pf
LEFT JOIN dbo.SystemCodeDetails scd ON pf.FrequencyId = scd.Id
LEFT JOIN dbo.AspNetUsers AS creator ON pf.CreatedById = creator.Id
LEFT JOIN dbo.AspNetUsers AS modifier ON pf.ModifiedById = modifier.Id;
GO


--------------------------------------------------------------------------------
-- View: BenefitRuleView
--------------------------------------------------------------------------------
IF OBJECT_ID('dbo.BenefitRuleView', 'V') IS NOT NULL
    DROP VIEW dbo.BenefitRuleView;
GO

CREATE VIEW dbo.BenefitRuleView
AS
SELECT
    br.Id AS BenefitRuleId,
    br.ProgrammeId,
    prog.Name AS ProgrammeName,
    prog.Code AS ProgrammeCode,

    br.MinHHMembers,
    br.MaxHHMembers,
    br.Amount AS BenefitRuleAmount,
    br.IsActive AS BenefitRuleIsActive,

    br.CreatedOn AS BenefitRuleCreatedOn,
    br.CreatedById AS BenefitRuleCreatedById,
    creator.UserName AS BenefitRuleCreatedByUserName,
    br.ModifiedOn AS BenefitRuleModifiedOn,
    br.ModifiedById AS BenefitRuleModifiedById,
    modifier.UserName AS BenefitRuleModifiedByUserName
FROM
    dbo.BenefitRules AS br
INNER JOIN
    dbo.Programmes AS prog
    ON br.ProgrammeId = prog.Id
LEFT JOIN
    dbo.AspNetUsers AS creator
    ON br.CreatedById = creator.Id
LEFT JOIN
    dbo.AspNetUsers AS modifier
    ON br.ModifiedById = modifier.Id;
GO

--------------------------------------------------------------------------------
-- View: EligibilityCriteriaView
--------------------------------------------------------------------------------

IF OBJECT_ID('dbo.EligibilityCriteriaView', 'V') IS NOT NULL
    DROP VIEW dbo.EligibilityCriteriaView;
GO

CREATE VIEW dbo.EligibilityCriteriaView
AS
WITH AggregatedLocations AS (
    -- Aggregate all districts for each criterion into single strings
    SELECT
        ecl.EligibilityCriteriaId,
        STRING_AGG(CAST(ecl.DistrictId AS NVARCHAR(MAX)), ',') AS LocationIds,
        STRING_AGG(d.Name, ', ') AS LocationNames
    FROM
        dbo.EligibilityCriteriaLocations AS ecl
    INNER JOIN
        dbo.Districts AS d ON ecl.DistrictId = d.Id
    GROUP BY
        ecl.EligibilityCriteriaId
),
AggregatedOtherProgrammes AS (
    -- Aggregate all must-not-be-enrolled-in programmes for each criterion into single strings
    SELECT
        eop.EligibilityCriteriaId,
        STRING_AGG(CAST(eop.ProgrammeId AS NVARCHAR(MAX)), ',') AS EnrolledInOtherProgrammeIds,
        STRING_AGG(p.Name, ', ') AS EnrolledInOtherProgrammeNames
    FROM
        dbo.EnrolledInOtherProgrammes AS eop
    INNER JOIN
        dbo.Programmes AS p ON eop.ProgrammeId = p.Id
    GROUP BY
        eop.EligibilityCriteriaId
),
AggregatedVulnerabilityTypes AS (
    -- Aggregate all Vulnerability Types for each criterion into single strings
    SELECT
        ecvt.EligibilityCriteriaId,
        STRING_AGG(CAST(ecvt.VulnerabilityTypeId AS NVARCHAR(MAX)), ',') AS VulnerabilityTypeIds,
        STRING_AGG(scd.Description, ', ') AS VulnerabilityTypeNames
    FROM
        dbo.EligibilityCriteriaVulnerabilityTypes AS ecvt
    INNER JOIN
        dbo.SystemCodeDetails AS scd ON ecvt.VulnerabilityTypeId = scd.Id
    GROUP BY
        ecvt.EligibilityCriteriaId
),
AggregatedPovertyStatuses AS (
    -- Aggregate all Poverty Statuses for each criterion into single strings
    SELECT
        ecps.EligibilityCriteriaId,
        STRING_AGG(CAST(ecps.PovertyStatusId AS NVARCHAR(MAX)), ',') AS PovertyStatusIds,
        STRING_AGG(scd.Description, ', ') AS PovertyStatusNames
    FROM
        dbo.EligibilityCriteriaPovertyStatus AS ecps
    INNER JOIN
        dbo.SystemCodeDetails AS scd ON ecps.PovertyStatusId = scd.Id
    GROUP BY
        ecps.EligibilityCriteriaId
),
AggregatedCBCCategorisations AS (
    -- Aggregate all Community Based Categorisations for each criterion into single strings
    SELECT
        eccbc.EligibilityCriteriaId,
        STRING_AGG(CAST(eccbc.CBCId AS NVARCHAR(MAX)), ',') AS CBCIds,
        STRING_AGG(scd.Description, ', ') AS CBCNames
    FROM
        dbo.EligibilityCriteriaCBCs AS eccbc
    INNER JOIN
        dbo.SystemCodeDetails AS scd ON eccbc.CBCId = scd.Id
    GROUP BY
        eccbc.EligibilityCriteriaId
)
SELECT
    ec.Id,
    ec.ProgrammeId,
    prog.Name AS ProgrammeName,
    
    ec.AssistanceUnitId,
    scd_au.Description AS AssistanceUnitName,

    ec.StartAge,
    ec.EndAge,

    ec.CommunityValidationStatusId,
    scd_cvs.Description AS CommunityValidationStatusName,

    ec.HasMoDClearance,
    ec.HasDisabilityRegistryRegistration,
    ec.HasSchoolEnrolment,

    -- Get aggregated multi-select data from CTEs
    agg_loc.LocationIds,
    agg_loc.LocationNames,
    agg_prog.EnrolledInOtherProgrammeIds,
    agg_prog.EnrolledInOtherProgrammeNames,
    agg_vt.VulnerabilityTypeIds,
    agg_vt.VulnerabilityTypeNames,
    agg_ps.PovertyStatusIds,
    agg_ps.PovertyStatusNames,
    agg_cbc.CBCIds,
    agg_cbc.CBCNames,

    ec.IsActive,
    ec.CreatedOn,
    creator.UserName AS CreatedByUserName,
    ec.ModifiedOn,
    modifier.UserName AS ModifiedByUserName
FROM
    dbo.EligibilityCriterias AS ec
INNER JOIN
    dbo.Programmes AS prog ON ec.ProgrammeId = prog.Id
LEFT JOIN
    dbo.SystemCodeDetails AS scd_au ON ec.AssistanceUnitId = scd_au.Id
LEFT JOIN
    dbo.SystemCodeDetails AS scd_cvs ON ec.CommunityValidationStatusId = scd_cvs.Id
LEFT JOIN
    AggregatedLocations AS agg_loc ON ec.Id = agg_loc.EligibilityCriteriaId
LEFT JOIN
    AggregatedOtherProgrammes AS agg_prog ON ec.Id = agg_prog.EligibilityCriteriaId
LEFT JOIN
    AggregatedVulnerabilityTypes AS agg_vt ON ec.Id = agg_vt.EligibilityCriteriaId
LEFT JOIN
    AggregatedPovertyStatuses AS agg_ps ON ec.Id = agg_ps.EligibilityCriteriaId
LEFT JOIN
    AggregatedCBCCategorisations AS agg_cbc ON ec.Id = agg_cbc.EligibilityCriteriaId
LEFT JOIN
    dbo.AspNetUsers AS creator ON ec.CreatedById = creator.Id
LEFT JOIN
    dbo.AspNetUsers AS modifier ON ec.ModifiedById = modifier.Id;
GO

--------------------------------------------------------------------------------
-- View: TopUpView
--------------------------------------------------------------------------------

IF OBJECT_ID('dbo.TopUpView', 'V') IS NOT NULL
    DROP VIEW dbo.TopUpView;
GO

CREATE VIEW dbo.TopUpView
AS
SELECT
    tu.Id AS Id,                         
    tu.ProgrammeId,                     
    prog.Name AS ProgrammeName,        
    tu.Name,                            
    tu.Amount,                         
    tu.IsActive,                       

 
    tu.CreatedOn,
    tu.CreatedById,
    creator.UserName AS CreatedByUserName,
    tu.ModifiedOn,
    tu.ModifiedById,
    modifier.UserName AS ModifiedByUserName

FROM dbo.TopUps AS tu
INNER JOIN dbo.Programmes AS prog ON tu.ProgrammeId = prog.Id
LEFT JOIN dbo.AspNetUsers AS creator ON tu.CreatedById = creator.Id
LEFT JOIN dbo.AspNetUsers AS modifier ON tu.ModifiedById = modifier.Id;
GO



-- ========================
-- Drop the old view if it exists, to ensure a clean creation
IF OBJECT_ID('dbo.EligibilityTestsView', 'V') IS NOT NULL
    DROP VIEW dbo.EligibilityTestsView;
GO

-- Create the new view with the correct structure to match your C# model
CREATE VIEW dbo.EligibilityTestsView AS
SELECT 
    et.Id,
    et.Description,
    et.Quota,
    et.ProgrammeId,
    p.Name AS ProgrammeName,
    
    -- --- Aggregate District Info (Many-to-Many) ---
    -- Creates a comma-separated string of District IDs, e.g., '1, 5, 12'
    (
        SELECT STRING_AGG(CAST(d.Id AS NVARCHAR(MAX)), ', ')
        FROM dbo.EligibilityTestDistricts det_join -- <-- REPLACE WITH YOUR REAL JOIN TABLE NAME
        JOIN dbo.Districts d ON det_join.DistrictId = d.Id
        WHERE det_join.EligibilityTestId = et.Id
    ) AS DistrictIds,

    -- Creates a comma-separated string of District Names, e.g., 'Berea, Maseru, Mohale''s Hoek'
    (
        SELECT STRING_AGG(d.Name, ', ')
        FROM dbo.EligibilityTestDistricts det_join -- <-- REPLACE WITH YOUR REAL JOIN TABLE NAME
        JOIN dbo.Districts d ON det_join.DistrictId = d.Id
        WHERE det_join.EligibilityTestId = et.Id
    ) AS DistrictNames,

    -- --- Optional Single-Location Info ---
    et.CommunityCouncilId,
    cc.CommunityCouncilName,
    et.VillageId,
    v.Name AS Village, -- This alias matches your C# class property name
    
    -- --- Aggregate Counts from a Subquery ---
    COALESCE(Aggregates.TotalProcessed, 0) AS TotalProcessed,
    COALESCE(Aggregates.TotalSelected, 0) AS TotalSelected,
    COALESCE(Aggregates.TotalWaitlisted, 0) AS TotalWaitlisted,
    COALESCE(Aggregates.TotalNotEligible, 0) AS TotalNotEligible,
    COALESCE(Aggregates.TotalEligiblePreQuota, 0) AS TotalEligiblePreQuota,

    -- --- Auditing Info ---
    et.CreatedOn,
    et.CreatedById,
    u_created.UserName AS CreatedByUserName,
    et.ModifiedOn,
    et.ModifiedById,
    u_modified.UserName AS ModifiedByUserName
FROM 
    dbo.EligibilityTests et
INNER JOIN 
    dbo.Programmes p ON et.ProgrammeId = p.Id
-- Use LEFT JOINs for optional relationships
LEFT JOIN
    dbo.CommunityCouncils cc ON et.CommunityCouncilId = cc.Id
LEFT JOIN
    dbo.Villages v ON et.VillageId = v.Id
LEFT JOIN 
    dbo.AspNetUsers u_created ON et.CreatedById = u_created.Id
LEFT JOIN
    dbo.AspNetUsers u_modified ON et.ModifiedById = u_modified.Id
-- Subquery to get aggregated counts for each test
LEFT JOIN (
    SELECT
        etd.EligibilityTestId,
        COUNT(etd.Id) AS TotalProcessed,
        SUM(CASE WHEN scd.Code = 'Selected' THEN 1 ELSE 0 END) AS TotalSelected,
        SUM(CASE WHEN scd.Code = 'WaitListed' THEN 1 ELSE 0 END) AS TotalWaitlisted,
        SUM(CASE WHEN scd.Code = 'Not Eligible' THEN 1 ELSE 0 END) AS TotalNotEligible,
        SUM(CASE WHEN scd.Code IN ('Eligible', 'Selected', 'WaitListed') THEN 1 ELSE 0 END) AS TotalEligiblePreQuota
    FROM
        dbo.EligibilityTestDetails etd
    JOIN 
        dbo.SystemCodeDetails scd ON etd.EligibilityStatusId = scd.Id
    GROUP BY
        etd.EligibilityTestId
) AS Aggregates ON et.Id = Aggregates.EligibilityTestId;
GO
-- VIEW: ValidationListView (Modified with Aggregate Counts)
IF OBJECT_ID('dbo.ValidationListView', 'V') IS NOT NULL
    DROP VIEW dbo.ValidationListView;
GO

CREATE VIEW dbo.ValidationListView AS
SELECT 
    vl.Id,
    
    -- Aggregated Counts from subqueries
    COALESCE(CouncilAggregates.TotalVillages, 0) AS TotalVillages,
    COALESCE(CouncilAggregates.TotalHouseholds, 0) AS TotalHouseholds,
    COALESCE(MemberAggregates.TotalMembers, 0) AS TotalMembers,
    COALESCE(MemberAggregates.ValidatedMembers, 0) AS ValidatedMembers,
    COALESCE(MemberAggregates.PendingValidation, 0) AS PendingValidation,
    
    -- Corrected Date Fields to match the entity
    vl.StartDate,
    vl.EndDate,
    
    
    d.Id AS DistrictId,
    d.Name AS DistrictName,
    vl.CommunityCouncilId,
    cc.CommunityCouncilName,
    vl.CreatedById,
    -- Combine user's name parts, falling back to UserName
    CASE 
        WHEN u.FirstName IS NOT NULL 
        THEN CONCAT(u.FirstName, 
                    CASE WHEN u.MiddleName IS NOT NULL THEN ' ' + u.MiddleName ELSE '' END, 
                    CASE WHEN u.Surname IS NOT NULL THEN ' ' + u.Surname ELSE '' END)
        ELSE u.UserName
    END AS CreatedByName,
    vl.CreatedOn
FROM 
    dbo.ValidationLists vl

INNER JOIN 
    dbo.CommunityCouncils cc ON vl.CommunityCouncilId = cc.Id
INNER JOIN 
    dbo.Districts d ON cc.DistrictId = d.Id
LEFT JOIN 
    dbo.AspNetUsers u ON vl.CreatedById = u.Id
-- Subquery to get totals for the entire Community Council
LEFT JOIN (
    SELECT 
        v.CommunityCouncilId,
        COUNT(DISTINCT v.Id) AS TotalVillages,
        COUNT(DISTINCT h.id) AS TotalHouseholds
    FROM dbo.Villages v
    LEFT JOIN dbo.Households h ON v.Id = h.VillageId
    GROUP BY v.CommunityCouncilId
) AS CouncilAggregates ON vl.CommunityCouncilId = CouncilAggregates.CommunityCouncilId
-- Subquery to get totals based on members in the validation list
LEFT JOIN (
    SELECT
        vdt.ValidationListId,
        COUNT(vdt.Id) AS TotalMembers,
        SUM(CASE WHEN scd.Description = 'Validated' THEN 1 ELSE 0 END) AS ValidatedMembers,
        SUM(CASE WHEN scd.Description = 'Pending' THEN 1 ELSE 0 END) AS PendingValidation
    FROM
        dbo.ValidationDetails vdt
    INNER JOIN 
        dbo.SystemCodeDetails scd ON vdt.ValidationStatusId = scd.Id
    GROUP BY
        vdt.ValidationListId
) AS MemberAggregates ON vl.Id = MemberAggregates.ValidationListId;
GO
-- ========================
-- VIEW: ValidationDetailsView (Unchanged)
-- ========================

IF OBJECT_ID('dbo.ValidationDetailView', 'V') IS NOT NULL
    DROP VIEW dbo.ValidationDetailView;
GO

CREATE VIEW dbo.ValidationDetailView AS
SELECT 
    d.Id,
    d.ValidationListId,
    d.HouseholdMemberId,
    CONCAT(h.FirstName, ' ', h.OtherName, ' ', h.Surname) AS HouseholdMemberName,
    d.ValidationStatusId,
    scd.Description AS ValidationStatusName
FROM ValidationDetails d
INNER JOIN HouseholdMembers h ON d.HouseholdMemberId = h.Id
INNER JOIN SystemCodeDetails scd ON d.ValidationStatusId = scd.Id;
GO



--------------------------------------------------------------------------------
-- VIEW: EligibilityTestsView
--------------------------------------------------------------------------------
IF OBJECT_ID('dbo.EligibilityTestsView', 'V') IS NOT NULL
    DROP VIEW dbo.EligibilityTestsView;
GO

-- Create the new view with the correct structure to match your C# model
CREATE VIEW dbo.EligibilityTestsView AS
SELECT 
    et.Id,
    et.Description,
    et.Quota,
    et.ProgrammeId,
    p.Name AS ProgrammeName,
    
    -- --- Aggregate District Info (Many-to-Many) ---
    -- Creates a comma-separated string of District IDs, e.g., '1, 5, 12'
    (
        SELECT STRING_AGG(CAST(d.Id AS NVARCHAR(MAX)), ', ')
        FROM dbo.EligibilityTestDistricts det_join -- <-- REPLACE WITH YOUR REAL JOIN TABLE NAME
        JOIN dbo.Districts d ON det_join.DistrictId = d.Id
        WHERE det_join.EligibilityTestId = et.Id
    ) AS DistrictIds,

    -- Creates a comma-separated string of District Names, e.g., 'Berea, Maseru, Mohale''s Hoek'
    (
        SELECT STRING_AGG(d.Name, ', ')
        FROM dbo.EligibilityTestDistricts det_join -- <-- REPLACE WITH YOUR REAL JOIN TABLE NAME
        JOIN dbo.Districts d ON det_join.DistrictId = d.Id
        WHERE det_join.EligibilityTestId = et.Id
    ) AS DistrictNames,

    -- --- Optional Single-Location Info ---
    et.CommunityCouncilId,
    cc.CommunityCouncilName,
    et.VillageId,
    v.Name AS Village, -- This alias matches your C# class property name
    
    -- --- Aggregate Counts from a Subquery ---
    COALESCE(Aggregates.TotalProcessed, 0) AS TotalProcessed,
    COALESCE(Aggregates.TotalSelected, 0) AS TotalSelected,
    COALESCE(Aggregates.TotalWaitlisted, 0) AS TotalWaitlisted,
    COALESCE(Aggregates.TotalNotEligible, 0) AS TotalNotEligible,
    COALESCE(Aggregates.TotalEligiblePreQuota, 0) AS TotalEligiblePreQuota,

    -- --- Auditing Info ---
    et.CreatedOn,
    et.CreatedById,
    u_created.UserName AS CreatedByUserName,
    et.ModifiedOn,
    et.ModifiedById,
    u_modified.UserName AS ModifiedByUserName
FROM 
    dbo.EligibilityTests et
INNER JOIN 
    dbo.Programmes p ON et.ProgrammeId = p.Id
-- Use LEFT JOINs for optional relationships
LEFT JOIN
    dbo.CommunityCouncils cc ON et.CommunityCouncilId = cc.Id
LEFT JOIN
    dbo.Villages v ON et.VillageId = v.Id
LEFT JOIN 
    dbo.AspNetUsers u_created ON et.CreatedById = u_created.Id
LEFT JOIN
    dbo.AspNetUsers u_modified ON et.ModifiedById = u_modified.Id
-- Subquery to get aggregated counts for each test
LEFT JOIN (
    SELECT
        etd.EligibilityTestId,
        COUNT(etd.Id) AS TotalProcessed,
        SUM(CASE WHEN scd.Code = 'Selected' THEN 1 ELSE 0 END) AS TotalSelected,
        SUM(CASE WHEN scd.Code = 'WaitListed' THEN 1 ELSE 0 END) AS TotalWaitlisted,
        SUM(CASE WHEN scd.Code = 'Not Eligible' THEN 1 ELSE 0 END) AS TotalNotEligible,
        SUM(CASE WHEN scd.Code IN ('Eligible', 'Selected', 'WaitListed') THEN 1 ELSE 0 END) AS TotalEligiblePreQuota
    FROM
        dbo.EligibilityTestDetails etd
    JOIN 
        dbo.SystemCodeDetails scd ON etd.EligibilityStatusId = scd.Id
    GROUP BY
        etd.EligibilityTestId
) AS Aggregates ON et.Id = Aggregates.EligibilityTestId;
GO
-----------------------------------------------------
-- vw_BankView
-- This view is correct. No changes needed.
IF OBJECT_ID('dbo.BankView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.vw_BankView';
    DROP VIEW dbo.BankView;
END
GO

CREATE VIEW dbo.BankView AS
SELECT
    b.Id,
    b.Name,
    b.BankDescription,
    u1.UserName AS CreatedByName,
    u2.UserName AS ModifiedByName,
	 b.CreatedOn,      
    b.ModifiedOn
FROM dbo.Banks b
LEFT JOIN dbo.AspNetUsers u1 ON b.CreatedById = u1.Id
LEFT JOIN dbo.AspNetUsers u2 ON b.ModifiedById = u2.Id;
GO

------------------------------------------------------
IF OBJECT_ID('dbo.FacilityView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.FacilityView';
    DROP VIEW dbo.FacilityView;
END
GO

CREATE VIEW dbo.FacilityView AS
SELECT
    f.Id,
    f.Code,
    f.BankId,
    b.Name AS BankName,
    f.AccountNo,
    f.BranchCode,
    f.IdentificationNumber,
    f.Name AS FacilityName,
    f.FacilityTypeId,
    ft.Name AS FacilityTypeName,
    f.CategoryId,
    scd.Description AS CategoryName,
    f.HeadName,
    f.HeadSurname,
    f.HeadEmail,
    f.HeadPhoneNumber,
    CAST(f.CreatedById AS varchar(36)) AS CreatedById,
    u1.UserName AS CreatedByName,
    f.CreatedOn,
    CAST(f.ModifiedById AS varchar(36)) AS ModifiedById,
    u2.UserName AS ModifiedByName,
    f.ModifiedOn,
    
    -- *** CHANGE 1 & 2: Return NULL if no grades exist, and name the column correctly ***
    NULLIF(
    (
        SELECT 
            g.Id, 
            g.Code,
            g.IsActive,
            g.CreatedOn,
            gu1.UserName as CreatedByName,
            g.ModifiedOn,
            gu2.UserName as ModifiedByName
        FROM dbo.Grades g
        INNER JOIN dbo.FacilityGrades jg ON g.Id = jg.GradesId 
        LEFT JOIN dbo.AspNetUsers gu1 ON g.CreatedById = gu1.Id
        LEFT JOIN dbo.AspNetUsers gu2 ON g.ModifiedById = gu2.Id
        WHERE jg.FacilitiesId = f.Id 
        FOR JSON PATH
    ), '[]') AS FacilityGradesJson -- The alias now matches the C# class perfectly

FROM 
    dbo.Facilities f
LEFT JOIN dbo.Banks b ON f.BankId = b.Id
LEFT JOIN dbo.FacilityTypes ft ON f.FacilityTypeId = ft.Id
LEFT JOIN dbo.SystemCodeDetails scd ON f.CategoryId = scd.Id
LEFT JOIN dbo.AspNetUsers u1 ON f.CreatedById = u1.Id
LEFT JOIN dbo.AspNetUsers u2 ON f.ModifiedById = u2.Id
GO


PRINT 'View dbo.FacilityView created successfully.';


--------------------------------------------------------
-- vw_FacilityTypeView
-- This view is correct. No changes needed.
IF OBJECT_ID('dbo.FacilityTypeView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.FacilityTypeView';
    DROP VIEW dbo.FacilityTypeView;
END
GO

CREATE VIEW dbo.FacilityTypeView AS
SELECT
    ft.Id,
    ft.Name,   
    ft.IsActive,
    ft.CreatedOn,
    cu.UserName AS CreatedByName,
    ft.ModifiedOn,
    mu.UserName AS ModifiedByName
FROM dbo.FacilityTypes ft
LEFT JOIN dbo.AspNetUsers cu ON ft.CreatedById = cu.Id
LEFT JOIN dbo.AspNetUsers mu ON ft.ModifiedById = mu.Id;
GO

------------------------------------------------------------
-- vw_FinancialYearView (FIXED)
-- - Added back CreatedOn and ModifiedOn columns.
IF OBJECT_ID('dbo.FinancialYearView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.vw_FinancialYearView';
    DROP VIEW dbo.FinancialYearView;
END
GO

CREATE VIEW dbo.FinancialYearView AS
SELECT
    fy.Id,
    fy.Name,
    fy.StartDate,
    fy.EndDate,
    fy.IsActive,
    fy.CreatedOn, -- FIXED: Added back
    cu.UserName AS CreatedByName,
    fy.ModifiedOn, -- FIXED: Added back
    mu.UserName AS ModifiedByName
FROM dbo.FinancialYears fy
LEFT JOIN dbo.AspNetUsers cu ON fy.CreatedById = cu.Id
LEFT JOIN dbo.AspNetUsers mu ON fy.ModifiedById = mu.Id;
GO

-----------------------------------------------------
-- vw_GradeView
-- This view is correct. No changes needed.
IF OBJECT_ID('dbo.GradeView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.GradeView';
    DROP VIEW dbo.GradeView;
END
GO

CREATE VIEW dbo.GradeView AS
SELECT
    g.Id,
    g.Code,
    g.IsActive,
    g.CreatedOn,
    cu.UserName AS CreatedByName,
    g.ModifiedOn,
    mu.UserName AS ModifiedByName
FROM dbo.Grades g
LEFT JOIN dbo.AspNetUsers cu ON g.CreatedById = cu.Id
LEFT JOIN dbo.AspNetUsers mu ON g.ModifiedById = mu.Id;
GO


---------------------------------------------------
-- vw_OVCBConfigurationView 
IF OBJECT_ID('dbo.OVCBConfigurationView', 'V') IS NOT NULL
BEGIN
    PRINT 'Dropping existing view: dbo.OVCBConfigurationView';
    DROP VIEW dbo.OVCBConfigurationView;
END
GO

CREATE VIEW dbo.OVCBConfigurationView AS
SELECT
    o.Id,
    o.ProgrammeId,
    p.Name AS ProgrammeName,
    o.FacilityTypeId,
    ft.Name AS FacilityTypeName,
    o.GradeId,
    g.Code AS GradeCode,
    o.FeeTypeId,
    ftd.Description AS FeeTypeName, 
    o.FeeAmount,
    o.FinYearId,
    fy.Name AS FinYearName,
    o.Status,
    cu.UserName AS CreatedByName,
    mu.UserName AS ModifiedByName
FROM dbo.OVCBConfigurations o
LEFT JOIN dbo.Programmes p ON o.ProgrammeId = p.Id
LEFT JOIN dbo.FacilityTypes ft ON o.FacilityTypeId = ft.Id
LEFT JOIN dbo.Grades g ON o.GradeId = g.Id
LEFT JOIN dbo.SystemCodeDetails ftd ON o.FeeTypeId = ftd.Id
LEFT JOIN dbo.FinancialYears fy ON o.FinYearId = fy.Id
LEFT JOIN dbo.AspNetUsers cu ON o.CreatedById = cu.Id
LEFT JOIN dbo.AspNetUsers mu ON o.ModifiedById = mu.Id;
GO

------------------------------ArrearsConfigurationView-------------------
IF OBJECT_ID('dbo.ArrearsConfigurationView', 'V') IS NOT NULL
BEGIN
    DROP VIEW dbo.ArrearsConfigurationView;
END
GO  

CREATE VIEW dbo.ArrearsConfigurationView
AS
SELECT
    ac.Id,
    ac.ProgrammeId,
    p.Name AS ProgrammeName,
    ac.MaximumCycles,
    ac.PenaltyId,
    scd.Description AS PenaltyDescription,
    ac.AccruedAfterPenalty,
    ac.ArrearsOverYear,
    ac.CreatedById,
    ISNULL(CONCAT(uc.FirstName, ' ', uc.MiddleName), uc.Surname) AS CreatedByName,
    ac.CreatedOn,
    ac.ModifiedById,
    ISNULL(CONCAT(um.FirstName, ' ', um.MiddleName), um.Surname) AS ModifiedByName,
    ac.ModifiedOn,
    ac.IsActive
FROM
    dbo.ArrearsConfigurations AS ac
LEFT JOIN
    dbo.Programmes AS p ON ac.ProgrammeId = p.Id
LEFT JOIN
    dbo.SystemCodeDetails AS scd ON ac.PenaltyId = scd.Id
LEFT JOIN
    dbo.AspNetUsers AS uc ON ac.CreatedById = uc.Id
LEFT JOIN
    dbo.AspNetUsers AS um ON ac.ModifiedById = um.Id;
GO
-- ------------------------------- EnrolmentsView -------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentsView];
GO 

CREATE VIEW dbo.[EnrolmentsView] AS
SELECT
    E.Id AS EnrolmentId,
    E.GUId AS EnrolmentGUId,
    E.EnrolmentScheduleId,
    E.EnrolmentEventDetailId,
    E.HouseholdId,
    E.PostalAddress,
    E.CreatedOn,
    E.ModifiedOn,
    CB.Id  AS CreatedById,
    MB.Id   AS ModifiedById 
FROM
    dbo.[Enrolments] AS E
LEFT JOIN
    dbo.[AspNetUsers] AS CB ON E.CreatedById = CB.Id
LEFT JOIN
    dbo.[AspNetUsers] AS MB ON E.ModifiedById = MB.Id;
GO 

-- ------------------------------- EnrolmentDetailsView -------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentDetailsView];
GO

CREATE VIEW dbo.[EnrolmentDetailsView] AS
SELECT
    ED.Id AS EnrolmentDetailId,
    ED.HouseholdMemberId,
    ED.GradeId,
    ED.CreatedById AS EnrolmentDetailCreatedById,
    ED.CreatedOn AS EnrolmentDetailCreatedOn,
    ED.ModifiedById  AS EnrolmentDetailModifiedById,
    ED.ModifiedOn AS EnrolmentDetailModifiedOn
FROM
    dbo.[EnrolmentDetails] AS ED;
GO

-- ------------------------------- EnrolmentEventView -------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentEventView];
GO

CREATE VIEW dbo.[EnrolmentEventView] AS
SELECT
    EE.Id  AS EnrolmentEventId,
    EE.Name AS EnrolmentEventName,
    EE.ProgrammeId,
    P.Name AS ProgrammeName,
    EE.DistrictId,
    D.Name AS DistrictName,
    EE.CommunityCouncilId,
    CC.CommunityCouncilName AS CommunityCouncilName,
    EE.VillageId,
    V.Name AS VillageName,
    EE.Quota,
    EE.StartDate,
    EE.EndDate,
    EE.CreatedOn,
    EE.ModifiedOn,
    CB.Id  AS CreatedById,
    MB.Id AS ModifiedById
FROM
    [dbo].[EnrolmentEvents] AS EE
LEFT JOIN
    dbo.[Programmes] AS P ON EE.ProgrammeId = P.Id
LEFT JOIN
    dbo.[Districts] AS D ON EE.DistrictId = D.Id
LEFT JOIN
    dbo.[CommunityCouncils] AS CC ON EE.CommunityCouncilId = CC.Id
LEFT JOIN
    dbo.[Villages] AS V ON EE.VillageId = V.Id
LEFT JOIN
    dbo.[AspNetUsers] AS CB ON EE.CreatedById = CB.Id
LEFT JOIN
    dbo.[AspNetUsers] AS MB ON EE.ModifiedById = MB.Id;
GO

-- ------------------------------- EnrolmentEventDetailView -------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentEventDetailView];
GO

CREATE VIEW dbo.[EnrolmentEventDetailView] AS
SELECT
    EED.Id  AS EnrolmentEventDetailId,
    EED.EnrolmentEventId,
    EE.Name AS EnrolmentEventName,
    EED.HouseholdMemberId,
    ISNULL(HM.FirstName + ' ', '') + ISNULL(HM.Surname, '') AS HouseholdMemberFullName,
    HM.IDNumberBirthCertificate    AS HouseholdMemberIDNumber,
    EED.HouseholdId,
    H.Id  AS HouseholdCode,
    EED.CreatedOn,
    EED.ModifiedOn,
    CB.Id  AS CreatedById,
    MB.Id AS ModifiedById
FROM
    dbo.[EnrolmentEventDetails] AS EED
LEFT JOIN
    dbo.[EnrolmentEvents] AS EE ON EED.EnrolmentEventId = EE.Id
LEFT JOIN
    dbo.[HouseholdMembers] AS HM ON EED.HouseholdMemberId = HM.Id
LEFT JOIN
    dbo.[Households] AS H ON EED.HouseholdId = H.Id
LEFT JOIN
    dbo.[AspNetUsers] AS CB ON EED.CreatedById = CB.Id
LEFT JOIN
    dbo.[AspNetUsers] AS MB ON EED.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- EnrolmentScheduleView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentScheduleView];
GO

CREATE VIEW dbo.[EnrolmentScheduleView] AS
SELECT
    ES.Id AS EnrolmentScheduleId,
    ES.EnrolmentEventId,
    EE.Name  AS EnrolmentEventName,
    ES.DistrictId,
    D.Name AS DistrictName,
    ES.CommunityCouncilId,
    CC.CommunityCouncilName AS CommunityCouncilName,
    ES.VillageId,
    V.Name  AS VillageName,
    ES.StartDate,
    ES.EndDate,
    ES.Venue,
    ES.CreatedOn,
    ES.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM
    dbo.[EnrolmentSchedules] AS ES
LEFT JOIN
    dbo.[EnrolmentEvents] AS EE ON ES.EnrolmentEventId = EE.Id
LEFT JOIN
    dbo.[Districts] AS D ON ES.DistrictId = D.Id
LEFT JOIN
    dbo.[CommunityCouncils] AS CC ON ES.CommunityCouncilId = CC.Id
LEFT JOIN
    dbo.[Villages] AS V ON ES.VillageId = V.Id
LEFT JOIN
    dbo.[AspNetUsers] AS CB ON ES.CreatedById = CB.Id
LEFT JOIN
    dbo.[AspNetUsers] AS MB ON ES.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- EnrolmentScheduleDetailView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[EnrolmentScheduleDetailView];
GO

CREATE VIEW dbo.[EnrolmentScheduleDetailView] AS
SELECT
    ESD.Id AS EnrolmentScheduleDetailId,
    ESD.EnrolmentScheduleId,
    ES.Venue AS EnrolmentScheduleVenue,
    ESD.EnrolmentEventId,
    EE.Name AS EnrolmentEventName,
    ESD.VillageId,
    V.Name  AS VillageName,
    ESD.ScheduleDate,
    ESD.CreatedOn,
    ESD.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM
    dbo.[EnrolmentScheduleDetails] AS ESD
LEFT JOIN
    dbo.[EnrolmentSchedules] AS ES ON ESD.EnrolmentScheduleId = ES.Id
LEFT JOIN
    dbo.[EnrolmentEvents] AS EE ON ESD.EnrolmentEventId = EE.Id
LEFT JOIN
    dbo.[Villages] AS V ON ESD.VillageId = V.Id
LEFT JOIN
    dbo.[AspNetUsers] AS CB ON ESD.CreatedById = CB.Id
LEFT JOIN
    dbo.[AspNetUsers] AS MB ON ESD.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- PaymentDetailView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[PaymentDetailView];
GO

CREATE VIEW dbo.[PaymentDetailView] AS
SELECT
    PD.Id AS PaymentDetailId,
    PD.MobileNumber,
    PD.EnrolmentId,
    E.GUId AS EnrolmentGUId,
    E.PostalAddress AS EnrolmentPostalAddress,
    PD.PaymentModeId,
    PM.Name AS PaymentModeName,
    PD.FacilityId,
    F.Name AS FacilityName,
    PD.PayeeId,
    ISNULL(HM.FirstName + ' ', '') + ISNULL(HM.Surname, '') AS PayeeFullName,
    HM.IDNumberBirthCertificate AS PayeeIDNumber,
    PD.PayPointId,
    PP.Name AS PayPointName,
    PD.PayeeTypeId,
    SCD.Code AS PayeeTypeCode,
    SCD.Description AS PayeeTypeDescription,
    PD.CreatedOn,
    PD.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM dbo.[PaymentDetails] AS PD
LEFT JOIN dbo.[Enrolments] AS E ON PD.EnrolmentId = E.Id
LEFT JOIN dbo.[PaymentModes] AS PM ON PD.PaymentModeId = PM.Id
LEFT JOIN dbo.[Facilities] AS F ON PD.FacilityId = F.Id
LEFT JOIN dbo.[HouseholdMembers] AS HM ON PD.PayeeId = HM.Id
LEFT JOIN dbo.[PayPoints] AS PP ON PD.PayPointId = PP.Id
LEFT JOIN dbo.[SystemCodeDetails] AS SCD ON PD.PayeeTypeId = SCD.Id
LEFT JOIN dbo.[AspNetUsers] AS CB ON PD.CreatedById = CB.Id
LEFT JOIN dbo.[AspNetUsers] AS MB ON PD.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- ProxieView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[ProxieView];
GO

CREATE VIEW dbo.[ProxieView] AS
SELECT
    P.Id AS ProxieId,
    P.GUId,
    P.PaymentDetailsId,
    P.IDNumber,
    P.FirstName,
    P.MiddleName,
    P.GenderId,
    SCD.Description AS GenderDescription,
    P.DateofBirth,
    P.PhoneNumber,
    P.CreatedOn,
    P.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM dbo.[Proxies] AS P
LEFT JOIN dbo.[SystemCodeDetails] AS SCD ON P.GenderId = SCD.Id
LEFT JOIN dbo.[AspNetUsers] AS CB ON P.CreatedById = CB.Id
LEFT JOIN dbo.[AspNetUsers] AS MB ON P.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- PayPointView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[PayPointView];
GO

CREATE VIEW dbo.[PayPointView] AS
SELECT
    PP.Id AS PayPointId,
    PP.Code,
    PP.Name,
    PP.IsActive,
    PP.CommunityCouncilId,
    CC.CommunityCouncilName AS CommunityCouncilName,
    PP.DistrictId,
    D.Name AS DistrictName,
    PP.CreatedOn,
    PP.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM [dbo].[PayPoints] AS PP
LEFT JOIN dbo.[CommunityCouncils] AS CC ON PP.CommunityCouncilId = CC.Id
LEFT JOIN dbo.[Districts] AS D ON PP.DistrictId = D.Id
LEFT JOIN dbo.[AspNetUsers] AS CB ON PP.CreatedById = CB.Id
LEFT JOIN dbo.[AspNetUsers] AS MB ON PP.ModifiedById = MB.Id;
GO
------------------------------------------------------------
-- PaymentModeView
------------------------------------------------------------
DROP VIEW IF EXISTS dbo.[PaymentModeView];
GO

CREATE VIEW dbo.[PaymentModeView] AS
SELECT
    PM.Id AS PaymentModeId,
    PM.Name,
    PM.Description,
    PM.CreatedOn,
    PM.ModifiedOn,
    CB.Id AS CreatedById,
    MB.Id AS ModifiedById
FROM dbo.[PaymentModes] AS PM
LEFT JOIN dbo.[AspNetUsers] AS CB ON PM.CreatedById = CB.Id
LEFT JOIN dbo.[AspNetUsers] AS MB ON PM.ModifiedById = MB.Id;
GO

---------------------------------------------------------------------------
PRINT 'All Missa Program related views created successfully.';
GO





