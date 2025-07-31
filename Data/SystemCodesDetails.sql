-- ====================================================================================================================>
-- Insert into SystemCodes if 'Sex' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'Sex')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('Sex', 'Sex Gender');
END

-- Get the ID for 'Sex'
DECLARE @SexSystemCodeId INT;
SELECT @SexSystemCodeId = Id FROM SystemCodes WHERE Code = 'Sex';

-- Insert Male if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Male' AND SystemCodeId = @SexSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Male', 1, 'Male', @SexSystemCodeId);
END

-- Insert Female if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Female' AND SystemCodeId = @SexSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Female', 2, 'Female', @SexSystemCodeId);
END

-- ======================================================================================
-- Insert into SystemCodes if 'Status' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'Status')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('Status', 'Approval status flow');
END

-- Get the ID for 'Status'
DECLARE @StatusSystemCodeId INT;
SELECT @StatusSystemCodeId = Id FROM SystemCodes WHERE Code = 'Status';

-- Insert Status Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Open' AND SystemCodeId = @StatusSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Open', 1, 'Open', @StatusSystemCodeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Under Review' AND SystemCodeId = @StatusSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Under Review', 2, 'Under Review', @StatusSystemCodeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Approved' AND SystemCodeId = @StatusSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Approved', 3, 'Approved', @StatusSystemCodeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Closed' AND SystemCodeId = @StatusSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Closed', 4, 'Closed', @StatusSystemCodeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Rejected' AND SystemCodeId = @StatusSystemCodeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Rejected', 4, 'Rejected', @StatusSystemCodeId);
END
-- ===============================================================================

-- Insert into SystemCodes if 'DataCollectionApproach' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'DataCollectionApproach')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('DataCollectionApproach', 'Data collection approach');
END

-- Get the ID for 'DataCollectionApproach'
DECLARE @DataCollectionApproachId INT;
SELECT @DataCollectionApproachId = Id FROM SystemCodes WHERE Code = 'DataCollectionApproach';

-- Insert Data Collection Approach Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Door to Door' AND SystemCodeId = @DataCollectionApproachId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Door to Door', 1, 'Door to Door', @DataCollectionApproachId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Data Collection Centers' AND SystemCodeId = @DataCollectionApproachId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Data Collection Centers', 2, 'Data Collection Centers', @DataCollectionApproachId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Mixed Approach' AND SystemCodeId = @DataCollectionApproachId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Mixed Approach', 3, 'Mixed Approach', @DataCollectionApproachId);
END

-- ==============================================================================================>
-- Insert into SystemCodes if 'PlanType' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'PlanType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('PlanType', 'Plan type');
END

-- Get the ID for 'PlanType'
DECLARE @PlanTypeId INT;
SELECT @PlanTypeId = Id FROM SystemCodes WHERE Code = 'PlanType';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'New Registration' AND SystemCodeId = @PlanTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('New Registration', 2, 'New Registration', @PlanTypeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Update Registration' AND SystemCodeId = @PlanTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Update Registration', 1, 'Update Registration', @PlanTypeId);
END

-- =======================================================================================>
-- Insert into SystemCodes if 'OrganisationType' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'OrganisationType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('OrganisationType', 'Organisation Type');
END

-- Get the ID for 'OrganisationType'
DECLARE @OrganisationTypeId INT;
SELECT @OrganisationTypeId = Id FROM SystemCodes WHERE Code = 'OrganisationType';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'NGO' AND SystemCodeId = @OrganisationTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('NGO', 1, 'NGO', @OrganisationTypeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Government ' AND SystemCodeId = @OrganisationTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Government ', 2, 'Government ', @OrganisationTypeId);
END

-- ======================================================================================>
-- Insert into SystemCodes if 'RegistrationPurpose' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'RegistrationPurpose')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('RegistrationPurpose', 'Registration Purpose');
END

