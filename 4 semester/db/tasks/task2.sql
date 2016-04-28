/* Сколько вариантов ходов может король сделать? 
   (сколько вокруг фигуры не занятых союзниками клеток?)*/

CREATE OR REPLACE FUNCTION isFree(cellX int, cellY int, allie char(5))
RETURNS boolean AS
$$ BEGIN 
	RETURN NOT EXISTS (
		SELECT * FROM fboard
		WHERE x = cellX AND y = cellY AND fcolor = allie);
END; $$
LANGUAGE plpgsql;

CREATE OR REPLACE FUNCTION checkWays(fid_ int)
RETURNS int AS $$
DECLARE
	count int := 0;
	kx int := (SELECT x FROM fboard WHERE fid = fid_);
	ky int := (SELECT y FROM fboard WHERE fid = fid_);
	kcolor char(5) := (SELECT fcolor FROM fboard WHERE fid = fid_);
BEGIN 
	FOR ix IN 1 .. 8 LOOP
		FOR iy IN 1 .. 8 LOOP
			IF abs(ix - kx) < 2 AND abs(iy - ky) < 2 AND isFree(ix, iy, kcolor) THEN
				count := count + 1;
			END IF;
		END LOOP;
	END LOOP;
	RETURN count;
END; $$
LANGUAGE plpgsql;

SELECT checkWays(1);