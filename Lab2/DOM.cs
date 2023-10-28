using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace Lab2
{
	public class DOM : ISearch
	{
		public List<Graduate> SearchGraduates(string xmlFilePath, Graduate filterGraduate)
		{
			List<Graduate> result = new List<Graduate>();
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(xmlFilePath);

			XmlNodeList graduateNodes = xmlDoc.SelectNodes("//graduate");

			foreach (XmlNode graduateNode in graduateNodes)
			{
				if((graduateNode.Attributes["full_name"].Value.Equals(filterGraduate.FullName) || filterGraduate.FullName == null) &&
					(graduateNode.Attributes["faculty"].Value.Equals(filterGraduate.Faculty) || filterGraduate.Faculty == null) &&
					(graduateNode.Attributes["department"].Value.Equals(filterGraduate.Department) || filterGraduate.Department == null) &&
					(graduateNode.Attributes["specialty"].Value.Equals(filterGraduate.Specialty) || filterGraduate.Specialty == null) &&
					((Int32.Parse(graduateNode.Attributes["admission_date"].Value.Split('-')[0]) == filterGraduate.AdmissionDate.Year) || filterGraduate.AdmissionDate == DateTime.MinValue) &&
					((Int32.Parse(graduateNode.Attributes["graduation_date"].Value.Split('-')[0]) == filterGraduate.GraduationDate.Year) || filterGraduate.GraduationDate == DateTime.MinValue))
				{
					Graduate graduate = new Graduate
					{
						FullName = graduateNode.Attributes["full_name"].Value,
						Faculty = graduateNode.Attributes["faculty"].Value,
						Department = graduateNode.Attributes["department"].Value,
						Specialty = graduateNode.Attributes["specialty"].Value,
						AdmissionDate = DateTime.Parse(graduateNode.Attributes["admission_date"].Value),
						GraduationDate = DateTime.Parse(graduateNode.Attributes["graduation_date"].Value),
						JobHistory = new List<Graduate.Job>()
					};

					XmlNodeList jobHistoryNodes = graduateNode.SelectNodes("//job_history");

					foreach (XmlNode jobNode in jobHistoryNodes)
					{
						Graduate.Job job = new Graduate.Job
						{
							Position = jobNode.Attributes["position"].Value,
							Employer = jobNode.Attributes["employer"].Value,
							StartDate = DateTime.Parse(jobNode.Attributes["start_date"].Value),
							EndDate = DateTime.Parse(jobNode.Attributes["end_date"].Value)
						};

						graduate.JobHistory.Add(job);
					}

					result.Add(graduate);
				}
			}

			return result;
		}
	}
}
