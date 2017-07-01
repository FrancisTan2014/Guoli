/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     2017/7/1 10:18:19                            */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PersonInfo') and o.name = 'FK_PERSONIN_DEPARTINF_DEPARTIN')
alter table PersonInfo
   drop constraint FK_PERSONIN_DEPARTINF_DEPARTIN
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PersonInfo') and o.name = 'FK_PERSONIN_POSITION_POSTS')
alter table PersonInfo
   drop constraint FK_PERSONIN_POSITION_POSTS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('View_Station')
            and   type = 'V')
   drop view View_Station
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewTrainNoLIne')
            and   type = 'V')
   drop view ViewTrainNoLIne
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewTrainMoment')
            and   type = 'V')
   drop view ViewTrainMoment
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewSignPoint')
            and   type = 'V')
   drop view ViewSignPoint
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorWifiRecord')
            and   type = 'V')
   drop view ViewInstructorWifiRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorTempTake')
            and   type = 'V')
   drop view ViewInstructorTempTake
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorTeach')
            and   type = 'V')
   drop view ViewInstructorTeach
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorReviewScore')
            and   type = 'V')
   drop view ViewInstructorReviewScore
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorRepair')
            and   type = 'V')
   drop view ViewInstructorRepair
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorPlan')
            and   type = 'V')
   drop view ViewInstructorPlan
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorPeccancy')
            and   type = 'V')
   drop view ViewInstructorPeccancy
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorLocoQuality')
            and   type = 'V')
   drop view ViewInstructorLocoQuality
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorKeyPerson')
            and   type = 'V')
   drop view ViewInstructorKeyPerson
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorGoodJob')
            and   type = 'V')
   drop view ViewInstructorGoodJob
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorCheck')
            and   type = 'V')
   drop view ViewInstructorCheck
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorAnalysis')
            and   type = 'V')
   drop view ViewInstructorAnalysis
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewInstructorAccept')
            and   type = 'V')
   drop view ViewInstructorAccept
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewPersonInfo')
            and   type = 'V')
   drop view ViewPersonInfo
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewExamRecords')
            and   type = 'V')
   drop view ViewExamRecords
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewExamNotify')
            and   type = 'V')
   drop view ViewExamNotify
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewExamFiles')
            and   type = 'V')
   drop view ViewExamFiles
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewDriveRecord')
            and   type = 'V')
   drop view ViewDriveRecord
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewBaseLine')
            and   type = 'V')
   drop view ViewBaseLine
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ViewAnnounceCommands')
            and   type = 'V')
   drop view ViewAnnounceCommands
go

alter table AnnounceCommands
   drop constraint PK_ANNOUNCECOMMANDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('AnnounceCommands')
            and   type = 'U')
   drop table AnnounceCommands
go

alter table Announcement
   drop constraint PK_ANNOUNCEMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Announcement')
            and   type = 'U')
   drop table Announcement
go

alter table BaseLine
   drop constraint PK_BASELINE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseLine')
            and   type = 'U')
   drop table BaseLine
go

alter table BaseStation
   drop constraint PK_BASESTATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('BaseStation')
            and   type = 'U')
   drop table BaseStation
go

alter table DbUpdateLog
   drop constraint PK_DBUPDATELOG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DbUpdateLog')
            and   type = 'U')
   drop table DbUpdateLog
go

alter table DepartInfo
   drop constraint PK_DEPARTINFO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DepartInfo')
            and   type = 'U')
   drop table DepartInfo
go

alter table DrivePlan
   drop constraint PK_DRIVEPLAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DrivePlan')
            and   type = 'U')
   drop table DrivePlan
go

alter table DriveRecords
   drop constraint PK_DRIVERECORDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DriveRecords')
            and   type = 'U')
   drop table DriveRecords
go

alter table DriveSignPoint
   drop constraint PK_DRIVESIGNPOINT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DriveSignPoint')
            and   type = 'U')
   drop table DriveSignPoint
go

alter table DriveTrainNoAndLine
   drop constraint PK_DRIVETRAINNOANDLINE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('DriveTrainNoAndLine')
            and   type = 'U')
   drop table DriveTrainNoAndLine
go

alter table ExamAnswers
   drop constraint PK_EXAMANSWERS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamAnswers')
            and   type = 'U')
   drop table ExamAnswers
go

alter table ExamErrorQuestions
   drop constraint PK_EXAMERRORQUESTIONS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamErrorQuestions')
            and   type = 'U')
   drop table ExamErrorQuestions
go

alter table ExamFiles
   drop constraint PK_EXAMFILES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamFiles')
            and   type = 'U')
   drop table ExamFiles
go

alter table ExamNotify
   drop constraint PK_EXAMNOTIFY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamNotify')
            and   type = 'U')
   drop table ExamNotify
go

alter table ExamQuestion
   drop constraint PK_EXAMQUESTION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamQuestion')
            and   type = 'U')
   drop table ExamQuestion
go

alter table ExamRecords
   drop constraint PK_EXAMRECORDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamRecords')
            and   type = 'U')
   drop table ExamRecords
go

alter table ExamType
   drop constraint PK_EXAMTYPE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExamType')
            and   type = 'U')
   drop table ExamType
go

alter table ExceptionLog
   drop constraint PK_EXCEPTIONLOG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ExceptionLog')
            and   type = 'U')
   drop table ExceptionLog
go

alter table Feedback
   drop constraint PK_FEEDBACK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Feedback')
            and   type = 'U')
   drop table Feedback
go

alter table InstructorAccept
   drop constraint PK_INSTRUCTORACCEPT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorAccept')
            and   type = 'U')
   drop table InstructorAccept
go

alter table InstructorAnalysis
   drop constraint PK_INSTRUCTORANALYSIS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorAnalysis')
            and   type = 'U')
   drop table InstructorAnalysis
go

alter table InstructorCheck
   drop constraint PK_INSTRUCTORCHECK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorCheck')
            and   type = 'U')
   drop table InstructorCheck
go

alter table InstructorGoodJob
   drop constraint PK_INSTRUCTORGOODJOB
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorGoodJob')
            and   type = 'U')
   drop table InstructorGoodJob
go

alter table InstructorKeyPerson
   drop constraint PK_INSTRUCTORKEYPERSON
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorKeyPerson')
            and   type = 'U')
   drop table InstructorKeyPerson
go

alter table InstructorLocoQuality
   drop constraint PK_INSTRUCTORLOCOQUALITY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorLocoQuality')
            and   type = 'U')
   drop table InstructorLocoQuality
go

alter table InstructorPeccancy
   drop constraint PK_INSTRUCTORPECCANCY
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorPeccancy')
            and   type = 'U')
   drop table InstructorPeccancy
go

alter table InstructorPlan
   drop constraint PK_INSTRUCTORPLAN
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorPlan')
            and   type = 'U')
   drop table InstructorPlan
go

alter table InstructorQuota
   drop constraint PK_INSTRUCTORQUOTA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorQuota')
            and   type = 'U')
   drop table InstructorQuota
go

alter table InstructorQuotaRecord
   drop constraint PK_INSTRUCTORQUOTARECORD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorQuotaRecord')
            and   type = 'U')
   drop table InstructorQuotaRecord
go

alter table InstructorRepair
   drop constraint PK_INSTRUCTORREPAIR
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorRepair')
            and   type = 'U')
   drop table InstructorRepair
go

alter table InstructorReviewScore
   drop constraint PK_INSTRUCTORREVIEWSCORE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorReviewScore')
            and   type = 'U')
   drop table InstructorReviewScore
go

alter table InstructorReviewStandard
   drop constraint PK_INSTRUCTORREVIEWSTANDARD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorReviewStandard')
            and   type = 'U')
   drop table InstructorReviewStandard
go

alter table InstructorRouterPosition
   drop constraint PK_INSTRUCTORROUTERPOSITION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorRouterPosition')
            and   type = 'U')
   drop table InstructorRouterPosition
go

alter table InstructorTeach
   drop constraint PK_INSTRUCTORTEACH
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorTeach')
            and   type = 'U')
   drop table InstructorTeach
go

alter table InstructorTempTake
   drop constraint PK_INSTRUCTORTEMPTAKE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorTempTake')
            and   type = 'U')
   drop table InstructorTempTake
go

alter table InstructorWifiRecord
   drop constraint PK_INSTRUCTORWIFIRECORD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('InstructorWifiRecord')
            and   type = 'U')
   drop table InstructorWifiRecord
go

alter table LineAnnounceCommands
   drop constraint PK_LINEANNOUNCECOMMANDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LineAnnounceCommands')
            and   type = 'U')
   drop table LineAnnounceCommands
go

alter table LineStations
   drop constraint PK_LINESTATIONS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('LineStations')
            and   type = 'U')
   drop table LineStations
go

alter table OperateLog
   drop constraint PK_OPERATELOG
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OperateLog')
            and   type = 'U')
   drop table OperateLog
go

alter table OracleTableMaxId
   drop constraint PK_ORACLETABLEMAXID
go

if exists (select 1
            from  sysobjects
           where  id = object_id('OracleTableMaxId')
            and   type = 'U')
   drop table OracleTableMaxId
go

alter table PersonInfo
   drop constraint PK_PERSONINFO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PersonInfo')
            and   type = 'U')
   drop table PersonInfo
go

alter table Posts
   drop constraint PK_POSTS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Posts')
            and   type = 'U')
   drop table Posts
go

alter table PrimaryIdRelation
   drop constraint PK_PRIMARYIDRELATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PrimaryIdRelation')
            and   type = 'U')
   drop table PrimaryIdRelation
go

alter table StationFiles
   drop constraint PK_STATIONFILES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('StationFiles')
            and   type = 'U')
   drop table StationFiles
go

alter table SystemUser
   drop constraint PK_SYSTEMUSER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('SystemUser')
            and   type = 'U')
   drop table SystemUser
go

alter table TraficFileType
   drop constraint PK_TRAFICFILETYPE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficFileType')
            and   type = 'U')
   drop table TraficFileType
go

alter table TraficFiles
   drop constraint PK_TRAFICFILES
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficFiles')
            and   type = 'U')
   drop table TraficFiles
go

alter table TraficKeywords
   drop constraint PK_TRAFICKEYWORDS
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficKeywords')
            and   type = 'U')
   drop table TraficKeywords
go

alter table TraficSearchRecord
   drop constraint PK_TRAFICSEARCHRECORD
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficSearchRecord')
            and   type = 'U')
   drop table TraficSearchRecord
go

alter table TraficSearchResult
   drop constraint PK_TRAFICSEARCHRESULT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficSearchResult')
            and   type = 'U')
   drop table TraficSearchResult
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TraficSearchText')
            and   type = 'U')
   drop table TraficSearchText
go

alter table TrainFormation
   drop constraint PK_TRAINFORMATION
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrainFormation')
            and   type = 'U')
   drop table TrainFormation
go

alter table TrainMoment
   drop constraint PK_TRAINMOMENT
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrainMoment')
            and   type = 'U')
   drop table TrainMoment
go

alter table TrainNo
   drop constraint PK_TRAINNO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrainNo')
            and   type = 'U')
   drop table TrainNo
go

alter table TrainNoLine
   drop constraint PK_TRAINNOLINE
go

if exists (select 1
            from  sysobjects
           where  id = object_id('TrainNoLine')
            and   type = 'U')
   drop table TrainNoLine
go

if exists (select 1
   from  sysobjects where type = 'D'
   and name = 'Default_1'
   )
   drop default Default_1
go

