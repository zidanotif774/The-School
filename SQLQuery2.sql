
USE [School2.mdf]
GO
 IF NOT EXISTS(SELECT * FROM sys.schemas WHERE [name] = N'School2')      
     EXEC (N'CREATE SCHEMA School2')                                   
 GO                                                               

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [admin_add_teacher_teaching_inschoolinyear]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[admin_add_teacher_teaching_inschoolinyear]
(
   [id] int IDENTITY(96, 1)  NOT NULL,
   [user_id] int  NULL,
   [teach_Id] int  NOT NULL,
   [year_Id] int  NOT NULL,
   [term_id] int  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.admin_add_teacher_teaching_inschoolinyear',
        N'SCHEMA', N'School2',
        N'TABLE', N'admin_add_teacher_teaching_inschoolinyear'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'student_sex'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'student_sex'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [student_sex]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[student_sex]
(
   [sex_id] int  NOT NULL,
   [sex_name] nvarchar(max)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.student_sex',
        N'SCHEMA', N'School2',
        N'TABLE', N'student_sex'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'student_status'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'student_status'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [student_status]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[student_status]
(
   [stat_id] int  NOT NULL,
   [stat_name] nvarchar(max)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.student_status',
        N'SCHEMA', N'School2',
        N'TABLE', N'student_status'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_admin_register_stud_in_class_in_year'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_admin_register_stud_in_class_in_year'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_admin_register_stud_in_class_in_year]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_admin_register_stud_in_class_in_year]
(
   [id] int IDENTITY(21, 1)  NOT NULL,
   [user_id] int  NULL,
   [stud_id] int  NOT NULL,
   [stat_id] int  NOT NULL,
   [classe_id] int  NOT NULL,
   [year_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_admin_register_stud_in_class_in_year',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_admin_register_stud_in_class_in_year'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classs'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_classs'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_classs]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_classs]
(
   [class_id] int IDENTITY(73, 1)  NOT NULL,
   [class_name] nvarchar(max)  NULL,
   [level_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_classs',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_classs'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classsubjects'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_classsubjects'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_classsubjects]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_classsubjects]
(
   [ClSu_id] int IDENTITY(140, 1)  NOT NULL,
   [classe_id] int  NOT NULL,
   [sub_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_classsubjects',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_classsubjects'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_degrees]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_degrees]
(
   [id] int IDENTITY(75, 1)  NOT NULL,
   [year_id] int  NOT NULL,
   [class_id] int  NOT NULL,
   [stud_id] int  NOT NULL,
   [sub_id] int  NOT NULL,
   [term_id] int  NOT NULL,
   [exam_id] int  NOT NULL,
   [mark] decimal(3, 0)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_degrees',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_degrees'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_divisions'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_divisions'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_divisions]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_divisions]
(
   [divis_id] int IDENTITY(1, 1)  NOT NULL,
   [classe_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_divisions',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_divisions'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_exam'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_exam'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_exam]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_exam]
(
   [id] int IDENTITY(13, 1)  NOT NULL,
   [exam_name] nvarchar(max)  NOT NULL,
   [gradeMax] int  NOT NULL,
   [term] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_exam',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_exam'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_level'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_level'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_level]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_level]
(
   [level_id] int IDENTITY(28, 1)  NOT NULL,
   [level_name] nvarchar(max)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_level',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_level'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_schoolterm'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_schoolterm'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_schoolterm]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_schoolterm]
(
   [term_id] int  NOT NULL,
   [term_name] nvarchar(max)  NOT NULL,
   [IsActive] smallint  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_schoolterm',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_schoolterm'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_schoolyear'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_schoolyear'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_schoolyear]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_schoolyear]
(
   [year_id] int IDENTITY(45, 1)  NOT NULL,
   [year_name] nvarchar(max)  NOT NULL,
   [IsActive] smallint  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_schoolyear',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_schoolyear'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_students'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_students'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_students]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_students]
(
   [stud_id] int IDENTITY(43, 1)  NOT NULL,
   [stud_name] nvarchar(50)  NOT NULL,
   [stud_bod_m] date  NOT NULL,
   [stud_addres] nvarchar(50)  NULL,
   [stud_sex_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_students',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_students'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_subjects'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_subjects'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_subjects]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_subjects]
