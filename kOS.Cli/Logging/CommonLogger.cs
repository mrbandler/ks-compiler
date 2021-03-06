﻿using System.Collections.Generic;
using System.Drawing;
using Pastel;

namespace kOS.Cli.Logging
{
    /// <summary>
    /// Common logger implementation.
    /// </summary>
    public class CommonLogger : Logger
    {
        /// <summary>
        /// Prints no configuration found message.
        /// </summary>
        public void NoConfigurationFound()
        {
            Error(Draw.PrefixAndColor, "No configuration found.");
            NewLine();
            Info(Draw.None, "Please execute the command " + "'ksc init'".Pastel(Color.DarkGray) + " to create a " + Constants.ConfigFileName.Pastel(Color.DarkGray));
            Info(Draw.None, "or point to a file or directory containing " + "*.ks".Pastel(Color.DarkGray) + " files via the compile CLI options (" + "'ksc compile --help'".Pastel(Color.DarkGray) + ").");
            NewLine();
        }

        /// <summary>
        /// Prints configuration invalid message.
        /// </summary>
        /// <param name="Messages">Invalidity messages.</param>
        public void ConfigurationInvalid(List<string> messages)
        {
            Error(Draw.PrefixAndColor, "Configuration invalid.");
            NewLine();
            foreach (string message in messages) 
            {
                Info(Draw.None, message);
            }
            NewLine();
        }
    }
}