/*==============================================================*/
/* Default: Default_1                                           */
/*==============================================================*/
create default Default_1
    as
go

/*==============================================================*/
/* Table: AnnounceCommands                                      */
/*==============================================================*/
create table AnnounceCommands (
   Id                   bigint               identity,
   CommandNo            varchar(20)          not null,
   CommandInterval      nvarchar(500)        not null default '',
   Direction            nvarchar(5)          not null default '',
   SpeedLimitLocation   nvarchar(100)        not null default '',
   StartEndTime         nvarchar(100)        not null default '',
   LoseEffectTime       datetime             not null default '1900-01-01',
   LimitedSpeed         int                  not null default 0,
   AddTime              datetime             not null default getdate(),
   IsActive             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('AnnounceCommands') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'AnnounceCommands' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���н�ʾ�����', 
   'user', @CurrentUser, 'table', 'AnnounceCommands'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommandNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'CommandNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'CommandNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommandInterval')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'CommandInterval'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ָʾ����',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'CommandInterval'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Direction')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'Direction'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г����з��򣬴˷���������ڱ�����˵�����������еķ����Ϊ�����С���Զ�뱱�������з����Ϊ�����С�',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'Direction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SpeedLimitLocation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'SpeedLimitLocation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ٵص�',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'SpeedLimitLocation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StartEndTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'StartEndTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ֹʱ�䣨�ַ�����ʽ��',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'StartEndTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LoseEffectTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'LoseEffectTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʶ�˽�ʾ�����ʧЧʱ��',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'LoseEffectTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LimitedSpeed')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'LimitedSpeed'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ֵ��km/h��',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'LimitedSpeed'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('AnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsActive')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'IsActive'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʶ�˽�ʾ���ǰ�Ƿ���Ч',
   'user', @CurrentUser, 'table', 'AnnounceCommands', 'column', 'IsActive'
go

alter table AnnounceCommands
   add constraint PK_ANNOUNCECOMMANDS primary key (Id)
go

/*==============================================================*/
/* Table: Announcement                                          */
/*==============================================================*/
create table Announcement (
   Id                   int                  identity,
   Title                nvarchar(50)         not null,
   AnnounceType         int                  not null,
   Content              nvarchar(max)        not null,
   FileName             nvarchar(100)        not null default '',
   FilePath             nvarchar(100)        not null default '',
   SystemUserId         int                  not null,
   PubTime              datetime             not null default getdate()
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Announcement') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Announcement' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '������Ϣ��', 
   'user', @CurrentUser, 'table', 'Announcement'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Title')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'Title'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'Title'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnnounceType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'AnnounceType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ͣ�1 �ļ��� 2 �ı���',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'AnnounceType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ϣ',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'FileName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�����',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'FileName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FilePath')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'FilePath'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ���ַ',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'FilePath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SystemUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'SystemUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ԱId',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'SystemUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Announcement')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PubTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'PubTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Announcement', 'column', 'PubTime'
go

alter table Announcement
   add constraint PK_ANNOUNCEMENT primary key (Id)
go

/*==============================================================*/
/* Table: BaseLine                                              */
/*==============================================================*/
create table BaseLine (
   Id                   int                  identity,
   LineName             nvarchar(50)         not null,
   FirstStationId       int                  not null,
   FirstStation         nvarchar(50)         not null,
   LastStationId        int                  not null,
   LastStation          nvarchar(50)         not null,
   LineLength           decimal              not null default 0.0,
   Spell                varchar(20)          not null default '',
   UpdateTime           datetime             not null,
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('BaseLine') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'BaseLine' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '������·��Ϣ��', 
   'user', @CurrentUser, 'table', 'BaseLine'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LineName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LineName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FirstStationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'FirstStationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·��ʼվId��������վ��Ϣ������',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'FirstStationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FirstStation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'FirstStation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʼվ����',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'FirstStation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastStationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LastStationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·�յ�վId��������վ��Ϣ������',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LastStationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastStation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LastStation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�յ�վ����',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LastStation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineLength')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LineLength'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·���ȣ���������',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'LineLength'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Spell')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'Spell'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƴ����д',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'Spell'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'BaseLine', 'column', 'UpdateTime'
go

alter table BaseLine
   add constraint PK_BASELINE primary key (Id)
go

/*==============================================================*/
/* Table: BaseStation                                           */
/*==============================================================*/
create table BaseStation (
   Id                   int                  identity,
   StationName          nvarchar(50)         not null,
   SN                   int                  not null,
   Spell                varchar(20)          not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('BaseStation') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'BaseStation' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '������վ��Ϣ', 
   'user', @CurrentUser, 'table', 'BaseStation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseStation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseStation', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'BaseStation', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('BaseStation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'BaseStation', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'BaseStation', 'column', 'IsDelete'
go

alter table BaseStation
   add constraint PK_BASESTATION primary key (Id)
go

/*==============================================================*/
/* Table: DbUpdateLog                                           */
/*==============================================================*/
create table DbUpdateLog (
   Id                   int                  identity,
   TableName            varchar(50)          not null,
   UpdateType           int                  not null,
   TargetId             int                  not null,
   UpdateTime           datetime             not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DbUpdateLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DbUpdateLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���ݿ���¼�¼��', 
   'user', @CurrentUser, 'table', 'DbUpdateLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DbUpdateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TableName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'TableName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���µı������',
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'TableName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DbUpdateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'UpdateType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ͣ�1 Insert�� 2 Update�� 3 Delete��',
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'UpdateType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DbUpdateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TargetId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'TargetId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ŀ¼��������',
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'TargetId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DbUpdateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'DbUpdateLog', 'column', 'UpdateTime'
go

alter table DbUpdateLog
   add constraint PK_DBUPDATELOG primary key (Id)
go

/*==============================================================*/
/* Table: DepartInfo                                            */
/*==============================================================*/
create table DepartInfo (
   Id                   int                  identity,
   DepartmentName       nvarchar(20)         not null,
   ParentId             int                  not null,
   IsDelete             bit                  not null default 0,
   AddTime              datetime             not null default getdate()
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DepartInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DepartInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��������β�����Ϣ', 
   'user', @CurrentUser, 'table', 'DepartInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DepartInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartmentName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DepartInfo', 'column', 'DepartmentName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'DepartInfo', 'column', 'DepartmentName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DepartInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DepartInfo', 'column', 'ParentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id',
   'user', @CurrentUser, 'table', 'DepartInfo', 'column', 'ParentId'
go

alter table DepartInfo
   add constraint PK_DEPARTINFO primary key (Id)
go

/*==============================================================*/
/* Table: DrivePlan                                             */
/*==============================================================*/
create table DrivePlan (
   Id                   int                  identity,
   LineName             nvarchar(50)         not null,
   TrainCode            nvarchar(20)         not null,
   LocoType             nvarchar(20)         not null default '',
   DriverNo             varchar(20)          not null,
   DriverName           nvarchar(20)         not null,
   ViceDriverNo         varchar(20)          not null,
   ViceDriverName       nvarchar(20)         not null,
   StudentNo            varchar(20)          not null default '',
   StudentName          nvarchar(20)         not null default '',
   OtherNo1             varchar(20)          not null default '',
   OtherName1           nvarchar(20)         not null,
   OtherNo2             varchar(20)          not null default '',
   OtherName2           nvarchar(20)         not null default '',
   AttendTime           datetime             not null,
   StartTime            datetime             not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DrivePlan') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DrivePlan' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г��ƻ���', 
   'user', @CurrentUser, 'table', 'DrivePlan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'LineName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·����',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'LineName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'TrainCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'TrainCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocoType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'LocoType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ͺ�',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'LocoType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'DriverNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˾������',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'DriverNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'DriverName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˾������',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'DriverName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'ViceDriverNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾������',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'ViceDriverNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'ViceDriverName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾������',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'ViceDriverName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudentNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StudentNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ѧԱ����',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StudentNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudentName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StudentName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ѧԱ����',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StudentName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OtherNo1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherNo1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ա����1',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherNo1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OtherNo2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherNo2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ա����2',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherNo2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OtherName2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherName2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Ա����2',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'OtherName2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AttendTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'AttendTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'AttendTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DrivePlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StartTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StartTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'DrivePlan', 'column', 'StartTime'
go

alter table DrivePlan
   add constraint PK_DRIVEPLAN primary key (Id)
go

/*==============================================================*/
/* Table: DriveRecords                                          */
/*==============================================================*/
create table DriveRecords (
   Id                   int                  identity,
   DriverId1            int                  not null,
   DriverId2            int                  not null default 0,
   ViceDriverId         int                  not null default 0,
   StudentDriverId      int                  not null default 0,
   OtherDriverId        int                  not null default 0,
   LocomotiveType       varchar(50)          not null default '',
   AttendTime           datetime             not null default '1900-01-01',
   GetTrainTime         datetime             not null default '1900-01-01',
   LeaveDepotTime1      datetime             not null default '1900-01-01',
   LeaveDepotTime2      datetime             not null default '1900-01-01',
   AttendForecast       nvarchar(500)        not null default '',
   ArriveDepotTime1     datetime             not null default '1900-01-01',
   ArriveDepotTime2     datetime             not null default '1900-01-01',
   GiveTrainTime        datetime             not null default '1900-01-01',
   RecordEndTime        datetime             not null default '0.0',
   OperateConsume       decimal              not null default 0.0,
   StopConsume          decimal              not null default 0.0,
   RecieveEnergy        decimal              not null default 0.0,
   LeftEnergy           decimal              not null default 0.0,
   EngineOil            decimal              not null default 0.0,
   AirCompressorOil     decimal              not null default 0.0,
   TurbineOil           decimal              not null default 0.0,
   GearOil              decimal              not null default 0.0,
   GovernorOil          decimal              not null default 0.0,
   OtherOil             decimal              not null default 0.0,
   Staple               decimal              not null default 0,
   MultiLocoDepot       nvarchar(20)         not null default '',
   MultiLocoType        varchar(20)          not null default '',
   MultiLocoSection     nvarchar(50)         not null default '',
   EndSummary           nvarchar(500)        not null default '',
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DriveRecords') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DriveRecords' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г��г���¼��', 
   'user', @CurrentUser, 'table', 'DriveRecords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'DriverId1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id����������Ա��Ϣ��Id',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'DriverId1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'DriverId2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڶ���˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'DriverId2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ViceDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ViceDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudentDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'StudentDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ѧԱId����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'StudentDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OtherDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OtherDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ԱId������ ����Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OtherDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocomotiveType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LocomotiveType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ͺţ���HXDC-6355',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LocomotiveType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AttendTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AttendTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���γ���ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AttendTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GetTrainTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GetTrainTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���γ�������ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GetTrainTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LeaveDepotTime1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeaveDepotTime1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���γ��ڳ�����ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeaveDepotTime1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LeaveDepotTime2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeaveDepotTime2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���γ��ڳ����ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeaveDepotTime2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AttendForecast')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AttendForecast'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ڻᣬҲ�Ƴ���С���',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AttendForecast'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArriveDepotTime1')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ArriveDepotTime1'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��д���뱾��ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ArriveDepotTime1'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArriveDepotTime2')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ArriveDepotTime2'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��д�������ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'ArriveDepotTime2'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GiveTrainTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GiveTrainTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��д������ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GiveTrainTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RecordEndTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'RecordEndTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'RecordEndTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperateConsume')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OperateConsume'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����г���ת������/����',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OperateConsume'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StopConsume')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'StopConsume'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����г��ڶ��ڴ�ʪ���ʱ�����Դ����/�磩����',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'StopConsume'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RecieveEnergy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'RecieveEnergy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ӳ�ʱ��Դ����',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'RecieveEnergy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LeftEnergy')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeftEnergy'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��Դʣ����',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'LeftEnergy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EngineOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'EngineOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'EngineOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AirCompressorOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AirCompressorOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AirCompressorOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TurbineOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'TurbineOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '͸ƽ��������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'TurbineOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GearOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GearOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GearOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GovernorOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GovernorOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'GovernorOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OtherOil')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OtherOil'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'OtherOil'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Staple')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'Staple'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˿��������ƥ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'Staple'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MultiLocoDepot')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoDepot'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoDepot'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MultiLocoType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���������ͺ�',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MultiLocoSection')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoSection'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������������',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'MultiLocoSection'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EndSummary')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'EndSummary'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ڻᣬҲ������С���',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'EndSummary'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'DriveRecords', 'column', 'IsDelete'
go

alter table DriveRecords
   add constraint PK_DRIVERECORDS primary key (Id)
go

/*==============================================================*/
/* Table: DriveSignPoint                                        */
/*==============================================================*/
create table DriveSignPoint (
   Id                   int                  identity,
   DriveRecordId        int                  not null,
   StationId            int                  not null,
   ArriveTime           datetime             not null default '1900-01-01',
   LeaveTime            datetime             not null default '1900-01-01',
   EarlyMinutes         int                  not null default 0,
   LateMinutes          int                  not null default 0,
   EarlyOrLateReason    nvarchar(100)        not null default ''
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DriveSignPoint') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DriveSignPoint' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г�ǩ���¼�Լ����������仯��¼', 
   'user', @CurrentUser, 'table', 'DriveSignPoint'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriveRecordId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'DriveRecordId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���˼�¼Id���������˼�¼������',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'DriveRecordId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'StationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վId��������վ��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'StationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArriveTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'ArriveTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�ʵ��ﱾվʱ��',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'ArriveTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LeaveTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'LeaveTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�ʳ���ʱ��',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'LeaveTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EarlyMinutes')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'EarlyMinutes'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г���������',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'EarlyMinutes'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LateMinutes')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'LateMinutes'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г���������',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'LateMinutes'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveSignPoint')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EarlyOrLateReason')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'EarlyOrLateReason'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ԭ��',
   'user', @CurrentUser, 'table', 'DriveSignPoint', 'column', 'EarlyOrLateReason'
