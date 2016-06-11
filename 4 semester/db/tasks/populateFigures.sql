DO
$do$
DECLARE
	ftypes char(6)[] := array['king', 'queen', 'rook','rook', 'bishop','bishop', 'knight','knight', 'pawn','pawn','pawn','pawn','pawn','pawn','pawn','pawn'];
	fcolors char(6)[] := array['white', 'black'];
	fid integer;
BEGIN 
	
	FOR c in 1 .. 2 LOOP
		FOR f in 1 .. 16 LOOP
			fid := (c - 1) * 16 + f;
			INSERT INTO figures VALUES (fid, fcolors[c], ftypes[f]);
			RAISE NOTICE 'NEW ROW: % % %', fid, fcolors[c], ftypes[f];
		END LOOP;
	END LOOP;
END;
$do$