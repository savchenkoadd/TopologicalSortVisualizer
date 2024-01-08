using System.Drawing.Drawing2D;

namespace TopSortVisualizer
{
	public class GraphDrawer
	{
		private Graphics _graphics;
		private Font _font;
		private Brush _brush;
		private float _circleRadius;

		public Graphics Graphics => _graphics;

		public GraphDrawer(Graphics graphics, Font font, Brush brush, float circleRadius = 20)
		{
			_graphics = graphics;
			_font = font;
			_brush = brush;
			_circleRadius = circleRadius;
		}

		public void DrawGraph(Dictionary<int, List<int>> adjacencyList, Dictionary<int, List<float>> coordinates)
		{
			foreach (var vertexId in adjacencyList.Keys)
			{
				if (coordinates.TryGetValue(vertexId, out var vertexCoordinates))
				{
					DrawVertex(vertexId, vertexCoordinates);

					if (adjacencyList.TryGetValue(vertexId, out var neighbors))
					{
						foreach (var neighbor in neighbors)
						{
							DrawEdge(coordinates, vertexCoordinates, neighbor);
						}
					}
				}
			}
		}

		private void DrawVertex(int vertexId, List<float> vertexCoordinates)
		{
			float vertexX = vertexCoordinates[0];
			float vertexY = vertexCoordinates[1];

			_graphics.DrawEllipse(new Pen(Color.Black, 1.8f), vertexX - _circleRadius, vertexY - _circleRadius, 2 * _circleRadius, 2 * _circleRadius);

			string vertexIdStr = vertexId.ToString();
			SizeF textSize = _graphics.MeasureString(vertexIdStr, _font);

			var textPosition = CalculateTextPosition(vertexX, vertexY, textSize);

			_graphics.DrawString(vertexIdStr, _font, _brush, textPosition.X, textPosition.Y);
		}

		private void DrawEdge(Dictionary<int, List<float>> coordinates, List<float> vertexCoordinates, int neighbor)
		{
			if (coordinates.TryGetValue(neighbor, out var neighborCoordinates))
			{
				float vertexX = vertexCoordinates[0];
				float vertexY = vertexCoordinates[1];
				float neighborX = neighborCoordinates[0];
				float neighborY = neighborCoordinates[1];

				DrawArrow(Color.Black, new PointF(vertexX, vertexY), new PointF(neighborX, neighborY));
			}
		}

		private void DrawArrow(Color color, PointF start, PointF end)
		{
			float penWidth = 1.5f;
			Pen pen = new Pen(color, penWidth);
			AdjustableArrowCap arrowCap = new AdjustableArrowCap(4, 7);
			pen.CustomEndCap = arrowCap;

			PointF startPoint = CalculateArrowPoint(start, end, _circleRadius);
			PointF endPoint = CalculateArrowPoint(end, start, _circleRadius);

			_graphics.DrawLine(pen, startPoint, endPoint);
		}

		private PointF CalculateArrowPoint(PointF point, PointF oppositePoint, float radius)
		{
			double angle = Math.Atan2(oppositePoint.Y - point.Y, oppositePoint.X - point.X);

			PointF resultPoint = new PointF(point.X + (float)(radius * Math.Cos(angle)),
										   point.Y + (float)(radius * Math.Sin(angle)));

			return resultPoint;
		}

		private PointF CalculateTextPosition(float vertexX, float vertexY, SizeF textSize)
		{
			float textX = vertexX - textSize.Width / 2;
			float textY = vertexY - textSize.Height / 2;

			return new PointF(textX, textY);
		}
	}
}