go

alter table DriveSignPoint
   add constraint PK_DRIVESIGNPOINT primary key (Id)
go

/*==============================================================*/
/* Table: DriveTrainNoAndLine                                   */
/*==============================================================*/
create table DriveTrainNoAndLine (
   Id                   int                  identity,
   DriveRecordId        int                  not null,
   TrainNoId            int                  not null,
   LineId               int                  not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('DriveTrainNoAndLine') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��������-����-��·��Ӧ��ϵ', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriveRecordId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'DriveRecordId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���˼�¼Id���������˼�¼������',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'DriveRecordId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainNoId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'TrainNoId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id������������Ϣ������',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'TrainNoId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'LineId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·Id��������·��Ϣ������',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'LineId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('DriveTrainNoAndLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'DriveTrainNoAndLine', 'column', 'IsDelete'
go

alter table DriveTrainNoAndLine
   add constraint PK_DRIVETRAINNOANDLINE primary key (Id)
go

/*==============================================================*/
/* Table: ExamAnswers                                           */
/*==============================================================*/
create table ExamAnswers (
   Id                   int                  identity,
   QuestionId           int                  not null,
   Answer               nvarchar(max)        not null,
   IsRight              bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamAnswers') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamAnswers' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����𰸱�', 
   'user', @CurrentUser, 'table', 'ExamAnswers'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamAnswers')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamAnswers')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuestionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'QuestionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id���������������',
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'QuestionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamAnswers')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Answer')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'Answer'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'ExamAnswers', 'column', 'Answer'
go

alter table ExamAnswers
   add constraint PK_EXAMANSWERS primary key (Id)
go

/*==============================================================*/
/* Table: ExamErrorQuestions                                    */
/*==============================================================*/
create table ExamErrorQuestions (
   Id                   int                  identity,
   PersionId            int                  not null,
   QuestionId           int                  not null,
   ErrorCount           int                  not null,
   HasRemembered        bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamErrorQuestions') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamErrorQuestions' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�ҵĴ���', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamErrorQuestions')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamErrorQuestions')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'PersionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ԱId��������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'PersionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamErrorQuestions')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuestionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'QuestionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id���������������',
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'QuestionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamErrorQuestions')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ErrorCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'ErrorCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'ErrorCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamErrorQuestions')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HasRemembered')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'HasRemembered'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��ס',
   'user', @CurrentUser, 'table', 'ExamErrorQuestions', 'column', 'HasRemembered'
go

alter table ExamErrorQuestions
   add constraint PK_EXAMERRORQUESTIONS primary key (Id)
go

/*==============================================================*/
/* Table: ExamFiles                                             */
/*==============================================================*/
create table ExamFiles (
   Id                   int                  identity,
   ExamTypeId           int                  not null,
   FileName             nvarchar(50)         not null,
   FileDesc             nvarchar(500)        not null default '',
   FilePath             nvarchar(200)        not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamFiles') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamFiles' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����ļ���', 
   'user', @CurrentUser, 'table', 'ExamFiles'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamTypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'ExamTypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������Id��������ExamType������',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'ExamTypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FileName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ�����',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FileName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileDesc')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FileDesc'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ�����',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FileDesc'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FilePath')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FilePath'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ���ַ',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'FilePath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'ExamFiles', 'column', 'IsDelete'
go

alter table ExamFiles
   add constraint PK_EXAMFILES primary key (Id)
go

/*==============================================================*/
/* Table: ExamNotify                                            */
/*==============================================================*/
create table ExamNotify (
   Id                   int                  identity,
   ExamName             nvarchar(100)        not null,
   PostId               int                  not null,
   ExamFilesId          int                  not null,
   QuestionCount        int                  not null,
   PassScore            int                  not null,
   ResitCount           int                  not null,
   EndTime              datetime             not null,
   TimeLimit            int                  not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamNotify') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamNotify' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����֪ͨ��', 
   'user', @CurrentUser, 'table', 'ExamNotify'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ExamName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ExamName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'PostId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ�μ���Ա�ĸ�λId��������λ��Ϣ�������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'PostId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamFilesId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ExamFilesId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ļ�Id',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ExamFilesId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuestionCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'QuestionCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'QuestionCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PassScore')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'PassScore'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ͨ������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'PassScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ResitCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ResitCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'ResitCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EndTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'EndTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Խ�ֹ����',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'EndTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TimeLimit')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'TimeLimit'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ������λ���֣�',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'TimeLimit'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamNotify')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'ExamNotify', 'column', 'IsDelete'
go

alter table ExamNotify
   add constraint PK_EXAMNOTIFY primary key (Id)
go

/*==============================================================*/
/* Table: ExamQuestion                                          */
/*==============================================================*/
create table ExamQuestion (
   Id                   int                  identity,
   ExamFileId           int                  not null,
   Question             nvarchar(max)        not null,
   AnswerType           int                  not null default ''
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamQuestion') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamQuestion' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���������', 
   'user', @CurrentUser, 'table', 'ExamQuestion'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamQuestion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamQuestion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamFileId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'ExamFileId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������Id������������������',
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'ExamFileId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamQuestion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Question')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'Question'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'Question'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamQuestion')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnswerType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'AnswerType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ���ͣ�1 ��ѡ�� 2 ��ѡ�� 3 �жϣ���',
   'user', @CurrentUser, 'table', 'ExamQuestion', 'column', 'AnswerType'
go

alter table ExamQuestion
   add constraint PK_EXAMQUESTION primary key (Id)
go

/*==============================================================*/
/* Table: ExamRecords                                           */
/*==============================================================*/
create table ExamRecords (
   Id                   int                  identity,
   ExamNotifyId         int                  not null,
   PersionId            int                  not null,
   RightCount           int                  not null,
   WrongCount           int                  not null,
   Score                int                  not null,
   ExamTime             datetime             not null,
   TimeSpends           int                  not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamRecords') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamRecords' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��Ա���Լ�¼��', 
   'user', @CurrentUser, 'table', 'ExamRecords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamNotifyId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'ExamNotifyId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����֪ͨId',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'ExamNotifyId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'PersionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�μ���ԱId��������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'PersionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RightCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'RightCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ȷ����',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'RightCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WrongCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'WrongCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'WrongCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Score')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'Score'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�÷�',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'Score'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExamTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'ExamTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'ExamTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TimeSpends')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'TimeSpends'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʱ����λ���֣�',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'TimeSpends'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamRecords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'ExamRecords', 'column', 'IsDelete'
go

alter table ExamRecords
   add constraint PK_EXAMRECORDS primary key (Id)
go

/*==============================================================*/
/* Table: ExamType                                              */
/*==============================================================*/
create table ExamType (
   Id                   int                  identity,
   TypeName             nvarchar(50)         not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExamType') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExamType' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����������', 
   'user', @CurrentUser, 'table', 'ExamType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamType', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExamType', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExamType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExamType', 'column', 'TypeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'ExamType', 'column', 'TypeName'
go

alter table ExamType
   add constraint PK_EXAMTYPE primary key (Id)
go

/*==============================================================*/
/* Table: ExceptionLog                                          */
/*==============================================================*/
create table ExceptionLog (
   Id                   int                  identity,
   Message              nvarchar(500)        not null,
   Source               int                  not null,
   FileName             nvarchar(100)        not null,
   ClassName            varchar(200)         not null,
   MethodName           varchar(200)         not null,
   Instance             varchar(200)         not null,
   StackTrace           nvarchar(max)        not null,
   HappenTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ExceptionLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'ExceptionLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����쳣��־��', 
   'user', @CurrentUser, 'table', 'ExceptionLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Message')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Message'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣��Ϣ',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Message'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Source')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Source'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣��Դ��1 ��̨��2 ��׿app��',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Source'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'FileName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣���������ļ�',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'FileName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ClassName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'ClassName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣������������',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'ClassName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MethodName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'MethodName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣�������ڷ�����',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'MethodName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Instance')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Instance'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����쳣�Ķ���',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'Instance'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StackTrace')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'StackTrace'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�쳣��ջ��Ϣ',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'StackTrace'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HappenTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'HappenTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'HappenTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('ExceptionLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'ExceptionLog', 'column', 'IsDelete'
go

alter table ExceptionLog
   add constraint PK_EXCEPTIONLOG primary key (Id)
go

/*==============================================================*/
/* Table: Feedback                                              */
/*==============================================================*/
create table Feedback (
   Id                   int                  identity,
   Content              nvarchar(max)        not null,
   PersonId             int                  not null,
   AddTime              datetime             not null default getdate()
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Feedback') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Feedback' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���������', 
   'user', @CurrentUser, 'table', 'Feedback'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Feedback')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Feedback')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Content')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'Content'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'Content'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Feedback')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersonId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'PersonId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������Id����������Ա��Ϣ�������',
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'PersonId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Feedback')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'Feedback', 'column', 'AddTime'
go

alter table Feedback
   add constraint PK_FEEDBACK primary key (Id)
go

