USE [LesothoMoGYSD];
GO

DECLARE @SystemCodeId INT;
DECLARE @CreatedById NVARCHAR(450) = '7d544dd0-c5b9-476f-b86c-32563510287b';

---------------------------------------------------------------
-- Assistance Unit
---------------------------------------------------------------
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'AssistanceUnit';
DELETE FROM SystemCodeDetails WHERE SystemCodeId = @SystemCodeId;

IF ISNULL(@SystemCodeId, 0) = 0
BEGIN
    INSERT INTO SystemCodes (Code, Description) 
    VALUES ('AssistanceUnit', 'Assistance Unit');

    SELECT @SystemCodeId = SCOPE_IDENTITY();
END

INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
VALUES 
    (@SystemCodeId, 'Household', 'Household', 1),
    (@SystemCodeId, 'Individual', 'Individual', 2);

---------------------------------------------------------------
-- Program Type
---------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'ProgramType')
BEGIN
    INSERT INTO SystemCodes (Code, Description) VALUES ('ProgramType', 'Program Type');
END

SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'ProgramType';
DELETE FROM SystemCodeDetails WHERE SystemCodeId = @SystemCodeId;

IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.Description, T1.OrderNo
    FROM (
        SELECT 'Cash Benefit', 'Cash Benefit', 1
        UNION SELECT 'In-Kind Benefit', 'In-Kind Benefit', 2
    ) AS T1(Code, Description, OrderNo)
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END



---------------------------------------------------------------
-- Payment Frequency
---------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'PaymentFrequency')
BEGIN
    INSERT INTO SystemCodes (Code, Description) VALUES ('PaymentFrequency', 'Payment Frequency');
END

SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'PaymentFrequency';

IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.Description, T1.OrderNo
    FROM (
        SELECT 'Month', 'Month', 1
        UNION SELECT 'Quarter', 'Quarter', 2
        UNION SELECT 'Annually', 'Annually', 3
        UNION SELECT 'Bi Annual', 'Bi Annual', 4
    ) AS T1(Code, Description, OrderNo)
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END

---------------------------------------------------------------
-- Programme Attribute
---------------------------------------------------------------


-- Ensure 'ProgrammeAttribute' exists in SystemCodes
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'ProgrammeAttribute')
BEGIN
    INSERT INTO SystemCodes (Code, Description) 
    VALUES ('ProgrammeAttribute', 'ProgrammeAttribute');
END

-- Get the SystemCodeId
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'ProgrammeAttribute';

-- Delete old/incorrect entries before inserting new ones
DELETE FROM SystemCodeDetails WHERE SystemCodeId = @SystemCodeId;

-- Insert fresh ProgrammeAttribute options
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.Description, T1.OrderNo
    FROM (
        SELECT 'Age', 'Age', 1
        UNION SELECT 'Live Status', 'Live status', 2    
    ) AS T1(Code, Description, OrderNo);
END


---------------------------------------------------------------
-- Comparison Operator
---------------------------------------------------------------
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'ComparisonOperator')
BEGIN
    INSERT INTO SystemCodes (Code, Description) VALUES ('ComparisonOperator', 'Comparison Operator');
END

SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'ComparisonOperator';

IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.Description, T1.OrderNo
    FROM (
        SELECT 'EQ', '=', 1
        UNION SELECT 'GT', '>', 2
        UNION SELECT 'LT', '<', 3
        UNION SELECT 'GTE', '>=', 4
        UNION SELECT 'LTE', '<=', 5
        UNION SELECT 'NEQ', '!=', 6
    ) AS T1(Code, Description, OrderNo)
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END

---------------------------------------------------------------
-- PaymentFrequencies Table Insert
---------------------------------------------------------------
-- Delete all invalid or obsolete payment frequencies first
DELETE FROM PaymentFrequencies;


