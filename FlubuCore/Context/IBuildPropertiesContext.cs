﻿namespace FlubuCore.Context
{
    public interface IBuildPropertiesContext
    {
        /// <summary>
        /// Build properties stored in session
        /// </summary>
        IBuildPropertiesSession Properties { get; }

	    DictionaryWithDefault<string, string> ScriptArgs { get; set; }
	}
}
