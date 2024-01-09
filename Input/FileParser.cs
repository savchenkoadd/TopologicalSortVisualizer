namespace TopSortVisualizer.Input
{
	public class FileParser
	{
		public Dictionary<int, List<int>> ParseAdjacencyList(string fileContent)
		{
			var adjacencyList = new Dictionary<int, List<int>>();

			string[] lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

			for (int j = 0; j < lines.Length; j++)
			{
				string line = lines[j];
				string[] tokens = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

				if (tokens.Length < 2)
				{
					throw new ArgumentException("Invalid adjacency list input: At least two values are required (vertex and at least one neighbor).");
				}

				int vertex = int.Parse(tokens[0]);

				var to = new int[tokens.Length - 1];

				for (int i = 0; i < to.Length; i++)
				{
					to[i] = int.Parse(tokens[i + 1]);
				}

				adjacencyList.Add(vertex, to.ToList());
			}

			return adjacencyList;
		}

		public Dictionary<int, List<float>> ParseCoordinates(string fileContent)
		{
			Dictionary<int, List<float>> result = new Dictionary<int, List<float>>();
			string[] lines = fileContent.Split('\n', StringSplitOptions.RemoveEmptyEntries);

			List<int> addedVertices = new List<int>();

			foreach (var item in lines)
			{
				string[] rowContent = item.Split(' ');

				if (rowContent.Length < 3)
				{
					throw new ArgumentException("Invalid coordinates input: Each line must contain at least three values (vertex, x, y).");
				}

				int currentVertex = ParseInteger(rowContent[0]);

				if (addedVertices.Contains(currentVertex))
				{
					throw new ArgumentException("Duplicate vertex found. The same vertex has already been added.");
				}

				float x = ParseFloat(rowContent[1]);
				float y = ParseFloat(rowContent[2]);

				if (x < 0 || y < 0)
				{
					throw new ArgumentOutOfRangeException("Coordinates cannot be less than zero.");
				}

				List<float> coordinates = new List<float>()
				{
					x, y
				};

				result.Add(currentVertex, coordinates);
				addedVertices.Add(currentVertex);
			}

			return result;
		}

		private int ParseInteger(string value)
		{
			if (int.TryParse(value, out int result))
			{
				return result;
			}

			throw new ArgumentException($"Failed to parse integer value: {value}");
		}

		private float ParseFloat(string value)
		{
			if (float.TryParse(value, out float result))
			{
				return result;
			}
			throw new ArgumentException($"Failed to parse float value: {value}");
		}
	}
}
