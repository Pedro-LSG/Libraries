using Log.Interface;
using Newtonsoft.Json;
using System.IO.Compression;
using System.Text;

namespace Log.Implementacao
{
    public class Registro : IRegistro
    {
        #region [definições padrão]
        private static readonly string _defaultDirectory = "C:\\Log\\";
        private static readonly string _defaultArchiveLog = "\\log.zip";
        private static readonly string _temp = "C:\\Users\\Public\\log.txt";
        #endregion

        #region [métodos]
        /// <summary>
        /// Método responsável por gravar os registros dentro do zip.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonObject"></param>
        /// <param name="message"></param>
        /// <param name="fileName"></param>
        /// <param name="stackTrace"></param>
        /// <returns> True se conseguir salvar e false se houver algum erro no processo. </returns>
        public bool GravaRegistro<T>(T jsonObject, string message, string fileName, string stackTrace = null)
        {
            try
            {
                string file = JsonConvert.SerializeObject(jsonObject);
                using (FileStream fs = new FileStream(_temp, FileMode.Create)) 
                {
                    if (!string.IsNullOrEmpty(message))
                        fs.Write(Encoding.UTF8.GetBytes($"{message} --> {file}"));
                    else
                        fs.Write(Encoding.UTF8.GetBytes(file));
                    fs.Flush();
                }
                using (ZipArchive archive = ZipFile.Open(@$"{CriaPastaPadrao()}", ZipArchiveMode.Update))
                {
                    archive.CreateEntryFromFile(_temp, $"{fileName}.txt");
                }
                File.Delete(_temp);
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Verifica se a pasta padrão existe e, caso negativo, cria.
        /// </summary>
        /// <returns> O caminho da pasta. </returns>
        private static string CriaPastaPadrao()
        {
            string path = $"{_defaultDirectory}{ConcatenaDatas()}";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            return @$"{path}{_defaultArchiveLog}";
        }
        /// <summary>
        /// Retorna a data atual separada por '-' para compor o nome da pasta.
        /// </summary>
        /// <returns> Data atual separada por '-' </returns>
        private static string ConcatenaDatas()
            => $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
        public T RecuperaRegistro<T>()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
