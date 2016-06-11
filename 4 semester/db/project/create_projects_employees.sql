--Creating table Project and Employee--

--CREATE TYPE emp_role AS ENUM ('programmer', 'tester', 'manager');

CREATE TABLE employees (
	employee_uid int PRIMARY KEY,
	full_name varchar(128) NOT NULL,
	email varchar(128) NOT NULL,
	role emp_role NOT NULL
);

CREATE TABLE projects (
	project_name varchar(128) PRIMARY KEY,
	start date NOT NULL DEFAULT now()::date,
	plan_end date NOT NULL,

	manager int REFERENCES employees
);

CREATE TABLE employees_projects (
	project varchar(128) REFERENCES projects ON UPDATE CASCADE ON DELETE CASCADE,
	employee int REFERENCES employees ON UPDATE CASCADE ON DELETE CASCADE,
	devoted_time int NOT NULL CHECK(devoted_time > 0 AND devoted_time < 101),
	PRIMARY KEY (project, employee)
);