/* Процедура: написать процедуру, которая делает ход фигуры. 
   Параметры процедуры: id фигуры, координаты, куда фигура ходит, и внешний параметр - результат. 
   Результат должен быть:
   0, если походить не удалось, 
   1, если походили
   2, если съели вражескую фигуру. */

CREATE OR REPLACE FUNCTION makeStep(fid_ int, x_to int, y_to int)
RETURNS int AS $$
DECLARE
	result int := 0;
	fcolor_ char(5) := (SELECT fcolor FROM fboard WHERE fid = fid_);
BEGIN
	IF NOT EXISTS (SELECT * FROM board WHERE fid = fid_) --если не сущ-т такой фигуры на доске ИЛИ
	   OR (x_to < 1 OR x_to > 8 OR y_to < 1 OR y_to > 8) --если пытаемся походить за пределы доски ИЛИ
	   OR NOT isFree(x_to, y_to, fcolor_) 		     --новая клетка занята союзником
	THEN RETURN result; END IF;

	IF EXISTS (SELECT * FROM fboard WHERE x = x_to AND y = y_to AND fcolor <> fcolor_) THEN
		DELETE FROM board WHERE x = x_to AND y = y_to;
		result := 1; 
	END IF;
		
	UPDATE board SET x = x_to, y = y_to WHERE fid = fid_;
	RETURN result + 1;
END; $$
LANGUAGE plpgsql;

--SELECT makeStep(10, 50, 2);