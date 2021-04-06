using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ComponentPathfinding
{
	private static int DISTANCE_COST = 10;

	private List<ShipComponent> traversalComponents;
	private List<ComponentPathNode> traversalNodes;

	private List<ComponentPathNode> openList;
	private List<ComponentPathNode> closeList;

	public List<ComponentPathNode> FindPath(List<ShipComponent> shipComponents,ShipComponent start, ShipComponent end)
	{
		traversalComponents = shipComponents;
		traversalNodes = traversalComponents.Select(x => new ComponentPathNode(x)).ToList();

		ComponentPathNode startNode = new ComponentPathNode(start);
		ComponentPathNode endNode = new ComponentPathNode(end);
		traversalNodes.Add(endNode);
		openList = new List<ComponentPathNode>() { startNode };
		closeList = new List<ComponentPathNode>();

		foreach (ComponentPathNode node in traversalNodes)
		{
			node.gCost = int.MaxValue;
			node.CalculateFCost();
			node.lastNode = null;
		}

		startNode.gCost = 0;
		startNode.hCost = CalculateDistance(startNode, endNode);
		startNode.CalculateFCost();

		while (openList.Count > 0)
		{
			ComponentPathNode currentNode = GetLowestFNode(openList);
			if (currentNode.localPosition == endNode.localPosition)
			{
				return Calculatepath(currentNode);
			}
			openList.Remove(currentNode);
			closeList.Add(currentNode);

			List<ComponentPathNode> neighbourNodes = GetSurroundingComponents(currentNode);
			foreach (ComponentPathNode neighbourNode in neighbourNodes)
			{
				if (closeList.Contains(neighbourNode))
				{
					continue;
				}
				int testcost = currentNode.gCost + CalculateDistance(currentNode, neighbourNode);
				if (testcost < neighbourNode.gCost)
				{
					neighbourNode.lastNode = currentNode;
					neighbourNode.gCost = testcost;
					neighbourNode.hCost = CalculateDistance(neighbourNode, endNode);
					neighbourNode.CalculateFCost();

					if (!openList.Contains(neighbourNode))
					{
						openList.Add(neighbourNode);
					}
				}
			}
		}
		return null;



	}



	private List<ComponentPathNode> Calculatepath(ComponentPathNode endNode)
	{
		List<ComponentPathNode> path = new List<ComponentPathNode>();
		path.Add(endNode);
		ComponentPathNode currentNode = endNode.lastNode;
		while (currentNode.lastNode != null)
		{
			path.Add(currentNode);
			currentNode = currentNode.lastNode;
		}
		path.Reverse();
		return path;
	}

	private ComponentPathNode GetLowestFNode(List<ComponentPathNode> componentPaths)
	{
		return componentPaths.OrderBy(x => x.fCost).FirstOrDefault();
	}

	private int CalculateDistance(ComponentPathNode a, ComponentPathNode b)
	{
		int xDistance = Mathf.Abs(a.x - b.x) * DISTANCE_COST;
		int yDistance = Mathf.Abs(a.y - b.y) * DISTANCE_COST;
		int zDistance = Mathf.Abs(a.z - b.z) * DISTANCE_COST;
		return xDistance + yDistance + zDistance;
	}

	private List<ComponentPathNode> GetSurroundingComponents(ComponentPathNode shipComponent)
	{
		List<ComponentPathNode> neighbourNodes = new List<ComponentPathNode>();
		Vector3 localposition = shipComponent.localPosition;
		AddSurroundingComponentToList(neighbourNodes, localposition + Vector3.forward);
		AddSurroundingComponentToList(neighbourNodes, localposition - Vector3.forward);
		AddSurroundingComponentToList(neighbourNodes, localposition + Vector3.right);
		AddSurroundingComponentToList(neighbourNodes, localposition - Vector3.right);
		AddSurroundingComponentToList(neighbourNodes, localposition + Vector3.up);
		AddSurroundingComponentToList(neighbourNodes, localposition - Vector3.up);
		return neighbourNodes;
	}

	private void AddSurroundingComponentToList(List<ComponentPathNode> shipComponents, Vector3 testPosition)
	{
		ComponentPathNode forward = GetComponentAtPosition(testPosition);
		if (forward != null)
		{
			shipComponents.Add(forward);
		}
	}

	private ComponentPathNode GetComponentAtPosition(Vector3 localPosition)
	{
		return traversalNodes.FirstOrDefault(x => Vector3.Distance(x.localPosition, localPosition) < 0.01f);
	}
}
