private string NavegaDiretorioRecursivo(char nomeCedente, string chaveNfe, string path)
{
	string xmlString = @"";

	DirectoryInfo xmlDir = new DirectoryInfo(path);
	DirectoryInfo[] folders = xmlDir.GetDirectories();
	FileSystemInfo[] files = xmlDir.GetFileSystemInfos(chaveNfe + "*.xml");

	if (files.Length == 0 && folders.Length == 0)
	{
		return xmlString;
	}

	if (folders.Length != 0)
	{
		//foreach (DirectoryInfo f in folders.Where(x => x.Name.ToUpper()[0] == nomeCedente))
		foreach (DirectoryInfo f in folders)
		{
			xmlString = NavegaDiretorioRecursivo(nomeCedente, chaveNfe, path + f.Name + "/");
			if (!string.IsNullOrEmpty(xmlString))
			{
				return xmlString;
			}
		}
	}

	if (!string.IsNullOrEmpty(xmlString))
	{
		return xmlString;
	}

	if (files.Length != 0)
	{
		try
		{
			string pathArq = path + files[0].Name;
			using (StreamReader streamReader = new StreamReader(pathArq, Encoding.UTF8))
			{
				xmlString = streamReader.ReadToEnd();
			}
		}
		catch (Exception)
		{
			//Não encontrou
		}
	}

	return xmlString;
}