using System.Collections.Generic;
using Wox.Plugin;

public class Main : IPlugin
{
    // PowerToy 必须属性 PluginID, Name, Description
    // TODO: PluginID更新为 GUID
    public static string PluginID => "TodoPlugin";
    public string Name => "PowerTODO";
    public string Description => "A TODO manager for Powertoy Run";

    private ITodoDataService _todoService;

    // 放在Main中防止可为空引用类型
    public Main()
    {
        _todoService = new TodoDataService(@"D:\todo");
    }
    // Init 方法
    public void Init(PluginInitContext context) { }

    // Query 方法
    // TODO: 添加编辑Todo以及完成Todo功能
    public List<Result> Query(Query query)
    {
        
        var items = _todoService.List(query.Search);

        return items.Select(item => new Result
        {
            Title = item.Title,
            SubTitle = item.Path,
            Action = e =>
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = item.Path,
                    UseShellExecute = true
                });
                return true;
            }
        }).ToList();
    }
}