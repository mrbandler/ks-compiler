﻿using System.Collections.Generic;
using System.IO;
using kOS.Cli.IO;
using kOS.Cli.Models;
using kOS.Cli.Options;
using kOS.Cli.Logging;
using kOS.Safe.Serialization;
using kOS.Safe.Compilation;
using kOS.Safe.Compilation.KS;
using kOS.Safe.Persistence;
using kOS.Safe.Exceptions;

namespace kOS.Cli.Actions
{
    public class Runner : AbstractAction
    {
        /// <summary>
        /// Run CLI options.
        /// </summary>
        private RunOptions _options;

        /// <summary>
        /// Logger.
        /// </summary>
        private RunnerLogger _logger;

        /// <summary>
        /// Common logger.
        /// </summary>
        private CommonLogger _commonLogger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="Options">Run CLI options.</param>
        public Runner(RunOptions Options)
        {
            _options = Options;
            _logger = new RunnerLogger();
            _commonLogger = new CommonLogger();
        }

        /// <summary>
        /// Runs the run action.
        /// </summary>
        /// <returns></returns>
        public override int Run()
        {
            int result = 0;

            if (IsKerboscript(_options.Script) == true)
            {
                ExecuteKerboscript(_options.Script);
            }
            else
            {
                Configuration config = LoadConfiguration();
                if (config != null) {
                    Models.Script script = config.Scripts.Find(s => s.Name == _options.Script);
                    if (script != null)
                    {
                        result = ExecuteConfigScript(script);
                    }
                    else
                    {
                        _logger.ScriptNotFound(_options.Script);
                        result = 1;
                    }
                }
                else
                {
                    _commonLogger.NoConfigurationFound();
                    result = 1;
                }
            }

            return result;
        }

        /// <summary>
        /// Loads the configuration from disk.
        /// </summary>
        /// <returns>Loaded configuration, if found on disk.</returns>
        protected override Configuration LoadConfiguration()
        {
            return base.LoadConfiguration();
        }

        /// <summary>
        /// Executes a script from the configuration.
        /// </summary>
        /// <param name="Script"></param>
        /// <returns>CLI return code.</returns>
        private int ExecuteConfigScript(Models.Script Script)
        {
            int result = 0;



            return result;
        }

        /// <summary>
        /// Executes a Kerboscript.
        /// </summary>
        /// <param name="Filepath">Filepath to the Kerboscript to execute.</param>
        /// <returns>CLI return code.</returns>
        private int ExecuteKerboscript(string Filepath)
        {
            int result = 0;



            return result;
        }

        /// <summary>
        /// Checks if a given script string is a Kerboscript on disk.
        /// </summary>
        /// <param name="Script">Script string to check.</param>
        /// <returns>True if it is a Kerboscript, false if it's not.</returns>
        private bool IsKerboscript(string Script)
        {
            return File.Exists(Script);
        }
    }
}
