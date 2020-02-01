namespace CoreCalculator.ServerDefinitions
{
    public interface IBase64Handler
    {
        string Encode(string input);
        string Decode(string base64Input);
    }
}
