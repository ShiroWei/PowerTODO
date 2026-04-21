using System.Collections.Generic;
using Wox.Plugin;

public class Main : IPlugin
{
    public static string PluginID => "TodoPlugin";
    public string Name => "PowerTODO";
    public string Description => "A TODO manager for Powertoy Run";
    public void Init(PluginInitContext context) { }

    public List<Result> Query(Query query)
    {
        return new List<Result>
        {
            new Result
            {
                Title = "Hello PowerTODO",
                SubTitle = "Plugin works",
                Action = e => true
            }
        };
    }
}