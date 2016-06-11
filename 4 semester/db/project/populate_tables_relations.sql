--employees
INSERT INTO employees VALUES(1, 'Frank Gallagher', 'frank.gallagher@work.com', 'tester');
INSERT INTO employees VALUES(2, 'Fiona Gallagher', 'fiona.gallagher@work.com', 'programmer');
INSERT INTO employees VALUES(3, 'Mikky Milckovich', 'mikky.milckovich@work.com', 'tester');
INSERT INTO employees VALUES(4, 'Kevin Abraham', 'kevin@work.com', 'manager');
INSERT INTO employees VALUES(5, 'Veronica Jordan', 'ver.jordan@work.com', 'programmer');
INSERT INTO employees VALUES(6, 'Ien Mask', 'ien.mask@work.com', 'programmer');
INSERT INTO employees VALUES(7, 'Jimmy Lie', 'jim.lie@work.com', 'programmer');

--projects
INSERT INTO projects VALUES('internet-browser', '2016-01-10', '2017-01-10', 4);

--employees_projects
INSERT INTO employees_projects VALUES('internet-browser', 1, 100);
INSERT INTO employees_projects VALUES('internet-browser', 2, 100);
INSERT INTO employees_projects VALUES('internet-browser', 3, 70);
INSERT INTO employees_projects VALUES('internet-browser', 4, 100);
INSERT INTO employees_projects VALUES('internet-browser', 5, 50);
INSERT INTO employees_projects VALUES('internet-browser', 6, 70);
INSERT INTO employees_projects VALUES('internet-browser', 7, 30);

--builds
INSERT INTO builds VALUES('internet-browser', 11);
INSERT INTO builds VALUES('internet-browser', 12);
INSERT INTO builds VALUES('internet-browser', 13);
INSERT INTO builds VALUES('internet-browser', 20);

--issues
INSERT INTO issues VALUES('internet-browser', 1, 'Tabs support', '', 'feature', 'A', 1, 5);
INSERT INTO issues VALUES('internet-browser', 2, 'Tabs support', 'Program crashed with many tabs open (more than 50).', 'bug', 'B', 1, 5);

INSERT INTO issues VALUES('internet-browser', 3, 'Fullscreen mode', '', 'feature', 'B', 1, 5);
INSERT INTO issues VALUES('internet-browser', 4, 'Fullscreen mode - dualscreen', 'Add multimonitor support.', 'feature', 'C', 3, 7);
 
INSERT INTO issues VALUES('internet-browser', 5, 'Video-streaming', 'Add ability to watch videos.', 'feature', 'A', 3, 6);
INSERT INTO issues VALUES('internet-browser', 6, 'Video-streaming', 'When video size exceedes 1Gb, browser crashes.', 'bug', 'A', 3, 6);
INSERT INTO issues VALUES('internet-browser', 7, 'HD-video-streaming', 'When stream video quality is 1080, browser crashes with SIGFAULT.', 'bug', 'B', 3, 7);

INSERT INTO issues VALUES('internet-browser', 8, 'FTP-protocol', 'Add ftp protocol implementation.', 'feature', 'A', 1, 2);
INSERT INTO issues VALUES('internet-browser', 9, 'FTP-protocol', 'When depth of directories exceedes 10, browser fails.', 'bug', 'A', 1, 2);

--bug_sources
INSERT INTO bug_sources VALUES('internet-browser', 2, 1);
INSERT INTO bug_sources VALUES('internet-browser', 6, 5);
INSERT INTO bug_sources VALUES('internet-browser', 7, 5);
INSERT INTO bug_sources VALUES('internet-browser', 9, 8);

--issue_statuses
INSERT INTO issue_statuses VALUES('internet-browser', 11, 1, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 11, 5, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 11, 8, 'open');

INSERT INTO issue_statuses VALUES('internet-browser', 12, 1, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 2, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 3, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 4, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 5, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 6, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 7, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 12, 8, 'closed');

INSERT INTO issue_statuses VALUES('internet-browser', 13, 1, 'checked');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 2, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 3, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 4, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 5, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 6, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 7, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 8, 'checked');
INSERT INTO issue_statuses VALUES('internet-browser', 13, 9, 'open');

INSERT INTO issue_statuses VALUES('internet-browser', 20, 2, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 3, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 4, 'checked');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 5, 'checked');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 6, 'closed');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 7, 'open');
INSERT INTO issue_statuses VALUES('internet-browser', 20, 9, 'closed');