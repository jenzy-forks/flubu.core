﻿using System;
using System.Collections.Generic;
using System.Text;
using FlubuCore.Context;
using FlubuCore.Tasks;
using Microsoft.Extensions.Logging;

namespace FlubuCore.Scripting
{
    public interface IBuildScriptEngine
    {
        ITaskFactory TaskFactory { get; }

        IServiceProvider ServiceProvider { get; }

        ILoggerFactory LoggerFactory { get; }

        ITaskSession CreateTaskSession(BuildScriptArguments commandArguments);
    }
}