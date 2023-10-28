using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
	public class Graduate
	{
		public string FullName { get; set; }
		public string Faculty { get; set; }
		public string Department { get; set; }
		public string Specialty { get; set; }

		private DateTime _admissionDate;
		public DateTime AdmissionDate 
		{ 
			get { return _admissionDate; }
			set { _admissionDate = value; }
		}
		public string AdmissionDateAsString
		{
			get { return _admissionDate.ToString("yyyy"); }
			set 
			{ 
				if (DateTime.TryParseExact(value, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
				{
					_admissionDate = parsedDate;
				}
				else
				{
					_admissionDate = DateTime.MinValue; 
				}
			} 
		}

		private DateTime _graduationDate;
		public DateTime GraduationDate
		{
			get { return _graduationDate; }
			set { _graduationDate = value; }
		}
		public string GraduationDateAsString
		{
			get { return _graduationDate.ToString("yyyy"); }
			set
			{
				if (DateTime.TryParseExact(value, "yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
				{
					_graduationDate = parsedDate;
				}
				else
				{
					_graduationDate = DateTime.MinValue;
				}
			}
		}
		public List<Job> JobHistory { get; set; }

		public class Job
		{
			public string Position { get; set; }
			public string Employer { get; set; }
			public DateTime StartDate { get; set; }
			public DateTime EndDate { get; set; }
		}
	}
}
