using TopSortVisualizer.Input;

namespace TopSortVisualizer
{
	public partial class Form1 : Form
	{
		public const string ADJACENCY_LIST_PATH = "C:/console/TopSortVisualizer/AdjacencyList.txt";
		public const string COORDINATES_PATH = "C:/console/TopSortVisualizer/Coordinates.txt";

		private Dictionary<int, List<int>> _adjacencyList;
		private Dictionary<int, List<float>> _coordinates;
		private GraphDrawer _drawer;
		private Graphics _graphPanelGraphics;
		private Font _defaultFont;
		private Brush _defaultBrush;

		public Form1()
		{
			InitializeComponent();

			_graphPanelGraphics = GraphPanel.CreateGraphics();
			_defaultFont = new Font("Times New Roman", 13);
			_defaultBrush = new SolidBrush(Color.Black);
			_drawer = new GraphDrawer(_graphPanelGraphics, _defaultFont, _defaultBrush);
		}

		private void InitializeGraphButton_Click(object sender, EventArgs e)
		{
			ParseGraph();

			_drawer.DrawGraph(_adjacencyList, _coordinates);

			StartAnimationButton.Enabled = true;
			AnimationSpeedBar.Enabled = true;
			Result.Text = string.Empty;
			StepLabel.Text = string.Empty;
		}

		private void StartAnimationButton_Click(object sender, EventArgs e)
		{
			DisableInteractiveElements();

			InitializeLabels();

			Graph graph = new Graph(_adjacencyList, _coordinates, _drawer);

			graph.TopologicalSort(Result, StepLabel, AnimationSpeedBar.Value);

			InitializeGraphButton.Enabled = true;
			StepLabel.Text = "Result:";
		}

		private void ParseGraph()
		{
			FileReader fileReader = new FileReader();
			var adjacencyListFileContent = fileReader.ReadFileContent(ADJACENCY_LIST_PATH);
			var coordinatesFileContent = fileReader.ReadFileContent(COORDINATES_PATH);

			FileParser parser = new FileParser();
			_adjacencyList = parser.ParseAdjacencyList(adjacencyListFileContent);
			_coordinates = parser.ParseCoordinates(coordinatesFileContent);

			foreach (var item in _coordinates)
			{
				if (!_adjacencyList.ContainsKey(item.Key))
				{
					_adjacencyList.Add(item.Key, new List<int>());
				}
			}
		}

		private void InitializeLabels()
		{
			Result.Text = string.Empty;
			Result.Font = new Font("Arial", 14);
			StepLabel.Font = new Font("Arial", 16, FontStyle.Bold);
		}

		private void DisableInteractiveElements()
		{
			InitializeGraphButton.Enabled = false;
			StartAnimationButton.Enabled = false;
			AnimationSpeedBar.Enabled = false;
		}
	}
}