/*==============================================================*/
/* Table: InstructorAccept                                      */
/*==============================================================*/
create table InstructorAccept (
   Id                   int                  identity,
   InstructorId         int                  not null,
   AcceptDate           date                 not null,
   DriverId             int                  not null,
   ViceDriverId         int                  not null,
   DriverScore          decimal              not null,
   ViceDriverScore      decimal              not null,
   Problems             nvarchar(1000)       not null default '',
   Suggests             nvarchar(1000)       not null default '',
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorAccept') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorAccept' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��׼������', 
   'user', @CurrentUser, 'table', 'InstructorAccept'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AcceptDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'AcceptDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'AcceptDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˾��Id',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'ViceDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'ViceDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverScore')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'DriverScore'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˾���÷�',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'DriverScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverScore')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'ViceDriverScore'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾���÷�',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'ViceDriverScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Problems')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Problems'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ҫ����',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Problems'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Suggests')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Suggests'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ�����',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'Suggests'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAccept')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorAccept', 'column', 'IsDelete'
go

alter table InstructorAccept
   add constraint PK_INSTRUCTORACCEPT primary key (Id)
go

/*==============================================================*/
/* Table: InstructorAnalysis                                    */
/*==============================================================*/
create table InstructorAnalysis (
   Id                   int                  identity,
   InstructorId         int                  not null,
   TrainCode            varchar(10)          not null,
   LocomotiveType       varchar(50)          not null,
   RunDate              date                 not null,
   RunSection           nvarchar(50)         not null,
   DriverId             int                  not null,
   ViceDriverId         int                  not null,
   AnalysisStart        datetime             not null,
   AnalysisEnd          datetime             not null,
   Problems             nvarchar(1000)       not null default '',
   Suggests             nvarchar(1000)       not null default '',
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorAnalysis') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorAnalysis' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��ط�����', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'TrainCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'TrainCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RunDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'RunDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г���������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'RunDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RunSection')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'RunSection'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г���������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'RunSection'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'ViceDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'ViceDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnalysisStart')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'AnalysisStart'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʼʱ��',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'AnalysisStart'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AnalysisEnd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'AnalysisEnd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������ʱ��',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'AnalysisEnd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Problems')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Problems'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Problems'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Suggests')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Suggests'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ�����',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'Suggests'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorAnalysis')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorAnalysis', 'column', 'IsDelete'
go

alter table InstructorAnalysis
   add constraint PK_INSTRUCTORANALYSIS primary key (Id)
go

/*==============================================================*/
/* Table: InstructorCheck                                       */
/*==============================================================*/
create table InstructorCheck (
   Id                   int                  identity,
   InstructorId         int                  not null,
   StartTime            datetime             not null,
   EndTime              datetime             not null,
   Location             nvarchar(50)         not null,
   CheckType            nvarchar(20)         not null,
   ProblemCount         int                  not null,
   CheckContent         nvarchar(1000)       not null default '',
   Problems             nvarchar(1000)       not null,
   Suggests             nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorCheck') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorCheck' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����Ϣ��', 
   'user', @CurrentUser, 'table', 'InstructorCheck'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StartTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'StartTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��鿪ʼʱ��',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'StartTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'EndTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'EndTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ʱ��',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'EndTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Location')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Location'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ص�',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Location'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'CheckType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ͣ��磺���ڣ����ȣ�',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'CheckType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ProblemCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'ProblemCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'ProblemCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CheckContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'CheckContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'CheckContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Problems')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Problems'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'Problems'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorCheck')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorCheck', 'column', 'IsDelete'
go

alter table InstructorCheck
   add constraint PK_INSTRUCTORCHECK primary key (Id)
go

/*==============================================================*/
/* Table: InstructorGoodJob                                     */
/*==============================================================*/
create table InstructorGoodJob (
   Id                   int                  identity,
   InstructorId         int                  not null,
   WriteDate            date                 not null,
   DriverId             int                  not null,
   GoodJobType          nvarchar(10)         not null,
   GeneralSituation     nvarchar(1000)       not null,
   Suggests             nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorGoodJob') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorGoodJob' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��ֹ�¹ʼ����˺��¼�¼', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WriteDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'WriteDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��д����',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'WriteDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GoodJobType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'GoodJobType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʣ���ֹ�¹ʻ��ߺ��˺��£�',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'GoodJobType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GeneralSituation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'GeneralSituation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ſ�',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'GeneralSituation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Suggests')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'Suggests'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'Suggests'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorGoodJob')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorGoodJob', 'column', 'IsDelete'
go

alter table InstructorGoodJob
   add constraint PK_INSTRUCTORGOODJOB primary key (Id)
go

/*==============================================================*/
/* Table: InstructorKeyPerson                                   */
/*==============================================================*/
create table InstructorKeyPerson (
   Id                   Int                  identity,
   InstructorId         int                  not null,
   ConfirmDate          date                 not null,
   KeyPersonId          int                  not null,
   ExpectRemoveTime     date                 not null,
   ActualRemoveTime     date                 not null default '1900-01-01',
   KeyLocation          nvarchar(50)         not null,
   PersonConfirmReason  nvarchar(1000)       not null default '',
   HelpMethod           nvarchar(1000)       not null default '',
   Changes              nvarchar(1000)       not null default '',
   PersonRemoveSuggests nvarchar(1000)       not null default '',
   LocationConfirmReason nvarchar(1000)       not null default '',
   ControlMethod        nvarchar(1000)       not null default '',
   ActualControl        nvarchar(1000)       not null default '',
   LocationRemoveSuggests nvarchar(1000)       not null default '',
   UploadTime           datetime             not null default getdate(),
   IsRemoved            bit                  not null default 0,
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorKeyPerson') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorKeyPerson' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�ؼ��˼�¼', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ConfirmDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ConfirmDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ȷ������',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ConfirmDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'KeyPersonId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'KeyPersonId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���Id',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'KeyPersonId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExpectRemoveTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ExpectRemoveTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Ԥ�ƽ������',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ExpectRemoveTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActualRemoveTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ActualRemoveTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�ʽ������',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ActualRemoveTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'KeyLocation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'KeyLocation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ��㣨�ؼ���λ���ؼ�վ��',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'KeyLocation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersonConfirmReason')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'PersonConfirmReason'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���ȷ��ԭ��',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'PersonConfirmReason'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HelpMethod')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'HelpMethod'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ȴ�ʩ',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'HelpMethod'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Changes')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'Changes'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ת�����',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'Changes'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersonRemoveSuggests')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'PersonRemoveSuggests'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ��˽�����',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'PersonRemoveSuggests'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocationConfirmReason')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'LocationConfirmReason'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���ȷ��ԭ��',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'LocationConfirmReason'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ControlMethod')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ControlMethod'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ش�ʩ',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ControlMethod'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ActualControl')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ActualControl'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʵ���',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'ActualControl'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsRemoved')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'IsRemoved'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��ѽ��',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'IsRemoved'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorKeyPerson')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorKeyPerson', 'column', 'IsDelete'
go

alter table InstructorKeyPerson
   add constraint PK_INSTRUCTORKEYPERSON primary key (Id)
go

/*==============================================================*/
/* Table: InstructorLocoQuality                                 */
/*==============================================================*/
create table InstructorLocoQuality (
   Id                   int                  identity,
   InstructorId         int                  not null,
   RegistDate           date                 not null,
   TrainCode            varchar(10)          not null,
   LocomotiveType       varchar(50)          not null,
   DriverId             int                  not null,
   RepairClass          varchar(50)          not null,
   MaintenanceStatus    nvarchar(20)         not null,
   Score                decimal              not null,
   FaultLocation        nvarchar(50)         not null,
   GeneralSituation     nvarchar(1000)       not null default '',
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorLocoQuality') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorLocoQuality' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '���������Ǽ�', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RegistDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'RegistDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ǽ�����',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'RegistDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'TrainCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'TrainCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocomotiveType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'LocomotiveType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ͺ�',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'LocomotiveType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RepairClass')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'RepairClass'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�޳�',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'RepairClass'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'MaintenanceStatus')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'MaintenanceStatus'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����״̬',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'MaintenanceStatus'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Score')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'Score'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ɼ�',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'Score'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FaultLocation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'FaultLocation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Լ����ϴ���',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'FaultLocation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GeneralSituation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'GeneralSituation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ſ�',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'GeneralSituation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorLocoQuality')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorLocoQuality', 'column', 'IsDelete'
go

alter table InstructorLocoQuality
   add constraint PK_INSTRUCTORLOCOQUALITY primary key (Id)
go

/*==============================================================*/
/* Table: InstructorPeccancy                                    */
/*==============================================================*/
create table InstructorPeccancy (
   Id                   int                  identity,
   InstructorId         int                  not null,
   WriteDate            date                 not null,
   DriverId             int                  not null,
   PeccancyType         nvarchar(20)         not null,
   GeneralSituation     nvarchar(1000)       not null,
   Analysis             nvarchar(1000)       not null,
   Suggests             nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorPeccancy') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorPeccancy' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Υ��Υ�ͼ�¼', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WriteDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'WriteDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼����',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'WriteDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Υ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PeccancyType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'PeccancyType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Υ������',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'PeccancyType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'GeneralSituation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'GeneralSituation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ſ�',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'GeneralSituation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Analysis')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Analysis'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Analysis'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Suggests')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Suggests'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'Suggests'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPeccancy')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorPeccancy', 'column', 'UploadTime'
go

alter table InstructorPeccancy
   add constraint PK_INSTRUCTORPECCANCY primary key (Id)
go

/*==============================================================*/
/* Table: InstructorPlan                                        */
/*==============================================================*/
create table InstructorPlan (
   Id                   int                  identity,
   InstructorId         int                  not null,
   WriteDate            date                 not null,
   WorkSummary          nvarchar(1000)       not null,
   Problems             nvarchar(1000)       not null,
   WorkPlans            nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorPlan') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorPlan' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����ܽἰ�ƻ�', 
   'user', @CurrentUser, 'table', 'InstructorPlan'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WriteDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WriteDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��д����',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WriteDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WorkSummary')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WorkSummary'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���¹���������',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WorkSummary'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Problems')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'Problems'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'Problems'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WorkPlans')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WorkPlans'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���¹����ƻ�',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'WorkPlans'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorPlan')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorPlan', 'column', 'IsDelete'
go

alter table InstructorPlan
   add constraint PK_INSTRUCTORPLAN primary key (Id)
go

/*==============================================================*/
/* Table: InstructorQuota                                       */
/*==============================================================*/
create table InstructorQuota (
   Id                   int                  identity,
   QuotaName            nvarchar(50)         not null,
   QuataAmmount         decimal              not null,
   NeedReview           bit                  not null,
   ReviewDesc           nvarchar(500)        not null default '',
   BaseScore            decimal              not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorQuota') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorQuota' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'ָ��˾��ָ��������', 
   'user', @CurrentUser, 'table', 'InstructorQuota'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuotaName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'QuotaName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ������',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'QuotaName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuataAmmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'QuataAmmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��������',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'QuataAmmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NeedReview')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'NeedReview'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ��������',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'NeedReview'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ReviewDesc')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'ReviewDesc'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'ReviewDesc'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BaseScore')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'BaseScore'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������ֵ',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'BaseScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuota')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorQuota', 'column', 'IsDelete'
go

alter table InstructorQuota
   add constraint PK_INSTRUCTORQUOTA primary key (Id)
go

/*==============================================================*/
/* Table: InstructorQuotaRecord                                 */
/*==============================================================*/
create table InstructorQuotaRecord (
   Id                   Int                  identity,
   InstructorId         int                  not null,
   QuotaId              int                  not null,
   FinishedAmmount      decimal              not null,
   Year                 int                  not null,
   Month                int                  not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorQuotaRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'ָ��˾��ָ��������', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'QuotaId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'QuotaId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��Id',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'QuotaId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FinishedAmmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'FinishedAmmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'FinishedAmmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Year')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Year'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Year'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Month')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Month'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�·�',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'Month'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorQuotaRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorQuotaRecord', 'column', 'IsDelete'
