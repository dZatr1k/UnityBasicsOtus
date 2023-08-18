using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonGame
{
    public static class PathFinder
    {
        public static List<Vector2> FindPath(Map map, Vector2 start, Vector2 end)
        {
            List<Cell> openList = new List<Cell>();
            HashSet<Cell> closedSet = new HashSet<Cell>();
            Dictionary<Cell, Cell> cameFrom = new Dictionary<Cell, Cell>();
            Dictionary<Cell, int> gScore = new Dictionary<Cell, int>();
            Dictionary<Cell, int> fScore = new Dictionary<Cell, int>();

            var endCell = map.Cell[end.X, end.Y];
            openList.Add(map.Cell[start.X, start.Y]);
            gScore[map.Cell[start.X, start.Y]] = 0;
            fScore[map.Cell[start.X, start.Y]] = CalculateHeuristic(map.Cell[start.X, start.Y], map.Cell[end.X, end.Y]);
            
            while(openList.Count > 0)
            {
                Cell currentCell = GetLowestFScoreCell(openList, fScore);

                if (currentCell == endCell)
                    return ReconstructPath(cameFrom, currentCell);

                openList.Remove(currentCell);
                closedSet.Add(currentCell);

                foreach (Cell neighbor in GetNeighbors(map, currentCell))
                {
                    if (!neighbor.IsWalkable || closedSet.Contains(neighbor))
                        continue;

                    int tentativeGScore = gScore[currentCell] + neighbor.Cost;
                    if (!gScore.ContainsKey(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = currentCell;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + CalculateHeuristic(neighbor, endCell);

                        if (!openList.Contains(neighbor))
                            openList.Add(neighbor);
                    }
                }
            }
            return null;
        }

        private static Cell GetLowestFScoreCell(List<Cell> openSet, Dictionary<Cell, int> fScore)
        {
            int lowestScore = int.MaxValue;
            Cell lowestCell = null;

            foreach (Cell cell in openSet)
            {
                if (fScore.ContainsKey(cell) && fScore[cell] < lowestScore)
                {
                    lowestScore = fScore[cell];
                    lowestCell = cell;
                }
            }

            return lowestCell;
        }

        private static int CalculateHeuristic(Cell cell, Cell target)
        {
            return Math.Abs(cell.CellPosition.X - target.CellPosition.X) + Math.Abs(cell.CellPosition.Y - target.CellPosition.Y);
        }

        private static List<Vector2> ReconstructPath(Dictionary<Cell, Cell> cameFrom, Cell currentCell)
        {
            List<Vector2> path = new List<Vector2> { currentCell.CellPosition };

            while (cameFrom.ContainsKey(currentCell))
            {
                currentCell = cameFrom[currentCell];
                path.Insert(0, currentCell.CellPosition);
            }

            return path;
        }

        private static List<Cell> GetNeighbors(Map map, Cell cell)
        {
            List<Cell> neighbors = new List<Cell>();
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int i = 0; i < 4; i++)
            {
                int newX = cell.CellPosition.X + dx[i];
                int newY = cell.CellPosition.Y + dy[i];

                if (newX >= 0 && newX < map.Cell.GetLength(0) && newY >= 0 && newY < map.Cell.GetLength(1))
                {
                    neighbors.Add(map.Cell[newX, newY]);
                }
            }

            return neighbors;
        }
    }
}