-- Get the ID for 'RegistrationPurpose'
DECLARE @RegistrationPurposeId INT;
SELECT @RegistrationPurposeId = Id FROM SystemCodes WHERE Code = 'RegistrationPurpose';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Programme Registration' AND SystemCodeId = @RegistrationPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Programme Registration', 1, 'Programme Registration', @RegistrationPurposeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Research ' AND SystemCodeId = @RegistrationPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Research ', 2, 'Research ', @RegistrationPurposeId);
END
-- ======================================================================================>
-- Insert into SystemCodes if 'Registration Activities' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'Registration Activities')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('Registration Activities', 'Registration Activities for community');
END

-- Get the ID for 'Activities'
DECLARE @ActivitiesPurposeId INT;
SELECT @ActivitiesPurposeId = Id FROM SystemCodes WHERE Code = 'Registration Activities';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Awareness and Community Mobilization' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Awareness and Community Mobilization', 1, 'Awareness and Community Mobilization', @ActivitiesPurposeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Household Listing' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Household Listing ', 2, 'Household Listing', @ActivitiesPurposeId);
END


IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Community-based Categorization' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Community-based Categorization', 2, 'Community-based Categorization', @ActivitiesPurposeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Household Enumeration' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Household Enumeration', 2, 'Household Enumeration', @ActivitiesPurposeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Data Quality Assurance' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Data Quality Assurance', 2, 'Data Quality Assurance', @ActivitiesPurposeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'PMT' AND SystemCodeId = @ActivitiesPurposeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('PMT', 2, 'PMT', @ActivitiesPurposeId);
END
-- ===========================================================================================
-- Insert into SystemCodes if 'AccessLevel' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'AccessLevel')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('AccessLevel', 'Access Level');
END

-- Get the ID for 'AccessLevel'
DECLARE @AccessLevelId INT;
SELECT @AccessLevelId = Id FROM SystemCodes WHERE Code = 'AccessLevel';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'National' AND SystemCodeId = @AccessLevelId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('National', 1, 'National', @AccessLevelId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'District' AND SystemCodeId = @AccessLevelId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('District', 2, 'District', @AccessLevelId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Community Council' AND SystemCodeId = @AccessLevelId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Community Council', 3, 'Community Council', @AccessLevelId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Village' AND SystemCodeId = @AccessLevelId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Village', 4, 'Village', @AccessLevelId);
END

-- ===========================================================================================
-- Insert into SystemCodes if 'IDType' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'IDType')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('IDType', 'ID Type');
END

-- Get the ID for 'IDType'
DECLARE @IDTypeId INT;
SELECT @IDTypeId = Id FROM SystemCodes WHERE Code = 'IDType';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'National ID' AND SystemCodeId = @IDTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('National ID', 1, 'National ID', @IDTypeId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Passport' AND SystemCodeId = @IDTypeId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Passport', 2, 'Passport', @IDTypeId);
END

-- ===========================================================================================
-- Insert into SystemCodes if 'Currency' does not exist
IF NOT EXISTS (SELECT 1 FROM SystemCodes WHERE Code = 'Currency')
BEGIN
    INSERT INTO SystemCodes (Code, Description)
    VALUES ('Currency', 'Currency Type');

END
-- Get the ID for 'Currency'
DECLARE @CurrencyId INT;
SELECT @CurrencyId = Id FROM SystemCodes WHERE Code = 'Currency';

-- Insert Plan Type Details if not exists
IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'Loti' AND SystemCodeId = @CurrencyId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('Loti', 1, 'Loti', @CurrencyId);
END

IF NOT EXISTS (
    SELECT 1 FROM SystemCodeDetails 
    WHERE Code = 'USD' AND SystemCodeId = @CurrencyId
)
BEGIN
    INSERT INTO SystemCodeDetails (Code, OrderNo, Description, SystemCodeId)
    VALUES ('USD', 2, 'USD', @CurrencyId);
END

-- ===========================================================================================

































