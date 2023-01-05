﻿#nullable disable
using FastTool.TimerTool;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Timer = FastTool.TimerTool.Timer;

namespace FastTool.WPF.ViewModels.Time
{
    public class TimeViewModel : INotifyPropertyChanged
    {
        private Stopwatch stopWatch = new(10);
        private List<Timer> timers = new();
        private bool started;
        private bool paused;
        private bool resetted = true;
        private ObservableCollection<SnapshotViewModel> snapshots = new();

        public TimeSpan StopWatchTime => stopWatch.Time;

        public bool Started
        {
            get => started;
            set
            {
                started = value;
                OnPropertyChanged();
            }
        }

        public bool Paused
        {
            get => paused;
            set
            {
                paused = value;
                OnPropertyChanged();
            }
        }

        public bool Resetted
        {
            get => resetted;
            set
            {
                resetted = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<SnapshotViewModel> Snapshots => snapshots;

        public TimeViewModel()
        {
            stopWatch.TimerUpdate += StopWatch_TimerUpdate;
        }

        private void StopWatch_TimerUpdate(object sender, TimerTool.EventHandlers.Args.TimerUpdateEventArgs e)
        {
            OnPropertyChanged(nameof(StopWatchTime));
        }

        public ICommand StartStopWatch => new RelayCommand(StartStopWatchExecute);

        private void StartStopWatchExecute(object obj) => stopWatch.Start();

        public ICommand PauseStopWatch => new RelayCommand(PauseStopWatchExecute);

        private void PauseStopWatchExecute(object obj) => stopWatch.Pause();

        public ICommand ResetStopWatch => new RelayCommand(ResetStopWatchExecute);

        private void ResetStopWatchExecute(object obj) => stopWatch.Stop();

        public ICommand RestartStopWatch => new RelayCommand(RestartStopWatchExecute);

        private void RestartStopWatchExecute(object obj) => stopWatch.Restart();

        public ICommand TakeSnapshot => new RelayCommand(TakeSnapshotExecute);

        private void TakeSnapshotExecute(object obj) => snapshots.Add(new(stopWatch.Time));

        public ICommand ClearSnapshots => new RelayCommand(ClearSnapshotsExecute);

        private void ClearSnapshotsExecute(object obj) => snapshots.Clear();

        public ICommand DeleteSnapshot => new RelayCommand(DeleteSnapshotExecute);

        private void DeleteSnapshotExecute(object obj) => snapshots.Remove((SnapshotViewModel)obj);

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        #endregion
    }
}
