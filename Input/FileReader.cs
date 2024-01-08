namespace TopSortVisualizer.Input
{
	public class FileReader
	{
		public string ReadFileContent(string filePath)
		{
			using (StreamReader reader = new StreamReader(filePath))
			{
				return reader.ReadToEnd();
			}
		}
	}
}