go

alter table InstructorQuotaRecord
   add constraint PK_INSTRUCTORQUOTARECORD primary key (Id)
go

/*==============================================================*/
/* Table: InstructorRepair                                      */
/*==============================================================*/
create table InstructorRepair (
   Id                   int                  identity,
   InstructorId         int                  not null,
   HappenTime           datetime             not null,
   Location             nvarchar(50)         not null,
   TrainCode            varchar(10)          not null,
   LocomotiveType       varchar(50)          not null,
   DriverId             int                  not null,
   ViceDriverId         int                  not null,
   StudentId            int                  not null,
   FaultLocation        nvarchar(50)         not null,
   FaultReason          nvarchar(1000)       not null,
   Responsibility       nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorRepair') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorRepair' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�������޼�¼', 
   'user', @CurrentUser, 'table', 'InstructorRepair'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'HappenTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'HappenTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Ʒ���ʱ��',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'HappenTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Location')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Location'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ص�',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Location'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'TrainCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'TrainCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocomotiveType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'LocomotiveType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ͺ�',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'LocomotiveType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'ViceDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id����������Ա��Ϣ������
   ',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'ViceDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'StudentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ѧϰ˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'StudentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FaultLocation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'FaultLocation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ϴ���',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'FaultLocation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FaultReason')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'FaultReason'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ԭ��',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'FaultReason'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Responsibility')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Responsibility'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'Responsibility'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRepair')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorRepair', 'column', 'IsDelete'
go

alter table InstructorRepair
   add constraint PK_INSTRUCTORREPAIR primary key (Id)
go

/*==============================================================*/
/* Table: InstructorReviewScore                                 */
/*==============================================================*/
create table InstructorReviewScore (
   Id                   int                  identity,
   InstructorId         int                  not null,
   Year                 int                  not null,
   Month                int                  not null,
   Score                decimal              not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorReviewScore') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorReviewScore' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'ָ��˾���¶���˵÷�', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Year')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Year'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Year'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Month')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Month'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�·�',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Month'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Score')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Score'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�÷�',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'Score'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewScore')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorReviewScore', 'column', 'IsDelete'
go

alter table InstructorReviewScore
   add constraint PK_INSTRUCTORREVIEWSCORE primary key (Id)
go

/*==============================================================*/
/* Table: InstructorReviewStandard                              */
/*==============================================================*/
create table InstructorReviewStandard (
   Id                   int                  identity,
   InstructorQuotaId    int                  not null,
   ConditionAmmount     decimal              not null,
   ExtraScore           decimal              not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorReviewStandard') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorReviewStandard' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'ָ��˾�����ֱ�׼', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewStandard')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewStandard')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ConditionAmmount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'ConditionAmmount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ֵ',
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'ConditionAmmount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewStandard')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ExtraScore')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'ExtraScore'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ӽ���ֵ���ڻ�����ֵ�Ļ����ϼӜp��',
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'ExtraScore'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewStandard')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorReviewStandard')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorReviewStandard', 'column', 'IsDelete'
go

alter table InstructorReviewStandard
   add constraint PK_INSTRUCTORREVIEWSTANDARD primary key (Id)
go

/*==============================================================*/
/* Table: InstructorRouterPosition                              */
/*==============================================================*/
create table InstructorRouterPosition (
   Id                   int                  identity,
   BssId                varchar(500)         not null,
   Location             nvarchar(100)        not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorRouterPosition') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorRouterPosition' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '·�����ص���ձ�', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRouterPosition')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRouterPosition')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BssId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'BssId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Mac��ַ������Զ��Ÿ���',
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'BssId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRouterPosition')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Location')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'Location'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ʵ�ʵ�ַ',
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'Location'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRouterPosition')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorRouterPosition')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorRouterPosition', 'column', 'IsDelete'
go

alter table InstructorRouterPosition
   add constraint PK_INSTRUCTORROUTERPOSITION primary key (Id)
go

/*==============================================================*/
/* Table: InstructorTeach                                       */
/*==============================================================*/
create table InstructorTeach (
   Id                   int                  identity,
   InstructorId         int                  not null,
   TeachPlace           nvarchar(20)         not null,
   JoinCount            int                  not null,
   TeachStart           datetime             not null,
   TeachEnd             datetime             not null,
   TeachContent         nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorTeach') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorTeach' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�ڿ���ѵ��¼', 
   'user', @CurrentUser, 'table', 'InstructorTeach'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeachPlace')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachPlace'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڿεص�',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachPlace'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'JoinCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'JoinCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'JoinCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeachStart')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachStart'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڿο�ʼʱ��',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachStart'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeachEnd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachEnd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڿν���ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachEnd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TeachContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ڿ�����',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'TeachContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTeach')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorTeach', 'column', 'IsDelete'
go

alter table InstructorTeach
   add constraint PK_INSTRUCTORTEACH primary key (Id)
go

/*==============================================================*/
/* Table: InstructorTempTake                                    */
/*==============================================================*/
create table InstructorTempTake (
   Id                   int                  identity,
   InstructorId         int                  not null,
   TakeDate             date                 not null,
   TrainCode            varchar(10)          not null,
   LocomotiveType       varhcar(50)          not null,
   DriverId             int                  not null,
   ViceDriverId         int                  not null,
   StudentId            int                  not null,
   CarCount             int                  not null,
   WholeWeight          decimal              not null,
   Length               decimal              not null,
   TakeSection          nvarchar(20)         not null,
   RunStart             datetime             not null,
   RunEnd               datetime             not null,
   OperateSection       nvarchar(20)         not null,
   OperateStart         datetime             not null,
   OperateEnd           datetime             not null,
   AttendTime           datetime             not null,
   EndAttendTime        datetime             not null,
   TakeAims             nvarchar(1000)       not null,
   Problems             nvarchar(1000)       not null,
   Suggests             nvarchar(1000)       not null,
   UploadTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorTempTake') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorTempTake' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����Ϣ��', 
   'user', @CurrentUser, 'table', 'InstructorTempTake'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TakeDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainCode')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TrainCode'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˳���',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TrainCode'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LocomotiveType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'LocomotiveType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ͺ�',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'LocomotiveType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˾��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ViceDriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'ViceDriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'ViceDriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StudentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'StudentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ѧϰ˾��Id',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'StudentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CarCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'CarCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'CarCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WholeWeight')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'WholeWeight'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'WholeWeight'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Length')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Length'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Length'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TakeSection')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeSection'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeSection'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RunStart')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'RunStart'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'RunStart'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RunEnd')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'RunEnd'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'RunEnd'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperateSection')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'OperateSection'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'OperateSection'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperateStart')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'OperateStart'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ݿ�ʼʱ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'OperateStart'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AttendTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'AttendTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'AttendTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TakeAims')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeAims'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���Ŀ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'TakeAims'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Problems')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Problems'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'Problems'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UploadTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'UploadTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ϴ�ʱ��',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'UploadTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorTempTake')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorTempTake', 'column', 'IsDelete'
go

alter table InstructorTempTake
   add constraint PK_INSTRUCTORTEMPTAKE primary key (Id)
go

/*==============================================================*/
/* Table: InstructorWifiRecord                                  */
/*==============================================================*/
create table InstructorWifiRecord (
   Id                   int                  identity,
   InstructorId         int                  not null,
   RouterPositionId     int                  not null,
   ConnectFlag          int                  not null,
   ConnectTime          datetime             not null,
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('InstructorWifiRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'InstructorWifiRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Wifi���Ӽ�¼', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'InstructorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'InstructorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��Id',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'InstructorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RouterPositionId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'RouterPositionId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '·�����ص���ձ�Id������ȷ������λ��',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'RouterPositionId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ConnectFlag')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'ConnectFlag'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ӶϿ���ʶ��1 ���ӣ� 2 �Ͽ���',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'ConnectFlag'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ConnectTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'ConnectTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'ConnectTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('InstructorWifiRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'InstructorWifiRecord', 'column', 'IsDelete'
go

alter table InstructorWifiRecord
   add constraint PK_INSTRUCTORWIFIRECORD primary key (Id)
go

/*==============================================================*/
/* Table: LineAnnounceCommands                                  */
/*==============================================================*/
create table LineAnnounceCommands (
   Id                   int                  identity,
   TrainNoId            int                  not null,
   LineId               int                  not null,
   DriverId             int                  not null,
   CommandId            bigint               not null,
   IsPassed             bit                  not null default 0,
   PassedTime           datetime             not null default '1900-01-01'
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('LineAnnounceCommands') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'LineAnnounceCommands' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�������н�ʾ��������·��ϵ', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainNoId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'TrainNoId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id������������Ϣ�������',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'TrainNoId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'LineId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·id��������·��Ϣ�������',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'LineId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriverId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'DriverId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����˾��Id����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'DriverId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CommandId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'CommandId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʾId��������ʾ���������',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'CommandId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsPassed')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'IsPassed'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ƿ�ͨ��',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'IsPassed'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineAnnounceCommands')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PassedTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'PassedTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ͨ��ʱ��',
   'user', @CurrentUser, 'table', 'LineAnnounceCommands', 'column', 'PassedTime'
go

alter table LineAnnounceCommands
   add constraint PK_LINEANNOUNCECOMMANDS primary key (Id)
go

/*==============================================================*/
/* Table: LineStations                                          */
/*==============================================================*/
create table LineStations (
   Id                   int                  identity,
   LineId               int                  not null,
   StationName          nvarchar(50)         not null,
   StationId            int                  not null,
   Sort                 int                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('LineStations') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'LineStations' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��·��վ��Ӧ��', 
   'user', @CurrentUser, 'table', 'LineStations'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineStations')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LineId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'LineId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��·Id',
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'LineId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineStations')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StationName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'StationName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վ����',
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'StationName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineStations')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'StationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վId',
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'StationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('LineStations')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ţ���ʾ��վ�ڴ���·�ϵ�˳��',
   'user', @CurrentUser, 'table', 'LineStations', 'column', 'Sort'
go

alter table LineStations
   add constraint PK_LINESTATIONS primary key (Id)
go

/*==============================================================*/
/* Table: OperateLog                                            */
/*==============================================================*/
create table OperateLog (
   Id                   int                  identity,
   LogContent           nvarchar(500)        not null,
   SystemUserId         int                  not null,
   OperateTime          datetime             not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('OperateLog') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'OperateLog' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��̨������־��', 
   'user', @CurrentUser, 'table', 'OperateLog'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LogContent')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'LogContent'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'LogContent'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SystemUserId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'SystemUserId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ԱId������������Ա�˻�������',
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'SystemUserId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OperateLog')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OperateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'OperateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'OperateLog', 'column', 'OperateTime'
go

alter table OperateLog
   add constraint PK_OPERATELOG primary key (Id)
go

/*==============================================================*/
/* Table: OracleTableMaxId                                      */
/*==============================================================*/
create table OracleTableMaxId (
   Id                   int                  identity,
   TableName            nvarchar(50)         not null,
   MaxId                varchar(50)          not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('OracleTableMaxId') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'OracleTableMaxId' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Oracle���ݿ������Id��¼', 
   'user', @CurrentUser, 'table', 'OracleTableMaxId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OracleTableMaxId')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OracleTableMaxId')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TableName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'TableName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'TableName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OracleTableMaxId')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('OracleTableMaxId')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'OracleTableMaxId', 'column', 'IsDelete'
