﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PixiEditor.Helpers
{
    [Serializable]
    public class NotifyableObject : INotifyPropertyChanged
    {
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };

        public void AddPropertyChangedCallback(string propertyName, Action action)
        {
            if (action == null)
            {
                throw new ArgumentNullException(nameof(propertyName));
            }

            if (string.IsNullOrWhiteSpace(propertyName))
            {
                PropertyChanged += (_, _) => action();
                return;
            }

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == propertyName)
                {
                    action();
                }
            };
        }

        protected void RaisePropertyChanged(string property)
        {
            if (property != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(property));
            }
        }

        protected bool SetProperty<T>(ref T backingStore, T value, [CallerMemberName] string propertyName = "")
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
            {
                return false;
            }

            backingStore = value;
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }
}