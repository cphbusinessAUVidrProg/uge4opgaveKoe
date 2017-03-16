using System;
using System.Collections.Generic;

namespace uge4opgavekoe
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Maze maze = new Maze("../../maze2.txt");

			Stack<Node> s = new Stack<Node>();
			s.Push(maze.StartNode);
			while (s.Count > 0)
			{
				Node next = s.Peek();
				Node neighbour;
				if ((neighbour = maze.UnvisitedNeighbour(next)) != null)
				{
					if (maze.isExit(neighbour))
					{
						while (s.Count > 1) maze.Mark(s.Pop(), '*');
						Console.WriteLine("Solved: ");
						Console.WriteLine(maze.ToString());
						return; // Hurra.
					}
					maze.MarkVisited(neighbour);
					s.Push(neighbour);
				}
				else
				{
					s.Pop();
				}
			}
			Console.WriteLine("I'm lost");
			Console.WriteLine(maze.ToString());
		}


}

	class Node
	{
		public int Row { get; set; }
		public int Col { get; set; }
		public Node(int c, int r)
		{
			Col = c; 
			Row = r;
		}
	}
}