go

alter table OracleTableMaxId
   add constraint PK_ORACLETABLEMAXID primary key (Id)
go

/*==============================================================*/
/* Table: PersonInfo                                            */
/*==============================================================*/
create table PersonInfo (
   Id                   bigint               identity,
   PersonId             varchar(20)          not null default '0',
   WorkNo               varchar(20)          not null,
   DepartmentId         int                  not null,
   Name                 nvarchar(20)         not null,
   Spell                varchar(20)          not null default '',
   BirthDate            datetime             not null,
   Sex                  int                  not null default 1,
   PostId               int                  not null,
   PhotoPath            varchar(200)         not null default '',
   IdentityNo           varchar(18)          not null default '',
   Password             varchar(32)          not null default '',
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PersonInfo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PersonInfo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����������Ա��Ϣ', 
   'user', @CurrentUser, 'table', 'PersonInfo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersonId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PersonId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ԱID�������˰����ݿ���Ա��Id���п��ܻ�ȡ������Id�����ʱ���ֶ�ֵΪ0��',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PersonId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'WorkNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'WorkNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ţ������������¿��ô��ֶ���Ϊ��Ա��Ψһ��ʶ',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'WorkNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartmentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'DepartmentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id������������Ϣ������',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'DepartmentId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Spell')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Spell'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ƴ����д',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Spell'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'BirthDate')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'BirthDate'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'BirthDate'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sex')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Sex'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Ա�1 ��ʾ�У�2 ��ʾŮ��3 ��ʾδ֪��',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Sex'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PostId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λId��������λ��Ϣ������',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PostId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PhotoPath')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PhotoPath'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ƭ·��',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'PhotoPath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IdentityNo')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'IdentityNo'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���֤��',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'IdentityNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Password')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Password'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ϵͳͳһ����',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'Password'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PersonInfo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'PersonInfo', 'column', 'UpdateTime'
go

alter table PersonInfo
   add constraint PK_PERSONINFO primary key (Id)
go

/*==============================================================*/
/* Table: Posts                                                 */
/*==============================================================*/
create table Posts (
   Id                   int                  identity,
   PostName             nvarchar(20)         not null,
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('Posts') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'Posts' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '������λ��Ϣ', 
   'user', @CurrentUser, 'table', 'Posts'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Posts')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Posts', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'Posts', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('Posts')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PostName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'Posts', 'column', 'PostName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��λ����',
   'user', @CurrentUser, 'table', 'Posts', 'column', 'PostName'
go

alter table Posts
   add constraint PK_POSTS primary key (Id)
go

/*==============================================================*/
/* Table: PrimaryIdRelation                                     */
/*==============================================================*/
create table PrimaryIdRelation (
   Id                   int                  identity,
   SqlTableName         varchar(50)          not null,
   SqlPrimaryId         varchar(50)          not null,
   OracleTableName      varchar(50)          not null,
   OraclePrimaryId      varchar(50)          not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('PrimaryIdRelation') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'PrimaryIdRelation' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   'Sqlserver��Oracle���������Ӧ��ϵ��', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SqlTableName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'SqlTableName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Sqlserver����',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'SqlTableName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SqlPrimaryId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'SqlPrimaryId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Sqlserver����',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'SqlPrimaryId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OracleTableName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'OracleTableName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Oracle����',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'OracleTableName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'OraclePrimaryId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'OraclePrimaryId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'Oracle����',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'OraclePrimaryId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('PrimaryIdRelation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'PrimaryIdRelation', 'column', 'IsDelete'
go

alter table PrimaryIdRelation
   add constraint PK_PRIMARYIDRELATION primary key (Id)
go

/*==============================================================*/
/* Table: StationFiles                                          */
/*==============================================================*/
create table StationFiles (
   Id                   int                  identity,
   StationId            int                  not null,
   FileType             int                  not null,
   FileSize             bigint               not null,
   FileName             nvarchar(200)        not null,
   FilePath             varchar(100)         not null,
   AddTime              datetime             not null,
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('StationFiles') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'StationFiles' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�복վ��ص��ļ�����վ����ϸ��������ʾ����վ��ʾ��ͼ�ȣ�', 
   'user', @CurrentUser, 'table', 'StationFiles'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'StationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վId��������վ��Ϣ������',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'StationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ����ͣ�1 ��ʾվ����ϸ�� 2 ��ʾ������ʾ���� 3 ��ʾվ��ʾ��ͼ����',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileSize')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileSize'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ���С',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileSize'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�����',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FileName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('StationFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FilePath')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FilePath'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ��ڷ������洢�ĵ�ַ',
   'user', @CurrentUser, 'table', 'StationFiles', 'column', 'FilePath'
go

alter table StationFiles
   add constraint PK_STATIONFILES primary key (Id)
go

/*==============================================================*/
/* Table: SystemUser                                            */
/*==============================================================*/
create table SystemUser (
   Id                   int                  identity,
   Account              varchar(20)          not null,
   Password             varchar(32)          not null,
   Name                 nvarchar(20)         not null,
   CreateTime           datetime             not null,
   CreatorId            int                  not null,
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('SystemUser') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'SystemUser' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��̨������Ա�˻���', 
   'user', @CurrentUser, 'table', 'SystemUser'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Account')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Account'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�˺�',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Account'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Password')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Password'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Password'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Name')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Name'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'Name'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'CreateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'CreateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CreatorId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'CreatorId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'CreatorId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('SystemUser')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'SystemUser', 'column', 'IsDelete'
go

alter table SystemUser
   add constraint PK_SYSTEMUSER primary key (Id)
go

/*==============================================================*/
/* Table: TraficFileType                                        */
/*==============================================================*/
create table TraficFileType (
   Id                   int                  identity,
   TypeName             nvarchar(100)        not null,
   ParentId             int                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficFileType') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficFileType' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г����Ϸ����', 
   'user', @CurrentUser, 'table', 'TraficFileType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFileType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFileType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'TypeName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'TypeName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFileType')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ParentId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'ParentId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ุ��Id������������������Ϊ0���ʾһ������',
   'user', @CurrentUser, 'table', 'TraficFileType', 'column', 'ParentId'
go

alter table TraficFileType
   add constraint PK_TRAFICFILETYPE primary key (Id)
go

/*==============================================================*/
/* Table: TraficFiles                                           */
/*==============================================================*/
create table TraficFiles (
   Id                   int                  identity,
   TypeId               int                  not null,
   FileName             nvarchar(100)        not null,
   FileExtension        varchar(20)          not null,
   FileSize             bigint               not null,
   FilePath             nvarchar(200)        not null,
   AddTime              datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficFiles') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficFiles' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г������ļ������', 
   'user', @CurrentUser, 'table', 'TraficFiles'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TypeId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'TypeId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�����Id�������г����Ϸ���������',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'TypeId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ�����',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileExtension')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileExtension'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ����ͣ���չ����',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileExtension'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileSize')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileSize'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ���С����λ��KB��',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FileSize'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FilePath')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FilePath'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ļ���ַ���ļ��ڷ�������ŵ����·��',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'FilePath'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'AddTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficFiles')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'TraficFiles', 'column', 'IsDelete'
go

alter table TraficFiles
   add constraint PK_TRAFICFILES primary key (Id)
go

/*==============================================================*/
/* Table: TraficKeywords                                        */
/*==============================================================*/
create table TraficKeywords (
   Id                   int                  identity,
   Keywords             nvarchar(50)         not null,
   SearchCount          int                  not null default 0,
   AddTime              datetime             not null default getdate()
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficKeywords') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficKeywords' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�����ؼ��ֱ�', 
   'user', @CurrentUser, 'table', 'TraficKeywords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficKeywords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficKeywords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Keywords')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'Keywords'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���',
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'Keywords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficKeywords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SearchCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'SearchCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��������',
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'SearchCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficKeywords')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'AddTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'AddTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���ʱ��',
   'user', @CurrentUser, 'table', 'TraficKeywords', 'column', 'AddTime'
go

alter table TraficKeywords
   add constraint PK_TRAFICKEYWORDS primary key (Id)
go

/*==============================================================*/
/* Table: TraficSearchRecord                                    */
/*==============================================================*/
create table TraficSearchRecord (
   Id                   bigint               identity,
   PersonId             int                  not null,
   Keywords             nvarchar(100)        not null,
   SearchCount          int                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficSearchRecord') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficSearchRecord' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����Ա�����ؼ��ּ�¼��', 
   'user', @CurrentUser, 'table', 'TraficSearchRecord'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'PersonId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'PersonId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ԱId����������Ա��Ϣ������',
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'PersonId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Keywords')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'Keywords'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����Ĺؼ���',
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'Keywords'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchRecord')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SearchCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'SearchCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�Դ˹ؼ��ֵ���������',
   'user', @CurrentUser, 'table', 'TraficSearchRecord', 'column', 'SearchCount'
go

alter table TraficSearchRecord
   add constraint PK_TRAFICSEARCHRECORD primary key (Id)
go

/*==============================================================*/
/* Table: TraficSearchResult                                    */
/*==============================================================*/
create table TraficSearchResult (
   Id                   int                  identity,
   KeywordsId           int                  not null,
   SearchResult         nvarchar(max)        not null,
   TraficFileId         int                  not null,
   Position             nvarchar(100)        not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficSearchResult') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficSearchResult' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�ؼ������������', 
   'user', @CurrentUser, 'table', 'TraficSearchResult'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'KeywordsId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'KeywordsId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�ؼ���Id',
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'KeywordsId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SearchResult')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'SearchResult'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������Id',
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'SearchResult'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TraficFileId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'TraficFileId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ�Id',
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'TraficFileId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchResult')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Position')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'Position'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����������λ�ã��磺�ؼ�������domԪ�ص�Id��',
   'user', @CurrentUser, 'table', 'TraficSearchResult', 'column', 'Position'
go

alter table TraficSearchResult
   add constraint PK_TRAFICSEARCHRESULT primary key (Id)
go

/*==============================================================*/
/* Table: TraficSearchText                                      */
/*==============================================================*/
create table TraficSearchText (
   Id                   int                  identity,
   FileId               int                  not null,
   Chapter              nvarchar(100)        not null,
   Item                 nvarchar(100)        not null,
   Content              text                 not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TraficSearchText') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TraficSearchText' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��������ı�����', 
   'user', @CurrentUser, 'table', 'TraficSearchText'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FileId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'FileId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�����ļ�Id',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'FileId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Chapter')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Chapter'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�½ڣ��������',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Chapter'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Item')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Item'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��Ŀ�����229��',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'Item'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TraficSearchText')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'TraficSearchText', 'column', 'IsDelete'
go

/*==============================================================*/
/* Table: TrainFormation                                        */
/*==============================================================*/
create table TrainFormation (
   Id                   int                  identity,
   DriveRecordId        int                  not null,
   StationId            int                  not null,
   CarriageCount        int                  not null,
   CarryingCapacity     decimal              not null,
   Length               decimal              not null,
   NoteTime             datetime             not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TrainFormation') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TrainFormation' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����-�г������¼', 
   'user', @CurrentUser, 'table', 'TrainFormation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Id')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'Id'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'Id'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DriveRecordId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'DriveRecordId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����Id���������˼�¼�������',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'DriveRecordId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'StationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վId��������վ��Ϣ�������',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'StationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CarriageCount')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'CarriageCount'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г�����-����',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'CarriageCount'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'CarryingCapacity')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'CarryingCapacity'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г�����-���������أ�',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'CarryingCapacity'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Length')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'Length'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г�����-�Ƴ�',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'Length'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainFormation')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'NoteTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'NoteTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��¼ʱ��',
   'user', @CurrentUser, 'table', 'TrainFormation', 'column', 'NoteTime'
