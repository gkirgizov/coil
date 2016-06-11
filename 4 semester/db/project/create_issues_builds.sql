-- Create builds ans issues tables and corresponding relations

CREATE TYPE iss_type AS ENUM ('bug', 'feature');
CREATE TYPE iss_status AS ENUM ('open', 'closed', 'checked');

CREATE TABLE builds (
	project varchar(128) NOT NULL,
	version int NOT NULL,

	FOREIGN KEY (project) REFERENCES projects ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (project, version)
);

CREATE TABLE issues (
	project varchar(128) NOT NULL,
	issue_uid int NOT NULL,
	title varchar(128) NOT NULL,
	description text,
	type iss_type NOT NULL,
	priority char NOT NULL CHECK(priority='A' OR  priority='B' OR priority='C'),

	responsible_tester int REFERENCES employees,
	responsible_programmer int REFERENCES employees,

	FOREIGN KEY (project) REFERENCES projects ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (project, issue_uid)
);

CREATE TABLE bug_sources (
	project varchar(128) NOT NULL,
	bug_uid int NOT NULL,
	source_uid int NOT NULL,

	FOREIGN KEY (project, bug_uid) REFERENCES issues ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (project, source_uid) REFERENCES issues ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (project, bug_uid, source_uid)
);

CREATE TABLE issue_statuses (
	project varchar(128) NOT NULL,
	build int NOT NULL,
	issue int NOT NULL,
	status iss_status NOT NULL,
	
	FOREIGN KEY (project, build) REFERENCES builds ON UPDATE CASCADE ON DELETE CASCADE,
	FOREIGN KEY (project, issue) REFERENCES issues ON UPDATE CASCADE ON DELETE CASCADE,
	PRIMARY KEY (project, build, issue)
);