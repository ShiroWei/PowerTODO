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
    public List<Result> Query(Query query)
    {
        var querySearch = query.Search;
        
        // TODO: 触发词没有内容
        // TODO: 获取现有列表
        // TODO: 构建结果列表
        // TODO: 创建代办事项（常驻）

        return new List<Result>();

    }
}