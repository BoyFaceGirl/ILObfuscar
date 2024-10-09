// See https://aka.ms/new-console-template for more information
using Obfuscar;

Console.WriteLine("请输入文本，输入特殊字符或'exit'退出程序：");

// 使用 while 循环来持续监听输入
while (true)
{
    string input = Console.ReadLine()!; // 读取用户输入

    // 检查输入是否为特殊字符
    if (input.Any(char.IsPunctuation))
    {
        Console.WriteLine("检测到特殊字符，程序即将退出。");
        break;
    }

    // 如果输入是 "exit"，也退出循环
    if (input.ToLower() == "exit")
    {
        Console.WriteLine("退出命令已接收，程序即将退出。");
        break;
    }

    if (input.IndexOf(".xml") < 1)
    {
        input = input + ".xml";
    }


    string currentDirectory = Directory.GetCurrentDirectory();
    string[] xmlFiles = Directory.GetFiles(currentDirectory, "*.xml");
    if (xmlFiles.Length < 1)
    {
        Console.WriteLine("没有找到对应的配置文件（Obfuscar.xml 或者 config.xml）。");
    }
    else
    {
        string file = xmlFiles[0];

        Obfuscator obfuscator = new Obfuscator(file);

        obfuscator.RunRules();

        Console.WriteLine($"你输入了: {input}");
    }

}

Console.WriteLine("程序已退出。");
