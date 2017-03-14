using System;
using System.Collections.Generic;

namespace uge4opgavekoe
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			char[,] maze;
			// read maze from file

			Stack<Node> s = new Stack<Node>();
			s.Push(new Node(0, 1) );
			while ( s.Count > 0)
			{
				Node next = s.Peek();
				Node neighbour;
				if (neighbour = UnvisitedNeighbours(next) != null)
				{
					if (isExit(neighbour) {
						return "Hurra";
					}
					maze[neighbour.Row, neighbour.Col] = ".";    
					s.Push(neighbour);
				}
				else
				{
					s.Pop();
				}
			}
		}
	}

	class Node
	{
		public int Row { get; set;}
		public int Col { get; set;}
		public Node(int r, int c)
		{
			row = r;
			col = c;
		}
	}
}
