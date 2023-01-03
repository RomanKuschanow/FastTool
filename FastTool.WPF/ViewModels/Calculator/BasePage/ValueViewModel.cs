﻿#nullable disable
using FastTool.CalculationTool;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using System.Windows.Input;
using FastTool.Utils;
using System.Collections.ObjectModel;

namespace FastTool.WPF.ViewModels.Calculator
{
    public class ValueViewModel : ListItemBase
    {
        private string name;
        private Error error;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public Error Error
        {
            get => error;
            set
            {
                error = value;
                OnPropertyChanged();
                Calculate();
            }
        }

        public ValueViewModel(ObservableCollection<ValueViewModel> values) : base(values) { }

        protected override void Calculate()
        {
            if (Error == Error.None)
                base.Calculate();
            else
                Answer = $"{error}";
        }
    }
}
