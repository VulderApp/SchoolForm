namespace Vulder.School.Form.Core.Utils;

public static class HtmlTemplateUtil
{
    public static async Task<string> Format(Dictionary<string, string> formaters, string templatePath)
    {
        var content = await File.ReadAllTextAsync(templatePath);

        foreach (var formater in formaters)
        {
            content = content.Replace("{" + formater.Key + "}", formater.Value);
        }

        return content;
    }
}