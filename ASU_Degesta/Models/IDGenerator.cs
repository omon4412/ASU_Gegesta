namespace ASU_Degesta.Models;

public static class IDGenerator
{
    public static string GetNewID()
    {
        Guid g = Guid.NewGuid();
        string GuidString = Convert.ToBase64String(g.ToByteArray());
        GuidString = GuidString.Replace("=", "");
        GuidString = GuidString.Replace("+", "");
        GuidString = GuidString.Replace("/", "");
        return GuidString;
    }
}