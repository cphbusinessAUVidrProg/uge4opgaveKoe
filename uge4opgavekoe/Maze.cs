using System;
using System.IO;
using System.Text;

namespace uge4opgavekoe
{
	public class Maze
	{
		char[,] maze;

		public Maze(string filename)
		{
			ReadMaze(filename);
		}

		internal Node StartNode
		{
			get { return new Node(0, 1); }
		}

		internal void MarkVisited(Node node)
		{
			maze [ node.Col, node.Row ] = '.';
		}

		internal void Mark(Node node, char c)
		{
			maze[node.Col, node.Row] = c;
		}

		internal Node UnvisitedNeighbour(Node next)
		{
			if ( isOpen( next.Col + 1, next.Row ) ) return new Node(next.Col + 1, next.Row);
			if ( isOpen(  next.Col, next.Row + 1 ) ) return new Node(next.Col, next.Row + 1);
			if ( isOpen( next.Col - 1, next.Row ) ) return new Node(next.Col - 1, next.Row);
			if ( isOpen( next.Col, next.Row - 1 ) ) return new Node(next.Col, next.Row - 1);
			return null;
		}

		private bool isOpen(int col, int row)
		{	if (col < 0 || col >= maze.GetLength(0) || row < 0 || row >= maze.GetLength(1))
				return false;
			char c = maze[col, row];
			return c == ' ' || c == 'E';
		}

		internal bool isExit(Node node)
		{
			return maze[node.Col, node.Row] == 'E';
		}

		private void ReadMaze(string fileLocation)
		{
			FileStream fs = new FileStream(fileLocation, FileMode.Open, FileAccess.Read);

			using (StreamReader streamReader = new StreamReader(fs, Encoding.UTF8))
			{
				string line = String.Empty;
				if ((line = streamReader.ReadLine()) != null)
				{
					string[] sizes = line.Split('x');
					int width = 0, height = 0;
					if (sizes.Length == 2 & int.TryParse(sizes[0], out width) && int.TryParse(sizes[1], out height))
					{
						maze = new char[width, height];
						int lineNumber = 0;
						while ((line = streamReader.ReadLine()) != null)
						{
							for (int col = 0; col < line.Length; col++)
							{
								maze[col, lineNumber] = (char)line[col];
							}
							lineNumber++;
						}
					}
				}
			}
		}

		override public string ToString()
		{
			var sb = new StringBuilder();
			sb.AppendLine("Maze: " + maze.GetLength(0) + " x " + maze.GetLength(1));
			for (int row = 0; row < maze.GetLength(0); row++)
			{
				for (int col = 0; col < maze.GetLength(1); col++)
				{
					sb.Append(maze[col, row]);
				}
				sb.AppendLine();
			}
			return sb.ToString();
		}

		public void PrintMaze()
		{
			Console.WriteLine(this.ToString());
		}
	}
}