-- Insert new payment frequencies based on SystemCodeDetails (FrequencyId)
INSERT INTO [dbo].[PaymentFrequencies] (
    [Name], [FrequencyId], [IsActive], [CreatedOn], [CreatedById], [ModifiedOn], [ModifiedById]
)
SELECT val.Name, scd.Id, 1, GETDATE(), @CreatedById, GETDATE(), @CreatedById
FROM (
    SELECT 'Monthly' AS Name, 'Month' AS Code
    UNION SELECT 'Bi-Monthly', 'Bi Monthly' -- Note: ensure 'Bi Monthly' exists in SystemCodeDetails if used
    UNION SELECT 'Quarterly', 'Quarter'
    UNION SELECT 'Bi-Annually', 'Bi Annual'
    UNION SELECT 'Annually', 'Annually'
) AS val(Name, Code)
INNER JOIN [dbo].[SystemCodeDetails] scd 
    ON scd.Code = val.Code AND scd.SystemCodeId = (
        SELECT Id FROM SystemCodes WHERE Code = 'PaymentFrequency'
    );

	------
	IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'PaymentMode')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('PaymentMode', 'Payment Mode');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'PaymentMode';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Cash' AS Code, 'Cash' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Digital', 'Digital', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END


----------
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'ProofOfLifeSpan')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('ProofOfLifeSpan', 'Proof Of LifeSpan');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'ProofOfLifeSpan';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Annual' AS Code, 'Annual' AS [Description], 1 AS OrderNo
        UNION
        SELECT '4 Years Recertification', '4 Years Recertification', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
--------
DECLARE @SystemCodeId INT;
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'ValidationStatus')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('ValidationStatus', 'Validation Status');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'ValidationStatus';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Pending' AS Code, 'Pending' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Validated', 'Validated', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
------Eligibility Status
-- ==============================================================================

IF NOT EXISTS (SELECT 1 FROM dbo.SystemCodes WHERE Code = 'EligibilityStatus')
BEGIN
    PRINT 'Inserting parent SystemCode: EligibilityStatus';
    INSERT INTO dbo.SystemCodes (Code, [Description])
    VALUES ('EligibilityStatus', 'Eligibility Status');
END
ELSE
BEGIN
    PRINT 'Parent SystemCode: EligibilityStatus already exists.';
END
GO

-- Declare a variable to hold the SystemCodeId
DECLARE @SystemCodeId INT;

-- Get the ID of the 'EligibilityStatus' SystemCode
SELECT @SystemCodeId = Id
FROM dbo.SystemCodes
WHERE Code = 'EligibilityStatus';

-- Insert the details only if they are not already present for the given SystemCodeId
IF @SystemCodeId IS NOT NULL
BEGIN
    PRINT 'Merging SystemCodeDetails for EligibilityStatus...';

    -- Use a MERGE statement for a more robust and readable upsert-like operation
    MERGE INTO dbo.SystemCodeDetails AS Target
    USING (
        VALUES
            (@SystemCodeId, 'Eligible',     'Eligible for the programme',      1),
            (@SystemCodeId, 'Not Eligible', 'Not eligible for the programme',  2),
            (@SystemCodeId, 'Selected',     'Selected for enrolment (post-quota)', 3),
            (@SystemCodeId, 'WaitListed',   'Placed on the waiting list',      4) 
    ) AS Source (SystemCodeId, Code, [Description], OrderNo)
    ON Target.SystemCodeId = Source.SystemCodeId AND Target.Code = Source.Code
    WHEN NOT MATCHED BY TARGET THEN
        INSERT (SystemCodeId, Code, [Description], OrderNo)
        VALUES (Source.SystemCodeId, Source.Code, Source.Description, Source.OrderNo);

    PRINT 'SystemCodeDetails merge complete.';
END
ELSE
BEGIN
    PRINT 'Error: Could not find SystemCodeId for ''EligibilityStatus''. Aborting detail insert.';
END
GO

DECLARE @SystemCodeId INT;
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'Caregiver')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('Caregiver', 'Caregiver');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'Caregiver';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Head of Household' AS Code, 'Head of Household' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Not Applicable', 'Not Applicable', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END

DECLARE @SystemCodeId INT;

-- ============================================
--        1. Poverty Status / PMT
-- ============================================

-- Get or create PovertyStatusPMT
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'PovertyStatusPMT';
IF @SystemCodeId IS NULL
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('PovertyStatusPMT', 'Poverty Status/PMT');

    SELECT @SystemCodeId = SCOPE_IDENTITY();
END
ELSE
BEGIN
    DELETE FROM SystemCodeDetails WHERE SystemCodeId = @SystemCodeId;
END

-- Insert common options for PovertyStatusPMT
INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
SELECT @SystemCodeId, Code, [Description], OrderNo
FROM (
    SELECT 'Ultra-poor', 'Ultra-poor', 1
    UNION ALL SELECT 'Poor',   'Poor',   2
    UNION ALL SELECT 'Middle', 'Middle', 3
    UNION ALL SELECT 'Able',   'Able',   4
) AS Data(Code, [Description], OrderNo);

