/***************************************************************************************
 *      Copyright (C) 2021 Fran Vojković, Martina Gaćina, Matea Čotić, Mirna Keser     *
 *                                                                                     *
 *              This file is part of the RP3_Projekt project.                          *
 *                                                                                     *
 ***************************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaffeBar
{
    /// <summary>
    /// Logedin user tracking class.
    /// </summary>
    internal static class User
    {
        public static string name;
        public static string authorisation;
        public static int id;
        public static bool showNotification;
    }
}
