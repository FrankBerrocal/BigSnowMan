/*
                                        Project Management Office Evaluation System (PMOES)
                                                        Final Project

                                                Student Frank Berrocal 427887





SODV-2202 Object Oriented Programming           MGM-1104 Introduction to Project Management             SODV-2201 Relational Databases

Dr. Sohaib Bajwa                                Prof. Achala Vinnakota                                  Prof. Mohamed ElMenshawy



                                                        December, 2022
*/


--primera version, incluir los requerimientos tecnologicos.

USE master
GO

/* OBJECT:  DATABASE Ulysses  */
--Project Management Office Evaluation System (PMOES)

IF DB_ID('Ulysses') IS NOT NULL
    DROP DATABASE Ulysses;

GO


CREATE DATABASE Ulysses;
GO


USE Ulysses;
GO

ALTER DATABASE CURRENT
SET RECOVERY SIMPLE, 
    ANSI_NULLS ON, 
    ANSI_PADDING ON, 
    ANSI_WARNINGS ON, 
    ARITHABORT ON, 
    CONCAT_NULL_YIELDS_NULL ON, 
    QUOTED_IDENTIFIER ON, 
    NUMERIC_ROUNDABORT OFF, 
    PAGE_VERIFY CHECKSUM, 
    ALLOW_SNAPSHOT_ISOLATION OFF;
GO

--Knowledge areas, originally entities, moved to schemas

CREATE SCHEMA [PMOES_Cost] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Schedule] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Scope] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Stakeholders] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Quality] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Communications] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Risk] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Procurement] AUTHORIZATION [dbo];
GO
CREATE SCHEMA [PMOES_Calculations] AUTHORIZATION [dbo];
GO

--TABLES

--COST VARIANCE TABLE, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE CV_CostVariance_tbl(
    CV_CostVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    CV_CostVariance_Date DATETIME NOT NULL,
    CV_CostVariance_EarnedValue FLOAT NOT NULL,
    CV_CostVariance_ActualCost FLOAT NOT NULL,
    CV_CostVariance_Value FLOAT NOT NULL,
);
GO


--ix, el nombre de la tabla, y luego el nombre de la columna
CREATE NONCLUSTERED INDEX ix_CV_CostVariance_tbl_CostVariance_Date
ON CV_CostVariance_tbl (CV_CostVariance_Date DESC);

CREATE NONCLUSTERED INDEX ix_CV_CostVariance_tbl_CostVariance_Value
ON CV_CostVariance_tbl (CV_CostVariance_Value DESC);

--exec sp_helpindex CostVariance_tbl;
GO

--SCEHDULE VARIANCE, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE SV_ScheduleVariance_tbl(
    SV_ScheduleVariance_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    SV_ScheduleVariance_Date DATETIME NOT NULL,
    SV_ScheduleVariance_EarnedValue FLOAT NOT NULL,
    SV_ScheduleVariance_PlannedValue FLOAT NOT NULL,
    SV_ScheduleVariance_Value FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_SV_ScheduleVariance_tbl_ScheduleVariance_Date
ON SV_ScheduleVariance_tbl (SV_ScheduleVariance_Date DESC);

CREATE NONCLUSTERED INDEX ix_SV_ScheduleVariance_tbl_ScheduleVariance_Value
ON SV_ScheduleVariance_tbl (SV_ScheduleVariance_Value DESC);
GO

--VARIANCE AT COMPLETION, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE VAC_VarianceAtCompletion_tbl(
    VAC_VarianceAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    VAC_VarianceAtCompletion_Date DATETIME NOT NULL,
    VAC_VarianceAtCompletion_BudgetAtCompletion FLOAT NOT NULL,
    VAC_VarianceAtCompletion_EstimateAtCompletion FLOAT NOT NULL,
    VAC_VarianceAtCompletion_Value FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Date
ON VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_Date DESC);

CREATE NONCLUSTERED INDEX ix_VAC_VarianceAtCompletion_tbl_VarianceAtCompletion_Value
ON VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_Value DESC);
GO

