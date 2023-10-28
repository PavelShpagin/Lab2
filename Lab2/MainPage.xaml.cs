using System.Net.Http;
using System.Xml;
using System.Xml.Xsl;

namespace Lab2
{
	public partial class MainPage : ContentPage
	{
		public List<string> FullNameOptions { get; set; }
		public List<string> FacultyOptions { get; set; }
		public List<string> DepartmentOptions { get; set; }
		public List<string> SpecialtyOptions { get; set; }
		public List<string> AdmissionDateOptions { get; set; }
		public List<string> GraduationDateOptions { get; set; }

		public Graduate FilterGraduate { get; set; }

		public ISearch Linq = new LINQ();

		public ISearch Dom = new DOM();

		public ISearch Sax = new SAX();

		public string XmlPath = "C:\\Users\\Pavel\\source\\repos\\Lab2\\Lab2\\XMLFile1.xml";

		public string XslPath = "C:\\Users\\Pavel\\source\\repos\\Lab2\\Lab2\\XSLTFile1.xslt";

		public string HtmlPath = "C:\\Users\\Pavel\\source\\repos\\Lab2\\Lab2\\HTMLFile1.html";

		public MainPage()
		{
			FilterGraduate = new Graduate();
			var graduates = Linq.SearchGraduates(XmlPath, FilterGraduate);
			FullNameOptions = new List<string>(graduates.Select(obj => obj.FullName).Distinct().ToList());
			FacultyOptions = new List<string>(graduates.Select(obj => obj.Faculty).Distinct().ToList());
			DepartmentOptions = new List<string>(graduates.Select(obj => obj.Department).Distinct().ToList());
			SpecialtyOptions = new List<string>(graduates.Select(obj => obj.Specialty).Distinct().ToList());
			AdmissionDateOptions = new List<string>(graduates.Select(obj => obj.AdmissionDate.Year.ToString()).Distinct().OrderBy(year => year).ToList());
			GraduationDateOptions = new List<string>(graduates.Select(obj => obj.GraduationDate.Year.ToString()).Distinct().OrderBy(year => year).ToList());
			
			BindingContext = this;

			InitializeComponent();
		}

		private void SearchButton_Clicked(object sender, EventArgs e)
		{
			var GraduateArray = new List<Graduate>();
			if (LINQButton.IsChecked)
			{
				GraduateArray = Linq.SearchGraduates(XmlPath, FilterGraduate);
			}
			else if (DOMButton.IsChecked)
			{
				GraduateArray = Dom.SearchGraduates(XmlPath, FilterGraduate);
			}
			else 
			{
				GraduateArray = Sax.SearchGraduates(XmlPath, FilterGraduate);
			}

			graduateCollectionView.ItemsSource = GraduateArray;
		}

		private void ClearButton_Clicked(object sender, EventArgs e)
		{
			FilterGraduate = new Graduate();

			fullNamePicker.SelectedItem = null;
			facultyPicker.SelectedItem = null;
			departmentPicker.SelectedItem = null;
			specialtyPicker.SelectedItem = null;
			admissionDatePicker.SelectedItem = null;
			graduationDatePicker.SelectedItem = null;

			graduateCollectionView.ItemsSource = null;
		}

		private void SaveHTMLButton_Clicked(object sender, EventArgs e)
		{
			XmlDocument xmlDoc = new XmlDocument();
			xmlDoc.Load(XmlPath);

			XslCompiledTransform xslt = new XslCompiledTransform();
			xslt.Load(XslPath);

			using (XmlWriter writer = XmlWriter.Create(HtmlPath))
			{
				xslt.Transform(xmlDoc, null, writer);
			}
		}
	}
}