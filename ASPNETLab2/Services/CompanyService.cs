using ASPNETLab2.Models;
using System.Xml.Serialization;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace ASPNETLab2.Services
{
    public class CompanyService
    {
        private readonly IConfiguration _configuration;

        public CompanyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Company GetCompanyWithMostEmployees()
        {
            var companies = new Dictionary<string, int>
            {
                { "Microsoft", _configuration.GetSection("Companies:Microsoft:Employees").Get<int>() },
                { "Apple", _configuration.GetSection("Companies:Apple:Employees").Get<int>() },
                { "Google", _configuration.GetSection("Companies:Google:Employees").Get<int>() }
            };

            var companyWithMostEmployees = new Company();
            var maxEmployees = 0;

            foreach (var company in companies)
            {
                if (company.Value > maxEmployees)
                {
                    maxEmployees = company.Value;
                    companyWithMostEmployees.Name = company.Key;
                    companyWithMostEmployees.CountOfEmployees = company.Value;
                }
            }

            return companyWithMostEmployees;
        }
    }
}
