﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.DotNet.Cli.Utils;

namespace Flubu.Tasks.Process
{
    public class RunProgramTask : TaskBase
    {
        private readonly string _programToExecute;
        private readonly List<string> _arguments = new List<string>();
        private string _workingFolder;

        public RunProgramTask(string programToExecute)
        {
            _programToExecute = programToExecute;
        }

        public override string Description => "Run program";

        public RunProgramTask WithArguments(string arg)
        {
            _arguments.Add(arg);
            return this;
        }

        public RunProgramTask WithArguments(params string[] args)
        {
            _arguments.AddRange(args);
            return this;
        }

        public RunProgramTask WorkingFolder(string folder)
        {
            _workingFolder = folder;
            return this;
        }

        protected override void DoExecute(ITaskContext context)
        {
            context.WriteMessage(
                $"Running program '{_programToExecute}': (work.dir='{_workingFolder}',args = '{_arguments.ListToString()}')");

            CommandFactory commandFactory = new CommandFactory();

            ICommand command = commandFactory.Create(_programToExecute, _arguments);

            string currentDirectory = Directory.GetCurrentDirectory();

            using (MemoryStream s = new MemoryStream())
            using (TextWriter w = new StreamWriter(s))
            {
                int res = command
                    .CaptureStdErr()
                    .CaptureStdOut()
                    .WorkingDirectory(_workingFolder ?? currentDirectory)
                    .OnErrorLine(context.WriteMessage)
                    .OnOutputLine(context.WriteMessage)
                    .Execute()
                    .ExitCode;

                w.Flush();

                context.WriteMessage(Encoding.UTF8.GetString(s.ToArray()));

                if (res != 0)
                {
                    context.Fail($"External program {_programToExecute} failed with {res}");
                }
            }
        }
    }
}
