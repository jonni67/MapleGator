using MapleGatorBot.ChoiceForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MapleGatorBot
{
	public partial class Planner : Form
	{
		public TreeView RoutineTree { get { return routineTree; } }

		public TreeView TriggerTree { get { return triggerTree; } }

		public int NumRoutines { get { return _numRoutines; } }

		public int CurrRoutine { get { return _currRoutine; } }

		public TreeNode CurrRoutineNode { get { return _currRoutineNode; } }

		public MapleGator GatorParent { get { return _parent; } }

		MapleGator _parent;
		Form _choiceBox;
		TreeNode _dragCallbackNode;
		TreeNode _currRoutineNode;

		PlannerElementTypes _currElementType;
		int _numRoutines;
		int _currRoutine = -1;

		Dictionary<string, PlannerTriggerTypes> _triggerElements = new Dictionary<string, PlannerTriggerTypes>
		{
			/* 0 */ { "HP Below: X%", PlannerTriggerTypes.HPBelow },
			/* 1 */ { "MP Below: X%", PlannerTriggerTypes.MPBelow },
			/* 2 */ { "Level Range: X, Y", PlannerTriggerTypes.LevelRange },
		};

		List<string> _triggerList = new List<string>();
		Dictionary<string, Action> _onTriggerDragCallbacks = new Dictionary<string, Action>();

		Dictionary<string, PlannerActionTypes> _actionElements = new Dictionary<string, PlannerActionTypes>
		{
			/* 0 */ { "Follow Routine: X", PlannerActionTypes.FollowRoutine },
			/* 1 */ { "Use Consumable: X", PlannerActionTypes.UseConsumable },
			/* 2 */ { "Wait: X ms", PlannerActionTypes.WaitMS },			
			/* 3 */ { "Wait random: X, Y ms", PlannerActionTypes.WaitRandomMS },
			/* 4 */ { "Goto Map: X", PlannerActionTypes.GotoMap },
			/* 5 */ { "Hunt In Map", PlannerActionTypes.HuntInMap },
		};

		List<string> _actionList = new List<string>();
		Dictionary<string, Action> _onActionDragCallbacks = new Dictionary<string, Action>();

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

			foreach(string t in _triggerElements.Keys)
			{
				_triggerList.Add(t);
			}

			foreach (string t in _actionElements.Keys)
			{
				_actionList.Add(t);
			}

			// trigger drag callbacks
			_onTriggerDragCallbacks[_triggerList[0]] = OpenChoiceBoxHPBelow;
			_onTriggerDragCallbacks[_triggerList[2]] = OpenChoiceBoxLevelRange;

			// action drag callbacks
			_onActionDragCallbacks[_actionList[4]] = OpenChoiceBoxGoMap;
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
			_parent.BotPaused = true;
			_choiceBox = new HPBelowChoiceForm(this);
			HPBelowChoiceForm f = ((HPBelowChoiceForm)_choiceBox);
			f.Initialize();
			f.OnSuccess += SuccessfulHPBelowChoice;
		}

		private void OpenChoiceBoxLevelRange()
		{
			_parent.BotPaused = true;
			_choiceBox = new LevelRangeChoiceForm(this);
			LevelRangeChoiceForm f = ((LevelRangeChoiceForm)_choiceBox);
			f.Initialize();
			f.OnSuccess += SuccessfulLevelRangeChoice;
		}

		private void OpenChoiceBoxGoMap()
		{
			_parent.BotPaused = true;
			_choiceBox = new GoMapChoiceForm(this);
			GoMapChoiceForm f = ((GoMapChoiceForm)_choiceBox);
			f.Initialize();
			f.OnSuccess += SuccessfulMapGoChoice;
		}

		private void SuccessfulHPBelowChoice(HPBelowChoiceForm sender, int val)
		{
			sender.OnSuccess -= SuccessfulHPBelowChoice;

			if (_dragCallbackNode != null)
			{
				StringBuilder s = new StringBuilder(_dragCallbackNode.Text);
				s.Replace("X", $"{val}");
				_dragCallbackNode.Text = s.ToString();
			}

			_dragCallbackNode = null;
			_parent.BotPaused = false;
		}

		private void SuccessfulLevelRangeChoice(LevelRangeChoiceForm sender, int val1, int val2)
		{
			sender.OnSuccess -= SuccessfulLevelRangeChoice;

			if (_dragCallbackNode != null)
			{
				StringBuilder s = new StringBuilder(_dragCallbackNode.Text);
				s.Replace("X", $"{val1}");
				s.Replace("Y", $"{val2}");
				_dragCallbackNode.Text = s.ToString();
				Console.WriteLine(_dragCallbackNode.Text);
			}

			_dragCallbackNode = null;
			_parent.BotPaused = false;
		}

		private void SuccessfulMapGoChoice(GoMapChoiceForm sender, int val1)
		{
			sender.OnSuccess -= SuccessfulMapGoChoice;

			if (_dragCallbackNode != null)
			{
				StringBuilder s = new StringBuilder(_dragCallbackNode.Text);
				s.Replace("X", $"{val1}");
				_dragCallbackNode.Text = s.ToString();
				Console.WriteLine(_dragCallbackNode.Text);
			}

			_dragCallbackNode = null;
			_parent.BotPaused = false;
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
					// if dropped on another node it will be
					// dropped as a root node instead
					if (_currElementType == PlannerElementTypes.Trigger)
					{
						// drop as root node
						targetTree.Nodes.Add(clonedNode);
						return;
					}
					// if its an action it must be dropped on a trigger node
					else if (_currElementType == PlannerElementTypes.Action)
					{
						if (_actionList.Contains(targetNode.Text))
							return;

						// execute drag callback for that action
						if(_onActionDragCallbacks.ContainsKey(draggedNode.Text))
						{
							_dragCallbackNode = clonedNode;
							_onActionDragCallbacks[draggedNode.Text]();
						}

						targetNode.Nodes.Add(clonedNode);
						targetNode.Expand();
					}
				}
				else
				{
					if (_currElementType == PlannerElementTypes.Trigger)
					{
						// if dropped on the tree directly,
						// its dropped as a root node
						targetTree.Nodes.Add(clonedNode);
					}
				}
			}
			// if we're dragging an element into the routine tree
			else if(targetTree.Name == "routineTree")
			{
				// make sure its an action thats being dropped
				if(_currElementType != PlannerElementTypes.Action)
					return;

				// make sure its not being dropped as a root node
				// actions can only be children nodes of routines
				if (targetNode == null)
					return;

				// clone that node
				TreeNode clonedNode = (TreeNode)draggedNode.Clone();

				// execute drag callback for that action
				if (_onActionDragCallbacks.ContainsKey(draggedNode.Text))
				{
					_dragCallbackNode = clonedNode;
					_onActionDragCallbacks[draggedNode.Text]();
				}

				// add that cloned node to the parent routine node
				targetNode.Nodes.Add(clonedNode);
				targetNode.Expand();
			}
			// if we're dragging an element into the trash tree 
			else if(targetTree.Name == "trashTree")
			{
				// delete that node
				draggedNode.Remove();

				// instead of checking what the sender tree was (more code)
				// just refresh the action/trigger tree if deleted one of their nodes
				if (_currElementType == PlannerElementTypes.Trigger)
					RefreshTriggerTree();
				else if (_currElementType == PlannerElementTypes.Action)
					RefreshActionTree();
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

		private void RefreshTriggerTree()
		{
			elementsTree.Nodes.Clear();

			for (int i = 0; i < _triggerList.Count; i++)
			{
				TreeNode n = elementsTree.Nodes.Add(_triggerList[i]);

				// enum is the tag object of this node
				n.Tag = _triggerElements[_triggerList[i]]; 

				n.Name = _triggerList[i];
			}
		}

		private void RefreshActionTree()
		{
			elementsTree.Nodes.Clear();

			for (int i = 0; i < _actionList.Count; i++)
			{
				TreeNode n = elementsTree.Nodes.Add(_actionList[i]);

				// enum is the tag object of this node
				n.Tag = _actionElements[_actionList[i]];

				n.Name = _actionList[i];
			}
		}

		private void Btn_AddTrigger_Click(object sender, EventArgs e)
		{
			RefreshTriggerTree();
			_currElementType = PlannerElementTypes.Trigger;
			categoryLabel.Text = "TRIGGERS";
		}

		private void Btn_AddAction_Click(object sender, EventArgs e)
		{
			RefreshActionTree();
			_currElementType = PlannerElementTypes.Action;
			categoryLabel.Text = "ACTIONS";
		}

		private void Btn_NewRoutine_Click(object sender, EventArgs e)
		{
			_numRoutines++;
			routineTree.Nodes.Add($"Routine {_numRoutines}");
			_currRoutineNode = routineTree.Nodes[0];
		}
	}
}
