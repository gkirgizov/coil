/* Какие фигуры может съесть данная? (для короля) */

CREATE OR REPLACE FUNCTION getBeatable(fid_ int)
RETURNS TABLE(id int, color char(5), type char(6), x_ int, y_ int) AS $$
DECLARE
	kx int := (SELECT x FROM fboard WHERE fid = fid_);
	ky int := (SELECT y FROM fboard WHERE fid = fid_);
	kcolor char(5) := (SELECT fcolor FROM fboard WHERE fid = fid_);
BEGIN 
	RETURN QUERY (
		SELECT * FROM fboard
		WHERE fcolor <> kcolor AND abs(x - kx) < 2 AND abs(y - ky) < 2);
END; $$
LANGUAGE plpgsql;

SELECT getBeatable(1);