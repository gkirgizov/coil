/* Триггер, хранящий историю шахматной партии */

CREATE TABLE log_fboard (
	fid int REFERENCES figures (fid),
	x_old int NOT NULL CHECK(x_old >= 1 AND x_old <= 8),
	y_old int NOT NULL CHECK(y_old >= 1 AND y_old <= 8),
	x_new int CHECK(x_new >= 1 AND x_new <= 8),
	y_new int CHECK(y_new >= 1 AND y_new <= 8),
	ftime time without time zone NOT NULL --now
);

CREATE OR REPLACE FUNCTION log_step()
RETURNS trigger AS $log_step$
BEGIN
	IF (TG_OP = 'DELETE') THEN
		INSERT INTO log_fboard VALUES(OLD.fid, OLD.x, OLD.y, NULL, NULL, now());
		RETURN NULL;
	ELSIF (TG_OP = 'UPDATE') THEN
		INSERT INTO log_fboard VALUES(OLD.fid, OLD.x, OLD.y, NEW.x, NEW.y, now());
		RETURN NULL;
	END IF;
	RETURN NULL;
END; $log_step$
LANGUAGE plpgsql;

CREATE TRIGGER loggame 
	AFTER UPDATE OR DELETE ON board
	FOR EACH ROW
	--WHEN (OLD.* IS DISTINCT FROM NEW.*)
	EXECUTE PROCEDURE log_step();
	