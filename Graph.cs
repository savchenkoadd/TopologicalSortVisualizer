namespace TopSortVisualizer
{
	public class Graph
	{
		private int _verticesCount;
		private Dictionary<int, List<int>> _adjacencyList;
		private Dictionary<int, List<float>> _coordinates;
		private GraphDrawer _drawer;

		public Graph(Dictionary<int, List<int>> adjacencyList, Dictionary<int, List<float>> coordinates, GraphDrawer graphDrawer)
		{
			_adjacencyList = adjacencyList;
			_coordinates = coordinates;
			_verticesCount = adjacencyList.Count;
			_drawer = graphDrawer;
		}

		public List<int> TopologicalSort(Label sequenceLabel, Label stepLabel, int animationSpeedInMs)
		{
			Dictionary<int, List<int>> animationList = _adjacencyList;

			List<int> result = new List<int>();
			var inDegrees = InitializeInDegrees();
			Queue<int> queue = InitializeQueue(inDegrees);
			int step = 1;

			int visitedCount = 0;

			while (queue.Count > 0)
			{
				int currentVertex = queue.Dequeue();
				result.Add(currentVertex);

				foreach (int neighbour in _adjacencyList[currentVertex])
				{
					inDegrees[neighbour]--;

					if (inDegrees[neighbour] == 0)
					{
						queue.Enqueue(neighbour);
					}
				}

				visitedCount++;

				UpdateGraphView(stepLabel, sequenceLabel, animationSpeedInMs, step, currentVertex, animationList); 

				animationList.Remove(currentVertex);
				step++;
			}

			CheckForCycles(visitedCount);

			return result;
		}

		private void CheckForCycles(int visitedCount)
		{
			if (visitedCount != _verticesCount)
			{
				throw new ArgumentException("There is a cycle in the graph.");
			}
		}

		private void UpdateGraphView(Label stepLabel, Label sequenceLabel, int animationSpeedInMs, int step, int currentVertex, Dictionary<int, List<int>> animationList)
		{
			_drawer.DrawGraph(animationList, _coordinates);

			stepLabel.Text = $"Step {step}:";
			sequenceLabel.Text += $"{currentVertex} ";
			Application.DoEvents();
			Thread.Sleep(animationSpeedInMs);
			
			_drawer.Graphics.Clear(Control.DefaultBackColor);
		}

		private Dictionary<int, int> InitializeInDegrees()
		{
			Dictionary<int, int> inDegrees = new Dictionary<int, int>();

			foreach (var neighbors in _adjacencyList)
			{
				foreach (int neighbour in neighbors.Value)
				{
					if (!inDegrees.ContainsKey(neighbour))
					{
						inDegrees.Add(neighbour, 0);
					}
					inDegrees[neighbour]++;
				}
			}

			return inDegrees;
		}

		private Queue<int> InitializeQueue(Dictionary<int, int> inDegrees)
		{
			Queue<int> queue = new Queue<int>();

			foreach (var vertex in _adjacencyList.Keys)
			{
				if (!inDegrees.ContainsKey(vertex) || inDegrees[vertex] == 0)
				{
					queue.Enqueue(vertex);
				}
			}

			return queue;
		}
	}
}
