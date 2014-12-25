using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Chronocourses.Services
{
    class GridUtilities
    {
        private gridElement[][] _grid;
        public GridUtilities(Model.Shop shop)
        {
            _grid = new gridElement[shop.Width][];

            for (int i = 0; i < shop.Width; i++)
            {
                _grid[i] = new gridElement[shop.Height];
                for (int j = 0; j < shop.Height; j++)
                {
                    _grid[i][j] = new gridElement(false, false);
                }
            }
            foreach (Model.Entity ent in shop.Entity)
            {
                _grid[ent.PositionX][ent.PositionY].container = (ent.Container);
            }
        }

        public class gridElement
        {
            public bool container;
            public bool visited;
            public gridElement(bool container, bool visited)
            {
                this.container = container;
                this.visited = visited;
            }
        }

        public class AStarNode
        {
            public int[] coord { get; set; }
            public AStarNode previous;
            public int cost;
            public AStarNode(int[] coord, AStarNode previous)
            {
                if (previous != null)
                    this.cost = previous.cost + 1;
                this.coord = coord;
                this.previous = previous;
            }
        }

        internal List<int[]> getShortestPath(int[] startPos, int[] end)
        {
            reinitializeVisits();
            return getShortestPath(startPos, end, null);
        }

        private void reinitializeVisits()
        {
            for (int i = 0; i < _grid.Length; i++)
            {
                for (int j = 0; j < _grid[0].Length; j++)
                {
                    _grid[i][j].visited = false;
                }
            }
        }

        internal List<int[]> getShortestPath(int[] startPos, int[] end, AStarNode previous)
        {
            if (!areThoseCoordinateEquals(startPos, end))
            {
                AStarNode first = new AStarNode(startPos, previous);
                int nb_nghb = getNeighboursNumber(startPos);
                int bestCost = estimateCost(startPos, end);
                List<AStarNode> nodesToBeAddedToClosedList = new List<AStarNode>();
                for (int i = 0; i < 4; i++) //Manhattan's NeighborHood
                {
                    AStarNode curr_nghb = new AStarNode(getNeighbor(startPos, i), first);
                    if (curr_nghb.coord != null)
                    {
                        if (areThoseCoordinateEquals(curr_nghb.coord, end))
                        {
                            return recreatePath(curr_nghb);
                        }
                        else if (!isContainer(curr_nghb.coord) && !isVisited(curr_nghb.coord))
                        {
                            int currCost = estimateCost(curr_nghb.coord, end);
                            if (currCost < bestCost)
                            {
                                nodesToBeAddedToClosedList.Clear();
                                bestCost = currCost;
                            }
                            if (currCost <= bestCost)
                            {
                                nodesToBeAddedToClosedList.Add(curr_nghb);
                                _grid[curr_nghb.coord[0]][curr_nghb.coord[1]].visited = true;
                            }
                        }
                    }
                    else
                    {
                        nb_nghb++;
                    }
                }
                List<int[]> final = new List<int[]>();
                foreach (AStarNode node in nodesToBeAddedToClosedList)
                {
                    int[] test = { 0, 1 };
                    List<int[]> curr = getShortestPath(node.coord, end, first);
                    if (curr != null)
                    {
                        if ((final.Count > curr.Count || final.Count == 0) && curr.Count != 0)
                            final = curr;
                    }
                    else
                    {
                        return recreatePath(node);
                    }
                }
                return final;
            }
            else
            {
                return null;
            }
        }

        private bool isVisited(int[] p)
        {
            return _grid[p[0]][p[1]].visited;
        }

        private bool areThoseCoordinateEquals(int[] c1, int[] c2)
        {
            return ((c1[0] == c2[0]) && (c1[1] == c2[1]));
        }

        private List<int[]> recreatePath(AStarNode endNode)
        {
            List<int[]> retList = new List<int[]>();
            retList.Add(endNode.coord);
            while (endNode.previous != null)
            {
                retList.Add(endNode.previous.coord);
                endNode = endNode.previous;
            }
            return retList;
        }

        internal int estimateCost(int[] coord, int[] end)
        {
            return (Math.Abs((end[0] - coord[0])) + Math.Abs((end[1] - coord[1])));
        }

        internal int getNeighboursNumber(int[] coord)
        {
            int cnt = 0;
            for (int i = 0; i < 4; i++)
            {
                if (getNeighbor(coord, i) != null)
                {
                    cnt++;
                }
            }
            return cnt;
        }

        internal bool isContainer(int[] coord)
        {
            return _grid[coord[0]][coord[1]].container;
        }

        internal int[] getNeighbor(int[] coord, int i)
        {
            int modifX = 0;
            int modifY = 0;
            if (i < 2)
            {
                modifX = (i == 0) ? -1 : 1;
            }
            else
            {
                modifY = (i == 2) ? -1 : 1;
            }
            try
            {
                int[] ret = { coord[0] + modifX, coord[1] + modifY };
                bool test = _grid[coord[0] + modifX][coord[1] + modifY].container;
                return ret;
            }
            catch (IndexOutOfRangeException e)
            {
                String s = e.Message;
                return null;
            }
        }
    }
}