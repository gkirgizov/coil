/* 1 */
SELECT COUNT(*) FROM board;

/* 2 */
SELECT fid 
FROM figures
WHERE ftype Like 'k%';

/* 3 */
SELECT ftype, COUNT(*) / 2 AS fcount
FROM figures
GROUP BY ftype;

/*
CREATE VIEW fboard AS
SELECT figures.fid, ftype, fcolor, x, y
FROM board JOIN figures ON figures.fid = board.fid;
*/

/* 4 */
SELECT fid
FROM fboard
WHERE fcolor = 'white';

/* 5 */
SELECT ftype, fcolor
FROM fboard
WHERE x = y;

/* 6 */
SELECT COUNT(*)
FROM fboard
GROUP BY fcolor;

/* 7 */
SELECT ftype
FROM fboard
WHERE fcolor = 'black'
GROUP BY ftype;

/* 8 */
SELECT ftype, COUNT(*)
FROM fboard
WHERE fcolor = 'black'
GROUP BY ftype;

/* 9 */
SELECT ftype
FROM fboard
GROUP BY ftype
HAVING COUNT(*) > 1;

/* 10 */

/* -- already eists --
CREATE TEMP TABLE countfig AS
SELECT fcolor, COUNT(*) as amount
FROM fboard
GROUP BY fcolor;
*/

SELECT fcolor
FROM countfig
WHERE amount = (
	SELECT MAX(amount)
	FROM countfig);

/* 11 */
SELECT ftype, fcolor
FROM fboard
WHERE 
	x IN (SELECT x
	FROM fboard
	WHERE ftype = 'rook') 
	OR
	y in (SELECT y
	FROM fboard
	WHERE ftype = 'rook');


/* 12 */
WITH pawnsLeft AS (
	SELECT fcolor, COUNT(*) as pawns
	FROM fboard
	GROUP BY fcolor, ftype
	HAVING ftype = 'pawn'
)
SELECT fcolor
FROM pawnsLeft
WHERE pawns = 8;

/* 13 */
SELECT board1.fid
FROM board1 LEFT JOIN board2 ON board1.fid = board2.fid
WHERE (board1.x <> board2.x) OR (board1.y <> board2.y)
	OR board2.x IS NULL;

/* 14 */
/*
CREATE FUNCTION distX (xFrom int, fidTo int)
RETURNS int AS
$$ BEGIN
	RETURN abs(xFrom - (SELECT x FROM board WHERE fid = fidTo)); 
END; $$
LANGUAGE plpgsql;

CREATE FUNCTION distY (yFrom int, fidTo int)
RETURNS int AS
$$ BEGIN
	RETURN abs(yFrom - (SELECT y FROM board WHERE fid = fidTo)); 
END; $$
LANGUAGE plpgsql;
*/

SELECT fid
FROM board
WHERE 
	distX(x, 17) <= 2 AND distY(y, 17) <= 2
	AND fid <> 17;

/* 15 */
WITH fdistance AS (
	SELECT ftype, fcolor, distX(x, 1) + distY(y, 1) AS dist
	FROM fboard
	WHERE fid <> 1
)
SELECT ftype, fcolor, dist
FROM fdistance
WHERE dist = (SELECT MIN(dist) FROM fdistance);