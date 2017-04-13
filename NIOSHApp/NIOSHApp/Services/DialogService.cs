﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NIOSHApp.Services
{
    class DialogService
    {
        public async Task ShowMessage(string message, string title)
        {
            await App.Navigator.DisplayAlert(title, message, "OK");
        }
    }
}
