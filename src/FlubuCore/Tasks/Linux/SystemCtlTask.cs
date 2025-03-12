using FlubuCore.Context;
using FlubuCore.Tasks.Process;

namespace FlubuCore.Tasks.Linux
{
    public class SystemCtlTask : TaskBase<int, SystemCtlTask>
    {
        private readonly string _command;
        private readonly string _service;
        private readonly string _host;

        /// <summary>
        /// Control systemd services.
        /// </summary>
        /// <param name="command">Command to execute (start, stop, status, ...)</param>
        /// <param name="service">Execute command for service unit.</param>
        /// <param name="host">Execute command on a remote host.</param>
        public SystemCtlTask(string command, string service, string host)
        {
            _command = command;
            _service = service;
            _host = host;
        }

        protected override string Description { get; set; }

        protected override int DoExecute(ITaskContextInternal context)
        {
            IRunProgramTask task = context
                .Tasks()
                .RunProgramTask("systemctl")
                .WithArguments(_command, _service);

            if (DoNotFail)
                task.DoNotFailOnError();

            if (!string.IsNullOrEmpty(_host))
                task.WithArguments("-H", _host);

            return task.Execute(context);
        }
    }
}