--COST PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE CPI_CostPerformanceIndex_tbl(
    CPI_CostPerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    CPI_CostPerformanceIndex_Date DATETIME NOT NULL,
    CPI_CostPerformanceIndex_EarnedValue FLOAT NOT NULL,
    CPI_CostPerformanceIndex_ActualCost  FLOAT NOT NULL,
    CPI_CostPerformanceIndex_Value  FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_CPI_CostPerformanceIndex_tbl_CostPerformanceIndex_Date
ON CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_Date DESC);

CREATE NONCLUSTERED INDEX ix_CPI_CostPerformanceIndex_tbl_CostPerformanceIndex_Value
ON CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_Value DESC);
GO

--SCHEDULE PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE SPI_SchedulePerformanceIndex_tbl(
    SPI_SchedulePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    SPI_SchedulePerformanceIndex_Date DATETIME NOT NULL,
    SPI_SchedulePerformanceIndex_EarnedValue FLOAT NOT NULL,
    SPI_SchedulePerformanceIndex_PlannedValue  FLOAT NOT NULL,
    SPI_SchedulePerformanceIndex_Value  FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_SPI_SchedulePerformanceIndex_tbl_SchedulePerformanceIndex_Date
ON SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_Date DESC);

CREATE NONCLUSTERED INDEX ix_SPI_SchedulePerformanceIndex_tbl_SchedulePerformanceIndex_Value
ON SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_Value DESC);
GO

--ESTIMATE AT COMPLETION, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE EAC_EstimateAtCompletion_tbl(
    EAC_EstimateAtCompletion_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    EAC_EstimateAtCompletion_Date DATETIME NOT NULL,
    EAC_EstimateAtCompletion_BudgetAtCompletion FLOAT NOT NULL,
    EAC_EstimateAtCompletion_CostPerformanceIndex  FLOAT NOT NULL,
    EAC_EstimateAtCompletion_Value  FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_EAC_EstimateAtCompletion_tbl_EstimateAtCompletion_Date
ON EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_Date DESC);

CREATE NONCLUSTERED INDEX ix_EAC_EstimateAtCompletion_tbl_EstimateAtCompletion_Value
ON EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_Value DESC);
GO

--ESTIMATE TO COMPLETE, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE ETC_EstimateToComplete_tbl(
    ETC_EstimateToComplete_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    ETC_EstimateToComplete_Date DATETIME NOT NULL,
    ETC_EstimateToComplete_EstimateAtCompletion FLOAT NOT NULL,
    ETC_EstimateToComplete_ActualCost  FLOAT NOT NULL,
    ETC_EstimateToComplete_Value  FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_ETC_EstimateToComplete_tbl_EstimateToComplete_Date
ON ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_Date DESC);

CREATE NONCLUSTERED INDEX ix_ETC_EstimateToComplete_tbl_EstimateToComplete_Value
ON ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_Value DESC);
GO

--TO COMPLETE PERFORMANCE INDEX, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE TCPI_ToCompletePerformanceIndex_tbl(
    TCPI_ToCompletePerformanceIndex_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    TCPI_ToCompletePerformanceIndex_Date DATETIME NOT NULL,
    TCPI_ToCompletePerformanceIndex_BudgetAtCompletion FLOAT NOT NULL,
    TCPI_ToCompletePerformanceIndex_EarnedValue FLOAT NOT NULL,
    TCPI_ToCompletePerformanceIndex_ActualCost  FLOAT NOT NULL,
    TCPI_ToCompletePerformanceIndex_Value  FLOAT NOT NULL,
);

CREATE NONCLUSTERED INDEX ix_TCPI_ToCompletePerformanceIndex_tbl_ToCompletePerformanceIndex_Date
ON TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_Date DESC);

CREATE NONCLUSTERED INDEX ix_TCPI_ToCompletePerformanceIndex_tbl_ToCompletePerformanceIndex_Value
ON TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_Value DESC);
GO

--TOTAL COST, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE TC_TotalCost_tbl(
    TC_TotalCost_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    TC_TotalCost_Date DATETIME NOT NULL,
    TC_TotalCost_TotalHours FLOAT NOT NULL,
    TC_TotalHours_CostHour FLOAT NOT NULL,
    TC_TotalCost_Value FLOAT NOT NULL  
);