-- ============================================
--        2. CBC Categorisation
-- ============================================

-- Get or create CBCCategorisation
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'CBCCategorisation';
IF @SystemCodeId IS NULL
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('CBCCategorisation', 'CBC Categorisation');

    SELECT @SystemCodeId = SCOPE_IDENTITY();
END
ELSE
BEGIN
    DELETE FROM SystemCodeDetails WHERE SystemCodeId = @SystemCodeId;
END

-- Insert common options for CBCCategorisation
INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
SELECT @SystemCodeId, Code, [Description], OrderNo
FROM (
    SELECT 'Ultra-poor', 'Ultra-poor', 1
    UNION ALL SELECT 'Poor',   'Poor',   2
    UNION ALL SELECT 'Middle', 'Middle', 3
    UNION ALL SELECT 'Able',   'Able',   4
) AS Data(Code, [Description], OrderNo);

--------------Yes/No---------
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'YesNo')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('YesNo', 'Yes No');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'YesNo';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Yes' AS Code, 'Yes' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'No', 'No', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
--------------Vulnerability Type---------
-- Insert into SystemCodes if not already present
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'VulnerabilityType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('VulnerabilityType', 'Vulnerability Type');
END

-- Get the ID of the VulnerabilityType SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'VulnerabilityType';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Childhood' AS Code, 'Childhood' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Orphanhood', 'Orphanhood', 2
        UNION
        SELECT 'Unemployment', 'Unemployment', 3
        UNION
        SELECT 'Disability', 'Disability', 4
        UNION
        SELECT 'OldAge', 'Old Age', 5
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
--------------HHMemberType---------


IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'HHMemberType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('HHMemberType', 'HH Member Type');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'HHMemberType';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Head' AS Code, 'Head' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Member', 'Member', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
--------------Facility Category---------
DECLARE @SystemCodeId INT;
DECLARE @CreatedById NVARCHAR(450) = '7d544dd0-c5b9-476f-b86c-32563510287b';

IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'FacilityCategory')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('FacilityCategory', 'Facility Category');
END

-- Get the ID of the PaymentFrequency SystemCode
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'FacilityCategory';

-- Insert the details only if not already present
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Public' AS Code, 'Public' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Private', 'Private', 2       
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END

--------------Facility Category---------
DECLARE @SystemCodeId INT;
DECLARE @CreatedById NVARCHAR(450) = '7d544dd0-c5b9-476f-b86c-32563510287b';

-- Insert into SystemCodes if not exists
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'FeeType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('FeeType', 'Fee Type');
END

-- Get the SystemCode ID
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'FeeType';

-- Insert SystemCodeDetails if SystemCodeId is valid
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Tuition' AS Code, 'Tuition' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Stationery', 'Stationery', 2
        UNION
        SELECT 'Exam', 'Exam', 3
        UNION
        SELECT 'Government Levy', 'Government Levy', 4
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
-- -------------- Form of Penalty ------------------
DECLARE @SystemCodeId INT;
DECLARE @CreatedById NVARCHAR(450) = '7d544dd0-c5b9-476f-b86c-32563510287b';

-- Insert into SystemCodes if not exists
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'FormOfPenalty')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('FormOfPenalty', 'Form of Penalty');
END

-- Get the SystemCode ID
SELECT @SystemCodeId = Id FROM SystemCodes WHERE Code = 'FormOfPenalty';

-- Insert SystemCodeDetails if SystemCodeId is valid
IF ISNULL(@SystemCodeId, 0) > 0
BEGIN
    INSERT INTO SystemCodeDetails (SystemCodeId, Code, [Description], OrderNo)
    SELECT @SystemCodeId, T1.Code, T1.[Description], T1.OrderNo
    FROM (
        SELECT 'Suspension' AS Code, 'Suspension' AS [Description], 1 AS OrderNo
        UNION
        SELECT 'Exit', 'Exit', 2
        UNION
        SELECT 'N/A', 'N/A', 3
    ) AS T1
    LEFT JOIN SystemCodeDetails T2 
        ON T1.Code = T2.Code AND T2.SystemCodeId = @SystemCodeId
    WHERE T2.Code IS NULL;
END
