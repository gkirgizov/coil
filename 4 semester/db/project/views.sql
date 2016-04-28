--View #1

CREATE OR REPLACE VIEW last_statuses AS
WITH last_builds AS (
	SELECT project, MAX(version) AS build_version
	FROM builds
	GROUP BY project
)
SELECT last_builds.project, build, issue, status
FROM issue_statuses INNER JOIN last_builds ON (build = build_version AND issue_statuses.project = last_builds.project);

--View #2

CREATE OR REPLACE VIEW issue_all_info AS
SELECT issues.project, issue_uid, type, priority, status, title, description, responsible_tester, responsible_programmer
FROM issues LEFT JOIN last_statuses ON (issue_uid = issue AND issues.project = last_statuses.project);

CREATE OR REPLACE VIEW project_total_issues AS
WITH total AS (
	SELECT project, type, COUNT(type) as iss_total
	FROM issue_all_info
	GROUP BY project, type
)
SELECT total.project, total.type, iss_total, coalesce(iss_done, 0) as iss_done
FROM total LEFT JOIN (
	SELECT project, type, COUNT(type) as iss_done
	FROM issue_all_info
	WHERE status = 'checked' OR status IS NULL
	GROUP BY project, type)
	AS done ON (total.project = done.project AND total.type = done.type);

CREATE OR REPLACE VIEW project_stat AS 
WITH bugs_stat AS (
	SELECT project, (iss_total - iss_done) as bugs_undone
	FROM project_total_issues
	WHERE type = 'bug'
)
SELECT bugs_stat.project, bugs_undone, features_done
FROM bugs_stat JOIN (
	SELECT project, CAST(iss_done * 100 / iss_total AS numeric(4, 1)) AS features_done
	FROM project_total_issues
	WHERE type = 'feature'
) AS features_stat ON bugs_stat.project = features_stat.project;

--View #3

CREATE OR REPLACE VIEW emp_stat AS
WITH emp_stat AS (
	SELECT responsible_programmer AS programmer, COUNT(*) AS solved
	FROM issue_all_info
	WHERE type = 'bug' AND (status = 'checked' OR status IS NULL)
	GROUP BY responsible_programmer
)
SELECT programmer, solved
FROM emp_stat
WHERE solved >= (SELECT AVG(solved) FROM emp_stat);

