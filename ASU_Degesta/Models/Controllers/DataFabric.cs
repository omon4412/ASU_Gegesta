using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Wordprocessing;

namespace ASU_Degesta.Models.Controllers;

public abstract class DataFabric
{
    public static RunProperties CreateTimesNewRoman12()
    {
        var rp12 = new RunProperties()
        {
            FontSize = new FontSize()
            {
                Val = new StringValue("24"),
            },
            RunFonts = new RunFonts()
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman"
            }
        };
        return rp12;
    }
    
    public static RunProperties CreateTimesNewRoman16()
    {
        var rp12 = new RunProperties()
        {
            FontSize = new FontSize()
            {
                Val = new StringValue("32"),
            },
            RunFonts = new RunFonts()
            {
                Ascii = "Times New Roman",
                HighAnsi = "Times New Roman"
            }
        };
        return rp12;
    }
}