﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
	public interface ISearch
	{
		List<Graduate> SearchGraduates(string xmlFilePath, Graduate filterGraduate);
	}
}
