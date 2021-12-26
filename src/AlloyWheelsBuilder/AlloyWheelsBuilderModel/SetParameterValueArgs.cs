using System;

namespace AlloyWheelsBuilderModel
{
    public class SetParameterValueArgs: EventArgs
    {
        public AlloyWheelsParameterName ParameterName { get; set; }

        public string Message { get; set; }

        public SetParameterValueArgs(AlloyWheelsParameterName parameterName,
            string message)
		{
            ParameterName = parameterName;
            Message = message;
		}
    }
}
