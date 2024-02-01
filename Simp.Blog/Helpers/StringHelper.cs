using System.Text.RegularExpressions;

namespace Simp.Blog.Helpers;

public static partial class StringHelper
{
    [GeneratedRegex("!\\[[^\\]]*\\]\\((blob:[^)]+)\\)", RegexOptions.Compiled)]
    public static partial Regex MarkdownImgBlobGeneratedRegex();
    [GeneratedRegex("!\\[[^\\]]*\\]\\(([^)]+)\\)", RegexOptions.Compiled)]
    public static partial Regex MarkdownImgTempGeneratedRegex();
}