go

alter table TrainFormation
   add constraint PK_TRAINFORMATION primary key (Id)
go

/*==============================================================*/
/* Table: TrainMoment                                           */
/*==============================================================*/
create table TrainMoment (
   Id                   int                  identity,
   TrainNoLineId        int                  not null,
   TrainStationId       int                  not null,
   ArriveTime           varchar(10)          not null default '',
   DepartTime           varchar(10)          not null default '',
   StopMinutes          int                  not null,
   IntervalKms          decimal              not null default 0.0,
   SuggestSpeed         decimal              not null default 0.0,
   Sort                 int                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TrainMoment') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TrainMoment' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '�г�ʱ�̱�', 
   'user', @CurrentUser, 'table', 'TrainMoment'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainNoLineId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'TrainNoLineId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '������·������id������������·�����������',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'TrainNoLineId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'TrainStationId')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'TrainStationId'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��վid��������վ��Ϣ�������',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'TrainStationId'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'ArriveTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'ArriveTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г����ﱾվ��ʱ��㣬��15��32',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'ArriveTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'DepartTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'DepartTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г��ӱ�վ������ʱ��㣬��16��48',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'DepartTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'StopMinutes')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'StopMinutes'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г��ڱ�վͣ����ʱ�䣬�Է�Ϊ��λ��ʾ',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'StopMinutes'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IntervalKms')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'IntervalKms'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���乫������ָ���Ǵ���һ��վ����վ��һ�ξ���',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'IntervalKms'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'SuggestSpeed')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'SuggestSpeed'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���鳵��',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'SuggestSpeed'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainMoment')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ţ��������ξ�����վ��˳������ԽСԽ��ǰ',
   'user', @CurrentUser, 'table', 'TrainMoment', 'column', 'Sort'
go

alter table TrainMoment
   add constraint PK_TRAINMOMENT primary key (Id)
go

/*==============================================================*/
/* Table: TrainNo                                               */
/*==============================================================*/
create table TrainNo (
   Id                   int                  identity,
   FullName             nvarchar(20)         not null,
   Code                 nvarchar(10)         not null default '',
   Number               varchar(10)          not null,
   Direction            nvarchar(5)          not null,
   RunType              int                  not null,
   FirstStation         nvarchar(50)         not null,
   LastStation          nvarchar(50)         not null,
   UpdateTime           datetime             not null,
   IsDelete             bit                  not null
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TrainNo') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TrainNo' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '����������Ϣ', 
   'user', @CurrentUser, 'table', 'TrainNo'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FullName')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'FullName'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ȫ�ƣ���Z170',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'FullName'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Code')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Code'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���δ�ͷ����ĸ����Z170�ı���ΪZ',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Code'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Number')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Number'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '���γ�ȥ��ͷ��ĸ��ʣ�µ�����',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Number'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Direction')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Direction'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�г����з��򣬴˷���������ڱ�����˵�����������еķ����Ϊ�����С���Զ�뱱�������з����Ϊ�����С�',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'Direction'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'RunType')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'RunType'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�������ͣ�1 �ͳ��� 2 ������ 3 ������ 4 ������',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'RunType'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'FirstStation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'FirstStation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ʼվ',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'FirstStation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'LastStation')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'LastStation'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '�յ�վ',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'LastStation'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNo')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'TrainNo', 'column', 'IsDelete'
go

alter table TrainNo
   add constraint PK_TRAINNO primary key (Id)
go

/*==============================================================*/
/* Table: TrainNoLine                                           */
/*==============================================================*/
create table TrainNoLine (
   Id                   int                  identity,
   TrainNoId            int                  not null,
   LineId               int                  not null,
   Sort                 int                  not null,
   UpdateTime           datetime             not null default getdate(),
   IsDelete             bit                  not null default 0
)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('TrainNoLine') and minor_id = 0)
begin 
   declare @CurrentUser sysname 
select @CurrentUser = user_name() 
execute sp_dropextendedproperty 'MS_Description',  
   'user', @CurrentUser, 'table', 'TrainNoLine' 
 
end 


select @CurrentUser = user_name() 
execute sp_addextendedproperty 'MS_Description',  
   '��������·��������������·Ϊһ�Զ�Ĺ�ϵ', 
   'user', @CurrentUser, 'table', 'TrainNoLine'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNoLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'Sort')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'Sort'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '��ţ��������˳��ξ�����·��˳��',
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'Sort'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNoLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'UpdateTime')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'UpdateTime'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   '����ʱ��',
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'UpdateTime'
go

if exists(select 1 from sys.extended_properties p where
      p.major_id = object_id('TrainNoLine')
  and p.minor_id = (select c.column_id from sys.columns c where c.object_id = p.major_id and c.name = 'IsDelete')
)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'IsDelete'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ɾ����ʶ',
   'user', @CurrentUser, 'table', 'TrainNoLine', 'column', 'IsDelete'
go

alter table TrainNoLine
   add constraint PK_TRAINNOLINE primary key (Id)
go

/*==============================================================*/
/* View: ViewAnnounceCommands                                   */
/*==============================================================*/
create view ViewAnnounceCommands as
SELECT
AC.Id,AC.CommandNo,AC.CommandInterval,AC.SpeedLimitLocation,AC.StartEndTime,AC.LoseEffectTime,AC.LimitedSpeed,AC.AddTime,AC.IsActive,
TN.FullName,TN.Code,TN.Number,TN.Direction,TN.RunType,TN.FirstStation,TN.LastStation,TN.UpdateTime,
LAC.TrainNoId
FROM TrainNo TN
LEFT JOIN LineAnnounceCommands LAC ON TN.Id=LAC.TrainNoId
LEFT JOIN AnnounceCommands AC ON LAC.CommandId=AC.Id
WHERE AC.IsActive=1
go

/*==============================================================*/
/* View: ViewBaseLine                                           */
/*==============================================================*/
create view ViewBaseLine as
SELECT
BL.Id,BL.LineName,BL.FirstStationId,BL.FirstStation,BL.LastStationId,BL.LastStation,BL.LineLength,BL.Spell,BL.UpdateTime,
LS.StationId,LS.StationName,LS.Sort
FROM BaseLine BL 
LEFT JOIN LineStations LS ON BL.Id=LS.LineId
go

/*==============================================================*/
/* View: ViewDriveRecord                                        */
/*==============================================================*/
create view ViewDriveRecord as
SELECT
DR.Id, DR.DriverId1, DR.DriverId2, DR.ViceDriverId, DR.StudentDriverId, DR.OtherDriverId, DR.LocomotiveType, DR.AttendTime, DR.GetTrainTime, DR.LeaveDepotTime1, DR.LeaveDepotTime2, DR.AttendForecast, DR.ArriveDepotTime1, DR.ArriveDepotTime2, DR.GiveTrainTime, DR.RecordEndTime, DR.OperateConsume, DR.StopConsume, DR.RecieveEnergy, DR.LeftEnergy, DR.EngineOil, DR.AirCompressorOil, DR.TurbineOil, DR.GearOil, DR.GovernorOil, DR.OtherOil, DR.Staple, DR.MultiLocoDepot, DR.MultiLocoType, DR.MultiLocoSection, DR.EndSummary, DR.AddTime, DR.IsDelete,
VP1.WorkNo AS DriverWorkNo,VP1.Name AS DriverName,
VP2.WorkNo AS ViceDriverWorkNo, VP2.Name AS ViceDriverName,
VP3.WorkNo AS StuDriverWorkNo, VP3.Name AS StuDriverName,
VP4.WorkNo AS OtherDriverWorkNo, VP4.Name AS OtherDriverName,
DT.Id AS DriveTrainNoAndLineId, DT.TrainNoId, DT.LineId,
TN.Code,TN.Direction,TN.FirstStation,TN.FullName,TN.LastStation,TN.Number,TN.RunType,
BL.LineName
FROM DriveRecords DR
LEFT JOIN ViewPersonInfo VP1 ON DR.DriverId1=VP1.Id
LEFT JOIN ViewPersonInfo VP2 ON DR.DriverId2=VP2.Id
LEFT JOIN ViewPersonInfo VP3 ON DR.StudentDriverId=VP3.Id
LEFT JOIN ViewPersonInfo VP4 ON DR.OtherDriverId=VP4.Id
LEFT JOIN DriveTrainNoAndLine DT ON DR.Id=DT.DriveRecordId
LEFT JOIN TrainNo TN ON DT.TrainNoId=TN.Id
LEFT JOIN BaseLine BL ON DT.LineId=BL.Id
go

/*==============================================================*/
/* View: ViewExamFiles                                          */
/*==============================================================*/
create view ViewExamFiles as
SELECT
F.Id,F.ExamTypeId,F.[FileName],F.FileDesc,F.FilePath,F.AddTime,F.IsDelete,
T.TypeName,
(SELECT COUNT(1) FROM ExamQuestion WHERE ExamFileId=F.Id) AS QuestionCount
FROM ExamFiles F
LEFT JOIN ExamType T
ON F.ExamTypeId=T.Id
go

/*==============================================================*/
/* View: ViewExamNotify                                         */
/*==============================================================*/
create view ViewExamNotify as

-- ����֪ͨ��ͼ
-- @author FrancisTan
-- @since 2016-08-16
SELECT
N.Id,N.PostId,P.PostName,N.ExamName,N.ExamFilesId,F.FileName,N.QuestionCount,N.PassScore,N.ResitCount,N.EndTime,N.TimeLimit,N.AddTime
FROM ExamNotify N
LEFT JOIN Posts P ON N.PostId=P.Id
LEFT JOIN ExamFiles F ON N.ExamFilesId=F.Id
WHERE N.IsDelete=0
go

/*==============================================================*/
/* View: ViewExamRecords                                        */
/*==============================================================*/
create view ViewExamRecords as
SELECT
ExamNotifyId,ExamName,PersionId,Name,DepartmentId,DepartmentName,PostId,PostName,PassScore,MaxScore,AddTime AS NotifyAddTime,
(CASE WHEN MaxScore>=PassScore THEN 'ͨ��' WHEN MaxScore<PassScore THEN 'δͨ��' END) AS Passed
FROM 
(SELECT
R.ExamNotifyId,N.ExamName,R.PersionId,P.Name,P.DepartmentId,P.DepartmentName,P.PostId,P.PostName,N.PassScore,N.AddTime,
(SELECT MAX(Score) FROM ExamRecords WHERE ExamNotifyId=R.ExamNotifyId AND PersionId=R.PersionId) AS MaxScore
FROM ExamRecords R
LEFT JOIN ExamNotify N ON R.ExamNotifyId=N.Id
LEFT JOIN ViewPersonInfo P ON R.PersionId=P.Id
GROUP BY R.ExamNotifyId,N.ExamName,R.PersionId,P.Name,P.DepartmentId,P.DepartmentName,P.PostId,P.PostName,N.PassScore,N.AddTime) AS NEWT
go

