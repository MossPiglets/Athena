﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Athena.Data;

namespace Athena {

    public partial class BookFormControl : UserControl {

        public BookFormControl(string title, string buttonContent, Book book) {
            InitializeComponent();
            Title = title;
            ButtonContent = buttonContent;
            this.DataContext = this;
            Book = book;
        }

        public Book Book { get; set; } = new Book();

        public string Title { get; set; }

        public string ButtonContent { get; set; }

        public ICommand ButtonCommand { get; set; }
    }
}