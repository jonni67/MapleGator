using System;
using System.Windows.Forms;
using System.Collections.Generic;

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

		private void Tick_Bot(object sender, EventArgs e)
		{
			// if still hooking return
			if (_hooking)
				return;

			// if hooked check if process still even exists
			if(_hooked)
			{
				if (!IsProcessRunning(_currPID))
				{
					ResetHook();
					return;
				}
			}

			// callback the current state
			_stateCallbacks[_state]();
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
	}


}