using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MapleGatorBot
{
	public partial class Planner : Form
	{
		MapleGator _parent;
		PlannerChoiceBox _choiceBox;
		TreeNode _dragCallbackNode;

		PlannerElementTypes _currElementType;

		List<string> _triggerElements = new List<string>
		{
			"HP Below X%",
			"MP Below X%",
			"Level Below X",
		};

		List<string> _actionElements = new List<string>
		{
			"Follow Routine X",
			"Use Consumable",
		};

		Dictionary<string, Action> _onTriggerDragCallbacks = new Dictionary<string, Action>();

		public Planner(MapleGator parent)
		{
			InitializeComponent();
			_parent = parent;

			triggerTree.AllowDrop = true;
			routineTree.AllowDrop = true;
			trashTree.AllowDrop = true;

			triggerTree.ItemDrag += TreeView_ItemDrag;
			elementsTree.ItemDrag += TreeView_ItemDrag;
			routineTree.ItemDrag += TreeView_ItemDrag;
			trashTree.ItemDrag += TreeView_ItemDrag;

			triggerTree.DragEnter += TreeView_DragEnter;
			elementsTree.DragEnter += TreeView_DragEnter;
			routineTree.DragEnter += TreeView_DragEnter;
			trashTree.DragEnter += TreeView_DragEnter;

			triggerTree.DragDrop += TreeView_DragDrop;
			elementsTree.DragDrop += TreeView_DragDrop;
			routineTree.DragDrop += TreeView_DragDrop;
			trashTree.DragDrop += TreeView_DragDrop;

			trashMob.BringToFront();

			_currElementType = PlannerElementTypes.Trigger;

			_onTriggerDragCallbacks["HP Below X%"] = OpenChoiceBoxHPBelow;
		}

		public void SuspendAll()
		{
			_parent.SuspendLayout();
			SuspendLayout();
			_parent.Enabled = false;
			Enabled = false;
		}

		public void ResumeAll()
		{
			_parent.ResumeLayout();
			ResumeLayout();
			_parent.Enabled = true;
			Enabled = true;
		}

		public void CancelDraggedNode()
		{
			if(_dragCallbackNode != null)
			{
				_dragCallbackNode.Remove();
			}
		}

		private void OpenChoiceBoxHPBelow()
		{
			_choiceBox = new PlannerChoiceBox(this);
			_choiceBox.ShowHundredValueMode("Choose a value for HP Below %");
			_choiceBox.OnSuccessfulHundredValue += SuccessfulHPBelowChoice;
		}

		private void SuccessfulHPBelowChoice(int val)
		{
			_choiceBox.OnSuccessfulHundredValue -= SuccessfulHPBelowChoice;

			Console.WriteLine(_dragCallbackNode == null);
			if (_dragCallbackNode != null)
			{
				_dragCallbackNode.Text = $"HP Below {val}%";
				Console.WriteLine(_dragCallbackNode.Text);
			}

			_dragCallbackNode = null;
		}

		private void TreeView_ItemDrag(object sender, ItemDragEventArgs e)
		{
			DoDragDrop(e.Item, DragDropEffects.Move);
		}

		private void TreeView_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(TreeNode)))
			{
				e.Effect = DragDropEffects.Move;
			}
		}

		private void TreeView_DragDrop(object sender, DragEventArgs e)
		{
			System.Windows.Forms.TreeView targetTree = sender as System.Windows.Forms.TreeView;

			TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));
			Point dropPoint = targetTree.PointToClient(new Point(e.X, e.Y));
			TreeNode targetNode = targetTree.GetNodeAt(dropPoint);

			// prevents dropping node onto itself or a descendant
			if (draggedNode == targetNode || IsDescendant(draggedNode, targetNode))
				return;

			// if we're dragging an element into the trigger tree
			if(targetTree.Name == "triggerTree")
			{
				// clone that node
				TreeNode clonedNode = (TreeNode)draggedNode.Clone();

				// trigger any callbacks that need to happen
				if (_onTriggerDragCallbacks.ContainsKey(draggedNode.Name))
				{
					_dragCallbackNode = clonedNode;
					_onTriggerDragCallbacks[draggedNode.Name]();
				}

				// then add node to its proper location
				if (targetNode != null)
				{
					// if its a trigger, it cannot be a child node
					// if dropped on another node it must be
					// dropped as a root node instead
					if (_currElementType == PlannerElementTypes.Trigger)
					{
						targetTree.Nodes.Add(clonedNode);
						return;
					}
					// if its an action it must be dropped on a trigger node
					else if (_currElementType == PlannerElementTypes.Action)
					{
						if (_actionElements.Contains(targetNode.Text))
							return;
						targetNode.Nodes.Add(clonedNode);
						targetNode.Expand();
					}
				}
				else
				{
					if (_currElementType == PlannerElementTypes.Trigger)
					{
						// if dropped on the tree directly,
						// its OK if its a trigger node
						targetTree.Nodes.Add(clonedNode);
					}
				}
			}
			// if we're dragging an element into the routine tree
			else if(targetTree.Name == "routineTree")
			{
				if(_currElementType != PlannerElementTypes.Routine)
					return;
			}
			// if we're dragging an element into the trash tree 
			else if(targetTree.Name == "trashTree")
			{
				// delete that node
				draggedNode.Remove();
			}
		}

		// Prevent dropping a node into itself or its children
		private bool IsDescendant(TreeNode parent, TreeNode child)
		{
			while (child != null)
			{
				if (child == parent) return true;
				child = child.Parent;
			}
			return false;
		}

		private void Btn_AddTrigger_Click(object sender, EventArgs e)
		{
			elementsTree.Nodes.Clear();

			for(int i = 0; i < _triggerElements.Count; i++)
			{
				TreeNode n = elementsTree.Nodes.Add(_triggerElements[i]);
				n.Name = _triggerElements[i];
			}

			_currElementType = PlannerElementTypes.Trigger;
		}

		private void Btn_AddAction_Click(object sender, EventArgs e)
		{
			elementsTree.Nodes.Clear();

			for (int i = 0; i < _actionElements.Count; i++)
			{
				TreeNode n = elementsTree.Nodes.Add(_actionElements[i]);
				n.Name = _actionElements[i];
			}

			_currElementType = PlannerElementTypes.Action;
		}
	}
}
