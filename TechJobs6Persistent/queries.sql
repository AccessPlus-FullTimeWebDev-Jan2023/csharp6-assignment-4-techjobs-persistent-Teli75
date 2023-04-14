-- Capture your answer here for each "Test It With SQL" section of this assignment
    -- write each as comments


--Part 1: List the columns and their data types in the Jobs table.
--SELECT *
--FROM jobs;

--Part 2: Write a query to list the names of the employers in St. Louis City.
--SELECT name
--FROM employers
--WHERE location = "St. Louis City";


--Part 3: Write a query to return a list of the names of all skills that are attached to jobs in alphabetical order.
    --If a skill does not have a job listed, it should not be included in the results of this query.

--SELECT names
--FROM skills
--LEFT JOIN jobskill ON skills.id = jobskill.skillsid
--WHERE JobsId IS NOT NULL
--ORDER BY ASC ;