CREATE NONCLUSTERED INDEX ix_TC_TotalCost_tbl_TotalCost_Date
ON TC_TotalCost_tbl (TC_TotalCost_Date DESC);

CREATE NONCLUSTERED INDEX ix_TC_TotalCost_tbl_TotalCost_Value
ON TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_Value DESC);
GO

--POWER_INTEREST, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE PIT_PowerInterest_tbl(
    PIT_PowerInterest_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    PIT_PowerInterest_Date DATETIME NOT NULL,
    PIT_PowerInterest_Power FLOAT NOT NULL,
    PIT_PowerInterest_Interest FLOAT NOT NULL,
    PIT_PowerInterest_Value INT NOT NULL
);

CREATE NONCLUSTERED INDEX ix_PIT_PowerInterest_tbl_PowerInterest_Date
ON PIT_PowerInterest_tbl (PIT_PowerInterest_Date DESC);

CREATE NONCLUSTERED INDEX ix_PIT_PowerInterest_tbl_PowerInterest_Value
ON PIT_PowerInterest_tbl (PIT_PowerInterest_Value DESC);
GO

--POWER_INFLUENCE, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE PIF_PowerInfluence_tbl(
    PIF_PowerInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    PIF_PowerInfluence_Date DATETIME NOT NULL,
    PIF_PowerInfluence_Power FLOAT NOT NULL,
    PIF_PowerInfluence_Influence FLOAT NOT NULL,
    PIF_PowerInfluence_Value INT NOT NULL
);

CREATE NONCLUSTERED INDEX ix_PIF_PowerInfluence_tbl_PowerInfluence_Date
ON PIF_PowerInfluence_tbl (PIF_PowerInfluence_Date DESC);

CREATE NONCLUSTERED INDEX ix_PIF_PowerInfluence_tbl_PowerInfluence_Value
ON PIF_PowerInfluence_tbl (PIF_PowerInfluence_Value DESC);
GO


--INTEREST_INFLUENCE, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE II_InterestInfluence_tbl(
    II_InterestInfluence_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    II_InterestInfluence_Date DATETIME NOT NULL,
    II_InterestInfluence_Power FLOAT NOT NULL,
    II_InterestInfluence_Influence FLOAT NOT NULL,
    II_InterestInfluence_Value INT NOT NULL
);

CREATE NONCLUSTERED INDEX ix_II_InterestInfluence_tbl_InterestInfluence_Date
ON II_InterestInfluence_tbl (II_InterestInfluence_Date DESC);

CREATE NONCLUSTERED INDEX ix_II_InterestInfluence_tbl_InterestInfluence_Value
ON II_InterestInfluence_tbl (II_InterestInfluence_Value DESC);
GO

--PRIORITY, PRIMARY TABLE, CALCULATION TYPE
CREATE TABLE PT_Priority_tbl(
    PT_Priority_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    PT_Priority_Date DATETIME NOT NULL,
    PT_Priority_Value INT NOT NULL
);

CREATE NONCLUSTERED INDEX ix_PT_Priority_tbl_InterestInfluence_Date
ON PT_Priority_tbl (PT_Priority_Date DESC);

CREATE NONCLUSTERED INDEX ix_PT_Priority_tbl_InterestInfluence_Value
ON PT_Priority_tbl (PT_Priority_Value DESC);
GO

--KNOWLEDGE AREA TABLE, PRIMARY TABLE, PRIMARY TABLE
CREATE TABLE KA_KnowledgeArea_tbl(
    KA_KnowledgeArea_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    KA_KnowledgeArea_Description VARCHAR(50) NOT NULL,
);
GO

--STATUS, PRIMARY TABLE, REFERENCE TYPE
CREATE TABLE ST_Status_tbl(
    ST_Status_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    ST_Status_Description VARCHAR(50) NOT NULL  --on hold, under review, active, draft, archived, cancelled
);
GO

--FIELD, PRIMARY TABLE, REFERENCE TYPE
CREATE TABLE FD_Field_tbl(
    FD_Field_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    FD_Field_Description VARCHAR(50) NOT NULL  --internal, external
);
GO

