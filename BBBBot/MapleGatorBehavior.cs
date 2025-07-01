using System;
using System.Windows.Forms;
using System.Collections.Generic;

using TreeNode = System.Windows.Forms.TreeNode;
using OpenTK.Audio.OpenAL;
using System.Runtime.Remoting.Metadata.W3cXsd2001;

namespace MapleGatorBot
{
	public partial class MapleGator : Form
	{

		/// <summary>
		/// Loads every state callback
		/// </summary>
		private void LoadStates()
		{
			_stateCallbacks = new Dictionary<BotStates, Action>();
			_stateCallbacks [BotStates.Idle] = Tick_Idle;
			_stateCallbacks [BotStates.Waiting] = Tick_Waiting;
			_stateCallbacks [BotStates.Moving] = Tick_Move;
			_stateCallbacks [BotStates.Attacking] = Tick_Attack;

			_state = BotStates.Idle;

			// simulated //
			_currLvl = 1;
			_currExp = 0;
			_currHp = _maxHP;
			_currMapID = 0;
			// simualted //
		}

		/// <summary>
		/// Starts the bot tick interval for the tick timer.
		/// </summary>
		private void StartBot()
		{
			// tick timer between states can be variable
			_tickTimer = new Timer();
			_tickTimer.Interval = _stateDelayMs;
			_tickTimer.Tick += new EventHandler(Tick_Bot);
			_tickTimer.Start();

			// sys timer always ticks every 1 ms
			_sysTimer = new Timer();
			_sysTimer.Interval = 1;
			_sysTimer.Tick += new EventHandler(Tick_StopWatch);
			_sysTimer.Start();

			_ipcTimer = new Timer();
			_ipcTimer.Interval = 1;
			_ipcTimer.Tick += new EventHandler(Tick_IPC);
			_ipcTimer.Start();
		}

		/// <summary>
		/// Sets the internal waiting stopwatch timer.
		/// </summary>
		private void SetTimer(float ms)
		{
			_stopWatch.Restart();
			_stopWatchTime = ms;
			_timerActive = true;
		}

		private bool IsTickValid()
		{
			if(!_hooked)
			{
				_state = BotStates.Idle;
				return false;
			}

			return true;
		}

		private bool IsTickBusy()
		{
			return (!_hooking && !_timerActive);
		}

		private void Tick_IPC(object sender, EventArgs e)
		{
			if (!_hooked || !IPCManager.IS_IPC_VALID)
			{
				return;
			}

			IPCManager.UpdateGameData();
			IPCManager.UpdateArrayData();
		}

		private void Tick_Bot(object sender, EventArgs e)
		{
			if (_botPaused)
				return;

			// if still hooking return
			if (_hooking)
				return;

			if(_hooked)
			{
				// if hooked check if process still even exists
				if (!IsProcessRunning(_currPID))
				{
					ResetHook();
					return;
				}
				else if(!_ipcInitiated)
				{
					// init the IPC after injection success
					IPCManager.InitIPC();
					_ipcInitiated = true;
				}
				else if(IPCManager.IS_IPC_VALID)
				{
					UpdateGameData();
				}
			}

			// callback the current state
			_stateCallbacks[_state]();
			TraverseTriggerTree();
			TraverseRoutine();
		}

		private void Tick_StopWatch(object sender, EventArgs e)
		{
			// tick the stop watch only if timer was activated
			if (!_timerActive)
			{
				return;
			}

			// if the internal stopwatch hasnt completed
			if (_stopWatch.ElapsedMilliseconds < _stopWatchTime)
			{
				float remaining = _stopWatchTime - (float)(_stopWatch.ElapsedMilliseconds);
				string rs = (remaining / 1000).ToString("0.00");
				_primary.TimerLabel.Text = $"{rs}s";
				return;
			}

			// call the stopwatch complete event on completion
			if (OnStopWatchTimeComplete != null)
			{
				OnStopWatchTimeComplete();
				OnStopWatchTimeComplete = null;
			}

			_timerActive = false;
		}

		private void Tick_Idle()
		{
			if (!IsTickBusy())
			{
				return;
			}

			// still waiting for a hook to be established
			if (!_hooked)
			{
				SetTimer(_processListRefreshRate);
				OnStopWatchTimeComplete += () =>
				{
					_primary.StatusLabel.Text = "Refreshing Process List";
					_primary.LoadProcessList();
				};

				return;
			}

			_state = BotStates.Waiting;
			_waitingState = WaitingStates.Initial;
		}