/*==============================================================*/
/* View: ViewPersonInfo                                         */
/*==============================================================*/
create view ViewPersonInfo as
SELECT P.Id,P.PersonId,P.WorkNo,P.DepartmentId,D.DepartmentName,P.Name,P.Spell,P.BirthDate,P.Sex,P.PostId,T.PostName,P.PhotoPath,P.IdentityNo,P.Password,P.UpdateTime FROM PersonInfo P
LEFT JOIN DepartInfo D ON P.DepartmentId=D.Id
LEFT JOIN Posts T ON P.PostId=T.Id
WHERE P.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorAccept                                   */
/*==============================================================*/
create view ViewInstructorAccept as
-- ��׼��������ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW [dbo].[ViewInstructorAccept]
AS
SELECT 
A.Id,A.AcceptDate,A.InstructorId,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.ViceDriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.ViceDriverId) AS ViceDriverName,
A.DriverScore,A.ViceDriverScore,A.Problems,A.Suggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorAccept A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorAnalysis                                 */
/*==============================================================*/
create view ViewInstructorAnalysis as
-- ��ط�������ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorAnalysis
AS
SELECT 
A.Id,A.InstructorId,A.TrainCode,A.LocomotiveType,A.RunDate,A.RunSection,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.ViceDriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.ViceDriverId) AS ViceDriverName,
A.AnalysisStart,A.AnalysisEnd,A.Problems,A.Suggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorAnalysis A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorCheck                                    */
/*==============================================================*/
create view ViewInstructorCheck as
-- �����Ϣ����ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorCheck
AS
SELECT 
C.Id,C.InstructorId,C.StartTime,C.EndTime,C.Location,C.CheckType,C.ProblemCount,C.CheckContent,C.Problems,C.Suggests,C.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorCheck C
LEFT JOIN ViewPersonInfo P ON C.InstructorId=P.Id
WHERE C.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorGoodJob                                  */
/*==============================================================*/
create view ViewInstructorGoodJob as
-- ��ֹ�¹ʼ����˺��¼�¼��ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorGoodJob
AS
SELECT 
A.Id,A.InstructorId,A.WriteDate,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.GoodJobType,A.GeneralSituation,A.Suggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorGoodJob A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorKeyPerson                                */
/*==============================================================*/
create view ViewInstructorKeyPerson as
-- �ؼ��˹�����ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorKeyPerson
AS
SELECT 
A.Id,A.InstructorId,A.ConfirmDate,A.KeyPersonId,
(SELECT Name FROM PersonInfo WHERE Id=A.KeyPersonId) AS KeyPersonName,
A.ExpectRemoveTime,A.ActualRemoveTime,A.KeyLocation,A.PersonConfirmReason,A.HelpMethod,A.Changes,A.PersonRemoveSuggests,A.LocationConfirmReason,A.ControlMethod,A.ActualControl,A.LocationRemoveSuggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorKeyPerson A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorLocoQuality                              */
/*==============================================================*/
create view ViewInstructorLocoQuality as
-- ���������Ǽ���ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorLocoQuality
AS
SELECT 
A.Id,A.InstructorId,A.RegistDate,A.TrainCode,A.LocomotiveType,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.RepairClass,A.MaintenanceStatus,A.Score,A.FaultLocation,A.GeneralSituation,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorLocoQuality A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorPeccancy                                 */
/*==============================================================*/
create view ViewInstructorPeccancy as
-- Υ�µǼ���ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorPeccancy
AS
SELECT 
A.Id,A.InstructorId,A.WriteDate,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.PeccancyType,A.GeneralSituation,A.Analysis,A.Suggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorPeccancy A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorPlan                                     */
/*==============================================================*/
create view ViewInstructorPlan as
-- �����ܽἰ�ƻ���ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorPlan
AS
SELECT 
A.Id,A.InstructorId,A.WriteDate,A.WorkSummary,A.Problems,A.WorkPlans,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorPlan A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorRepair                                   */
/*==============================================================*/
create view ViewInstructorRepair as
-- �������޼�¼��ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorRepair
AS
SELECT 
A.Id,A.InstructorId,A.HappenTime,A.Location,A.TrainCode,A.LocomotiveType,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.ViceDriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.ViceDriverId) AS ViceDriverName,
A.StudentId,
(SELECT Name FROM PersonInfo WHERE Id=A.StudentId) AS StudentName,
A.FaultLocation,A.FaultReason,A.Responsibility,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorRepair A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorReviewScore                              */
/*==============================================================*/
create view ViewInstructorReviewScore as
SELECT 
S.Id,S.InstructorId,S.Month,S.Year,S.Score,S.UpdateTime,
P.DepartmentId,P.DepartmentName,P.PostId,P.PostName,P.Name,P.WorkNo
FROM InstructorReviewScore S
LEFT JOIN ViewPersonInfo P ON S.InstructorId=P.Id
go

/*==============================================================*/
/* View: ViewInstructorTeach                                    */
/*==============================================================*/
create view ViewInstructorTeach as
-- �ڿ���ѵ��ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorTeach
AS
SELECT 
A.Id,A.InstructorId,A.TeachPlace,A.JoinCount,A.TeachStart,A.TeachEnd,A.TeachContent,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorTeach A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorTempTake                                 */
/*==============================================================*/
create view ViewInstructorTempTake as
-- �����Ϣ����ͼ
-- @author FrancisTan
-- @since 2016-08-08
CREATE VIEW ViewInstructorTempTake
AS
SELECT 
A.Id,A.InstructorId,A.TakeDate,A.TrainCode,A.LocomotiveType,
A.DriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.DriverId) AS DriverName,
A.ViceDriverId,
(SELECT Name FROM PersonInfo WHERE Id=A.ViceDriverId) AS ViceDriverName,
A.StudentId,
(SELECT Name FROM PersonInfo WHERE Id=A.StudentId) AS StudentName,
A.CarCount,A.WholeWeight,A.Length,A.TakeSection,A.RunStart,A.RunEnd,A.OperateSection,A.OperateStart,A.OperateEnd,A.AttendTime,A.EndAttendTime,A.TakeAims,A.Problems,A.Suggests,A.UploadTime,
P.DepartmentId,P.DepartmentName,P.PostName,P.PostId,P.Name
FROM InstructorTempTake A
LEFT JOIN ViewPersonInfo P ON A.InstructorId=P.Id
WHERE A.IsDelete=0
go

/*==============================================================*/
/* View: ViewInstructorWifiRecord                               */
/*==============================================================*/
create view ViewInstructorWifiRecord as
select
   W.Id,
   W.InstructorId,
   W.RouterPositionId,
   W.ConnectFlag,
   W.ConnectTime,
   W.IsDelete,
   R.BssId,
   R.Location,
   V.DepartmentId,
   V.DepartmentName,
   V.Name,
   V.PostName,
   V.PostId
from
   InstructorWifiRecord W
   LEFT OUTER JOIN dbo.InstructorRouterPosition R on  W.RouterPositionId = R.Id
   LEFT OUTER JOIN dbo.ViewPersonInfo V on  W.InstructorId = V.Id
where
   (W.IsDelete = 0)
go

if exists (select 1 from  sys.extended_properties
           where major_id = object_id('ViewInstructorWifiRecord') and minor_id = 0)
begin
   declare @CurrentUser sysname
select @CurrentUser = user_name()
execute sp_dropextendedproperty 'MS_Description', 
   'user', @CurrentUser, 'view', 'ViewInstructorWifiRecord'

end


select @CurrentUser = user_name()
execute sp_addextendedproperty 'MS_Description', 
   'ָ��˾��WIFI���Ӽ�¼',
   'user', @CurrentUser, 'view', 'ViewInstructorWifiRecord'
go

/*==============================================================*/
/* View: ViewSignPoint                                          */
/*==============================================================*/
create view ViewSignPoint as
SELECT
VDR.Id AS DriveRecordId,
DSP.Id, DSP.StationId, DSP.ArriveTime, DSP.LeaveTime, DSP.EarlyMinutes, DSP.LateMinutes, DSP.EarlyOrLateReason,
VBL.LineName,VBL.StationName,VBL.Sort,
TF.CarriageCount,TF.CarryingCapacity,TF.Length,TF.NoteTime
FROM ViewDriveRecord VDR
LEFT JOIN ViewBaseLine VBL ON VDR.LineId=VBL.Id
LEFT JOIN DriveSignPoint DSP ON VDR.Id=DSP.DriveRecordId AND VBL.StationId=DSP.StationId
LEFT JOIN TrainFormation TF ON VDR.Id=TF.DriveRecordId AND VBL.StationId=DSP.StationId
go

/*==============================================================*/
/* View: ViewTrainMoment                                        */
/*==============================================================*/
create view ViewTrainMoment as
SELECT 
M.Id,M.TrainNoLineId,M.TrainStationId,M.ArriveTime,M.DepartTime,M.StopMinutes,M.IntervalKms,M.SuggestSpeed,M.Sort,
N.FullName,S.StationName,N.Id AS TrainNoId,L.LineId,B.LineName
FROM TrainMoment M
LEFT JOIN TrainNoLine L ON M.TrainNoLineId=L.Id
LEFT JOIN TrainNo N ON L.TrainNoId=N.Id
LEFT JOIN BaseLine B ON L.LineId=B.Id
LEFT JOIN BaseStation S ON M.TrainStationId=S.Id
go

/*==============================================================*/
/* View: ViewTrainNoLIne                                        */
/*==============================================================*/
create view ViewTrainNoLIne as
SELECT   TN.Id, TN.FullName, TL.Id AS TrainNoLineId, TL.Sort, BL.Id AS LineId, BL.LineName, BL.FirstStationId, BL.FirstStation, 
                BL.LastStationId, BL.LastStation
FROM      dbo.TrainNo AS TN LEFT OUTER JOIN
                dbo.TrainNoLine AS TL ON TN.Id = TL.TrainNoId LEFT OUTER JOIN
                dbo.BaseLine AS BL ON TL.LineId = BL.Id
WHERE   (TN.IsDelete = 0)
go

/*==============================================================*/
/* View: View_Station                                           */
/*==============================================================*/
create view View_Station as
SELECT   Id, SN, StationName, Spell, UpdateTime, FileCount, ZdCount, CzCount, ZcCount
FROM      (SELECT   S.Id, S.SN, S.StationName, S.Spell, S.UpdateTime,
                                     (SELECT   COUNT(1) AS Expr1
                                      FROM      dbo.StationFiles
                                      WHERE   (StationId = S.Id) AND (IsDelete = 0)) AS FileCount,
                                     (SELECT   COUNT(1) AS Expr1
                                      FROM      dbo.StationFiles
                                      WHERE   (StationId = S.Id) AND (IsDelete = 0) AND (FileType = 1)) AS ZdCount,
                                     (SELECT   COUNT(1) AS Expr1
                                      FROM      dbo.StationFiles
                                      WHERE   (StationId = S.Id) AND (IsDelete = 0) AND (FileType = 2)) AS CzCount,
                                     (SELECT   COUNT(1) AS Expr1
                                      FROM      dbo.StationFiles
                                      WHERE   (StationId = S.Id) AND (IsDelete = 0) AND (FileType = 3)) AS ZcCount
                 FROM      dbo.BaseStation AS S LEFT OUTER JOIN
                                 dbo.StationFiles AS F ON S.Id = F.StationId
                 WHERE   (S.IsDelete = 0)) AS T
GROUP BY Id, SN, StationName, Spell, UpdateTime, FileCount, ZdCount, ZcCount, CzCount
go

alter table PersonInfo
   add constraint FK_PERSONIN_DEPARTINF_DEPARTIN foreign key (DepartmentId)
      references DepartInfo (Id)
go

alter table PersonInfo
   add constraint FK_PERSONIN_POSITION_POSTS foreign key (PostId)
      references Posts (Id)
go