--ROLE, PRIMARY TABLE, REFERENCE TYPE
CREATE TABLE RL_Role_tbl(
    RL_Role_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    RL_Role_Description VARCHAR(50) NOT NULL  --final user (project analyst assigned to one project), stakeholder, product owner, PMO manager, Program Manager, data master (data maintenence)
);
GO

--PROJECT TYPE, PRIMARY TABLE, REFERENCE TYPE
CREATE TABLE PT_ProjectType_tbl(
    PT_ProjectType_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    PT_ProjectType_PJ_Project_ID INT NOT NULL
);
GO




--COST RECORD, SECONDARY TABLE, RECORD TYPE
CREATE TABLE CRC_CostRecord_tbl(
    CRC_CostRecord_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    CRC_CostRecord_Date DATETIME NOT NULL,
    CRC_CostRecord_KA_KnowledgeArea_ID INT NOT NULL, 
    CRC_CostRecord_CV_CostVariance_ID INT NOT NULL,
    CRC_CostRecord_SV_ScheduleVariance_ID INT NOT NULL,
    CRC_CostRecord_VAC_VarianceAtCompletion_ID  INT NOT NULL,
    CRC_CostRecord_CPI_CostPerformanceIndex_ID  INT NOT NULL,
    CRC_CostRecord_SPI_SchedulePerformanceIndex_ID  INT NOT NULL,
    CRC_CostRecord_EAC_EstimateAtCompletion_ID  INT NOT NULL,
    CRC_CostRecord_ETC_EstimateToComplete_ID  INT NOT NULL,
    CRC_CostRecord_TCPI_ToCompletePerformanceIndex_ID  INT NOT NULL,

    CONSTRAINT FK_CRC_CostRecord_tbl_KA_KnowledgeArea_ID FOREIGN KEY (CRC_CostRecord_KA_KnowledgeArea_ID)     
        REFERENCES dbo.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_CV_CostVariance_ID FOREIGN KEY (CRC_CostRecord_CV_CostVariance_ID)     
        REFERENCES dbo.CV_CostVariance_tbl (CV_CostVariance_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_SV_ScheduleVariance_ID FOREIGN KEY (CRC_CostRecord_SV_ScheduleVariance_ID)     
        REFERENCES dbo.SV_ScheduleVariance_tbl (SV_ScheduleVariance_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_VAC_VarianceAtCompletion_ID FOREIGN KEY (CRC_CostRecord_VAC_VarianceAtCompletion_ID)     
        REFERENCES dbo.VAC_VarianceAtCompletion_tbl (VAC_VarianceAtCompletion_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_CPI_CostPerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_CPI_CostPerformanceIndex_ID)     
        REFERENCES dbo.CPI_CostPerformanceIndex_tbl (CPI_CostPerformanceIndex_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_SPI_SchedulePerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_SPI_SchedulePerformanceIndex_ID)     
        REFERENCES dbo.SPI_SchedulePerformanceIndex_tbl (SPI_SchedulePerformanceIndex_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_EAC_EstimateAtCompletion_ID FOREIGN KEY (CRC_CostRecord_EAC_EstimateAtCompletion_ID)     
        REFERENCES dbo.EAC_EstimateAtCompletion_tbl (EAC_EstimateAtCompletion_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_ETC_EstimateToComplete_ID FOREIGN KEY (CRC_CostRecord_ETC_EstimateToComplete_ID)     
        REFERENCES dbo.ETC_EstimateToComplete_tbl (ETC_EstimateToComplete_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,

    CONSTRAINT FK_CRC_CostRecord_tbl_TCPI_ToCompletePerformanceIndex_ID FOREIGN KEY (CRC_CostRecord_TCPI_ToCompletePerformanceIndex_ID)     
        REFERENCES dbo.TCPI_ToCompletePerformanceIndex_tbl (TCPI_ToCompletePerformanceIndex_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,
);
GO

--COST REPORT, SECONDARY TABLE, TOOL TYPE
CREATE TABLE CRP_CostReport_tbl(
    CRP_CostReport_ID INT NOT NULL PRIMARY KEY,
    CRP_CostReport_DATE DATETIME,
    CRC_CostReport_PJ_Project_ID INT NOT NULL,
    --Foreign Keys
    CRC_CostReport_KA_KnowledgeArea_ID INT NOT NULL

    CONSTRAINT FK_CRC_CostReport_tbl_KA_KnowledgeArea_ID FOREIGN KEY (CRC_CostReport_KA_KnowledgeArea_ID)     
            REFERENCES dbo.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)     
            ON DELETE NO ACTION  
);
GO




--WORK PACKAGE, SECONDARY TABLE, RECORD TYPE
CREATE TABLE WP_WorkPackage_tbl(
    WP_WorkPackage_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    WP_WorkPackage_Date DATETIME NOT NULL,
    WP_WorkPackage_Level INT NOT NULL, 
    WP_WorkPackage_WorkPackageSuperior_ID INT NULL,  --this will simulate an FK to work with self-reference
    WP_WorkPackage_StartDate DATETIME,
    WP_WorkPackage_EndDate DATETIME,
    WP_WorkPackage_Name VARCHAR(20),
    WP_WorkPackage_Description VARCHAR(100),
    --Foreign Keys
    WP_WorkPackage_TC_TotalCost_ID INT NOT NULL,
    WP_WorkPackage_ST_Status_ID INT NOT NULL
    
    CONSTRAINT FK_WP_WorkPackage_tbl_TC_TotalCost_ID FOREIGN KEY (WP_WorkPackage_WorkPackageSuperior_ID)     
        REFERENCES dbo.TC_TotalCost_tbl (TC_TotalCost_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,
    
    CONSTRAINT FK_WP_WorkPackage_tbl_ST_Status_ID FOREIGN KEY (WP_WorkPackage_ST_Status_ID)     
        REFERENCES dbo.ST_Status_tbl (ST_Status_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION

);

CREATE NONCLUSTERED INDEX ix_WP_WorkPackage_tbl_WP_WorkPackage_Date
ON WP_WorkPackage_tbl (WP_WorkPackage_Date DESC);

CREATE NONCLUSTERED INDEX ix_WP_WorkPackage_tbl_WP_WorkPackage_WorkPackageSuperior_ID
ON WP_WorkPackage_tbl (WP_WorkPackage_WorkPackageSuperior_ID DESC);
GO


--WORK BREAKDOWN STRUCTURE (WBS), PRIMARY TABLE, TOOL TYPE
CREATE TABLE WBS_WorkBreakdown_tbl(
    WBS_WorkBreakdown_ID INT NOT NULL PRIMARY KEY,
    WBS_WorkBreakdown_DATE DATETIME,
    WBS_WorkBreakdown_PJ_Project_ID INT NOT NULL,
    --Foreign Keys
    WBS_WorkBreakdown_KA_KnowledgeArea_ID INT NOT NULL

    CONSTRAINT FK_WBS_WorkBreakdown_tbl_KA_KnowledgeArea_ID FOREIGN KEY (WBS_WorkBreakdown_KA_KnowledgeArea_ID)     
            REFERENCES dbo.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)     
            ON DELETE NO ACTION    
            ON UPDATE NO ACTION
);
GO


--REQUIREMENT RECORD, SECONDARY TABLE, RECORD TYPE
CREATE TABLE RR_RequirementRecord_tbl(
    RR_RequirementRecord_ID INT NOT NULL PRIMARY KEY,
    RR_RequirementRecord_DATE DATETIME,
    RR_RequirementRecord_Objective VARCHAR(100),
    RR_RequirementRecord_StatusDate DATETIME,
    RR_RequirementRecord_Version INT NOT NULL,
    --Foreign Keys
    RR_RequirementRecord_ST_Status_ID INT NOT NULL

    CONSTRAINT FK_RR_RequirementRecord_tbl_ST_Status_ID FOREIGN KEY (RR_RequirementRecord_ST_Status_ID)     
        REFERENCES dbo.ST_Status_tbl (ST_Status_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION

);
GO

CREATE NONCLUSTERED INDEX ix_RR_RequirementRecord_tbl_WP_RR_RequirementRecord_DATE
ON RR_RequirementRecord_tbl (RR_RequirementRecord_DATE DESC);
GO


--TRACEABILITY MATRIX, SECONDARY TABLE, TOOL TYPE
CREATE TABLE TM_TraceabilityMatrix_tbl(
    TM_TraceabilityMatrix_ID INT NOT NULL PRIMARY KEY,
    TM_TraceabilityMatrix_DATE DATETIME,
    --Foreign Keys
    TM_Traceability_Matrix_PJ_Project_ID INT NOT NULL,
    TM_Traceability_Matrix_KA_KnowledgeArea_ID INT NOT NULL

    CONSTRAINT FK_TM_TraceabilityMatrix_tbl_KA_KnowledgeArea_ID FOREIGN KEY (TM_Traceability_Matrix_KA_KnowledgeArea_ID)     
            REFERENCES dbo.KA_KnowledgeArea_tbl (KA_KnowledgeArea_ID)     
            ON DELETE NO ACTION    
            ON UPDATE NO ACTION
);
GO

--PROJECT, SECONDARY TABLE, REFERENCE TYPE
CREATE TABLE PJ_Project_tbl(
    PJ_Project_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    PJ_Project_Name VARCHAR(20),
    PJ_Project_Description VARCHAR(100),
    --Foreign Keys
    PJ_Project_CRP_CostReport_ID INT NOT NULL,     
    PJ_Project_WBS_WorkBreakdown_ID INT NOT NULL,  
    PJ_Project_TM_TraceabilityMatrix_ID INT NOT NULL, 
    PJ_Project_SKL_StakeholderList_ID INT NOT NULL, --next sprint
    PJ_Project_SEM_StakeholderEvMatrix_ID INT NOT NULL,  --next sprint
    PJ_Project_COM_CommunicationsStategy_ID INT NOT NULL,  --next sprint
    PJ_Project_CMA_CommunicationsMatrix_ID INT NOT NULL --next sprint

);
GO

--DASHBOARD, SECONDARY TABLE, TOOL TYPE
CREATE TABLE DB_Dashboard_tbl(
    DB_Dashboard_ID INT IDENTITY(1, 1) NOT NULL PRIMARY KEY,
    DB_Dashboard_PJ_Project_ID INT NOT NULL
);
GO



-- COST REPORT COST RECORD, TERCIARY TABLE, JOIN TYPE
CREATE TABLE CRC_CostReport_CRP_CostRecord_tbl(
    CRP_CostReport_ID INT NOT NULL,
    CRC_CostRecord_ID INT NOT NULL

    CONSTRAINT CRC_CostReport_CRP_CostRecord_tbl_CRP_CostReport_ID FOREIGN KEY (CRP_CostReport_ID)     
        REFERENCES CRP_CostReport_tbl (CRP_CostReport_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,
    
    CONSTRAINT CRC_CostReport_CRP_CostRecord_tbl_CRC_CostRecord_ID FOREIGN KEY (CRC_CostRecord_ID)     
        REFERENCES CRC_CostRecord_tbl (CRC_CostRecord_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION
);


-- WORK BREAKDOWN WORK PACKAGE, TERCIARY TABLE, JOIN TYPE
CREATE TABLE WBS_WorkBreakdown_WP_WorkPackage_tbl(
    WBS_WorkBreakdown_ID INT NOT NULL,
    WP_WorkPackage_ID INT NOT NULL

    CONSTRAINT WBS_WorkBreakdown_WP_WorkPackage_tbl_WBS_WorkBreakdown_ID FOREIGN KEY (WBS_WorkBreakdown_ID)     
        REFERENCES WBS_WorkBreakdown_tbl (WBS_WorkBreakdown_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION,
    
    CONSTRAINT WBS_WorkBreakdown_WP_WorkPackage_tbl_CRC_CostRecord_ID FOREIGN KEY (WP_WorkPackage_ID)     
        REFERENCES WP_WorkPackage_tbl (WP_WorkPackage_ID)     
        ON DELETE NO ACTION    
        ON UPDATE NO ACTION
);




--DICTIONARY, QUERY.  TRANSLATE TO A VIEW
 Use Ulysses;
 Go
 
--SELECT * FROM INFORMATION_SCHEMA.COLUMNS