		private void Tick_Waiting()
		{
			if (!IsTickValid() || !IsTickBusy())
			{
				return;
			}

			if (_waitingState == WaitingStates.Initial)
			{
				_primary.StatusLabel.Text = "Preparing ...";
				_waitingState = WaitingStates.Waiting;
				return;
			}

			if(_waitingState == WaitingStates.Waiting)
			{
				_primary.StatusLabel.Text = "Waiting ...";
				SetTimer(2000);
				OnStopWatchTimeComplete += () =>
				{
					_state = BotStates.Moving;
				};
			}
		}

		private void Tick_Move()
		{
			if (!IsTickValid() || !IsTickBusy())
			{
				return;
			}

			_primary.StatusLabel.Text = "Moving ...";
			SetTimer(2000);
			OnStopWatchTimeComplete += () =>
			{
				_state = BotStates.Waiting;
				_waitingState = WaitingStates.Waiting;
			};
		}

		private void Tick_Attack()
		{
			if (!IsTickValid() || !IsTickBusy())
			{
				return;
			}

			// NOT YET IMPLEMENTED //
		}

		private void TraverseTriggerTree()
		{
			// we could write a sophisticated traversal tree for nodes
			// but really, why bother?
			// their structure is at most depth of 2 and pretty small
			// the strings contain all the info we'll need
			// its simple and easy to deal with, no OOP needed

			// nodes are traversed sequentially
			foreach (TreeNode n in _planner.TriggerTree.Nodes)
			{
				PlannerTriggerTypes tag = (PlannerTriggerTypes)n.Tag;

				if (tag == PlannerTriggerTypes.HPBelow)
				{
					// HP Below: X%
					string[] split = n.Text.Split(':');
					string sVal = split[1].Replace('%', ' ').Trim();
					float val = float.Parse(sVal);

					float hpPercent = (_currHp / _maxHP) * 100;
					if(hpPercent < val)
					{
						Console.WriteLine($"Trigger Reached: HP Below: {val}%");
						TraverseTrigger(n);
					}
				}
				else if(tag == PlannerTriggerTypes.LevelRange)
				{
					// Level Range: X, Y
					string[] split = n.Text.Split(':');
				}
			}
		}

		private void TraverseTrigger(TreeNode n)
		{
			foreach(TreeNode tn in n.Nodes)
			{
				ExecuteActionsInNode(tn);
			}
		}

		private void TraverseRoutine()
		{
			if (_planner.CurrRoutineNode == null)
				return;

			foreach (TreeNode tn in _planner.CurrRoutineNode.Nodes)
			{
				ExecuteActionsInNode(tn);
			}
		}

		private void ExecuteActionsInNode(TreeNode tn)
		{
			PlannerActionTypes tag = (PlannerActionTypes)tn.Tag;
			if (tag == PlannerActionTypes.UseConsumable)
			{
				UseConsumable();
				Console.WriteLine($"Executing Action: Use Consumable: Test");
			}
			else if(tag == PlannerActionTypes.GotoMap)
			{
				string t = tn.Text;
				string[] split = tn.Text.Split(':');
				
				int val = int.Parse(split[1]);
				if (_currMapID != val)
				{
					// Simulate_GotoMap(val); // for simulation
					IPC_GotoMap(val);
				}
				
			}
			else if(tag == PlannerActionTypes.HuntInMap)
			{
				SimulateHunting();
			}
		}

		private void IPC_GotoMap(int id)
		{
			if (!_hooked)
				return;

			if (IPCManager.GAME_DATA.isNavigating == 1)
			{
				Console.WriteLine($"Action Execute: Goto Map: {id} : ALREADY NAVIGATING");
				return;
			}

			if (IPCManager.GAME_DATA.currentMapID == id)
			{
				Console.WriteLine($"Action Execute: Goto Map: {id} : ALREADY IN MAP");
				return;
			}


			// starting test = 40000 -> 40001
			// Usage: navigate<mapId>
			Console.WriteLine($"Executing Action: Goto Map: {id}");
			Console.WriteLine("Sending Navigate Command to IPC");
			Console.WriteLine($"Nav Status: {IPCManager.GAME_DATA.navigationStatus}");

			IPCManager.SendCommand($"navigate {id}");
		}

		private void SimulateHunting()
		{
			_currExp += 100;
			_currHp -= 25;

			if(_currExp > 2000)
			{
				_currLvl++;
				_currExp = 0;
			}

			Console.WriteLine($"Simulating Hunt ... HP: {_currHp} | EXP: {_currExp} / 2000 | LVL: {_currLvl}");
		}

		private void Simulate_GotoMap(int id)
		{
			Console.WriteLine($"Simulating Going to Map ...");
			_currMapID = id;
		}
	}
}