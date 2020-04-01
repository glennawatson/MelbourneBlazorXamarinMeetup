﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using MelbourneModernApp.Core.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace MelbourneModernApps.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class NewItemPage : ContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();

            Item = new Item
            {
                Name = "Item name",
                Description = "This is an item description."
            };

        }

        async void Save_Clicked(object sender, EventArgs e)
        {
            var success = await VM.Save();
            if(success)
                await Navigation.PopModalAsync();
        }

        async void Cancel_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}