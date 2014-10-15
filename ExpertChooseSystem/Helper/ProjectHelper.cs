using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExpertChooseSystem.Model;

namespace ExpertChooseSystem.Helper
{
    public class ProjectHelper
    {
        public IList<Project> GetProjects(int count)
        {
            int projectCount = 0;
            var projects = new List<Project>() { };
            while (projectCount < count)
            {
                projectCount++;
                projects.Add(NexProject());
            }
            return projects;
        }

        public Project NexProject()
        {
            RandomHelper randomHelper = RandomHelper.GetHelper();

            Project project = Project.Craete();
            project.Field = randomHelper.NextField();
            project.Name = "Project#" + Project.Count;
            project.MasterName = "Master";

            return project;
        }
    }
}
