using System;
using System.Collections.Generic;
using System.Text;

namespace HCEngine.Default.Language
{
    public interface IInput
    {
        IDictionary<string, Type> ParametersMap { get; }
    }
}
