<div align="center">
<h1>PowerTODO</h1>
<p> 一款面向 <a href="https://github.com/microsoft/PowerToys">PowerToys Run</a> 打造的轻量级待办管理插件</p>

![PowerToys Plugin](https://img.shields.io/badge/PowerToys-Plugin-blue)
![.NET 6.0](https://img.shields.io/badge/.NET-6.0-purple)
![License](https://img.shields.io/badge/license-MIT-green)
![Windows](https://img.shields.io/badge/Windows-10%2B-orange)

<p><b>无需切换窗口 · 一键呼出 · 极速记录</b></p>
</div>

> 依赖说明：需提前安装Microsoft PowerToys（建议使用最新版本），插件仅作用于 PowerToys Run 模块。

##  核心功能

-  **快速添加**：输入`todo [任务]`，一键创建待办
-  **智能搜索**：支持关键词模糊匹配，不区分大小写
-  **自动保存**：数据持久化，重启不丢失

## 安装

1. 下载插件：

    - 前往 https://github.com/ShiroWei/PowerTODO 下载最新版本的 [`PowerTODO.zip`](https://github.com/ShiroWei/PowerTOD/releases)

2. 安装插件：

    **安装前请确保 PowerToys 已完全退出（包括后台进程）**

    - 将下载的 PowerTODO.zip 解压到 `%LOCALAPPDATA%\Microsoft\PowerToys\PowerToys Run\Plugins` 目录
    - 重新启动 PowerToys 应用程序

## 配置说明

插件会**自动在 `%LOCALAPPDATA%\PowerTODO\todo.json` 路径下创建待办存储文件**

若需备份待办数据，可直接复制该 JSON 文件；若需重置待办，删除该文件后重启 PowerToys 即可。

## 开发环境

本插件基于以下环境开发，如需二次开发或调试，可参考配置：
- 框架：.NET 6.0
- 开发工具：Visual Studio Code
- 运行系统：Windows 11（建议版本 22H2 及以上）

## 待优化项

- 目前仅支持删除任务，缺乏“标记完成”的状态管理功能
- 图标不支持随 PowerToys Run 主题自动切换，浅色主题下可能显示不一致
- 缺乏本地化存储的配置选项

## 许可证

本项目采用 MIT 许可证。详见 [LICENSE](LICENSE) 文件。

## 其他
本项目为新人个人开发者维护，能力有限，欢迎任何形式的贡献：

欢迎各位开发者补充完善、提交 PR，也欢迎提出 issue 反馈问题，共同优化插件体验
