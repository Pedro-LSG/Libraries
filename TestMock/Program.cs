using Log.Implementacao;
using Newtonsoft.Json;

class Program
{
    private readonly static string stackTraceDefault = "This example of Exception.Message, generates the following output.";
    private readonly static string messageDefault = "Erro na obtenção dos dados.";
    private readonly static string registroDefault = "{\"Message\":\"Teste\"}";
    static void Main(string[] args)
    {
        Registro registro = new();
        var retorno = registro.GravaRegistro(
            JsonConvert.DeserializeObject(registroDefault), 
            messageDefault,
            nameof(Main),
            stackTraceDefault);
    }
}