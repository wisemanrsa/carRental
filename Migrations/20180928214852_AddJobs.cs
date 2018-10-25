using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ngxadminstarterkit.Migrations
{
    public partial class AddJobs : Migration
    {
        private Dictionary<string, string> GetJobs()
        {
            var jobs = new Dictionary<string, string>();

            jobs.Add("SP", "Supervisor");
            jobs.Add("DO", "Desk Officer");

            return jobs;
        }
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var jobs = GetJobs();

            foreach(var job in jobs)
                migrationBuilder.Sql($"INSERT INTO Job(code, Description) VALUES('{job.Key}', '{job.Value}')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            var jobs = GetJobs();

            foreach(var job in jobs)
                migrationBuilder.Sql($"DELETE FROM Job WHERE Code = '{job.Key}'");
        }
    }
}
