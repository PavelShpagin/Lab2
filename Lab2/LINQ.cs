using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Lab2
{
	public class LINQ : ISearch
	{
		public List<Graduate> SearchGraduates(string xmlFilePath, Graduate filterGraduate)
		{
			XDocument xmlDoc = XDocument.Load(xmlFilePath);
			var result = (from graduate in xmlDoc.Descendants("graduate") where
						((graduate.Attribute("full_name").Value.Equals(filterGraduate.FullName) || filterGraduate.FullName == null) &&
						(graduate.Attribute("faculty").Value.Equals(filterGraduate.Faculty) || filterGraduate.Faculty == null) &&
						(graduate.Attribute("department").Value.Equals(filterGraduate.Department) || filterGraduate.Department == null) &&
						(graduate.Attribute("specialty").Value.Equals(filterGraduate.Specialty) || filterGraduate.Specialty == null) &&
						((((DateTime)graduate.Attribute("admission_date")).Year == filterGraduate.AdmissionDate.Year) || filterGraduate.AdmissionDate == DateTime.MinValue) &&
						((((DateTime)graduate.Attribute("graduation_date")).Year == filterGraduate.GraduationDate.Year) || filterGraduate.GraduationDate == DateTime.MinValue))
						select new Graduate {
							FullName = (string)graduate.Attribute("full_name"),
							Faculty = (string)graduate.Attribute("faculty"),
							Department = (string)graduate.Attribute("department"),
							Specialty = (string)graduate.Attribute("specialty"),
							AdmissionDate = (DateTime)graduate.Attribute("admission_date"),
							GraduationDate = (DateTime)graduate.Attribute("graduation_date"),
							JobHistory = (from job in graduate.Elements("job_history")
							 select new Graduate.Job
							 {
								 Position = (string)job.Attribute("position"),
								 Employer = (string)job.Attribute("employer"),
								 StartDate = (DateTime)job.Attribute("start_date"),
								 EndDate = (DateTime)job.Attribute("end_date")
							 }).ToList()
						}
					).ToList();

			return result;
		}

	}
}
