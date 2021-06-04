using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorObserver.Stores.CounterStore
{
  public class CounterState
  {
    public CounterState(int count)
    {
      Count = count;
    }
    public int Count { get; }
  }

  public class CounterStore
  {
    private CounterState _counterState;
    private Action _listeners;

    public CounterStore()
    {
      _counterState = new CounterState(0);
    }

    public CounterState GetState()
    {
      return _counterState;
    }

    public void IncrementCount()
    {
      var count = this._counterState.Count;
      count++;
      this._counterState = new CounterState(count);
      BroadcastStateChanged();
    }

    public void DecrementCount()
    {
      var count = this._counterState.Count;
      count--;
      this._counterState = new CounterState(count);
      BroadcastStateChanged();
    }

    public void AddStateChangeListeners(Action listener)
    {
      _listeners += listener;
    }

    public void RemoveStateChangeListeners(Action listener)
    {
      _listeners -= listener;
    }

    private void BroadcastStateChanged()
    {
      _listeners.Invoke();
    }
  }
}