(
   [sub_id] int IDENTITY(21, 1)  NOT NULL,
   [sub_name] nvarchar(max)  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_subjects',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_subjects'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_teacher_teaching_subject_class'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_teacher_teaching_subject_class'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_teacher_teaching_subject_class]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_teacher_teaching_subject_class]
(
   [TeacherSubjectClass_id] int IDENTITY(78, 1)  NOT NULL,
   [teach_id] int  NOT NULL,
   [subClass_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_teacher_teaching_subject_class',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_teacher_teaching_subject_class'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_teachers'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_teachers'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_teachers]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_teachers]
(
   [teach_id] int IDENTITY(20, 1)  NOT NULL,

   /*
   *   SSMA informational messages:
   *   M2SS0003: The following SQL clause was ignored during conversion: COMMENT 'اسم المدرس'.
   */

   [teach_name_] nvarchar(max)  NOT NULL,
   [isActive] smallint  NOT NULL,
   [Teacher_sex] int  NOT NULL,
   [major] nvarchar(max)  NULL,
   [phone] nvarchar(max)  NULL,
   [Teacher_CardNum] nvarchar(max)  NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_teachers',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_teachers'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_terminyear'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_terminyear'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_terminyear]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_terminyear]
(
   [id] int IDENTITY(9, 1)  NOT NULL,
   [year_id] int  NOT NULL,
   [term_id] int  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_terminyear',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_terminyear'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_users'  AND sc.name = N'School2'  AND type in (N'U'))
BEGIN

  DECLARE @drop_statement nvarchar(500)

  DECLARE drop_cursor CURSOR FOR
      SELECT 'alter table '+quotename(schema_name(ob.schema_id))+
      '.'+quotename(object_name(ob.object_id))+ ' drop constraint ' + quotename(fk.name) 
      FROM sys.objects ob INNER JOIN sys.foreign_keys fk ON fk.parent_object_id = ob.object_id
      WHERE fk.referenced_object_id = 
          (
             SELECT so.object_id 
             FROM sys.objects so JOIN sys.schemas sc
             ON so.schema_id = sc.schema_id
             WHERE so.name = N'tbl_users'  AND sc.name = N'School2'  AND type in (N'U')
           )

  OPEN drop_cursor

  FETCH NEXT FROM drop_cursor
  INTO @drop_statement

  WHILE @@FETCH_STATUS = 0
  BEGIN
     EXEC (@drop_statement)

     FETCH NEXT FROM drop_cursor
     INTO @drop_statement
  END

  CLOSE drop_cursor
  DEALLOCATE drop_cursor

  DROP TABLE [tbl_users]
END 
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE 
[tbl_users]
(
   [user_id] int IDENTITY(3, 1)  NOT NULL,
   [user_name] nvarchar(50)  NOT NULL,
   [pasword] nvarchar(50)  NOT NULL,
   [typework] smallint  NOT NULL
)
WITH (DATA_COMPRESSION = NONE)
GO
BEGIN TRY
    EXEC sp_addextendedproperty
        N'MS_SSMA_SOURCE', N'School2.tbl_users',
        N'SCHEMA', N'School2',
        N'TABLE', N'tbl_users'
END TRY
BEGIN CATCH
    IF (@@TRANCOUNT > 0) ROLLBACK
    PRINT ERROR_MESSAGE()
END CATCH
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_admin_add_teacher_teaching_inschoolinyear_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [admin_add_teacher_teaching_inschoolinyear] DROP CONSTRAINT [PK_admin_add_teacher_teaching_inschoolinyear_id]
 GO



ALTER TABLE [admin_add_teacher_teaching_inschoolinyear]
 ADD CONSTRAINT [PK_admin_add_teacher_teaching_inschoolinyear_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_student_sex_sex_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [student_sex] DROP CONSTRAINT [PK_student_sex_sex_id]
 GO



ALTER TABLE [student_sex]
 ADD CONSTRAINT [PK_student_sex_sex_id]
   PRIMARY KEY
   CLUSTERED ([sex_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_student_status_stat_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [student_status] DROP CONSTRAINT [PK_student_status_stat_id]
 GO



ALTER TABLE [student_status]
 ADD CONSTRAINT [PK_student_status_stat_id]
   PRIMARY KEY
   CLUSTERED ([stat_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_admin_register_stud_in_class_in_year_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_admin_register_stud_in_class_in_year] DROP CONSTRAINT [PK_tbl_admin_register_stud_in_class_in_year_id]
 GO



ALTER TABLE [tbl_admin_register_stud_in_class_in_year]
 ADD CONSTRAINT [PK_tbl_admin_register_stud_in_class_in_year_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_classs_class_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_classs] DROP CONSTRAINT [PK_tbl_classs_class_id]
 GO



ALTER TABLE [tbl_classs]
 ADD CONSTRAINT [PK_tbl_classs_class_id]
   PRIMARY KEY
   CLUSTERED ([class_id] ASC, [level_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_classsubjects_ClSu_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_classsubjects] DROP CONSTRAINT [PK_tbl_classsubjects_ClSu_id]
 GO



ALTER TABLE [tbl_classsubjects]
 ADD CONSTRAINT [PK_tbl_classsubjects_ClSu_id]
   PRIMARY KEY
   CLUSTERED ([ClSu_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_degrees_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_degrees] DROP CONSTRAINT [PK_tbl_degrees_id]
 GO



ALTER TABLE [tbl_degrees]
 ADD CONSTRAINT [PK_tbl_degrees_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_divisions_divis_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_divisions] DROP CONSTRAINT [PK_tbl_divisions_divis_id]
 GO



ALTER TABLE [tbl_divisions]
 ADD CONSTRAINT [PK_tbl_divisions_divis_id]
   PRIMARY KEY
   CLUSTERED ([divis_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_exam_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_exam] DROP CONSTRAINT [PK_tbl_exam_id]
 GO



ALTER TABLE [tbl_exam]
 ADD CONSTRAINT [PK_tbl_exam_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_level_level_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_level] DROP CONSTRAINT [PK_tbl_level_level_id]
 GO



ALTER TABLE [tbl_level]
 ADD CONSTRAINT [PK_tbl_level_level_id]
   PRIMARY KEY
   CLUSTERED ([level_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_schoolterm_term_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_schoolterm] DROP CONSTRAINT [PK_tbl_schoolterm_term_id]
 GO



ALTER TABLE [tbl_schoolterm]
 ADD CONSTRAINT [PK_tbl_schoolterm_term_id]
   PRIMARY KEY
   CLUSTERED ([term_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_schoolyear_year_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_schoolyear] DROP CONSTRAINT [PK_tbl_schoolyear_year_id]
 GO



ALTER TABLE [tbl_schoolyear]
 ADD CONSTRAINT [PK_tbl_schoolyear_year_id]
   PRIMARY KEY
   CLUSTERED ([year_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_students_stud_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_students] DROP CONSTRAINT [PK_tbl_students_stud_id]
 GO



ALTER TABLE [tbl_students]
 ADD CONSTRAINT [PK_tbl_students_stud_id]
   PRIMARY KEY
   CLUSTERED ([stud_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_subjects_sub_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_subjects] DROP CONSTRAINT [PK_tbl_subjects_sub_id]
 GO



ALTER TABLE [tbl_subjects]
 ADD CONSTRAINT [PK_tbl_subjects_sub_id]
   PRIMARY KEY
   CLUSTERED ([sub_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_teacher_teaching_subject_class_TeacherSubjectClass_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_teacher_teaching_subject_class] DROP CONSTRAINT [PK_tbl_teacher_teaching_subject_class_TeacherSubjectClass_id]
 GO



ALTER TABLE [tbl_teacher_teaching_subject_class]
 ADD CONSTRAINT [PK_tbl_teacher_teaching_subject_class_TeacherSubjectClass_id]
   PRIMARY KEY
   CLUSTERED ([TeacherSubjectClass_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_teachers_teach_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_teachers] DROP CONSTRAINT [PK_tbl_teachers_teach_id]
 GO



ALTER TABLE [tbl_teachers]
 ADD CONSTRAINT [PK_tbl_teachers_teach_id]
   PRIMARY KEY
   CLUSTERED ([teach_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_terminyear_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_terminyear] DROP CONSTRAINT [PK_tbl_terminyear_id]
 GO



ALTER TABLE [tbl_terminyear]
 ADD CONSTRAINT [PK_tbl_terminyear_id]
   PRIMARY KEY
   CLUSTERED ([id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'PK_tbl_users_user_id'  AND sc.name = N'School2'  AND type in (N'PK'))
ALTER TABLE [tbl_users] DROP CONSTRAINT [PK_tbl_users_user_id]
 GO



ALTER TABLE [tbl_users]
 ADD CONSTRAINT [PK_tbl_users_user_id]
   PRIMARY KEY
   CLUSTERED ([user_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classsubjects$classe_id'  AND sc.name = N'School2'  AND type in (N'UQ'))
ALTER TABLE [tbl_classsubjects] DROP CONSTRAINT [tbl_classsubjects$classe_id]
 GO



ALTER TABLE [tbl_classsubjects]
 ADD CONSTRAINT [tbl_classsubjects$classe_id]
 UNIQUE 
   NONCLUSTERED ([classe_id] ASC, [sub_id] ASC)

GO


USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear'  AND sc.name = N'School2'  AND si.name = N'admin_add_teacher_teaching_inschoolinyear_ibfk_1' AND so.type in (N'U'))
   DROP INDEX [admin_add_teacher_teaching_inschoolinyear_ibfk_1] ON [admin_add_teacher_teaching_inschoolinyear] 
GO
CREATE NONCLUSTERED INDEX [admin_add_teacher_teaching_inschoolinyear_ibfk_1] ON [admin_add_teacher_teaching_inschoolinyear]
(
   [teach_Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear'  AND sc.name = N'School2'  AND si.name = N'admin_add_teacher_teaching_inschoolinyear_ibfk_2' AND so.type in (N'U'))
   DROP INDEX [admin_add_teacher_teaching_inschoolinyear_ibfk_2] ON [admin_add_teacher_teaching_inschoolinyear] 
GO
CREATE NONCLUSTERED INDEX [admin_add_teacher_teaching_inschoolinyear_ibfk_2] ON [admin_add_teacher_teaching_inschoolinyear]
(
   [year_Id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_users'  AND sc.name = N'School2'  AND si.name = N'admin_name' AND so.type in (N'U'))
   DROP INDEX [admin_name] ON [tbl_users] 
GO
CREATE NONCLUSTERED INDEX [admin_name] ON [tbl_users]
(
   [user_name] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_divisions'  AND sc.name = N'School2'  AND si.name = N'classe_id' AND so.type in (N'U'))
   DROP INDEX [classe_id] ON [tbl_divisions] 
GO
CREATE NONCLUSTERED INDEX [classe_id] ON [tbl_divisions]
(
   [classe_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_classs'  AND sc.name = N'School2'  AND si.name = N'gred_id' AND so.type in (N'U'))
   DROP INDEX [gred_id] ON [tbl_classs] 
GO
CREATE NONCLUSTERED INDEX [gred_id] ON [tbl_classs]
(
   [level_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_students'  AND sc.name = N'School2'  AND si.name = N'stud_sex' AND so.type in (N'U'))
   DROP INDEX [stud_sex] ON [tbl_students] 
GO
CREATE NONCLUSTERED INDEX [stud_sex] ON [tbl_students]
(
   [stud_sex_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_classsubjects'  AND sc.name = N'School2'  AND si.name = N'tbl_classsubjects_ibfk_2' AND so.type in (N'U'))
   DROP INDEX [tbl_classsubjects_ibfk_2] ON [tbl_classsubjects] 
GO
CREATE NONCLUSTERED INDEX [tbl_classsubjects_ibfk_2] ON [tbl_classsubjects]
(
   [sub_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND si.name = N'tbl_degrees_ibfk_1' AND so.type in (N'U'))
   DROP INDEX [tbl_degrees_ibfk_1] ON [tbl_degrees] 
GO
CREATE NONCLUSTERED INDEX [tbl_degrees_ibfk_1] ON [tbl_degrees]
(
   [year_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND si.name = N'tbl_degrees_ibfk_3' AND so.type in (N'U'))
   DROP INDEX [tbl_degrees_ibfk_3] ON [tbl_degrees] 
GO
CREATE NONCLUSTERED INDEX [tbl_degrees_ibfk_3] ON [tbl_degrees]
(
   [sub_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND si.name = N'tbl_degrees_ibfk_4' AND so.type in (N'U'))
   DROP INDEX [tbl_degrees_ibfk_4] ON [tbl_degrees] 
GO
CREATE NONCLUSTERED INDEX [tbl_degrees_ibfk_4] ON [tbl_degrees]
(
   [stud_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_degrees'  AND sc.name = N'School2'  AND si.name = N'tbl_degrees_ibfk_6' AND so.type in (N'U'))
   DROP INDEX [tbl_degrees_ibfk_6] ON [tbl_degrees] 
GO
CREATE NONCLUSTERED INDEX [tbl_degrees_ibfk_6] ON [tbl_degrees]
(
   [class_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_teacher_teaching_subject_class'  AND sc.name = N'School2'  AND si.name = N'tbl_teacher_teaching_subject_class_ibfk_1' AND so.type in (N'U'))
   DROP INDEX [tbl_teacher_teaching_subject_class_ibfk_1] ON [tbl_teacher_teaching_subject_class] 
GO
CREATE NONCLUSTERED INDEX [tbl_teacher_teaching_subject_class_ibfk_1] ON [tbl_teacher_teaching_subject_class]
(
   [subClass_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_teacher_teaching_subject_class'  AND sc.name = N'School2'  AND si.name = N'tbl_teacher_teaching_subject_class_ibfk_3' AND so.type in (N'U'))
   DROP INDEX [tbl_teacher_teaching_subject_class_ibfk_3] ON [tbl_teacher_teaching_subject_class] 
GO
CREATE NONCLUSTERED INDEX [tbl_teacher_teaching_subject_class_ibfk_3] ON [tbl_teacher_teaching_subject_class]
(
   [teach_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_teachers'  AND sc.name = N'School2'  AND si.name = N'Teacher_sex' AND so.type in (N'U'))
   DROP INDEX [Teacher_sex] ON [tbl_teachers] 
GO
CREATE NONCLUSTERED INDEX [Teacher_sex] ON [tbl_teachers]
(
   [Teacher_sex] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (
       SELECT * FROM sys.objects  so JOIN sys.indexes si
       ON so.object_id = si.object_id
       JOIN sys.schemas sc
       ON so.schema_id = sc.schema_id
       WHERE so.name = N'tbl_terminyear'  AND sc.name = N'School2'  AND si.name = N'year_id' AND so.type in (N'U'))
   DROP INDEX [year_id] ON [tbl_terminyear] 
GO
CREATE NONCLUSTERED INDEX [year_id] ON [tbl_terminyear]
(
   [year_id] ASC
)
WITH (SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF) ON [PRIMARY] 
GO
GO

USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_1'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [admin_add_teacher_teaching_inschoolinyear] DROP CONSTRAINT [admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_1]
 GO



ALTER TABLE [admin_add_teacher_teaching_inschoolinyear]
 ADD CONSTRAINT [admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_1]
 FOREIGN KEY 
   ([teach_Id])
 REFERENCES 
   [School2.mdf].[tbl_teachers]     ([teach_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_2'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [admin_add_teacher_teaching_inschoolinyear] DROP CONSTRAINT [admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_2]
 GO



ALTER TABLE [admin_add_teacher_teaching_inschoolinyear]
 ADD CONSTRAINT [admin_add_teacher_teaching_inschoolinyear$admin_add_teacher_teaching_inschoolinyear_ibfk_2]
 FOREIGN KEY 
   ([year_Id])
 REFERENCES 
   [School2.mdf].[tbl_schoolyear]     ([year_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classs$tbl_classs_ibfk_1'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_classs] DROP CONSTRAINT [tbl_classs$tbl_classs_ibfk_1]
 GO



ALTER TABLE [tbl_classs]
 ADD CONSTRAINT [tbl_classs$tbl_classs_ibfk_1]
 FOREIGN KEY 
   ([level_id])
 REFERENCES 
   [School2.mdf].[tbl_level]     ([level_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classsubjects$tbl_classsubjects_ibfk_1'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_classsubjects] DROP CONSTRAINT [tbl_classsubjects$tbl_classsubjects_ibfk_1]
 GO


/* 
*   SSMA error messages:
*   M2SS0015: Foreign Key is not Primary key or Unique key in the referenced table


ALTER TABLE [tbl_classsubjects]
 ADD CONSTRAINT [tbl_classsubjects$tbl_classsubjects_ibfk_1]
 FOREIGN KEY 
   ([classe_id])
 REFERENCES 
   [School2.mdf].[tbl_classs]     ([class_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

*/

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_classsubjects$tbl_classsubjects_ibfk_2'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_classsubjects] DROP CONSTRAINT [tbl_classsubjects$tbl_classsubjects_ibfk_2]
 GO



ALTER TABLE [tbl_classsubjects]
 ADD CONSTRAINT [tbl_classsubjects$tbl_classsubjects_ibfk_2]
 FOREIGN KEY 
   ([sub_id])
 REFERENCES 
   [School2.mdf].[tbl_subjects]     ([sub_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_degrees$tbl_degrees_ibfk_1'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_degrees] DROP CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_1]
 GO



ALTER TABLE [tbl_degrees]
 ADD CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_1]
 FOREIGN KEY 
   ([year_id])
 REFERENCES 
   [School2.mdf].[tbl_schoolyear]     ([year_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_degrees$tbl_degrees_ibfk_3'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_degrees] DROP CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_3]
 GO



ALTER TABLE [tbl_degrees]
 ADD CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_3]
 FOREIGN KEY 
   ([sub_id])
 REFERENCES 
   [School2.mdf].[tbl_subjects]     ([sub_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_degrees$tbl_degrees_ibfk_4'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_degrees] DROP CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_4]
 GO



ALTER TABLE [tbl_degrees]
 ADD CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_4]
 FOREIGN KEY 
   ([stud_id])
 REFERENCES 
   [School2.mdf].[tbl_students]     ([stud_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

GO

IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_degrees$tbl_degrees_ibfk_6'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_degrees] DROP CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_6]
 GO


/* 
*   SSMA error messages:
*   M2SS0015: Foreign Key is not Primary key or Unique key in the referenced table


ALTER TABLE [tbl_degrees]
 ADD CONSTRAINT [tbl_degrees$tbl_degrees_ibfk_6]
 FOREIGN KEY 
   ([class_id])
 REFERENCES 
   [School2.mdf].[tbl_classs]     ([class_id])
    ON DELETE CASCADE
    ON UPDATE CASCADE

*/

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_divisions$tbl_divisions_ibfk_1'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_divisions] DROP CONSTRAINT [tbl_divisions$tbl_divisions_ibfk_1]
 GO


/* 
*   SSMA error messages:
*   M2SS0015: Foreign Key is not Primary key or Unique key in the referenced table


ALTER TABLE [tbl_divisions]
 ADD CONSTRAINT [tbl_divisions$tbl_divisions_ibfk_1]
 FOREIGN KEY 
   ([classe_id])
 REFERENCES 
   [School2.mdf].[tbl_classs]     ([class_id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

*/

GO


USE [School2.mdf]
GO
IF EXISTS (SELECT * FROM sys.objects so JOIN sys.schemas sc ON so.schema_id = sc.schema_id WHERE so.name = N'tbl_students$tbl_students_ibfk_5'  AND sc.name = N'School2'  AND type in (N'F'))
ALTER TABLE [tbl_students] DROP CONSTRAINT [tbl_students$tbl_students_ibfk_5]
 GO



ALTER TABLE [tbl_students]
 ADD CONSTRAINT [tbl_students$tbl_students_ibfk_5]
 FOREIGN KEY 
   ([stud_sex_id])
 REFERENCES 
   [School2.mdf].[student_sex]     ([sex_id])
    ON DELETE NO ACTION
    ON UPDATE NO ACTION

GO


USE [School2.mdf]
GO
ALTER TABLE  [admin_add_teacher_teaching_inschoolinyear]
 ADD DEFAULT NULL FOR [user_id]
GO

ALTER TABLE  [admin_add_teacher_teaching_inschoolinyear]
 ADD DEFAULT NULL FOR [term_id]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_admin_register_stud_in_class_in_year]
 ADD DEFAULT NULL FOR [user_id]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_classs]
 ADD DEFAULT NULL FOR [class_name]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_schoolterm]
 ADD DEFAULT NULL FOR [IsActive]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_schoolyear]
 ADD DEFAULT NULL FOR [IsActive]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_students]
 ADD DEFAULT NULL FOR [stud_addres]
GO


USE [School2.mdf]
GO
ALTER TABLE  [tbl_teachers]
 ADD DEFAULT NULL FOR [major]
GO

ALTER TABLE  [tbl_teachers]
 ADD DEFAULT NULL FOR [phone]
GO

ALTER TABLE  [tbl_teachers]
 ADD DEFAULT NULL FOR [Teacher_CardNum]
GO

