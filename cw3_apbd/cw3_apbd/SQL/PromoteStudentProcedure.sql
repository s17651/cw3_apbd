CREATE PROCEDURE [dbo].[PromoteStudents] @Studies NVARCHAR(10), @Semester INT
AS
BEGIN
	SET XACT_ABORT ON;
	BEGIN TRAN
	BEGIN TRY
		--pobieramy id kierunku
		DECLARE @IdStudy INT = (SELECT IdStudy FROM Studies WHERE Name=@Studies);
		--jeżeli brak to kończymy z błędem
		IF @IdStudy IS NULL
		BEGIN
			RAISERROR('Brak kierunku', 15, 5);
		END
		--pobieramy id najnowszego semestru
		DECLARE @IdEnrollment INT = (SELECT TOP 1 IdEnrollment FROM Enrollment WHERE Semester = @Semester + 1 AND IdStudy = @IdStudy ORDER BY StartDate DESC)
		--jeżeli brak to dodajemy nowy semestr
		IF @IdEnrollment IS NULL
		BEGIN
			DECLARE @NextId INT = (SELECT MAX(IdEnrollment) FROM Enrollment) + 1;
			INSERT INTO Enrollment(IdEnrollment, Semester, IdStudy, StartDate) VALUES (@NextId, @Semester + 1, @IdStudy, GETDATE());
		END
		--promujemy studentów
		SELECT @IdEnrollment = (SELECT TOP 1 IdEnrollment FROM Enrollment WHERE Semester = @Semester + 1 AND IdStudy = @IdStudy ORDER BY StartDate DESC)
		UPDATE Student 
		SET IdEnrollment = @IdEnrollment 
		WHERE IdEnrollment = (SELECT IdEnrollment 
							  FROM Enrollment 
							  WHERE Semester = @Semester AND IdStudy = @IdStudy)
	
		COMMIT;
	END TRY
	BEGIN CATCH
		ROLLBACK;
	END CATCH
END;