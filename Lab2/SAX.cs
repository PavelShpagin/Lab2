using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Lab2
{
	public class SAX : ISearch
	{
		public List<Graduate> SearchGraduates(string xmlFilePath, Graduate filterGraduate)
		{
			List<Graduate> result = new List<Graduate>();

			using (var reader = XmlReader.Create(xmlFilePath))
			{
				Graduate currentGraduate = new Graduate();
				currentGraduate.JobHistory = new List<Graduate.Job> { new Graduate.Job() };
				while (reader.Read())
				{
					switch (reader.NodeType) 
					{
						case XmlNodeType.Element:
							if (reader.HasAttributes)
							{
								switch (reader.Name) 
								{
									case "job_history":
										while (reader.MoveToNextAttribute())
										{
											switch (reader.Name)
											{
												case "position":
													currentGraduate.JobHistory[0].Position = reader.Value;
													break;

												case "employer":
													currentGraduate.JobHistory[0].Employer = reader.Value;
													break;

												case "start_date":
													currentGraduate.JobHistory[0].StartDate = DateTime.Parse(reader.Value);
													break;

												case "end_date":
													currentGraduate.JobHistory[0].EndDate = DateTime.Parse(reader.Value);
													break;
											}
										}
										break;

									case "graduate":
										while (reader.MoveToNextAttribute())
										{
											switch (reader.Name)
											{
												case "full_name":
													currentGraduate.FullName = reader.Value;
													break;

												case "faculty":
													currentGraduate.Faculty = reader.Value;
													break;

												case "department":
													currentGraduate.Department = reader.Value;
													break;

												case "specialty":
													currentGraduate.Specialty = reader.Value;
													break;

												case "admission_date":
													currentGraduate.AdmissionDate = DateTime.Parse(reader.Value);
													break;

												case "graduation_date":
													currentGraduate.GraduationDate = DateTime.Parse(reader.Value);
													break;
											}
										}
										break;
								}
							}

							break; 
						
						case XmlNodeType.EndElement:
							if (reader.Name == "graduate")
							{
								if ((currentGraduate.FullName == filterGraduate.FullName || filterGraduate.FullName == null) &&
									(currentGraduate.Faculty == filterGraduate.Faculty || filterGraduate.Faculty == null) &&
									(currentGraduate.Department == filterGraduate.Department || filterGraduate.Department == null) &&
									(currentGraduate.Specialty == filterGraduate.Specialty || filterGraduate.Specialty == null) &&
									(currentGraduate.AdmissionDate.Year == filterGraduate.AdmissionDate.Year || filterGraduate.AdmissionDate == DateTime.MinValue) &&
									(currentGraduate.GraduationDate.Year == filterGraduate.GraduationDate.Year || filterGraduate.GraduationDate == DateTime.MinValue))
								{
									result.Add(currentGraduate);
									currentGraduate = new Graduate();
									currentGraduate.JobHistory = new List<Graduate.Job> { new Graduate.Job() };
								}
							}
							break;
					}
				}
			}

			return result;
		}
	}
}
