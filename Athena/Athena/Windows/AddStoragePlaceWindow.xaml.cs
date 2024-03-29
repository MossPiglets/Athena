﻿using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using System.Windows;
using Athena.Data.StoragePlaces;
using Athena.EventManagers;

namespace Athena.Windows {
    public partial class AddStoragePlaceWindow {
        public AddStoragePlaceWindow() {
            InitializeComponent();
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e) {
            if (!ApplicationDbContext.Instance.StoragePlaces.Any(a =>
                a.StoragePlaceName.ToLower() == StoragePlaceTextBox.Text.ToLower())) {
                var storagePlace = new StoragePlace
                    {StoragePlaceName = StoragePlaceTextBox.Text, Id = Guid.NewGuid()};
                ApplicationDbContext.Instance.Entry(storagePlace).State = EntityState.Added;
                ApplicationDbContext.Instance.SaveChanges();
                StoragePlaceAdded?.Invoke(this, new EntityEventArgs<StoragePlace> {Entity = storagePlace});

                this.Close();
            }

            else {
                StoragePlaceExistsTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e) {
            e.CanExecute = !Validation.GetHasError(StoragePlaceTextBox);
        }

        public event EventHandler<EntityEventArgs<StoragePlace>> StoragePlaceAdded;
    }
}