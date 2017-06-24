--Query #1
SELECT project, issue_uid, full_name, responsible_programmer AS emp_uid
FROM issue_all_info JOIN employees ON responsible_programmer = employee_uid
WHERE type = 'bug' AND status = 'open';

--Query #2
SELECT DISTINCT bug_sources.project, source_uid
FROM bug_sources LEFT JOIN last_statuses ON (last_statuses.project = bug_sources.project AND bug_uid = issue)
WHERE status <> 'checked';

WITH throw_f AS (
	SELECT DISTINCT bug_sources.project, source_uid
	FROM bug_sources LEFT JOIN last_statuses ON (last_statuses.project = bug_sources.project AND bug_uid = issue)
	WHERE status <> 'checked')
SELECT issues.project, issue_uid AS left_features, title
FROM throw_f RIGHT JOIN issues ON (throw_f.project = issues.project AND source_uid = issue_uid)
WHERE type = 'feature' AND source_uid IS NULL;

--Query #3
SELECT t1.project, t1.issue, t1.build, t1.status, t2.build, t2.status
FROM issue_statuses AS t1 FULL JOIN issue_statuses AS t2 ON t1.project = t2.project AND t1.issue = t2.issue
WHERE 
	t1.build = 20 AND t1.build > t2.build AND
	t1.status = 'open' AND t2.status = 'closed';

--Procedure
CREATE OR REPLACE FUNCTION predict_project_end(project_ varchar(128))
RETURNS date AS $$
DECLARE
	start date := (SELECT start FROM projects WHERE project_name = project_);
	time_spent int := current_date - start;
	bugs_closed int := (SELECT iss_done FROM project_total_issues WHERE type = 'bug' AND project = project_);
	bugs_left int := (SELECT bugs_undone FROM project_stat WHERE project = project_);
BEGIN
	IF bugs_closed <> 0 THEN
		RETURN current_date + bugs_left * (time_spent / bugs_closed);
	ELSE 
		RETURN start;
	END IF;
END; $$
LANGUAGE plpgsql;

SELECT predict_project_end('messenger');