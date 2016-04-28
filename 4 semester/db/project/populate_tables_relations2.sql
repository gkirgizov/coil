--employees
INSERT INTO employees VALUES(8, 'Monica Washington', 'monica@work.com', 'manager');
INSERT INTO employees VALUES(9, 'Mendy Fillipovich', 'fillipovich@work.com', 'tester');

--projects
INSERT INTO projects VALUES('messenger', '2016-03-01', '2016-11-01', 8);

--employees_projects
INSERT INTO employees_projects VALUES('messenger', 8, 100);
INSERT INTO employees_projects VALUES('messenger', 9, 100);
INSERT INTO employees_projects VALUES('messenger', 3, 30);
INSERT INTO employees_projects VALUES('messenger', 5, 50);
INSERT INTO employees_projects VALUES('messenger', 6, 30);
INSERT INTO employees_projects VALUES('messenger', 7, 70);

--builds
INSERT INTO builds VALUES('messenger', 10);
INSERT INTO builds VALUES('messenger', 11);
INSERT INTO builds VALUES('messenger', 12);
INSERT INTO builds VALUES('messenger', 20);

--issues
INSERT INTO issues VALUES('messenger', 1, 'Tabs support', '', 'feature', 'B', 3, 5);
INSERT INTO issues VALUES('messenger', 2, 'Tabs support', 'Program crashes with many tabs open (more than 20).', 'bug', 'B', 3, 5);

INSERT INTO issues VALUES('messenger', 3, 'XMPP accounts support', '', 'feature', 'A', 9, 7);

INSERT INTO issues VALUES('messenger', 4, 'Changable chat background', '', 'feature', 'C', 9, 6);
 
INSERT INTO issues VALUES('messenger', 5, 'VOIP calls', 'Add support of voip calls.', 'feature', 'A', 9, 7);
INSERT INTO issues VALUES('messenger', 6, 'VOIP calls interrupts', 'Constant interrupts with weak internet signal.', 'bug', 'B', 9, 7);

--bug_sources
INSERT INTO bug_sources VALUES('messenger', 2, 1);
INSERT INTO bug_sources VALUES('messenger', 6, 5);

--issue_statuses
INSERT INTO issue_statuses VALUES('messenger', 10, 1, 'open');
INSERT INTO issue_statuses VALUES('messenger', 10, 3, 'open');
INSERT INTO issue_statuses VALUES('messenger', 10, 5, 'open');

INSERT INTO issue_statuses VALUES('messenger', 11, 1, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 11, 2, 'open');
INSERT INTO issue_statuses VALUES('messenger', 11, 3, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 11, 4, 'open');
INSERT INTO issue_statuses VALUES('messenger', 11, 5, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 11, 6, 'open');

INSERT INTO issue_statuses VALUES('messenger', 12, 1, 'checked');
INSERT INTO issue_statuses VALUES('messenger', 12, 2, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 12, 3, 'open');
INSERT INTO issue_statuses VALUES('messenger', 12, 4, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 12, 5, 'checked');
INSERT INTO issue_statuses VALUES('messenger', 12, 6, 'closed');

INSERT INTO issue_statuses VALUES('messenger', 20, 2, 'checked');
INSERT INTO issue_statuses VALUES('messenger', 20, 3, 'closed');
INSERT INTO issue_statuses VALUES('messenger', 20, 4, 'open');
INSERT INTO issue_statuses VALUES('messenger', 20, 6, 'open');