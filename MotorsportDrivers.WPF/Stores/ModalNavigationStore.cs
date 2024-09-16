﻿using MotorsportDrivers.WPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MotorsportDrivers.WPF.Stores
{
    public class ModalNavigationStore
    {

        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                /*
                if(_currentViewModel != null)
                {
                    _currentViewModel.Dispose();
                }
                */
                _currentViewModel = value;
                CurrentViewModelChanged?.Invoke();
            }
        }

        public event Action CurrentViewModelChanged;


    }
}
