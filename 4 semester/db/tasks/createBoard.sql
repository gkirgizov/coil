CREATE TABLE board (
	fid int REFERENCES figures (fid),
	x int NOT NULL CHECK(x >= 1 AND x <= 8),
	y int NOT NULL CHECK(y >= 1 AND y <= 8),
	UNIQUE (x, y)
)