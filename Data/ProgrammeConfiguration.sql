USE [LesothoMoGYSD];
GO

--------------------------------------------------------------------------------
-- View: ProgrammeView
--------------------------------------------------------------------------------
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
    p.TypeId,
    pt_scd.Description AS TypeDescription,
    p.BeneficiaryType,
    p.IsActive,
    p.PayeeModality,
    pm_scd.Description AS PayeeModalityDescription,
    p.Amount,
    p.ColourScheme,
    p.TopUpId,
    tu.Name AS TopUpDescription,
    p.PaymentFrequencyId,
    pf.Name AS PaymentFrequencyDescription,
    p.ProofOfLifeSpan,
    p.CreatedById,
    creator.UserName AS CreatedByUserName,
    p.CreatedOn,
    p.ModifiedById,
    modifier.UserName AS ModifiedByUserName,
    p.ModifiedOn,
    -- ✅ Aggregate all criteria
    (
        SELECT STRING_AGG(Name, ', ')
        FROM dbo.EligibilityCriterias ec
        WHERE ec.ProgrammeId = p.Id
    ) AS EligibilityCriteriaDescriptions
FROM dbo.Programmes p
LEFT JOIN dbo.SystemCodeDetails au_scd ON p.AssistanceUnitId = au_scd.Id
LEFT JOIN dbo.SystemCodeDetails pt_scd ON p.TypeId = pt_scd.Id
LEFT JOIN dbo.SystemCodeDetails pm_scd ON p.PayeeModality = pm_scd.Id
LEFT JOIN dbo.TopUps tu ON p.TopUpId = tu.Id
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
GO
IF OBJECT_ID('dbo.EligibilityCriteriaView', 'V') IS NOT NULL
    DROP VIEW dbo.EligibilityCriteriaView;
GO

CREATE VIEW dbo.EligibilityCriteriaView
AS
SELECT
    ec.Id,
    ec.ProgrammeId,
    prog.Name AS ProgrammeName,
    prog.Code AS ProgrammeCode,

    ec.Name AS EligibilityCriteriaName,

    ec.AttributeId AS CriteriaDefinitionSystemCodeDetailId,
    scd_criteria_def.Description AS CriteriaDefinitionName,
    scd_criteria_def.Code AS CriteriaDefinitionCode,

    ec.OperatorId AS CriteriaOperatorSystemCodeDetailId,
    scd_operator.Description AS CriteriaOperatorName,
    scd_operator.Code AS CriteriaOperatorCode,

    ec.Value AS CriteriaValue,
    ec.IsActive AS EligibilityCriteriaIsActive,

    ec.CreatedOn AS EligibilityCriteriaCreatedOn,
    ec.CreatedById AS EligibilityCriteriaCreatedById,
    creator.UserName AS EligibilityCriteriaCreatedByUserName,
    ec.ModifiedOn AS EligibilityCriteriaModifiedOn,
    ec.ModifiedById AS EligibilityCriteriaModifiedById,
    modifier.UserName AS EligibilityCriteriaModifiedByUserName
FROM
    dbo.EligibilityCriterias AS ec
INNER JOIN
    dbo.Programmes AS prog ON ec.ProgrammeId = prog.Id
LEFT JOIN
    dbo.SystemCodeDetails AS scd_criteria_def ON ec.AttributeId = scd_criteria_def.Id
LEFT JOIN
    dbo.SystemCodeDetails AS scd_operator ON ec.OperatorId = scd_operator.Id
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
    tu.Id AS TopUpId,
    tu.ProgrammeId,
    prog.Name AS ProgrammeName,
    prog.Code AS ProgrammeCode,

    tu.Name AS TopUpName,
    tu.Amount AS TopUpAmount,
    tu.Criteria AS TopUpCriteriaDescription,
    tu.IsActive AS TopUpIsActive,

    tu.CreatedOn AS TopUpCreatedOn,
    tu.CreatedById AS TopUpCreatedById,
    creator.UserName AS TopUpCreatedByUserName,
    tu.ModifiedOn AS TopUpModifiedOn,
    tu.ModifiedById AS TopUpModifiedById,
    modifier.UserName AS TopUpModifiedByUserName
FROM
    dbo.TopUps AS tu
INNER JOIN
    dbo.Programmes AS prog
    ON tu.ProgrammeId = prog.Id
LEFT JOIN
    dbo.AspNetUsers AS creator
    ON tu.CreatedById = creator.Id
LEFT JOIN
    dbo.AspNetUsers AS modifier
    ON tu.ModifiedById = modifier.Id;
GO

--------------------------------------------------------------------------------
-- End of View Scripts
--------------------------------------------------------------------------------

PRINT 'All Missa Program related views created successfully.';
GO





